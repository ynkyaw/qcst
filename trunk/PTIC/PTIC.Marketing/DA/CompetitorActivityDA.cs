/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: CompetitorActivity data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class CompetitorActivityDA
    {
        #region SELECT
        public static DataTable SelectByCompetitorActivityID(int competitorActivityID, SqlConnection conn)
        {
            DataTable table = null;
            string tableName = "CompetitorActivityTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_CompetitorActivitySelectByCompetitorActivityID";

                command.Parameters.AddWithValue("@p_CompetitorActivityID", competitorActivityID);
                command.Parameters["@p_CompetitorActivityID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
        #endregion

        #region INSERT
        public static int Insert(CompetitorActivity compActivity, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompetitorActivityInsert";

                cmd.Parameters.AddWithValue("@p_A_P_Remark", compActivity.A_P_Remark);
                cmd.Parameters["@p_A_P_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketPromoRemark", compActivity.MarketPromoRemark);
                cmd.Parameters["@p_MarketPromoRemark"].Direction = ParameterDirection.Input;
               
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newCompetitorActivity"></param>
        /// <param name="newCompetitor_A_P_Supports"></param>
        /// <param name="newCompetitorMarketPromotions"></param>
        /// <param name="conn"></param>
        /// <returns>Return a new inserted CompetitorActivityID</returns>
        public static int? Insert(CompetitorActivity newCompetitorActivity,
            List<Competitor_A_P_Support> newCompetitor_A_P_Supports, 
            List<CompetitorMarketPromotion> newCompetitorMarketPromotions, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int? insertedCompetitorActivityID = null;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new CompetitorActivity
                cmd.CommandText = "usp_CompetitorActivityInsert";

                cmd.Parameters.AddWithValue("@p_A_P_Remark", newCompetitorActivity.A_P_Remark);
                cmd.Parameters["@p_A_P_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketPromoRemark", newCompetitorActivity.MarketPromoRemark);
                cmd.Parameters["@p_MarketPromoRemark"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedCompetitorActivityID = (int)insertedIDObj;
                // Clear parameters of stored procedure usp_CompetitorActivityInsert
                cmd.Parameters.Clear();
                // Insert new CompetitorA_PSupport
                cmd.CommandText = "usp_CompetitorA_P_SupportInsert";
                foreach (Competitor_A_P_Support newCompetitor_A_P_Support in newCompetitor_A_P_Supports)
                {
                    cmd.Parameters.AddWithValue("@p_CActivityID", insertedCompetitorActivityID);
                    cmd.Parameters["@p_CActivityID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_BrandID", newCompetitor_A_P_Support.BrandID);
                    cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_A_P_Type", newCompetitor_A_P_Support.A_P_Type);
                    cmd.Parameters["@p_A_P_Type"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_A_P_Size", newCompetitor_A_P_Support.A_P_Size);
                    cmd.Parameters["@p_A_P_Size"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Period", newCompetitor_A_P_Support.Period);
                    cmd.Parameters["@p_Period"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Result", newCompetitor_A_P_Support.Result);
                    cmd.Parameters["@p_Result"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                    // clear parameters of each usp_CompetitorA_P_SupportInsert
                    cmd.Parameters.Clear();
                }

                // insert new CompetitorMarketPromotion
                cmd.CommandText = "usp_CompetitorMarketPromotionInsert";
                foreach (CompetitorMarketPromotion newCompetitorMarketPromotion in newCompetitorMarketPromotions)
                {
                    cmd.Parameters.AddWithValue("@p_CActivityID", insertedCompetitorActivityID);
                    cmd.Parameters["@p_CActivityID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_BrandID", newCompetitorMarketPromotion.BrandID);
                    cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_PromoActivity", newCompetitorMarketPromotion.PromoActivity);
                    cmd.Parameters["@p_PromoActivity"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FromDate", 
                        newCompetitorMarketPromotion.FromDate != DateTime.MinValue ? newCompetitorMarketPromotion.FromDate : (object)DBNull.Value);
                    cmd.Parameters["@p_FromDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ToDate",
                        newCompetitorMarketPromotion.ToDate != DateTime.MinValue ? newCompetitorMarketPromotion.ToDate : (object)DBNull.Value);
                    cmd.Parameters["@p_ToDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Period", newCompetitorMarketPromotion.Period);
                    cmd.Parameters["@p_Period"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Result", newCompetitorMarketPromotion.Result);
                    cmd.Parameters["@p_Result"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                    // clear parameters of each usp_CompetitorMarketPromotionInsert
                    cmd.Parameters.Clear();
                }
                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return insertedCompetitorActivityID;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return insertedCompetitorActivityID;
        }
        #endregion

        #region UPDATE
        public static int UpdateByCompetitorActivityID(CompetitorActivity compActivity, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompetitorActivityUpdateByCompetitorActivityID";

                cmd.Parameters.AddWithValue("@p_CompetitorActivityID", compActivity.CompetitorActivityID);
                cmd.Parameters["@p_CompetitorActivityID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_A_P_Remark", compActivity.A_P_Remark);
                cmd.Parameters["@p_A_P_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketPromoRemark", compActivity.MarketPromoRemark);
                cmd.Parameters["@p_MarketPromoRemark"].Direction = ParameterDirection.Input;
             
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByCompetitorActivityID(int competitorActivityID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompetitorActivityDeleteByCompetitorActivityID";

                cmd.Parameters.AddWithValue("@p_CompetitorActivityID", competitorActivityID);
                cmd.Parameters["@p_CompetitorActivityID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion
      
    }
}

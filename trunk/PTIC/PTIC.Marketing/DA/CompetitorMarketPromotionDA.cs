/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: CompetitorMarketPromotion data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.DA
{
    public class CompetitorMarketPromotionDA
    {
        #region SELECT
        public static DataTable SelectByCompetitorActivityID(int competitorActivityID, SqlConnection conn)
        {
            DataTable table = null;
            string tableName = "CompetitorMarketPromotionTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_CompetitorMarketPromotionSelectByCActivityID";

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
        public static int Insert(CompetitorMarketPromotion newCompetitorMarketPromotion, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompetitorMarketPromotionInsert";

                cmd.Parameters.AddWithValue("@p_CActivityID", newCompetitorMarketPromotion.CActivityID);
                cmd.Parameters["@p_CActivityID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BrandID", newCompetitorMarketPromotion.BrandID);
                cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PromoActivity", newCompetitorMarketPromotion.PromoActivity);
                cmd.Parameters["@p_PromoActivity"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FromDate", newCompetitorMarketPromotion.FromDate);
                cmd.Parameters["@p_FromDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ToDate", newCompetitorMarketPromotion.ToDate);
                cmd.Parameters["@p_ToDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Peroid", newCompetitorMarketPromotion.Period);
                cmd.Parameters["@p_Peroid"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Result", newCompetitorMarketPromotion.Result);
                cmd.Parameters["@p_Result"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(CompetitorMarketPromotion mdCompetitorMarketPromotion, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompetitorMarketPromotionUpdateByID";

                cmd.Parameters.AddWithValue("@p_CompetitorMarketPromotionID", mdCompetitorMarketPromotion.ID);
                cmd.Parameters["@p_CompetitorMarketPromotionID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CActivityID", mdCompetitorMarketPromotion.CActivityID);
                cmd.Parameters["@p_CActivityID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BrandID", mdCompetitorMarketPromotion.BrandID);
                cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PromoActivity", mdCompetitorMarketPromotion.PromoActivity);
                cmd.Parameters["@p_PromoActivity"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FromDate", mdCompetitorMarketPromotion.FromDate);
                cmd.Parameters["@p_FromDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ToDate", mdCompetitorMarketPromotion.ToDate);
                cmd.Parameters["@p_ToDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Period", mdCompetitorMarketPromotion.Period);
                cmd.Parameters["@p_Period"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Result", mdCompetitorMarketPromotion.Result);
                cmd.Parameters["@p_Result"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                throw;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(int competitorMarketPromotionID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompetitorMarketPromotionDeleteByID";

                cmd.Parameters.AddWithValue("@p_CompetitorMarketPromotionID", competitorMarketPromotionID);
                cmd.Parameters["@p_CompetitorMarketPromotionID"].Direction = ParameterDirection.Input;
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

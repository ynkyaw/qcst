/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: MarketingDetail data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using System.Data;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class MarketingDetailDA
    {
        #region SELECT
        public static DataTable SelectByMarketingDetailID(int marketingDetailID)
        {
            DataTable table = null;
            string tableName = "MarketingDetailTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_MarketingDetailSelectByMarketingDetailID";

                command.Parameters.AddWithValue("@p_MarketingDetailID", marketingDetailID);
                command.Parameters["@p_MarketingDetailID"].Direction = ParameterDirection.Input;

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newMarketingDetail"></param>
        /// <param name="conn"></param>
        /// <returns>Return an inserted ID</returns>
        public static int? Insert(
            MarketingDetail newMarketingDetail,
            List<OwnBrandInMarketingDetail> newOwnBrandInMarketingDetail,
            List<CompetitorBrandInMarketingDetail> newCompetitorBrandInMarketingDetail)
        {
            int? insertedMarketingDetailID = null;            
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MarketingDetailInsert";

                cmd.Parameters.AddWithValue("@p_CusID", newMarketingDetail.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EmpID", newMarketingDetail.EmpID);
                cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketingPlanID", newMarketingDetail.MarketingPlanID);
                cmd.Parameters["@p_MarketingPlanID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_BrandID", newMarketingDetail.BrandID);
                //cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderID", newMarketingDetail.OrderID);
                cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_A_P_UsageID", newMarketingDetail.A_P_UsageID);
                cmd.Parameters["@p_A_P_UsageID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CustomerComplaintID", newMarketingDetail.CustomerComplaintID);
                cmd.Parameters["@p_CustomerComplaintID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CompetitorActivityID", newMarketingDetail.CompetitorActivityID);
                cmd.Parameters["@p_CompetitorActivityID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketedDate", newMarketingDetail.MarketedDate);
                cmd.Parameters["@p_MarketedDate"].Direction = ParameterDirection.Input;

                //return cmd.ExecuteNonQuery();
                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;
                insertedMarketingDetailID = (int)insertedIDObj;
                cmd.Parameters.Clear();

                //  CommandText - Update

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_OwnBrandInMarketingDetailInsert";

                foreach (OwnBrandInMarketingDetail ownBrandMkD in newOwnBrandInMarketingDetail)
                {
                    cmd.Parameters.AddWithValue("@p_MarketingDetailID", insertedMarketingDetailID);
                    cmd.Parameters["@p_MarketingDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_BrandID", ownBrandMkD.BrandID);
                    cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompBrandInMarketingDetailInsert";

                foreach (CompetitorBrandInMarketingDetail newCompBrandMkD in newCompetitorBrandInMarketingDetail)
                {
                    cmd.Parameters.AddWithValue("@p_MarketingDetailID", insertedMarketingDetailID);
                    cmd.Parameters["@p_MarketingDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_BrandID", newCompBrandMkD.BrandID);
                    cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }

            }
            catch (SqlException sqle)
            {
                return null;
            }
            return insertedMarketingDetailID;
        }
        #endregion

        #region UPDATE
        public static int UpdateByMarketingDetailID(MarketingDetail mdMarketingDetail,
            List<OwnBrandInMarketingDetail> newOwnBrandInMarketingDetail,
            List<CompetitorBrandInMarketingDetail> newCompetitorBrandInMarketingDetail)
        {
            try
            {
                int affectedRow = 0;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MarketingDetailUpdateByMarketingDetailID";

                cmd.Parameters.AddWithValue("@p_MarketingDetailID", mdMarketingDetail.ID);
                cmd.Parameters["@p_MarketingDetailID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", mdMarketingDetail.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EmpID", mdMarketingDetail.EmpID);
                cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketingPlanID", mdMarketingDetail.MarketingPlanID);
                cmd.Parameters["@p_MarketingPlanID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_BrandID", mdMarketingDetail.BrandID);
                //cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderID", mdMarketingDetail.OrderID);
                cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_A_P_UsageID", mdMarketingDetail.A_P_UsageID);
                cmd.Parameters["@p_A_P_UsageID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CustomerComplaintID", mdMarketingDetail.CustomerComplaintID);
                cmd.Parameters["@p_CustomerComplaintID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CompetitorActivityID", mdMarketingDetail.CompetitorActivityID);
                cmd.Parameters["@p_CompetitorActivityID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketedDate", mdMarketingDetail.MarketedDate);
                cmd.Parameters["@p_MarketedDate"].Direction = ParameterDirection.Input;

                affectedRow +=cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_OwnBrandInMarketingDetailInsert";

                foreach (OwnBrandInMarketingDetail ownBrandMkD in newOwnBrandInMarketingDetail)
                {
                    cmd.Parameters.AddWithValue("@p_MarketingDetailID", mdMarketingDetail.ID);
                    cmd.Parameters["@p_MarketingDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_BrandID", ownBrandMkD.BrandID);
                    cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    affectedRow+=cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompBrandInMarketingDetailInsert";

                foreach (CompetitorBrandInMarketingDetail newCompBrandMkD in newCompetitorBrandInMarketingDetail)
                {
                    cmd.Parameters.AddWithValue("@p_MarketingDetailID", mdMarketingDetail.ID);
                    cmd.Parameters["@p_MarketingDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_BrandID", newCompBrandMkD.BrandID);
                    cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    affectedRow +=cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                return affectedRow;
            }
            catch (SqlException sqle)
            {
                return 0;
            }         
        }
        #endregion

        #region DELETE
        public static int DeleteByMarketingDetailID(int marketingDetailID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MarketingDetailDeleteByMarketingDetailID";

                cmd.Parameters.AddWithValue("@p_MarketingDetailID", marketingDetailID);
                cmd.Parameters["@p_MarketingDetailID"].Direction = ParameterDirection.Input;
               
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

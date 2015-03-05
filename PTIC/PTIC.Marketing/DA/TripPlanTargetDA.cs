/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/08/26 (yyyy/MM/dd)
 * Description: Trip plan target file
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    /// <summary>
    /// Trip plan target form
    /// </summary>
    public class TripPlanTargetDA
    {
        private static BaseDAO _dataAccess = new BaseDAO();

        #region SELECT
        public static DataTable SelectByTripPlanDetailID(int tripPlanDetailID)
        {
            string queryString = string.Format("SELECT * FROM TripPlanTarget WHERE TripPlanDetailID = {0} ", tripPlanDetailID);
            return _dataAccess.SelectByQuery(queryString);
        }

        public static decimal SelectTargetAmountByTripPlanDetailID(int tripPlanDetailID)
        {
            string queryString = string.Format("SELECT ISNULL(SUM(TargetAmount), 0) FROM TripPlanTarget WHERE TripPlanDetailID = {0} ", tripPlanDetailID);
            return (decimal)_dataAccess.SelectScalar(queryString);
        }
        #endregion

        #region INSERT
        public static int Insert(TripPlanDetail tripPlanDetail, List<TripPlanTarget> tripPlanTargets)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            string insertCommnadText = string.Empty;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;

                insertCommnadText = "INSERT INTO [TripPlanTarget] ([TripPlanDetailID], [BrandID], [TargetAmount]) "
                                                + " VALUES (@p_TripPlanDetailID, @p_BrandID, @p_TargetAmount)";
                cmd.CommandText = insertCommnadText;

                foreach(TripPlanTarget target in tripPlanTargets)
                {
                    cmd.Parameters.AddWithValue("@p_TripPlanDetailID", tripPlanDetail.ID);
                    cmd.Parameters["@p_TripPlanDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_BrandID", target.BrandID);
                    cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TargetAmount", target.TargetAmount);
                    cmd.Parameters["@p_TargetAmount"].Direction = ParameterDirection.Input;
                
                    cmd.ExecuteNonQuery();
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
                    affectedRows = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
                DBManager.GetInstance().CloseDbConnection();
            }
            return affectedRows;
        }
        #endregion

        #region UPDATE
        public static int Update(TripPlanDetail tripPlanDetail, List<TripPlanTarget> tripPlanTargets)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            string insertCommnadText = string.Empty;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;

                insertCommnadText = "UPDATE [TripPlanTarget] SET [BrandID]=@p_BrandID, [TargetAmount]=@p_TargetAmount WHERE  ID=@p_ID";
                cmd.CommandText = insertCommnadText;

                foreach (TripPlanTarget target in tripPlanTargets)
                {
                    cmd.Parameters.AddWithValue("@p_BrandID", target.BrandID);
                    cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TargetAmount", target.TargetAmount);
                    cmd.Parameters["@p_TargetAmount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ID", target.ID);
                    cmd.ExecuteNonQuery();
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
                    affectedRows = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
                DBManager.GetInstance().CloseDbConnection();
            }
            return affectedRows;
        }
        #endregion

        #region DELETE
        public static int Delete(TripPlanDetail tripPlanDetail, List<TripPlanTarget> tripPlanTargets)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            string insertCommnadText = string.Empty;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;

                insertCommnadText = "Delete [TripPlanTarget] WHERE  ID=@p_ID";
                cmd.CommandText = insertCommnadText;

                foreach (TripPlanTarget target in tripPlanTargets)
                {
                    

                    cmd.Parameters.AddWithValue("@p_ID", target.ID);
                    cmd.ExecuteNonQuery();
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
                    affectedRows = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
                DBManager.GetInstance().CloseDbConnection();
            }
            return affectedRows;
        }

        #endregion

    }
}

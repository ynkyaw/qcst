/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/06/02 (yyyy/MM/dd)
 * Description: Service Fact data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;
using PTIC.Sale.Entities;
using System.Data.SqlClient;

namespace PTIC.Sale.DA
{
    /// <summary>
    /// Service fact data access
    /// </summary>
    public class SvcFactDA
    {
        /// <summary>
        /// 
        /// </summary>
        private static BaseDAO _dataAccess = new BaseDAO();

        #region SELECT
        public static DataTable SelectByID(int? svcFactID)
        {
            string queryString = "SELECT * FROM SvcFact WHERE ID = {0}";
            return _dataAccess.SelectByQuery(string.Format(queryString, svcFactID));
        }
        #endregion

        #region INSERT
        /// <summary>
        /// Insert new service fact
        /// </summary>
        /// <param name="newSvcFact"></param>
        /// <param name="salesServiceID"></param>
        /// <param name="conn"></param>
        /// <returns>Return inserted service fact id</returns>
        public static int? Insert(SvcFact newSvcFact, int salesServiceID, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int? insertedSvcFactID = null;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new service fact
                cmd.CommandText = "usp_SvcFactInsert";

                cmd.Parameters.AddWithValue("@p_SvcTestID", newSvcFact.SvcTestID);
                cmd.Parameters["@p_SvcTestID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripID", newSvcFact.TripID);
                cmd.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RouteID", newSvcFact.RouteID);
                cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownID", newSvcFact.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownshipID", newSvcFact.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ShopID", newSvcFact.ShopID);
                cmd.Parameters["@p_ShopID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedDuration", newSvcFact.UsedDuration);
                cmd.Parameters["@p_UsedDuration"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedPlace", newSvcFact.UsedPlace);
                cmd.Parameters["@p_UsedPlace"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedAmp", newSvcFact.UsedAmp);
                cmd.Parameters["@p_UsedAmp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedSize", newSvcFact.UsedSize);
                cmd.Parameters["@p_UsedSize"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ChargingTime", newSvcFact.ChargingTime);
                cmd.Parameters["@p_ChargingTime"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ContinuousUsedTime", newSvcFact.ContinuousUsedTime);
                cmd.Parameters["@p_ContinuousUsedTime"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Address", newSvcFact.Address);
                cmd.Parameters["@p_Address"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DateToSvc", newSvcFact.DateToSvc);
                cmd.Parameters["@p_DateToSvc"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesServiceID", salesServiceID);
                cmd.Parameters["@p_SalesServiceID"].Direction = ParameterDirection.Input;
             
                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;
                insertedSvcFactID = (int)insertedIDObj;
                
                // commit transaction
                transaction.Commit();

                if (!insertedSvcFactID.HasValue || insertedSvcFactID == 0)
                    transaction.Rollback();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return null;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return insertedSvcFactID;
        }
        #endregion

        #region UPDATE
        public static int Update(SvcFact updateSvcFact, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SvcFactUpdate";

                cmd.Parameters.AddWithValue("@p_SvcFactID", updateSvcFact.ID);
                cmd.Parameters["@p_SvcFactID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SvcTestID", updateSvcFact.SvcTestID);
                cmd.Parameters["@p_SvcTestID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripID", updateSvcFact.TripID);
                cmd.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RouteID", updateSvcFact.RouteID);
                cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownID", updateSvcFact.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownshipID", updateSvcFact.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ShopID", updateSvcFact.ShopID);
                cmd.Parameters["@p_ShopID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedDuration", updateSvcFact.UsedDuration);
                cmd.Parameters["@p_UsedDuration"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedPlace", updateSvcFact.UsedPlace);
                cmd.Parameters["@p_UsedPlace"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedAmp", updateSvcFact.UsedAmp);
                cmd.Parameters["@p_UsedAmp"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedSize", updateSvcFact.UsedSize);
                cmd.Parameters["@p_UsedSize"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ChargingTime", updateSvcFact.ChargingTime);
                cmd.Parameters["@p_ChargingTime"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ContinuousUsedTime", updateSvcFact.ContinuousUsedTime);
                cmd.Parameters["@p_ContinuousUsedTime"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Address", updateSvcFact.Address);
                cmd.Parameters["@p_Address"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DateToSvc", updateSvcFact.DateToSvc);
                cmd.Parameters["@p_DateToSvc"].Direction = ParameterDirection.Input;
                              
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE

        #endregion
    }
}

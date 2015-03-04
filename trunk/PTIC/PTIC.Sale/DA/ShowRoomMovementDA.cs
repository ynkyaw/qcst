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
    public class ShowRoomMovementDA
    {
        private static BaseDAO b = new BaseDAO();
        #region SELECT
        public static DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM WarehouseMovement WHERE ID=0");
            }
            catch (Exception)
            {                
                throw;
            }
            return dt;
        }

        public static DataTable SelectByCondition(DateTime DeliverDate, int SalesPerson, int MoveFrom, int MoveTo,int VenNo)
        {
            DataTable dt;
            try
            {
                string queryStr = "SELECT * FROM WarehouseMovement WHERE CONVERT(VARCHAR(10),DeliverDate,103)  = CONVERT(VARCHAR(10),CAST ('{0}' as DATE) ,103) AND SalePersonID = {1} AND MoveFrom ={2} AND MoveTo = {3} AND VenID = {4}";
                dt = b.SelectByQuery(string.Format(queryStr, DeliverDate, SalesPerson, MoveFrom, MoveTo,VenNo));
            }
            catch (Exception)
            {
                
                throw;
            }
            return dt;
        }

        #endregion

        #region INSERT
        //public int Insert(ShowRoomMovement showRoomMovement)
        //{
        //    int lastInsertId = 0;
        //    try
        //    {
        //        lastInsertId = b.InsertInto("ShowRoomMovement", b.ConvertColName(showRoomMovement), b.ConvertValueList(showRoomMovement));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lastInsertId;
        //}

        public static int Insert(ShowRoomMovement showRoomMovement,SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedrow = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                cmd.CommandText = "usp_WarehouseMovementInsert";

                cmd.Parameters.AddWithValue("@p_DeliverDate", showRoomMovement.DeliverDate);
                cmd.Parameters["@p_DeliverDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalePersonID", showRoomMovement.SalePersonID);
                cmd.Parameters["@p_SalePersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MoveFrom", showRoomMovement.MoveFrom);
                cmd.Parameters["@p_MoveFrom"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MoveTo", showRoomMovement.MoveTo);
                cmd.Parameters["@p_MoveTo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", showRoomMovement.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductID", showRoomMovement.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RequestQty", showRoomMovement.RequestQty);
                cmd.Parameters["@p_RequestQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeliverQty",showRoomMovement.DeliverQty);
                cmd.Parameters["@p_DeliverQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReceivedQty", showRoomMovement.ReceivedQty);
                cmd.Parameters["@p_ReceivedQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", (int)PTIC.Common.Enum.WarehouseMovementStatus.Requested);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.VehicleStockBy.Warehouse);
                cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_StockByVen", (int)PTIC.Common.Enum.WarehouseStockBy.Vehicle);
                cmd.Parameters["@p_StockByVen"].Direction = ParameterDirection.Input;

                    affectedrow += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_MobileServiceRecordInsert
                   cmd.Parameters.Clear();
                
                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return affectedrow = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedrow;
        }
        #endregion

        #region UPDATE
        public static int Update(ShowRoomMovement showRoomMovement, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedrow = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                cmd.CommandText = "usp_WarehouseMovementUpdate";

                cmd.Parameters.AddWithValue("@p_MovementID", showRoomMovement.ID);
                cmd.Parameters["@p_MovementID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeliverDate", showRoomMovement.DeliverDate);
                cmd.Parameters["@p_DeliverDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalePersonID", showRoomMovement.SalePersonID);
                cmd.Parameters["@p_SalePersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MoveFrom", showRoomMovement.MoveFrom);
                cmd.Parameters["@p_MoveFrom"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MoveTo", showRoomMovement.MoveTo);
                cmd.Parameters["@p_MoveTo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", showRoomMovement.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductID", showRoomMovement.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RequestQty", showRoomMovement.RequestQty);
                cmd.Parameters["@p_RequestQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeliverQty", showRoomMovement.DeliverQty);
                cmd.Parameters["@p_DeliverQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReceivedQty", showRoomMovement.ReceivedQty);
                cmd.Parameters["@p_ReceivedQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", (int)PTIC.Common.Enum.WarehouseMovementStatus.Received);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.VehicleStockBy.Warehouse);
                cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_StockByVen", (int)PTIC.Common.Enum.WarehouseStockBy.Vehicle);
                cmd.Parameters["@p_StockByVen"].Direction = ParameterDirection.Input;

                affectedrow += cmd.ExecuteNonQuery();
                // clear parameters of each usp_MobileServiceRecordInsert
                cmd.Parameters.Clear();

                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return affectedrow = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedrow;
        }    
        #endregion

        public  bool isExist(string key)
        {
            return b.CheckRec("ShowRoomMovement", key);
        }
    }
}

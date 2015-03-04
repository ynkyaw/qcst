/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Delivery detail data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Sale.Entities;
using PTIC.Common.DA;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    /// <summary>
    /// Delivery detail data access
    /// </summary>
    public class DeliveryDetailDA
    {
        public static BaseDAO b = new BaseDAO();

        public static DataTable SelectStockQtyByProductID(int ProductID)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM StockInWarehouse INNER JOIN Warehouse ON Warehouse.ID = StockInWarehouse.WarehouseID AND Warehouse.IsSub = 1 WHERE ProductID =" + ProductID);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return dt;
        }

        #region SELECT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DataTable SelectAll(SqlConnection conn)
        {
            DataTable table = new DataTable("DeliveryDetailTable");
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_DeliveryDetailSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                return table;
            }
            catch (SqlException sqle)
            {
                throw;
            }
        }

        public static DataTable SelectByDeliveryID(int deliveryID)
        {
            DataTable table = null;
            string tableName = "DeliveryDetailTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_DeliveryDetailSelectByDeliveryID";

                command.Parameters.AddWithValue("@p_DeliveryID", deliveryID);
                command.Parameters["@p_DeliveryID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return table;
        }
        #endregion

        #region INSERT
        /// <summary>
        ///
        /// </summary>
        /// <param name="newDeliveryDetail"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int Insert(DeliveryDetail newDeliveryDetail, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeliveryDetailInsert";

                cmd.Parameters.AddWithValue("@p_DeliveryID", newDeliveryDetail.DeliveryID);
                cmd.Parameters["@p_DeliveryID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductID", newDeliveryDetail.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderQty", newDeliveryDetail.OrderQty);
                cmd.Parameters["@p_OrderQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeliverQty", newDeliveryDetail.DeliverQty);
                cmd.Parameters["@p_DeliverQty"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdDeliveryDetail"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int UpdateByDeliveryDetailID(DeliveryDetail mdDeliveryDetail, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeliveryDetailUpdateByDeliveryDetailID";

                cmd.Parameters.AddWithValue("@p_DeliveryDetailID", mdDeliveryDetail.ID);
                cmd.Parameters["@p_DeliveryDetailID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeliveryID", mdDeliveryDetail.DeliveryID);
                cmd.Parameters["@p_DeliveryID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductID", mdDeliveryDetail.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderQty", mdDeliveryDetail.OrderQty);
                cmd.Parameters["@p_OrderQty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeliverQty", mdDeliveryDetail.DeliverQty);
                cmd.Parameters["@p_DeliverQty"].Direction = ParameterDirection.Input;
             
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deliveryDetailID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int DeleteByDeliveryDetailID(string deliveryDetailID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeliveryDetailDeleteByDeliveryDetailID";

                cmd.Parameters.AddWithValue("@p_DeliveryDetailID", deliveryDetailID);
                cmd.Parameters["@p_DeliveryDetailID"].Direction = ParameterDirection.Input;

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

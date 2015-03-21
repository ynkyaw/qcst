/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: Order data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Common.DA;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    /// <summary>
    /// Order data access
    /// </summary>
    public class OrderDA
    {
        /// <summary>
        /// 
        /// </summary>
        private static BaseDAO b = new BaseDAO();

        #region SELECT
        /// <summary>
        /// Retrieve all orders from database
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all orders</returns>
        public static DataTable SelectAll()
        {
            DataTable table = null;
            string tableName = "OrderTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_OrderSelectAll";

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

        /// <summary>
        /// Retrieve all orders between start and end row
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="pageSize">Result row count</param>
        /// <param name="skip">Start row to be skipped along with remaining rows</param>
        /// <returns>Return result DataTable</returns>
        public static DataTable SelectTop(DateTime? startDate, DateTime? endDate,int CustomerID,int DeptID,int pageSize, int skip)
        {
            string queryString = string.Empty;

            if (!startDate.HasValue || !endDate.HasValue)
            {
                queryString = string.Format("SELECT TOP {0}" +
                                        " * FROM uv_Order WHERE OrderID NOT IN" +
                                        " (SELECT TOP {1} OrderID FROM uv_Order ORDER BY OrderDate DESC) ORDER BY OrderDate DESC"
                                        , pageSize, skip);
            }
            else if (startDate.HasValue && endDate.HasValue && CustomerID == -1 && DeptID == -1)
            {
                queryString = string.Format("SELECT TOP {0}" +
                                        " * FROM uv_Order WHERE OrderID NOT IN" +
                                        " (SELECT TOP {1} OrderID FROM uv_Order ORDER BY OrderDate DESC)" +
                                        " AND CAST(OrderDate AS DATE)" +
                                        " BETWEEN '{2}' AND '{3}' ORDER BY OrderDate DESC"
                                        , pageSize, skip, startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"));
            }
            else if (startDate.HasValue && endDate.HasValue && CustomerID == -1 && DeptID != -1)
            {
                queryString = string.Format("SELECT TOP {0}" +
                                        " * FROM uv_Order WHERE OrderID NOT IN" +
                                        " (SELECT TOP {1} OrderID FROM uv_Order ORDER BY OrderDate DESC)" +
                                        " AND CAST(OrderDate AS DATE)" +
                                        " BETWEEN '{2}' AND '{3}' AND DeptID ={4} ORDER BY OrderDate DESC"
                                        , pageSize, skip, startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"),DeptID);
            }
            else if(startDate.HasValue && endDate.HasValue && CustomerID != -1 && DeptID == -1)
            {
                queryString = string.Format("SELECT TOP {0}" +
                                      " * FROM uv_Order WHERE OrderID NOT IN" +
                                      " (SELECT TOP {1} OrderID FROM uv_Order ORDER BY OrderDate DESC)" +
                                      " AND CAST(OrderDate AS DATE)" +
                                      " BETWEEN '{2}' AND '{3}' AND CusID = {4} ORDER BY OrderDate DESC"
                                      , pageSize, skip, startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"), CustomerID);
            }
            else
            {
                queryString = string.Format("SELECT TOP {0}" +
                                       " * FROM uv_Order WHERE OrderID NOT IN" +
                                       " (SELECT TOP {1} OrderID FROM uv_Order ORDER BY OrderDate DESC)" +
                                       " AND CAST(OrderDate AS DATE)" +
                                       " BETWEEN '{2}' AND '{3}' AND CusID = {4} AND DeptID ={5} ORDER BY OrderDate DESC"
                                       , pageSize, skip, startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"),CustomerID,DeptID);
            }

            return new BaseDAO().SelectByQuery(queryString);
        }

        /// <summary>
        /// Retrieve all lost orders between start and end row without any filters
        /// </summary>
        /// <param name="pageSize">Result row count</param>
        /// <param name="skip">Start row to be skipped along with remaining rows</param>
        /// <returns>Return result DataTable</returns>
        public static DataTable SelectLostTop(int pageSize, int skip)
        {
            string queryString = string.Format("SELECT TOP {0}" +
                                        " * FROM uv_LostOrder WHERE OrderID NOT IN " +
                                        "(SELECT TOP {1} OrderID FROM uv_LostOrder)", pageSize, skip);
                    
            return new BaseDAO().SelectByQuery(queryString);
        }

        /// <summary>
        /// Retrieve lost orders between start and end row with specific filters
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="productID">Product ID</param>        
        /// <param name="pageSize">Result row count</param>
        /// <param name="skip">Start row to be skipped along with remaining rows</param>
        /// <returns>Return result DataTable</returns>                
        public static DataTable SelectLostTop(
            DateTime? startDate, DateTime? endDate, 
            //int? customerID, int? productID,
            int? customerID, int? townID, int? productID,
            int pageSize, int skip)
        {             
             string queryString = string.Format("SELECT TOP {0}" +
                                         //" * FROM uv_LostOrder WHERE OrderID NOT IN" +
                                         //" (SELECT TOP {1} OrderID FROM uv_LostOrder)" +
                                         " * FROM uv_LostOrder WHERE DeliveryDetailID NOT IN" +
                                         " (SELECT TOP {1} DeliveryDetailID FROM uv_LostOrder)" +
                                         " @OrderDate @CustomerID @TownID @ProductID", pageSize, skip);
            // Date criteria
            if (startDate.HasValue && endDate.HasValue)
                queryString = queryString.Replace("@OrderDate",
                    string.Format(" AND CAST(OrderDate AS DATE) BETWEEN '{0}' AND '{1}'", 
                    startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd")));
            else
                queryString = queryString.Replace("@OrderDate", string.Empty);

            // CustomerID criteria
            if(customerID.HasValue)
                queryString = queryString.Replace("@CustomerID",
                    string.Format(" AND CustomerID = {0}", customerID.Value));
            else
                queryString = queryString.Replace("@CustomerID", string.Empty);

            // TownID criteria
            if(townID.HasValue)
                queryString = queryString.Replace("@TownID",
                    string.Format(" AND TownID = {0}", townID.Value));
            else
                queryString = queryString.Replace("@TownID", string.Empty);

            // Product criteria
            if(productID.HasValue)
                queryString = queryString.Replace("@ProductID",
                    string.Format(" AND ProductID = {0}", productID.Value));
            else
                queryString = queryString.Replace("@ProductID", string.Empty);

            return new BaseDAO().SelectByQuery(queryString);
        }

        /// <summary>
        /// Retrieve row count over all rows.
        /// </summary>
        /// <returns>Return row count</returns>
        private static int SelectRowCount_bak()
        {            
            string queryString = "SELECT Rows, Id FROM SYSINDEXES WHERE Id = OBJECT_ID('Order') AND IndId < 2";            
            return (int)new BaseDAO().SelectScalar(queryString);
        }

        /// <summary>
        /// Retrieve all order row count.
        ///     If startDate or endDate is null, get row count over all rows. Otherwise, over selected rows.
        /// </summary>
        /// <param name="startDate">Start date filter</param>
        /// <param name="endDate">End date filter</param>
        /// <returns>Return row count</returns>
        public static int SelectOrderRowCount(DateTime? startDate, DateTime? endDate)
        {
            string queryString = string.Empty;
            if (!startDate.HasValue || !endDate.HasValue) // Get count over all rows
            {
                //queryString = "SELECT Rows, Id FROM SYSINDEXES WHERE Id = OBJECT_ID('Order') AND IndId < 2";
                queryString = string.Format("SELECT COUNT(*) FROM uv_Order");
            }
            else
            {
                queryString = string.Format("SELECT COUNT(*) FROM uv_Order" +
                                        //" WHERE CAST(YEAR(OrderDate) AS VARCHAR(4)) + '-' + CAST(MONTH(OrderDate) AS VARCHAR(2)) + '-' + CAST(DAY(OrderDate) AS VARCHAR(2))" +
                                        " WHERE CAST(OrderDate AS DATE)" + // assume DB language setting is us_english
                                        " BETWEEN '{0}' AND '{1}'", startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"));
            }                     
            return (int)new BaseDAO().SelectScalar(queryString);
        }

        /// <summary>
        /// Retrieve all lost order row count.
        ///     If startDate or endDate is null, get row count over all rows. Otherwise, over selected rows.
        /// </summary>
        /// <param name="startDate">Start date filter</param>
        /// <param name="endDate">End date filter</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="townID">Town ID</param>
        /// <param name="productID">Product ID</param>
        /// <returns>Return row count</returns>
        public static int SelectLostOrderRowCount(DateTime? startDate, DateTime? endDate, int? customerID, int? townID, int? productID)
        {
            string queryString = "SELECT COUNT(*) FROM uv_LostOrder";
            if (startDate != null || endDate != null || customerID.HasValue || townID.HasValue || productID.HasValue)
            {
                queryString += " WHERE 1 = 1 @OrderDate @CustomerID @TownID @ProductID";

                // Date criteria
                if (startDate.HasValue && endDate.HasValue)
                    queryString = queryString.Replace("@OrderDate", string.Format(" AND CAST(OrderDate AS DATE) BETWEEN '{0}' AND '{1}'",
                        startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd")));
                else
                    queryString = queryString.Replace("@OrderDate", string.Empty);

                // CustomerID criteria
                if (customerID.HasValue)
                    queryString = queryString.Replace("@CustomerID",
                        string.Format(" AND CustomerID = {0}", customerID.Value));
                else
                    queryString = queryString.Replace("@CustomerID", string.Empty);

                // TownID criteria
                if (townID.HasValue)
                    queryString = queryString.Replace("@TownID",
                        string.Format(" AND TownID = {0}", townID.Value));
                else
                    queryString = queryString.Replace("@TownID", string.Empty);

                // Product criteria
                if (productID.HasValue)
                    queryString = queryString.Replace("@ProductID",
                        string.Format(" AND ProductID = {0}", productID.Value));
                else
                    queryString = queryString.Replace("@ProductID", string.Empty);
            }
                                   
            return (int)new BaseDAO().SelectScalar(queryString);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static int SelectLostOrderRowCount(DateTime? startDate, DateTime? endDate)
        {
            string queryString = string.Empty;
            if (!startDate.HasValue || !endDate.HasValue) // Get count over all rows
            {                
                queryString = string.Format("SELECT COUNT(*) FROM uv_LostOrder");
            }
            else
            {              
                queryString = string.Format("SELECT COUNT(*) FROM uv_LostOrder" +
                        " WHERE CAST(OrderDate AS DATE)" +
                        " BETWEEN '{0}' AND '{1}' ",
                        startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"));
            }

            return (int)new BaseDAO().SelectScalar(queryString);
        }

        public static DataTable SelectOrderListing()
        {
            DataTable table = null;
            string tableName = "OrderTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection(); ;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[usp_OrderListing]";

               

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



        public static DataTable SelectByIsDelivered(bool isDelivered)
        {
            DataTable table = null;
            string tableName = "OrderTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection(); ;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_OrderSelectByIsDelivered";

                command.Parameters.AddWithValue("@p_IsDelivered", isDelivered);
                command.Parameters["@p_IsDelivered"].Direction = ParameterDirection.Input;

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

        public static DataTable SelectByOrderNo(string orderNo)
        {
            DataTable table = null;
            string tableName = "OrderTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_OrderSelectByOrderNo";

                command.Parameters.AddWithValue("@p_OrderNo", orderNo);
                command.Parameters["@p_OrderNo"].Direction = ParameterDirection.Input;

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

        public static DataTable GetDelieveryHistory(int orderNo)
        {
            DataTable table = null;
            string tableName = "OrderTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[usp_DeliveryHistoryByOrderId]";

                command.Parameters.AddWithValue("@p_orderId", orderNo);
                command.Parameters["@p_orderId"].Direction = ParameterDirection.Input;

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

        public static DataTable SelectByID(int orderID)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM uv_Order WHERE OrderID = " + orderID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectLost()
        {
            DataTable table = null;
            string tableName = "LostOrderTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_OrderSelectLost";

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
        /// Insert a new order into database
        /// </summary>
        /// <param name="newOrder">New order entity</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public static int Insert(Order newOrder)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_OrderInsert";

                cmd.Parameters.AddWithValue("@p_CusID", newOrder.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_RouteID", newOrder.RouteID);
                //cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_TripID", newOrder.TripID);
                //cmd.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderReceieverID", newOrder.OrderReceieverID);
                cmd.Parameters["@p_OrderReceieverID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_OrderNo", newOrder.OrderNo);
                //cmd.Parameters["@p_OrderNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderDate", newOrder.OrderDate);
                cmd.Parameters["@p_OrderDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsMain", newOrder.IsMain);
                cmd.Parameters["@p_IsMain"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsDevice", newOrder.IsDevice);
                cmd.Parameters["@p_IsDevice"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newOrder"></param>
        /// <param name="newOrderDetails"></param>
        /// <returns>Return inserted order id</returns>
        public static int? Insert(Order newOrder, List<OrderDetail> newOrderDetails)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            SqlConnection conn = null;            
            int? insertedOrderID = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new order
                cmd.CommandText = "usp_OrderInsert";

                cmd.Parameters.AddWithValue("@p_CusID", newOrder.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderReceieverID", newOrder.OrderReceieverID);
                cmd.Parameters["@p_OrderReceieverID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_OrderNo", newOrder.OrderNo);
                //cmd.Parameters["@p_OrderNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderDate", newOrder.OrderDate);
                cmd.Parameters["@p_OrderDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsMain", newOrder.IsMain);
                cmd.Parameters["@p_IsMain"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsDevice", newOrder.IsDevice);
                cmd.Parameters["@p_IsDevice"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedOrderID = (int)insertedIDObj;
                // clear parameters of usp_OrderInsert
                cmd.Parameters.Clear();
                // insert new order details
                cmd.CommandText = "usp_OrderDetailInsert";
                foreach (OrderDetail newOrderDetail in newOrderDetails)
                {
                    cmd.Parameters.AddWithValue("@p_OrderID", insertedOrderID);
                    cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", newOrderDetail.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_WSPrice", newOrderDetail.WSPrice);
                    cmd.Parameters["@p_WSPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RSPrice", newOrderDetail.RSPrice);
                    cmd.Parameters["@p_RSPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", newOrderDetail.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Amount", newOrderDetail.Amount);
                    cmd.Parameters["@p_Amount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newOrderDetail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                    // clear parameters of each usp_OrderDetailInsert
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
                    throw sqle;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return insertedOrderID;
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Update an existing order by order ID
        /// </summary>
        /// <param name="mdOrder">Order to be updated</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public static int UpdateByOrderID(Order mdOrder)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_OrderUpdateByOrderID";

                cmd.Parameters.AddWithValue("@p_OrderID", mdOrder.ID);
                cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", mdOrder.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_RouteID", mdOrder.RouteID);
                //cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_TripID", mdOrder.TripID);
                //cmd.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderReceieverID", mdOrder.OrderReceieverID);
                cmd.Parameters["@p_OrderReceieverID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_OrderNo", mdOrder.OrderNo);
                //cmd.Parameters["@p_OrderNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderDate", mdOrder.OrderDate);
                cmd.Parameters["@p_OrderDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsMain", mdOrder.IsMain);
                cmd.Parameters["@p_IsMain"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsDevice", mdOrder.IsDevice);
                cmd.Parameters["@p_IsDevice"].Direction = ParameterDirection.Input;
              
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        public static int Update(Order mdOrder, List<OrderDetail> mdOrderDetails, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // update an existing order
                cmd.CommandText = "usp_OrderUpdateByOrderID";

                cmd.Parameters.AddWithValue("@p_OrderID", mdOrder.ID);
                cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", mdOrder.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderReceieverID", mdOrder.OrderReceieverID);
                cmd.Parameters["@p_OrderReceieverID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderNo", mdOrder.OrderNo);
                cmd.Parameters["@p_OrderNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OrderDate", mdOrder.OrderDate);
                cmd.Parameters["@p_OrderDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsMain", mdOrder.IsMain);
                cmd.Parameters["@p_IsMain"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsDevice", mdOrder.IsDevice);
                cmd.Parameters["@p_IsDevice"].Direction = ParameterDirection.Input;

                // execute query
                affectedRows += cmd.ExecuteNonQuery();

                // clear parameters of usp_OrderUpdateByOrderID
                cmd.Parameters.Clear();
                // update an existing order details
                cmd.CommandText = "usp_OrderDetailUpdateByOrderDetailID";
                foreach (OrderDetail mdOrderDetail in mdOrderDetails)
                {
                    cmd.Parameters.AddWithValue("@p_OrderDetailID", mdOrderDetail.ID);
                    cmd.Parameters["@p_OrderDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_OrderID", mdOrderDetail.OrderID);
                    cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", mdOrderDetail.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_WSPrice", mdOrderDetail.WSPrice);
                    cmd.Parameters["@p_WSPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RSPrice", mdOrderDetail.RSPrice);
                    cmd.Parameters["@p_RSPrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", mdOrderDetail.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Amount", mdOrderDetail.Amount);
                    cmd.Parameters["@p_Amount"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", mdOrderDetail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;
                    
                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_OrderDetailUpdateByOrderDetailID
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
            }
            return affectedRows;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Delete order from database by order ID
        /// </summary>
        /// <param name="orderID">Order ID</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public static int DeleteByOrderID(int orderID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_OrderDeleteByOrderID";

                cmd.Parameters.AddWithValue("@p_OrderID", orderID);
                cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;
                
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion
    }
}

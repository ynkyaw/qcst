/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Delivery data access class
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
    /// Delivery data access
    /// </summary>
    public class DeliveryDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECT
        public static DataTable SelectStockInSubStoreByProdutID(int ProductID,int WarehouseID)
        {
            DataTable dt;
            try
            {
                string query = String.Format("SELECT StockInWarehouse.ID,ProductID,WarehouseID,Qty,StockInWarehouse.IsDeleted,ProductName FROM StockInWarehouse "
                                                + "INNER JOIN Product ON Product.ID = StockInWarehouse.ProductID "
                                                + "WHERE WarehouseID = {1} AND ProductID = {0} AND StockInWarehouse.IsDeleted =0", ProductID,WarehouseID);
                dt = b.SelectByQuery(query);
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }


        public static DataTable SelectStockInVehicle(int VanID,int ProductID)
        {
            DataTable dt;
            try
            {
                string query = String.Format("SELECT StockInVehicle.ID,ProductID,VehicleID,Qty,StockInVehicle.IsDeleted,ProductName FROM StockInVehicle "
                                               + "INNER JOIN Product ON Product.ID = StockInVehicle.ProductID WHERE VehicleID = {0} AND ProductID = {1} AND StockInVehicle.IsDeleted = 0", VanID, ProductID);
                dt = b.SelectByQuery(query);
            }
            catch (Exception)
            {                
                throw;
            }
            return dt;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DataTable SelectByStatus(bool status)
        {
            DataTable table = null;
            string tableName = "DeliveryTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_DeliverySelectByStatus";

                command.Parameters.AddWithValue("@p_Status", status);
                command.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                return table;
            }
            catch (SqlException sqle)
            {
                return null;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status">Planned (to deliver) = False, Delivered = True</param>
        /// <param name="salesPersonID"></param>
        /// <param name="customerID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DataTable SelectBy(
            bool status, 
            int? salesPersonID, 
            int? customerID,
            DateTime? startDate, 
            DateTime? endDate)
        {
            DataTable table = null;
            string tableName = "DeliveryTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_DeliverySelectBy";

                command.Parameters.AddWithValue("@p_Status", status);
                command.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_SalesPersonID", salesPersonID);
                command.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_CustomerID", customerID);
                command.Parameters["@p_CustomerID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_DeliveryStartDate", startDate);
                command.Parameters["@p_DeliveryStartDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_DeliveryEndDate", endDate);
                command.Parameters["@p_DeliveryEndDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                return table;
            }
            catch (SqlException sqle)
            {
                return null;
            }
            finally 
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        public static DataTable SelectDeliveryProductList() 
        {
        DataTable table = null;
            string tableName = "DeliveryTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandText = "SELECT d.VenID,Convert(date,d.DeliveryDate) DeliveryDate,DD.ProductID,p.ProductName,b.BrandName,b.ID as BrandId,SUM(DD.DeliverQty) AS DeliverTotalQty ";
                command.CommandText += " FROM Delivery D INNER JOIN DeliveryDetail DD ON D.ID=DD.DeliveryID Inner Join Product P ";
                command.CommandText += " ON P.ID=dd.ProductID  Inner Join ProdSubCategory sb on p.SubCategoryID = sb.ID";
                command.CommandText += " Inner JOin ProdCategory pc on sb.CategoryID=pc.ID Inner Join Brand b on b.ID=pc.BrandID";
                command.CommandText += " GROUP BY d.VenID,Convert(date,d.DeliveryDate),dd.ProductID,p.ProductName,b.BrandName,b.ID";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                return table;
            }
            catch (SqlException sqle)
            {
                return null;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        
        }

        public static DataTable SelectDeliveryPlanByVenIdDate(int venId,DateTime dtp)
        {
            DataTable table = null;
            string tableName = "DeliveryTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                //command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SELECT b.id,dd.ProductID,sum(DeliverQty) ";
                command.CommandText += " FROM DeliveryDetail dd JOIN Delivery d on dd.DeliveryID=d.ID JOIN Product p ON ";
                command.CommandText += " p.ID=dd.ProductID JOIN  ProdSubCategory psc on ";
                command.CommandText += " p.SubCategoryID = psc.ID JOIN ";
                command.CommandText += " ProdCategory pc on psc.CategoryID = pc.ID JOIN  Brand b";
                command.CommandText += " ON b.ID=pc.BrandID ";
                command.CommandText += " where VenID=@p_VenId ";
                command.CommandText += " and DeliveryDate  between @p_fromDate and @p_toDate";
                command.CommandText += " group by b.ID,dd.ProductID";

                //command.Parameters.AddWithValue("@p_VenId",);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                return table;
            }
            catch (SqlException sqle)
            {
                return null;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        /// <summary>
        /// Retrieve records between start and end row
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="employeeID">Employee ID</param>
        /// <param name="customerID">Customer ID</param>
        /// <param name="pageSize">Result row count</param>
        /// <param name="skip">Start row to be skipped along with remaining rows</param>
        /// <returns>Return result DataTable</returns>
        public static DataTable SelectTop(
            DateTime? startDate, DateTime? endDate, 
            int? employeeID, int? customerID, 
            int pageSize, int skip)
        {
            StringBuilder queryString = new StringBuilder(
                    string.Format("SELECT TOP {0}" +
                                        " * FROM uv_DeliveredOrder WHERE DeliveryID NOT IN " +
                                        "(SELECT TOP {1} DeliveryID FROM uv_DeliveredOrder WHERE Status = 1 ORDER BY DeliveryDate DESC) AND Status = 1 @Date @EmployeeID @CustomerID ORDER BY DeliveryDate DESC",
                                        pageSize, skip)
                );
            /*
            if (!startDate.HasValue || !endDate.HasValue) // Not filter by startDate and endDate
            {
                queryString = string.Format("SELECT TOP {0}" +
                                        " * FROM uv_DeliveredOrder WHERE DeliveryID NOT IN " +
                                        "(SELECT TOP {1} DeliveryID FROM uv_DeliveredOrder WHERE Status = 1 ORDER BY DeliveryDate DESC) AND Status = 1 ORDER BY DeliveryDate DESC", 
                                        pageSize, skip);
            }
            else // Filter by startDate and endDate
            {             
                queryString = string.Format("SELECT TOP {0}" +
                                        " * FROM uv_DeliveredOrder WHERE DeliveryID NOT IN" +
                                        " (SELECT TOP {1} DeliveryID FROM uv_DeliveredOrder WHERE Status = 1 ORDER BY DeliveryDate DESC)" +                                        
                                        " AND CAST(DeliveryDate AS DATE)" +
                                        " BETWEEN '{2}' AND '{3}' AND Status = 1 ORDER BY DeliveryDate DESC"
                                        , pageSize, skip, startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"));
            }
             */
            // Filter by date
            if (startDate.HasValue && endDate.HasValue)
            {
                queryString.Replace("@Date",
                    string.Format(" AND CAST(DeliveryDate AS DATE)" +
                                        " BETWEEN '{0}' AND '{1}'", startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"))
                                        );
            }
            else
                queryString.Replace("@Date", string.Empty);
            // Filter by employee
            if (employeeID.HasValue)
                queryString.Replace("@EmployeeID", " AND SalesPersonID = " + employeeID.Value);
            else
                queryString.Replace("@EmployeeID", string.Empty);
            // Filter by customer
            if (customerID.HasValue)
                queryString.Replace("@CustomerID", " AND CusID = " + customerID.Value);
            else
                queryString.Replace("@CustomerID", string.Empty);
            // Execute query
            return new BaseDAO().SelectByQuery(queryString.ToString());
        }

        /// <summary>
        /// Retrieve row count.
        ///     If startDate or endDate is null, get row count over all rows. Otherwise, over selected rows.
        /// </summary>
        /// <param name="startDate">Start date filter</param>
        /// <param name="endDate">End date filter</param>
        /// <param name="employeeID">Employee ID</param>
        /// <param name="customerID">Customer ID</param>
        /// <returns>Return row count</returns>
        public static int SelectRowCount(DateTime? startDate, DateTime? endDate, int? employeeID, int? customerID)
        {
            StringBuilder queryString = new StringBuilder("SELECT COUNT(*) FROM uv_DeliveredOrder WHERE Status = 'True'");
            /*
            if (!startDate.HasValue || !endDate.HasValue) // Get count over all rows
            {
                //queryString = "SELECT Rows, Id FROM SYSINDEXES WHERE Id = OBJECT_ID('Delivery') AND IndId < 2 ";
                queryString = "SELECT COUNT(*) FROM uv_DeliveredOrder WHERE Status= 'True' ";
            }
            else
            {
                queryString = string.Format("SELECT COUNT(*) FROM uv_DeliveredOrder" +
                                        //" WHERE CAST(YEAR(DeliveryDate) AS VARCHAR(4)) + '-' + CAST(MONTH(DeliveryDate) AS VARCHAR(2)) + '-' + CAST(DAY(DeliveryDate) AS VARCHAR(2))" +
                                        " WHERE CAST(DeliveryDate AS DATE)" +
                                        " BETWEEN '{0}' AND '{1}' And Status= 'True'", startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"));
            }
             */ 
            // Filter by date
            if(startDate.HasValue && endDate.HasValue)
            {
                queryString.Append(
                        string.Format(" AND CAST(DeliveryDate AS DATE)" +
                                        " BETWEEN '{0}' AND '{1}'", startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"))
                    );
            }
            // Filter by employee
            if (employeeID.HasValue)
                queryString.Append(" AND SalesPersonID = " + employeeID.Value);
            // Filter by customer
            if (customerID.HasValue)
                queryString.Append(" AND CusID = " + customerID.Value);
            // Execute query string
            return (int)new BaseDAO().SelectScalar(queryString.ToString());
        }
        #endregion

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newDelivery"></param>        
        /// <returns></returns>
        public static int Insert(Delivery newDelivery)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeliveryInsert";

                cmd.Parameters.AddWithValue("@p_VenID", newDelivery.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;
                
                cmd.Parameters.AddWithValue("@p_SalesPersonID", newDelivery.SalesPersonID);
                cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportTypeID", newDelivery.TransportTypeID);
                cmd.Parameters["@p_TransportTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_GateID", newDelivery.GateID);
                cmd.Parameters["@p_GateID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_DeliveryNo", newDelivery.DeliveryNo);
                //cmd.Parameters["@p_DeliveryNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeliveryDate", newDelivery.DeliveryDate);
                cmd.Parameters["@p_DeliveryDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsMain", newDelivery.IsMain);
                cmd.Parameters["@p_IsMain"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsDevice", newDelivery.IsDevice);
                cmd.Parameters["@p_IsDevice"].Direction = ParameterDirection.Input;

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
        /// <param name="newDelivery"></param>
        /// <param name="newDeliveryDetails"></param>
        /// <returns></returns>
        public static int Insert(Delivery newDelivery, List<DeliveryDetail> newDeliveryDetails)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new delivery (delivered)
                cmd.CommandText = "usp_DeliveryInsert";

                cmd.Parameters.AddWithValue("@p_OrderID", newDelivery.OrderID);
                cmd.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", newDelivery.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersonID", newDelivery.SalesPersonID);
                cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportTypeID", newDelivery.TransportTypeID);
                cmd.Parameters["@p_TransportTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_GateID", newDelivery.GateID);
                cmd.Parameters["@p_GateID"].Direction = ParameterDirection.Input;
                
                cmd.Parameters.AddWithValue("@p_DeliveryDate", newDelivery.DeliveryDate);
                cmd.Parameters["@p_DeliveryDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", newDelivery.Status);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsMain", newDelivery.IsMain);
                cmd.Parameters["@p_IsMain"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsDevice", newDelivery.IsDevice);
                cmd.Parameters["@p_IsDevice"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                int insertedDeliveryID = (int)insertedIDObj;
                // clear parameters of usp_DeliveryInsert
                cmd.Parameters.Clear();
                // insert new order details
                cmd.CommandText = "usp_DeliveryDetailInsert";
                foreach (DeliveryDetail newDeliveryDetail in newDeliveryDetails)
                {
                    cmd.Parameters.AddWithValue("@p_DeliveryID", insertedDeliveryID);
                    cmd.Parameters["@p_DeliveryID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", newDeliveryDetail.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_OrderQty", newDeliveryDetail.OrderQty);
                    cmd.Parameters["@p_OrderQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_DeliverQty", newDeliveryDetail.DeliverQty);
                    cmd.Parameters["@p_DeliverQty"].Direction = ParameterDirection.Input;
                    
                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_DeliveryDetailInsert
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

        #region UPDATE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdDelivery"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int UpdateByDeliveryID(Delivery mdDelivery, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeliveryUpdateByDeliveryID";

                cmd.Parameters.AddWithValue("@p_DeliveryID", mdDelivery.ID);
                cmd.Parameters["@p_DeliveryID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", mdDelivery.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersonID", mdDelivery.SalesPersonID);
                cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportTypeID", mdDelivery.TransportTypeID);
                cmd.Parameters["@p_TransportTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_GateID", mdDelivery.GateID);
                cmd.Parameters["@p_GateID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeliveryNo", mdDelivery.DeliveryNo);
                cmd.Parameters["@p_DeliveryNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeliveryDate", mdDelivery.DeliveryDate);
                cmd.Parameters["@p_DeliveryDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsMain", mdDelivery.IsMain);
                cmd.Parameters["@p_IsMain"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsDevice", mdDelivery.IsDevice);
                cmd.Parameters["@p_IsDevice"].Direction = ParameterDirection.Input;

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
        /// <param name="deliveryID"></param>
        /// <param name="status"></param>        
        /// <returns></returns>
        public static int UpdateStatusByDeliveryID(int deliveryID, bool status)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeliveryStatusUpdateByDeliveryID";

                cmd.Parameters.AddWithValue("@p_DeliveryID", deliveryID);
                cmd.Parameters["@p_DeliveryID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", status);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

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
        /// <param name="deliveryID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int DeleteByDeliveryID(string deliveryID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeliveryDeleteByDeliveryID";

                cmd.Parameters.AddWithValue("@p_DeliveryID", deliveryID);
                cmd.Parameters["@p_DeliveryID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        public static bool IsAlreadyPlan(int orderId, out DateTime deliveryPlanDate,out string deliveryNo)
        {
            try
            {
                SqlConnection conn = DBManager.GetInstance().GetDbConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SELECT DeliveryNo,DateAdded FROM Delivery WHERE [Status] =0 and OrderID=@p_orderId";
                cmd.Parameters.AddWithValue("@p_orderId", orderId);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    deliveryNo =  dt.Rows[0]["DeliveryNo"]+string.Empty;
                    DateTime.TryParse(dt.Rows[0]["DateAdded"] + string.Empty, out deliveryPlanDate);
                    return true;


                }
                else 
                {
                    deliveryNo = string.Empty;
                    deliveryPlanDate = new DateTime();
                    return false;
                }
                
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
        }
        #endregion
    }
}

/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 *              Aung Ko Ko <?>
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: Invoice data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    /// <summary>
    /// Invoice voucher (cash/credit) data access class
    /// </summary>
    public class InvoiceDA
    {
        #region SELECT
        /// <summary>
        /// Retrieve all InvoiceVoucher from database
        /// </summary>        
        /// <returns>Return datatable containing all invoices</returns>
        public static DataTable SelectAll()
        {
            DataTable table = null;
            string tableName = "InvoiceVoucherTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_InvoiceVouchersSelectAll";

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

        public static DataTable SelectInvoicesWithoutAnyPayment()
        {
            DataTable table = null;
            string tableName = "InvoicesWithoutAnyPaymentTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM uv_InvoiceList WHERE Paid = 0 AND VoucherType = 0 "
                                                            +" AND InvoiceID NOT IN (SELECT InvoiceID FROM Payment)";
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
        /// Retrieve cash sale by filters
        /// </summary>
        /// <returns>Return datatable containing all cash sale invoices</returns>
        public static DataTable SelectCashSaleInvoice(DateTime? startDate, DateTime? endDate, int? employeeID, int? customerID)
        {
            DataTable table = null;
            string tableName = "CashSaleInvoiceTable";
            StringBuilder queryText = new StringBuilder("SELECT * FROM uv_CashSaleInvoice WHERE 1 = 1");
            try
            {
                table = new DataTable(tableName);
                // Filter by date
                if (startDate.HasValue && endDate.HasValue)
                {
                    queryText.Append(
                        string.Format(" AND CAST(SalesDate AS DATE)" +
                                        " BETWEEN '{0}' AND '{1}'", startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"))
                                        );
                }
                // Filter by employee
                if (employeeID.HasValue)
                    queryText.Append(" AND SalesPersonID = " + employeeID.Value);
                // Filter by customer
                if (customerID.HasValue)
                    queryText.Append(" AND CustomerID = " + customerID);
                //queryText = "SELECT * FROM uv_CashSaleInvoice";

                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandType = CommandType.Text;
                command.CommandText = queryText.ToString();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        /// <summary>
        /// Retrieve all credit invoice by filters
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeID"></param>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static DataTable SelectCreditSaleInvoice(DateTime? startDate, DateTime? endDate, int? employeeID, int? customerID)
        {
            DataTable table = null;
            string tableName = "CreditSaleInvoiceTable";
            StringBuilder queryText = new StringBuilder("SELECT * FROM uv_InvoiceList WHERE 1 = 1");
            try
            {
                table = new DataTable(tableName);
                // Filter by date
                if (startDate.HasValue && endDate.HasValue)
                {
                    queryText.Append(
                        string.Format(" AND CAST(SalesDate AS DATE)" +
                                        " BETWEEN '{0}' AND '{1}'", startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"))
                                        );
                }
                // Filter by employee
                if (employeeID.HasValue)
                    queryText.Append(" AND SalesPersonID = " + employeeID.Value);
                // Filter by customer
                if (customerID.HasValue)
                    queryText.Append(" AND CustomerID = " + customerID);
                
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandType = CommandType.Text;
                command.CommandText = queryText.ToString();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DataTable SelectByInvoiceID(int? invoiceID)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            string tableName = "SalesDetailTable";
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_InvoiceVouchersSelectByInvoiceID";

                command.Parameters.AddWithValue("@p_InvoiceID", invoiceID);
                command.Parameters["@p_InvoiceID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="InvoiceNo"></param>        
        /// <returns>SalesDetailTable</returns>
        /// 
        public static DataTable SelectByInvoiceNo(string InvoiceNo)
        {
            DataTable dt = null;
            string tableName = "SalesDetailTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_InvoiceVouchersSelectByInvoiceNo";

                command.Parameters.AddWithValue("@p_InvoiceNo", InvoiceNo);
                command.Parameters["@p_InvoiceNo"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }
        #endregion
        
        #region SELECT FromDeliveryNoteView
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DeliveryNo"></param>        
        /// <returns></returns>
        public static DataTable SelectByDeliveryNo(string DeliveryNo)
        {
            DataTable dt = null;
            string tableName = "InvoiceTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_InvoiceSelectByDeliveryNo";

                command.Parameters.AddWithValue("@p_DeliveryNo", DeliveryNo);
                command.Parameters["@p_DeliveryNo"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InvoiceID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DataTable SelectByInvoiceID(string InvoiceID) 
        {
            DataTable dt = null;
            string tableName = "SaleDetailTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_InvoiceVouchersSelectByInvoiceID";

                command.Parameters.AddWithValue("@p_InvoiceID", InvoiceID);
                command.Parameters["@p_InvoiceID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }
        #endregion

        #region INSERT
          /// <summary>
        /// 
        /// </summary>
        /// <param name="newInvoice"></param>
        /// <param name="newSaleDetailRecords"></param>        
        /// <returns>Return an inserted Invoice</returns>
        public static int? Insert(
            Invoice newInvoice, 
            List<SaleDetail> newSaleDetailRecords, 
            int VenID,
            int WarehouseID)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int? insertedInvoiceID = null;
            int affectedrow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new Invoice
                cmd.CommandText = "usp_InvoiceVoucherInsert";

                cmd.Parameters.AddWithValue("@p_CusID", newInvoice.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeliveryID", newInvoice.DeliveryID);
                cmd.Parameters["@p_DeliveryID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersonID", newInvoice.SalesPersonID);
                cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportTypeID", newInvoice.TransportTypeID);
                cmd.Parameters["@p_TransportTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportGateID", newInvoice.TransportGateID);
                cmd.Parameters["@p_TransportGateID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesDate", newInvoice.SalesDate);
                cmd.Parameters["@p_SalesDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SaleType", newInvoice.SaleType);
                cmd.Parameters["@p_SaleType"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_GateInvNo", newInvoice.GateInvNo);
                cmd.Parameters["@p_GateInvNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportCharges", newInvoice.TransportCharges);
                cmd.Parameters["@p_TransportCharges"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TotalAmt", newInvoice.TotalAmt);
                cmd.Parameters["@p_TotalAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", newInvoice.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_InvoiceNo", newInvoice.InvoiceNo);
                cmd.Parameters["@p_InvoiceNo"].Direction = ParameterDirection.Input;
               
                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;

                insertedInvoiceID = (int)insertedIDObj;
                // clear parameters of usp_InvoiceVoucherInsert
                cmd.Parameters.Clear();
                // insert new SaleDetail
                cmd.CommandText = "usp_SaleDetailInsert";
                foreach (SaleDetail newSaleDetialRecord in newSaleDetailRecords)
                {
                    cmd.Parameters.AddWithValue("@p_InvoiceID", insertedInvoiceID);
                    cmd.Parameters["@p_InvoiceID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", newSaleDetialRecord.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SalePrice", newSaleDetialRecord.SalePrice);
                    cmd.Parameters["@p_SalePrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", newSaleDetialRecord.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Package", newSaleDetialRecord.Package);
                    cmd.Parameters["@p_Package"].Direction = ParameterDirection.Input;

                    if (VenID == 0) // it is not via vehicle
                    {
                        cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.WarehouseStockBy.CustomerOrSale);
                        cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;
                    }
                    else // via warehouse
                    {
                        cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.VehicleStockBy.CustomerOrSale);
                        cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;
                    }

                    cmd.Parameters.AddWithValue("@p_VenID", VenID);
                    cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_WarehouseID", WarehouseID);
                    cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SalesPersonID", newInvoice.SalesPersonID);
                    cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SalesDate", newInvoice.SalesDate);
                    cmd.Parameters["@p_SalesDate"].Direction = ParameterDirection.Input;
                   
                    // cmd.Parameters.AddWithValue("@p_Amount", newSaleDetialRecord.Amount);
                    //cmd.Parameters["@p_Amount"].Direction = ParameterDirection.Input;
                    
                    affectedrow += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_SaleDetailInsert
                    cmd.Parameters.Clear();
                }

                if (newInvoice.DeliveryID != null)
                {
                    // Update Status
                    cmd.CommandText = "usp_DeliveryStatusUpdateByDeliveryID";

                    cmd.Parameters.AddWithValue("@p_DeliveryID", newInvoice.DeliveryID);
                    cmd.Parameters["@p_DeliveryID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Status", true);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    affectedrow += cmd.ExecuteNonQuery();
                }

                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    //affectedrow = 0;
                    insertedInvoiceID = null;
                }
                if (sqle.Number == 2627)
                    throw new Exception("Invoice No ရှိပြီးဖြစ်သည်။ \nပြန်လည်ဖြည့်သွင်းပေးပါရန်။");
                else
                    throw sqle;
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            //return affectedrow;
            return insertedInvoiceID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newInvoice"></param>
        /// <param name="newSaleDetailRecords"></param>
        /// <param name="isSaleFromVehicle"></param>
        /// <param name="placeID"></param>
        /// <param name="needStockControl"></param>
        /// <param name="newCommDiscount"></param>
        /// <param name="newTax"></param>
        /// <returns></returns>
        public static int? InsertCashInvoice(
            Invoice newInvoice, List<SaleDetail> newSaleDetailRecords,
            bool isSaleFromVehicle, int placeID, bool needStockControl,
            CommDiscount newCommDiscount, Tax newTax)
        {
            // TODO: Add concurrency control - isolation level @InsertCashInvoice
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int? insertedInvoiceID = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // Start transaction
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // Insert a new Invoice
                cmd.CommandText = "usp_CashSaleInvoiceInsert";

                cmd.Parameters.AddWithValue("@p_InvoiceNo", newInvoice.InvoiceNo);
                cmd.Parameters["@p_InvoiceNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", newInvoice.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersonID", newInvoice.SalesPersonID);
                cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;
                
                cmd.Parameters.AddWithValue("@p_SalesDate", newInvoice.SalesDate);
                cmd.Parameters["@p_SalesDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TotalAmt", newInvoice.TotalAmt);
                cmd.Parameters["@p_TotalAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CommDiscAmt", newInvoice.CommDiscAmt);
                cmd.Parameters["@p_CommDiscAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OtherAmt", newInvoice.OtherAmt);
                cmd.Parameters["@p_OtherAmt"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_NetAmt", newInvoice.NetAmt);
                //cmd.Parameters["@p_NetAmt"].Direction = ParameterDirection.Input;
                if (newInvoice.TransportGateID > 0)
                    cmd.Parameters.AddWithValue("@p_TransportGateID", newInvoice.TransportGateID);
                else
                    cmd.Parameters.AddWithValue("@p_TransportGateID", DBNull.Value);
                cmd.Parameters["@p_TransportGateID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", newInvoice.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;
                
                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;

                insertedInvoiceID = (int)insertedIDObj;
                // Clear parameters of usp_CashSaleInvoiceInsert
                cmd.Parameters.Clear();

                // Insert new CashSales                
                cmd.CommandText = "usp_CashSalesDetailInsert";
                foreach (SaleDetail newSaleDetialRecord in newSaleDetailRecords)
                {
                    cmd.Parameters.AddWithValue("@p_InvoiceID", insertedInvoiceID);
                    cmd.Parameters["@p_InvoiceID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", newSaleDetialRecord.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SalePrice", newSaleDetialRecord.SalePrice);
                    cmd.Parameters["@p_SalePrice"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", newSaleDetialRecord.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Package", newSaleDetialRecord.Package);
                    cmd.Parameters["@p_Package"].Direction = ParameterDirection.Input;
                    
                    cmd.ExecuteNonQuery();
                    // Clear parameters of each usp_SaleDetailInsert
                    cmd.Parameters.Clear();
                }

                // If stock control is required, update inventory
                if (needStockControl)
                {                    
                    DataTable dtStock = new DataTable("StockTableType");
                    dtStock.Columns.Add("ProductID", typeof(int));
                    dtStock.Columns.Add("PlaceID", typeof(int)); // Warehouse ID or Vehicle ID
                    dtStock.Columns.Add("Place", typeof(int)); // Warehouse : 0, Vehicle : 1
                    dtStock.Columns.Add("SalePersonID", typeof(int));
                    dtStock.Columns.Add("StockBy", typeof(int));
                    dtStock.Columns.Add("Qty", typeof(int));
                    dtStock.Columns.Add("Date", typeof(DateTime));
                    dtStock.Columns.Add("Remark", typeof(string));
                    // Create table-valued parameter
                    foreach (SaleDetail saleDetialRow in newSaleDetailRecords)
                    {
                        DataRow row = dtStock.NewRow();
                        row["ProductID"] = saleDetialRow.ProductID;
                        row["PlaceID"] = placeID;
                        row["Place"] = Convert.ToInt16(isSaleFromVehicle);
                        row["SalePersonID"] = newInvoice.SalesPersonID;
                        //row["StockBy"] = isSaleFromVehicle? 1 : 3; // 1 = Sale from vehicle, 3 = Sale from warehouse 
                        row["StockBy"] = isSaleFromVehicle ?
                            (int)PTIC.Common.Enum.VehicleStockBy.CustomerOrSale : (int)PTIC.Common.Enum.WarehouseStockBy.CustomerOrSale;
                        row["Qty"] = saleDetialRow.Qty;
                        row["Date"] = newInvoice.SalesDate;
                        row["Remark"] = DBNull.Value;
                        dtStock.Rows.Add(row);
                    }
                    cmd.CommandText = "usp_StockUpdateByCashSale";
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@p_StockTable";
                    param.SqlDbType = SqlDbType.Structured;
                    param.Value = dtStock;
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    // Clear parameters of usp_StockUpdateByCashSale
                    cmd.Parameters.Clear();
                } // END OF if (needStockControl)
                                                
                // Insert a new commission discount if passed
                if (newCommDiscount != null)
                {
                    cmd.CommandText = "usp_CommDiscountInsert";

                    cmd.Parameters.AddWithValue("@p_InvoiceID", insertedInvoiceID);
                    cmd.Parameters["@p_InvoiceID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SaleCommID", newCommDiscount.SaleCommID);
                    cmd.Parameters["@p_SaleCommID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_CashCommID", newCommDiscount.CashCommID);
                    cmd.Parameters["@p_CashCommID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_PackingAmt", newCommDiscount.PackingAmt);
                    cmd.Parameters["@p_PackingAmt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SaleCommAmt", newCommDiscount.SaleCommAmt);
                    cmd.Parameters["@p_SaleCommAmt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_CashCommAmt", newCommDiscount.CashCommAmt);
                    cmd.Parameters["@p_CashCommAmt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_OtherCommAmt", newCommDiscount.OtherCommAmt);
                    cmd.Parameters["@p_OtherCommAmt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RefundAmt", newCommDiscount.RefundAmt);
                    cmd.Parameters["@p_RefundAmt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_NeedAmt", newCommDiscount.NeedAmt);
                    cmd.Parameters["@p_NeedAmt"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                // Clear parameters of usp_CommDiscountInsert
                cmd.Parameters.Clear();
                // Insert a new tax if passed
                if (newTax != null)
                {
                    cmd.CommandText = "usp_TaxInsert";

                    cmd.Parameters.AddWithValue("@p_InvoiceID", insertedInvoiceID);
                    cmd.Parameters["@p_InvoiceID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_InsuranceAmt", newTax.InsuranceAmt);
                    cmd.Parameters["@p_InsuranceAmt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TaxAmt", newTax.TaxAmt);
                    cmd.Parameters["@p_TaxAmt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TransportAmt", newTax.TransportAmt);
                    cmd.Parameters["@p_TransportAmt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_GateInvNo", newTax.GateInvNo);
                    cmd.Parameters["@p_GateInvNo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_GateInvPhoto", newTax.GateInvPhoto);
                    cmd.Parameters["@p_GateInvPhoto"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                }
                // Commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    insertedInvoiceID = null;
                }
                if (sqle.Number == 2627)
                    throw new Exception("Invoice No ရှိပြီးဖြစ်သည်။ \nပြန်လည်ဖြည့်သွင်းပေးပါရန်။");
                else
                    throw sqle;
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
                DBManager.GetInstance().CloseDbConnection();
            }
            return insertedInvoiceID;
        }
        #endregion
   
        #region UPDATE
        #endregion

        #region DELETE
        #endregion

        public static DataTable SelectAllPayment()
        {
            DataTable table = null;
            string tableName = "PaymentTbl";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_PaymentSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        #region DailySalesReport
        public static DataTable SelectDailyReports()
        {


            DataTable table = null;
            string tableName = "DailySales";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                string cmdStr = "SELECT i.ID,SalesDate,e.EmpName,ADDR.TOWN,C.CusName,";
                cmdStr += " ( CASE ";
                cmdStr += " WHEN SaleType=0 THEN 'Credit'";
                cmdStr += " WHEN SaleType=1 THEN 'Consignment'";
                cmdStr += " WHEN SaleType=2 THEN 'Cash'";
                cmdStr += " END) SalesType,i.InvoiceNo,ISNULL(V.VehiclePrefixNo+'/'+ V.VehicleNo,'-') VanNo,i.TotalAmt";
                cmdStr += " FROM Invoice i JOIN Employee e";
                cmdStr += " ON I.SalesPersonID = e.ID";
                cmdStr += " JOIN Customer C ON i.CusID = c.ID";
                cmdStr += " JOIN (SELECT A.ID,ISNULL(TSP.Township,T.Town) AS TOWN FROM [Address] A JOIN Town T ON A.TownID=T.ID LEFT JOIN Township TSP ON TSP.ID = A.TownshipID) ADDR";
                cmdStr += " ON C.AddrID=ADDR.ID";
                cmdStr += " LEFT JOIN (Delivery D JOIN Vehicle V ON D.VenID =V.ID) ON I.DeliveryID=D.ID";


                command.CommandText = cmdStr;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

          public static DataTable SelectDetails()
        {


            DataTable table = null;
            string tableName = "SalesDetails";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                string cmdStr = "SELECT P.ProductName,SD.SalePrice,SD.Qty,SD.Amount,SD.InvoiceID ";
                cmdStr += " FROM SalesDetail SD JOIN Product P ON P.ID =SD.ProductID WHERE SD.QTY>0";
               


                command.CommandText = cmdStr;

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
    }
}

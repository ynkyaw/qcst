using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    public class PaymentDA
    {
        private string TableName = "Payment";
        public static BaseDAO b = new BaseDAO();

        ///<summary>
        ///<param name=""/></param>
        ///<returns>Product</returns>
        /// </summary>
        public static DataTable SelectProductFromSaleDetails()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT SalesDetail.ID As SalesDetailID,InvoiceNo,InvoiceID,ProductID,SalePrice,Qty,Package,Amount,Product.ProductName FROM SalesDetail INNER JOIN Product ON Product.ID = SalesDetail.ProductID INNER JOIN Invoice ON Invoice.ID = SalesDetail.InvoiceID WHERE Qty > 0");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns>Debtors List</returns>
        /// 
        public static DataTable SelectDebtorsListByQuery(int CustomerID)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM uv_Debtor WHERE CusID =" + CustomerID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;            
        }

        public static DataTable SelectSaleReturnByInvoiceID(int InvoiceID, int ProductID)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT SalesDetail.ID As SalesDetailID,InvoiceNo,InvoiceID,ProductID,SalePrice, "
                         +"(SalesDetail.Qty - CASE WHEN SaleReturnIn.Qty IS NOT NULL THEN SaleReturnIn.Qty ELSE 0 END) As Qty "
                         + ",Package,Amount,Product.ProductName FROM SalesDetail INNER JOIN Product ON Product.ID = SalesDetail.ProductID "
                            +"INNER JOIN Invoice ON Invoice.ID = SalesDetail.InvoiceID "
                               + "LEFT JOIN SaleReturnIn ON SaleReturnIn.SaleDetailID = SalesDetail.ID WHERE InvoiceID = " + InvoiceID + "AND ProductID =" + ProductID + "AND Amount > 0");
                //dt = b.SelectByQuery("SELECT SalesDetail.ID As SalesDetailID,InvoiceNo,InvoiceID,ProductID,SalePrice,Qty,Package,Amount,Product.ProductName FROM SalesDetail INNER JOIN Product ON Product.ID = SalesDetail.ProductID INNER JOIN Invoice ON Invoice.ID = SalesDetail.InvoiceID WHERE InvoiceID = " + InvoiceID + "AND ProductID =" + ProductID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }

        #region SELECT
        public DataTable SelectAllByQuery(int InvoiceID)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM Payment WHERE PayType = (SELECT MAX(PayType) FROM Payment WHERE InvoiceID=" + InvoiceID + ") AND InvoiceID =" + InvoiceID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectBy(DateTime? startDate, DateTime? endDate, int? customerID, int? departmentID)
        {
            DataTable table = null;
            string tableName = "SingleInvoicePaymentTable";
            StringBuilder queryText = new StringBuilder("SELECT * FROM uv_Payment WHERE 1 = 1");
            try
            {
                table = new DataTable(tableName);
                // Filter by date range
                if (startDate.HasValue && endDate.HasValue)
                {
                    queryText.Append(
                        string.Format(" AND CAST(PayDate AS DATE)" +
                                        " BETWEEN '{0}' AND '{1}'", startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"))
                                        );
                }
                // Filter by customer
                if (customerID.HasValue)
                    queryText.Append(" AND CusID = " + customerID.Value);
                // Filter by department
                if(departmentID.HasValue)
                    queryText.Append(" AND DeptID = " + departmentID.Value);

                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandType = CommandType.Text;
                command.CommandText = queryText.ToString();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                throw null;
            }
            return table;
        }

        public static bool Exists(int invoiceID, int payType)
        {
            DataTable table = null;
            try
            {
                table = new DataTable();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandText = "SELECT ID FROM Payment WHERE IsDeleted = 0 AND PayType = @p_PayType AND InvoiceID = @p_InvoiceID";

                command.Parameters.AddWithValue("@p_InvoiceID", invoiceID);
                command.Parameters["@p_InvoiceID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_PayType", payType);
                command.Parameters["@p_PayType"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);

                if (table != null && table.Rows.Count > 0)
                    return true;
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="payAmount"></param>
        /// <returns>True if pay amount of specific invoice is less than credit amount, otherwise false.</returns>
        public static bool IsLessThanCreditAmount(int invoiceID, decimal payAmount)
        {
            DataTable table = null;
            try
            {
                table = new DataTable();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandText = "SELECT 1 WHERE ( (SELECT SUM(BalanceAmt) FROM uv_Debtor WHERE CusID = (SELECT CusID FROM Invoice WHERE ID = @p_InvoiceID)) - "
                                                      + " ISNULL((SELECT SUM(PaidAmt) FROM uv_Payment WHERE CusID = (SELECT CusID FROM Invoice WHERE ID = @p_InvoiceID)), 0) ) > @p_PayAmount";

                command.Parameters.AddWithValue("@p_InvoiceID", invoiceID);
                command.Parameters["@p_InvoiceID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_PayAmount", payAmount);
                command.Parameters["@p_PayAmount"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);

                if (table != null && table.Rows.Count > 0)
                    return true;
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return false;
        }

        public static bool IsLessThanOrEqualCreditAmount(int invoiceID, decimal payAmount)
        {
            DataTable table = null;
            try
            {
                table = new DataTable();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandText = "SELECT 1 WHERE ( (SELECT SUM(BalanceAmt) FROM uv_Debtor WHERE CusID = (SELECT CusID FROM Invoice WHERE ID = @p_InvoiceID)) - "
                                                      + " ISNULL((SELECT SUM(PaidAmt) FROM uv_Payment WHERE CusID = (SELECT CusID FROM Invoice WHERE ID = @p_InvoiceID)), 0) ) >= @p_PayAmount";

                command.Parameters.AddWithValue("@p_InvoiceID", invoiceID);
                command.Parameters["@p_InvoiceID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_PayAmount", payAmount);
                command.Parameters["@p_PayAmount"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);

                if (table != null && table.Rows.Count > 0)
                    return true;
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return false;
        }

        /// <summary>
        /// Receipt Voucher List
        /// </summary>
        /// <param name="invoideID"></param>
        /// <returns></returns>
        /// 
        public static DataTable SelectAllReceipt(int? InvoiceID)
        {
            DataTable dt;
            try
            {
                // TODO: Create prepared statement to avoid sql injection
                dt = new BaseDAO().SelectByQuery("SELECT * FROM uv_Payment WHERE InvoiceID="+InvoiceID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectAllReceiptNo(string ReceiptNo)
        {
            DataTable dt;
            try
            {
                // TODO: Create prepared statement to avoid sql injection
                dt = new BaseDAO().SelectByQuery("SELECT * FROM uv_Payment WHERE ReceiptNo =" + "'"+ReceiptNo+"'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public static decimal SelectTotalPastPayment(int invoideID)
        {
            try
            {
                string queryStr = "SELECT ISNULL(SUM(PaidAmt), 0) FROM Payment WHERE InvoiceID = {0}";
                //return (decimal)new BaseDAO().SelectScalar(string.Format(queryStr, invoideID));
                return (decimal)b.SelectScalar(string.Format(queryStr, invoideID));
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }
        #endregion

        #region INSERT
        public static int? Insert(Payment vo)
        {
            /*
            int id = 0;
            if (!da.isExist(vo.ID.ToString()))
            {                
                id = da.Insert(vo);
            }
            else
            {
              // TODO: update payment
              //  id = da.Update(vo);
            }
            return id;
             */


            SqlCommand cmd = null;
            SqlTransaction transaction = null;
            SqlConnection conn = null;
            int? insertedID = null;
            try
            {
                //string cmdInsert = "INSERT INTO Payment"
                //                        + " (InvoiceID, PayType, CashReceiptType, BankID, SalesPersonID,"
                //                        + " PayDate, TotalAmt, CommDisAmt, OtherAmt, PaidAmt,ReceiptNo)"
                //                        + " OUTPUT INSERTED.ID"
                //                        + " VALUES(@InvoiceID, @PayType, @CashReceiptType, @BankID, @SalesPersonID,"
                //                        + " @PayDate, @TotalAmt, @CommDisAmt, @OtherAmt, @PaidAmt,@ReceiptNo)";

                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = transaction;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_PaymentInsert";

                cmd.Parameters.AddWithValue("@p_InvoiceID", vo.InvoiceID);
                cmd.Parameters["@p_InvoiceID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PayType", vo.PayType);
                cmd.Parameters["@p_PayType"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CashReceiptType", vo.CashReceiptType);
                cmd.Parameters["@p_CashReceiptType"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BankID", vo.BankID);
                cmd.Parameters["@p_BankID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersionID", vo.SalesPersonID);
                cmd.Parameters["@p_SalesPersionID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReceiptNo", vo.ReceiptNo);
                cmd.Parameters["@p_ReceiptNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PayDate", vo.PayDate);
                cmd.Parameters["@p_PayDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TotalAmt", vo.TotalAmt);
                cmd.Parameters["@p_TotalAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CommDisAmt", vo.CommDisAmt);
                cmd.Parameters["@p_CommDisAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OtherAmt", vo.OtherAmt);
                cmd.Parameters["@p_OtherAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PaidAmt", vo.PaidAmt);
                cmd.Parameters["@p_PaidAmt"].Direction = ParameterDirection.Input;
                                               
                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;
                insertedID = (int)insertedIDObj;

                cmd.Parameters.Clear();
                /*** Update Invoice as Paid if PayType is Final ***/
                if (vo.PayType == PTIC.Common.Enum.PayType.Final)
                {
                    cmd.CommandType = CommandType.Text;
                    string cmdUpdateStr = string.Format("UPDATE Invoice SET Paid = 1 WHERE ID = {0} ", vo.InvoiceID);
                    cmd.CommandText = cmdUpdateStr;
                    if (cmd.ExecuteNonQuery() < 0)
                    {
                        throw new Exception();
                    }
                }

                // Commit transaction
                transaction.Commit();

                if (!insertedID.HasValue)
                {
                    transaction.Rollback();
                    insertedID = null;
                }
            }
            catch (Exception e)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return insertedID;
        }
        #endregion

        #region
        /*
        public int Insert(Payment vo)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.Insert(TableName, b.GetFieldNames(vo), b.GetFieldValues(vo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
         */ 
        #endregion

        public bool isExist(string key)
        {
            return b.CheckRec("Payment", key);
        }
    }
}

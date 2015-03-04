/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/08/31 (yyyy/MM/dd)
 * Description: Multi Invoices Payment data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using PTIC.Common;
using System.Data.SqlClient;
using System.Data;
using PTIC.Common.DA;

namespace PTIC.Sale.DA
{
    /// <summary>
    /// Multi Invoices Payment data access
    /// </summary>
    public class MultiInvoicesPaymentDA
    {
        private static BaseDAO _dataAccess = new BaseDAO();

        #region SELECT
        public static DataTable SelectAll()
        {
            string queryString = "SELECT * FROM uv_MultiInvoicesPayment ";
            return _dataAccess.SelectByQuery(queryString);
        }

        public static DataTable SelectBy(DateTime? startDate, DateTime? endDate, int? customerID, int? departmentID)
        {
            DataTable table = null;
            string tableName = "MultiInvoicePaymentTable";
            StringBuilder queryText = new StringBuilder("SELECT * FROM uv_MultiInvoicesPayment WHERE 1 = 1");
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
                    queryText.Append(" AND CustomerID = " + customerID.Value);
                // Filter by department
                if (departmentID.HasValue)
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
                throw ex;
            }
            return table;
        }

        public static DataTable SelectByReceiptNo(string receiptNo)
        {
            string queryString = string.Format("SELECT m_inv.InvoiceID, inv.InvoiceNo"
                                                                + " FROM MultiInvoicesPayment AS m_pmt"
                                                                    + " INNER JOIN InvoiceInMultiInvoicesPayment AS m_inv ON m_inv.MultiInvoicesPaymentID = m_pmt.ID"
                                                                    + " INNER JOIN Invoice AS inv ON inv.ID = m_inv.InvoiceID"
                                                                + " WHERE m_pmt.ReceiptNo = '{0}' ", receiptNo);
            return _dataAccess.SelectByQuery(queryString);
        }
        #endregion

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPayment"></param>
        /// <param name="invoices"></param>
        /// <returns>Inserted id of MultiInvoicesPayment</returns>
        public static int? Insert(Payment newPayment, List<Invoice> invoices)
        {
            SqlCommand cmd = null;
            SqlTransaction transaction = null;
            SqlConnection conn = null;
            int? insertedID = null;
            try
            {
                /*** Insert a new [MultiInvoicesPayment] ***/
                string cmdInsert = "INSERT INTO [MultiInvoicesPayment]"
                                           + " ([PayType], [CashReceiptType], [BankID]"
                                           + " ,[SalesPersonID], [PayDate], [TotalAmt]"
                                           + " ,[CommDisAmt], [OtherAmt], [PaidAmt] )"
                                     + " OUTPUT inserted.ID"
                                     + " VALUES"
                                           + " (@p_PayType, @p_CashReceiptType, @p_BankID"
                                           + " ,@p_SalesPersonID, @p_PayDate, @p_TotalAmt"
                                           + " ,@p_CommDisAmt, @p_OtherAmt, @p_PaidAmt )";
                
                conn = DBManager.GetInstance().GetDbConnection();

                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                                                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdInsert;

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_PayType",
                    Value = newPayment.PayType
                });

                //cmd.Parameters.AddWithValue("@p_ArrivedDate", newPayment.ArrivedDate);
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_CashReceiptType",
                    Value = newPayment.CashReceiptType
                });

                //cmd.Parameters.AddWithValue("@p_PrevDebitAmt", newPayment.PrevDebitAmt);
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_BankID",
                    Value = (object)newPayment.BankID ?? DBNull.Value
                });

                //cmd.Parameters.AddWithValue("@p_RentAmt", newPayment.RentAmt);
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_SalesPersonID",
                    Value = newPayment.SalesPersonID
                });

                //cmd.Parameters.AddWithValue("@p_FoodAmt", newPayment.FoodAmt);
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_PayDate",
                    Value = (object)newPayment.PayDate
                });

                //cmd.Parameters.AddWithValue("@p_TransportAmt", newPayment.TransportAmt);
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_TotalAmt",
                    Value = newPayment.TotalAmt
                });

                //cmd.Parameters.AddWithValue("@p_CommunicationAmt", newPayment.CommunicationAmt);
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_CommDisAmt",
                    Value = (object)newPayment.CommDisAmt ?? DBNull.Value
                });

                //cmd.Parameters.AddWithValue("@p_OtherExpense", newPayment.OtherExpense);
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_OtherAmt",
                    Value = (object)newPayment.OtherAmt ?? DBNull.Value
                });

                //cmd.Parameters.AddWithValue("@p_RemittanceAmt", newPayment.RemittanceAmt);
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@p_PaidAmt",
                    Value = newPayment.PaidAmt
                });
                
                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;
                insertedID = (int)insertedIDObj;

                cmd.Parameters.Clear();
                // Add new InvoiceInMultiInvoicePayment
                string cmdInsertInvoices = "INSERT INTO [InvoiceInMultiInvoicesPayment]"
                                                           + " ([MultiInvoicesPaymentID], [InvoiceID] )"
                                                     + " VALUES"
                                                           + " (@p_MultiInvoicesPaymentID, @p_InvoiceID )";
                // Update Invoice as Paid
                string cmdUpdateStr = "UPDATE Invoice SET Paid = 1 WHERE ID = {0} ";

                int affectedCount = 0;                
                foreach(Invoice inv in invoices)
                {
                    cmd.CommandText = cmdInsertInvoices;
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@p_MultiInvoicesPaymentID",
                        Value = insertedID.Value
                    });

                    cmd.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = "@p_InvoiceID",
                        Value = inv.ID.Value
                    });
                    affectedCount += cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    /*** Update Invoice as Paid if PayType is Final ***/
                    if (newPayment.PayType == PTIC.Common.Enum.PayType.Final)
                    {
                        cmd.CommandText = string.Format(cmdUpdateStr, inv.ID);                        
                        if (cmd.ExecuteNonQuery() < 0)
                        {
                            throw new Exception();
                        }
                    }
                }
                
                // Commit transaction
                transaction.Commit();

                if (!insertedID.HasValue || affectedCount != invoices.Count)
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
                    return null;
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

        #region UPDATE
        #endregion

        #region DELETE
        #endregion
    }
}

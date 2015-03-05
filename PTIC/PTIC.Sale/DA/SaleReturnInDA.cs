using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using System.Data;
using PTIC.Common.DA;
using PTIC.Common;


namespace PTIC.Sale.DA
{
    public class SaleReturnInDA
    {
        public static BaseDAO b = new BaseDAO();
        #region INSERT
         public static int Insert(SaleReturnIn saleReturnIn,SaleDetail saleDetail,int? VenID, int? WarehouseID)
        {
            SqlConnection conn = DBManager.GetInstance().GetDbConnection();
            SqlTransaction transaction = null;
            SqlCommand cmd = new SqlCommand();
                
            int affectedrow = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                cmd.CommandText = "usp_SaleReturnInInsert";

                cmd.Parameters.AddWithValue("@p_SalesDetail", saleReturnIn.SaleDetailID);
                cmd.Parameters["@p_SalesDetail"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Qty", saleReturnIn.Qty);
                cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", saleReturnIn.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductID", saleReturnIn.ProuductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesDate", saleReturnIn.Date);
                cmd.Parameters["@p_SalesDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersonID", saleReturnIn.SalePersonID);
                cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                if (saleDetail != null)
                {
                    cmd.Parameters.AddWithValue("@p_InvoiceID", saleDetail.InvoiceID);
                    cmd.Parameters["@p_InvoiceID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SalesPrice", saleDetail.SalePrice);
                    cmd.Parameters["@p_SalesPrice"].Direction = ParameterDirection.Input;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@p_InvoiceID", null);
                    cmd.Parameters["@p_InvoiceID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SalesPrice", null);
                    cmd.Parameters["@p_SalesPrice"].Direction = ParameterDirection.Input;
                }

                if (VenID == null)
                {
                    cmd.Parameters.AddWithValue("@p_WarehouseID", WarehouseID);
                    cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_VenID", VenID);
                    cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.WarehouseStockBy.CustomerOrSale);
                    cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@p_VenID", VenID);
                    cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_WarehouseID", WarehouseID);
                    cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.VehicleStockBy.CustomerOrSale);
                    cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;
                }

                affectedrow += cmd.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    affectedrow = 0;
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
         public static int Update(SaleReturnIn saleReturnIn, int? VenID, int? WarehouseID, SqlConnection conn)
         {
             int affectedrow = 0;
             try
             {
                 SqlCommand cmd = new SqlCommand();
                 cmd.Connection = conn;

                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.CommandText = "usp_SaleReturnInUpdate";

                 cmd.Parameters.AddWithValue("@p_SaleReturnInID", saleReturnIn.SalesReturnInID);
                 cmd.Parameters["@p_SaleReturnInID"].Direction = ParameterDirection.Input;

                 cmd.Parameters.AddWithValue("@p_SalesDetail", saleReturnIn.SaleDetailID);
                 cmd.Parameters["@p_SalesDetail"].Direction = ParameterDirection.Input;

                 cmd.Parameters.AddWithValue("@p_Qty", saleReturnIn.Qty);
                 cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                 cmd.Parameters.AddWithValue("@p_Remark", saleReturnIn.Remark);
                 cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                 cmd.Parameters.AddWithValue("@p_ProductID", saleReturnIn.ProuductID);
                 cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                 cmd.Parameters.AddWithValue("@p_SalesDate", saleReturnIn.Date);
                 cmd.Parameters["@p_SalesDate"].Direction = ParameterDirection.Input;

                 cmd.Parameters.AddWithValue("@p_SalesPersonID", saleReturnIn.SalePersonID);
                 cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                 if (VenID == null)
                 {
                     cmd.Parameters.AddWithValue("@p_WarehouseID", WarehouseID);
                     cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                     cmd.Parameters.AddWithValue("@p_VenID", VenID);
                     cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                     cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.WarehouseStockBy.CustomerOrSale);
                     cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;
                 }
                 else
                 {
                     cmd.Parameters.AddWithValue("@p_VenID", VenID);
                     cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                     cmd.Parameters.AddWithValue("@p_WarehouseID", WarehouseID);
                     cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                     cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.VehicleStockBy.CustomerOrSale);
                     cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;
                 }

                 affectedrow += cmd.ExecuteNonQuery();
             }
             catch (SqlException sqle)
             {
                 return affectedrow = 0;
             }
             return affectedrow;
         }
         #endregion

         #region SELECT
         public static DataTable SelectSaleReturnInByDate(DateTime SaleReturnDate,int CustomerID)
         {
             DataTable dt;
             try
             {
                 string queryStr = "SELECT * FROM uv_SaleReturn WHERE CONVERT(VARCHAR(10),Date,103)  = CONVERT(VARCHAR(10),CAST ('{0}' as DATE) ,103) AND CusID = {1}";
                 dt = b.SelectByQuery(string.Format(queryStr,SaleReturnDate,CustomerID));
             }
             catch (Exception ex)
             {                 
                 throw ex;
             }
             return dt;
         }

         public static DataTable SelectQtyToReturn(int SaleDetailID,int ProductID)
         {
             DataTable dt;
             try
             {
                 string queryStr = "SELECT (SELECT SUM(SalesDetail.Qty) FROM SalesDetail WHERE ID ={0} AND ProductID = {3}) - SUM(SaleReturnIn.Qty) As Result , (SELECT SUM(SalesDetail.Qty) FROM SalesDetail WHERE ID ={2} AND ProductID={4}) As SaleDetailQty FROM SaleReturnIn INNER JOIN SalesDetail ON SalesDetail.ID = SaleReturnIn.SaleDetailID WHERE SalesDetail.ID ={1} AND ProductID ={5}";
                 dt = b.SelectByQuery(string.Format(queryStr,SaleDetailID,SaleDetailID,SaleDetailID,ProductID,ProductID,ProductID));
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             return dt;
         }


         public static DataTable SelectBalanceAmountToReturn(int InvoiceID)
         {
             DataTable dt;
             try
             {
                 string queryStr = "SELECT (BalanceAmt - PaidAmt) As TotalBalance "
                                      +"FROM (SELECT Invoice.BalanceAmt,SUM(Payment.PaidAmt) As PaidAmt FROM Invoice "
                                        +"INNER JOIN Payment ON Payment.InvoiceID = Invoice.ID "
                                            +"WHERE VoucherType =0 AND Invoice.ID ={0} "
                                                +"GROUP BY Invoice.ID,Invoice.BalanceAmt)Result";
                 dt = b.SelectByQuery(string.Format(queryStr,InvoiceID));
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             return dt;
         }
        #endregion
    }
}

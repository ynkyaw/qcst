using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Sale.Entities;

namespace PTIC.Sale.DA
{
    public class FGRequestDA
    {
        internal static DataTable GetAll(SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_FGRequestSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "FGRequestTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["FGRequestTable"];
        }

        public static int Insert(FGRequest fgRequest, List<FGRequestDetail> fgRequestDetail, SqlConnection conn)
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

                // insert a new a & p plan
                cmd.CommandText = "usp_FGRequstInsert";

                //cmd.Parameters.AddWithValue("@p_ReqVouNo", fgRequest.ReqVouNo);
                //cmd.Parameters["@p_ReqVouNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReqDate", fgRequest.ReqDate);
                cmd.Parameters["@p_ReqDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RequireDate", fgRequest.RequireDate);
                cmd.Parameters["@p_RequireDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportEmpID", fgRequest.TarnsportEmpID);
                cmd.Parameters["@p_TransportEmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportVenID", fgRequest.TransportVenID);
                cmd.Parameters["@p_TransportVenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RequesterID", fgRequest.RequesterID);
                cmd.Parameters["@p_RequesterID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", fgRequest.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();

                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                int insertedFGRequestID = (int)insertedIDObj;
                // clear parameters of usp_FGRequstInsert
                cmd.Parameters.Clear();
                // insert new order details
                cmd.CommandText = "usp_FGRequstDetailInsert";
                foreach (FGRequestDetail newfgRequestDetails in fgRequestDetail)
                {
                    cmd.Parameters.AddWithValue("@p_FGReqID", insertedFGRequestID);
                    cmd.Parameters["@p_FGReqID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", newfgRequestDetails.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", newfgRequestDetails.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newfgRequestDetails.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;
                  
                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_FGRequstDetailInsert
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

        public static int Update(FGRequest fgRequest, List<FGRequestDetail> fgRequestDetail, SqlConnection conn)
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

                // insert a new a & p plan
                cmd.CommandText = "usp_FGRequestUpdateByID";

                cmd.Parameters.AddWithValue("@p_FGReqID", fgRequest.ID);
                cmd.Parameters["@p_FGReqID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReqDate", fgRequest.ReqDate);
                cmd.Parameters["@p_ReqDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RequireDate", fgRequest.RequireDate);
                cmd.Parameters["@p_RequireDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IssueDate", fgRequest.IssueDate);
                cmd.Parameters["@p_IssueDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportEmpID", fgRequest.TarnsportEmpID);
                cmd.Parameters["@p_TransportEmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportVenID", fgRequest.TransportVenID);
                cmd.Parameters["@p_TransportVenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RequesterID", fgRequest.RequesterID);
                cmd.Parameters["@p_RequesterID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", fgRequest.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FRemark", fgRequest.Remark);
                cmd.Parameters["@p_FRemark"].Direction = ParameterDirection.Input;

                affectedRows += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandText = "usp_FGRequestDetailUpdateByID";
                foreach (FGRequestDetail newfgRequestDetails in fgRequestDetail)
                {
                    cmd.Parameters.AddWithValue("@p_FGRequestDetailID", newfgRequestDetails.ID);
                    cmd.Parameters["@p_FGRequestDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FGReqID", fgRequest.ID);
                    cmd.Parameters["@p_FGReqID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", newfgRequestDetails.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", newfgRequestDetails.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IssueQty", newfgRequestDetails.IssueQty);
                    cmd.Parameters["@p_IssueQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FactoryRemark", newfgRequestDetails.FactoryRemark);
                    cmd.Parameters["@p_FactoryRemark"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newfgRequestDetails.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;


                    cmd.Parameters.AddWithValue("@p_FromWarehouseID", 1);
                    cmd.Parameters["@p_FromWarehouseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ToWarehouseID", 2);
                    cmd.Parameters["@p_ToWarehouseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StockByFrom", (int)PTIC.Common.Enum.WarehouseStockBy.Factory);
                    cmd.Parameters["@p_StockByFrom"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StockByTo", (int)PTIC.Common.Enum.WarehouseStockBy.Warehouse);
                    cmd.Parameters["@p_StockByTo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Date", fgRequest.IssueDate);
                    cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_FGRequstDetailInsert
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
    }
}

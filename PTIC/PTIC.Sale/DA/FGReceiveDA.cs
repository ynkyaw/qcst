using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using System.Data;
using PTIC.Common.DA;

namespace PTIC.Sale.DA
{
    class FGReceiveDA
    {
        #region SELECTALL
        BaseDAO b = new BaseDAO();
        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM uv_FGReceive");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion

        #region INSERT
        public static int Insert(FGReceive fgReceive, List<FGReceiveDetail> fgReceiveDetail, int WarehouseID, int FactoryID, SqlConnection conn)
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

                // insert a new FGReceive
                cmd.CommandText = "usp_FGReceivetInsert";

                cmd.Parameters.AddWithValue("@p_FGReqID", fgReceive.FGReqID);
                cmd.Parameters["@p_FGReqID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IssueDate", fgReceive.IssueDate);
                cmd.Parameters["@p_IssueDate"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();

                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                int insertedFGReceiveID = (int)insertedIDObj;
                // clear parameters of usp_FGReceiveInsert
                cmd.Parameters.Clear();

                // insert new FGReceiveDetail
                cmd.CommandText = "usp_FGReceiveDetailInsert";
                foreach (FGReceiveDetail newfgReceiveDetails in fgReceiveDetail)
                {
                    cmd.Parameters.AddWithValue("@p_FGRecID", insertedFGReceiveID);
                    cmd.Parameters["@p_FGRecID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", newfgReceiveDetails.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductionDate", newfgReceiveDetails.ProduceDate);
                    cmd.Parameters["@p_ProductionDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IssueQty", newfgReceiveDetails.IssueQty);
                    cmd.Parameters["@p_IssueQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newfgReceiveDetails.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FromWarehouseID", WarehouseID);
                    cmd.Parameters["@p_FromWarehouseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ToWarehouseID", FactoryID);
                    cmd.Parameters["@p_ToWarehouseID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StockByFrom", (int)PTIC.Common.Enum.WarehouseStockBy.Factory);
                    cmd.Parameters["@p_StockByFrom"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_StockByTo", (int)PTIC.Common.Enum.WarehouseStockBy.Warehouse);
                    cmd.Parameters["@p_StockByTo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Date", fgReceive.IssueDate);
                    cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;
                 
                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_FGRequstDetailInsert
                    cmd.Parameters.Clear();
                }

                //// Insert WarehouseIn To SubStore
                //cmd.CommandText = "usp_WarehouseInOutInsert";
                //foreach (FGReceiveDetail newfgReceiveDetails in fgReceiveDetail)
                //{
                //    cmd.Parameters.AddWithValue("@p_WarehouseID", WarehouseID);
                //    cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                //    cmd.Parameters.AddWithValue("@p_ProductID", newfgReceiveDetails.ProductID);
                //    cmd.Parameters["@_p_ProductID"].Direction = ParameterDirection.Input;

                //    cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.WarehouseStockBy.Factory);
                //    cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;

                //    cmd.Parameters.AddWithValue("@p_Date", fgReceive.IssueDate);
                //    cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                //    cmd.Parameters.AddWithValue("@p_Qty", newfgReceiveDetails.IssueQty);
                //    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                //    cmd.Parameters.AddWithValue("@p_Remark", newfgReceiveDetails.Remark);
                //    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                //    affectedRows += cmd.ExecuteNonQuery();
                //    cmd.Parameters.Clear();
                //}

                //// Insert WarehouseOut From Factory
                //cmd.CommandText = "usp_WarehouseInOutInsert";
                //foreach (FGReceiveDetail newfgReceiveDetails in fgReceiveDetail)
                //{
                //    cmd.Parameters.AddWithValue("@p_WarehouseID", FactoryID);
                //    cmd.Parameters["@p_WarehouseID"].Direction = ParameterDirection.Input;

                //    cmd.Parameters.AddWithValue("@p_ProductID", newfgReceiveDetails.ProductID);
                //    cmd.Parameters["@_p_ProductID"].Direction = ParameterDirection.Input;

                //    cmd.Parameters.AddWithValue("@p_StockBy", (int)PTIC.Common.Enum.WarehouseStockBy.Warehouse);
                //    cmd.Parameters["@p_StockBy"].Direction = ParameterDirection.Input;

                //    cmd.Parameters.AddWithValue("@p_Date", fgReceive.IssueDate);
                //    cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                //    cmd.Parameters.AddWithValue("@p_Qty", newfgReceiveDetails.IssueQty * -1);
                //    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                //    cmd.Parameters.AddWithValue("@p_Remark", newfgReceiveDetails.Remark);
                //    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                //    affectedRows += cmd.ExecuteNonQuery();
                //    cmd.Parameters.Clear();
                //}

                //// Insert OR Update Stock
                //cmd.CommandText = "usp_StockInsertORUpdate";

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
    }
}

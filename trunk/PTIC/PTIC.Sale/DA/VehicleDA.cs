/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/23 (yyyy/MM/dd)
 * Description: Vehicle data access class
 */
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using PTIC.Common.TableType;
using PTIC.Common.DA;
using System;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class VehicleDA
    {
        /// <summary>
        /// 
        /// </summary>
        private static BaseDAO dataAccess = new BaseDAO();

        #region SELECT 
        public static DataTable SelectAll()
        {
            DataTable table = null;
            string tableName = "VehicleTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_VehicleSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable SelectVenReturn()
        {
            try
            {
                string queryStr = "SELECT * FROM uv_VenReturn";
                return dataAccess.SelectByQuery(queryStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable SelectVenReturnByDate(DateTime Date)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection conn = DBManager.GetInstance().GetDbConnection();

                string queryStr = "SELECT * FROM uv_VenReturn WHERE CAST([Date] as DATE) = @date";
                //SqlCommand query = new SqlCommand(queryStr);
                //        query.Parameters.AddWithValue("@date", Date);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                SqlParameter date =cmd.Parameters.Add("@date", SqlDbType.Date);
                date.Value = Date;
                SqlDataAdapter _Adp = new SqlDataAdapter(cmd);
                _Adp.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region INSERT
        public static int InsertVenReturn(List<StockTableType> newStocks, int vehicleID, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;

            try
            {
                // Start transaction
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                
                // Update inventory with concurrency control
                // TODO: Add concurrency control @InsertVenReturn
                DataTable dtStock = StockTableType.AsClonedDataTable();
                // Create table-valued parameter
                foreach (StockTableType stock in newStocks)
                {
                    DataRow row = dtStock.NewRow();
                    row["ProductID"] = stock.ProductID;
                    row["PlaceID"] = stock.PlaceID; // warehouse id
                    row["Place"] = 0; // warehouse
                    row["SalePersonID"] = stock.SalePersonID;
                    row["StockBy"] = (int)PTIC.Common.Enum.WarehouseStockBy.Vehicle;
                    row["Qty"] = stock.Qty;
                    row["Date"] = stock.Date;
                    row["Remark"] = stock.Remark;
                    dtStock.Rows.Add(row);                    
                }
                cmd.CommandText = "usp_StockUpdateByVenReturn";

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@p_WarehouseStockTable";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dtStock;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@p_VehicleID", vehicleID);

                affectedRows = cmd.ExecuteNonQuery();

                // Commit transaction
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
        
        #endregion
    }
}

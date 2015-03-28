/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/16 (yyyy/MM/dd)
 * Description:
 */
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System;
using PTIC.Common;
namespace PTIC.Marketing.DA
{
    public class AP_ReturnDA
    {
        #region SELECT
        public static DataTable SelectAP_StockInVehicleByAPID(int AP_MaterailID, int VenID)
        {
            DataSet dataSet=null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                dataSet = new DataSet();
                conn = DBManager.GetInstance().GetDbConnection();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT AP_MaterialID,VehicleID,Qty,APMaterialName FROM AP_StockInVehicle "
                                                   +"INNER JOIN AP_Material ON AP_Material.ID = AP_StockInVehicle.AP_MaterialID "
                                                    +"WHERE AP_MaterialID =  @p_AP_MaterialID AND VehicleID = @p_VenID";
                cmd.Parameters.AddWithValue("@p_AP_MaterialID", AP_MaterailID);
                cmd.Parameters.AddWithValue("@p_VenID", VenID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet, "StockInVen");
            }
            catch (Exception)
            {                
                throw;
            }
            return dataSet.Tables["StockInVen"];
        }


        public static DataTable SelectAPStockInDepartmentBYAPID(int AP_MaterailID,int DeptID)
        {
            DataSet dataSet=null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                dataSet = new DataSet();
                conn = DBManager.GetInstance().GetDbConnection();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT AP_MaterialID,DeptID,Qty,AP_Material.APMaterialName FROM AP_StockInDepartment "
                                                    +"INNER JOIN AP_Material ON AP_Material.ID = AP_StockInDepartment.AP_MaterialID WHERE AP_MaterialID =@p_AP_MaterailID AND DeptID = @p_DeptID ";
                cmd.Parameters.AddWithValue("@p_AP_MaterailID", AP_MaterailID);
                cmd.Parameters.AddWithValue("@p_DeptID", DeptID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet, "StockInDept");
            }
            catch (Exception)
            {                
                throw;
            }
            return dataSet.Tables["StockInDept"];
        }
        #endregion

        #region INSERT
        public static int? Insert(AP_Return ap_Return, List<AP_ReturnDetail> newAP_ReturnDetails, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int? insertedAP_ReturnID = ap_Return.ID;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = transaction;

                if (!ap_Return.ID.HasValue)
                {
                    /** Insert master **/
                    string queryAP_ReturnInsert =
                        "INSERT INTO AP_Return" +
                            " (ReturnDate, ReturnNo, FromDeptID, FromVenID," +
                            " FromEmpID, ToDeptID, ToVenID, ToEmpID)" +
                        " OUTPUT inserted.ID" +
                        " VALUES" +
                            " (@p_ReturnDate, @p_ReturnNo, @p_FromDeptID, @p_FromVenID," +
                            " @p_FromEmpID, @p_ToDeptID, @p_ToVenID, @p_ToEmpID)";
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = queryAP_ReturnInsert;

                    cmd.Parameters.AddWithValue("@p_ReturnDate", ap_Return.ReturnDate);
                    cmd.Parameters.AddWithValue("@p_ReturnNo", ap_Return.ReturnNo);
                    cmd.Parameters.AddWithValue("@p_FromDeptID", ap_Return.FromDeptID.HasValue ? ap_Return.FromDeptID : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_FromVenID", ap_Return.FromVenID.HasValue ? ap_Return.FromVenID : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_FromEmpID", ap_Return.FromEmpID);
                    cmd.Parameters.AddWithValue("@p_ToDeptID", ap_Return.ToDeptID.HasValue ? ap_Return.ToDeptID : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_ToVenID", ap_Return.ToVenID.HasValue ? ap_Return.ToVenID : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_ToEmpID", ap_Return.ToEmpID);

                    object insertedIDObj = cmd.ExecuteScalar();
                    if (insertedIDObj.GetType() == typeof(DBNull))
                        return null;
                    insertedAP_ReturnID = (int)insertedIDObj;
                    // Clear parameter of usage insert query
                    cmd.Parameters.Clear();
                }
                                
                /** Insert detail **/
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dtReturnDetail = AP_ReturnDetail.AsClonedDataTable();
                // Create table-value parameter
                foreach (AP_ReturnDetail detail in newAP_ReturnDetails)
                {
                    DataRow newRow = dtReturnDetail.NewRow();
                    newRow["AP_ReturnID"] = insertedAP_ReturnID;
                    newRow["AP_MaterialID"] = detail.AP_MaterialID;
                    newRow["ReturnQty"] = detail.ReturnQty;
                    newRow["ReturnPurpose"] = detail.ReturnPurpose;
                    newRow["Remark"] = detail.Remark;
                    dtReturnDetail.Rows.Add(newRow);
                }
                cmd.CommandText = "usp_AP_ReturnDetailInsert";
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@p_AP_ReturnDetailTableType";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dtReturnDetail;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@p_FromDeptID", ap_Return.FromDeptID);
                cmd.Parameters.AddWithValue("@p_FromVenID", ap_Return.FromVenID);
                cmd.Parameters.AddWithValue("@p_ToDeptID", ap_Return.ToDeptID);
                cmd.Parameters.AddWithValue("@p_ToVenID", ap_Return.ToVenID);

                cmd.ExecuteNonQuery();
                // Commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
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
            return insertedAP_ReturnID;
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion

    }
}

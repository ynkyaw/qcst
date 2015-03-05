/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/13 (yyyy/MM/dd)
 * Description: 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using System.Data;
using PTIC.Common.DA;

namespace PTIC.Marketing.DA
{
    public class POSM_UsageDA
    {
        #region SELECT
        public static DataTable SelectUsageList(DateTime date, int? departmentID)
        {
            string queryString = "SELECT * FROM uv_POSM_Usage WHERE ";
            if (date != DateTime.MinValue && departmentID.HasValue) // Both date and depatment are passed
            {
                queryString += string.Format(" CAST(Date AS Date) = '{0}' AND DeptID = {1}",
                    date.ToString("yyyy-MM-dd"), departmentID.Value);
            }
            else if (date != DateTime.MinValue) // Only date is passed
                queryString += string.Format(" CAST(Date AS Date) = '{0}' ", date.ToString("yyyy-MM-dd"));
            else // Only depatment is passed
                queryString += string.Format(" DeptID = '{0}' ", departmentID.Value);

            return new BaseDAO().SelectByQuery(queryString);
        }
        #endregion

        #region INSERT
        public static int? Insert(POSM_Usage usage, List<POSM_UsageDetail> usageDetails, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int? insertedUsageID = null;
            try
            {
                // Start transaction
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                /** Insert master **/
                string queryUsageInsert =
                    "INSERT INTO POSM_Usage" +
                        " (DeptID, InchargeID, Date)" +
                    " OUTPUT inserted.ID" +
                    " VALUES" +
                        " (@p_DeptID, @p_InchargeID,@p_Date)";
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = queryUsageInsert;
                cmd.Parameters.AddWithValue("@p_DeptID", usage.DeptID);
                cmd.Parameters.AddWithValue("@p_InchargeID", usage.InchargeID);
                cmd.Parameters.AddWithValue("@p_Date", usage.Date);

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return null;
                insertedUsageID = (int)insertedIDObj;
                // Clear parameter of usage insert query
                cmd.Parameters.Clear();                
                /** Insert detail **/
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dtUsageDetail = POSM_UsageDetail.AsClonedDataTable();
                // Create table-value parameter
                foreach (POSM_UsageDetail detail in usageDetails)
                {
                    DataRow newRow = dtUsageDetail.NewRow();
                    newRow["A_P_MaterialID"] = detail.A_P_MaterialID;
                    newRow["BrandID"] = detail.BrandID;
                    newRow["POSM_UsageID"] = insertedUsageID;
                    newRow["Qty"] = detail.Qty;
                    newRow["UsagePurpose"] = detail.UsagePurpose;
                    newRow["Remark"] = detail.Remark;
                    dtUsageDetail.Rows.Add(newRow);
                }
                cmd.CommandText = "usp_POSM_UsageDetailInsert";
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@p_POSM_UsageDetailTable";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dtUsageDetail;
                cmd.Parameters.Add(param);

                // Pass param DeptID from which quantity of A P Material is to be substracted
                cmd.Parameters.AddWithValue("@p_DeptID", usage.DeptID);

                cmd.ExecuteNonQuery();

                // Commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    insertedUsageID = null;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return insertedUsageID;
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
            #endregion
    }
}

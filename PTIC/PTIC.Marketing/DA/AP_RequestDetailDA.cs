using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Common.DA;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;

namespace PTIC.Marketing.DA
{
    class AP_RequestDetailDA
    {
        public static BaseDAO b = new BaseDAO();
       
        #region SELECT

        public static DataTable SelectAll()
        {
            DataTable dtAP_RequestDetail = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                dtAP_RequestDetail = b.SelectByQuery("SELECT * FROM uv_AP_RequestIssueDetail");    
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtAP_RequestDetail;
        }
      
        #endregion

        #region INSERT
        public static int Insert(AP_Request _AP_Request, List<AP_RequestDetail> _AP_RequestDetail, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            int insertedAP_RequestID = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new AP_Request
                cmd.CommandText = "usp_AP_RequestInsert";

                cmd.Parameters.AddWithValue("@p_RequestDate", _AP_Request.RequestDate);
                cmd.Parameters["@p_RequestDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@P_RequestDeptID", _AP_Request.RequestDeptID);
                cmd.Parameters["@P_RequestDeptID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RequestVenID", _AP_Request.RequestVenID);
                cmd.Parameters["@p_RequestVenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RequesterID", _AP_Request.RequesterID);
                cmd.Parameters["@p_RequesterID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IssueDeptID", _AP_Request.IssueDeptID);
                cmd.Parameters["@p_IssueDeptID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IssueEmployeeID", _AP_Request.IssueEmployeeID);
                cmd.Parameters["@p_IssueEmployeeID"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();

                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedAP_RequestID = (int)insertedIDObj;
                // clear parameters of AP_Request
                cmd.Parameters.Clear();

                // insert new AP_RequestDetail
                cmd.CommandText = "usp_AP_RequestDetailInsert";
                foreach (AP_RequestDetail newAP_RequestDetail in _AP_RequestDetail)
                {
                    cmd.Parameters.AddWithValue("@p_AP_RequestID", insertedAP_RequestID);
                    cmd.Parameters["@p_AP_RequestID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_AP_MaterialID", newAP_RequestDetail.AP_MaterialID);
                    cmd.Parameters["@p_AP_MaterialID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RequestQty", newAP_RequestDetail.RequestQty);
                    cmd.Parameters["@p_RequestQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RequestPurpose", newAP_RequestDetail.RequestPurpose);
                    cmd.Parameters["@p_RequestPurpose"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newAP_RequestDetail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each AP_RequestDetail
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
            return insertedAP_RequestID;
        }

        #endregion

        #region UPDATE
        public static int Update(List<AP_RequestDetail> _AP_RequestDetail, SqlConnection conn)
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
                
                // update new AP_RequestDetail
                cmd.CommandText = "usp_AP_RequestDetailUpdateByID";
                foreach (AP_RequestDetail newAP_RequestDetail in _AP_RequestDetail)
                {
                    cmd.Parameters.AddWithValue("@p_AP_RequestDetailID", newAP_RequestDetail.ID);
                    cmd.Parameters["@p_AP_RequestDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_AP_MaterialID", newAP_RequestDetail.AP_MaterialID);
                    cmd.Parameters["@p_AP_MaterialID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RequestQty", newAP_RequestDetail.RequestQty);
                    cmd.Parameters["@p_RequestQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RequestPurpose", newAP_RequestDetail.RequestPurpose);
                    cmd.Parameters["@p_RequestPurpose"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newAP_RequestDetail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each AP_RequestDetail
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
    }
}

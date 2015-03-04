using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using System.Data;

namespace PTIC.Marketing.DA
{
    public class IssueDetailDA
    {

        #region AP_IssueDetail INSERT

        public static int Insert(List<AP_IssueDetail> _AP_IssueDetail, SqlConnection conn)
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
               
                // insert new AP_IssueDetail
                cmd.CommandText = "usp_AP_IssueDetailInsert";
                foreach (AP_IssueDetail newAP_IssueDetail in _AP_IssueDetail)
                {
                    cmd.Parameters.AddWithValue("@p_AP_RequestDetailID", newAP_IssueDetail.AP_RequestDetailID);
                    cmd.Parameters["@p_AP_RequestDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IssueQty", newAP_IssueDetail.IssueQty);
                    cmd.Parameters["@p_IssueQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IssueDate", newAP_IssueDetail.IssueDate);
                    cmd.Parameters["@p_IssueDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FromDeptID", newAP_IssueDetail.FromDeptID);
                    cmd.Parameters["@p_FromDeptID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FromVenID", newAP_IssueDetail.FromVenID);
                    cmd.Parameters["@p_FromVenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ToDeptID", newAP_IssueDetail.ToDeptID);
                    cmd.Parameters["@p_ToDeptID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ToVenID", newAP_IssueDetail.ToVenID);
                    cmd.Parameters["@p_ToVenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FromEmpID", newAP_IssueDetail.FromEmpID);
                    cmd.Parameters["@p_FromEmpID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ToEmpID", newAP_IssueDetail.ToEmpID);
                    cmd.Parameters["@p_ToEmpID"].Direction = ParameterDirection.Input;                    

                    cmd.Parameters.AddWithValue("@p_Remark", newAP_IssueDetail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each AP_IssueDetail
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

        public static int Update(List<AP_IssueDetail> _AP_IssueDetail, SqlConnection conn)
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

                // update new AP_IssueDetail
                cmd.CommandText = "usp_AP_IssueDetailUpdate";
                foreach (AP_IssueDetail newAP_IssueDetail in _AP_IssueDetail)
                {
                    cmd.Parameters.AddWithValue("@p_AP_IssueDetailID", newAP_IssueDetail.ID);
                    cmd.Parameters["@p_AP_IssueDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_AP_RequestDetailID", newAP_IssueDetail.AP_RequestDetailID);
                    cmd.Parameters["@p_AP_RequestDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IssueQty", newAP_IssueDetail.IssueQty);
                    cmd.Parameters["@p_IssueQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IssueDate", newAP_IssueDetail.IssueDate);
                    cmd.Parameters["@p_IssueDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FromDeptID", newAP_IssueDetail.FromDeptID);
                    cmd.Parameters["@p_FromDeptID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FromVenID", newAP_IssueDetail.FromVenID);
                    cmd.Parameters["@p_FromVenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ToDeptID", newAP_IssueDetail.ToDeptID);
                    cmd.Parameters["@p_ToDeptID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ToVenID", newAP_IssueDetail.ToVenID);
                    cmd.Parameters["@p_ToVenID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_FromEmpID", newAP_IssueDetail.FromEmpID);
                    cmd.Parameters["@p_FromEmpID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ToEmpID", newAP_IssueDetail.ToEmpID);
                    cmd.Parameters["@p_ToEmpID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newAP_IssueDetail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each AP_IssueDetail
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.Entities;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class ComplaintRegisterDA
    {
        #region SELECT
        public static DataTable SelectComplaintCommentByComplaintRegisterID(int ComplaintRegisterID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                string query = String.Format("SELECT * FROM ComplaintComment "
                                                + "WHERE ComplaintRegisterID = @ComplaintRegisterID");
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComplaintRegisterID", ComplaintRegisterID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        public static DataTable SelectComplaintExplanationandActionByComplaintRegisterID(int ComplaintRegisterID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                string query = String.Format("SELECT * FROM ComplaintExplanation "
                                                +"WHERE ComplaintRegisterID = @ComplaintRegisterID");
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComplaintRegisterID", ComplaintRegisterID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectComplaintRegisteByReceiveDate(int ReceiveMonth, int ReceiveYear)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                string query = String.Format("SELECT ComplaintReceive.ID As ComplaintReceiveID,CAST(ReceivedDate AS DATE) As ReceivedDate, "
                                                +"CASE WHEN OutletCustomerID IS NULL THEN OtherCustomer "
                                                    +"ELSE (SELECT CusName FROM Customer WHERE Customer.ID = OutletCustomerID)END As Customer, "
                                                      +"CASE WHEN ComplaintRegister.ComplaintReceiveID IS NOT NULL THEN 'Valid' "
	                                                      +"ELSE 'InValid' END As Action, "
                                                            + "ReceivedVia,ReceivedViaBy, "
                                                                +"RefNo,ReceiveName =(SELECT EmpName FROM Employee WHERE Employee.ID = ReceivedBy), "
                                                                    +"UsingHour,IsChecked,ActionByReseller,ResellerRemark,Remark,ReceiverID,UsedPeriod,UsageNature, "
                                                                      +"TownOfCus = (SELECT Town FROM uv_Customers WHERE CustomerID = OutletCustomerID),ClosedDate, "
                                                                        + "Who = (SELECT DeptName FROM Department WHERE ID = DepartmentIDClosed),ComplaintRegister.ID As ComplaintRegisterID, "
                                                                        +"ReceivedBy =(SELECT DeptName FROM Employee "
				                                                          +"INNER JOIN Department ON Department.ID = Employee.DeptID "
                                                                            + "WHERE Employee.ID = ReceiverID) "
                                                                              +"FROM ComplaintReceive "
                                                                                +"FULL OUTER JOIN ComplaintRegister ON ComplaintRegister.ComplaintReceiveID = ComplaintReceive.ID "
                                                                                  + "WHERE MONTH(ReceivedDate)= @ReceiveMonth AND YEAR(ReceivedDate) = @ReceiveYear");
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ReceiveMonth", ReceiveMonth);
                cmd.Parameters.AddWithValue("@ReceiveYear", ReceiveYear);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion

        #region INSERT
        public static int InsertComplaintRegister(
            ComplaintRegister newComplaintRegister, 
            List<ComplaintExplanation> newComplaintExplanation, 
            List<ComplaintComment> newComplaintComment)
        {
            SqlConnection conn = DBManager.GetInstance().GetDbConnection();
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            int insertedComplaintRegisterID = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                //  Insert usp_ComplaintRegisterInsert
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ComplaintRegisterInsert";

                cmd.Parameters.AddWithValue("@p_MsgNo", newComplaintRegister.MsgNo);
                cmd.Parameters["@p_MsgNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ComplaintReceiveID", newComplaintRegister.ComplaintReceiveID);
                cmd.Parameters["@p_ComplaintReceiveID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ToEmployeeID", null); // Change to null coz use text insted of EmployeeID 
                cmd.Parameters["@p_ToEmployeeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FromEmployeeID", null); // Change to null
                cmd.Parameters["@p_FromEmployeeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ToEmployee", newComplaintRegister.ToEmployee);
                cmd.Parameters["@p_ToEmployee"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_FromEmployee", newComplaintRegister.FromEmployee);
                cmd.Parameters["@p_FromEmployee"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DepartmentClosed", newComplaintRegister.DepartmentIDClosed);
                cmd.Parameters["@p_DepartmentClosed"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CloseDate", newComplaintRegister.ClosedDate);
                cmd.Parameters["@p_CloseDate"].Direction = ParameterDirection.Input;

                //return cmd.ExecuteNonQuery();
                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return -1;

                insertedComplaintRegisterID = (int)insertedIDObj;
                cmd.Parameters.Clear();

                if (newComplaintExplanation !=null)
                {
                    // insert new usp_ComplaintExplanationInsert
                    cmd.CommandText = "usp_ComplaintExplanationInsert";
                    foreach (ComplaintExplanation _newComplaintExplanation in newComplaintExplanation)
                    {
                        cmd.Parameters.AddWithValue("@p_ComplaintRegisterID", insertedComplaintRegisterID);
                        cmd.Parameters["@p_ComplaintRegisterID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Explanation", _newComplaintExplanation.Explanation);
                        cmd.Parameters["@p_Explanation"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Action", _newComplaintExplanation.Action);
                        cmd.Parameters["@p_Action"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_ExplainedByEmployeeID", null); // Change to null
                        cmd.Parameters["@p_ExplainedByEmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_ExplainedByEmployee", _newComplaintExplanation.ExplainedByEmployee); // Change to null
                        cmd.Parameters["@p_ExplainedByEmployee"].Direction = ParameterDirection.Input;

                        affectedRows += cmd.ExecuteNonQuery();
                        // clear parameters of each usp_ComplaintExplanationInsert
                        cmd.Parameters.Clear();
                    }
                }

                if (newComplaintComment != null)
                {
                    // insert new usp_ComplaintCommentInsert
                    cmd.CommandText = "usp_ComplaintCommentInsert";
                    foreach (ComplaintComment _newnewComplaintComment in newComplaintComment)
                    {
                        cmd.Parameters.AddWithValue("@p_ComplaintRegisterID", insertedComplaintRegisterID);
                        cmd.Parameters["@p_ComplaintRegisterID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Comment", _newnewComplaintComment.Comment);
                        cmd.Parameters["@p_Comment"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_CommentByEmployeeID", null); // Change to null
                        cmd.Parameters["@p_CommentByEmployeeID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_CommentByEmployee", _newnewComplaintComment.CommentByEmployee);
                        cmd.Parameters["@p_CommentByEmployee"].Direction = ParameterDirection.Input;

                        affectedRows += cmd.ExecuteNonQuery();
                        // clear parameters of each usp_ComplaintCommentInsert
                        cmd.Parameters.Clear();
                    }
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

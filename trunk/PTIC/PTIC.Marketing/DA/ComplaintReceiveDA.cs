using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using System.Data;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class ComplaintReceiveDA
    {
        #region SELECT
        public static DataTable SelectProductInComplaintReceiveByComplaintReceiveID(int ComplaintReceiveID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                string query = String.Format("SELECT ID As ProductInComplaintReceiveID,ComplaintReceiveID, "
                                                + "ComplaintCase =(SELECT CaseDespt FROM ComplaintCase WHERE ID = ComplaintCaseID) "
	                                            +",ProductName=(SELECT ProductName FROM Product WHERE Product.ID = ProductInComplaintReceive.ProductID) "
	                                                +",Qty,ProductionDate "
                                                        +"FROM ProductInComplaintReceive "
                                                           + "WHERE ComplaintReceiveID= @ComplaintReceiveID");
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComplaintReceiveID", ComplaintReceiveID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        public static DataTable SelectComplaintReceiveByComplaintReceiveID(int ComplaintReceiveID)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                string query = String.Format("SELECT ID As ComplaintReceiveID,CAST(ReceivedDate AS DATE) As ReceivedDate,MsgNo, "
	                                           +"CASE WHEN OutletCustomerID IS NULL THEN OtherCustomer "
		                                            +"ELSE (SELECT CusName FROM Customer WHERE Customer.ID = OutletCustomerID)END As Customer, "
	                                                    +"RefNo,ReceiveName =(SELECT EmpName FROM Employee WHERE Employee.ID = ReceivedBy), "
                                                            + "UsingHour,IsChecked,ActionByReseller,ResellerRemark,Remark,ReceiverID,UsedPeriod,UsageNature, "
                                                                +"TownOfCus = (SELECT Town FROM uv_Customers WHERE CustomerID = OutletCustomerID) "    
                                                                     +"FROM ComplaintReceive "
                                                                         + "WHERE ID= @ComplaintReceiveID");
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ComplaintReceiveID", ComplaintReceiveID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public static DataTable SelectComplaintReceiveByReceiveDate(int ReceiveMonth,int ReceiveYear)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                string query = String.Format("SELECT ComplaintReceive.ID As ComplaintReceiveID,CAST(ReceivedDate AS DATE) As ReceivedDate, "
                                                + "CASE WHEN OutletCustomerID IS NULL THEN OtherCustomer "
                                                    + "ELSE (SELECT CusName FROM Customer WHERE Customer.ID = OutletCustomerID)END As Customer, "
                                                        + "RefNo,ReceiveName =(SELECT EmpName FROM Employee WHERE Employee.ID = ReceivedBy),ComplaintRegister.ComplaintReceiveID "
                                                            + "FROM ComplaintReceive "
                                                                +"FULL OUTER JOIN ComplaintRegister ON ComplaintRegister.ComplaintReceiveID = ComplaintReceive.ID "
                                                                  + "WHERE MONTH(ReceivedDate)= @ReceiveMonth AND YEAR(ReceivedDate) = @ReceiveYear AND ComplaintRegister.ComplaintReceiveID IS NULL");
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
        public static int InsertComplaintReceive(ComplaintReceive newComplaintReceive, List<ProductInComplaintReceive> newProductInComplaintReceives)
        {
            SqlConnection conn = DBManager.GetInstance().GetDbConnection();
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            int insertedComplaintReceivedID = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                //  Insert usp_ComplaintReceiveInsert
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ComplaintReceiveInsert";

                cmd.Parameters.AddWithValue("@p_ReceivedDate", newComplaintReceive.ReceivedDate);
                cmd.Parameters["@p_ReceivedDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MsgNo", newComplaintReceive.MsgNo);
                cmd.Parameters["@p_MsgNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReceivedVai", newComplaintReceive.ReceivedVia);
                cmd.Parameters["@p_ReceivedVai"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReceivedVaiBy", newComplaintReceive.ReceivedViaBy);
                cmd.Parameters["@p_ReceivedVaiBy"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Sender", newComplaintReceive.Sender);
                cmd.Parameters["@p_Sender"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReceiverID", newComplaintReceive.ReceiverID);
                cmd.Parameters["@p_ReceiverID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ServiceNo", newComplaintReceive.ServiceNo);
                cmd.Parameters["@p_ServiceNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsageNature", newComplaintReceive.UsageNature);
                cmd.Parameters["@p_UsageNature"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsedPeriod", newComplaintReceive.UsedPeriod);
                cmd.Parameters["@p_UsedPeriod"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OutletCustomerID", newComplaintReceive.OutletCustomerID);
                cmd.Parameters["@p_OutletCustomerID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OtherCustomer", newComplaintReceive.OtherCustomer);
                cmd.Parameters["@p_OtherCustomer"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_UsingHour", newComplaintReceive.UsingHour);
                cmd.Parameters["@p_UsingHour"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsChecked", newComplaintReceive.IsChecked);
                cmd.Parameters["@p_IsChecked"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ActionByReseller", newComplaintReceive.ActionByReseller);
                cmd.Parameters["@p_ActionByReseller"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ResellerRemark", newComplaintReceive.ResellerRemark);
                cmd.Parameters["@p_ResellerRemark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", newComplaintReceive.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReceivedBy", newComplaintReceive.ReceivedBy);
                cmd.Parameters["@p_ReceivedBy"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RepairedBy", newComplaintReceive.RepairedBy);
                cmd.Parameters["@p_RepairedBy"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CheckedBy", newComplaintReceive.CheckedBy);
                cmd.Parameters["@p_CheckedBy"].Direction = ParameterDirection.Input;

                //return cmd.ExecuteNonQuery();
                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return -1;

                insertedComplaintReceivedID = (int)insertedIDObj;
                affectedRows += insertedComplaintReceivedID;
                cmd.Parameters.Clear();

                if (newProductInComplaintReceives != null)
                {
                    // insert new usp_ProductInComplaintReceiveInsert
                    cmd.CommandText = "usp_ProductInComplaintReceiveInsert";
                    foreach (ProductInComplaintReceive newProductInComplaintReceive in newProductInComplaintReceives)
                    {
                        cmd.Parameters.AddWithValue("@p_ComplaintReceivedID", insertedComplaintReceivedID);
                        cmd.Parameters["@p_ComplaintReceivedID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_ComplaintCaseID", newProductInComplaintReceive.ComplaintCaseID);
                        cmd.Parameters["@p_ComplaintCaseID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_ProductID", newProductInComplaintReceive.ProductID);
                        cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_Qty", newProductInComplaintReceive.Qty);
                        cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                        cmd.Parameters.AddWithValue("@p_ProductionDate", newProductInComplaintReceive.ProductionDate);
                        cmd.Parameters["@p_ProductionDate"].Direction = ParameterDirection.Input;

                        affectedRows += cmd.ExecuteNonQuery();
                        // clear parameters of each usp_ProductInComplaintReceiveInsert
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

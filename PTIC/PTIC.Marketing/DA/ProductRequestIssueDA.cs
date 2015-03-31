using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;
using PTIC.VC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class ProductRequestIssueDA
    {
        static BaseDAO b = new BaseDAO();

        public static DataTable SelectByProductReqIssueID(int ProductRequestIssueID)
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM uv_ProductRequestIssue WHERE ProductRequestIssueID ={0}";
                dt = b.SelectByQuery(String.Format(query, ProductRequestIssueID));
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return dt;
        }

        public static int Insert(ProductRequestIssue _ProductRequestIssue, List<ProductRequestIssueDetail> _ProductRequestIssueDetail)
        {
            SqlConnection conn = DBManager.GetInstance().GetDbConnection();
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
           
            int affectedRows = 0;
            int insertedProductRequestIssueID = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new ProductRequestIssue
                cmd.CommandText = "usp_ProductRequestIssueInsert";

                cmd.Parameters.AddWithValue("@p_RequestDate", _ProductRequestIssue.RequestDate);
                cmd.Parameters["@p_RequestDate"].Direction = ParameterDirection.Input;

                if(_ProductRequestIssue.IssueDate.Date==new DateTime(1,1,1).Date)
                    cmd.Parameters.AddWithValue("@p_IssueDate", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@p_IssueDate", _ProductRequestIssue.IssueDate);
                cmd.Parameters["@p_IssueDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RequesterID", _ProductRequestIssue.RequesterID);
                cmd.Parameters["@p_RequesterID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IssuerID", _ProductRequestIssue.IssuerID);
                cmd.Parameters["@p_IssuerID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RequestDeptID", _ProductRequestIssue.RequestDeptID);
                cmd.Parameters["@p_RequestDeptID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RequestVenID", _ProductRequestIssue.RequestVenID);
                cmd.Parameters["@p_RequestVenID"].Direction = ParameterDirection.Input;              

                cmd.Parameters.AddWithValue("@p_IssueDeptID", _ProductRequestIssue.IssueDeptID);
                cmd.Parameters["@p_IssueDeptID"].Direction = ParameterDirection.Input;              

                object insertedIDObj = cmd.ExecuteScalar();

                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedProductRequestIssueID = (int)insertedIDObj;
                // clear parameters of ProductRequestIssue
                cmd.Parameters.Clear();

                // insert new ProductRequestIssueDetail
                cmd.CommandText = "usp_ProductRequestIssueDetailInsert";
                foreach (ProductRequestIssueDetail newProductRequestIssueDetail in _ProductRequestIssueDetail)
                {
                    cmd.Parameters.AddWithValue("@p_ProductRequestIssueID", insertedProductRequestIssueID);
                    cmd.Parameters["@p_ProductRequestIssueID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ProductID", newProductRequestIssueDetail.ProductID);
                    cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_RequestQty", newProductRequestIssueDetail.RequestQty);
                    cmd.Parameters["@p_RequestQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IssueQty", newProductRequestIssueDetail.IssueQty);
                    cmd.Parameters["@p_IssueQty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Weight", newProductRequestIssueDetail.Weight);
                    cmd.Parameters["@p_Weight"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Purpose", newProductRequestIssueDetail.Purpose);
                    cmd.Parameters["@p_Purpose"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newProductRequestIssueDetail.Remark);
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
            return insertedProductRequestIssueID;
        }


        public static int Update(ProductRequestIssue _ProductRequestIssue, List<ProductRequestIssueDetail> _ProductRequestIssueDetail)
        {
            SqlConnection conn = DBManager.GetInstance().GetDbConnection();
            SqlTransaction transaction = null;
            SqlCommand cmd = null;

            int affectedRows = 0;
          //  int insertedProductRequestIssueID = 0;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new ProductRequestIssue
                cmd.CommandText = "usp_ProductRequestIssueUpdate";

                cmd.Parameters.AddWithValue("@p_ProductRequestIssueID", _ProductRequestIssue.ID);
                cmd.Parameters["@p_ProductRequestIssueID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IssueDate", _ProductRequestIssue.IssueDate);
                cmd.Parameters["@p_IssueDate"].Direction = ParameterDirection.Input;
                                
                cmd.Parameters.AddWithValue("@p_IssuerID", _ProductRequestIssue.IssuerID);
                cmd.Parameters["@p_IssuerID"].Direction = ParameterDirection.Input;
                                
                cmd.Parameters.AddWithValue("@p_IssueDeptID", _ProductRequestIssue.IssueDeptID);
                cmd.Parameters["@p_IssueDeptID"].Direction = ParameterDirection.Input;

                affectedRows += cmd.ExecuteNonQuery();
                // clear parameters of ProductRequestIssue
                cmd.Parameters.Clear();

                // insert new ProductRequestIssueDetail
                cmd.CommandText = "usp_ProductRequestIssueDetailUpdate";
                foreach (ProductRequestIssueDetail newProductRequestIssueDetail in _ProductRequestIssueDetail)
                {
                    cmd.Parameters.AddWithValue("@p_ProductRequestIssueDetailID", newProductRequestIssueDetail.ID);
                    cmd.Parameters["@p_ProductRequestIssueDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IssueQty", newProductRequestIssueDetail.IssueQty);
                    cmd.Parameters["@p_IssueQty"].Direction = ParameterDirection.Input;

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

    }
}

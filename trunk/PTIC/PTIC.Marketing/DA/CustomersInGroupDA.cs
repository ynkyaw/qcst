using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Common.DA;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class CustomersInGroupDA
    {
        static BaseDAO b = new BaseDAO();
        #region SELECT
        /// <summary>
        /// Get all CustomersInGroup
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM uv_CustomerInGroup WHERE IsDeleted = 0";
                dt = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {                
                throw ex;
            }

            return dt;
        }
        #endregion

        #region INSERT
        public static int Insert(Group group, List<CustomersInGroup> customersInGroup)
        {
            SqlConnection conn = DBManager.GetInstance().GetDbConnection();
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

                // insert new CustomersInGroup
                cmd.CommandText = "usp_CustomersInGroup";
                foreach (CustomersInGroup newCusomtersInGroup in customersInGroup)
                {
                    cmd.Parameters.AddWithValue("@p_GroupID", group.ID);
                    cmd.Parameters["@p_GroupID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_CustomerID", newCusomtersInGroup.CustomerID);
                    cmd.Parameters["@p_CustomerID"].Direction = ParameterDirection.Input;
                    
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
        #endregion

        #region DELETE
        public int Delete(CustomersInGroup vo)
        {
            int CustomersInGroupID = 0;
            try
            {
                //b.Delete("uv_CustomerInGroup", vo.ID);
                string query = "UPDATE CustomersInGroup SET [LastModified] = GETDATE(),[IsDeleted] = 1 WHERE ID=" + vo.ID;
                CustomersInGroupID =b.ExecuteNonQuery(query);            
            }
            catch (Exception ex)
            {
                return CustomersInGroupID = 0;
            }
            return CustomersInGroupID;
        }
        #endregion
    }
}

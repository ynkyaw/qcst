/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/27 (yyyy/MM/dd)
 * Description: A_P_Usage data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Common.DA;

namespace PTIC.Marketing.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class A_P_UsageDA
    {
        #region SELECT
        public static DataTable SelectByA_P_UsageID(int A_P_UsageID, SqlConnection conn)
        {
            DataTable table = null;
            string tableName = "A_P_UsageTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_A_P_UsageSelectByA_P_UsageID";

                command.Parameters.AddWithValue("@p_A_P_UsageID", A_P_UsageID);
                command.Parameters["@p_A_P_UsageID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
        
        /*
        public static DataTable SelectAll(SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_APTypeSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "APTypeTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["APTypeTable"];
        }
         */ 
        #endregion

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newA_P_Usage"></param>
        /// <param name="newA_P_UsageDetails"></param>
        /// <param name="conn"></param>
        /// <returns>Return inserted A_P_UsageID </returns>
        public static int? Insert(A_P_Usage newA_P_Usage, List<A_P_UsageDetail> newA_P_UsageDetails, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int? insertedA_P_UsageID = null;
            try
            {
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new A_P_Usage
                cmd.CommandText = "usp_A_P_UsageInsert";

                cmd.Parameters.AddWithValue("@p_CusID", newA_P_Usage.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeptID", newA_P_Usage.DeptID);
                cmd.Parameters["@p_DeptID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", newA_P_Usage.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersonID", newA_P_Usage.SalesPersonID);
                cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Date", newA_P_Usage.Date);
                cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Advertisement", newA_P_Usage.Advertisement);
                cmd.Parameters["@p_Advertisement"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsPTIC", newA_P_Usage.IsPTIC);
                cmd.Parameters["@p_IsPTIC"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedA_P_UsageID = (int)insertedIDObj;
                // clear parameters of usp_A_P_UsageInsert
                cmd.Parameters.Clear();
                // insert new usp_A_P_Usage detail
                cmd.CommandText = "usp_A_P_UsageDetailInsert";
                foreach (A_P_UsageDetail newA_P_UsageDetail in newA_P_UsageDetails)
                {
                    cmd.Parameters.AddWithValue("@p_A_P_UsageID", insertedA_P_UsageID);
                    cmd.Parameters["@p_A_P_UsageID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_A_P_MaterialID", newA_P_UsageDetail.A_P_MaterialID);
                    cmd.Parameters["@p_A_P_MaterialID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_BrandID", newA_P_UsageDetail.BrandID);
                    cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", newA_P_UsageDetail.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Remark", newA_P_UsageDetail.Remark);
                    cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;
                    // To substract A P Material quantity from a specific vehicle
                    cmd.Parameters.AddWithValue("@p_VenID", newA_P_Usage.VenID);
                    cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                    // clear parameters of each usp_A_P_UsageDetailInsert
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
                    return insertedA_P_UsageID;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return insertedA_P_UsageID;
        }

        /*
        public static int Insert(A_P_Usage apUsage, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BankInsert";

                //cmd.Parameters.AddWithValue("@p_Bank", apType.BankName);
                //cmd.Parameters["@p_Bank"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_BankAddress", apType.BankAddress);
                //cmd.Parameters["@p_BankAddress"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Phone", apType.Phone);
                //cmd.Parameters["@p_Phone"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Remark", apType.Remark);
                //cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return -1;
            }
        }
         */ 
        #endregion

        #region UPDATE
        public static int UpdateByA_P_UsageID(A_P_Usage mdA_P_Usage, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_A_P_UsageUpdateByA_P_UsageID";
                
                cmd.Parameters.AddWithValue("@p_A_P_UsageID", mdA_P_Usage.A_P_UsageID);
                cmd.Parameters["@p_A_P_UsageID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", mdA_P_Usage.CusID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_DeptID", mdA_P_Usage.DeptID);
                cmd.Parameters["@p_DeptID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", mdA_P_Usage.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersonID", mdA_P_Usage.SalesPersonID);
                cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Date", mdA_P_Usage.Date);
                cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Advertisement", mdA_P_Usage.Advertisement);
                cmd.Parameters["@p_Advertisement"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsPTIC", mdA_P_Usage.IsPTIC);
                cmd.Parameters["@p_IsPTIC"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        /*
        public static int UpdateByID(A_P_Usage apUsage, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BankUpdateByBankID";

                //cmd.Parameters.AddWithValue("@p_BankID", bank.BankID);
                //cmd.Parameters["@p_BankID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Bank", bank.BankName);
                //cmd.Parameters["@p_Bank"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_BankAddress", bank.BankAddress);
                //cmd.Parameters["@p_BankAddress"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Phone", bank.Phone);
                //cmd.Parameters["@p_Phone"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Remark", bank.Remark);
                //cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;



                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return -1;
            }
        }
         */ 
        #endregion

        #region DELETE
        public static int DeleteByA_P_UsageID(int A_P_UsageID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_A_P_UsageDeleteByA_P_UsageID";

                cmd.Parameters.AddWithValue("@p_A_P_UsageID", A_P_UsageID);
                cmd.Parameters["@p_A_P_UsageID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        /*
        public static int DeleteByID(A_P_Usage apUsage, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BankDeleteByBankID";

                //cmd.Parameters.AddWithValue("@p_BankID", bank.BankID);
                //cmd.Parameters["@p_BankID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return -1;
            }
        }
         */ 
        #endregion
        
    }
}

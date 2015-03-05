/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/27 (yyyy/mm/dd)
 * Description: A_P_Usage Detail data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.DA
{
    public class A_P_UsageDetailDA
    {
        #region SELECT
        public static DataTable SelectByA_P_UsageID(int A_P_UsageID, SqlConnection conn)
        {
            DataTable table = null;
            string tableName = "A_P_UsageDetailTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;

                // APSubCategoryID

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_A_P_UsageDetailSelectByA_P_UsageID";

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
        public static int? Insert(A_P_UsageDetail newA_P_UsageDetail, int vehicleID,
            SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_A_P_UsageDetailInsert";

                cmd.Parameters.AddWithValue("@p_A_P_UsageID", newA_P_UsageDetail.A_P_UsageID);
                cmd.Parameters["@p_A_P_UsageID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_A_P_MaterialID", newA_P_UsageDetail.A_P_MaterialID);
                cmd.Parameters["@p_A_P_MaterialID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BrandID", newA_P_UsageDetail.BrandID);
                cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Qty", newA_P_UsageDetail.Qty);
                cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", newA_P_UsageDetail.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", vehicleID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        /*
        public static int Insert(A_P_UsageDetail apUsageDetail, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BankInsert";

                //cmd.Parameters.AddWithValue("@p_Bank", apUsageDetail.BankName);
                //cmd.Parameters["@p_Bank"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_BankAddress", apUsageDetail.BankAddress);
                //cmd.Parameters["@p_BankAddress"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Phone", apUsageDetail.Phone);
                //cmd.Parameters["@p_Phone"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Remark", apUsageDetail.Remark);
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
        public static int UpdateByA_P_UsageDetailID(A_P_UsageDetail mdA_P_UsageDetail, int vehicleID,
            SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_A_P_UsageDetailUpdateByA_P_UsageDetailID";

                cmd.Parameters.AddWithValue("@p_A_P_UsageDetailID", mdA_P_UsageDetail.A_P_UsageDetailID);
                cmd.Parameters["@p_A_P_UsageDetailID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_A_P_UsageID", mdA_P_UsageDetail.A_P_UsageID);
                cmd.Parameters["@p_A_P_UsageID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_A_P_MaterialID", mdA_P_UsageDetail.A_P_MaterialID);
                cmd.Parameters["@p_A_P_MaterialID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BrandID", mdA_P_UsageDetail.BrandID);
                cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Qty", mdA_P_UsageDetail.Qty);
                cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", mdA_P_UsageDetail.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", vehicleID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        /*
        public static int UpdateByID(A_P_UsageDetail apUsageDetail, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BankUpdateByBankID";

                //cmd.Parameters.AddWithValue("@p_BankID", apUsageDetail.BankID);
                //cmd.Parameters["@p_BankID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Bank", apUsageDetail.BankName);
                //cmd.Parameters["@p_Bank"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_BankAddress", apUsageDetail.BankAddress);
                //cmd.Parameters["@p_BankAddress"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_Phone", apUsageDetail.Phone);
                //cmd.Parameters["@p_Phone"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", apUsageDetail.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;



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
        public static int DeleteByA_P_UsageDetailID(int A_P_UsageDetailID, int vehicleID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_A_P_UsageDetailDeleteByA_P_UsageDetailID";

                cmd.Parameters.AddWithValue("@p_A_P_UsageDetailID", A_P_UsageDetailID);
                cmd.Parameters["@p_A_P_UsageDetailID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", vehicleID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        /*
        public static int DeleteByID(A_P_UsageDetail apUsageDetail, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BankDeleteByBankID";

                cmd.Parameters.AddWithValue("@p_BankID", apUsageDetail.A_P_UsageDetailID);
                cmd.Parameters["@p_BankID"].Direction = ParameterDirection.Input;

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

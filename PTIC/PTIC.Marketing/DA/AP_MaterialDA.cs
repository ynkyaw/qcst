/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   A_P_DA
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class AP_MaterialDA
    { 
        #region SelectAll
        public static DataTable SelectAll()
        {
            DataTable table = null;
            string tableName = "AP_Material";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_AP_MaterialSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
            }
            return table;
        }
        #endregion

        #region INSERT
        /*
        public static int Insert(A_P ap, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_APInsert";

                cmd.Parameters.AddWithValue("@p_A_PTypeID", ap.A_PTypeID);
                cmd.Parameters["@p_A_PTypeID"].Direction = ParameterDirection.Input;                

                cmd.Parameters.AddWithValue("@P_A_P_Name", ap.A_PName);
                cmd.Parameters["@P_A_P_Name"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", ap.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;
                
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return -1;
            }
        }
         * */
        #endregion

        #region UPDATE
        /*
        public static int UpdateByID(A_P ap, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_APUpdateByID";

                cmd.Parameters.AddWithValue("@p_A_PID", ap.A_PID);
                cmd.Parameters["@p_A_PID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_A_PTypeID", ap.A_PTypeID);
                cmd.Parameters["@p_A_PTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@P_A_P_Name", ap.A_PName);
                cmd.Parameters["@P_A_P_Name"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", ap.Remark);
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
        /*
        public static int DeleteByID(A_P ap, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_APDeleteByID";

                cmd.Parameters.AddWithValue("@p_A_PID", ap.A_PID);
                cmd.Parameters["@p_A_PID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return -1;
            }
        }
        */
        #endregion
        //
    }
}

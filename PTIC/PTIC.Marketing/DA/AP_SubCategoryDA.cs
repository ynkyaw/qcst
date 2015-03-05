/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   A_P_TypeDA
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
    public class AP_SubCategoryDA
    {
        #region SelectAll
        public static DataTable SelectAll()
        {
            DataTable table = null;
            string tableName = "AP_SubCategory";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_AP_SubCategorySelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
        #endregion

        #region INSERT
        /*
        public static int Insert(A_P_Type apType, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_APTypeInsert";

                cmd.Parameters.AddWithValue("@p_A_P_TypeName", apType.A_P_TypeName);
                cmd.Parameters["@p_A_P_TypeName"].Direction = ParameterDirection.Input;

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
        /*
        public static int UpdateByID(A_P_Type apType, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_APTypeUpdateByID";

                cmd.Parameters.AddWithValue("@p_APTypeID", apType.A_P_TypeID);
                cmd.Parameters["@p_APTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_APTypeName", apType.A_P_TypeName);
                cmd.Parameters["@p_APTypeName"].Direction = ParameterDirection.Input;
                
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
        public static int DeleteByID(A_P_Type apType, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_APTypeDeleteByID";

                cmd.Parameters.AddWithValue("@p_A_PTypeID", apType.A_P_TypeID);
                cmd.Parameters["@p_A_PTypeID"].Direction = ParameterDirection.Input;

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

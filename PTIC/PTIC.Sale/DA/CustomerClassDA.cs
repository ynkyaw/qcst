/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   CustomerClassDA ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    public class CustomerClassDA
    {
         #region SelectAll

        public static DataTable SelectAll()
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_CustomerClassSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "CustomerClassTable");
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return dataSet.Tables["CustomerClassTable"];
        }
        #endregion

        #region SelectCuClassWithTownship
        public static DataTable SelectWithTownship(SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_CustomerClassSelectWithTownship";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "CustomerClassWithTownshipTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["CustomerClassWithTownshipTable"];
        }
        #endregion

        #region INSERT
        public static int Insert(CustomerClass customerclass, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CustomerClassInsert";

                cmd.Parameters.AddWithValue("@p_CusClass", customerclass.CusClass);
                cmd.Parameters["@p_CusClass"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Description", customerclass.Description);
                cmd.Parameters["@p_Description"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", customerclass.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(CustomerClass customerclass, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CustomerClassUpdateByCustomerClassID";

                cmd.Parameters.AddWithValue("@p_CustomerClassID", customerclass.CustomerClassID);
                cmd.Parameters["@p_CustomerClassID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusClass", customerclass.CusClass);
                cmd.Parameters["@p_CusClass"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Description", customerclass.Description);
                cmd.Parameters["@p_Description"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", customerclass.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(CustomerClass customerclass, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CustomerClassDeleteByCustomerClassID";

                cmd.Parameters.AddWithValue("@p_CustomerClassID", customerclass.CustomerClassID);
                cmd.Parameters["@p_CustomerClassID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion
    }
}


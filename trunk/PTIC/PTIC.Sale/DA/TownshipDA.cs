/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   TownshipDA ( Insert , Update , Delete , Select}
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
    public class TownshipDA
    {
        #region SelectWithCustomer

        public static DataTable SelectWithCustomerType()
        {
            DataTable table = null;
            string tableName = "TownshipWithCusTypeTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TownshipWithCusTypeSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
            }
            return table;
        }
        #endregion

        #region SelectAll

        public static DataTable SelectAll()
        {
            DataTable table = null;
            string tableName = "TownshipTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TownshipSelectAll";

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
        public static int Insert(Township township, SqlConnection conn)
        {
            int affectedrow = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TownshipInsert";

                cmd.Parameters.AddWithValue("@p_TownID", township.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Township", township.TownshipName);
                cmd.Parameters["@p_Township"].Direction = ParameterDirection.Input;

                affectedrow = cmd.ExecuteNonQuery();
                return affectedrow;
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(Township township, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TownshipUpdateByTownshipID";

                cmd.Parameters.AddWithValue("@p_TownshipID", township.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownID", township.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Township", township.TownshipName);
                cmd.Parameters["@p_Township"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(Township township, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TownshipDeleteByTownshipID";

                cmd.Parameters.AddWithValue("@p_TownshipID", township.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

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

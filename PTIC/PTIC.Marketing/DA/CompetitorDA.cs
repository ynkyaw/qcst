/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   CompetitorDA
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
    class CompetitorDA
    {
        //

        #region SelectAll

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
        #endregion

        #region INSERT
        public static int Insert(Competitor competitor, SqlConnection conn)
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
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(Competitor competitor, SqlConnection conn)
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
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(Competitor competitor, SqlConnection conn)
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
                return 0;
            }
        }
        #endregion
        //
    }
}

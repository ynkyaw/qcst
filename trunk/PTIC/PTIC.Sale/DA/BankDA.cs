/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   BankDA ( Insert , Update , Delete , Select}
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
    public class BankDA
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
                command.CommandText = "usp_BankSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "BankTable");
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            finally 
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return dataSet.Tables["BankTable"];
        }

        public static DataTable SelectBy(int TownID, string BankName)
        {
            DataTable table = null;
            string tableName = "BankTalbe";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandText = "SELECT * FROM Bank WHERE TownID = @p_TownID AND Bank = @p_BankName AND IsDeleted = 0";

                command.Parameters.AddWithValue("@p_TownID", TownID);
                command.Parameters.AddWithValue("@p_BankName", BankName);

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
        public static int Insert(Bank bank)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BankInsert";

                cmd.Parameters.AddWithValue("@p_Bank", bank.BankName);
                cmd.Parameters["@p_Bank"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_City", bank.TownID);
                //cmd.Parameters["@p_City"].Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@p_TownID", bank.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BankAddress", bank.BankAddress);
                cmd.Parameters["@p_BankAddress"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone", bank.Phone);
                cmd.Parameters["@p_Phone"].Direction = ParameterDirection.Input;

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

        #region UPDATE
        public static int UpdateByID(Bank bank)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BankUpdateByBankID";

                cmd.Parameters.AddWithValue("@p_BankID", bank.BankID);
                cmd.Parameters["@p_BankID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownID", bank.TownID);
                cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Bank", bank.BankName);
                cmd.Parameters["@p_Bank"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_BankAddress", bank.BankAddress);
                cmd.Parameters["@p_BankAddress"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Phone", bank.Phone);
                cmd.Parameters["@p_Phone"].Direction = ParameterDirection.Input;

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
        public static int DeleteByID(Bank bank)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_BankDeleteByBankID";

                cmd.Parameters.AddWithValue("@p_BankID", bank.BankID);
                cmd.Parameters["@p_BankID"].Direction = ParameterDirection.Input;

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

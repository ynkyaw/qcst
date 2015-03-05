/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   CashDiscountDA ( Insert , Update , Delete , Select}
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
    public class CashDiscountDA
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
                command.CommandText = "usp_CashDiscountSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "CashDiscountTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["CashDiscountTable"];
        }
        #endregion

        #region INSERT
        public static int Insert(CashDiscount cashdiscount, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CashDiscountInsert";

                cmd.Parameters.AddWithValue("@p_Date", cashdiscount.Date);
                cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CashCommPercent", cashdiscount.CashCommPercent);
                cmd.Parameters["@p_CashCommPercent"].Direction = ParameterDirection.Input;
                
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(CashDiscount cashdiscount, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CashDiscountUpdate";

                cmd.Parameters.AddWithValue("@p_CashDiscountID", cashdiscount.CashDiscountID);
                cmd.Parameters["@p_CashDiscountID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Date", cashdiscount.Date);
                cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CashCommPercent", cashdiscount.CashCommPercent);
                cmd.Parameters["@p_CashCommPercent"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(CashDiscount cashdiscount, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CashDiscountDelete";

                cmd.Parameters.AddWithValue("@p_CashDiscountID", cashdiscount.CashDiscountID);
                cmd.Parameters["@p_CashDiscountID"].Direction = ParameterDirection.Input;

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

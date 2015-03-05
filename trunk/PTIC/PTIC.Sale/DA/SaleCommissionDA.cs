/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   SaleCommissionDA ( Insert , Update , Delete , Select}
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
    public class SaleCommissionDA
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
                command.CommandText = "usp_SaleCommissionSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "SaleCommissionTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["SaleCommissionTable"];
        }
        #endregion

        #region INSERT
        public static int Insert(SaleCommission salecommission, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SaleCommissionInsert";

                cmd.Parameters.AddWithValue("@p_SaleCommPercent", salecommission.SaleCommPercent);
                cmd.Parameters["@p_SaleCommPercent"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CommAmt1", salecommission.CommAmt1);
                cmd.Parameters["@p_CommAmt1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CommAmt2", salecommission.CommAmt2);
                cmd.Parameters["@p_CommAmt2"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(SaleCommission salecommission, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SaleCommissionUpdate";

                cmd.Parameters.AddWithValue("@p_SaleCommissionID", salecommission.SaleCommissionID);
                cmd.Parameters["@p_SaleCommissionID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SaleCommPercent", salecommission.SaleCommPercent);
                cmd.Parameters["@p_SaleCommPercent"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CommAmt1", salecommission.CommAmt1);
                cmd.Parameters["@p_CommAmt1"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CommAmt2", salecommission.CommAmt2);
                cmd.Parameters["@p_CommAmt2"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(SaleCommission salecommission, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SaleCommissionDelete";

                cmd.Parameters.AddWithValue("@p_SaleCommissionID", salecommission.SaleCommissionID);
                cmd.Parameters["@p_SaleCommissionID"].Direction = ParameterDirection.Input;

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

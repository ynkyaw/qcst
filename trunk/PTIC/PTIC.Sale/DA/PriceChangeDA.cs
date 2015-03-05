/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   PriceChangeDA ( Insert , Update , Delete , Select}
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
    public class PriceChangeDA
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
                command.CommandText = "usp_PriceChangeSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "PriceChangeTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["PriceChangeTable"];
        }

        public static DataTable SelectBy(int productID, DateTime date)
        {
            DataTable table = null;
            string tableName = "PriceChangeTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_PriceChangeSelectBy";

                command.Parameters.AddWithValue("@p_ProductID", productID);
                command.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_Date", date);
                command.Parameters["@p_Date"].Direction = ParameterDirection.Input;

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
        public static int Insert(PriceChange pricechange, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_PriceChangeInsert";

                cmd.Parameters.AddWithValue("@p_ProductID", pricechange.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TranDate", pricechange.TranDate);
                cmd.Parameters["@p_TranDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_WholeSaleNo", pricechange.WholeSaleNo);
                cmd.Parameters["@p_WholeSaleNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_WSPrice", pricechange.WSPrice);
                cmd.Parameters["@p_WSPrice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RetailNo", pricechange.RetailNo);
                cmd.Parameters["@p_RetailNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RSPrice", pricechange.RSPrice);
                cmd.Parameters["@p_RSPrice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_AcidPrice", pricechange.AcidPrice);
                cmd.Parameters["@p_AcidPrice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ChangeFromDate", pricechange.ChangeFromDate);
                cmd.Parameters["@p_ChangeFromDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ChangeToDate", pricechange.ChangeToDate);
                cmd.Parameters["@p_ChangeToDate"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(PriceChange pricechange, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_PriceChangeUpdateByPriceChange";

                cmd.Parameters.AddWithValue("@p_PriceChangeID", pricechange.PriceChangeID);
                cmd.Parameters["@p_PriceChangeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ProductID", pricechange.ProductID);
                cmd.Parameters["@p_ProductID"].Direction = ParameterDirection.Input;
                
                cmd.Parameters.AddWithValue("@p_TranDate", pricechange.TranDate);
                cmd.Parameters["@p_TranDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_WholeSaleNo", pricechange.WholeSaleNo);
                cmd.Parameters["@p_WholeSaleNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_WSPrice", pricechange.WSPrice);
                cmd.Parameters["@p_WSPrice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RetailNo", pricechange.RetailNo);
                cmd.Parameters["@p_RetailNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RSPrice", pricechange.RSPrice);
                cmd.Parameters["@p_RSPrice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_AcidPrice", pricechange.AcidPrice);
                cmd.Parameters["@p_AcidPrice"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ChangeFromDate", pricechange.ChangeFromDate);
                cmd.Parameters["@p_ChangeFromDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ChangeToDate", pricechange.ChangeToDate);
                cmd.Parameters["@p_ChangeToDate"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(PriceChange pricechange, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_PriceChangeDeleteByPriceChangeID";

                cmd.Parameters.AddWithValue("@p_PriceChangeID", pricechange.PriceChangeID);
                cmd.Parameters["@p_PriceChangeID"].Direction = ParameterDirection.Input;

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

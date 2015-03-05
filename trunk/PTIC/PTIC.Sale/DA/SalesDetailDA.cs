/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Sale Detail data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Sale.Entities;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class SalesDetailDA
    {
        #region SELECT
        public static DataTable SelectByInvoiceID(int? invoiceID)
        {
            DataTable dt = null;
            string tableName = "SalesDetailTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SalesDetailSelectByInvoiceID";

                command.Parameters.AddWithValue("@p_InvoiceID", invoiceID);
                command.Parameters["@p_InvoiceID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }
        #endregion

        #region INSERT
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        public static int DeleteByID(int saledeatil, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SaleDetailDeleteBySaleDetailID";

                cmd.Parameters.AddWithValue("@p_SaleDetialID", saledeatil);
                cmd.Parameters["@p_SaleDetialID"].Direction = ParameterDirection.Input;

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

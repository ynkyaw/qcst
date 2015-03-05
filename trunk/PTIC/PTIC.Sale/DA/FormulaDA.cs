using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PTIC.Sale.DA
{
    public class FormulaDA
    {
        #region SELECT
        /// <summary>
        /// Retrieve all Convert Formula from database
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all orders</returns>
        public static DataTable SelectAll(SqlConnection conn)
        {
            DataTable table = null;
            string tableName = "FormulaTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_FormulaSlectAll";

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
    }
}

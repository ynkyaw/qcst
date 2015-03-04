/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   TransportTypeDA ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    public class TransportTypeDA
    {
        #region SelectAll

        public static DataTable SelectAll()
        {
            DataTable table = null;
            string tableName = "TransportTypeTable";
            try
            {
                SqlConnection conn = DBManager.GetInstance().GetDbConnection();
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TransportTypeSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
            }
            return table;
        }
        #endregion
    }
}

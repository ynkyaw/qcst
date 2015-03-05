using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class AP_CategoryDA
    {
        #region SelectAll

        public static DataTable SelectAll()
        {
            DataTable table = null;
            string tableName = "AP_Category";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_AP_CategorySelectAll";

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

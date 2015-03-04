using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PTIC.Sale.DA
{
    public class UserDA
    {
        public static DataTable GetAll(SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_UserSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "UserTable");
            }
            catch (SqlException sqle)
            {
                // show error message
            }
            return dataSet.Tables["UserTable"];
        }
    }
        

    
}

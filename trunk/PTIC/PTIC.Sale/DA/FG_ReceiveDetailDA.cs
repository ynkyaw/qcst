using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PTIC.Sale.DA
{
    public class FG_ReceiveDetailDA
    {
        internal static DataTable GetAll(SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_FG_ReceiveDetailSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "FG_ReceiveDetailTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["FG_ReceiveDetailTable"];
        }
    }
}

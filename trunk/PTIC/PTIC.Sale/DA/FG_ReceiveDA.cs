using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Common;
using PTIC.Common.DA;

namespace PTIC.Sale.DA
{
    public class FG_ReceiveDA
    {
        static BaseDAO b = new BaseDAO();
        internal static DataTable GetAll(SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_FG_ReceiveSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "FG_ReceiveTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["FG_ReceiveTable"];
        }

        internal static DataTable GetStockInMainStore()
        {
            DataTable dt = null;
            try
            {
                string query = "SELECT * FROM StockInWarehouse WHERE WarehouseID = 1 AND IsDeleted =0";
                dt = b.SelectByQuery(query);
                
            }
            catch (SqlException Sqle)
            {
            }
            return dt;
        }
    }
}

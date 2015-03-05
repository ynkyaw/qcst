using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PTIC.Common.DA
{
    public class RP_AP_UsageCustomersDA
    {
        public static DataTable APUsageSelectBy(DateTime startDate,DateTime endDate,bool aPUsageCustomer)
        {
            SqlConnection conn = DBManager.GetInstance().GetDbConnection();
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_AP_UsageCustomersSelectBy";

                command.Parameters.AddWithValue("@p_startDate", startDate);
                command.Parameters["@p_startDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_endDate", endDate);
                command.Parameters["@p_endDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_APUsageCustomer", aPUsageCustomer);
                command.Parameters["@p_APUsageCustomer"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "AP_UsageCustomers");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["AP_UsageCustomers"];

        }

        public static DataTable CustomerNotUsedPOSMSelectBy(DateTime startDate, DateTime endDate)
        {
            DataTable table = null;
            string tableName = "DailyMarketingTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_POSMUnUsedListSelectBy";

                command.Parameters.AddWithValue("@p_startDate", startDate);
                command.Parameters["@p_startDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_endDate", endDate);
                command.Parameters["@p_endDate"].Direction = ParameterDirection.Input;             

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
    }
}

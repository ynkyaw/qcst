using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Common.DA;

namespace PTIC.Sale.DA
{
    public class FGRequestDetailDA
    {
        static BaseDAO b = new BaseDAO();

        public static DataTable SelectAllFGRequestIssue()
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery("SELECT * FROM uv_FGNewRequest");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }

        internal static DataTable GetAll(SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_FGRequestDetailSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "FGRequestDetailTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["FGRequestDetailTable"];
        }

        public static DataTable SelectByFormFGRequestID(int FGRequestID)
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM uv_FGRequestIssue WHERE FGRequestID ={0}";
                dt = b.SelectByQuery(String.Format(query, FGRequestID));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
        }




        public static DataTable SelectByRequireDate(DateTime requireDate, SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_FGRequestSelectAllByRequireDate";

                command.Parameters.AddWithValue("@p_RequireDate", requireDate);
                command.Parameters["@p_RequireDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "FGRequestDetail");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["FGRequestDetail"];
        }

        public static DataTable SelectByFGRequestID(int FGRequestID, SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_FGRequestDetailSelectByFGRequestID";

                command.Parameters.AddWithValue("@p_FGRequestID", FGRequestID);
                command.Parameters["@p_FGRequestID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "FGRequestDetail");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["FGRequestDetail"];
        }

    }
}

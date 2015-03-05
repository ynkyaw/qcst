using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class SurveyAnswerDA
    {
        #region SELECT
        public static DataTable SelectSurveyResultBy(
            DateTime startDate, DateTime endDate, PTIC.Common.Enum.QuestionForm questionForm, 
            Customer customer, Address address)
        {
            DataTable table = null;
            string tableName = "SurveyResultTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SurveyResultSelectBy";

                command.Parameters.AddWithValue("@p_startDate", startDate);
                command.Parameters["@p_startDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_endDate", endDate);
                command.Parameters["@p_endDate"].Direction = ParameterDirection.Input; 

                command.Parameters.AddWithValue("@p_questionForm", (int)questionForm);
                command.Parameters["@p_questionForm"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_routeID", customer.RouteID);
                command.Parameters["@p_routeID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_townshipID", address.TownshipID);
                command.Parameters["@p_townshipID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_tripID", customer.TripID);
                command.Parameters["@p_tripID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_townID", address.TownID);
                command.Parameters["@p_townID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return table;
        }
        #endregion
    }
}

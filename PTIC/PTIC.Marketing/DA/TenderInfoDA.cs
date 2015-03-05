using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PTIC.Marketing.DA
{
    public class TenderInfoDA
    {
        internal static DataTable GetTenderInfoByID(int tenderID, SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TenderInfoSelectByID";

                command.Parameters.AddWithValue("@p_tenderinfoID", tenderID);
                command.Parameters["@p_tenderinfoID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "TenderInfoTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["TenderInfoTable"];
            
        }

        internal static int UpdateInfo(Entities.TenderInfo tenderinfo, SqlConnection conn)
        {
              try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TenderInfoUpdate";


                cmd.Parameters.AddWithValue("@p_TenderInfoID", tenderinfo.ID);
                cmd.Parameters["@p_TenderInfoID"].Direction = ParameterDirection.Input;


                cmd.Parameters.AddWithValue("@p_TranDate", tenderinfo.TranDate);
                cmd.Parameters["@p_TranDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_GovName", tenderinfo.GovName);
                cmd.Parameters["@p_GovName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OpenDate", tenderinfo.OpenDate);
                cmd.Parameters["@p_OpenDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TenderNo", tenderinfo.TenderNo);
                cmd.Parameters["@p_TenderNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TenderName", tenderinfo.TenderName);
                cmd.Parameters["@p_TenderName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CloseDate", tenderinfo.CloseDate);
                cmd.Parameters["@p_CloseDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ContactP", tenderinfo.ContactPerson);
                cmd.Parameters["@p_ContactP"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        internal static int? InsertInfo(Entities.TenderInfo tenderinfo, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TenderInfoInsert";

                cmd.Parameters.AddWithValue("@p_TranDate", tenderinfo.TranDate);
                cmd.Parameters["@p_TranDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_GovName", tenderinfo.GovName);
                cmd.Parameters["@p_GovName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_OpenDate", tenderinfo.OpenDate);
                cmd.Parameters["@p_OpenDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TenderNo", tenderinfo.TenderNo);
                cmd.Parameters["@p_TenderNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TenderName", tenderinfo.TenderName);
                cmd.Parameters["@p_TenderName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CloseDate", tenderinfo.CloseDate);
                cmd.Parameters["@p_CloseDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ContactP", tenderinfo.ContactPerson);
                cmd.Parameters["@p_ContactP"].Direction = ParameterDirection.Input;

                int id = 0;
                id=(int) cmd.ExecuteScalar();
                return id;
            }
            catch (SqlException sqle)
            {
                return null;
            }
        }
    }
}

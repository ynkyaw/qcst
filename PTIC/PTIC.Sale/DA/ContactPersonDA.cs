using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    public class ContactPersonDA
    {
        #region SELECT
        /// <summary>
        /// Retrieve all ContactPerson from database
        /// </summary>        
        /// <returns>Return datatable containing all customers</returns>
        public static DataTable SelectAll(int CusID)
        {
            DataTable table = null;
            try
            {
                table = new DataTable("ContactPersonTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_ContactPersonSelectAll";

                command.Parameters.AddWithValue("@p_CusID", CusID);
                command.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw;
            }
            return table;
        }
        #endregion
    }
}

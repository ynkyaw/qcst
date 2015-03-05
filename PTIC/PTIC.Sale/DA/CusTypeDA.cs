/* Author   :   Aung Ko Ko
    Date      :   26 Feb 2014
    Description :   CusTypeDA ( Insert , Update , Delete , Select}
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
    public class CusTypeDA
    {
        #region SelectAll
        public static DataTable Select()
        {
            DataTable table = null;
            string tableName = "CusTypeTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_CusTypeSlectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
            }
            return table;
        }
        #endregion

        #region SelectAllWithCusID
        public static DataTable SelectAll()
        {
            DataTable table = null;
            string tableName = "CusTypeTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_CusTypeSlectAllCusID";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return table;
        }
        #endregion

        #region SelectAll

        public static DataTable SelectAllByTownshipID(int TownshipID,SqlConnection conn)
        {
            DataTable table = null;
            string tableName = "CusTypeTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_CusTypeSlectAllByTownship";

                command.Parameters.AddWithValue("@p_TownshipID", TownshipID);
                command.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

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

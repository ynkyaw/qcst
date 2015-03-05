/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   TransportGate ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    public class TransportGateDA
    {
        #region SelectAll

        public static DataTable SelectAll()
        {
            DataTable table = null;
            string tableName = "TransportGateTable";
            try
            {
                SqlConnection conn = DBManager.GetInstance().GetDbConnection();
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TransportGateSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
            }
            return table;
        }

        public static DataTable SelectBy(int transportTypeID, string gateName)
        {
            DataTable table = null;
            string tableName = "TransportGateTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandText = "SELECT * FROM TransportGate WHERE TransportTypeID = @p_TransportTypeID AND GateName = @p_GateName ";

                command.Parameters.AddWithValue("@p_TransportTypeID", transportTypeID);
                command.Parameters.AddWithValue("@p_GateName", gateName);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
        #endregion

        #region INSERT
        public static int Insert(TransportGate transportgate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TransportGateInsert";

                cmd.Parameters.AddWithValue("@p_TransportTypeID", transportgate.TransportTypeID);
                cmd.Parameters["@p_TransportTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_GateName", transportgate.GateName);
                cmd.Parameters["@p_GateName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", transportgate.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(TransportGate transportgate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TransportGateUpdateByTransportGateID";

                cmd.Parameters.AddWithValue("@p_TransportGateID", transportgate.TransportGateID);
                cmd.Parameters["@p_TransportGateID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TransportTypeID", transportgate.TransportTypeID);
                cmd.Parameters["@p_TransportTypeID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_GateName", transportgate.GateName);
                cmd.Parameters["@p_GateName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", transportgate.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(TransportGate transportgate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TransportGateDeleteByTransportGateID";

                cmd.Parameters.AddWithValue("@p_TransportGateID", transportgate.TransportGateID);
                cmd.Parameters["@p_TransportGateID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion
    }
}

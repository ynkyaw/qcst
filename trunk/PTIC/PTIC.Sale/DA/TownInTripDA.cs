/* Author   :   Aung Ko Ko
    Date      :   20 Feb 2014
    Description :   TownInTripDA
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
    public class TownInTripDA
    {
        #region SelectAll

        public static DataTable SelectTownInTripByTownID(int TownID)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable("TownInTripTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM TownInTrip WHERE TownID = @p_TownID AND IsDeleted =0";

                command.Parameters.AddWithValue("@p_TownID", TownID);
                command.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
            }
            return dt;
        }

        
        public static int GetTownShipCountByTownId(int TownID)
        {
            int cnt = 0;
            try
            {
                
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Count(*) FROM Township WHERE TownID = @p_TownID AND IsDeleted =0";

                command.Parameters.AddWithValue("@p_TownID", TownID);
                command.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                cnt = (int)command.ExecuteScalar();
                
            }
            catch (SqlException sqle)
            {
            }
            return cnt;
        }
        


        public static DataTable SelectAll()
        {
            DataTable dt = null;
            try
             {
                dt = new DataTable("TownInTripTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TownInTripSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
            }
            return dt;
        }

        public static DataTable SelectBy(int tripID, int townID)
        {
            DataTable dt = null;
            SqlConnection conn = null;
            string tableName = "TownInTripTable";
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;

                command.CommandText = "SELECT ID FROM TownInTrip WHERE TripID = @p_TripID AND TownID = @p_TownID ";

                command.Parameters.AddWithValue("@p_TripID", tripID);
                command.Parameters.AddWithValue("@p_TownID", townID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            finally 
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return dt;
        }
        #endregion

        #region INSERT
        public static int Insert(List<TownInTrip> townInTripList)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            SqlConnection conn = null;
            int affectedRow = 0;
            try
            {
                cmd = new SqlCommand();
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.Transaction = transaction;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TownInTripInsert";

                foreach(TownInTrip townInTrip in townInTripList)
                {
                    cmd.Parameters.AddWithValue("@p_TripID", townInTrip.TripID);
                    cmd.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownID", townInTrip.TownID);
                    cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                    affectedRow += cmd.ExecuteNonQuery();
                    // Clear parameters of each usp_OrderDetailInsert
                    cmd.Parameters.Clear();
                }
                // Commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    throw sqle;
                }     
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return affectedRow;
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(List<TownInTrip> townInTripList)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            SqlConnection conn = null;
            int affectedRow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = transaction;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TownInTripUpdateByTownInTripID";

                foreach (TownInTrip townInTrip in townInTripList)
                {
                    cmd.Parameters.AddWithValue("@p_TownInTripID", townInTrip.TownInTripID);
                    cmd.Parameters["@p_TownInTripID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TripID", townInTrip.TripID);
                    cmd.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownID", townInTrip.TownID);
                    cmd.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                    affectedRow += cmd.ExecuteNonQuery();
                    // Clear parameters of each usp_OrderDetailInsert
                    cmd.Parameters.Clear();
                }
                // Commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    throw sqle;
                }
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return affectedRow;
        }
        #endregion

        #region DELETE
        public static int DeleteByID(TownInTrip twonintrip)
        {
            int affectedRow = 0;
            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TownInTripDeleteByTownInTripID";

                cmd.Parameters.AddWithValue("@p_TownInTripID", twonintrip.TownInTripID);
                cmd.Parameters["@p_TownInTripID"].Direction = ParameterDirection.Input;

                affectedRow = cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();               
            }
            return affectedRow;
        }
        #endregion
    }
}

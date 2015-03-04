/* Author   :   Aung Ko Ko
    Date      :   20 Feb 2014
    Description :   TripDA Entity
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
    public class TripDA
    {
        #region SelectAll

        public static DataTable SelectAll()
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable("TripTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripSelectAll";

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

        public static DataTable SelectAllTownByTripID(int TripID)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable("TripTownTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Trip.ID As TripID,TripName,TownID,Town "
                                         +"FROM "
                                          +"Trip "
                                           +"INNER JOIN TownInTrip ON TownInTrip.TripID = TripID "
                                             +"INNER JOIN Town ON Town.ID = TownInTrip.TownID "
                                               +"WHERE Trip.IsDeleted = 0 AND Trip.ID =@TripID";

                command.Parameters.AddWithValue("@TripID", TripID);
                command.Parameters["@TripID"].Direction = ParameterDirection.Input;

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
        public static int Insert(Trip trip)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripInsert";

                cmd.Parameters.AddWithValue("@p_TripName", trip.TripName);
                cmd.Parameters["@p_TripName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripPeriod", trip.TripPeriod);
                cmd.Parameters["@p_TripPeriod"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", trip.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            finally 
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(Trip trip)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripUpdateByTripID";

                cmd.Parameters.AddWithValue("@p_TripID", trip.TripID);
                cmd.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripName", trip.TripName);
                cmd.Parameters["@p_TripName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TripPeriod", trip.TripPeriod);
                cmd.Parameters["@p_TripPeriod"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", trip.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            finally 
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(Trip trip)
        {
            int affectedRows = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripDeleteByTripID";

                cmd.Parameters.AddWithValue("@p_TripID", trip.TripID);
                cmd.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                affectedRows= cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 547)
                {
                    throw new Exception("ခရီးစဉ်တွင်ပါဝင်မည့်မြို့များသတ်မှတ်ပြီးဖြစ်သည်။ မြို့များသတ်မှတ်ထား၍ သိုမဟုတ် ခရီးစဉ် Plan တွင် အသုံးပြုထား၍ဖျက်မရပါ။");
                }
            }
            finally 
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return affectedRows;
        }
        #endregion
    }
}


/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, 
 * Create date: 3 March 2013
 * Description: about TripPlan_AP
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.DA
{
    /// <summary>
    /// 
    /// </summary>
    public class TripPlan_AP_DA
    {

        #region SELECT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static DataTable SelectAll(SqlConnection conn)
        {
            DataSet dataSet = null;
           
            string tableName = "TripPlan_APTable";
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripPlan_AP_SelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, tableName);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dataSet.Tables[tableName];
        }



        public static DataTable SelectByTripPlanDetailID(int tripPlanDetailID, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "T_R_APTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripPlan_AP_SelectByTripPlanDetailID";

                command.Parameters.AddWithValue("@p_TripPlanDetailID", tripPlanDetailID);
                command.Parameters["@p_TripPlanDetailID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }

        public static DataTable SelectByNo(string No, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "TripPlan_APTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TripPlan_APSelectByNo";

                command.Parameters.AddWithValue("@p_No", No);
                command.Parameters["@p_OrderNo"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dt;
        }
        #endregion

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newOrderDetail"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int Insert(List<TripPlan_AP> tripPlan_AP, SqlConnection conn)
        {
            int affectedRows = 0;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripPlan_AP_Insert";

                foreach (TripPlan_AP newtripPlan_AP in tripPlan_AP)
                {
                    cmd.Parameters.AddWithValue("@p_TripPlanDetailID", newtripPlan_AP.TripPlanDetailID);
                    cmd.Parameters["@p_TripPlanDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_A_PID", newtripPlan_AP.A_PID);
                    cmd.Parameters["@p_A_PID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", newtripPlan_AP.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_TripPlan_AP_Insert
                    cmd.Parameters.Clear();
                }
              //  return cmd.ExecuteNonQuery();
                return affectedRows;
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdOrderDetail"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int UpdateByTripPlan_APID(List<TripPlan_AP> mdTripPlan_AP, SqlConnection conn)
        {
            int affectedRows = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripPlan_APUpdateByTripPlan_APID";

                foreach (TripPlan_AP newtripPlan_AP in mdTripPlan_AP)
                {
                    cmd.Parameters.AddWithValue("@p_TripPlan_APID", newtripPlan_AP.ID);
                    cmd.Parameters["@p_TripPlan_APID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TripPlanDetailID", newtripPlan_AP.TripPlanDetailID);
                    cmd.Parameters["@p_TripPlanDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_A_PID", newtripPlan_AP.A_PID);
                    cmd.Parameters["@p_A_PID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", newtripPlan_AP.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_TripPlan_APUpdateByTripPlan_APID
                    cmd.Parameters.Clear();
                }

                return affectedRows;
               // return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetailID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int DeleteByTripPlan_APID(List<TripPlan_AP> mdTripPlan_AP , SqlConnection conn)
        {
            int affectedRows = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TripPlan_AP_DeleteByTripPlan_AP_ID";

                foreach (TripPlan_AP newtripPlan_AP in mdTripPlan_AP)
                {
                    cmd.Parameters.AddWithValue("@p_TripPlan_AP_ID", newtripPlan_AP.ID);
                    cmd.Parameters["@p_TripPlan_AP_ID"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_TripPlan_AP_DeleteByTripPlan_AP_ID
                    cmd.Parameters.Clear();
                }
                return affectedRows;
                //return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

    }
}


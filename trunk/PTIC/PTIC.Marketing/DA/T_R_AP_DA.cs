
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, 
 * Create date: 3 March 2013
 * Description: about T R AP
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
    public class T_R_AP_DA
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
            string tableName = "T_R_APTable";
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_T_R_APSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, tableName);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return dataSet.Tables[tableName];
        }

        public static DataTable SelectByOrderID(int orderID, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "T_R_APTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_T_R_APSelectByID";

                command.Parameters.AddWithValue("@p_OrderID", orderID);
                command.Parameters["@p_OrderID"].Direction = ParameterDirection.Input;

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
            string tableName = "T_R_APTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_T_R_APSelectByNo";

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


        public static DataTable SelectByTripReqID(int tripReqID, SqlConnection conn)
        {
            DataTable dt = null;
            string tableName = "T_R_APTable";
            try
            {
                dt = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_T_R_APSelectByTripReqID";

                command.Parameters.AddWithValue("@p_tripReqid", tripReqID);
                command.Parameters["@p_tripReqid"].Direction = ParameterDirection.Input;

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
        public static int Insert(List<T_R_AP> newT_R_AP, SqlConnection conn)
        {
            int affectedRows = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_T_R_AP_Insert";

                foreach (T_R_AP t_r_ap in newT_R_AP)
                {
                    cmd.Parameters.AddWithValue("@p_tripReqid", t_r_ap.TripReqID);
                    cmd.Parameters["@p_tripReqid"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_A_PID", t_r_ap.A_PID);
                    cmd.Parameters["@p_A_PID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", t_r_ap.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_T_R_AP_Insert
                    cmd.Parameters.Clear();

                }

               // return cmd.ExecuteNonQuery();
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
        public static int UpdateByT_R_APID(List<T_R_AP> mdT_R_AP, SqlConnection conn)
        {
            int affectedRows = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_T_R_APUpdateByT_R_APID";

                foreach (T_R_AP t_r_ap in mdT_R_AP)
                {
                    cmd.Parameters.AddWithValue("@p_T_R_APID", t_r_ap.ID);
                    cmd.Parameters["@p_T_R_APID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TripReqID", t_r_ap.TripReqID);
                    cmd.Parameters["@p_TripReqID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_A_PID", t_r_ap.A_PID);
                    cmd.Parameters["@p_A_PID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Qty", t_r_ap.Qty);
                    cmd.Parameters["@p_Qty"].Direction = ParameterDirection.Input;
  
                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_T_R_APUpdateByT_R_APID
                    cmd.Parameters.Clear();
                }
               // return cmd.ExecuteNonQuery();
                return affectedRows;

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
        public static int DeleteByT_R_APID(List<T_R_AP> T_R_APs, SqlConnection conn)
        {
            int affectedRows = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_T_R_APDeleteByT_R_APID";

                foreach (T_R_AP t_r_ap in T_R_APs)
                {
                    cmd.Parameters.AddWithValue("@p_T_R_APID", t_r_ap.ID);
                    cmd.Parameters["@p_T_R_APID"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_T_R_APDeleteByT_R_APID
                    cmd.Parameters.Clear();
                }
             //   return cmd.ExecuteNonQuery();
                return affectedRows;
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

    }
}


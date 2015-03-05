/* Author   :   Aung Ko Ko
    Date      :   18 Feb 2014
    Description :   SDivisoinDA ( Insert , Update , Delete , Select}
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
    public class SDivisionDA
    {
        #region SelectAllDivision

        public static DataTable SelectAll()
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_SDivisionSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "SDivisionTable");
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return dataSet.Tables["SDivisionTable"];
        }
        #endregion

        #region INSERT
        public static int Insert(SDivision sdivision, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SDivisionInsert";

                cmd.Parameters.AddWithValue("@p_statedivisionname", sdivision.StateDivisionName);
                cmd.Parameters["@p_statedivisionname"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(SDivision sdivision, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SDivisionUpdateByID";

                cmd.Parameters.AddWithValue("@p_id", sdivision.ID);
                cmd.Parameters["@p_id"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_statedivisionname", sdivision.StateDivisionName);
                cmd.Parameters["@p_statedivisionname"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(SDivision sdivision, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_SDivisionDelete";

                cmd.Parameters.AddWithValue("@p_id", sdivision.ID);
                cmd.Parameters["@p_id"].Direction = ParameterDirection.Input;

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

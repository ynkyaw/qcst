/* Author   :   Aung Ko Ko
    Date      :   22 Feb 2014
    Description :   TownshipInRouteDA
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
    public class TownshipInRouteDA
    {

        #region SelectAll

        public static DataTable SelectTownshipInRouteByTownshipID(int TownshipID)
        {
            DataTable table = null;
            string tableName = "TownshipInRouteTable";
            try
            {               
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM TownshipInRoute WHERE TownshipID = @p_TownshipID AND IsDeleted =0";

                command.Parameters.AddWithValue("@p_TownshipID", TownshipID);
                command.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return table;
        }

        public static DataTable SelectAll()
        {
            DataTable table = null;
            string tableName = "TownshipInRouteTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_TownshipInRouteSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return table;
        }

        public static DataTable GetDataByRouteId(int routeId)
        {
            DataTable dt = null;
            try
            {
                dt = new DataTable("TownshipInRouteTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM TownshipInRoute WHERE RouteId = @routeId AND IsDeleted =0";

                command.Parameters.AddWithValue("@routeId", routeId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (SqlException sqle)
            {
            }
            return dt;
        }

        #endregion

        #region INSERT
        public static int Insert(TownshipInRoute townshipinroute)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TownshipInRouteInsert";

                cmd.Parameters.AddWithValue("@p_RouteID", townshipinroute.RouteID);
                cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownshipID", townshipinroute.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int UpdateByID(TownshipInRoute townshipinroute)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TownshipInRouteUpdateByTownshipInRouteID";

                cmd.Parameters.AddWithValue("@p_TownshipInRouteID", townshipinroute.TownshipInRouteID);
                cmd.Parameters["@p_TownshipInRouteID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RouteID", townshipinroute.RouteID);
                cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownshipID", townshipinroute.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE
        public static int DeleteByID(TownshipInRoute townshipinroute)
        {
            int affectedRow = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TownshipInRouteDeleteByTownshipInRouteID";

                cmd.Parameters.AddWithValue("@p_TownshipInRouteID", townshipinroute.TownshipInRouteID);
                cmd.Parameters["@p_TownshipInRouteID"].Direction = ParameterDirection.Input;

                affectedRow = cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
            return affectedRow;
        }
        #endregion
    }
}

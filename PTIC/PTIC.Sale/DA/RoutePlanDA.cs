using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Common.DA;

namespace PTIC.Sale.DA
{
    public class RoutePlanDA
    {
        internal static DataTable GetAll(SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RoutePlanSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "RoutePlanTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["RoutePlanTable"];
        }
        
        internal static DataTable GetAllView(SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RoutePlanViewSelect";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "RoutePlanView");
            }
            catch (SqlException sqle)
            {
                //
            }
            return dataSet.Tables["RoutePlanView"];
        }

        internal static int Insert(Entities.RoutePlan routeplan, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_RoutePlanInsert";

                cmd.Parameters.AddWithValue("@p_RouteID", routeplan.RouteID);
                cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RoutePlanNo", routeplan.RoutePlanNo);
                cmd.Parameters["@p_RoutePlanNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersonID", routeplan.SalesPersonID);
                cmd.Parameters["@p_RoutePlanNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", routeplan.VenID);
                cmd.Parameters["@p_RoutePlanNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PlanDate", routeplan.PlanDate);
                cmd.Parameters["@p_RoutePlanNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TranDate", routeplan.TranDate);
                cmd.Parameters["@p_TranDate"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        #region DELETE
        /// <summary>
        /// Delete a specific record
        /// </summary>
        /// <param name="routePlanID">By roue plan ID</param>
        /// <returns>Return affected row count</returns>
        internal static int DeleteByID(int routePlanID)
        {
            // Update row as Deleted instead of permanately deletion
            string tableName = "RoutePlan";
            string[] colNames = new string[] { "", "IsDeleted" };
            string[] values = new string[] { "", "True" };
            return new BaseDAO().Update(tableName, routePlanID.ToString(), colNames, values);
        }
        #endregion

        internal static int Update(Entities.RoutePlan routeplan, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_RoutePlanUpdate";

                cmd.Parameters.AddWithValue("@p_RPlanID", routeplan.ID);
                cmd.Parameters["@p_RPlanID"].Direction = ParameterDirection.Input;
                
                cmd.Parameters.AddWithValue("@p_RouteID", routeplan.RouteID);
                cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RoutePlanNo", routeplan.RoutePlanNo);
                cmd.Parameters["@p_RoutePlanNo"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalesPersonID", routeplan.SalesPersonID);
                cmd.Parameters["@p_SalesPersonID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_VenID", routeplan.VenID);
                cmd.Parameters["@p_VenID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PlanDate", routeplan.PlanDate);
                cmd.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TranDate", routeplan.TranDate);
                cmd.Parameters["@p_TranDate"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
    }
}

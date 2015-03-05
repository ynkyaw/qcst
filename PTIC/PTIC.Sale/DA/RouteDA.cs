/* Author   :   Aung Ko Ko
    Date      :   22 Feb 2014
    Description :   RouteDA Entity
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Common.DA;
using PTIC.Common;

namespace PTIC.Sale.DA
{
    public class RouteDA
    {
        static BaseDAO b = new BaseDAO();
        #region SelectAll
        public static DataTable SelectRouteWithTownshipID()
        {
            DataTable dt;

            try
            {
                string query = "";
                dt = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return dt;
        }


        public static int SelectRouteIdByRouteName(string routeName)
        {
            int routeId = 0;
            try
            {   
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandText = "SELECT [ID] FROM ROUTE WHERE ROUTENAME=@routeName";
                command.Parameters.AddWithValue("@routeName", routeName);
                object result = command.ExecuteScalar();
                int.TryParse(result==null?"0":result.ToString(), out routeId);
                return routeId;
            }
            catch (Exception err) 
            {
                throw err;
            }
        }

        public static DataTable SelectAll()
        {
            DataTable dtRoute = null;
            try
            {
                dtRoute = new DataTable("RouteTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RouteSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                //adapter.Fill(dataSet, "RouteTable");
                adapter.Fill(dtRoute);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            finally 
            {
                DBManager.GetInstance().GetDbConnection();
            }
            return dtRoute;
        }

        public static DataTable GetTownList()
        {
            DataTable dtRoute = null;
            try
            {
                dtRoute = new DataTable("RouteTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandText = @"SELECT ROW_NUMBER() OVER(ORDER BY ID DESC) AS ROWNUM,r.ID,r.RouteName,
		                                      Township =STUFF((SELECT ',' +Township as [text()]
						                                        FROM Township t,TownshipInRoute tr
						                                        where t.ID=tr.TownshipID
						                                        and tr.routeId = r.ID
                                                                Order by t.Township
						                                        FOR XML PATH('')),1,1,''),r.Remark
                                                                From Route r ";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                //adapter.Fill(dataSet, "RouteTable");
                adapter.Fill(dtRoute);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            finally
            {
                DBManager.GetInstance().GetDbConnection();
            }
            return dtRoute;
        }


        public static DataTable GetDataByRouteId(int routeId)
        {
            DataTable dtRoute = null;
            try
            {
                dtRoute = new DataTable("RouteTable");
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandText = "SELECT * FROM ROUTE WHERE id=@routeId";
                command.Parameters.AddWithValue("@routeId", routeId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dtRoute);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            finally
            {
                DBManager.GetInstance().GetDbConnection();
            }
            return dtRoute;
        }

        #endregion

        #region INSERT
        public static int Insert(Route route, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_RouteInsert";

                cmd.Parameters.AddWithValue("@p_RouteName", route.RouteName);
                cmd.Parameters["@p_RouteName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", route.Remark);
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
        public static int UpdateByID(Route route, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_RouteUpdateByRouteID";

                cmd.Parameters.AddWithValue("@p_RouteID", route.RouteID);
                cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RouteName", route.RouteName);
                cmd.Parameters["@p_RouteName"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", route.Remark);
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
        public static int DeleteByID(Route route, SqlConnection conn)
        {
            int affectedRow = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_RouteDeleteByRouteID";

                cmd.Parameters.AddWithValue("@p_RouteID", route.RouteID);
                cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                affectedRow = cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 547)
                {
                    throw new Exception("လမ်းကြောင်းတွင်ပါဝင်မည့်မြို့နယ်များသတ်မှတ်ပြီးဖြစ်သည်။ မြို့နယ်များသတ်မှတ်ထား၍ သိုမဟုတ် Plan များတွင် အသုံးပြုထား၍ဖျက်မရပါ။");
                }
            }
            return affectedRow;
        }
        #endregion


    }
}

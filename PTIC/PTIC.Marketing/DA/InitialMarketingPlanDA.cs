using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class InitialMarketingPlanDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECTALL IntialMarketingPlan
             public static DataTable SelectByDateRange(DateTime FromDate, DateTime ToDate)
        {
            DataTable dtIntialMarketingPlan;
            SqlConnection conn = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                dtIntialMarketingPlan = new DataTable("InitialMarketingPlan");
                conn = DBManager.GetInstance().GetDbConnection();
                cmd.Connection = conn;
                

                string query = String.Format("SELECT * FROM uv_InitialMarketingPlan WHERE "
                                         +"InitialPlanDate BETWEEN @p_FromDate AND @p_ToDate");

                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@p_FromDate", FromDate);
                cmd.Parameters.AddWithValue("@p_ToDate", ToDate);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtIntialMarketingPlan);
            }
            catch ( Exception ex)
            {                
                throw ex;
            }
            return dtIntialMarketingPlan;
        }

        public static DataTable SelectInitialMarketingPlanByInitialMarketingPlanID(int InititalMarketingPlanID,int CustomerID)
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM uv_InitialMarketingPlanByRoute WHERE InitialMarketingPlanID = {0} AND CustomerID ={1}";
                dt = b.SelectByQuery(String.Format(query, InititalMarketingPlanID,CustomerID));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public static DataTable SelectCustomersByRouteID(int RouteID)
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM uv_Customers WHERE RouteID = {0}";
                dt = b.SelectByQuery(String.Format(query, RouteID));
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return dt;
        }


        public static DataTable SelectCustomersByRouteIDAndCustomerID(int RouteID,int CustomerID)
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM uv_Customers WHERE RouteID = {0} AND CustomerID ={1}";
                dt = b.SelectByQuery(String.Format(query, RouteID,CustomerID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static int Insert(InitialMarketingPlan initialMarketingPlan)
        {
            int affectedrow = 0;
            SqlConnection conn = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO [InitialMarketingPlan] ([InitialPlanDate],[Day],[RouteID],[Remark])"
                                    +"VALUES (@p_InitialPlanDate,@p_Day,@p_RouteID,@p_Remark)";
                               
                cmd.Parameters.AddWithValue("@p_InitialPlanDate", initialMarketingPlan.InitialPlanDate);
                cmd.Parameters["@p_InitialPlanDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Day", initialMarketingPlan.Day);
                cmd.Parameters["@p_Day"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RouteID", initialMarketingPlan.RouteID);
                cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", initialMarketingPlan.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                affectedrow = cmd.ExecuteNonQuery();
                //lastInsertId = b.InsertInto("InitialMarketingPlan", b.ConvertColName(initialMarketingPlan), b.ConvertValueList(initialMarketingPlan));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return affectedrow;
        }
        #endregion

        #region Update
        public static int Update(InitialMarketingPlan initialMarketingPlan)
        {
            int affectedrow = 0;
            SqlConnection conn = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE [InitialMarketingPlan] SET [InitialPlanDate] = @p_InitialPlanDate,[Day] = @p_Day,[RouteID] = @p_RouteID,[Remark] = @p_Remark,[LastModified] = @p_LastModifiedDate"   
                                    +" WHERE ID = @p_ID";

                cmd.Parameters.AddWithValue("@p_ID", initialMarketingPlan.ID);
                cmd.Parameters["@p_ID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_InitialPlanDate", initialMarketingPlan.InitialPlanDate);
                cmd.Parameters["@p_InitialPlanDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Day", initialMarketingPlan.Day);
                cmd.Parameters["@p_Day"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_RouteID", initialMarketingPlan.RouteID);
                cmd.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", initialMarketingPlan.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_LastModifiedDate", DateTime.Now);
                cmd.Parameters["@p_LastModifiedDate"].Direction = ParameterDirection.Input;

                affectedrow = cmd.ExecuteNonQuery();
                //lastInsertId = b.InsertInto("InitialMarketingPlan", b.ConvertColName(initialMarketingPlan), b.ConvertValueList(initialMarketingPlan));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return affectedrow;
        }
        #endregion
    }
}

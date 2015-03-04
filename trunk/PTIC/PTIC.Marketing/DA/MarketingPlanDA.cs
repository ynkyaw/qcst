/*
 * Author:  AUNGKOKO <aungkoko@asiagreenleaf.com>
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: MobileServicePlanDA data access class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Common.DA;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    /// <summary>
    /// MarketingPlan data access
    /// </summary>
    public class MarketingPlanDA
    {
        private static BaseDAO _dataAccess = new BaseDAO();

        #region SELECT
        public static DataTable SelectDailyMarketingLogByPlannedDateRange(DateTime startDate, DateTime endDate)
        {
            //string queryString = string.Format("SELECT * FROM uv_DailyMarketingLog WHERE PlanDate BETWEEN '{0}' AND '{1}'",
            //    startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
            //return _dataAccess.SelectByQuery(queryString);

            DataTable table = null;
            string tableName = "DailyMarketingLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_DailyMarketingLogSelectBy";

                command.Parameters.AddWithValue("@p_startDate", startDate);
                command.Parameters["@p_startDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_endDate", endDate);
                command.Parameters["@p_endDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return table;
        }

        public static DataTable SelectDailyMarketingLogByMarketedDateRange(DateTime startDate, DateTime endDate)
        {            
            DataTable table = null;
            string tableName = "DailyMarketingLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_DailyMarketingLogSelectByMarketedDate";

                command.Parameters.AddWithValue("@p_startDate", startDate);
                command.Parameters["@p_startDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_endDate", endDate);
                command.Parameters["@p_endDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return table;
        }

        public static DataTable SelectDailyMarketingLogByDateRangeAndRouteID(DateTime startDate, DateTime endDate, int routeID)
        {
            string queryString = string.Format("SELECT * FROM uv_DailyMarketingLog WHERE PlanDate BETWEEN '{0}' AND '{1}' AND RouteID = {2}",                
                startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), routeID);            
            return _dataAccess.SelectByQuery(queryString);
        }

        public static DataTable SelectDailyMarketingLogByInitialMarketingPlanID(int InitialMarketingPlanID)
        {
            //string queryString = string.Format("SELECT * FROM uv_DailyMarketingLog WHERE InitialMarketingPlanID = {0}", InitialMarketingPlanID);
            //return _dataAccess.SelectByQuery(queryString);
            DataTable table = null;
            string tableName = "DailyMarketingLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_DailyMarketingLogSelectByInitialMarketingPlanID";

                command.Parameters.AddWithValue("@p_InitialMarketingPlanID", InitialMarketingPlanID);
                command.Parameters["@p_InitialMarketingPlanID"].Direction = ParameterDirection.Input;              

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return table;
        }

        public static DataTable SelectUnconfirmedTelemarketingPlan()
        {
            return SelectMarketingPlanBy(Common.Enum.FormStatus.Reported, Common.Enum.MarketingType.Telemarketing);
        }

       
        public static DataTable SelectMarketingPlanBy(
            Common.Enum.FormStatus fromStatus, Common.Enum.MarketingType marketingType)
        {
            DataTable table = null;
            string tableName = "MarketingPlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MarketingPlanSelectBy";

                cmd.Parameters.AddWithValue("@p_MarketingType", marketingType);
                cmd.Parameters["@p_MarketingType"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", (int)fromStatus);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }


        public static DataTable SelectMarketingPlanWithoutDetailBy(
            Common.Enum.FormStatus fromStatus, Common.Enum.MarketingType marketingType,DateTime StartDate,DateTime EndDate)
        {
            DataTable table = null;
            string tableName = "MarketingPlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MarketingPlanWithoutDetailSelectBy";

                cmd.Parameters.AddWithValue("@p_MarketingType", marketingType);
                cmd.Parameters["@p_MarketingType"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", (int)fromStatus);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_startDate", StartDate);
                cmd.Parameters["@p_startDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_endDate", EndDate);
                cmd.Parameters["@p_endDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        /*
        public static DataTable SelectMarketingLogs(SqlConnection conn)
        {

            DataTable table = null;
            string tableName = "MarketingLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_MarketingLogSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
         */
        #endregion

        #region SELECT CusName
        public static DataTable SelectCusName(CustomerName cusname,SqlConnection conn)
        {
            DataTable table = null;
            string tableName = "CusNameTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_CusNameSelectByTownshipandCusType";

                command.Parameters.AddWithValue("@p_TownshipID", cusname.TownshipID);
                command.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_CusType", cusname.CusType);
                command.Parameters["@p_CusType"].Direction = ParameterDirection.Input;

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

        #region SELECT MarketingPlan
        public static DataTable SelectMarketingPlan(int marketingtype,SqlConnection conn)
        {
            DataTable table = null;
            string tableName = "MarketingPlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_DailyMarketingPlanSelectAll";

                command.Parameters.AddWithValue("@p_MarketingType", marketingtype);
                command.Parameters["@p_MarketingType"].Direction = ParameterDirection.Input;

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

        #region SELECT TelmarketingLog
        public static DataTable SelectTelemarketingLogByInitialTeleMarketingPlan(int InitialTeleMarketingPlan)
        {
            DataTable table = null;
            string tableName = "TelemarketingLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "usp_TeleMarketingLogSelectByInitialTeleMarketingPlan";

                command.Parameters.AddWithValue("@p_InitialTeleMarketingPlan", InitialTeleMarketingPlan);
                command.Parameters["@p_InitialTeleMarketingPlan"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }


        public static DataTable SelectTelemarketingLogBy(DateTime startDate, DateTime endDate)
        {
            DataTable table = null;
            string tableName = "TelemarketingLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "usp_TeleMarketingLogSelectBy";

                command.Parameters.AddWithValue("@p_startDate", startDate);
                command.Parameters["@p_startDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_endDate", endDate);
                command.Parameters["@p_endDate"].Direction = ParameterDirection.Input;
                
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

        #region INSERT INTO DailyMarketingPlan
        public static int InsertMarketingPlan(MarketingPlan marketingplan, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            try
            {
               // transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_DailyMarketingPlanInsert";

                cmd.Parameters.AddWithValue("@p_CusID", marketingplan.CustomerID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                //cmd.Parameters.AddWithValue("@p_EmpID", marketingplan.EmpID);
                //cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PlanDate", marketingplan.PlanDate);
                cmd.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;
                
                cmd.Parameters.AddWithValue("@p_MarketingType", marketingplan.MarketingType);
                cmd.Parameters["@p_MarketingType"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@P_InitialMarketingPlan", marketingplan.InitialMarketingPlanID);
                cmd.Parameters["@P_InitialMarketingPlan"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", marketingplan.Status);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();

                //object insertedIDObj = cmd.ExecuteScalar();
                //if (insertedIDObj.GetType() == typeof(DBNull))
                //    return 0;

                //int insertedMarketingPlanID = (int)insertedIDObj;
                //// clear parameters of usp_MarketingInsert
                //cmd.Parameters.Clear();
                //// Insert Marketing Log
                //cmd.CommandText = "usp_MarketingLogInsert";

                //cmd.Parameters.AddWithValue("@p_MarketingPlanID", insertedMarketingPlanID);
                //cmd.Parameters["@p_MarketingPlanID"].Direction = ParameterDirection.Input;
                              
                //affectedRows = cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();
                //// commit transaction
                //transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    //transaction.Rollback();
                    affectedRows = 0;
                }
            }
            finally
            {
                //transaction.Dispose();
                cmd.Dispose();
            }
            return affectedRows;
        }
        #endregion

        #region INSERT INTO TeleMarketingPlan
        public static int InsertTeleMarketingPlan(MarketingPlan marketingplan, SqlConnection conn)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            try
            {
                // transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_TeleMarketingPlanInsert";

                cmd.Parameters.AddWithValue("@p_CusID", marketingplan.CustomerID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;
                                
                cmd.Parameters.AddWithValue("@p_PlanDate", marketingplan.PlanDate);
                cmd.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketingType", marketingplan.MarketingType);
                cmd.Parameters["@p_MarketingType"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", marketingplan.Status);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();

                //object insertedIDObj = cmd.ExecuteScalar();
                //if (insertedIDObj.GetType() == typeof(DBNull))
                //    return 0;

                //int insertedMarketingPlanID = (int)insertedIDObj;
                //// clear parameters of usp_MarketingInsert
                //cmd.Parameters.Clear();
                //// Insert Marketing Log
                //cmd.CommandText = "usp_MarketingLogInsert";

                //cmd.Parameters.AddWithValue("@p_MarketingPlanID", insertedMarketingPlanID);
                //cmd.Parameters["@p_MarketingPlanID"].Direction = ParameterDirection.Input;

                //affectedRows = cmd.ExecuteNonQuery();
                //cmd.Parameters.Clear();
                //// commit transaction
                //transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    //transaction.Rollback();
                    affectedRows = 0;
                }
            }
            finally
            {
                //transaction.Dispose();
                cmd.Dispose();
            }
            return affectedRows;
        }
        #endregion

        #region UPDATE DailyMarketingPlan
        public static int UpdateByID(MarketingPlan marketingplan, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DailyMarketingPlanUpdateByDailyMarketingPlanID";

                cmd.Parameters.AddWithValue("@p_MarketinPlanID", marketingplan.ID);
                cmd.Parameters["@p_MarketinPlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", marketingplan.CustomerID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EmpID", marketingplan.EmpID);
                cmd.Parameters["@p_EmpID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PlanDate", marketingplan.PlanDate);
                cmd.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketingType", marketingplan.MarketingType);
                cmd.Parameters["@p_MarketingType"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", marketingplan.Status);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE TeleMarketingMarketingPlan
        public static int UpdateTeleMarketingByID(MarketingPlan marketingplan, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_TeleMarketingPlanUpdateByDailyMarketingPlanID";

                cmd.Parameters.AddWithValue("@p_MarketinPlanID", marketingplan.ID);
                cmd.Parameters["@p_MarketinPlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", marketingplan.CustomerID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;
                
                cmd.Parameters.AddWithValue("@p_PlanDate", marketingplan.PlanDate);
                cmd.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketingType", marketingplan.MarketingType);
                cmd.Parameters["@p_MarketingType"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", marketingplan.Status);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        private static void UpdateTelemarketingPlan_FormStatus(List<MarketingPlan> telePlans, PTIC.Common.Enum.FormStatus status)
        {
            try
            {
                string cmdUpdate = string.Empty; 
                if(status == Common.Enum.FormStatus.Confirmed)
                    cmdUpdate = "UPDATE [MarketingPlan] SET"
                                               + " [PlanDate] = @p_PlanDate"
                                               + " ,[Status] = @p_Status"
                                             + " WHERE [ID] = @p_ID";
                else
                    cmdUpdate = "UPDATE [MarketingPlan] SET"                                               
                                               + " [Status] = @p_Status"
                                             + " WHERE [ID] = @p_ID";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdUpdate;

                foreach(MarketingPlan telePlan in telePlans)
                {
                    if (status == Common.Enum.FormStatus.Confirmed)
                    {
                        cmd.Parameters.AddWithValue("@p_PlanDate", telePlan.PlanDate);
                        cmd.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;
                    }
                    cmd.Parameters.AddWithValue("@p_Status", (int)status);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.AddWithValue("@p_ID", telePlan.ID);
                    cmd.Parameters["@p_ID"].Direction = ParameterDirection.Input;

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }                
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
        }

        public static void UpdateTelemarketingPlanAsConfirmed(List<MarketingPlan> telePlans)
        {
            UpdateTelemarketingPlan_FormStatus(telePlans, Common.Enum.FormStatus.Confirmed);
        }

        public static void UpdateTelemarketingPlanAsRejected(List<MarketingPlan> telePlans)
        {
            UpdateTelemarketingPlan_FormStatus(telePlans, Common.Enum.FormStatus.Rejected);
        }
        #endregion

        #region DELETE
        public static int DeleteByID(MarketingPlan marketingplan, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DailyMarketingPlanDeleteByMarketingPlanID";

                cmd.Parameters.AddWithValue("@p_MarketingPlanID", marketingplan.ID);
                cmd.Parameters["@p_MarketingPlanID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region SEARCH
        public static DataTable SearchByID(DateTime startdate, DateTime enddate, int marketingtype)
        {
            DataTable table = null;
            string tableName = "DailyMarketingPlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection(); ;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DailyMarketingPlanSearchByPlanDate";

                cmd.Parameters.AddWithValue("@p_StartDate", startdate);
                cmd.Parameters["@p_StartDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EndDate", enddate);
                cmd.Parameters["@p_EndDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MarketingType", marketingtype);
                cmd.Parameters["@p_MarketingType"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            finally 
            {
                DBManager.GetInstance().CloseDbConnection();
            }
            return table;
        }        
        #endregion
    }
}

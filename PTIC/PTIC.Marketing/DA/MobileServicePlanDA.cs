/*
 * Author:  AUNGKOKO <aungkoko@asiagreenleaf.com>
 *              Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: MobileServicePlanDA data access class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class MobileServicePlanDA
    {
        #region SELECT
        public static DataTable SelectMobileServicePlan()
        {
            DataTable table = null;
            string tableName = "MoblieServicePlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_MobileServicePlanSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        private static DataTable SelectMobileServicePlanBy(PTIC.Common.Enum.FormStatus formStatus)
        {
            DataTable table = null;
            string tableName = "MoblieServicePlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "usp_MobileServicePlanSelectBy";

                command.Parameters.AddWithValue("@p_Status", (int)formStatus);
                command.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable SelectReportedMobileServicePlan()
        {
            return SelectMobileServicePlanBy(Common.Enum.FormStatus.Reported);
        }

        public static DataTable SelectMobileServiceLogsByInitialMobileServicePlanID(int InitialMobileServicePlanID)
        {
            DataTable table = null;
            string tableName = "MobileServiceLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_MobileServiceLogSelectByInitialMobileServiePlanID";

                command.Parameters.AddWithValue("@p_InitialMobileServicePlanID", InitialMobileServicePlanID);
                command.Parameters["@p_InitialMobileServicePlanID"].Direction = ParameterDirection.Input;
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                throw sqle;
            }
            return table;
        }

        public static DataTable SelectMobileServiceLogsBy(DateTime startDate, DateTime endDate)
        {
            DataTable table = null;
            string tableName = "MobileServiceLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_MobileServiceLogSelectBy";

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

        public static DataTable SelectMobileServiceLogsByServiceDate(DateTime startDate, DateTime endDate)
        {
            DataTable table = null;
            string tableName = "MobileServiceLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_MobileServiceLogSelectByServiceDate";

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

        public static DataTable SelectMobileServiceLogsWithoutDetailsBy(DateTime startDate, DateTime endDate)
        {
            DataTable table = null;
            string tableName = "MobileServiceLogTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_MobileServiceLogWithoutDetailsSelectBy";

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
        #endregion

        #region INSERT INTO MobileServicePlan
        public static int? InsertMobileServicePlan(List<MobileServicePlan> mobileserviceplan)
        {
            SqlTransaction transaction = null;
            int affectedrow = 0;
            SqlCommand cmd = null;
             try
            {
                // transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.CommandText = "usp_MobileServicePlanInsert";

                foreach (MobileServicePlan newmobileserviceplan in mobileserviceplan)
                {
                    cmd.Parameters.AddWithValue("@p_CusID", newmobileserviceplan.CustomerID);
                    cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownshipID", newmobileserviceplan.TownshipID);
                    cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_SvcPlanNo", mobileserviceplan.SvcPlanNo);
                    //cmd.Parameters["@p_SvcPlanNo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SvcPlanDate", newmobileserviceplan.SvcPlanDate);
                    cmd.Parameters["@p_SvcPlanDate"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_InitialMobileServicePlanID", newmobileserviceplan.InitialMobileServicePlanID);
                    cmd.Parameters["@p_InitialMobileServicePlanID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Status", newmobileserviceplan.Status);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    affectedrow +=  cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                return affectedrow;
            }
            catch (SqlException sqle)
            {
                return null;               
            }
         }
        #endregion

        #region UPDATE MobileServicePlan
        public static int? UpdateMobileServicePlanByID(List<MobileServicePlan> mobileserviceplan)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();
                int affectedrow = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MobileServicePlanUpdateByID";

                foreach (MobileServicePlan newmobileserviceplan in mobileserviceplan)
                {

                    cmd.Parameters.AddWithValue("@p_MobileServicePlanID", newmobileserviceplan.ID);
                    cmd.Parameters["@p_MobileServicePlanID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownshipID", newmobileserviceplan.TownshipID);
                    cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_CusID", newmobileserviceplan.CustomerID);
                    cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_SvcPlanNo", mobileserviceplan.SvcPlanNo);
                    //cmd.Parameters["@p_SvcPlanNo"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SvcPlanDate", newmobileserviceplan.SvcPlanDate);
                    cmd.Parameters["@p_SvcPlanDate"].Direction = ParameterDirection.Input;

                    affectedrow+=cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
               return affectedrow;
            }
            catch (SqlException sqle)
            {
                return null;
            }
        }

        private static void UpdateMobileServicePlan_FormStatus(
            List<MobileServicePlan> mobileServicePlans, PTIC.Common.Enum.FormStatus status)
        {
            try
            {
                string cmdUpdate = string.Empty;
                if (status == Common.Enum.FormStatus.Confirmed)
                    cmdUpdate = "UPDATE [MobileServicePlan] SET"
                                           + " [SvcPlanDate] = @p_SvcPlanDate"
                                           + " ,[Status] = @p_Status"
                                         + " WHERE [ID] = @p_ID";
                else
                    cmdUpdate = "UPDATE [MobileServicePlan] SET"                                           
                                           + " [Status] = @p_Status"
                                         + " WHERE [ID] = @p_ID";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdUpdate;

                foreach (MobileServicePlan plan in mobileServicePlans)
                {
                    if (status == Common.Enum.FormStatus.Confirmed)
                    {
                        cmd.Parameters.AddWithValue("@p_SvcPlanDate", plan.SvcPlanDate);
                        cmd.Parameters["@p_SvcPlanDate"].Direction = ParameterDirection.Input;
                    }
                    cmd.Parameters.AddWithValue("@p_Status", (int)status);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ID", plan.ID);
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

        public static void UpdateMobileServicePlanAsConfirmed(List<MobileServicePlan> mobileServicePlans)
        {
            UpdateMobileServicePlan_FormStatus(mobileServicePlans, Common.Enum.FormStatus.Confirmed);
        }

        public static void UpdateMobileServicePlanAsRejected(List<MobileServicePlan> mobileServicePlans)
        {
            UpdateMobileServicePlan_FormStatus(mobileServicePlans, Common.Enum.FormStatus.Rejected);
        }
        #endregion

        #region DELETE
        public static int DeleteByID(MobileServicePlan mobileserviceplan)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection conn = DBManager.GetInstance().GetDbConnection();
                cmd.Connection = conn;
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MobileServicePlanDeleteByID";

                cmd.Parameters.AddWithValue("@p_MobileServiePlanID", mobileserviceplan.ID);
                cmd.Parameters["@p_MobileServiePlanID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region SEARCH
        public static DataTable SearchByID(DateTime startdate, DateTime enddate)
        {
            DataTable table = null;
            string tableName = "MobileServicePlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_MobileServicePlanSearchByPlanDate";

                cmd.Parameters.AddWithValue("@p_StartDate", startdate);
                cmd.Parameters["@p_StartDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_EndDate", enddate);
                cmd.Parameters["@p_EndDate"].Direction = ParameterDirection.Input;

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

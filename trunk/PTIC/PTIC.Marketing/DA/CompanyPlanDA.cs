/*
 * Author:  AUNGKOKO <aungkoko@asiagreenleaf.com>
 *              Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: CompanyPlanDA data access class
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
    public class CompanyPlanDA
    {
        #region SELECT
        public static DataTable SelectCompanyPlanUnConfirmedList()
        {
            DataTable table = null;
            string tableName = "CompanyPlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                //command.CommandType = CommandType.StoredProcedure;
                command.CommandText = " SELECT [CompanyPlan].[ID],[CompanyPlanNo],[TargetedDate],[TownshipId],[CustomerId]";
                command.CommandText += " ,[Status],[CreatedDate],[LastModifedDate],cp.ConPersonName ,cp.MobilePhone";
                command.CommandText += " FROM [PTIC_Ver_1_0_7_To_Deliver].[dbo].[CompanyPlan] Inner Join ContactPerson cp";
                command.CommandText += " ON (CompanyPlan.CustomerId = cp.CusID)";
                command.CommandText += " where CompanyPlan.IsDeleted = 0 and cp.IsDeleted=0 and [IsConfirmed]=0";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        private static DataTable SelectCompanyPlanBy(PTIC.Common.Enum.FormStatus formStatus)
        {
            DataTable table = null;
            string tableName = "MoblieServicePlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "usp_CompanyPlanSelectBy";

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

        public static DataTable SelectReportedCompanyPlan()
        {
            return SelectCompanyPlanBy(Common.Enum.FormStatus.Reported);
        }

        public static DataTable SelectMobileServiceLogsByInitialCompanyPlanID(int InitialCompanyPlanID)
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

                command.Parameters.AddWithValue("@p_InitialCompanyPlanID", InitialCompanyPlanID);
                command.Parameters["@p_InitialCompanyPlanID"].Direction = ParameterDirection.Input;

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

        #region INSERT INTO CompanyPlan
        public static int? InsertCompanyPlan(List<CompanyPlan> CompanyPlan)
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
                cmd.CommandText = "usp_CompanyPlanInsert";

                foreach (CompanyPlan newCompanyPlan in CompanyPlan)
                {
                    cmd.Parameters.AddWithValue("@p_CusID", newCompanyPlan.CustomerID);
                    cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownshipID", newCompanyPlan.TownshipID);
                    cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_SvcPlanNo", CompanyPlan.SvcPlanNo);
                    //cmd.Parameters["@p_SvcPlanNo"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_SvcPlanDate", newCompanyPlan.SvcPlanDate);
                    //cmd.Parameters["@p_SvcPlanDate"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_InitialCompanyPlanID", newCompanyPlan.InitialCompanyPlanID);
                    //cmd.Parameters["@p_InitialCompanyPlanID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Status", newCompanyPlan.Status);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    affectedrow += cmd.ExecuteNonQuery();
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

        #region UPDATE CompanyPlan
        public static int? UpdateCompanyPlanByID(List<CompanyPlan> CompanyPlan)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();
                int affectedrow = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompanyPlanUpdateByID";

                foreach (CompanyPlan newCompanyPlan in CompanyPlan)
                {

                    cmd.Parameters.AddWithValue("@p_CompanyPlanID", newCompanyPlan.Id);
                    cmd.Parameters["@p_CompanyPlanID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TownshipID", newCompanyPlan.TownshipID);
                    cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_CusID", newCompanyPlan.CustomerID);
                    cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_SvcPlanNo", CompanyPlan.SvcPlanNo);
                    //cmd.Parameters["@p_SvcPlanNo"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_SvcPlanDate", newCompanyPlan.SvcPlanDate);
                    //cmd.Parameters["@p_SvcPlanDate"].Direction = ParameterDirection.Input;

                    affectedrow += cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                return affectedrow;
            }
            catch (SqlException sqle)
            {
                return null;
            }
        }

        private static void UpdateCompanyPlan_FormStatus(
            List<CompanyPlan> CompanyPlans, PTIC.Common.Enum.FormStatus status)
        {
            try
            {
                string cmdUpdate = string.Empty;
                if (status == Common.Enum.FormStatus.Confirmed)
                    cmdUpdate = "UPDATE [CompanyPlan] SET"
                                           + " [SvcPlanDate] = @p_SvcPlanDate"
                                           + " ,[Status] = @p_Status"
                                         + " WHERE [ID] = @p_ID";
                else
                    cmdUpdate = "UPDATE [CompanyPlan] SET"
                                           + " [Status] = @p_Status"
                                         + " WHERE [ID] = @p_ID";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdUpdate;

                foreach (CompanyPlan plan in CompanyPlans)
                {
                    if (status == Common.Enum.FormStatus.Confirmed)
                    {
                        //cmd.Parameters.AddWithValue("@p_SvcPlanDate", plan.SvcPlanDate);
                        cmd.Parameters["@p_SvcPlanDate"].Direction = ParameterDirection.Input;
                    }
                    cmd.Parameters.AddWithValue("@p_Status", (int)status);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ID", plan.Id);
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

        public static void UpdateCompanyPlanAsConfirmed(List<CompanyPlan> CompanyPlans)
        {
            UpdateCompanyPlan_FormStatus(CompanyPlans, Common.Enum.FormStatus.Confirmed);
        }

        public static void UpdateCompanyPlanAsRejected(List<CompanyPlan> CompanyPlans)
        {
            UpdateCompanyPlan_FormStatus(CompanyPlans, Common.Enum.FormStatus.Rejected);
        }
        #endregion

        #region DELETE
        public static int DeleteByID(CompanyPlan CompanyPlan)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection conn = DBManager.GetInstance().GetDbConnection();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompanyPlanDeleteByID";

                cmd.Parameters.AddWithValue("@p_MobileServiePlanID", CompanyPlan.Id);
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
            string tableName = "CompanyPlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_CompanyPlanSearchByPlanDate";

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

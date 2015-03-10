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

        public static DataTable SelectCompanyPlanUnConfirmedListByDateRange(DateTime dtStart,DateTime dtEnd)
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
                command.CommandText += " and TargetedDate Between @p_startDate and @p_endDate";
                command.Parameters.AddWithValue("@p_startDate", dtStart);
                command.Parameters.AddWithValue("@p_endDate", dtEnd);

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
            string tableName = "CompanyPlanTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandText = " SELECT [CompanyPlan].[ID],[CompanyPlanNo],[TargetedDate],[TownshipId],[CustomerId],[CusName]";
                command.CommandText += " ,[Status],[CreatedDate],[LastModifedDate],cp.ConPersonName ,cp.MobilePhone,[IsConfirmed]";
                command.CommandText += " FROM [PTIC_Ver_1_0_7_To_Deliver].[dbo].[CompanyPlan] Inner Join ContactPerson cp";
                command.CommandText += " ON (CompanyPlan.CustomerId = cp.CusID) Inner Join Customer cust ON (CompanyPlan.CustomerId=cust.ID)";
                command.CommandText += " where CompanyPlan.IsDeleted = 0 and cp.IsDeleted=0 and [IsConfirmed]=0 AND STATUS=@p_Status";
                command.Parameters.AddWithValue("@p_Status", (int)formStatus);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                command.Parameters.Clear();
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
                
                
                SqlConnection con = DBManager.GetInstance().GetDbConnection();
                cmd = new SqlCommand();

                transaction = con.BeginTransaction("SampleTransaction");
                cmd.Connection = con;
                cmd.Transaction = transaction;
                cmd.CommandText = "INSERT INTO [CompanyPlan]([CompanyPlanNo],[TargetedDate],[TownshipId],[CustomerId],[Status],[IsConfirmed],[CreatedDate],[LastModifedDate],[IsDeleted])";
                cmd.CommandText += " VALUES(@CompanyPlanNo,@TargetedDate,@TownshipId,@CustomerId,@Status,@IsConfirmed,@CreatedDate,@LastModifedDate,@IsDeleted)";

                foreach (CompanyPlan newCompanyPlan in CompanyPlan)
                {
                    cmd.Parameters.AddWithValue("@TownshipId", newCompanyPlan.TownshipID);
                    cmd.Parameters.AddWithValue("@CompanyPlanNo", newCompanyPlan.CompanyPanNo);
                    cmd.Parameters.AddWithValue("@TargetedDate", newCompanyPlan.TargetedDate);
                    cmd.Parameters.AddWithValue("@CustomerId", newCompanyPlan.CustomerID);
                    cmd.Parameters.AddWithValue("@Status", newCompanyPlan.Status);
                    cmd.Parameters.AddWithValue("@IsConfirmed", newCompanyPlan.IsConfirmed);
                    cmd.Parameters.AddWithValue("@CreatedDate", newCompanyPlan.IsConfirmed);
                    cmd.Parameters.AddWithValue("@LastModifedDate", newCompanyPlan.LastModifiedDate);
                    cmd.Parameters.AddWithValue("@IsDeleted", newCompanyPlan.IsDeleted);
                    
                    affectedrow += cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                transaction.Commit();
                return affectedrow;
            }
            catch (SqlException sqle)
            {
                return null;
            }
        }
        #endregion

        #region UPDATE CompanyPlan
        public static int? UpdateCompanyPlanByID(CompanyPlan CompanyPlan)
        {
            int affectedrow = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandText = "UPDATE COMPANYPLAN SET [TargetedDate]=@p_TargetedDate, [TownshipId]=@p_TownshipID,[CustomerId]=@p_CusID WHERE ID=@p_CompanyPlanID";

                cmd.Parameters.AddWithValue("@p_TargetedDate", CompanyPlan.CustomerID);
                cmd.Parameters["@p_TargetedDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CompanyPlanID", CompanyPlan.Id);
                cmd.Parameters["@p_CompanyPlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TownshipID", CompanyPlan.TownshipID);
                cmd.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_CusID", CompanyPlan.CustomerID);
                cmd.Parameters["@p_CusID"].Direction = ParameterDirection.Input;

                affectedrow = cmd.ExecuteNonQuery();
                
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
                                           + " [TargetedDate] = @p_TargetedDate"
                                           + " ,[Status] = @p_Status"
                                           + ",[IsConfirmed]=1"
                                         + " WHERE [ID] = @p_ID";
                else
                    cmdUpdate = "UPDATE [CompanyPlan] SET"
                                           + " [Status] = @p_Status"
                                         + " WHERE [ID] = @p_ID";
                SqlCommand cmd = new SqlCommand();
                SqlConnection conn=DBManager.GetInstance().GetDbConnection();
                SqlTransaction trans = conn.BeginTransaction("CompanyPlanConfirm");
                cmd.Connection = conn;
                cmd.Transaction = trans;
                
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdUpdate;
                int effectedRowsCount = 0;
                foreach (CompanyPlan plan in CompanyPlans)
                {
                    if (status == Common.Enum.FormStatus.Confirmed)
                    {
                        cmd.Parameters.AddWithValue("@p_TargetedDate", plan.TargetedDate);
                        cmd.Parameters["@p_TargetedDate"].Direction = ParameterDirection.Input;
                    }
                    cmd.Parameters.AddWithValue("@p_Status", (int)status);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ID", plan.Id);
                    cmd.Parameters["@p_ID"].Direction = ParameterDirection.Input;

                    
                    effectedRowsCount += cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                trans.Commit();
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
                cmd.CommandText = "DELETE  FROM CompanyPlan WHERE ID = @p_Id";
                cmd.Parameters.AddWithValue("@p_Id", CompanyPlan.Id);
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

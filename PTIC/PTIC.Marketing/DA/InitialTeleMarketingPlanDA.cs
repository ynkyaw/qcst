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
    public class InitialTeleMarketingPlanDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECT
        public static DataTable SelectByDateRange(DateTime FromDate, DateTime ToDate)
        {
            DataTable dtIntialMarketingPlan;
            try
            {
                string query = String.Format("SELECT * FROM uv_TeleMarketingInitialPlan WHERE "
                                         + "CONVERT(DATE,PlanDate,103) BETWEEN CONVERT(DATE,CAST('{0}' as DATE),103) "
                                                + "AND CONVERT(DATE,CAST('{1}' as DATE),103)", FromDate, ToDate);
                dtIntialMarketingPlan = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtIntialMarketingPlan;
        }
        #endregion

        #region INSERT
        public static int Insert(InitialTeleMarketingPlan newInitialTeleMarketingPlan, List<PTIC.Marketing.Entities.MarketingPlan> newMarketingPlan)
        {
            SqlTransaction transaction = null;
            SqlConnection conn = null;
            SqlCommand cmd = null;
            int insertedInitialTeleMarketingPlanID = -1;
            try
            {
                // Start transaction
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();               
                cmd = new SqlCommand();
                cmd.Connection = conn;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                /** Insert master **/
                string queryTeleMarketingPlanInsert =
                    "INSERT INTO TeleMarketingInitialPlan" +
                        " (PlanDate, GroupID, Remark,DateAdded,IsDeleted)" +
                    " OUTPUT inserted.ID" +
                    " VALUES" +
                        " (@p_PlanDate, @p_GroupID,@p_Remark,@p_DateAdded,@p_IsDeleted)";
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = queryTeleMarketingPlanInsert;
                cmd.Parameters.AddWithValue("@p_PlanDate", newInitialTeleMarketingPlan.PlanDate);
                cmd.Parameters.AddWithValue("@p_GroupID", newInitialTeleMarketingPlan.GroupID);
                cmd.Parameters.AddWithValue("@p_Remark", newInitialTeleMarketingPlan.Remark);
                cmd.Parameters.AddWithValue("@p_DateAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@p_IsDeleted",false);
                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return -1;

                insertedInitialTeleMarketingPlanID = (int)insertedIDObj;
                // Clear parameter of usage insert query
                cmd.Parameters.Clear();

                /** Insert detail **/
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dtTeleMarketingPlan = PTIC.Marketing.Entities.MarketingPlan.AsClonedDataTable();
                // Create table-value parameter
                foreach (PTIC.Marketing.Entities.MarketingPlan MarketingPlan in newMarketingPlan)
                {
                    DataRow newRow = dtTeleMarketingPlan.NewRow();
                    newRow["CustomerID"] = MarketingPlan.CustomerID;
                    newRow["PlanDate"] = MarketingPlan.PlanDate;
                    newRow["TeleMarketingInitialPlan"] =insertedInitialTeleMarketingPlanID;
                    newRow["MarketingType"] = MarketingPlan.MarketingType;
                    newRow["Status"] = MarketingPlan.Status;
                    dtTeleMarketingPlan.Rows.Add(newRow);
                }
                cmd.CommandText = "usp_NewTeleMarketingPlanInsert";
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@p_TeleMarketingPlanTable";
                param.SqlDbType = SqlDbType.Structured;
                param.Value = dtTeleMarketingPlan;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                // Commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    insertedInitialTeleMarketingPlanID = -1;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return insertedInitialTeleMarketingPlanID;
        }
        #endregion

        #region DELETE
        public static int Delete(InitialTeleMarketingPlan initialTeleMarketingPlan)
        {
            int TeleMarketinPlanID = 0;
            try
            {
                b.Delete("TeleMarketingInitialPlan", initialTeleMarketingPlan.ID);
                TeleMarketinPlanID = initialTeleMarketingPlan.ID;
            }
            catch (Exception ex)
            {
                return TeleMarketinPlanID = 0;
            }
            return TeleMarketinPlanID;
        }
        #endregion
    }
}

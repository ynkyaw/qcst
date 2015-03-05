using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    public class A_P_PlanDA
    {
        //

        #region SelectAll

        public static DataTable SelectAll(SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_A_P_PlanSelectAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "APPlanTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["APPlanTable"];
        }

        public static DataTable SelectByDate(DateTime A_P_PlanDate)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM A_P_Plan WHERE YEAR(A_P_PlanDate) = YEAR(@p_PlanDate) AND MONTH(A_P_PlanDate) = MONTH(@p_PlanDate) AND IsDeleted = 0";

                command.Parameters.AddWithValue("@p_PlanDate", A_P_PlanDate);
                command.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;
                               
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "APPlanTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["APPlanTable"];
        }

        public static DataTable SelectByDate(DateTime applanDate,int BrandID)
        {

            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_A_P_PlanSelectByMonth";

                command.Parameters.AddWithValue("@p_PlanDate", applanDate);
                command.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_BrandID", BrandID);
                command.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "APPlanTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["APPlanTable"];
        }

        #endregion

        #region INSERT
     
        public static int Insert(A_P_Plan apPlan, List<A_P_PlanDetail> apPlanDetails)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new a & p plan
                cmd.CommandText = "usp_A_P_PlanInsert";

                cmd.Parameters.AddWithValue("@p_PlanDate", apPlan.A_P_PlanDate);
                cmd.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalePlanAmt", apPlan.SalePlanAmt);
                cmd.Parameters["@p_SalePlanAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_status", apPlan.Status);
                cmd.Parameters["@p_status"].Direction = ParameterDirection.Input;
             
                object insertedIDObj = cmd.ExecuteScalar();

                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                int insertedOrderID = (int)insertedIDObj;
                // clear parameters of usp_A_P_PlanInsert
                cmd.Parameters.Clear();
                // insert new order details
                cmd.CommandText = "usp_A_P_PlanDetailInsert";
                foreach (A_P_PlanDetail newApPlanDetails in apPlanDetails)
                {
                    cmd.Parameters.AddWithValue("@p_AP_PlanID", insertedOrderID);
                    cmd.Parameters["@p_AP_PlanID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_BrandID", newApPlanDetails.BrandID);
                    cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_A_P_Material", newApPlanDetails.A_P_MaterialID);
                    cmd.Parameters["@p_A_P_Material"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_usageAmt", newApPlanDetails.UsageAmt);
                    cmd.Parameters["@p_usageAmt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TotalAmtPercent", newApPlanDetails.TotalAmtPercent);
                    cmd.Parameters["@p_TotalAmtPercent"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SalePlanPercent", newApPlanDetails.SalePlanPercent);
                    cmd.Parameters["@p_SalePlanPercent"].Direction = ParameterDirection.Input; 

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_A_P_PlanDetailInsert
                    cmd.Parameters.Clear();
                }
                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    affectedRows = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedRows;
        }

        #endregion

        #region UPDATE
      
        public static int Update(A_P_Plan apPlan, List<A_P_PlanDetail> apPlanDetails)
        {
            SqlConnection conn = null;
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            int affectedRows = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                transaction = conn.BeginTransaction();
                cmd.Transaction = transaction;
                
                // update an existing order 
                cmd.CommandText = "usp_A_P_PlanUpdateByID";

                cmd.Parameters.AddWithValue("@p_AP_PlanID", apPlan.A_P_PlanID);
                cmd.Parameters["@p_AP_PlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PlanDate", apPlan.A_P_PlanDate);
                cmd.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalePlanAmt", apPlan.SalePlanAmt);
                cmd.Parameters["@p_SalePlanAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_status", apPlan.Status);
                cmd.Parameters["@p_status"].Direction = ParameterDirection.Input;

                affectedRows += cmd.ExecuteNonQuery();

                // clear parameters of usp_OrderUpdateByOrderID
                cmd.Parameters.Clear();
                
                // update an existing order details
                cmd.CommandText = "usp_A_P_PlanDetailInsert";
                foreach (A_P_PlanDetail apPlanDetail in apPlanDetails)
                {                    
                    cmd.Parameters.AddWithValue("@p_AP_PlanID", apPlan.A_P_PlanID);
                    cmd.Parameters["@p_AP_PlanID"].Direction = ParameterDirection.Input;
                    
                    cmd.Parameters.AddWithValue("@p_BrandID", apPlanDetail.BrandID);
                    cmd.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_A_P_Material", apPlanDetail.A_P_MaterialID);
                    cmd.Parameters["@p_A_P_Material"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_usageAmt", apPlanDetail.UsageAmt);
                    cmd.Parameters["@p_usageAmt"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_TotalAmtPercent", apPlanDetail.TotalAmtPercent);
                    cmd.Parameters["@p_TotalAmtPercent"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SalePlanPercent", apPlanDetail.SalePlanPercent);
                    cmd.Parameters["@p_SalePlanPercent"].Direction = ParameterDirection.Input; 

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_OrderDetailUpdateByOrderDetailID
                    cmd.Parameters.Clear();
                }
                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    affectedRows = 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedRows;
        }

        /// <summary>
        /// Update an existing order by order ID
        /// </summary>
        /// <param name="apPlan">Order to be updated</param>        
        /// <returns>Return affected row count</returns>
        public static int UpdateByAPPlanID(A_P_Plan apPlan)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_A_P_PlanUpdateByID";

                cmd.Parameters.AddWithValue("@p_AP_PlanID", apPlan.A_P_PlanID);
                cmd.Parameters["@p_AP_PlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_PlanDate", apPlan.A_P_PlanDate);
                cmd.Parameters["@p_PlanDate"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalePlanAmt", apPlan.SalePlanAmt);
                cmd.Parameters["@p_SalePlanAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_status", apPlan.Status);
                cmd.Parameters["@p_status"].Direction = ParameterDirection.Input;         

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }

        #endregion
        
        #region DELETE
        /// <summary>
        /// Delete order from database by order ID
        /// </summary>
        /// <param name="apPlanID">Order ID</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public static int DeleteByAPPlanID(A_P_Plan apPlanID, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_ApPlanDeleteByApPlanID";

                cmd.Parameters.AddWithValue("@p_apPlanID", apPlanID);
                cmd.Parameters["@p_apPlanID"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion
        //

        internal static DataTable GetSummary(SqlConnection conn)
        {
            DataSet dataSet = null;
            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_A_P_PlanSummaryViewGetAll";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "APPlanSummary");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["APPlanSummary"];
        }
    }
}

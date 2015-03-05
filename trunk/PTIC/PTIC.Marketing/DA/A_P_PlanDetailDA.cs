using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using System.Data;
using PTIC.Common;

namespace PTIC.Marketing.DA
{
    class A_P_PlanDetailDA
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
                command.CommandText = "usp_A_P_PlanDetailSelectALL";

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "APPlanDetailTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["APPlanDetailTable"];
        }
        #endregion


        //SelectByAPPanelID

        public static DataTable SelectByAPPanelID(int APPanelID)
        {
            DataSet dataSet = null;

            try
            {
                dataSet = new DataSet();
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_A_P_PlanDetailSelectByPlanID";

                command.Parameters.AddWithValue("@p_AP_PlanID", APPanelID);
                command.Parameters["@p_AP_PlanID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataSet, "APPlanDetailTable");
            }
            catch (SqlException sqle)
            {
            }
            return dataSet.Tables["APPlanDetailTable"];
        }

        #region INSERT
        public static int Insert(A_P_PlanDetail apPlanDetail, SqlConnection conn)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_A_P_PlanDetailInsert";

                cmd.Parameters.AddWithValue("@p_AP_PlanID", apPlanDetail.A_P_PlanID);
                cmd.Parameters["@p_AP_PlanID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_A_P_Material", apPlanDetail.A_P_MaterialID);
                cmd.Parameters["@p_A_P_Material"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_usageAmt", apPlanDetail.UsageAmt);
                cmd.Parameters["@p_usageAmt"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_TotalAmtPercent", apPlanDetail.TotalAmtPercent);
                cmd.Parameters["@p_TotalAmtPercent"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SalePlanPercent", apPlanDetail.SalePlanPercent);
                cmd.Parameters["@p_SalePlanPercent"].Direction = ParameterDirection.Input;

                return cmd.ExecuteNonQuery();
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region UPDATE
        public static int Update(A_P_Plan apPlan,List<A_P_PlanDetail> apPlanDetail)
        {
            int affectedrow = 0;
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

                affectedrow += cmd.ExecuteNonQuery();
                // clear parameters of usp_OrderUpdateByOrderID
                cmd.Parameters.Clear();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_A_P_PlanDetailUpdateByID";

                foreach (A_P_PlanDetail newApPlanDetails in apPlanDetail)
                {
                    cmd.Parameters.AddWithValue("@p_AP_PlanDetailID", newApPlanDetails.A_P_PlanDetailID);
                    cmd.Parameters["@p_AP_PlanDetailID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_AP_PlanID", newApPlanDetails.A_P_PlanID);
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

                    affectedrow += cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                return affectedrow;
            }
            catch (SqlException sqle)
            {
                return 0;
            }
        }
        #endregion

        #region DELETE

         public static int DeleteByapPlanDetailID(int DeleteByapPlanDetailID, SqlConnection conn)
        {
            int affectedRows = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_A_P_PlanDetailDeleteByID";

                cmd.Parameters.AddWithValue("@p_APPlanDetailID", DeleteByapPlanDetailID);
                cmd.Parameters["@p_APPlanDetailID"].Direction = ParameterDirection.Input;

                affectedRows = cmd.ExecuteNonQuery();

            }
            catch (SqlException sqle)
            {
                return 0;
            }
            return affectedRows;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="apPlanDetailID"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int DeleteByapPlanDetailID(List<A_P_PlanDetail> apPlanDetail)
        {
            int affectedRows = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = DBManager.GetInstance().GetDbConnection();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_A_P_PlanDetailDeleteByID";

                foreach (A_P_PlanDetail newApPlanDetails in apPlanDetail)
                {
                    cmd.Parameters.AddWithValue("@p_APPlanDetailID", newApPlanDetails.A_P_PlanDetailID);
                    cmd.Parameters["@p_APPlanDetailID"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                }                
            }
            catch (SqlException sqle)
            {
                return 0;
            }
            return affectedRows;
        }
        #endregion

    }
}

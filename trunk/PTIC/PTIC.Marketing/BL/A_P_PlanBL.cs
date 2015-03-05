using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.BL
{
    public class A_P_PlanBL
    {
        #region INSERT
        //public int Insert(A_P_Plan apPlan, SqlConnection conn)
        //{
        //    return A_P_PlanDA.Insert(apPlan, conn);
        //}
        #endregion

        #region UPDATE
        public int Update(A_P_Plan apPlan)
        {
            return A_P_PlanDA.UpdateByAPPlanID(apPlan);
        }
        #endregion

        #region DELETE
        public int Delete(A_P_Plan apPlan, SqlConnection conn)
        {
            return A_P_PlanDA.DeleteByAPPlanID(apPlan, conn);
        }
        #endregion

        #region SELECT
        /// <summary>
        /// Get all orders from system
        /// </summary>        
        /// <returns>Return datatable containing all orders</returns>
        public DataTable GetAll(SqlConnection conn)
        {
            return A_P_PlanDA.SelectAll(conn);
        }

        public DataTable GetAllAPPlanByDate(DateTime AP_PlanDate)
        {
            return A_P_PlanDA.SelectByDate(AP_PlanDate);
        }

        public DataTable SelectByDate(DateTime applanDate,int BrandID)
        {
            return A_P_PlanDA.SelectByDate(applanDate,BrandID);
        }

        
        //public DataTable GetLost(SqlConnection conn)
        //{
        //    return A_P_PlanDA.SelectLost(conn);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDelivered"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        //public DataTable GetDelivered(SqlConnection conn)
        //{
        //    return A_P_PlanDA.SelectByIsDelivered(true, conn);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        //public DataTable GetUndelivered(SqlConnection conn)
        //{
        //    return A_P_PlanDA.SelectByIsDelivered(false, conn);
        //}

        //public DataTable GetByOrderNo(string orderNo, SqlConnection conn)
        //{
        //    return A_P_PlanDA.SelectByOrderNo(orderNo, conn);
        //}
        #endregion

        #region INSERT
        /// <summary>
        /// Add a new order into system
        /// </summary>
        /// <param name="newAPPlan">New order entity</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        //public int Add(A_P_Plan newAPPlan, SqlConnection conn)
        //{
        //    return A_P_PlanDA.Insert(newAPPlan, conn);
        //}

        public int Add(A_P_Plan newAPPlan, List<A_P_PlanDetail> newAPPlanrDetails)
        {
            return A_P_PlanDA.Insert(newAPPlan, newAPPlanrDetails);
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Update an existing order in system by order ID
        /// </summary>
        /// <param name="mdPlan">Order to be updated</param>        
        /// <returns>Return affected row count</returns>
        public int UpdateByAPPlanID(A_P_Plan apPlan)
        {
            return A_P_PlanDA.UpdateByAPPlanID(apPlan);
        }

        public int Update(A_P_Plan apPlan, List<A_P_PlanDetail> apPlanDetails)
        {
            return A_P_PlanDA.Update(apPlan, apPlanDetails);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Delete order from system by order ID
        /// </summary>
        /// <param name="orderID">Order ID</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int DeleteByAPPlanID(A_P_Plan apPlanID, SqlConnection conn)
        {
            return A_P_PlanDA.DeleteByAPPlanID(apPlanID, conn);
        }
        #endregion

       
        //

        public DataTable GetAllSummary(SqlConnection conn)
        {
            return A_P_PlanDA.GetSummary(conn);
        }
    }
}

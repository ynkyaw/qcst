using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.BL
{
    public class A_P_PlanDetailBL
    {

        #region SELECTALL
        public DataTable GetAll(SqlConnection conn)
        {
            return A_P_PlanDetailDA.SelectAll(conn);
        }
        #endregion

        public DataTable SelectByAPPanelID(int ApPanelID)
        {
            return A_P_PlanDetailDA.SelectByAPPanelID(ApPanelID);
        }

        #region INSERT
        public int Insert(A_P_PlanDetail applanDetail, SqlConnection conn)
        {
            return A_P_PlanDetailDA.Insert(applanDetail, conn);
        }
        #endregion

        #region UPDATE
        public int Update(A_P_Plan apPlan, List<A_P_PlanDetail> applanDetail)
        {
            return A_P_PlanDetailDA.Update(apPlan,applanDetail);
        }
        #endregion

        #region DELETE
        public int Delete( List<A_P_PlanDetail> applanDetail)
        {
            return A_P_PlanDetailDA.DeleteByapPlanDetailID(applanDetail);
        }
        #endregion


        //DeleteByAPPlanDetailID
        #region DELETE
        public int DeleteByAPPlanDetailID(List<A_P_PlanDetail> apPlanDetail)
        {
            return A_P_PlanDetailDA.DeleteByapPlanDetailID(apPlanDetail);
        }

        public int DeleteByAPPlanDetailID(int apPlanDetailID, SqlConnection conn)
        {
            return A_P_PlanDetailDA.DeleteByapPlanDetailID(apPlanDetailID, conn);
        }
        #endregion
        //
    }
}

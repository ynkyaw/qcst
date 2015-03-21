/*
 * Author:  AUNGKOKO <aungkoko@asiagreenleaf.com>
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: CompanyPlanBL data access class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using PTIC.Common.BL;
using AGL.Util;

namespace PTIC.Marketing.BL
{
    public class CompanyPlanBL : BaseBusinessLogic
    {
        #region SELECT
        public DataTable SelectCompanyPlanUnConfirmedList()
        {
            return CompanyPlanDA.SelectCompanyPlanUnConfirmedList();
        }

        public DataTable SelectCompanyPlanUnConfirmedListByDateRange(DateTime startDate,DateTime endDate)
        {
            return CompanyPlanDA.SelectCompanyPlanUnConfirmedListByDateRange(startDate,endDate);
        }

        public DataTable SelectCompanyPlanLog()
        {
            return CompanyPlanDA.SelectCompanyPlanLog();
        }


        public DataTable GetReportedCompanyPlan()
        {
            return CompanyPlanDA.SelectReportedCompanyPlan();
        }

        public CompanyPlanDetail SelectCompanyPlanDetailsById(int CmpDtlId)
        {
            return CompanyPlanDA.SelectCompanyPlanDetailsById(CmpDtlId);
        }

        public DataTable GetMobileServiceLogsWithoutDetailsBy(DateTime startDate, DateTime endDate)
        {
            return CompanyPlanDA.SelectMobileServiceLogsWithoutDetailsBy(startDate, endDate);
        }

        public DataTable GetMobileServiceLogsByInitialCompanyPlanID(int InitialCompanyPlanID)
        {
            return CompanyPlanDA.SelectMobileServiceLogsByInitialCompanyPlanID(InitialCompanyPlanID);
        }
        #endregion

        #region Insert
        public int? Insert(List<CompanyPlan> CompanyPlan)
        {
            try
            {
                
                DataTable dtinitialMarketingPlan = new CompanyPlanBL().SelectCompanyPlanUnConfirmedList();
                foreach (DataRow row in dtinitialMarketingPlan.Rows)
                {
                    foreach (CompanyPlan plan in CompanyPlan)
                    {
                        DateTime dbDate=((DateTime)DataTypeParser.Parse(row["TargetedDate"], typeof(DateTime), DateTime.MinValue)).Date ;
                        if (plan.TargetedDate ==dbDate && plan.CustomerID == (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), null))
                        {
                            base.ValidationResults.AddResult(
                            new ValidationResult("Duplicate Not Allowed!",
                                null, "CompanyPlan", null, null));
                            return null;
                        }
                    }
                }

                return CompanyPlanDA.InsertCompanyPlan(CompanyPlan);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                     new ValidationResult(e.Message,
                     null, "CompanyPlan", null, null));
                return null;
            }
        }
        #endregion

        #region Update
        public int? Update(CompanyPlan CompanyPlan)
        {
            try
            {
                
                return CompanyPlanDA.UpdateCompanyPlanByID(CompanyPlan);

            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                      new ValidationResult(e.Message,
                      null, "CompanyPlan", null, null));
                return null;
            }

        }

        public void ConfirmCompanyPlan(List<CompanyPlan> CompanyPlans)
        {
            CompanyPlanDA.UpdateCompanyPlanAsConfirmed(CompanyPlans);
        }

        public void RejectCompanyPlanAsRejected(List<CompanyPlan> CompanyPlans)
        {
            CompanyPlanDA.UpdateCompanyPlanAsRejected(CompanyPlans);
        }
        #endregion

        #region Delete
        public int Delete(CompanyPlan CompanyPlan, SqlConnection conn)
        {
            return CompanyPlanDA.DeleteByID(CompanyPlan);
        }
        #endregion

        #region 
        public int InsertCompanyPlanDetails(CompanyPlanDetail cmpDtl) 
        {

            return CompanyPlanDA.InsertCompanyPlanDetail(cmpDtl);
        
        }

        public int DeleteCompanyPlanDetails(CompanyPlanDetail cmpDtl)
        {

            return CompanyPlanDA.DeleteCompanyPlanDetail(cmpDtl);

        }


        #endregion


    }
}

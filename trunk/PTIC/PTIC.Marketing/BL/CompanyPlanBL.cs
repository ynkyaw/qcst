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

        public DataTable GetReportedCompanyPlan()
        {
            return CompanyPlanDA.SelectReportedCompanyPlan();
        }

        public DataTable GetMobileServiceLogsBy(DateTime startDate, DateTime endDate)
        {
            return CompanyPlanDA.SelectMobileServiceLogsBy(startDate, endDate);
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
                if (CompanyPlan == null)
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult("Mobile Service Plan အချက်အလက်များ ဖြည့်သွင်းပေးပါ။",
                            null, "CompanyPlan", null, null));
                    return null;
                }
                // InitialMarketingPlan
                Validator<CompanyPlan> initialMarketingValidator = base.ValidationManager.CreateValidator<CompanyPlan>();
                foreach (CompanyPlan plan in CompanyPlan)
                {
                    ValidationResults vInvResults = initialMarketingValidator.Validate(plan);
                    base.ValidationResults = vInvResults;
                    if (!vInvResults.IsValid)
                        return null;
                }


                DataTable dtinitialMarketingPlan = new CompanyPlanBL().GetAll();
                foreach (DataRow row in dtinitialMarketingPlan.Rows)
                {
                    foreach (CompanyPlan plan in CompanyPlan)
                    {
                        if (plan.CreatedDate == ((DateTime)DataTypeParser.Parse(row["SvcPlanDate"], typeof(DateTime), DateTime.MinValue)).Date && plan.CustomerID == (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), null))
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
        public int? Update(List<CompanyPlan> CompanyPlan)
        {
            try
            {
                if (CompanyPlan == null)
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult("Mobile Service Plan အချက်အလက်များ ဖြည့်သွင်းပေးပါ။",
                            null, "CompanyPlan", null, null));
                    return null;
                }
                // InitialMarketingPlan
                Validator<CompanyPlan> initialMarketingValidator = base.ValidationManager.CreateValidator<CompanyPlan>();
                foreach (CompanyPlan plan in CompanyPlan)
                {
                    ValidationResults vInvResults = initialMarketingValidator.Validate(plan);
                    base.ValidationResults = vInvResults;
                    if (!vInvResults.IsValid)
                        return null;
                }

                DataTable dtinitialMarketingPlan = new CompanyPlanBL().GetAll();
                foreach (DataRow row in dtinitialMarketingPlan.Rows)
                {
                    foreach (CompanyPlan plan in CompanyPlan)
                    {
                        if (plan.CreatedDate == (DateTime)DataTypeParser.Parse(row["SvcPlanDate"], typeof(DateTime), DateTime.MinValue) && plan.CustomerID == (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), null))
                        {
                            base.ValidationResults.AddResult(
                            new ValidationResult("Duplicate Not Allowed!",
                                null, "CompanyPlan", null, null));
                            return null;
                        }
                    }
                }

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

    }
}

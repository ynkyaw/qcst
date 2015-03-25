/*
 * Author:  AUNGKOKO <aungkoko@asiagreenleaf.com>
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: MobileServicePlanBL data access class
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
    public class MobileServicePlanBL : BaseBusinessLogic
    {
        #region SELECT
        public DataTable GetAll()
        {
            return MobileServicePlanDA.SelectMobileServicePlan();
        }

        public DataTable GetReportedMobileServicePlan()
        {
            return MobileServicePlanDA.SelectReportedMobileServicePlan();
        }

        public DataTable GetMobileServiceLogsBy(DateTime startDate, DateTime endDate)
        {
            return MobileServicePlanDA.SelectMobileServiceLogsBy(startDate, endDate);
        }

        public DataTable GetMobileServiceLogsByServiceDate(DateTime startDate, DateTime endDate)
        {
            return MobileServicePlanDA.SelectMobileServiceLogsByServiceDate(startDate, endDate);
        }

        public DataTable GetMobileServiceLogsWithoutDetailsBy(DateTime startDate, DateTime endDate)
        {
            return MobileServicePlanDA.SelectMobileServiceLogsWithoutDetailsBy(startDate, endDate);
        }

        public DataTable GetMobileServiceLogsByInitialMobileServicePlanID(int InitialMobileServicePlanID)
        {
            return MobileServicePlanDA.SelectMobileServiceLogsByInitialMobileServicePlanID(InitialMobileServicePlanID);
        }
        #endregion

        #region Insert
        public int? Insert(List<MobileServicePlan> mobileserviceplan)
        {
            try
            {
                if (mobileserviceplan == null)
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult("Mobile Service Plan အချက်အလက်များ ဖြည့်သွင်းပေးပါ။",
                            null, "MobileServicePlan", null, null));
                    return null;
                }
                // InitialMarketingPlan
                Validator<MobileServicePlan> initialMarketingValidator = base.ValidationManager.CreateValidator<MobileServicePlan>();
                foreach (MobileServicePlan plan in mobileserviceplan)
                {
                    ValidationResults vInvResults = initialMarketingValidator.Validate(plan);
                    base.ValidationResults = vInvResults;
                    if (!vInvResults.IsValid)
                        return null;
                }


                DataTable dtinitialMarketingPlan = new MobileServicePlanBL().GetAll();
                foreach (DataRow row in dtinitialMarketingPlan.Rows)
                {
                    foreach (MobileServicePlan plan in mobileserviceplan)
                    {                      
                        if (plan.SvcPlanDate.Date == ((DateTime)DataTypeParser.Parse(row["SvcPlanDate"], typeof(DateTime), DateTime.MinValue)).Date && plan.CustomerID == (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), null))
                        {
                            base.ValidationResults.AddResult(
                            new ValidationResult("Duplicate Not Allowed!",
                                null, "MobileServicePlan", null, null));
                            return null;
                        }
                    }
                }

                return MobileServicePlanDA.InsertMobileServicePlan(mobileserviceplan);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                     new ValidationResult(e.Message,
                     null, "MobileServicePlan", null, null));
                return null;
            }
        }
        #endregion

        #region Update
        public int? Update(List<MobileServicePlan> mobileserviceplan)
        {
            try
            {
                if (mobileserviceplan == null)
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult("Mobile Service Plan အချက်အလက်များ ဖြည့်သွင်းပေးပါ။",
                            null, "MobileServicePlan", null, null));
                    return null;
                }
                // InitialMarketingPlan
                Validator<MobileServicePlan> initialMarketingValidator = base.ValidationManager.CreateValidator<MobileServicePlan>();
                foreach (MobileServicePlan plan in mobileserviceplan)
                {
                    ValidationResults vInvResults = initialMarketingValidator.Validate(plan);
                    base.ValidationResults = vInvResults;
                    if (!vInvResults.IsValid)
                        return null;
                }

                DataTable dtinitialMarketingPlan = new MobileServicePlanBL().GetAll();
                foreach (DataRow row in dtinitialMarketingPlan.Rows)
                {
                    foreach (MobileServicePlan plan in mobileserviceplan)
                    {
                        if (plan.SvcPlanDate == (DateTime)DataTypeParser.Parse(row["SvcPlanDate"], typeof(DateTime), DateTime.MinValue) && plan.CustomerID == (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), null))
                        {
                            base.ValidationResults.AddResult(
                            new ValidationResult("Duplicate Not Allowed!",
                                null, "MobileServicePlan", null, null));
                            return null;
                        }
                    }
                }

                return MobileServicePlanDA.UpdateMobileServicePlanByID(mobileserviceplan);

            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                      new ValidationResult(e.Message,
                      null, "MobileServicePlan", null, null));
                return null;
            }

        }

        public void ConfirmMobileServicePlan(List<MobileServicePlan> mobileServicePlans)
        {
            MobileServicePlanDA.UpdateMobileServicePlanAsConfirmed(mobileServicePlans);
        }

        public void RejectMobileServicePlanAsRejected(List<MobileServicePlan> mobileServicePlans)
        {
            MobileServicePlanDA.UpdateMobileServicePlanAsRejected(mobileServicePlans);
        }
        #endregion

        #region Delete
        public int Delete(MobileServicePlan mobileserviceplan, SqlConnection conn)
        {
            return MobileServicePlanDA.DeleteByID(mobileserviceplan);
        }
        #endregion

    }
}

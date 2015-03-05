using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using PTIC.Common.BL;
using AGL.Util;

namespace PTIC.Marketing.BL
{
    public class InitialTeleMarketingPlanBL : BaseBusinessLogic
    {
        #region SELECT
        public DataTable GetByDateRange(DateTime FromDate, DateTime ToDate)
        {
            return InitialTeleMarketingPlanDA.SelectByDateRange(FromDate, ToDate);
        }
        #endregion

        #region INSERT
        public int? Add(InitialTeleMarketingPlan newInitialTeleMarketingPlan, List<PTIC.Marketing.Entities.MarketingPlan> newMarketingPlan)
        {
            try
            {
                if (newInitialTeleMarketingPlan == null)
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult("TeleMarketingPlan အချက်အလက်များ ဖြည့်သွင်းပေးပါ။",
                            null, "InitialTeleMarketingPlan", null, null));
                    return null;
                }
                // InitialMarketingPlan
                Validator<InitialTeleMarketingPlan> initialMarketingValidator = base.ValidationManager.CreateValidator<InitialTeleMarketingPlan>();
                ValidationResults vInvResults = initialMarketingValidator.Validate(newInitialTeleMarketingPlan);
                base.ValidationResults = vInvResults;
                if (!vInvResults.IsValid)
                    return null;


                DataTable dtinitialMarketingPlan = new InitialTeleMarketingPlanBL().GetByDateRange(newInitialTeleMarketingPlan.PlanDate, newInitialTeleMarketingPlan.PlanDate);
                foreach (DataRow row in dtinitialMarketingPlan.Rows)
                {
                    if (newInitialTeleMarketingPlan.PlanDate == (DateTime)DataTypeParser.Parse(row["PlanDate"], typeof(DateTime), DateTime.MinValue) && newInitialTeleMarketingPlan.GroupID == (int)DataTypeParser.Parse(row["GroupID"], typeof(int), null))
                    {
                        base.ValidationResults.AddResult(
                        new ValidationResult("Duplicate Not Allowed!",
                            null, "InitialTeleMarketingPlan", null, null));
                        return null;
                    }
                }

                return InitialTeleMarketingPlanDA.Insert(newInitialTeleMarketingPlan, newMarketingPlan);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                    null, "InitialTeleMarketingPlan", null, null));
                return null;
            }
            
        }
        #endregion

        #region DELETE
        public int Delete(InitialTeleMarketingPlan initialTeleMarketingPlan)
        {
            return InitialTeleMarketingPlanDA.Delete(initialTeleMarketingPlan);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using AGL.Util;

namespace PTIC.Marketing.BL
{
    public class InitialMarketingPlanBL : BaseBusinessLogic
    {
        #region SELECT
        /// <summary>
        /// GetAllByDateRange
        /// </summary>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        /// <returns></returns>
        public DataTable GetAllByDateRange(DateTime FromDate, DateTime ToDate)
        {
            return InitialMarketingPlanDA.SelectByDateRange(FromDate, ToDate);
        }

        /// <summary>
        /// GetCustomersByRouteID
        /// </summary>
        /// <param name="RouteID"></param>
        /// <returns></returns>
        /// 
        public DataTable GetCustomerByRouteIDAndCustomerID(int RouteID, int CustomerID)
        {
            return InitialMarketingPlanDA.SelectCustomersByRouteIDAndCustomerID(RouteID, CustomerID);
        }

        public DataTable GetCustomerByRouteID(int RouteID)
        {
            return InitialMarketingPlanDA.SelectCustomersByRouteID(RouteID);
        }

        public DataTable GetInitialMarketingPlan(int InitialMarketingPlanID, int CustomerID)
        {
            return InitialMarketingPlanDA.SelectInitialMarketingPlanByInitialMarketingPlanID(InitialMarketingPlanID, CustomerID);
        }
        #endregion

        #region Insert InitialMarketingPlan
        public int? Add(InitialMarketingPlan initialMarketingPlan)
        {
            try
            {
                if (initialMarketingPlan == null)
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult("Daily MarketingPlan အချက်အလက်များ ဖြည့်သွင်းပေးပါ။",
                            null, "InitialMarketingPlan", null, null));
                    return null;
                }
                // InitialMarketingPlan
                Validator<InitialMarketingPlan> initialMarketingValidator = base.ValidationManager.CreateValidator<InitialMarketingPlan>();
                ValidationResults vInvResults = initialMarketingValidator.Validate(initialMarketingPlan);
                base.ValidationResults = vInvResults;
                if (!vInvResults.IsValid)
                    return null;


                DataTable dtinitialMarketingPlan = new InitialMarketingPlanBL().GetAllByDateRange(initialMarketingPlan.InitialPlanDate, initialMarketingPlan.InitialPlanDate);
                foreach (DataRow row in dtinitialMarketingPlan.Rows)
                {
                    if (initialMarketingPlan.Day == (int)DataTypeParser.Parse(row["Day"], typeof(int), null) && initialMarketingPlan.RouteID == (int)DataTypeParser.Parse(row["RouteID"], typeof(int), null))
                    {
                        base.ValidationResults.AddResult(
                        new ValidationResult("Duplicate Not Allowed!",
                            null, "InitialMarketingPlan", null, null));
                        return null;
                    }
                }

                // Save to DB
                return InitialMarketingPlanDA.Insert(initialMarketingPlan);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                    null, "InitialMarketingPlan", null, null));
                return null;
            }

        }
        #endregion

        #region Update
        public int? Update(InitialMarketingPlan initialMarketingPlan)
        {
            try
            {
                if (initialMarketingPlan == null)
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult("Daily MarketingPlan အချက်အလက်များ ဖြည့်သွင်းပေးပါ။",
                            null, "DailyMarketingPlan", null, null));
                    return null;
                }
                // InitailMarketingPlan
                Validator<InitialMarketingPlan> initialMarketingValidator = base.ValidationManager.CreateValidator<InitialMarketingPlan>();
                ValidationResults vInvResults = initialMarketingValidator.Validate(initialMarketingPlan);
                base.ValidationResults = vInvResults;
                if (!vInvResults.IsValid)
                    return null;

                DataTable dtinitialMarketingPlan = new InitialMarketingPlanBL().GetAllByDateRange(initialMarketingPlan.InitialPlanDate, initialMarketingPlan.InitialPlanDate);
                foreach (DataRow row in dtinitialMarketingPlan.Rows)
                {
                    if (initialMarketingPlan.Day == (int)DataTypeParser.Parse(row["Day"], typeof(int), null) && initialMarketingPlan.RouteID == (int)DataTypeParser.Parse(row["RouteID"], typeof(int), null))
                    {
                        base.ValidationResults.AddResult(
                        new ValidationResult("Duplicate Not Allowed!",
                            null, "InitialMarketingPlan", null, null));
                        return null;
                    }
                }


                // Save DB
                return InitialMarketingPlanDA.Update(initialMarketingPlan);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                   new ValidationResult(e.Message,
                   null, "InitialMarketingPlan", null, null));
                return null;
            }

        }
        #endregion

        #region DELETE
        public int Delete(InitialMarketingPlan _InitialMarketingPlan)
        {
            return InitialMarketingPlanDA.Delete(_InitialMarketingPlan);
        }
        #endregion
    }
}

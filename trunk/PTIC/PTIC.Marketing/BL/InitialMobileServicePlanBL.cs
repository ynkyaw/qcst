using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.BL
{
    public class InitialMobileServicePlanBL
    {
        #region SELECT
        public DataTable GetAllByDateRange(DateTime FromDate, DateTime ToDate)
        {
            return InitialMobileServicePlanDA.SelectByDateRange(FromDate, ToDate);
        }

        public DataTable GetInitialMobileServicePlan(int InitialMobileServicePlanID, int CustomerID)
        {
            return InitialMobileServicePlanDA.SelectInitialMobileServicePlanByInitialMobileServicePlanID(InitialMobileServicePlanID, CustomerID);
        }

        public DataTable GetCustomerByRouteID(int RouteID)
        {
            return InitialMobileServicePlanDA.SelectCustomersByRouteID(RouteID);
        }

        public DataTable GetCustomerByRouteIDAndCustomerID(int RouteID, int CustomerID)
        {
            return InitialMobileServicePlanDA.SelectCustomersByRouteIDAndCustomerID(RouteID, CustomerID);
        }
       
        #endregion

        #region Insert InitialMarketingPlan
        public int Add(InitialMobileServicePlan initialMobileServicePlan)
        {
            return InitialMobileServicePlanDA.Insert(initialMobileServicePlan);
        }
        #endregion

        #region Update
        public int Update(InitialMobileServicePlan initialMobileServicePlan)
        {
            return InitialMobileServicePlanDA.Update(initialMobileServicePlan);
        }
        #endregion
    }
}

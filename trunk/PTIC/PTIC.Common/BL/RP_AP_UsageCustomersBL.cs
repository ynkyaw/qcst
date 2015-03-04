using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Common.DA;

namespace PTIC.Common.BL
{
    public class RP_AP_UsageCustomersBL
    {
        public DataTable GetAPUsageCustomersBy(DateTime startDate, DateTime endDate,bool apUsageCustomer)
        {
            return RP_AP_UsageCustomersDA.APUsageSelectBy(startDate, endDate,apUsageCustomer);
        }

        public DataTable GetCustomerNotUsedPOSMSelectBy(DateTime startDate, DateTime endDate)
        {
            return RP_AP_UsageCustomersDA.CustomerNotUsedPOSMSelectBy(startDate, endDate);
        } 
    }
}

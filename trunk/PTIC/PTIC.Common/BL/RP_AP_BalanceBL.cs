using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Common.DA;

namespace PTIC.Common.BL
{
    public class RP_AP_BalanceBL
    {
        public DataTable GetAPBalanceBy(int? DeptID, int? VenID, int? APCategoryID, int? SubCategoryID, int? APMaterialID)
        {
            return RP_AP_BalanceDA.APBalanceSelectBy(DeptID, VenID, APCategoryID, SubCategoryID, APMaterialID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Sale.DA;

namespace PTIC.Sale.BL
{
    public class ServicedCustomerBL
    {
        public DataTable GetAllBySvcCustomerID(int? servicedCustomerID)
        {
            return ServicedCustomerDA.SelectAllByServicedCustomerID(servicedCustomerID);
        }
    }
}

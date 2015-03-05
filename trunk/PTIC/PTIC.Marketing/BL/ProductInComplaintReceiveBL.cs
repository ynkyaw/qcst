using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.BL
{
    public class ProductInComplaintReceiveBL
    {
        #region SELECT
        public DataTable GetProductInComplaintReceiveByComplaintReceiveID(int ComplaintReceiveID)
        {
            return ProductInComplaintReceiveDA.SelectProductInComplaintReceiveByComplaintReceiveID(ComplaintReceiveID);
        }
        #endregion
    }
}

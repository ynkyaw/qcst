using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.BL
{
    public class OwnBrandInMarketingDetailBL
    {
        #region SELECT
        public DataTable GetOwnBrandInMarketingDetail()
        {
            return OwnBrandInMarketingDetailDA.SelectAllOwnBrandInMarketingDetail();
        }
        #endregion
    }
}

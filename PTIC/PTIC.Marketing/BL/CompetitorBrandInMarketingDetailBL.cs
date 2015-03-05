using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.BL
{
    public class CompetitorBrandInMarketingDetailBL
    {
        #region SELECT
        public DataTable GetCompBrandInMarketingDetail()
        {
            return CompetitorBrandInMarketingDetailDA.SelectAllCompBrandInMarketingDetail();
        }
        #endregion
    }
}

/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/27 (yyyy/mm/dd)
 * Description: POSM_UsageDetail business logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.BL
{
    public class POSM_UsageDetailBL
    {
        #region SELECT
        public DataTable GetByUsageID(int POSM_UsageID)
        {
            return POSM_UsageDetailDA.SelectByUsageID(POSM_UsageID);
        }
        #endregion

        #region INSERT
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion
    }
}

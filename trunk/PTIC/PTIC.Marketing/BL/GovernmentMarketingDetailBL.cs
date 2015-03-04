/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Government Marketing Detail business logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Marketing.DA;
using System.Data;

namespace PTIC.Marketing.BL
{
    public class GovernmentMarketingDetailBL
    {
        #region SELECT
        public DataTable GetGovMarketingLogs(SqlConnection conn)
        {
            return GovernmentMarketingDetailDA.SelectGovMarketingLogs(conn);
        }
        #endregion

        #region INSERT
        public int? Add(GovernmentMarketingDetail newGovernmentMarketingDetail, SqlConnection conn)
        {
            return GovernmentMarketingDetailDA.Insert(newGovernmentMarketingDetail, conn);
        }
        #endregion

        #region UPDATE
        public int UpdateByGovDetailID(GovernmentMarketingDetail mdGovernmentMarketingDetail, SqlConnection conn)
        {
            return GovernmentMarketingDetailDA.UpdateByGovDetailID(mdGovernmentMarketingDetail, conn);
        }
        #endregion

        #region DELETE
        #endregion
    }
}

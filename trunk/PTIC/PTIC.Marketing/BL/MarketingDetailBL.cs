/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Marketing Detail business logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Marketing.DA;
using System.Data;

namespace PTIC.Marketing.BL
{
    public class MarketingDetailBL
    {
        #region SELECT
        public DataTable GetByMarketingDetailID(int marketingDetailID)
        {
            return MarketingDetailDA.SelectByMarketingDetailID(marketingDetailID);
        }
        #endregion

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newMarketingDetail"></param>
        /// <param name="conn"></param>
        /// <returns>Return an inserted ID</returns>
        public int? Add(
            MarketingDetail newMarketingDetail, 
            List<OwnBrandInMarketingDetail> newOwnBrandInMarketingDetail,
            List<CompetitorBrandInMarketingDetail> newCompBrandInMarketingDetail)
        {
            return MarketingDetailDA.Insert(newMarketingDetail, newOwnBrandInMarketingDetail, newCompBrandInMarketingDetail);
        }
        #endregion

        #region UPDATE
        public int UpdateByMarketingDetailID(MarketingDetail mdMarketingDetail,
              List<OwnBrandInMarketingDetail> newOwnBrandInMarketingDetail,
            List<CompetitorBrandInMarketingDetail> newCompBrandInMarketingDetail)
        {
            return MarketingDetailDA.UpdateByMarketingDetailID(mdMarketingDetail,newOwnBrandInMarketingDetail,newCompBrandInMarketingDetail);
        }
        #endregion

        #region DELETE
        public int DeleteByMarketingDetailID(int marketingDetailID, SqlConnection conn)
        {
            return MarketingDetailDA.DeleteByMarketingDetailID(marketingDetailID, conn);
        }
        #endregion
    }
}

/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: CompetitorMarketPromotion business class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.BL
{
    /// <summary>
    /// 
    /// </summary>
    public class CompetitorMarketPromotionBL
    {
        #region SELECT
        public DataTable GetByCompetitorActivityID(int competitorActivityID, SqlConnection conn)
        {
            return CompetitorMarketPromotionDA.SelectByCompetitorActivityID(competitorActivityID, conn);
        }
        #endregion

        #region INSERT
        public int Add(CompetitorMarketPromotion newCompetitorMarketPromotion, SqlConnection conn)
        {
            return CompetitorMarketPromotionDA.Insert(newCompetitorMarketPromotion, conn);
        }
        #endregion

        #region UPDATE
        public int UpdateByID(CompetitorMarketPromotion mdCompetitorMarketPromotion, SqlConnection conn)
        {
            return CompetitorMarketPromotionDA.UpdateByID(mdCompetitorMarketPromotion, conn);
        }
        #endregion

        #region DELETE
        public int DeleteByID(int competitorMarketPromotionID, SqlConnection conn)
        {
            return CompetitorMarketPromotionDA.DeleteByID(competitorMarketPromotionID, conn);
        }
        #endregion
    }
}

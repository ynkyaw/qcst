/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: CompetitorActivity business class
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
    public class CompetitorActivityBL
    {        
        #region SELECT
        public DataTable GetByCompetitorActivityID(int competitorActivityID, SqlConnection conn)
        {
            return CompetitorActivityDA.SelectByCompetitorActivityID(competitorActivityID, conn);
        }
        #endregion

        #region INSERT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newCompActivity">New competitor acitvity</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Inserted competitor ID</returns>
        public int Add(CompetitorActivity newCompActivity, SqlConnection conn)
        {
            return CompetitorActivityDA.Insert(newCompActivity, conn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newCompetitorActivity"></param>
        /// <param name="newCompetitor_A_P_Supports"></param>
        /// <param name="newCompetitorMarketPromotions"></param>
        /// <param name="conn"></param>
        /// <returns>Return a new inserted CompetitorActivityID</returns>
        public int? Add(CompetitorActivity newCompetitorActivity,
            List<Competitor_A_P_Support> newCompetitor_A_P_Supports,
            List<CompetitorMarketPromotion> newCompetitorMarketPromotions, SqlConnection conn)
        {
            return CompetitorActivityDA.Insert(newCompetitorActivity, 
                newCompetitor_A_P_Supports, 
                newCompetitorMarketPromotions, 
                conn);
        }
        #endregion

        #region UPDATE
        public int UpdateByCompetitorActivityID(CompetitorActivity compActivity, SqlConnection conn)
        {
            return CompetitorActivityDA.UpdateByCompetitorActivityID(compActivity, conn);
        }
        #endregion

        #region DELETE
        public int DeleteByCompetitorActivityID(int competitorActivityID, SqlConnection conn)
        {            
            return CompetitorActivityDA.DeleteByCompetitorActivityID(competitorActivityID, conn);
        }
        #endregion
        
    }
}

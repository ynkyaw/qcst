/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: Competitor_A_P_Support business class
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
    public class Competitor_A_P_SupportBL
    {
        #region SELECT
        public DataTable GetByCompetitorActivityID(int competitorActivityID, SqlConnection conn)
        {
            return Competitor_A_P_SupportDA.SelectByCompetitorActivityID(competitorActivityID, conn);
        }
        #endregion

        #region INSERT
        public int Add(Competitor_A_P_Support newCompetitor_A_P_Support, SqlConnection conn)
        {
            return Competitor_A_P_SupportDA.Insert(newCompetitor_A_P_Support, conn);
        }
        #endregion

        #region UPDATE
        public int UpdateByID(Competitor_A_P_Support mdCompetitor_A_P_Support, SqlConnection conn)
        {
            return Competitor_A_P_SupportDA.UpdateByID(mdCompetitor_A_P_Support, conn);
        }
        #endregion

        #region DELETE
        public int DeleteByID(int competitor_A_P_SupportID, SqlConnection conn)
        {
            return Competitor_A_P_SupportDA.DeleteByID(competitor_A_P_SupportID, conn);
        }
        #endregion
    }
}

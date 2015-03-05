/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/13 (yyyy/MM/dd)
 * Description: 
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
    /// <summary>
    /// 
    /// </summary>
    public class POSM_UsageBL
    {
        #region SELECT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public DataTable GetUsageList(DateTime date, int? departmentID)
        {
            return POSM_UsageDA.SelectUsageList(date, departmentID);
        }
        #endregion

        #region INSERT
        public int? Add(POSM_Usage newUsage, List<POSM_UsageDetail> newUsageDetails, SqlConnection conn)
        {
            return POSM_UsageDA.Insert(newUsage, newUsageDetails, conn);
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion

    }
}

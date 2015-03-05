/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/13 (yyyy/MM/dd)
 * Description: 
 */
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using PTIC.Common.DA;
namespace PTIC.Marketing.DA
{
    public class POSM_UsageDetailDA
    {
        #region SELECT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="POSM_UsageID"></param>
        /// <returns></returns>
        public static DataTable SelectByUsageID(int POSM_UsageID)
        {
            string queryString = string.Format("SELECT * FROM uv_POSM_UsageDetail WHERE POSM_UsageID = {0}", POSM_UsageID);
            return new BaseDAO().SelectByQuery(queryString);
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

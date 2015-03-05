/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/06/02 (yyyy/MM/dd)
 * Description: Service fact business logic class
 */

using System.Data;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
namespace PTIC.Sale.BL
{
    /// <summary>
    /// Service fact business logic
    /// </summary>
    public class SvcFactBL
    {
        #region SELECT
        public DataTable GetByID(int? svcFactID)
        {
            return SvcFactDA.SelectByID(svcFactID);
        }
        #endregion

        #region INSERT
        /// <summary>
        /// Add a new service fact
        /// </summary>
        /// <param name="newSvcFact"></param>
        /// <param name="salesServiceID"></param>
        /// <param name="conn"></param>
        /// <returns>Return an inserted service fact ID</returns>
        public int? Add(SvcFact newSvcFact, int salesServiceID, SqlConnection conn)
        {
            return SvcFactDA.Insert(newSvcFact, salesServiceID, conn);
        }
        #endregion

        #region UPDATE
        public int Update(SvcFact updateSvcFact, SqlConnection conn)
        {
            return SvcFactDA.Update(updateSvcFact, conn);
        }
        #endregion

        #region DELETE
        #endregion
    }
}

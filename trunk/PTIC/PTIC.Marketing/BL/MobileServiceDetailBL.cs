/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: Mobile Service Detail data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.BL
{
    /// <summary>
    /// 
    /// </summary>
    public class MobileServiceDetailBL
    {
        #region SELECT
        public DataTable GetByMobileServiceDetailID(int mobileServiceDetailID)
        {
            return MobileServiceDetailDA.SelectByMobileServiceDetailID(mobileServiceDetailID);
        }
        #endregion

        #region INSERT
        public int Add(MobileServiceDetail newMobileServiceDetail)
        {
            return MobileServiceDetailDA.Insert(newMobileServiceDetail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newMobileServiceDetail"></param>
        /// <param name="newMobileServiceRecords"></param>
        /// <returns>Return an inserted MobileServiceDetail</returns>
        public int? Add(MobileServiceDetail newMobileServiceDetail, List<MobileServiceRecord> newMobileServiceRecords)
        {
            return MobileServiceDetailDA.Insert(newMobileServiceDetail, newMobileServiceRecords);
        }
        #endregion

        #region UPDATE
        public int UpdateByMobileServiceDetailID(MobileServiceDetail mdMobileServiceDetail)
        {
            return MobileServiceDetailDA.UpdateByMobileServiceDetailID(mdMobileServiceDetail);
        }
        #endregion

        #region DELETE
        public int DeleteByMobileServiceDetailID(int mobileServiceDetailID)
        {
            return MobileServiceDetailDA.DeleteByMobileServiceDetailID(mobileServiceDetailID);
        }
        #endregion

    }

}

/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: Mobile Service Record data access class
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
    public class MobileServiceRecordBL
    {
        #region SELECT
        public DataTable GetByMobileServiceDetailID(int? mobileServiceDetailID)
        {
            return MobileServiceRecordDA.SelectByMobileServiceDetailID(mobileServiceDetailID);
        }
        #endregion

        #region INSERT
        public int Add(MobileServiceRecord newMobileServiceRecord)
        {
            return MobileServiceRecordDA.Insert(newMobileServiceRecord);
        }
        #endregion

        #region UPDATE
        public int UpdateByMobileServiceRecordID(MobileServiceRecord mdMobileServiceRecord)
        {
            return MobileServiceRecordDA.UpdateByMobileServiceRecordID(mdMobileServiceRecord);
        }
        #endregion

        #region DELETE
        public int DeleteByID(int mobileServiceRecordID)
        {
            return MobileServiceRecordDA.DeleteByID(mobileServiceRecordID);
        }
        #endregion

    }
}

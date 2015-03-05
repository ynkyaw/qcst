/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   ServiceBL
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.BL
{
    public class ServiceBL
    { //

        #region SelectAll
        public DataTable GetByServiceID(int? ServiceID)
        {
            return ServiceDA.SelectByServiceID(ServiceID);
        }
        #endregion

        #region INSERT
        public int? Add(Service service, List<ServiceDetail> serviceDetail,SqlConnection conn)
        {
            return ServiceDA.Insert(service, serviceDetail, conn);
        }

        public int? Add(MobileServiceDetail moblieServiceDetail, List<MobileServiceRecord> mobileServiceRecord, SqlConnection conn)
        {
            return ServiceDA.Insert(moblieServiceDetail, mobileServiceRecord, conn);
        }
        #endregion

        #region UPDATE
        public int UpdateByServiceID(Service Service, SqlConnection conn)
        {
            return ServiceDA.UpdateByID(Service, conn);
        }
        #endregion

        #region DELETE
        public int DeleteByServiceID(int? ServiceID, SqlConnection conn)
        {
            return ServiceDA.DeleteByServiceID(ServiceID, conn);
        }     
        #endregion
        //
    }
}

/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   ServiceDetailBL
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
    public class ServiceDetailBL
    { //

        #region SelectAll


        public DataTable getByServiceID(int? ServiceID, SqlConnection conn)
        {
            return ServiceDetailDA.SelectByServiceID(ServiceID, conn);
        }

        public DataTable GetByServiceDetailID(int serviceDetailID, SqlConnection conn)
        {
            return ServiceDetailDA.SelectByServiceDetailID(serviceDetailID, conn);
        }
        
        #endregion

        #region INSERT
        
        #endregion

        #region UPDATE
        
        #endregion

        #region DELETE
        public int DeleteByServiceDetailID(int ServiceDetailID, SqlConnection conn)
        {
            return 0;
           // return ServiceDetailDA.DeleteByServiceDetailID(ServiceDetailID, conn);
        }     
        #endregion
        //
    }
}


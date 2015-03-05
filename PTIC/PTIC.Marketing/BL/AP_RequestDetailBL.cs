using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;

namespace PTIC.Marketing.BL
{
    public class AP_RequestDetailBL
    {
        #region GETALL
        public DataTable GetAll()
        {
            return AP_RequestDetailDA.SelectAll();
        }
        #endregion

        #region ADD
        public int Add(AP_Request _AP_Request, List<AP_RequestDetail> _AP_RequestDetail, SqlConnection conn)
        {
            return AP_RequestDetailDA.Insert(_AP_Request, _AP_RequestDetail, conn);
        }
        #endregion
        #region UpdateByID
        public int UpdateID(List<AP_RequestDetail> _AP_RequestDetail, SqlConnection conn)
        {
            return AP_RequestDetailDA.Update(_AP_RequestDetail,conn);
        }
        #endregion
    }
}

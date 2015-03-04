using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.BL
{
    public class AP_TransferListBL
    {
        #region GetAll AP_Request & AP_IssueDetail
        
        #endregion
        public DataTable GetAll()
        {
            return AP_TransferListDA.SelectAll();
        }
    }
}

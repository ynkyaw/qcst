using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.BL
{
    public class ComplaintCaseBL
    {
        #region SELECT
        public DataTable GetComplaintCase()
        {
            return ComplaintCaseDA.SelectComplaintCase();
        }
        #endregion
    }
}

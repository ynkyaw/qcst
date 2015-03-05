using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.BL
{
    public class IssueDetailBL
    {
        #region ADD
        public int Add(List<AP_IssueDetail> _AP_IssueDetail, SqlConnection conn)
        {
            return IssueDetailDA.Insert(_AP_IssueDetail, conn);
        }

        public int Update(List<AP_IssueDetail> _AP_IssueDetail, SqlConnection conn)
        {
            return IssueDetailDA.Update(_AP_IssueDetail, conn);
        }
        #endregion
    }
}

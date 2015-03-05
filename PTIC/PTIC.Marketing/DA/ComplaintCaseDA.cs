using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;

namespace PTIC.Marketing.DA
{
    public class ComplaintCaseDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECT
        public static DataTable SelectComplaintCase()
        {
            DataTable dt;
            try
            {
                string query = "SELECT ID As ComplaintCaseID,CaseDespt FROM ComplaintCase";
                dt = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            return dt;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;

namespace PTIC.Marketing.DA
{
    public class OwnBrandInMarketingDetailDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECT
        public static DataTable SelectAllOwnBrandInMarketingDetail()
        {
            DataTable dt;

            try
            {
                dt = b.SelectAll("OwnBrandInMarketingDetail");
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

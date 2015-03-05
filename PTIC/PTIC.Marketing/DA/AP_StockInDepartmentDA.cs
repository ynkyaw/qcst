/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/27 (yyyy/MM/dd)
 * Description: AP_StockInDepartment data access class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Common.DA;

namespace PTIC.Marketing.DA
{
    public class AP_StockInDepartmentDA
    {
        #region SELECT
        public static DataTable SelectAll()
        {
            string queryString = "SELECT * FROM AP_StockInDepartment";
            return new BaseDAO().SelectByQuery(queryString);
        }
        #endregion

        #region INSERT
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion
    }
}

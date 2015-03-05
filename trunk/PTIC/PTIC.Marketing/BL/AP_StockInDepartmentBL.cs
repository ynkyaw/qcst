/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/08/08 (yyyy/MM/dd)
 * Description: AP_StockInDepartment business logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;

namespace PTIC.Marketing.BL
{
    public class AP_StockInDepartmentBL
    {
        #region SELECT
        public DataTable GetAll()
        {
            return AP_StockInDepartmentDA.SelectAll();
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

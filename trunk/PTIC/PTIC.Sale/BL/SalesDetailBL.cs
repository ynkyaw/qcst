/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Sale Detail logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;

namespace PTIC.Sale.BL
{
    /// <summary>
    /// 
    /// </summary>
    public class SalesDetailBL
    {
        #region SELECT
        public DataTable GetByInvoiceID(int? invoiceID)
        {
            return SalesDetailDA.SelectByInvoiceID(invoiceID);
        }
        #endregion

        #region INSERT
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        public int Delete(int saledetail, SqlConnection conn)
        {
            return SalesDetailDA.DeleteByID(saledetail, conn);
        }
        #endregion
    }
}

/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   CashDiscount ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Sale.DA;

namespace PTIC.Sale.BL
{
    public class CashDiscountBL
    {
        #region SELECTALL
        public DataTable GetAll()
        {
            return CashDiscountDA.SelectAll();
        }
        #endregion

        #region INSERT
        public int Insert(CashDiscount cashdiscount, SqlConnection conn)
        {
            return CashDiscountDA.Insert(cashdiscount, conn);
        }
        #endregion

        #region UPDATE
        public int Update(CashDiscount cashdiscount, SqlConnection conn)
        {
            return CashDiscountDA.UpdateByID(cashdiscount, conn);
        }
        #endregion

        #region DELETE
        public int Delete(CashDiscount cashdiscount, SqlConnection conn)
        {
            return CashDiscountDA.DeleteByID(cashdiscount, conn);
        }
        #endregion
    }
}

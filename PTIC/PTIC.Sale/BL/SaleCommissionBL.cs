/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   SaleCommissionBL ( Insert , Update , Delete , Select}
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
    public class SaleCommissionBL
    {
        #region SELECTALL
        public DataTable GetAll()
        {
            return SaleCommissionDA.SelectAll();
        }
        #endregion

        #region INSERT
        public int Insert(SaleCommission salecommission, SqlConnection conn)
        {
            return SaleCommissionDA.Insert(salecommission, conn);
        }
        #endregion

        #region UPDATE
        public int Update(SaleCommission salecommission, SqlConnection conn)
        {
            return SaleCommissionDA.UpdateByID(salecommission, conn);
        }
        #endregion

        #region DELETE
        public int Delete(SaleCommission salecommission, SqlConnection conn)
        {
            return SaleCommissionDA.DeleteByID(salecommission, conn);
        }
        #endregion
    }
}

/* Author   :   Aung Ko Ko
    Date      :   20 Feb 2014
    Description :   PackingDiscountBL ( Insert , Update , Delete , Select}
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
    public class PackingDiscountBL
    {
        #region SELECTALL
        public DataTable GetAll(SqlConnection conn)
        {
            return PackingDiscountDA.SelectAll(conn);
        }
        #endregion

        #region INSERT
        public int Insert(PackingDiscount packingdiscount, SqlConnection conn)
        {
            return PackingDiscountDA.Insert(packingdiscount, conn);
        }
        #endregion

        #region UPDATE
        public int Update(PackingDiscount packingdiscount, SqlConnection conn)
        {
            return PackingDiscountDA.UpdateByID(packingdiscount, conn);
        }
        #endregion

        #region DELETE
        public int Delete(PackingDiscount packingdiscount, SqlConnection conn)
        {
            return PackingDiscountDA.DeleteByID(packingdiscount, conn);
        }
        #endregion
    }
}

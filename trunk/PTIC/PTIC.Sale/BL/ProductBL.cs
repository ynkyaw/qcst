/* Author   :   Aung Ko Ko
    Date      :   14 Feb 2014
    Description :   ProductBL ( Insert , Update , Delete , Select}
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
    public class ProductBL
    {
        #region SELECT
        public DataTable GetAll()
        {
            return ProductDA.SelectAll();
        }

        public DataTable GetWithPrice()
        {
            return ProductDA.SelectWithPrice();
        }

        public DataTable GetPriceList()
        {
            return ProductDA.SelectPriceList();
        }
        #endregion

        #region INSERT
        public int Add(Product newProduct, SqlConnection conn)
        {
            return ProductDA.Insert(newProduct, conn);
        }
        #endregion

        #region UPDATE
        public int UpdateByID(Product product, SqlConnection conn)
        {
            return ProductDA.UpdateByID(product, conn);
        }
        #endregion

        #region DELETE
        public int DeleteByID(int productID, SqlConnection conn)
        {
            return ProductDA.DeleteByID(productID, conn);
        }
        #endregion
    }
}

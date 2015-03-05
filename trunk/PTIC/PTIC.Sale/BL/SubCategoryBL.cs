/* Author   :   Aung Ko Ko
    Date      :   14 Feb 2014
    Description :   SubCategoryBL ( Insert , Update , Delete , Select}
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
    public class SubCategoryBL
    {

        #region SELECT
        public DataTable GetAll()
        {
            return SubCategoryDA.SelectAll();
        }
        #endregion

        #region INSERT
        public int Insert(SubCategory product, SqlConnection conn)
        {
            return SubCategoryDA.Insert(product, conn);
        }
        #endregion

        #region UPDATE
        public int Update(SubCategory product, SqlConnection conn)
        {
            return SubCategoryDA.UpdateByID(product, conn);
        }
        #endregion

        #region DELETE
        public int Delete(SubCategory product, SqlConnection conn)
        {
            return SubCategoryDA.DeleteByID(product, conn);
        }
        #endregion
    }
}

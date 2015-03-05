/* Author   :   Aung Ko Ko
    Date      :   13 Feb 2014
    Description :   CategoryBL ( Insert , Update , Delete , Select}
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using System.Data;

namespace PTIC.Sale.BL
{
    public class CategoryBL
    {
        #region SELECT
        public DataTable GetAll()
        {
            return CategoryDA.SelectAll();
        }
        #endregion

        #region INSERT
        public int Insert(Category category, SqlConnection conn)
        {
            return CategoryDA.Insert(category, conn);
        }
        #endregion

        #region UPDATE
        public int Update(Category category, SqlConnection conn)
        {
            return CategoryDA.UpdateByID(category, conn);
        }
        #endregion

        #region DELETE
        public int Delete(Category category, SqlConnection conn)
        {
            return CategoryDA.DeleteByID(category, conn);
        }
        #endregion

    }
}

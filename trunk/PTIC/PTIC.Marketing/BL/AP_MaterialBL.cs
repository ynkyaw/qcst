/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   A_P_BL
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.BL
{
    public class AP_MaterialBL
    { 
        #region SELECTALL
        public DataTable GetAllCategory()
        {
            return AP_CategoryDA.SelectAll();
        }

        public DataTable GetAllSubCategory()
        {
            return AP_SubCategoryDA.SelectAll();
        }

        public DataTable GetAllMaterial()
        {
            return AP_MaterialDA.SelectAll();
        }
        #endregion

        #region INSERT
        /*
        public int Insert(A_P ap, SqlConnection conn)
        {
            return AP_MaterialDA.Insert(ap, conn);
        }
        */
        #endregion

        #region UPDATE
        /*
        public int Update(A_P ap, SqlConnection conn)
        {
            return AP_MaterialDA.UpdateByID(ap, conn);
        }
        */
        #endregion

        #region DELETE
        /*
        public int Delete(A_P ap, SqlConnection conn)
        {
            return AP_MaterialDA.DeleteByID(ap, conn);
        }
        */
        #endregion
        //
    }
}

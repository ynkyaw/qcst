/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   SDivisoinBL ( Insert , Update , Delete , Select}
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
    public class SDivisionBL
    {
        #region SELECTALL
        public DataTable GetAll()
        {
            return SDivisionDA.SelectAll();
        }
        #endregion

        #region INSERT
        public int Insert(SDivision sdivision, SqlConnection conn)
        {
            return SDivisionDA.Insert(sdivision, conn);
        }
        #endregion

        #region UPDATE
        public int Update(SDivision sdivision, SqlConnection conn)
        {
            return SDivisionDA.UpdateByID(sdivision, conn);
        }
        #endregion

        #region DELETE
        public int Delete(SDivision sdivision, SqlConnection conn)
        {
            return SDivisionDA.DeleteByID(sdivision, conn);
        }
        #endregion
    }
}

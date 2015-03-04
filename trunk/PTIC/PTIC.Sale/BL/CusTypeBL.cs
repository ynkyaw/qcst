/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   CusTypeBL ( Insert , Update , Delete , Select}
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.DA;

namespace PTIC.Sale.BL
{
    public class CusTypeBL
    {
        #region Select
        public DataTable GetData()
        {
            return CusTypeDA.Select();
        }
        #endregion

        #region SELECTALL
        public DataTable GetAll()
        {
            return CusTypeDA.SelectAll();
        }
        #endregion

        #region SELECTBYTOWNSHIPID
        public DataTable GetByTownshipID(int TownshipID, SqlConnection conn)
        {
            return CusTypeDA.SelectAllByTownshipID(TownshipID, conn);
        }
        #endregion
    }
}

/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   TownshipBL ( Insert , Update , Delete , Select}
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
    public class TownshipBL
    {
        #region SELECTALL
        public DataTable GetWithCustomerType()
        {            
            return TownshipDA.SelectWithCustomerType();
        }

        public DataTable GetAll()
        {
            return TownshipDA.SelectAll();
        }
        #endregion

        #region INSERT
        public int Insert(Township township, SqlConnection conn)
        {
            return TownshipDA.Insert(township, conn);
        }
        #endregion

        #region UPDATE
        public int Update(Township township, SqlConnection conn)
        {
            return TownshipDA.UpdateByID(township, conn);
        }
        #endregion

        #region DELETE
        public int Delete(Township township, SqlConnection conn)
        {
            return TownshipDA.DeleteByID(township, conn);
        }
        #endregion

        #region GetTownShipCount By Town ID
        public int GetTownShipCountByTownID(int townId) 
        {
            return TownInTripDA.GetTownShipCountByTownId(townId);
        }
        #endregion

    }
}

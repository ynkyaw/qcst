/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   TripBL ( Insert , Update , Delete , Select}
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
    public class TripBL
    {
        #region SELECTALL
        public DataTable GetAll()
        {
            return TripDA.SelectAll();
        }

        public DataTable GetAllTownByTripID(int TripID)
        {
            return TripDA.SelectAllTownByTripID(TripID);
        }
        #endregion

        #region INSERT
        public int Insert(Trip trip)
        {
            return TripDA.Insert(trip);
        }
        #endregion

        #region UPDATE
        public int Update(Trip trip)
        {
            return TripDA.UpdateByID(trip);
        }
        #endregion

        #region DELETE
        public int Delete(Trip trip)
        {
            return TripDA.DeleteByID(trip);
        }
        #endregion

    }
}

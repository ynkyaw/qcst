/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   TownshipInRouteBL ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Sale.DA;

namespace PTIC.Sale.BL
{
    public class TownshipInRouteBL
    {
        #region SELECTALL
        public DataTable GetTownshipInRouteByTownshipID(int TownshipID)
        {
            return TownshipInRouteDA.SelectTownshipInRouteByTownshipID(TownshipID);
        }

        public DataTable GetAll()
        {
            return TownshipInRouteDA.SelectAll();
        }

        public DataTable GetDataByRouteId(int routeId)
        {

            return TownshipInRouteDA.GetDataByRouteId(routeId);
        }

        #endregion

        #region INSERT
        public int Insert(TownshipInRoute townshipinroute)
        {
            return TownshipInRouteDA.Insert(townshipinroute);
        }
        #endregion

        #region UPDATE
        public int Update(TownshipInRoute townshipinroute)
        {
            return TownshipInRouteDA.UpdateByID(townshipinroute);
        }
        #endregion

        #region DELETE
        public int Delete(TownshipInRoute townshipinroute)
        {
            return TownshipInRouteDA.DeleteByID(townshipinroute);
        }
        #endregion
    }
}

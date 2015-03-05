/* Author   :   Aung Ko Ko
    Date      :   22 Feb 2014
    Description :   RouteBL ( Insert , Update , Delete , Select}
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
    public class RouteBL
    {
        #region SELECTALL
        public DataTable GetAll()
        {
            return RouteDA.SelectAll();
        }

        public DataTable GetTownList()
        {
            return RouteDA.GetTownList();
        }

        public Route GetDataByRouteId(int routeId)
        {
            DataTable dt = new DataTable();
            
            dt = RouteDA.GetDataByRouteId(routeId);
            Route route = new Route();
            if (dt != null && dt.Rows.Count == 1)
            {
             
                route.RouteID = (int)dt.Rows[0]["ID"];
                route.RouteName = (string)dt.Rows[0]["RouteName"];
                route.DateAdded = (DateTime)dt.Rows[0]["DateAdded"];
                route.LastModified = (DateTime)dt.Rows[0]["LastModified"];
                route.IsDeleted = false;
            }
            return route;

        }

        #endregion

        #region INSERT
        public int Insert(Route route, SqlConnection conn)
        {
            return RouteDA.Insert(route, conn);
        }
        #endregion

        #region UPDATE
        public int Update(Route route, SqlConnection conn)
        {
            return RouteDA.UpdateByID(route, conn);
        }
        #endregion

        #region DELETE
        public int Delete(Route route, SqlConnection conn)
        {
            return RouteDA.DeleteByID(route, conn);
        }
        #endregion

        #region Select RouteId by Name
        public int SelectRouteIdByRouteName(string routeName) 
        {

            return RouteDA.SelectRouteIdByRouteName(routeName);
        }





        #endregion



    }
}

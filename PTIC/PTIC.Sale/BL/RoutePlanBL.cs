using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.DA;

namespace PTIC.Sale.BL
{
    public class RoutePlanBL
    {
        public System.Data.DataTable GetAll(System.Data.SqlClient.SqlConnection conn)
        {
            return RoutePlanDA.GetAll(conn);
        }

        public int Save(Entities.RoutePlan routeplan, System.Data.SqlClient.SqlConnection conn)
        {
            return RoutePlanDA.Insert(routeplan,conn);
        }

        public System.Data.DataTable GetAllView(System.Data.SqlClient.SqlConnection conn)
        {
            return RoutePlanDA.GetAllView(conn);
        }

        /// <summary>
        /// Delete a specific record
        /// </summary>
        /// <param name="routePlanID">By roue plan ID</param>
        /// <returns>Return affected row count</returns>
        public int DeleteByID(int routePlanID)
        {
            return RoutePlanDA.DeleteByID(routePlanID);
        }

        public int Update(Entities.RoutePlan routeplan, System.Data.SqlClient.SqlConnection conn)
        {
            return RoutePlanDA.Update(routeplan,conn);
        }
    }
}

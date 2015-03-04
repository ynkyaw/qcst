
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, 
 * Create date: 3 March 2014
 * Description: About T_R_Product
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.BL
{
    /// <summary>
    /// TripPlan_AP business logic
    /// </summary>
    public class TripPlan_AP_BL
    {
        #region SELECT
        /// <summary>
        /// Get all TripPlan_AP from system
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all orders</returns>
        public DataTable GetAll(SqlConnection conn)
        {
            return TripPlan_AP_DA.SelectAll(conn);
        }

        public DataTable GetByTripPlanDetailID(int TripPlanDetailID, SqlConnection conn)
        {
            return TripPlan_AP_DA.SelectByTripPlanDetailID(TripPlanDetailID, conn);
        }


        #endregion

        #region INSERT


        public int Insert(List<TripPlan_AP> tripPlan_AP, SqlConnection conn)
        {
            return TripPlan_AP_DA.Insert(tripPlan_AP, conn);
        }

      
        #endregion

        #region UPDATE
    


        #endregion

        public int UpdateByTripPlanAPID(List<TripPlan_AP> tripPlan_AP, SqlConnection conn)
        {
            return TripPlan_AP_DA.UpdateByTripPlan_APID(tripPlan_AP, conn);
        }


        #region DELETE
        public int DeleteByTripPlanAPID(List<TripPlan_AP> tripPlan_AP, SqlConnection conn)
        {
            return TripPlan_AP_DA.DeleteByTripPlan_APID(tripPlan_AP, conn);
        }

        #endregion




    }
}

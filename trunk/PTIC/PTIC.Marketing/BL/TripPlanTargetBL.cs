using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.BL
{
    public class TripPlanTargetBL
    {
        #region SELECT
        public DataTable GetByTripPlanDetailID(int tripPlanDetailID)
        {
            return TripPlanTargetDA.SelectByTripPlanDetailID(tripPlanDetailID);
        }

        public decimal GetTargetAmountByTripPlanDetailID(int tripPlanDetailID)
        {
            return TripPlanTargetDA.SelectTargetAmountByTripPlanDetailID(tripPlanDetailID);
        }
        #endregion

        #region INSERT
        public int Add(TripPlanDetail tripPlanDetail, List<TripPlanTarget> tripPlanTargets)
        {
            return TripPlanTargetDA.Insert(tripPlanDetail, tripPlanTargets);
        }
        #endregion
        public int Update(TripPlanDetail tripPlanDetail, List<TripPlanTarget> tripPlanTargets)
        {
            return TripPlanTargetDA.Update(tripPlanDetail, tripPlanTargets);
        }
        #region UPDATE

        #endregion

        #region DELETE
        public int Delete(TripPlanDetail tripPlanDetail, List<TripPlanTarget> tripPlanTargets)
        {
            return TripPlanTargetDA.Delete(tripPlanDetail, tripPlanTargets);
        }


        #endregion

       
    }
}

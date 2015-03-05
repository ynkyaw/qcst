/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/08/27 (yyyy/mm/dd)
 * Description: TripRecord business logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Marketing.Entities;
using PTIC.Marketing.DA;
using System.Data;

namespace PTIC.Marketing.BL
{
    public class TripRecordBL
    {
        #region SELECT
        public DataTable GetByTripPlanDetailID(int tripPlanDetailID)
        {
            return TripRecordDA.SelectByTripPlanDetailID(tripPlanDetailID);
        }

        public DataTable GetPreviousRecordByTripPlanDetailID(int tripPlanDetailID)
        {
            return TripRecordDA.SelectPreviousRecordByTripPlanDetailID(tripPlanDetailID);
        }
        #endregion

        #region INSERT
        /// <summary>
        /// Add new trip record
        /// </summary>
        /// <param name="newTripRecord">New TripRecord</param>
        /// <returns>Inserted ID</returns>
        public int? Add(TripRecord newTripRecord)
        {
            return TripRecordDA.Insert(newTripRecord);
        }
        #endregion

        #region UPDATE
        public int UpdateByID(TripRecord uTripRecord)
        {
            return TripRecordDA.UpdateByID(uTripRecord);
        }
        #endregion

        #region DELETE
        #endregion
    }
}

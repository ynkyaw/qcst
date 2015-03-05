
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, Aung Ko Ko, Wai Phyoe Thu <wpt.osp@gmail.com>
 * Create date: March 1 2014
 * Description: About TripPlanDetail BL
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using PTIC.Common.Entities;
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Marketing.BL
{
    /// <summary>
    /// TripPlanDetail business logic
    /// </summary>
    public class TripPlanDetailBL : BaseBusinessLogic
    {
        #region SELECT
        /// <summary>
        /// Get all TripPlanDetail from system
        /// </summary>        
        /// <returns>Return datatable containing all orders</returns>
        public DataTable GetAll()
        {
            return TripPlanDetailDA.SelectAll();
        }

        public DataTable GetBy(DateTime startDate, DateTime endDate, int vehicleID)
        {
            return TripPlanDetailDA.SelectBy(startDate, endDate, vehicleID);
        }

        public DataTable GetBy(DateTime startDate, DateTime endDate, Employee manager)
        {
            return TripPlanDetailDA.SelectBy(startDate, endDate, manager);
        }

        public DataTable GetBy(string tripPlanNo, int tripPlanID)
        {
            return TripPlanDetailDA.SelectBy(tripPlanNo.Trim(), tripPlanID);
        }

        public DataTable GetByDateRange(DateTime start, DateTime end, bool isSale)
        {
            return TripPlanDetailDA.SelectByDateRange(start, end, isSale);
        }

        public DataTable GetByTripPlanID(int tripPlanID,SqlConnection conn)
        {
            return TripPlanDetailDA.SelectByTripPlanID(tripPlanID,conn);
        }

        public DataTable GetByTripPlanDetailID(int  tripPlanDetailID, SqlConnection conn)
        {
            return TripPlanDetailDA.GetByTripPlanDetailID(tripPlanDetailID, conn);
        }

        public DataTable GetPrevTripPlan(int tripPlanDetailId,bool isSale, SqlConnection conn)
        {
            return TripPlanDetailDA.GetPrevTripPlan(tripPlanDetailId,isSale, conn);
        }

        public DataTable GetPrevTripPlanByTripPlanDetailID(int tripPlanDetailID, SqlConnection conn)
        {
            return TripPlanDetailDA.GetPrevTripPlanByTripPlanDetailID(tripPlanDetailID, conn);
        }
        #endregion

        #region INSERT
        /// <summary>
        /// Add a new TripPlanDetail into system
        /// </summary>
        /// <param name="newOrder">New TripPlanDetail entity</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int Add(TripPlanDetail newTripPlanDetail, SqlConnection conn)
        {
            return TripPlanDetailDA.Insert(newTripPlanDetail, conn);
        }

        public int Add(TripPlanDetail newTripPlanDetail, List<TripPlanDetail> newTripPlanDetailDetails, SqlConnection conn)
        {
            //return TripPlanDetailDA.Insert(newTripPlanDetail, newTripPlanDetailDetails, conn);
            return 0;
        }
        #endregion

        #region UPDATE
        /// <summary>
        /// Update an existing TripPlanDetail in system by order ID
        /// </summary>
        /// <param name="mdTripPlanDetail">TripPlanDetail to be updated</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int UpdateByID(TripPlanDetail mdTripPlanDetail,List<Employee> EmployeesList,SqlConnection conn)
        { 
            return TripPlanDetailDA.UpdateByTripPlanDetailID(mdTripPlanDetail,EmployeesList, conn);
        }

        public int Update(List<TripPlanDetail> mdTripPlanDetailDetails)
        {
            if (mdTripPlanDetailDetails == null || mdTripPlanDetailDetails.Count < 1)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult("Trip Detail ဖြည့်သွင်းပေးပါရန်။",
                        null, "NullTripPlanDetailList", null, null));
                return 0;
            }
            
            //− ခရီးစဉ်အမှတ် မထပ်ရ in each new rows
            var duplicatedTripPlanNo = mdTripPlanDetailDetails.GroupBy(x => new { x.TripPlanNo }).Where(x => x.Skip(1).Any()).ToArray();
            if (duplicatedTripPlanNo.Any())
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.TripPlanDetail_TripPlanNo_Duplicate,
                        null, "TripPlanDetail_TripPlanNo_Duplicate", null, null));
                return 0;
            }

            // Get vehicle IDs that are null
            var nullVan = from vanFromDts in mdTripPlanDetailDetails
                          where vanFromDts.VenID == null
                          select vanFromDts;

            // TripPlanDetail validation
            Validator<TripPlanDetail> detailValidator = base.ValidationManager.CreateValidator<TripPlanDetail>();
            foreach (TripPlanDetail detail in mdTripPlanDetailDetails)
            {
                ValidationResults vResults = detailValidator.Validate(detail);
                base.ValidationResults = vResults;
                if (!vResults.IsValid)
                    return 0;
                //− ခရီးစဉ်တာဝန်ခံသည် တူညီသည့် သွားမည့်ရက် နှင့် ပြန်ရောက်မည့်ရက် အတွင်း တစ်ကြိမ်ထက်ပိုသွား၍မရပါ။
                var duplicatedManager = from dts in mdTripPlanDetailDetails
                                        where detail.FromDate >= dts.FromDate && detail.ToDate <= dts.ToDate && dts.ManagerID == detail.ManagerID
                                        select dts;
                if (duplicatedManager.ToArray().Length > 1) // do not allow entry that exceed one entry at most
                {
                    base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.TripPlanDetail_ManagerID_Duplicate,
                        null, "TripPlanDetail_ManagerID_Duplicate", null, null));
                    return 0;
                }
                //- အရောင်းကားသည် တူညီသည့် သွားမည့်ရက် နှင့် ပြန်ရောက်မည့်ရက် အတွင်း တစ်ကြိမ်ထက်ပိုသွား၍မရပါ။
                if (nullVan.ToArray().Length != mdTripPlanDetailDetails.Count) // Skip if all vehicle ids are null
                {
                    var duplicatedVan = from dts in mdTripPlanDetailDetails
                                        where detail.FromDate >= dts.FromDate && detail.ToDate <= dts.ToDate && dts.VenID == detail.VenID
                                        select dts;
                    if (duplicatedVan.ToArray().Length > 1) // do not allow entry that exceed one entry at most
                    {
                        base.ValidationResults.AddResult(
                        new ValidationResult(ErrorMessages.TripPlanDetail_duplicatedVan_Duplicate,
                            null, "TripPlanDetail_duplicatedVan_Duplicate", null, null));
                        return 0;
                    }
                }                
            }

            try
            {
                //− ခရီးစဉ်အမှတ် မထပ်ရ in each new rows with db rows (this validation is set last in sequence bcoz it interacts with database)
                foreach (TripPlanDetail tpDetail in mdTripPlanDetailDetails)
                {
                    DataTable dtDuplicatedTripPlanNo = this.GetBy(tpDetail.TripPlanNo, tpDetail.TripPlanID);
                    if (dtDuplicatedTripPlanNo != null && dtDuplicatedTripPlanNo.Rows.Count > 0)
                    {
                        base.ValidationResults.AddResult(
                            new ValidationResult(ErrorMessages.TripPlanDetail_TripPlanNo_Duplicate,
                                null, "TripPlanDetail_TripPlanNo_Duplicate", null, null));
                        return 0;
                    }
                }
                // Save into db
                return TripPlanDetailDA.Update(mdTripPlanDetailDetails);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "TripPlanDetailBL", null, null));
                return 0;
            }
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Delete TripPlanDetail from system by order ID
        /// </summary>
        /// <param name="TripPlanDetailID">TripPlanDetail ID</param>
        /// <returns>Return affected row count</returns>
        public int DeleteByTripPlanDetailID(int TripPlanDetailID)
        {
            return TripPlanDetailDA.DeleteByTripPlanDetailID(TripPlanDetailID);
        }

        public int Delete(List<TripPlanDetail> tripPlanDetail)
        {
            if (tripPlanDetail == null || tripPlanDetail.Count < 1)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult("Trip Detail ဖြည့်သွင်းပေးပါရန်။",
                        null, "NullTripPlanDetailList", null, null));
                return 0;
            }
            
            foreach(TripPlanDetail detail in tripPlanDetail)
            {
                if(detail.ID < 1)
                {
                    base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.TripPlanDetail_ID_Require,
                        null, "NullTripPlanDetailList", null, null));
                    return 0;
                }
            }

            try
            {
                return TripPlanDetailDA.DeleteByTripPlanDetailID(tripPlanDetail);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "TripPlanDetailBL", null, null));
                return 0;
            }
        }

        public int DeleteByTripPlanID(int TripPlanID, SqlConnection conn)
        {
            return TripPlanDetailDA.DeleteByTripPlanID(TripPlanID, conn);
        }
        #endregion
    }
}

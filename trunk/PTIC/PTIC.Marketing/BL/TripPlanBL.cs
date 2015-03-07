﻿
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, Aung Ko Ko, Wai Phyoe Thu <wpt.osp@gmail.com>
 * Create date: 2014/03/01 (yyyy/MM/dd)
 * Description: TripPlanDetail BL
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using PTIC.Common.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using PTIC.Common.Entities;

namespace PTIC.Marketing.BL
{
    /// <summary>
    /// TripPlan business logic
    /// </summary>
    public class TripPlanBL : BaseBusinessLogic
    {
        #region SELECT
        /// <summary>
        /// Get all TripPlan from system
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all orders</returns>
        public DataTable GetAll(bool is_sale,SqlConnection conn)
        {
            return TripPlanDA.SelectAll(is_sale,conn);
        }
        
        public DataTable GetLost(SqlConnection conn)
        {
          //  return TripPlanDA.SelectLost(conn);
            return null;
        }

        public DataTable SelectBy(DateTime fromDate, DateTime toDate,bool isSale)
        {
            return TripPlanDA.SelectBy(fromDate, toDate,isSale);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDelivered"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataTable GetDelivered(SqlConnection conn)
        {
            //return TripPlanDA.SelectByIsDelivered(true, conn);
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public DataTable GetUndelivered(SqlConnection conn)
        {
            //return TripPlanDA.SelectByIsDelivered(false, conn);
            return null;
        }

        public DataTable GetByNo(string No, SqlConnection conn)
        {
          //  return TripPlanDA.SelectByTripPlanNo(No, conn);
            return null;
        }
        #endregion

        #region INSERT
        /// <summary>
        /// Add a new TripPlan into system
        /// </summary>
        /// <param name="newOrder">New TripPlan entity</param>
        /// <param name="conn">Database connection</param>
        /// <returns>Return affected row count</returns>
        public int Add(TripPlan newTripPlan, SqlConnection conn)
        {
            return TripPlanDA.Insert(newTripPlan, conn);
        }

        public int Add(TripPlan newTripPlan, List<TripPlanDetail> newTripPlanDetails)
        {
            if (newTripPlan == null)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult("ခရီးစဉ် Plan ကို ပြည့်စုံမှန်ကန်စွာ ဖြည့်သွင်းပေးပါရန်။",
                        null, "NullTripPlan", null, null));
                return 0;
            }
            else if (newTripPlanDetails == null || newTripPlanDetails.Count < 1)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult("Trip Detail ဖြည့်သွင်းပေးပါရန်။",
                        null, "NullTripPlanDetailList", null, null));
                return 0;
            }

            // TripPlan validation
            Validator<TripPlan> tpValidator = base.ValidationManager.CreateValidator<TripPlan>();
            ValidationResults vTPResults = tpValidator.Validate(newTripPlan);
            base.ValidationResults = vTPResults;
            if (!vTPResults.IsValid)
                return 0;
            
            //− ခရီးစဉ်အမှတ် မထပ်ရ in each new rows
            var duplicatedTripPlanNo = newTripPlanDetails.GroupBy(x => new { x.TripPlanNo }).Where(x => x.Skip(1).Any()).ToArray();
            if (duplicatedTripPlanNo.Any())
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.TripPlanDetail_TripPlanNo_Duplicate,
                        null, "TripPlanDetail_TripPlanNo_Duplicate", null, null));
                return 0;
            }
              
            // TripPlanDetail validation
            Validator<TripPlanDetail> detailValidator = base.ValidationManager.CreateValidator<TripPlanDetail>();
            // Get vehicle IDs that are null
            var nullVan = from vanFromDts in newTripPlanDetails
                          where vanFromDts.VenID == null
                          select vanFromDts;
            foreach (TripPlanDetail detail in newTripPlanDetails)
            {
                ValidationResults vResults = detailValidator.Validate(detail);
                base.ValidationResults = vResults;
                if (!vResults.IsValid)
                    return 0;
                //− ခရီးစဉ်တာဝန်ခံသည် တူညီသည့် သွားမည့်ရက် နှင့် ပြန်ရောက်မည့်ရက် အတွင်း တစ်ကြိမ်ထက်ပိုသွား၍မရပါ။
                var duplicatedManager = from dts in newTripPlanDetails
                                        where dts.ManagerID == detail.ManagerID
                                            && ((detail.FromDate >= dts.FromDate && detail.FromDate <= dts.ToDate)
                                            || (detail.ToDate >= dts.FromDate && detail.ToDate <= dts.ToDate))
                                        select dts;
                if (duplicatedManager.ToArray().Length > 1) // do not allow entry that exceed one entry at most
                {
                    base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.TripPlanDetail_ManagerID_Duplicate,
                        null, "TripPlanDetail_ManagerID_Duplicate", null, null));
                    return 0;
                }                
                //- အရောင်းကားသည် တူညီသည့် သွားမည့်ရက် နှင့် ပြန်ရောက်မည့်ရက် အတွင်း တစ်ကြိမ်ထက်ပိုသွား၍မရပါ။                
                if (nullVan.ToArray().Length != newTripPlanDetails.Count) // Skip if all vehicle ids are null
                {
                    var duplicatedVan = from dts in newTripPlanDetails
                                        where dts.VenID == detail.VenID
                                            && ((detail.FromDate >= dts.FromDate && detail.FromDate <= dts.ToDate)
                                            || (detail.ToDate >= dts.FromDate && detail.ToDate <= dts.ToDate))
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

            //− ခရီးစဉ်အမှတ် မထပ်ရ in each new rows with db rows (this validation is set last in sequence bcoz it interacts with database)
            TripPlanDetailBL detailBL = new TripPlanDetailBL();
            foreach (TripPlanDetail tpDetail in newTripPlanDetails)
            {
                DataTable dtDuplicatedTripPlanNo = detailBL.GetBy(tpDetail.TripPlanNo, tpDetail.TripPlanID);
                if (dtDuplicatedTripPlanNo != null && dtDuplicatedTripPlanNo.Rows.Count > 0)
                {
                    base.ValidationResults.AddResult(
                        new ValidationResult(ErrorMessages.TripPlanDetail_TripPlanNo_Duplicate,
                            null, "TripPlanDetail_TripPlanNo_Duplicate", null, null));
                    return 0;
                }
            }

            try
            {
                // Save into db
                return TripPlanDA.Insert(newTripPlan, newTripPlanDetails);
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

        #region UPDATE
        /// <summary>
        /// Update an existing TripPlan in system by order ID
        /// </summary>
        /// <param name="mdTripPlan">TripPlan to be updated</param>
        /// <returns>Return affected row count</returns>
        public int UpdateByID(TripPlan mdTripPlan)
        {
            if (mdTripPlan == null)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult("ခရီးစဉ် Plan ကို ပြည့်စုံမှန်ကန်စွာ ဖြည့်သွင်းပေးပါရန်။",
                        null, "NullTripPlan", null, null));
                return 0;
            }
            try
            {
                return TripPlanDA.UpdateByTripPlanID(mdTripPlan);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "TripPlanBL", null, null));
                return 0;
            }
        }

        public int Update(TripPlan mdTripPlan, List<TripPlanDetail> mdTripPlanDetails)
        {
            if (mdTripPlan == null)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult("ခရီးစဉ် Plan ကို ပြည့်စုံမှန်ကန်စွာ ဖြည့်သွင်းပေးပါရန်။",
                        null, "NullTripPlan", null, null));
                return 0;
            }
            else if (mdTripPlanDetails == null || mdTripPlanDetails.Count < 1)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult("Trip Detail ဖြည့်သွင်းပေးပါရန်။",
                        null, "NullTripPlanDetailList", null, null));
                return 0;
            }

            // TripPlan validation
            Validator<TripPlan> tpValidator = base.ValidationManager.CreateValidator<TripPlan>();
            ValidationResults vTPResults = tpValidator.Validate(mdTripPlan);
            base.ValidationResults = vTPResults;
            if (!vTPResults.IsValid)
                return 0;

            //− ခရီးစဉ်အမှတ် မထပ်ရ in each new rows
            var duplicatedTripPlanNo = mdTripPlanDetails.GroupBy(x => new { x.TripPlanNo }).Where(x => x.Skip(1).Any()).ToArray();
            if (duplicatedTripPlanNo.Any())
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.TripPlanDetail_TripPlanNo_Duplicate,
                        null, "TripPlanDetail_TripPlanNo_Duplicate", null, null));
                return 0;
            }

            // Get vehicle IDs that are null
            var nullVan = from vanFromDts in mdTripPlanDetails
                          where vanFromDts.VenID == null
                          select vanFromDts;

            // TripPlanDetail validation
            TripPlanDetailBL detailBL = new TripPlanDetailBL();
            Validator<TripPlanDetail> detailValidator = base.ValidationManager.CreateValidator<TripPlanDetail>();
            foreach (TripPlanDetail detail in mdTripPlanDetails)
            {
                ValidationResults vResults = detailValidator.Validate(detail);
                base.ValidationResults = vResults;
                if (!vResults.IsValid)
                    return 0;
                //− ခရီးစဉ်တာဝန်ခံသည် တူညီသည့် သွားမည့်ရက် နှင့် ပြန်ရောက်မည့်ရက် အတွင်း တစ်ကြိမ်ထက်ပိုသွား၍မရပါ။
                var duplicatedManager = from dts in mdTripPlanDetails
                                        where dts.ManagerID == detail.ManagerID
                                            && ((detail.FromDate >= dts.FromDate && detail.FromDate <= dts.ToDate)
                                            || (detail.ToDate >= dts.FromDate && detail.ToDate <= dts.ToDate))
                                        select dts;
                if (duplicatedManager.ToArray().Length > 1) // do not allow entry that exceed one entry at most
                {
                    base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.TripPlanDetail_ManagerID_Duplicate,
                        null, "TripPlanDetail_ManagerID_Duplicate", null, null));
                    return 0;
                }
                //− ခရီးစဉ်တာဝန်ခံသည် တူညီသည့် သွားမည့်ရက် နှင့် ပြန်ရောက်မည့်ရက် အတွင်း တစ်ကြိမ်ထက်ပိုသွား၍မရပါ။ (validate via db)
                DataTable dtDuplicatedManager = detailBL.GetBy(detail.FromDate, detail.ToDate, new Employee() { ID = detail.ManagerID });
                if (dtDuplicatedManager != null && dtDuplicatedManager.Rows.Count > 0)
                {
                    base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.TripPlanDetail_ManagerID_Duplicate,
                        null, "TripPlanDetail_ManagerID_Duplicate", null, null));
                    return 0;
                }

                //- အရောင်းကားသည် တူညီသည့် သွားမည့်ရက် နှင့် ပြန်ရောက်မည့်ရက် အတွင်း တစ်ကြိမ်ထက်ပိုသွား၍မရပါ။
                if (nullVan.ToArray().Length != mdTripPlanDetails.Count) // Skip if all vehicle ids are null
                {
                    var duplicatedVan = from dts in mdTripPlanDetails
                                        where dts.VenID == detail.VenID
                                            && ((detail.FromDate >= dts.FromDate && detail.FromDate <= dts.ToDate)
                                            || (detail.ToDate >= dts.FromDate && detail.ToDate <= dts.ToDate))
                                        select dts;
                    if (duplicatedVan.ToArray().Length > 1) // do not allow entry that exceed one entry at most
                    {
                        base.ValidationResults.AddResult(
                        new ValidationResult(ErrorMessages.TripPlanDetail_duplicatedVan_Duplicate,
                            null, "TripPlanDetail_duplicatedVan_Duplicate", null, null));
                        return 0;
                    }
                }
                               
                //- အရောင်းကားသည် တူညီသည့် သွားမည့်ရက် နှင့် ပြန်ရောက်မည့်ရက် အတွင်း တစ်ကြိမ်ထက်ပိုသွား၍မရပါ။ (validate via db)
                if (detail.VenID.HasValue)
                {
                    DataTable dtDuplicatedVan = detailBL.GetBy(detail.FromDate, detail.ToDate, detail.VenID.Value);
                    if (dtDuplicatedVan != null && dtDuplicatedVan.Rows.Count > 0)
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
                foreach (TripPlanDetail tpDetail in mdTripPlanDetails)
                {
                    DataTable dtDuplicatedTripPlanNo = detailBL.GetBy(tpDetail.TripPlanNo, mdTripPlan.ID);
                    if (dtDuplicatedTripPlanNo != null && dtDuplicatedTripPlanNo.Rows.Count > 0)
                    {
                        base.ValidationResults.AddResult(
                            new ValidationResult(ErrorMessages.TripPlanDetail_TripPlanNo_Duplicate,
                                null, "TripPlanDetail_TripPlanNo_Duplicate", null, null));
                        return 0;
                    }
                }

                return TripPlanDA.Update(mdTripPlan, mdTripPlanDetails);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "TripPlanBL", null, null));
                return 0;
            }
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Delete TripPlan from system by order ID
        /// </summary>
        /// <param name="TripPlanID">TripPlan ID</param>
        /// <returns>Return affected row count</returns>
        public int DeleteByTripPlanID(int tripPlanID)
        {
            return TripPlanDA.DeleteByTripPlanID(tripPlanID);
        }
        #endregion

        #region Trip Plan Target_BrandName And Amount
        public DataTable GetTripPlanTargetedBrand_Amount_By_TripDtlId(string id)
        {

            return TripPlanDA.GetTripPlanTargetedBrand_Amount_By_TripDtlId(id);
        }

        #endregion

    }
}
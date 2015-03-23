
/*
 * Author:  Wai Phyoe Thu <wpt.osp@gmail.com> 
 * Create date: 2014/03/01 (yyyy/MM/dd)
 * Description: Trip Plan
 */
using System;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Marketing.Entities
{
    /// <summary>
    /// Trip Plan detail entity
    /// </summary>
    [HasSelfValidation]
    public class TripPlanDetail
    {
        #region Properties
        public int ID { get; set; }
        public int TripPlanID { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "TripPlanDetail_ManagerID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int ManagerID { get; set; }

        //[RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
        //            MessageTemplateResourceName = "TripPlanDetail_SalesPersonID_Require",
        //            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int SalesPersonID { get; set; }

        [DomainValidator(
                    (int)PTIC.Common.Enum.PredefinedTransportType.ExpressID, (int)PTIC.Common.Enum.PredefinedTransportType.TrainID,
                    (int)PTIC.Common.Enum.PredefinedTransportType.ShipID, (int)PTIC.Common.Enum.PredefinedTransportType.AirplaneID,
                    (int)PTIC.Common.Enum.PredefinedTransportType.VanID, (int)PTIC.Common.Enum.PredefinedTransportType.OtherID,
                    MessageTemplateResourceName = "TripPlanDetail_TransportTypeID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int TransportTypeID { get; set; }

        public int? VenID { get; set; }

        public string TripPlanNo { get; set; }
        public string TripName { get; set; }
        public int TripID { get; set; }
        public int PersonCount { get; set; }
        public bool SaleType { get; set; }
        public bool SaleType1 { get; set; }
        public bool SaleType2 { get; set; }
        public DateTime TranDate { get; set; }

        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "TripPlanDetail_FromDate_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public DateTime FromDate { get; set; }

        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "TripPlanDetail_ToDate_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public DateTime ToDate { get; set; }

        public string PrevTripName { get; set; }
        public string Accessories { get; set; }
        public decimal Rent { get; set; }
        public decimal Food { get; set; }
        public decimal Transport { get; set; }
        public decimal Communication { get; set; }
        public decimal OtherExp { get; set; }
        public decimal Remittance { get; set; }
        public string Remark { get; set; }
        public string COO_remark { get; set; }
        public string MM_remark { get; set; }
        public string SM_remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        public string TripPlanPurpose { get; set; }
        #endregion

        [SelfValidation]
        public void Check(ValidationResults results)
        {
            if(TransportTypeID == (int)PTIC.Common.Enum.PredefinedTransportType.VanID
                && (!VenID.HasValue || VenID.Value < 1))
                results.AddResult(
                    new ValidationResult(ErrorMessages.TripPlanDetail_VenID_Require,
                        null, "RequireVenID", null, null));
            else if(TransportTypeID != (int)PTIC.Common.Enum.PredefinedTransportType.VanID
                && VenID.HasValue)
                results.AddResult(
                    new ValidationResult(ErrorMessages.TripPlanDetail_VenID_SetNull,
                        null, "SetNullVenID", null, null)); 
        }

    }
}

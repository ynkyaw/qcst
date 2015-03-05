using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Sale.Entities
{
    [HasSelfValidation]
    public class SalesService
    {
        #region Properties      
        public int ID { get; set; }        
        public int ServicedCustomerID { get; set; }
        public string SalesServiceNo { get; set; }

        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "SalesService_ReceivedDate_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public DateTime ReceivedDate { get; set; }

        public DateTime? ReturnedDate { get; set; }
        public string ProductionDate { get; set; }
        public string PurchaseDate { get; set; }
        public string Giver { get; set; }
        public int? TakerID { get; set; }
        public int? GiverID { get; set; }
        public string Taker { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "SalesService_ProductID_Select",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int ProductID { get; set; }

        public int ReceiveVia { get; set; }
        public string JobCardNo { get; set; }
        public string JobNo { get; set; }
        public string WarrantyNo { get; set; }
        //public string ShopName { get; set; }
        public int UsedDuration { get; set; }
        public string UsedPlace { get; set; }
        public int UsedAmp { get; set; }
        public int UsedSize { get; set; }
        public int ChargingTime { get; set; }
        public string ContinuousUsedTime { get; set; }

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "SalesService_DateToSvc_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public DateTime? DateToSvc { get; set; }

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "SalesService_SeviceDate_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public DateTime? SeviceDate { get; set; }

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "SalesService_DateToFactory_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public DateTime? DateToFactory { get; set; }

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "SalesService_DateFromFactory_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public DateTime? DateFromFactory { get; set; }

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "SalesService_DateFromSvc_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public DateTime? DateFromSvc { get; set; }

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "SalesService_ContactDateToCustomer_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public DateTime? ContactDateToCustomer { get; set; }

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "SalesService_DateToCustomer_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public DateTime? DateToCustomer { get; set; }

        [DomainValidator(
                    (int)PTIC.Common.Enum.CustomerSalesService.NewBattery, (int)PTIC.Common.Enum.CustomerSalesService.CVC_Battery,
                    (int)PTIC.Common.Enum.CustomerSalesService.Repair, (int)PTIC.Common.Enum.CustomerSalesService.Other,
                    MessageTemplateResourceName = "SalesService_Service_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int Service { get; set; }
        
        public int? VenID { get; set; }
        public int? WarehouseID { get; set; }
        public bool IsReturned { get; set; }

        //[DomainValidator(
        //            (int)PTIC.Common.Enum.SalesServiceWhereami.Vehicle, (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom,
        //            (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore, (int)PTIC.Common.Enum.SalesServiceWhereami.MainStore,
        //            (int)PTIC.Common.Enum.SalesServiceWhereami.Customer,
        //            MessageTemplateResourceName = "SalesService_Whereami_Require",
        //            MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int? Whereami { get; set; }

        public bool IsBackward { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }       
       #endregion

        #region Self Validation
        [SelfValidation]
        public void Validate(ValidationResults results)
        {
            if(string.IsNullOrEmpty(Giver) && !GiverID.HasValue)
                results.AddResult(
                    new ValidationResult(ErrorMessages.SalesService_Giver_Require,
                        null, "RequireGiver", null, null));
            else if(string.IsNullOrEmpty(Taker) && !TakerID.HasValue)            
                results.AddResult(
                    new ValidationResult(ErrorMessages.SalesService_Taker_Require,
                        null, "RequireTaker", null, null));
            else if(
                ID > 0
                && (string.IsNullOrEmpty(JobNo) || JobNo.Length < 1)
                )
                results.AddResult(
                    new ValidationResult(ErrorMessages.SalesService_JobNo_Require,
                        null, "RequireJobNo", null, null));
        }
        #endregion
    }
}

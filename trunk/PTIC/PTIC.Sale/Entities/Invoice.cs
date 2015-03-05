using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Sale.Entities
{
    [HasSelfValidation]
    public class Invoice
    {
        public int? ID {get;set;}
        
        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "Invoice_DeliveryID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int? DeliveryID { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "Invoice_CusID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int CusID {get;set;}

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "Invoice_SalesPersonID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int SalesPersonID {get;set;}

        [RangeValidator(0, RangeBoundaryType.Inclusive, 1, RangeBoundaryType.Inclusive,
                    MessageTemplateResourceName = "Invoice_SaleType_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int SaleType { get; set; } // 0: Credit 1: Cosignment

        [RangeValidator(1, RangeBoundaryType.Inclusive, 6, RangeBoundaryType.Inclusive,
                    MessageTemplateResourceName = "Invoice_TransportTypeID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int TransportTypeID {get;set;}

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "Invoice_TransportGateID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int? TransportGateID {get;set;}

        public string InvoiceNo {get;set;}

        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "Invoice_SalesDate_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public DateTime SalesDate {get;set;}

        public string GateInvNo {get;set;}
        public int TransportCharges {get;set;}

        [RangeValidator(typeof(decimal), "1", RangeBoundaryType.Inclusive, "0", RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "Invoice_TotalAmt_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public decimal TotalAmt { get; set; }

        //public int Refree1 {get;set;}
        //public int Refree2 {get;set;}

        public decimal CommDiscAmt {get;set;}
        public decimal OtherAmt {get;set;}
        public decimal NetAmt {get;set;}
        public decimal PaidAmt {get;set;}
        public decimal BalanceAmt {get;set;}
        public bool IsMain {get;set;}
        public bool IsDevice {get;set;}

        [RangeValidator(0, RangeBoundaryType.Inclusive, 1, RangeBoundaryType.Inclusive,
                    MessageTemplateResourceName = "Invoice_VoucherType_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int VoucherType { get; set; } // 0 :Credit 1:Cash
        
        public bool Paid { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded {get;set;}
        public DateTime LastModified {get;set;}
        public bool IsDeleted { get; set; }

        [SelfValidation]
        public void Check(ValidationResults results)
        {
            if (CommDiscAmt >= TotalAmt)
                results.AddResult(new ValidationResult(ErrorMessages.Invoice_CommDiscAmt_GreaterThan_Total, this, "", "", null));
        }


    }
}

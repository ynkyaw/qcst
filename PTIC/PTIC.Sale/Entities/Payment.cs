/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: Payment entity bean class
 */
using System;
using PTIC.Common;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
namespace PTIC.Sale.Entities
{
    /// <summary>
    /// Payment entity class
    /// </summary>
    public class Payment
    {        
        #region Properties
        //[DBField("ID")]
        public int ID { get; set; }

        [DBField("InvoiceID")]
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "Payment_InvoiceID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int? InvoiceID { get; set; }

        [DBField("PayType")]
        //[DomainValidator(
        //            PTIC.Common.Enum.PayType.First, 
        //            PTIC.Common.Enum.PayType.Partial,
        //            PTIC.Common.Enum.PayType.Final,
        //            MessageTemplateResourceName = "Payment_PayType_Require",
        //            MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public PTIC.Common.Enum.PayType PayType { get; set; }

        [DBField("CashReceiptType")]
        //[DomainValidator(
        //            (int)PTIC.Common.Enum.CashReceiptType.Cash,
        //            (int)PTIC.Common.Enum.CashReceiptType.Cheque,
        //            (int)PTIC.Common.Enum.CashReceiptType.Remittance,
        //            MessageTemplateResourceName = "Payment_CashReceiptType_Require",
        //            MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public PTIC.Common.Enum.CashReceiptType CashReceiptType { get; set; }

        [DBField("BankID")]
        public int? BankID { get; set; }
        [DBField("SalesPersonID")]
        public int SalesPersonID { get; set; }
        //[DBField("ReceiptNo")]
        public string ReceiptNo { get; set; }
        [DBField("PayDate")]
        public DateTime PayDate { get; set; }
        [DBField("TotalAmt")]
        public decimal TotalAmt { get; set; }
        [DBField("CommDisAmt")]
        public decimal CommDisAmt { get; set; }
        [DBField("OtherAmt")]
        public decimal OtherAmt { get; set; }
        //[DBField("NetAmt")]
        public decimal NetAmt { get; set; }

        [DBField("PaidAmt")]
        [RangeValidator(typeof(decimal), "1", RangeBoundaryType.Inclusive, "0", RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "Payment_PaidAmt_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public decimal PaidAmt { get; set; }

        //[DBField("BalanceAmt")]
        public decimal BalanceAmt { get; set; }
        //[DBField("IsMain")]
        public bool IsMain { get; set; }
        //[DBField("IsDevice")]
        public bool IsDevice { get; set; }
        //[DBField("DateAdded")]
        public DateTime DateAdded { get; set; }
        //[DBField("LastModified")]
        public DateTime LastModified { get; set; }
        //[DBField("IsDeleted")]
        public bool IsDeleted { get; set; }
        #endregion
    }

}

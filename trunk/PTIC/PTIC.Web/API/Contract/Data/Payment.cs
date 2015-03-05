using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class Payment
    {
        #region Properties
        [DataMember]
        public int? InvoiceID { get; set; }
        [DataMember]
        public int PayType { get; set; }
        [DataMember]
        public int CashReceiptType { get; set; }
        [DataMember]
        public int? BankID { get; set; }
        [DataMember]
        public int SalesPersonID { get; set; }
        [DataMember]
        public string SalesPerson { get; set; }
        [DataMember]
        public string ReceiptNo { get; set; }
        [DataMember]
        public DateTime PayDate { get; set; }
        [DataMember]
        public decimal CommDisAmt { get; set; }
        [DataMember]
        public decimal OtherAmt { get; set; }
        [DataMember]
        public decimal PaidAmt { get; set; }
        [DataMember]
        public decimal BalanceAmt { get; set; }
       #endregion
    }
}
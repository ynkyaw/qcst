
using System.Runtime.Serialization;
namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class CommDiscount
    {
        #region Properties
        [DataMember]
        public int? ID { get; set; }
        [DataMember]
        public int? InvoiceID { get; set; }
        [DataMember]
        public int? SaleCommID { get; set; }
        [DataMember]
        public int? CashCommID { get; set; }
        [DataMember]
        public decimal PackingAmt { get; set; }
        [DataMember]
        public decimal SaleCommAmt { get; set; }
        [DataMember]
        public decimal CashCommAmt { get; set; }
        [DataMember]
        public decimal OtherCommAmt { get; set; }
        [DataMember]
        public decimal RefundAmt { get; set; }
        [DataMember]
        public decimal NeedAmt { get; set; }
        [DataMember]
        public decimal TotalCommAmt { get; set; }
        #endregion
    }
}
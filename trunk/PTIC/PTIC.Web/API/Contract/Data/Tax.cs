
using System.Runtime.Serialization;
namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class Tax
    {
        #region Properties
        [DataMember]
        public int? ID { get; set; }
        [DataMember]
        public int? InvoiceID { get; set; }
        [DataMember]
        public decimal InsuranceAmt { get; set; }
        [DataMember]
        public decimal TaxAmt { get; set; }
        [DataMember]
        public decimal TransportAmt { get; set; }
        [DataMember]
        public decimal TotalAmt { get; set; }
        [DataMember]
        public string GateInvNo { get; set; }
        [DataMember]
        public byte[] GateInvPhoto { get; set; }
        #endregion
    }
}
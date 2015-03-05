
using System.Runtime.Serialization;
namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class OrderDetail
    {
        #region Properties
        [DataMember]
        public int OrderDetailID { get; set; }
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public decimal WSPrice { get; set; }
        [DataMember]
        public decimal RSPrice { get; set; }
        [DataMember]
        public int Qty { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public string Remark { get; set; }        
        #endregion
    }
}
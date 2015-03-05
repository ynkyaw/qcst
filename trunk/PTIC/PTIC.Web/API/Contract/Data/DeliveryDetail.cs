using System;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class DeliveryDetail
    {
        #region Properties
        [DataMember]
        public int DeliveryDetailID { get; set; }
        [DataMember]
        public int DeliveryID { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public int OrderQty { get; set; }
        [DataMember]
        public int DeliverQty { get; set; }
        #endregion
    }
}
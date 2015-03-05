using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class Delivery
    {
        #region Properties
        [DataMember]
        public int DeliveryID { get; set; }
        [DataMember]
        public int OrderID { get; set; }
        [DataMember]
        public string OrderNo { get; set; }
        [DataMember]
        public int VenID { get; set; }
        [DataMember]
        public int CusID { get; set; }
        [DataMember]
        public int SalesPersonID { get; set; }
        //public int TransportTypeID { get; set; }
        [DataMember]
        public int? GateID { get; set; }
        [DataMember]
        public string DeliveryNo { get; set; }
        [DataMember]
        public string DeliveryDate { get; set; }
        //public DateTime DeliveryDate { get; set; }
        [DataMember]
        public bool Status { get; set; }
        #endregion
    }
}
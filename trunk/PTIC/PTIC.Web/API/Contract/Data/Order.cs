
using System.Runtime.Serialization;
using System.Collections.Generic;
using System;
namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class Order
    {
        #region Properties
        [DataMember]
        public int? OrderID { get; set; }
        [DataMember]
        public int CusID { get; set; }
        [DataMember]
        public int OrderReceieverID { get; set; }
        [DataMember]
        public string OrderNo { get; set; }
        [DataMember]
        public DateTime OrderDate { get; set; }
        [DataMember]
        public List<OrderDetail> OrderDetails { get; set; }
        #endregion
    }
}
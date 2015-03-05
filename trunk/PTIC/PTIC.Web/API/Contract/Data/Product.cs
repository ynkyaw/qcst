using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class Product
    {
        #region Properties
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public int NoPerPack { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string WholeSaleNo { get; set; }
        [DataMember]
        public decimal WholeSalePrice { get; set; }
        [DataMember]
        public string RetailSaleNo { get; set; }
        [DataMember]
        public decimal RetailSalePrice { get; set; }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class ProductPrice
    {
        #region Properties
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string BrandName { get; set; }
        [DataMember]
        public int Plate { get; set; }
        [DataMember]
        public decimal AcidPrice { get; set; }        
        [DataMember]
        public decimal WholeSalePrice { get; set; }        
        [DataMember]
        public decimal RetailSalePrice { get; set; }
        [DataMember]
        public decimal WSPriceWithAcid { get; set; }
        [DataMember]
        public decimal RSPriceWithAcid { get; set; }
        #endregion
    }
}
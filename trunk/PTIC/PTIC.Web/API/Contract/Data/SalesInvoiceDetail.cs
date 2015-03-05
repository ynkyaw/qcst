using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class SalesInvoiceDetail
    {
        #region Properties
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int InvoiceID { get; set; }
        [DataMember]
        public int BrandID { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public int SalePrice { get; set; }
        [DataMember]
        public int Qty { get; set; }
        [DataMember]
        public int Package { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
        #endregion
    }
}
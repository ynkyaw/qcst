using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class SalesReturnIn
    {
        #region Properties
        [DataMember]
        public int SalesReturnInID { get; set; }
        [DataMember]
        public int VenID { get; set; }
        [DataMember]
        public int SaleDetailID { get; set; }
        [DataMember]
        public int ProuductID { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int SalePersonID { get; set; }
        [DataMember]
        public int Qty { get; set; }
        [DataMember]
        public string Remark { get; set; }
        #endregion
    }
}
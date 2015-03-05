using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class MarketingDetail
    {
        #region Properties
        [DataMember]
        public int? ID { get; set; }
        [DataMember]
        public int? CusID { get; set; }
        [DataMember]
        public int? EmpID { get; set; }
        [DataMember]
        public int? MarketingPlanID { get; set; }
        [DataMember]
        public int? BrandID { get; set; }
        [DataMember]
        public int? OrderID { get; set; }
        [DataMember]
        public int? A_P_UsageID { get; set; }
        [DataMember]
        public int? CustomerComplaintID { get; set; }
        [DataMember]
        public int? CompetitorActivityID { get; set; }
        [DataMember]
        public DateTime MarketedDate { get; set; }
        //[DataMember]
        //public DateTime DateAdded { get; set; }
        //public DateTime LastModified { get; set; }
        //public bool IsDeleted { get; set; }
        #endregion
    }
}
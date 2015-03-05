using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class MobileServicePlan
    {
        #region Properties
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int TownshipID { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public int CusTypeID { get; set; }
        [DataMember]
        public String SvcPlanNo { get; set; }
        [DataMember]
        public DateTime SvcPlanDate { get; set; }
        //[DataMember]
        //public int InitialMobileServicePlanID { get; set; }
        //[DataMember]
        //public int Status { get; set; }
        //[DataMember]
        //public bool IsConfirmed { get; set; }
        //public DateTime DateAdded { get; set; }
        //public DateTime LastModified { get; set; }
        //public bool IsDeleted { get; set; }
        #endregion
    }
}
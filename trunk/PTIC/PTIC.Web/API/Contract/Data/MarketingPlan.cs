using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class MarketingPlan
    {
        #region Properties
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public int EmpID { get; set; }
        //public int CusTypeID { get; set; }
        [DataMember]
        public DateTime PlanDate { get; set; }
        //TODO: InitialMarketingPlanID နှင့် TeleMarketingInitialPlanID 
        //[DataMember]
        //public int InitialMarketingPlanID { get; set; }
        //[DataMember]
        //public int TeleMarketingInitialPlanID { get; set; }
        [DataMember]
        public int MarketingType { get; set; } // 0:Marketing 1:Telemarketing 2:Mobile Service
        [DataMember]
        public int Status { get; set; } // 0: Report 1: Confirm 2: Reject
        //public DateTime DateAdded { get; set; }
        //public DateTime LastModified { get; set; }
        //public bool IsDeleted { get; set; }
        #endregion
    }
}
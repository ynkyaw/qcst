using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
     [DataContract]
    public class Trip
    {
        #region Properties
        [DataMember]
        public int TripID { get; set; }
        [DataMember]
        public string TripName { get; set; }
        [DataMember]
        public int TripPeriod { get; set; }
        [DataMember]
        public string Remark { get; set; }
        #endregion
    }
}
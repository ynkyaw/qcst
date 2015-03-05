using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class BatteryStatus
    {
        #region Properties
        [DataMember]
        public string BrandName { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public DateTime ReceivedDate { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool InShowRoom { get; set; }
        [DataMember]
        public bool InVehicle { get; set; }
        [DataMember]
        public bool InServiceTeam { get; set; }
        [DataMember]
        public bool InMainStore { get; set; }
        [DataMember]
        public string Whereami { get; set; }
        #endregion
    }
}
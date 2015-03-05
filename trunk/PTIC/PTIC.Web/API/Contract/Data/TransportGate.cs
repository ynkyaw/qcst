using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class TransportGate
    {
        #region Properties
        [DataMember]
        public int TransportGateID { get; set; }
        [DataMember]
        public int TransportTypeID { get; set; }
        [DataMember]
        public String GateName { get; set; }
        [DataMember]
        public String Remark { get; set; }
        #endregion
    }
}
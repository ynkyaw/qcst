using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class TransportType
    {
        #region Properties
        [DataMember]
         public int TransportTypeID { get; set; }
        [DataMember]
        public String TransportTypeName { get; set; }
        #endregion
    }
}
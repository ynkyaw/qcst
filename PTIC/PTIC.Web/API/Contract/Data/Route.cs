using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
     [DataContract]
    public class Route
    {
        #region Properties
        [DataMember]
        public int RouteID { get; set; }
        [DataMember]
        public string RouteName { get; set; }
        [DataMember]
        public string Remark { get; set; }       
        #endregion
    }
}
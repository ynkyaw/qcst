using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class CompetitorBrand
    {
        #region Properties
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string CompetitorBrands { get; set; }
        [DataMember]
        public string Remark { get; set; }      
        #endregion
    }
}
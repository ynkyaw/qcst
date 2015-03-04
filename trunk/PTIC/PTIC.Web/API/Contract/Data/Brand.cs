using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class Brand
    {
        #region Properties	
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public String BrandName { get; set; }
        //public bool IsOwnBrand { get; set; }
        //public DateTime ConfirmDate { get; set; }
        //public String Company { get; set; }
        //public String Phone1 { get; set; }
        //public String Phone2 { get; set; }
        //public DateTime StartDate { get; set; }
        //public String Remark { get; set; }
        //public string CompetitorProduct { get; set; }
        #endregion
    }
}
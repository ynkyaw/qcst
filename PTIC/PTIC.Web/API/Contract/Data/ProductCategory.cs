using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    public class ProductCategory
    {
        #region
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int BrandID { get; set; }
        [DataMember]
        public String CategoryName { get; set; }
        [DataMember]
        public String Remark { get; set; }
        #endregion
    }
}
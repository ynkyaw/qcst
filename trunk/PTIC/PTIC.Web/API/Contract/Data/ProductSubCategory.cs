using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class ProductSubCategory
    {
        #region
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public String SubCategoryName { get; set; }
        [DataMember]
        public String Remark { get; set; }
        #endregion
    }
}
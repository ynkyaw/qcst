using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class AP_RequestDetail
    {
        #region Properties
        public int ID { get; set; }
        public int AP_RequestID { get; set; }
        public int AP_MaterialID { get; set; }
        public int RequestQty { get; set; }
        public int RequestPurpose{get;set;}
        public String Remark{get;set;}
         public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

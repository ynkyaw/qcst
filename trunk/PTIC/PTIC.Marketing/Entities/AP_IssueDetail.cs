using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class AP_IssueDetail
    {
        #region Properties
        public int ID { get; set; }
        public int AP_RequestDetailID { get; set; }       
        public DateTime IssueDate { get; set; }
        public int IssueQty { get; set; }
        public int? FromDeptID { get; set; }
        public int? FromVenID { get; set; }
        public int? ToDeptID { get; set; }
        public int? ToVenID { get; set; }
        public int FromEmpID { get; set; }
        public int ToEmpID { get; set; }
        public String Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

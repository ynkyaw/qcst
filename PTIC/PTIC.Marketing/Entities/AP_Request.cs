using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class AP_Request
    {
        #region Properties
        public int ID { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime RequestDate { get; set; }
        public String RequestNo { get; set; }
        public int? RequestVenID { get; set; }
        public int? RequestDeptID { get; set; }
        public int RequesterID { get; set; }
        public int IssueDeptID { get; set; }
        public int IssueEmployeeID { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

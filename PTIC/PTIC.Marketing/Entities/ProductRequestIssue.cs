using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.VC.Marketing.Entities
{
    public class ProductRequestIssue
    {
        #region Properties
        public int ID { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime IssueDate { get; set; }
        public int? RequesterID { get; set; }
        public int? IssuerID{get;set;}
        public int? RequestDeptID { get; set; }
        public int? RequestVenID { get; set; }
        public int? IssueDeptID { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsIssued { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.VC.Marketing.Entities
{
    public class ProductRequestIssueDetail
    {
        #region Properties
        public int ID { get; set; }
        public int ProductRequestIssueID { get; set; }
        public int ProductID { get; set; }
        public int RequestQty { get; set; }
        public int IssueQty { get; set; }
        public int Weight { get; set; }
        public int Purpose { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

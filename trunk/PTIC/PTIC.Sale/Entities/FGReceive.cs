using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class FGReceive
    {
        #region Properties
        public int ID { get; set; }
        public string RecVouNo { get; set; }
        public int FGReqID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

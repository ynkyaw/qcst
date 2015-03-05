using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class FGReceiveDetail
    {
        #region Properties
        public int ID { get; set; }
        public int FGRecID { get; set; }
        public int ProductID { get; set; }
        public DateTime ProduceDate { get; set; }
        public int IssueQty { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

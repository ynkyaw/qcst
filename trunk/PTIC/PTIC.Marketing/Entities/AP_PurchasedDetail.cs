using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class AP_PurchasedDetail
    {
        #region Properties
        public int ID { get; set; }
        public int AP_EnquiryDetailID { get; set; }
        public DateTime PurchasedDate { get; set; }
        public int EntryPersonID { get; set; }
        public int DeptID { get; set; }
        public int PurchasedQty { get; set; }
        public int PresentQty { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime IsDeleted { get; set; }
        #endregion
    }
}

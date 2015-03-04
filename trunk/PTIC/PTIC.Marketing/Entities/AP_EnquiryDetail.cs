using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class AP_EnquiryDetail
    {
        #region Properties
        public int ID { get; set; }
        public int AP_EnquiryID { get; set; }
        public int SupplierID { get; set; }
        public int AP_MaterialID { get; set; }
        public DateTime EnquiryDate { get; set; }
        public int ApprovedQty { get; set; }
        public int RevisedQty { get; set; }
        public decimal UnitCost { get; set; }
        public DateTime LastRequireDate { get; set; }
        public bool IsAccepted { get; set; }
        public String Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

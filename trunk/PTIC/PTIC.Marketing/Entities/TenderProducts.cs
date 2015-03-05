using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class TenderProducts
    {
        public int ID { get; set; }
        public int TenderInfoID { get; set; }
        public string TproductName { get; set; }
        public int Tqty { get; set; }
        public decimal Tprice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}

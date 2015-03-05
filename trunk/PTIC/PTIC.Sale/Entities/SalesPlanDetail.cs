using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class SalesPlanDetail
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int SalesPlanID { get; set; }
        public decimal retailPrice { get; set; }
        public int SaleQty { get; set; }
        public int ProduceQty { get; set; }
        public int RequireQty { get; set; }
        public decimal Nconvert { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}

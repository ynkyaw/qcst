using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class SalesPlan
    {
        public int ID { get; set; }
        public DateTime PlanDate { get; set; }
        public decimal SalesPlanAmt { get; set; }
        public int Status { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }

    }
}

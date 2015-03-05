using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class A_P_PlanDetail
    {
        public int A_P_PlanDetailID { get; set; }
        public int A_P_PlanID { get; set; }
        public int BrandID { get; set; }
        public int A_P_MaterialID { get; set; }
        public decimal UsageAmt { get; set; }
        public float TotalAmtPercent { get; set; }
        public float SalePlanPercent { get; set; }
        //
        //public DateTime DateAdded { get; set; }
        //public DateTime LastModified { get; set; }
        //public bool IsDeleted { get; set; }
    }
}

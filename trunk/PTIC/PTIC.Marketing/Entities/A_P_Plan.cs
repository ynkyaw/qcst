using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class A_P_Plan
    {
         #region Entities

        public int A_P_PlanID { get; set; }
        public DateTime A_P_PlanDate { get; set; }
        public decimal SalePlanAmt { get; set; }
        public int Status { get; set; }
        //
        //public DateTime DateAdded { get; set; }
        //public DateTime LastModified { get; set; }
        //public bool IsDeleted { get; set; }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common;

namespace PTIC.Marketing.Entities
{
    public class InitialMobileServicePlan
    {
        #region Properties
        //[DBField("ID")]
        public int ID { get; set; }
        [DBField("IntialPlanDate")]
        public DateTime InitialPlanDate { get; set; }
        [DBField("Day")]
        public int Day { get; set; }
        [DBField("RouteID")]
        public int RouteID { get; set; }
        [DBField("Remark")]
        public string Remark { get; set; }
        //[DBField("DateAdded")]
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        //[DBField("IsDeleted")]
        public bool IsDeleted { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Marketing.Entities
{
    public class InitialMarketingPlan
    {
        #region Properties
        //[DBField("ID")]
        public int ID { get; set; }
        [DBField("IntialPlanDate")]
        public DateTime InitialPlanDate { get; set; }
        [DBField("Day")]
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "InitialMarketingPlan_Day_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int Day { get; set; }
        [DBField("RouteID")]
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "InitialMarketingPlan_RouteID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
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

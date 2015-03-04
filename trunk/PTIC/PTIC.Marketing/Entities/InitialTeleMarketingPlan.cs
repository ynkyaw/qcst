using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Marketing.Entities
{
    public class InitialTeleMarketingPlan
    {
        #region Properties
        public int ID { get; set; }
         [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "InitialTeleMarketingPlan_PlanDate_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public DateTime PlanDate { get; set; }
         [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "InitialTeleMarketingPlan_GruopID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int GroupID { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

/*
 * Author:  AUNGKOKO<aungkoko@asiagreenleaf.com>
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: MobileServicePlan entity bean class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Marketing.Entities
{
    public class MobileServicePlan
    {
        #region Properties
        public int ID { get; set; }

        public String SvcPlanNo { get; set; }

        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                       MessageTemplateResourceName = "MobileServiecPlan_SvcPlanDate_Require",
                   MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public DateTime SvcPlanDate { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "MobileServiecPlan_TownshipID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int TownshipID { get; set; }

        public int CusTypeID { get; set; }

       [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                  MessageTemplateResourceName = "MobileServiecPlan_CustomerID_Require",
                  MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
       public int CustomerID { get; set; }
        
        public int InitialMobileServicePlanID { get; set; }
        public int Status { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

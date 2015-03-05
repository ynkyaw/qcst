
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, Aung Ko Ko, Wai Phyoe Thu <wpt.osp@gmail.com>
 * Create date: 1 March 2014
 * Description: About Trip Plan
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Marketing.Entities
{
    /// <summary>
    /// TripPlan entity
    /// </summary>
    public class TripPlan
    {
        #region Properties
        public int ID { get; set; }
        public string TripPlanNo { get; set; }

        //[DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
        //                MessageTemplateResourceName = "TripPlan_TranDate_Require",
        //            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public DateTime TranDate { get; set; }

        [NotNullValidator(
                    MessageTemplateResourceName = "TripPlan_TripPlanName_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        [StringLengthValidator(1, 50,
            MessageTemplateResourceName = "TripPlan_TripPlanName_Require",
            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public string TripPlanName { get; set; }

        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "TripPlan_FromDate_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public DateTime FromDate { get; set; }

        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "TripPlan_ToDate_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public DateTime ToDate { get; set; }

        public bool IsSale { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

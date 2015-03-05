using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Marketing.Entities
{
    public class ComplaintExplanation
    {
        #region Properties
        public int ID { get; set; }
        public int ComplaintRegisterID { get; set; }

        [NotNullValidator(MessageTemplateResourceName = "ComplaintExplanation_Explanation_Require",
            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        [StringLengthValidator(1, 500,
            MessageTemplateResourceName = "ComplaintExplanation_Explanation_Require",
            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public string Explanation { get; set; }

        [NotNullValidator(MessageTemplateResourceName = "ComplaintExplanation_Action_Require",
            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        [StringLengthValidator(1, 500,
            MessageTemplateResourceName = "ComplaintExplanation_Action_Require",
            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public string Action { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "ComplaintExplanation_ExplainedByEmployeeID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int ExplainedByEmployeeID { get; set; }

        public string ExplainedByEmployee { get; set; }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Marketing.Entities
{
    public class ComplaintRegister
    {
        #region Properties
        public int ID { get; set; }
        public string MsgNo { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "ComplaintRegister_ComplaintReceiveID_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int ComplaintReceiveID { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "ComplaintRegister_ToEmployeeID_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int ToEmployeeID { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "ComplaintRegister_FromEmployeeID_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int FromEmployeeID { get; set; }

        public string ToEmployee { get; set; }
        public string FromEmployee{get;set;}

        public int? DepartmentIDClosed { get; set; }
        public DateTime ClosedDate { get; set; }
        #endregion
    }
}

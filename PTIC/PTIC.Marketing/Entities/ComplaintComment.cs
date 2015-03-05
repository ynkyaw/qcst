using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Marketing.Entities
{
    public class ComplaintComment
    {
        #region Properties
        public int ID { get; set; }
        public int ComplaintRegisterID { get; set; }

        //[NotNullValidator(MessageTemplateResourceName = "ComplaintComment_Comment_Require",
        //    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        //[StringLengthValidator(1, 500,
        //    MessageTemplateResourceName = "ComplaintComment_Comment_Require",
        //    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public string Comment { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "ComplaintComment_CommentByEmployeeID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int CommentByEmployeeID { get; set; }

        public string CommentByEmployee { get; set; }
        #endregion
    }
}

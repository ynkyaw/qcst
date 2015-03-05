using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Common.Entities
{    
    public class Message
    {
        #region Properties        
        public int ID { get; set; }

        [NotNullValidator(MessageTemplateResourceName = "Message_Subject_Require",
                    MessageTemplateResourceType = typeof(PTIC.Common.ErrorMessages))]
        [StringLengthValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,            
            MessageTemplateResourceName = "Message_Subject_Require",
                    MessageTemplateResourceType = typeof(PTIC.Common.ErrorMessages))]
        public string Subject { get; set; }

        public string Body { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

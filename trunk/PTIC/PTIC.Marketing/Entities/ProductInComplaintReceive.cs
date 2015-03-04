using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Marketing.Entities
{
    public class ProductInComplaintReceive
    {
        #region Properties
        public int ID { get; set; }        
        public int ComplaintReceiveID { get; set; }
        
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "ProductInComplaintReceive_ProductID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int ProductID { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "ProductInComplaintReceive_Qty_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int Qty { get; set; }

        [NotNullValidator(MessageTemplateResourceName = "ComplaintReceive_ProductionDate_Require",
            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        [StringLengthValidator(1, 30,
            MessageTemplateResourceName = "ComplaintReceive_ProductionDate_Require",
            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public string ProductionDate { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "ProductInComplaintReceive_ComplaintCaseID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int ComplaintCaseID { get; set; }
        #endregion
    }
}

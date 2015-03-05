/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   A_P_UsageDetail
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Marketing.Entities
{
    public class A_P_UsageDetail
    {
        #region Entities
        public int A_P_UsageDetailID { get; set; }
        public int A_P_UsageID { get; set; }
        //public int A_PID { get; set; }
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "A_P_UsageDetail_A_P_MaterialID_Select",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int A_P_MaterialID { get; set; }
        public int BrandID { get; set; }
         [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "A_P_UsageDetail_Qty_Select",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int Qty { get; set; }
        public string Remark { get; set; }        
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

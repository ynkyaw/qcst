/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   SupplierType
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Marketing.Entities
{
    public class SupplierType
    {
        #region Entities
                
        public int SupplierTypeID { get; set; }

        [NotNullValidator( MessageTemplateResourceName = "SupplierType_SupplierTypeName_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        [StringLengthValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
            MessageTemplateResourceName = "SupplierType_SupplierTypeName_Require",
            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public String SupplierTypeName { get; set; }
        //
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
    }
}

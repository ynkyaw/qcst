/* Author   :   Aung Ko Ko, Wai Phyoe Thu<wpt.osp@gmail.com>
    Date      :   21 Feb 2014
    Description :   Supplier
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Marketing.Entities
{
    public class Supplier
    {
        #region Entities
        public int SupplierID { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "Supplier_SupTypeID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public int SupTypeID { get; set; }

        public String Address { get; set; }

        [NotNullValidator(MessageTemplateResourceName = "Supplier_SupplierName_Require",
            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        [StringLengthValidator(1, 50,
            MessageTemplateResourceName = "Supplier_SupplierName_Require",
            MessageTemplateResourceType = typeof(PTIC.Marketing.ErrorMessages))]
        public String SupplierName { get; set; }

        public String ContactPerson { get; set; }
        public String ContactPhone { get; set; }
        public String Phone1 { get; set; }
        public String Phone2 { get; set; }        
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
    }
}

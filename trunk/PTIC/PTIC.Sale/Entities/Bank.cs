/* Author   :   Aung Ko Ko
    Date      :   20 Feb 2014
    Description :   Bank Entity
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Sale.Entities
{
    public class Bank
    {
        #region Entities
		 
	    public int BankID { get; set; }
        [NotNullValidator(MessageTemplateResourceName = "Bank_BankName_Require",
                          MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        [StringLengthValidator(1, 50, MessageTemplateResourceName = "Bank_BankName_Require",
                          MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public String BankName { get; set; }
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "Bank_TownID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int TownID { get; set; }
        public String BankAddress { get; set; }
        public String Phone { get; set; }
        //public String Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

/* Author   :   Aung Ko Ko
    Date      :   11 Feb 2014
    Description :   Brand Entity
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Sale.Entities
{
    public class Brand
    {
        #region
        public int ID { get; set; }
        [NotNullValidator(MessageTemplateResourceName = "Brand_BrandName_Require",
                          MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        [StringLengthValidator(1, 50, MessageTemplateResourceName = "Brand_BrandName_Require",
                          MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public String BrandName { get; set; }
        [NotNullValidator(MessageTemplateResourceName = "Brand_CompetitorProductName_Require",
                          MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        [StringLengthValidator(1, 50, MessageTemplateResourceName = "Brand_CompetitorProductName_Require",
                          MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public string CompetitorProduct { get; set; }
        public bool IsOwnBrand { get; set; }
        public DateTime ConfirmDate{get;set;}
        [NotNullValidator(MessageTemplateResourceName = "Brand_CompanyName_Require",
                          MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        [StringLengthValidator(1, 50, MessageTemplateResourceName = "Brand_CompanyName_Require",
                          MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public String Company { get; set; }
        public String Phone1 { get; set; }
        public String Phone2 { get; set; }        
        public DateTime StartDate{get;set;}
        public String Remark {get;set;}        
        #endregion
    }
}

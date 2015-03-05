using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Sale.Entities
{
    [HasSelfValidation]
    public class ServicedCustomer
    {
        #region Properties
        public int ID { get; set; }

        //[ValidatorComposition(CompositionType.Or)]
        //[NotNullValidator(Negated = true)]
        //[RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
        //            MessageTemplateResourceName = "ServicedCustomer_CustomerID_Require",
        //            MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int? CustomerID{get;set;}

        public int? TownID{get;set;}

        public int? TownshipID{get;set;}
        public string UserName{get;set;}
        public string ContactPerson{get;set;}
        public string Phone1{get;set;}
        public string Phone2{get;set;}
        public string ShopName { get; set; }
        public DateTime DateAdded{get;set;}
        public DateTime LastModified{get;set;}
        public bool IsDeleted{get;set;}
        #endregion

        [SelfValidation]
        public void Validate(ValidationResults results)
        {
            if (!CustomerID.HasValue)
            { 
                if(string.IsNullOrEmpty(UserName) || UserName.Length < 1)
                    results.AddResult(
                    new ValidationResult(ErrorMessages.ServicedCustomer_UserName_Require,
                        null, "RequireUserName", null, null));
                else if(!TownID.HasValue)
                    results.AddResult(
                        new ValidationResult(ErrorMessages.ServicedCustomer_TownID_Require,
                            null, "RequireTownID", null, null));
            }
            else if(CustomerID.Value < 1)
            {
                results.AddResult(
                        new ValidationResult(ErrorMessages.ServicedCustomer_CustomerID_Require,
                            null, "RequireCustomerID", null, null));
            }
        }
    }
}

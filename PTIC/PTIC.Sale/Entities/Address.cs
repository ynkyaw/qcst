/*
 * Author:  AUNG KO KO <aungkoko@asiagreenleaf.com>
 * Create date: 2014/02/22 (yyyy/mm/dd)
 * Description: Address entity bean class
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Sale.Entities
{
    [HasSelfValidation]
    public class Address
    {
        public int AddressID { get; set; }

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "Address_TownID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int? TownID { get; set; }

        [ValidatorComposition(CompositionType.Or)]
        [NotNullValidator(Negated = true)]
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "Address_TownshipID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int? TownshipID { get; set; }

        public int? StateDivisionID { get; set; }
        public String Hno { get; set; }
        public String Street { get; set; }
        public String Quartar { get; set; }
        public String Country { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }

        [SelfValidation]
        public void Check(ValidationResults results)
        {
            if(!TownID.HasValue && !TownshipID.HasValue)
                results.AddResult(new ValidationResult(ErrorMessages.Address_TownIDOrTownshipID_Require, 
                    this, "", "", null));
        }

        override public string ToString()
        {
            string str = String.Empty;
            str = String.Concat(str, "AddressID = ", AddressID, "\r\n");
            str = String.Concat(str, "TownID = ", TownID, "\r\n");
            str = String.Concat(str, "TownshipID = ", TownshipID, "\r\n");
            str = String.Concat(str, "StateDivisionID = ", StateDivisionID, "\r\n");
            str = String.Concat(str, "Hno = ", Hno, "\r\n");
            str = String.Concat(str, "Street = ", Street, "\r\n");
            str = String.Concat(str, "Quartar = ", Quartar, "\r\n");
            str = String.Concat(str, "Country = ", Country, "\r\n");
            str = String.Concat(str, "DateAdded = ", DateAdded, "\r\n");
            str = String.Concat(str, "LastModified = ", LastModified, "\r\n");
            str = String.Concat(str, "IsDeleted = ", IsDeleted, "\r\n");
            return str;
        }
    }
}

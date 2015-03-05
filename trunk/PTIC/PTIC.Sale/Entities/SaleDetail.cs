using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Sale.Entities
{
    public class SaleDetail
    {
        public int ID {get; set;}
	    public int InvoiceID {get; set;}

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "SaleDetail_ProductID_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
	    public int ProductID {get; set;}

        [RangeValidator(typeof(decimal), "1", RangeBoundaryType.Inclusive, "0", RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "SaleDetail_SalePrice_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
	    public decimal SalePrice {get; set;}

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "SaleDetail_Qty_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
	    public int Qty {get; set;}

	    public int Package {get; set;}

        [RangeValidator(typeof(decimal), "1", RangeBoundaryType.Inclusive, "0", RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "SaleDetail_Amount_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
	    public decimal Amount {get; set;}

	    public DateTime DateAdded {get; set;}
	    public DateTime LastModified {get; set;}
        public bool IsDeleted { get; set; }

    }
}

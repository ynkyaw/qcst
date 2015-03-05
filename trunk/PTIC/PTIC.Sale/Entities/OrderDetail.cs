/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: Order detail entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Sale.Entities
{
    /// <summary>
    /// Order detail entity
    /// </summary>    
    public class OrderDetail
    {
        #region Properties
        public int ID { get; set; }
        public int OrderID { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "OrderDetail_ProductID_Select",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int ProductID { get; set; }

        [RangeValidator(typeof(decimal), "1", RangeBoundaryType.Inclusive, "0", RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "OrderDetail_SalePrice_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public decimal WSPrice { get; set; }

        public decimal RSPrice { get; set; }
        
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "OrderDetail_Qty_GreaterThanZero",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int Qty { get; set; }

        [RangeValidator(typeof(decimal), "1", RangeBoundaryType.Inclusive, "0", RangeBoundaryType.Ignore,                    
                    MessageTemplateResourceName = "OrderDetail_Amount_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public decimal Amount { get; set; }

        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
        
    }
}

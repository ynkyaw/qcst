/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: Order entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Sale.Entities
{
    /// <summary>
    /// Order entity bean
    /// </summary>
    public class Order
    {
        #region Properties
        public int? ID { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "Order_CusID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int CusID { get; set; }

        //public int RouteID { get; set; }
        //public int TripID { get; set; }
        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "Order_OrderReceieverID_Require",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int OrderReceieverID { get; set; }

        public string OrderNo { get; set; }

        [DateTimeRangeValidator("2000-01-01T00:00:00", "9999-12-31T00:00:00",
                        MessageTemplateResourceName = "Order_OrderDate_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public DateTime OrderDate { get; set; }

        public bool IsMain { get; set; }
        public bool IsDevice { get; set; }        
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

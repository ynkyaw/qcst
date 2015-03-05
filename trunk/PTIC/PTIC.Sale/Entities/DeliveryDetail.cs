/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: Delivery detail entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Microsoft.Practices.EnterpriseLibrary.Validation;
//using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Sale.Entities
{
    /// <summary>
    /// Delivery detail entity bean
    /// </summary>    
    public class DeliveryDetail
    {        
        #region Properties
        public int ID { get; set; }
        public int DeliveryID { get; set; }
        public int ProductID { get; set; }
        public int OrderQty { get; set; }

        //[RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
        //            MessageTemplate = "ပို့ရမည့်အရေအတွက် သည် 0 ထက်ပိုရမည်။.")]                
        public int DeliverQty { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion        
    }
}

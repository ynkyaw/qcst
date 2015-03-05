/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Delivery entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    /// <summary>
    /// Delivery entity bean
    /// </summary>
    public class Delivery
    {
        #region Properties
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int VenID { get; set; }
        public int SalesPersonID { get; set; }
        public int TransportTypeID { get; set; }
        public int? GateID { get; set; }
        public string DeliveryNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool Status { get; set; }
        public bool IsMain { get; set; }
        public bool IsDevice { get; set; }        
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

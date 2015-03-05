/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/28 (yyyy/mm/dd)
 * Description: Mobile service detail entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    /// <summary>
    /// Represent MobileServiceDetail
    /// </summary>
    public class MobileServiceDetail
    {
        #region Properties
        public int? ID { get; set; }
        public int? ServicePlanID { get; set; }
        public int? OrderID { get; set; }
        public string ServiceNo { get; set; }
        public int CusID { get; set; }
        public int EmpID { get; set; }
        public DateTime ServicedDate { get; set; }
        public bool IsCustomer { get; set; }
        public string SugForUsage { get; set; }
        public string ResonNotService { get; set; }
        public DateTime AppointedDate { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

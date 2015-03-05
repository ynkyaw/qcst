/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: MarketingDetail entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    /// <summary>
    /// MarketingDetail entity bean class
    /// </summary>
    public class MarketingDetail
    {
        #region Properties
        public int? ID { get; set; }
        public int? CusID { get; set; }
        public int? EmpID { get; set; }
        public int? MarketingPlanID { get; set; }
        public int? BrandID { get; set; }
        public int? OrderID { get; set; }
        public int? A_P_UsageID { get; set; }
        public int? CustomerComplaintID { get; set; }
        public int? CompetitorActivityID { get; set; }
        public DateTime MarketedDate { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

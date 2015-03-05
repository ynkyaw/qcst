/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/08/26 (yyyy/MM/dd)
 * Description: TripPlanTarget entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    /// <summary>
    /// TripPlanTarget bean class
    /// </summary>
    public class TripPlanTarget
    {
        #region Properties
        public int? ID { get; set; }
        public int TripPlanDetailID { get; set; }
        public int? BrandID { get; set; }
        public decimal TargetAmount { get; set; }                
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/28 (yyyy/mm/dd)
 * Description: CompetitorMarketPromotion entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class CompetitorMarketPromotion
    {
        #region Properties
        public int ID { get; set; }
        public int CActivityID { get; set; }
        public int BrandID { get; set; }
        public string PromoActivity { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Period { get; set; }
        public string Result { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

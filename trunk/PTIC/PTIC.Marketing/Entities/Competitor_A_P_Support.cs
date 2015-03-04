/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/28 (yyyy/mm/dd)
 * Description: Competitor_A_P_Support entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    /// <summary>
    /// Represent Competitor_A_P_Support entity
    /// </summary>
    public class Competitor_A_P_Support
    {
        #region Properties
        public int ID { get; set; }
        public int CActivityID { get; set; }
        public int BrandID { get; set; }
        public string A_P_Type { get; set; }
        public string A_P_Size { get; set; }
        public int Period { get; set; }
        public string Result { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/13 (yyyy/MM/dd)
 * Description: 
 */
using System;

namespace PTIC.Marketing.Entities
{
    #region Properties
    public class POSM_Usage
    {
        #region Properties
        public int? ID { get; set; }
        public int DeptID { get; set; }
        public int InchargeID { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
    #endregion
}

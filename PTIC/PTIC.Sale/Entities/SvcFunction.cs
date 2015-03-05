/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/06/02 (yyyy/MM/dd)
 * Description: Service function entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class SvcFunction
    {
        #region Properties
        public int ID { get; set; }
        public int SalesServiceID { get; set; }
        public DateTime SvcDate { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public int SvcFunctions { get; set; }
        public int Volt { get; set; }
        public string RecPlus1 { get; set; }
        public string RecPlus2 { get; set; }
        public string RecPlus3 { get; set; }
        public string RecPlus4 { get; set; }
        public string RecPlus5 { get; set; }
        public string RecPlus6 { get; set; }
        public string RecMinus1 { get; set; }
        public string RecMinus2 { get; set; }
        public string RecMinus3 { get; set; }
        public string RecMinus4 { get; set; }
        public string RecMinus5 { get; set; }
        public string RecMinus6 { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

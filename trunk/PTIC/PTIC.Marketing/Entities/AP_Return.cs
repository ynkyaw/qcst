/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/13 (yyyy/MM/dd)
 * Description: 
 */
using System;
namespace PTIC.Marketing.Entities
{
    public class AP_Return
    {
        #region Properties
        public int? ID { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ReturnNo { get; set; }
        public int? FromDeptID { get; set; }
        public int? FromVenID { get; set; }
        public int FromEmpID { get; set; }
        public int? ToDeptID { get; set; }
        public int? ToVenID { get; set; }
        public int ToEmpID { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

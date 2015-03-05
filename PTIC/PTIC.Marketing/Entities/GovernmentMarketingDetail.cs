/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: Governmen Marketing Detail entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class GovernmentMarketingDetail
    {
        #region Properties
        public int? ID { get; set; }
        public int? MarketingPlanID { get; set; }
        //public string MinistryName { get; set; }
        public string Department { get; set; }
        //public string ContactPerson { get; set; }
        //public string Position { get; set; }
        //public string ContactPhone { get; set; }
        public string Matter { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public int EmpID { get; set; }
        public int CusID { get; set; }
        public int VenID { get; set; }
        public string Remark { get; set; }
        public int? ServiceID { get; set; }
        public int? OrderID { get; set; }
        public int? TenderInfoID { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

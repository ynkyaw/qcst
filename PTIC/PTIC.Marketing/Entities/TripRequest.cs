
/*
 * Author:  Phoe Htoo <phoohtoo@gmail.com>, 
 * Create date: 2 March 2014
 * Description: About Trip Request
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    /// <summary>
    /// TripRequest detail entity
    /// </summary>
    public class TripRequest
    {
        #region Properties
        public int ID { get; set; }
        public int TripPlanDetailID { get; set; }
        public int RoutePlanID { get; set; }
        public int TransportTypeID { get; set; }
        public int VenID { get; set; }
        public int ManagerID { get; set; }
        public int SalesPersonID { get; set; }
        public int SupporterID { get; set; }
        public string TripPlanNo { get; set; }
        public DateTime ReqDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string PrevTripName { get; set; }
        public bool IsSaleDevice { get; set; }
        public bool IsVocher { get; set; }
        public int PersonCount { get; set; }
        public decimal SalesTargetAmt { get; set; }
        public bool IsVen { get; set; }
        public bool IsAcc { get; set; }
        public bool IsFac { get; set; }
        public bool IsAdm { get; set; }
        public bool IsTab { get; set; }
        public bool IsBoard { get; set; }
        public string Remark { get; set; }
        public string COO { get; set; }
        public string MM { get; set; }
        public string SM { get; set; }
        public bool isSale { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        public int? ProductRequestIssueID { get; set; }
        public int? AP_RequestID { get; set; }
        #endregion
    }
}

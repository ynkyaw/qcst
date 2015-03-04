/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: TripRecord entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    /// <summary>
    /// TripRecord entity
    /// </summary>
    public class TripRecord
    {
        #region Properties
        public int? ID { get; set; }
        public int TripPlanDetailID { get; set; }
        public DateTime ArrivedDate { get; set; }
        public decimal? PrevDebitAmt { get; set; }
        public decimal? RentAmt { get; set; }
        public decimal? FoodAmt { get; set; }
        public decimal? TransportAmt { get; set; }
        public decimal? CommunicationAmt { get; set; }
        public decimal? OtherExpense { get; set; }
        public decimal? RemittanceAmt { get; set; }
        public int? DebitConflictShop { get; set; }
        public int? ShopWithoutOwnerSign { get; set; }
        public string CompetitorStatus { get; set; }
        public string Complaint { get; set; }
        public DateTime PossibleNextTripDate { get; set; }
        /// <summary>
        /// Product ID
        /// </summary>
        public int? MainProductID4NextTrip { get; set; } // Product ID
        public string SpecialCase { get; set; }
        public string Suggestion { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

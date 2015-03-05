/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/06/02 (yyyy/MM/dd)
 * Description: Service Fact entity bean class
 */
using System;
using PTIC.Common;
namespace PTIC.Sale.Entities
{
    /// <summary>
    /// Service Fact entity bean
    /// </summary>
    public class SvcFact
    {
        #region Properties
        public int ID { get; set; }
        [DBField("SvcTestID")]
        public int? SvcTestID { get; set; }

        [DBField("TripID")]
        public int? TripID { get; set; }

        [DBField("RouteID")]
        public int? RouteID { get; set; }

        [DBField("TownID")]
        public int? TownID { get; set; }

        [DBField("TownshipID")]
        public int? TownshipID { get; set; }

        [DBField("ShopID")]
        public int ShopID { get; set; } // Customer ID

        [DBField("UsedDuration")]
        public int? UsedDuration { get; set; }

        [DBField("UsedPlace")]
        public string UsedPlace { get; set; }

        [DBField("UsedAmp")]
        public int? UsedAmp { get; set; }

        [DBField("UsedSize")]
        public int? UsedSize { get; set; }

        [DBField("ChargingTime")]
        public int? ChargingTime { get; set; }

        [DBField("ContinuousUsedTime")]
        public string ContinuousUsedTime { get; set; }

        [DBField("Address")]
        public string Address { get; set; }

        [DBField("DateToSvc")]
        public DateTime DateToSvc { get; set; }

        public DateTime ServicingDate { get; set; }
        public DateTime DateToFactory { get; set; }
        public DateTime DateFromFactory { get; set; }
        public DateTime DateFromSvc { get; set; }
        public DateTime DateToCustomer { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

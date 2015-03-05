/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/06/03 (yyyy/MM/dd)
 * Description: Service Battery Status entity bean class
 */

namespace PTIC.Sale.Entities
{
    /// <summary>
    /// Service battery status entity
    /// </summary>
    public class ServiceBatteryStatus
    {
        #region Properties
        //public int? SalesServiceID { get; set; }

        public int? CurrentVehicleID { get; set; }
        public int? CurrentWarehouseID { get; set; }
        public int? CurrentServiceTeamID { get; set; }
        public int? CurrentMainStoreID { get; set; }

        public bool InForwardVehicle { get; set; }
        public bool InForwardShowroom { get; set; }
        public bool InForwardServiceTeam { get; set; }
        public bool InForwardMainStore { get; set; } // Factory

        public bool InBackwardVehicle { get; set; }
        public bool InBackwardShowroom { get; set; }
        public bool InBackwardServiceTeam { get; set; }
        public bool InBackwardCustomer { get; set; }
        #endregion

    }
}

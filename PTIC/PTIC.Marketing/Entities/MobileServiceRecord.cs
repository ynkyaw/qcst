/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/28 (yyyy/MM/dd)
 * Description: Mobile service record entity bean class
 */
using System;

namespace PTIC.Marketing.Entities
{
    /// <summary>
    /// Represent MobileServiceRecord
    /// </summary>
    public class MobileServiceRecord
    {
        #region Properties
        public int ID { get; set; }
        public int MSuvDetailID { get; set; }
        public int BrandID { get; set; }
        public int ProductID { get; set; }
        public string UsedPlace { get; set; }
        public string MachineNo { get; set; }
        public string ProductionDate { get; set; }
        public int Volt { get; set; }
        public float ChargingAmp { get; set; }
        public float OutAmp { get; set; }
        public float Acid1 { get; set; }
        public float Acid2 { get; set; }
        public float Acid3 { get; set; }
        public float Acid4 { get; set; }
        public float Acid5 { get; set; }
        public float Acid6 { get; set; }
        public string Serving { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

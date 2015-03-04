/*
 * Author:  AUNGKOKO <aungkoko@asiagreenleaf.com>
 * Create date: 2014/03/03 (yyyy/mm/dd)
 * Description: 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class ComplaintServiceRecord
    {
        #region Properties
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int ComplainID { get; set; }
        public string ServiceNo { get; set; }
        public DateTime PurchasedDate { get; set; }
        public string PurchasedShop { get; set; }
        public int UsedPeriod { get; set; }
        public string UsedPlace { get; set; }
        public DateTime ProductionDate { get; set; }
        public int Volt{get;set;}
        public float ChargingAmp { get; set; }
        public float OutAmp { get; set; }
        public float UsingAmp { get; set; }
        public int UsingSize { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

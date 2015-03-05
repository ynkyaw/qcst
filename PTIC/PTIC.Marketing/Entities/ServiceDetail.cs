/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   ServiceDetail
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class ServiceDetail
    {
        #region Entities

        public int? ServiceDetailID { get; set; }
        public int ServiceID { get; set; }
        public int ProductID { get; set; }
        public DateTime ProductionDate { get; set; }
        public String JobCardNo { get; set; }
        public DateTime PurchaseDate { get; set; }
        public String ShopName { get; set; }
        public DateTime UserDuration { get; set; }
        public String UserPlace { get; set; }
        public DateTime ChargingTime { get; set; }
        public DateTime ChargingUsedTime { get; set; }
        public int UsedAmp { get; set; }
        public decimal UsedSize { get; set; }
        public float Description { get; set; }
        public DateTime SvcCheckDate { get; set; }
        public String PosAcid1 { get; set; }
        public String PosAcid2 { get; set; }
        public String PosAcid3 { get; set; }
        public String NegAcid1 { get; set; }
        public String NegAcid2 { get; set; }
        public String NegAcid3 { get; set; }
        public String Volt { get; set; }
        public String SuvFault { get; set; }
        public DateTime FacRecDate { get; set; }
        public String FacFault { get; set; }
        //
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
    }
}


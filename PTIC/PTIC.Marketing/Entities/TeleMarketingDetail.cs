using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class TeleMarketingDetail
    {
        #region Properties
        public int? ID { get; set; }
        public int? CusID { get; set; }
        public int? EmpID { get; set; }
        public int? MarketingPlanID { get; set; }
        public DateTime MarketedDate { get; set; }
        public int? OrderID { get; set; }
        public int UsingBrand { get; set; }
        public int UsingProductID { get; set; }
        public int UsingQty { get; set; }
        public int UsingPeriod { get; set; }
        public int SellingPeriod { get; set; }
        public int SellingBrandID { get; set; }
        public string SatisfactionFact { get; set; }
        public string DisatisfactionFact { get; set; }
        public string OtherFact { get; set; }
        public DateTime ServiceDate { get; set; }
        public DateTime RecallDate { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/MM/dd)
 * Description: MarketingPlan entity bean class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PTIC.Marketing.Entities
{
    /// <summary>
    /// MarketingPlan entity
    /// </summary>
    public class MarketingPlan
    {
        #region Properties
        public int ID { get; set; }
        public int CustomerID { get; set; }  
        public int EmpID { get; set; }
        //public int CusTypeID { get; set; }
        public DateTime PlanDate { get; set; }
        //TODO: InitialMarketingPlanID နှင့် TeleMarketingInitialPlanID 
        public int InitialMarketingPlanID { get; set; }
        public int TeleMarketingInitialPlanID { get; set; }
        public int MarketingType { get; set; } // 0:Marketing 1:Telemarketing 2:Mobile Service
        public int Status { get; set; } // 0: Report 1: Confirm 2: Reject
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion

        public static DataTable AsClonedDataTable()
        {
            DataTable dtTeleMarketingPlan = new DataTable("TeleMarketingPlanTableType");
            dtTeleMarketingPlan.Columns.Add("CustomerID", typeof(int));
            dtTeleMarketingPlan.Columns.Add("PlanDate", typeof(DateTime));
            dtTeleMarketingPlan.Columns.Add("TeleMarketingInitialPlan", typeof(int));
            dtTeleMarketingPlan.Columns.Add("MarketingType", typeof(int));
            dtTeleMarketingPlan.Columns.Add("Status", typeof(int));          
            return dtTeleMarketingPlan;
        }
    }
}

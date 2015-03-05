/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/20 (yyyy/mm/dd)
 * Description: MarketingPlan business logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.BL
{
    /// <summary>
    /// Marketing Plan business logic
    /// </summary>
    public class MarketingPlanBL
    {
        #region SELECT

        //public DataTable GetMarketingLogs(SqlConnection conn)
        //{
        //    return MarketingPlanDA.SelectMarketingLogs(conn);
        //}
        public DataTable GetDailyMarketingLogByPlannedDateRange(DateTime startDate, DateTime endDate)
        {
            return MarketingPlanDA.SelectDailyMarketingLogByPlannedDateRange(startDate, endDate);
        }

        public DataTable GetDailyMarketingLogByMarketedDateRange(DateTime startDate, DateTime endDate)
        {
            return MarketingPlanDA.SelectDailyMarketingLogByMarketedDateRange(startDate, endDate);
        }

        public DataTable GetDailyMarketingLogByDateRangeAndRouteID(DateTime startDate, DateTime endDate, int routeID)
        {
            return MarketingPlanDA.SelectDailyMarketingLogByDateRangeAndRouteID(startDate, endDate, routeID);
        }

        public DataTable GetDailyMarketingLogByInitialTeleMarketingPlanID(int InitialTeleMarketingPlanID)
        {
            return MarketingPlanDA.SelectTelemarketingLogByInitialTeleMarketingPlan(InitialTeleMarketingPlanID);
        }

        public DataTable GetDailyMarketingLogByInitialMarketingPlanID(int InitialMarketingPlanID)
        {
            return MarketingPlanDA.SelectDailyMarketingLogByInitialMarketingPlanID(InitialMarketingPlanID);
        }

        public DataTable GetUnconfirmedTelemarketingPlan()
        {
            return MarketingPlanDA.SelectUnconfirmedTelemarketingPlan();
        }
        #endregion

        #region SELECT CusName
        public DataTable GetCusName(CustomerName cusname, SqlConnection conn)
        {
            return MarketingPlanDA.SelectCusName(cusname, conn);
        }
        #endregion

        #region SELECT TelemarketingLog
        public DataTable GetTelemarketingLogBy(DateTime startDate, DateTime endDate)
        {
            return MarketingPlanDA.SelectTelemarketingLogBy(startDate, endDate);
        }

        public DataTable GetTelemarketingLogByInitialMarketingPlan(int InitialMarketingPlan)
        {
            return MarketingPlanDA.SelectDailyMarketingLogByInitialMarketingPlanID(InitialMarketingPlan);
        }
        #endregion

        #region SELECT MarketingPlan
        public DataTable GetMarketingPlan(int marketingtype, SqlConnection conn)
        {
            return MarketingPlanDA.SelectMarketingPlan(marketingtype, conn);
        }
        #endregion
        
        #region INSERT INTO MarketingPlan
        public int Insert(MarketingPlan marketingplan, SqlConnection conn)
        {
            return MarketingPlanDA.InsertMarketingPlan(marketingplan, conn);
        }
        #endregion

        #region UPDATE
        public int Update(MarketingPlan marketingplan, SqlConnection conn)
        {
            return MarketingPlanDA.UpdateByID(marketingplan, conn);
        }

        public void UpdateAsConfirmed(List<MarketingPlan> telePlans)
        {
            MarketingPlanDA.UpdateTelemarketingPlanAsConfirmed(telePlans);
        }

        public void UpdateAsRejected(List<MarketingPlan> telePlans)
        {
            MarketingPlanDA.UpdateTelemarketingPlanAsRejected(telePlans);
        }

        #endregion

        #region DELETE
        public int Delete(MarketingPlan marketingplan, SqlConnection conn)
        {
            return MarketingPlanDA.DeleteByID(marketingplan, conn);
        }
        #endregion

        #region SEARCH
        public DataTable Search(DateTime startdate,DateTime enddate, int marketingtype)
        {
            return MarketingPlanDA.SearchByID(startdate, enddate, marketingtype);
        }
        #endregion


        public DataTable GetMarketingPlanBy(DateTime StartDate,DateTime EndDate)
        {
            return MarketingPlanDA.SelectMarketingPlanWithoutDetailBy(Common.Enum.FormStatus.Confirmed, Common.Enum.MarketingType.DailyMarketing,StartDate,EndDate);
        }
    }
}

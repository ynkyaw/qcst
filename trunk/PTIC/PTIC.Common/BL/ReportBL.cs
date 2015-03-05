/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/04/20 (yyyy/MM/dd)
 * Description: Report business logice file
 */

using System.Data;
using PTIC.Common.DA;
using System;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Common.BL
{
    /// <summary>
    /// Report business logic class
    /// </summary>
    public class ReportBL : BaseBusinessLogic
    {
        #region SALES

        #region Cash Collection
        public DataTable GetDebtors()
        {
            return ReportDA.SelectDebtors();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tripID">tripID that less than 1 means ALL trips</param>
        /// <param name="routeID">routeID that less than 1 means ALL routes </param>
        /// <param name="townID"></param>
        /// <param name="townshipID"></param>
        /// <param name="customerTypeID"></param>
        /// <param name="customerID"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public DataTable GetDebtorBy
            (
                int? tripID, int? routeID,
                int? townID, int? townshipID,
                int? customerTypeID, int? customerID,
                DateTime? startDate, DateTime? endDate
            ) 
        {
            // TODO: validataion

            return ReportDA.SelectDebtorBy(
                tripID, routeID,
                townID, townshipID,
                customerTypeID, customerID,
                startDate, endDate);
        }

        public DataTable GetInvoicesByRouteID(int RouteID)
        {
            return ReportDA.SelectDebtorsByRouteID(RouteID);
        }

        public DataTable GetInvoicesByTripID(int TripID)
        {
            return ReportDA.SelectDebtorsByTripID(TripID);
        }
        #endregion

        #region Sales Service
        /// <summary>
        /// Get service battery status indicating whether it've got to Showroom, SSB, Factory..
        /// </summary>
        /// <returns>DataTable including battery status</returns>
        public DataTable GetServiceBatteryStatus()
        {
            return ReportDA.SelectServiceBatteryStatus();
        }

        /// <summary>
        /// Get SalesServie Detail For Battery List
        /// </summary>
        /// <returns></returns>
        public DataTable GetSalesServiceDetails()
        {
            return ReportDA.SelectSalesServiceDetail();
        }
        /// <summary>
        /// Get service batteries in factory 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetServiceBatteryInFactory()
        {
            return ReportDA.SelectServiceBatteryInFactory();
        }

        /// <summary>
        /// Get service batteries
        /// </summary>
        /// <returns>DataTable including service batteries</returns>
        public DataTable GetServiceBatteries()
        {
            return ReportDA.SelectServiceBatteries();
        }
        #endregion

        #region Inventory
        /// <summary>
        /// Get VenIn by filter Vehicle ID and DateTime
        /// </summary>
        /// <param name="vehicleID">keyword vehicle id</param>
        /// <param name="date">keyword DateTime</param>
        /// <returns>VenIn DataTable</returns>
        public DataTable GetVenIn(int vehicleID, DateTime date)
        {
            return ReportDA.SelectVenInBy(vehicleID, date);
        }

        /// <summary>
        /// Get VenOut by filter Vehicle ID and DateTime
        /// </summary>
        /// <param name="vehicleID">keyword vehicle id</param>
        /// <param name="date">keyword DateTime</param>
        /// <returns>VenOut DataTable</returns>
        public DataTable GetVenOut(int vehicleID, DateTime date)
        {
            return ReportDA.SelectVenOutBy(vehicleID, date);
        }
        #endregion

        #region Sales QOB
        public DataTable GetMonthlyDeliverySummaryByDate(DateTime SalesDate,int BrandID)
        {
            try
            {
                return ReportDA.SelectMonthlyDeliverySummaryByDate(SalesDate,BrandID);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                   new ValidationResult(e.Message,
                       null, "ReportBL", null, null));
                return null;
            }

        }

        public DataTable GetMonthlySalesByRegion(DateTime SalesDate,int? TripID)
        {
            try
            {
                return ReportDA.SelectMonthlySalesByRegion(SalesDate,TripID);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                   new ValidationResult(e.Message,
                       null, "ReportBL", null, null));
                return null;
            }

        }

        /// <summary>
        /// GetYearlySalesSelectBy
        /// </summary>
        /// <param name="CusType"></param>
        /// <param name="VoucherType"></param>
        /// <param name="TownID"></param>
        /// <param name="TownshipID"></param>
        /// <param name="RouteID"></param>
        /// <param name="TripID"></param>
        /// <param name="Date"></param>
        /// <returns></returns>
        public DataTable GetYearlySalesSelectBy(int? CusType,int? VoucherType,int? TownID,int? TownshipID,int? RouteID, int? TripID,DateTime Date)
        {
            try
            {
                return ReportDA.YearlySalesSelectBy(CusType,VoucherType,TownID,TownshipID,RouteID, TripID,Date);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                   new ValidationResult(e.Message,
                       null, "ReportBL", null, null));
                return null;
            }

        }

        public DataTable GetMonthlySalesByCustomer(DateTime SalesDate,int? CusType)
        {
            try
            {
                return ReportDA.SelectMonthlySalesByCustomer(SalesDate,CusType);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                   new ValidationResult(e.Message,
                       null, "ReportBL", null, null));
                return null;
            }
            
        }

        public DataTable GetSalesQOB1(DateTime startDate, DateTime endDate)
        {            
            try
            {
                return ReportDA.SelectSalesQOB1(startDate, endDate);
            }
            catch(Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "ReportBL", null, null));
                return null;
            }
            
        }

        public DataTable GetSalesQOB2(DateTime startDate, DateTime endDate)
        {
            return ReportDA.SelectSalesQOB2(startDate, endDate);
        }

        public DataTable GetSalesQOB5(DateTime startDate, DateTime endDate, int brandID)
        {
            return ReportDA.SelectSalesQOB5(startDate, endDate, brandID);
        }

        public DataTable GetSalesQOB6(DateTime startDate, DateTime endDate, int brandID)
        {
            return ReportDA.SelectSalesQOB6(startDate, endDate, brandID);
        }
        #endregion

        #endregion // END of SALES

        #region MARKETING
        #region A & P
        /// <summary>
        /// Get AP plan summary by specifying start date and end date
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>AP plan summary DataTable</returns>
        public DataTable GetAP_PlanSummaryBy(DateTime startDate, DateTime endDate)
        {
            return ReportDA.SelectAP_PlanSummaryBy(startDate, endDate);
        }
        #endregion
        #endregion

        #region REPORT

        #region Waiting Customer
        public DataTable GetWaitingCustomers(DateTime endDate)
        {
            return ReportDA.SelectWaitingOrPermanentCustomers(Enum.CustomerTransition.Waiting, endDate);
        }
        #endregion

        #region Permanent Customer
        public DataTable GetPermanentCustomers(DateTime endDate)
        {
            return ReportDA.SelectWaitingOrPermanentCustomers(Enum.CustomerTransition.Permanent, endDate);
        }
        #endregion

        #region Customer Transition
        public DataTable GetCustomerTransition
            (PTIC.Common.Enum.CustomerType customerType, DateTime endDate)
        {
            return ReportDA.SelectCustomerTransition(customerType, endDate);
        }
        #endregion

        #region Yearly Customer Transition
        public DataTable GetYearlyCustomerTransition
            (
            int? tripID,
            int? townID,
            DateTime startDate,
            PTIC.Common.Enum.CustomerType? customerType
            )
        {
            if (tripID.HasValue && tripID.Value == -1)
                tripID = null;
            if (townID.HasValue && townID.Value == -1)
                townID = null;
            return ReportDA.SelectYearlyCustomerTransition(tripID, townID, startDate, customerType);
        }
        #endregion

        #endregion

        #region TELEMARKETING(COMPANY CONTACT)
        public DataTable CompanyContactSelectBy(int? TripID, int? RouteID, int? TownID, int? TownshipID, int? CustomerType, DateTime StartDate, DateTime EndDate)
        {
            return ReportDA.CompanyContactSelectBy(TripID, RouteID, TownID, TownshipID, CustomerType, StartDate, EndDate);
        }
        #endregion

        #region DAILY MARKETING
         public DataTable DailyMarketingSelectBy(int? TripID, int? RouteID, int? TownID, int? TownshipID, int? CustomerType, DateTime StartDate, DateTime EndDate)
        {
            return ReportDA.DailyMarketingSelectBy(TripID, RouteID, TownID, TownshipID, CustomerType, StartDate, EndDate);
        }
        #endregion

        #region Markeing QOB
        public DataTable GetNewOutletQOBBy(DateTime StartDate, int BrandID)
        {
            return ReportDA.SelectNewOutletQOBBy(StartDate,BrandID);
        }

        public DataTable GetComplaintImprovementQOBBy(DateTime StartDate)
        {
            return ReportDA.SelectComplaintImprovementQOBBy(StartDate);
        }
        #endregion

    }
}

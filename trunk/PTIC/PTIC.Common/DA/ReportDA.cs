/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/04/20 (yyyy/MM/dd)
 * Description: Report data access file
 */
using System.Data;
using PTIC.Common.DA;
using System;
using System.Data.SqlClient;
using System.Text;
namespace PTIC.Common.DA
{
    /// <summary>
    /// Report data access class
    /// </summary>
    public class ReportDA
    {
        private static BaseDAO _dataAccess = new BaseDAO();

        #region SALES

        #region Cash Collection
        /// <summary>
        /// Select debtors
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable SelectDebtors()
        {
            string queryString = "SELECT * FROM uv_Debtor";
            return _dataAccess.SelectByQuery(queryString);
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
        public static DataTable SelectDebtorBy
            (
                int? tripID, int? routeID,
                int? townID, int? townshipID,
                int? customerTypeID, int? customerID,
                DateTime? startDate, DateTime? endDate
            )
        {
            DataTable tbDebtors = null;
            string tableName = "DebtorTable";
            StringBuilder queryText = new StringBuilder(
                "SELECT "
                + " InvoiceID, InvoiceNo, SalesDate, cus.CusName, Town, BalanceAmt, BalanceDuration, RouteName, TripName"
                + " FROM uv_Debtor"
                + " INNER JOIN Customer cus ON cus.ID = CusID"
                + " INNER JOIN Address addr ON addr.ID = cus.AddrID WHERE 1 = 1");
            try
            {
                tbDebtors = new DataTable(tableName);
                // By Trip ID
                if(tripID.HasValue)
                    queryText.Append(
                        tripID.Value < 1 ? " AND cus.TripID IS NOT NULL" : " AND cus.TripID = " + tripID.Value); // tripID that less than 1 means ALL trips
                // By Route ID
                if(routeID.HasValue)
                    queryText.Append(
                        routeID.Value < 1 ? " AND cus.RouteID IS NOT NULL" : " AND cus.RouteID = " + routeID.Value); // routeID that less than 1 means ALL routes
                // By Town ID
                if (townID.HasValue)
                    queryText.Append(" AND TownID = " + townID.Value);
                // By Township ID
                if (townshipID.HasValue)
                    queryText.Append(" AND TownshipID = " + townshipID.Value);
                // By Customer Type ID
                if (customerTypeID.HasValue)
                    queryText.Append(" AND CusType = " + customerTypeID.Value);
                // By Customer ID
                if (customerID.HasValue)
                    queryText.Append(" AND CusID = " + customerID.Value);
                // By Date Range
                if (startDate.HasValue && endDate.HasValue)
                {
                    queryText.Append(
                        string.Format(" AND CAST(SalesDate AS DATE)" +
                                        " BETWEEN '{0}' AND '{1}'", startDate.Value.ToString("yyyy-MM-dd"), endDate.Value.ToString("yyyy-MM-dd"))
                                        );
                }
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();

                command.CommandType = CommandType.Text;
                command.CommandText = queryText.ToString();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(tbDebtors);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tbDebtors;
        }

        /// <summary>
        /// SELECT Debtors By RouteID
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectDebtorsByRouteID(int RouteID)
        {
            string queryString = "SELECT * FROM uv_Debtor WHERE RouteID=" +RouteID;
            //return new BaseDAO().SelectByQuery(queryString);
            return _dataAccess.SelectByQuery(queryString);
        }

        /// <summary>
        /// SELECT Debtors By TripID
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectDebtorsByTripID(int TripID)
        {
            string queryString = "SELECT * FROM uv_Debtor WHERE TripID ="+ TripID;
            //return new BaseDAO().SelectByQuery(queryString);
            return _dataAccess.SelectByQuery(queryString);
        }
        #endregion

        #region Sales Service
        /// <summary>
        /// Select service battery status
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable SelectServiceBatteryStatus()
        {
            string queryString = "SELECT * FROM uv_ServiceBatteryStatus";
            return _dataAccess.SelectByQuery(queryString);
        }
        /// <summary>
        /// Select service battery status
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable SelectServiceBatteryStatusByDate(DateTime Date)
        {
            string queryString = "SELECT * FROM uv_ServiceBatteryStatus WHERE CAST(ReceivedDate AS DATE) = CAST('" + Date + "' AS DATE)";
            return _dataAccess.SelectByQuery(queryString);
        }

        /// <summary>
        /// Select Sales service detail
        /// </summary>
        /// <returns></returns>
        public static DataTable SelectSalesServiceDetail()
        {
            string queryString = "SELECT * FROM uv_SalesServiceDetails";
            return _dataAccess.SelectByQuery(queryString);
        }

        /// <summary>
        /// Select service batteries in factory
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable SelectServiceBatteryInFactory()
        {
            string queryString = "SELECT * FROM uv_ServiceBatteryStatus WHERE Whereami = 3";
                //SalesServiceWhereami.MainStore);
            return _dataAccess.SelectByQuery(queryString);
        }

        /// <summary>
        /// Select service batteries
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable SelectServiceBatteries()
        {
            string queryString = "SELECT * FROM uv_ServiceBatteries";
            return _dataAccess.SelectByQuery(queryString);
        }
        #endregion

        #region
        /// <summary>
        /// Select service batteries by date
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable SelectServiceBatteriesByDate(DateTime Date)
        {
            string queryString = "SELECT * FROM uv_ServiceBatteries WHERE CAST(ReceivedDate AS DATE) ="+  "CAST('"+ Date +"' As DATE)";
            return _dataAccess.SelectByQuery(queryString);
        }
        #endregion

        #region Inventory
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DataTable SelectVenInBy(int vehicleID, DateTime date)
        {
            string queryString = "SELECT Date, ProductID, ProductName, VehicleID, WarehouseID, Warehouse, SalesReturnQty, ServiceReceiveQty, WarehouseQty," +
                                            " CASE WHEN WarehouseID = 2 THEN WarehouseQty ELSE 0 END AS SSB_Qty," +
                                            " CASE WHEN WarehouseID = 3 THEN WarehouseQty ELSE 0 END AS TGGN_Qty," +
                                            " CASE WHEN WarehouseID = 4 THEN WarehouseQty ELSE 0 END AS NOKP_Qty" +
                                            " FROM uv_VenIn WHERE VehicleID = {0} AND CONVERT(VARCHAR(10),Date,103) = CONVERT(VARCHAR(10),CAST ('{1}' as DATE) ,103) ";
            return _dataAccess.SelectByQuery(string.Format(queryString, vehicleID, date));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DataTable SelectVenOutBy(int vehicleID, DateTime date)
        {
            string queryString = "SELECT" +
                                            " Date, ProductID, ProductName, VehicleID, WarehouseID, Warehouse," +
                                            " WarehouseQty, ConsignSalesQty, CashSalesQty, CreditSalesQty, ServiceReturnQty, DamageQty = 0," +
                                            " CASE WHEN WarehouseID = 2 THEN WarehouseQty ELSE 0 END AS SSB_Qty," +
                                            " CASE WHEN WarehouseID = 3 THEN WarehouseQty ELSE 0 END AS TGGN_Qty," +
                                            " CASE WHEN WarehouseID = 4 THEN WarehouseQty ELSE 0 END AS NOKP_Qty" +
                                            " FROM uv_VenOut WHERE VehicleID = {0} AND CONVERT(VARCHAR(10),Date,103) = CONVERT(VARCHAR(10),CAST ('{1}' as DATE) ,103)";
            return _dataAccess.SelectByQuery(string.Format(queryString, vehicleID, date));
        }
        #endregion

        #region Sales QOB
        public static DataTable SelectMonthlyDeliverySummaryByDate(DateTime DeliveryDate,int BrandID)
        {
            DataTable table = null;
            string tableName = "MonthlyDeliverySummaryTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_MonthlyDeliveryByDate";

                command.Parameters.AddWithValue("@p_DeliveryDate", DeliveryDate);
                command.Parameters["@p_DeliveryDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_BrandID", BrandID);
                command.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 8134) // Divide by zero(Sale Plan Amount) error encountered
                    throw new Exception("ရွေးချယ်ထားသော လအတွင်း၌ ရောင်းဝယ်ထားခြင်း မရှိသောကြောင့် Report ကြည့်ရှု၍ မရနိုင်ပါ။");
                return null;
            }
            return table;
        }

        public static DataTable SelectMonthlySalesByRegion(DateTime SalesDate,int? TripID)
        {
            DataTable table = null;
            string tableName = "MonthlySalesByRegionTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_MonthlsySalesSelectByRegion";

                command.Parameters.AddWithValue("@p_SalesDate", SalesDate);
                command.Parameters["@p_SalesDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_TripID", TripID);
                command.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 8134) // Divide by zero(Sale Plan Amount) error encountered
                    throw new Exception("ရွေးချယ်ထားသော လအတွင်း၌ ရောင်းဝယ်ထားခြင်း မရှိသောကြောင့် Report ကြည့်ရှု၍ မရနိုင်ပါ။");
                return null;
            }
            return table;
        }

        public static DataTable SelectMonthlySalesByCustomer(DateTime SalesDate,int? CusType)
        {
            DataTable table = null;
            string tableName = "MonthlySalesByCustomerTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_MonthlsySalesSelectByCustomer";

                command.Parameters.AddWithValue("@p_SalesDate", SalesDate);
                command.Parameters["@p_SalesDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_CusType", CusType);
                command.Parameters["@p_CusType"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 8134) // Divide by zero(Sale Plan Amount) error encountered
                    throw new Exception("ရွေးချယ်ထားသော လအတွင်း၌ ရောင်းဝယ်ထားခြင်း မရှိသောကြောင့် Report ကြည့်ရှု၍ မရနိုင်ပါ။");
                return null;
            }
            return table;
        }

        public static DataTable SelectSalesQOB1(DateTime startDate, DateTime endDate)
        {
            DataTable table = null;
            string tableName = "SalesQOB1Table";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_Sales_QOB1";

                command.Parameters.AddWithValue("@p_StartDate", startDate);
                command.Parameters["@p_StartDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_EndDate", endDate);
                command.Parameters["@p_EndDate"].Direction = ParameterDirection.Input;
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 8134) // Divide by zero(Sale Plan Amount) error encountered
                    throw new Exception("ရွေးချယ်ထားသော နှစ်ကာလတွင် Sales Plan ပြုလုပ်ထားခြင်း မရှိသောကြောင့် Report ကြည့်ရှု၍ မရနိုင်ပါ။");
                return null;
            }
            return table;
        }

        public static DataTable SelectSalesQOB2(DateTime startDate, DateTime endDate)
        {
            DataTable table = null;
            string tableName = "SalesQOB2Table";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_Sales_QOB2";

                command.Parameters.AddWithValue("@p_StartDate", startDate);
                command.Parameters["@p_StartDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_EndDate", endDate);
                command.Parameters["@p_EndDate"].Direction = ParameterDirection.Input;
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable SelectSalesQOB5(DateTime startDate, DateTime endDate, int brandID)
        {
            DataTable table = null;
            string tableName = "SalesQOB5Table";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_Sales_QOB5";

                command.Parameters.AddWithValue("@p_StartDate", startDate);
                command.Parameters["@p_StartDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_EndDate", endDate);
                command.Parameters["@p_EndDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_BrandID", brandID);
                command.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;                

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable SelectSalesQOB6(DateTime startDate, DateTime endDate, int brandID)
        {
            DataTable table = null;
            string tableName = "SalesQOB6Table";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_Sales_QOB6";

                command.Parameters.AddWithValue("@p_StartDate", startDate);
                command.Parameters["@p_StartDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_EndDate", endDate);
                command.Parameters["@p_EndDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_BrandID", brandID);
                command.Parameters["@p_BrandID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        /// <summary>
        /// YearlySalesSelectBy
        /// </summary>
        /// <param name="CusType"></param>
        /// <param name="VoucherType"></param>
        /// <param name="TownID"></param>
        /// <param name="TownshipID"></param>
        /// <param name="RouteID"></param>
        /// <param name="TripID"></param>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static DataTable YearlySalesSelectBy(int? CusType,int? VoucherType,int? TownID,int? TownshipID,int? RouteID, int? TripID,DateTime Date)
        {
            DataTable table = null;
            string tableName = "YearlySalesTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_YearlySalesSelectBy";

                command.Parameters.AddWithValue("@p_CusType", CusType);
                command.Parameters["@p_CusType"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_VoucherType", VoucherType);
                command.Parameters["@p_VoucherType"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_TownID", TownID);
                command.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_TownshipID", TownshipID);
                command.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_RouteID", RouteID);
                command.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_TripID", TripID);
                command.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_Date", Date);
                command.Parameters["@p_Date"].Direction = ParameterDirection.Input;


                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                if (sqle.Number == 8134) // Divide by zero(Sale Plan Amount) error encountered
                    throw new Exception("ရွေးချယ်ထားသော လအတွင်း၌ ရောင်းဝယ်ထားခြင်း မရှိသောကြောင့် Report ကြည့်ရှု၍ မရနိုင်ပါ။");
                return null;
            }
            return table;
        }
        #endregion

        #endregion // END of SALES

        #region MARKETING
        #region A & P
        /// <summary>
        /// Select AP Plan Summary DataTable by specifying start date and end date
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>AP plan summary DataTable</returns>
        public static DataTable SelectAP_PlanSummaryBy(DateTime startDate, DateTime endDate)
        {
            string queryString = string.Format("EXEC usp_AP_PlanSummarySelectBy '{0}', '{1}' ", 
                startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
            return _dataAccess.SelectByQuery(queryString);
        }
        #endregion                       
        #endregion

        #region REPORT

        #region Waiting or Permanent Customer
        public static DataTable SelectWaitingOrPermanentCustomers
            (PTIC.Common.Enum.CustomerTransition customerTransition, DateTime endDate)
        {
            DataTable table = null;
            string tableName = "WaitingOrPermanentTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_WaitingOrPermanentCustomerSelectBy";

                command.Parameters.AddWithValue("@p_Transition", (int)customerTransition);
                command.Parameters["@p_Transition"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_EndDate", endDate);
                command.Parameters["@p_EndDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
        #endregion

        #region Customer Transition
        public static DataTable SelectCustomerTransition
            (PTIC.Common.Enum.CustomerType customerType, DateTime endDate)
        {
            DataTable table = null;
            string tableName = "WaitingOrPermanentTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_CustomerTransitionSelectBy";

                command.Parameters.AddWithValue("@p_CustomerTypeID", (int)customerType);
                command.Parameters["@p_CustomerTypeID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_EndDate", endDate);
                command.Parameters["@p_EndDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
        #endregion

        #region Yearly Customer Transition
        public static DataTable SelectYearlyCustomerTransition
            (
            int? tripID,
            int? townID,
            DateTime startDate, 
            PTIC.Common.Enum.CustomerType? customerType
            )
        {
            DataTable table = null;
            string tableName = "YearlyCustomerTransitionTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_YearlyCustomerTransitionSelectBy";

                command.Parameters.AddWithValue("@p_TripID", tripID);
                command.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                //command.Parameters.AddWithValue("@p_TownID", (object)tripID?? DBNull.Value);
                command.Parameters.AddWithValue("@p_TownID", townID);
                command.Parameters["@p_TownID"].Direction = ParameterDirection.Input;
                
                command.Parameters.AddWithValue("@p_CustomerTypeID", customerType == null ?  (object)DBNull.Value : (int)customerType);
                command.Parameters["@p_CustomerTypeID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_StartDate", startDate);
                command.Parameters["@p_StartDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
        #endregion

        #endregion

        #region TELEMARKETIN (COMPANY CONTACT)
        public static DataTable CompanyContactSelectBy(int? TripID, int? RouteID, int? TownID,int? TownshipID,int? CustomerType,DateTime StartDate,DateTime EndDate)
        {
            DataTable table = null;
            string tableName = "CompanyContactTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_CompanyContactSelectBy";

                command.Parameters.AddWithValue("@p_TripID", TripID);
                command.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_RouteID", RouteID);
                command.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_TownID", TownID);
                command.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_TownshipID", TownshipID);
                command.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_CustomerType", CustomerType);
                command.Parameters["@p_CustomerType"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_StartDate", StartDate);
                command.Parameters["@p_StartDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_EndDate", EndDate);
                command.Parameters["@p_EndDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
        #endregion

        #region DAILYMARKETING
        public static DataTable DailyMarketingSelectBy(int? TripID, int? RouteID, int? TownID, int? TownshipID, int? CustomerType, DateTime StartDate, DateTime EndDate)
        {
            DataTable table = null;
            string tableName = "DailyMarketingTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_RP_DailyMarketingReportSelectBy";

                command.Parameters.AddWithValue("@p_TripID", TripID);
                command.Parameters["@p_TripID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_RouteID", RouteID);
                command.Parameters["@p_RouteID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_TownID", TownID);
                command.Parameters["@p_TownID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_TownshipID", TownshipID);
                command.Parameters["@p_TownshipID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_CustomerType", CustomerType);
                command.Parameters["@p_CustomerType"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_StartDate", StartDate);
                command.Parameters["@p_StartDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_EndDate", EndDate);
                command.Parameters["@p_EndDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
        
        #endregion

        #region QOB_Markeing
        #region QOB2
        /// <summary>
        /// Select New Outlet DataTable by specifying Start Date and BrandID
        /// </summary>
        /// <param name="StartDate">Start date</param>
        /// <param name="endDate">BrandID</param>
        /// <returns>New Outlet QOB DataTable</returns>
        public static DataTable SelectNewOutletQOBBy(DateTime StartDate, int BrandID)
        {
            string queryString = string.Format("EXEC usp_RP_Marketing_QOB2 '{0}', '{1}' ",
                StartDate.ToString("yyyy-MM-dd"),BrandID);
            return _dataAccess.SelectByQuery(queryString);
        }

        public static DataTable SelectComplaintImprovementQOBBy(DateTime StartDate)
        {
            string queryString = string.Format("EXEC usp_RP_Marketing_QOB5 '{0}' ",
                StartDate.ToString("yyyy-MM-dd"));
            return _dataAccess.SelectByQuery(queryString);
        }
        
        #endregion
        #endregion
    }
}

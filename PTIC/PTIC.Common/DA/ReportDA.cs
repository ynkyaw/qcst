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
            //string queryString = string.Format("EXEC usp_AP_PlanSummarySelectBy '{0}', '{1}' ", 
            //    startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));

            string []month = {"Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"};
            string template = "SELECT AP_Planning.A_P_Material as A_P_MaterialID,";
            template +="'' {7},ISNULL([{0}],0) as PrevMonthBalAmt_1,";
            template +="ISNULL([{1}],0) as PlanAmt_1,";
            template +="ISNULL([{0}],0)+ISNULL([{1}],0) as AvailableAmt_1,";
            template += "ISNULL(Used_{1},0) as UsedAmt_1,";
            template +="(ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0)) as ThisMonthBalAmt_1,";
            template +="'' {8},(ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0)) as PrevMonthBalAmt_2,";
            template +="ISNULL([{2}],0) as PlanAmt_2";
            template +=",(ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0) as AvailableAmt_2";
            template +=",ISNULL(Used_{2},0) as UsedAmt_2";
            template +=",((ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0)-ISNULL(Used_{2},0)) as ThisMonthBalAmt_2";
            template +=",'' {9},((ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0)-ISNULL(Used_{2},0)) as PrevMonthBalAmt_3,";
            template +="ISNULL([{3}],0) as PlanAmt_3";
            template +=",((ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0)-ISNULL(Used_{2},0))+ISNULL([{3}],0) as AvailableAmt_3";
            template +=",ISNULL(Used_{3},0) as UsedAmt_3";
            template +=",(((ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0)-ISNULL(Used_{2},0))+ISNULL([{3}],0)-ISNULL(Used_{3},0)) as ThisMonthBalAmt_3";
            template +=",'' {10},(((ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0)-ISNULL(Used_{2},0))+ISNULL([{3}],0)-ISNULL(Used_{3},0)) as PrevMonthBalAmt_3,";
            template +="ISNULL([{4}],0) as PlanAmt_4";
            template +=",(((ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0)-ISNULL(Used_{2},0))+ISNULL([{3}],0)-ISNULL(Used_{3},0))+ISNULL([{4}],0) as AvailableAmt_4";
            template +=",ISNULL(Used_{4},0) as UsedAmt_4";
            template +=",((((ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0)-ISNULL(Used_{2},0))+ISNULL([{3}],0)-ISNULL(Used_{3},0))+ISNULL([{4}],0)-ISNULL(Used_{4},0)) as ThisMonthBalAmt_4";
            template +=",'' {11},((((ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0)-ISNULL(Used_{2},0))+ISNULL([{3}],0)-ISNULL(Used_{3},0))+ISNULL([{4}],0)-ISNULL(Used_{4},0)) as PrevMonthBalAmt_5,";
            template +="ISNULL([{5}],0) as PlanAmt_5";
            template +=",((((ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0)-ISNULL(Used_{2},0))+ISNULL([{3}],0)-ISNULL(Used_{3},0))+ISNULL([{4}],0)-ISNULL(Used_{4},0))+ISNULL([{5}],0) as AvailableAmt_5";
            template +=",ISNULL(Used_{5},0) as UsedAmt_5";
            template +=",(((((ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0)-ISNULL(Used_{2},0))+ISNULL([{3}],0)-ISNULL(Used_{3},0))+ISNULL([{4}],0)-ISNULL(Used_{4},0))+ISNULL([{5}],0)-ISNULL(Used_{5},0)) as ThisMonthBalAmt_5";
            template +=",'' {12},(((((ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0)-ISNULL(Used_{2},0))+ISNULL([{3}],0)-ISNULL(Used_{3},0))+ISNULL([{4}],0)-ISNULL(Used_{4},0))+ISNULL([{5}],0)-ISNULL(Used_{5},0)) as PrevMonthBalAmt_6,";
            template +="ISNULL([{6}],0) as PlanAmt_6";
            template +=",(((((ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0)-ISNULL(Used_{2},0))+ISNULL([{3}],0)-ISNULL(Used_{3},0))+ISNULL([{4}],0)-ISNULL(Used_{4},0))+ISNULL([{5}],0)-ISNULL(Used_{5},0))+ISNULL([{6}],0) as AvailableAmt_6";
            template +=",ISNULL(Used_{6},0) as UsedAmt_6";
            template +=",((((((ISNULL([{0}],0)+ISNULL([{1}],0)-ISNULL(Used_{1},0))+ISNULL([{2}],0)-ISNULL(Used_{2},0))+ISNULL([{3}],0)-ISNULL(Used_{3},0))+ISNULL([{4}],0)-ISNULL(Used_{4},0))+ISNULL([{5}],0)-ISNULL(Used_{5},0))+ISNULL([{6}],0)-ISNULL(Used_{6},0)) as ThisMonthBalAmt_6";
            template +=" FROM (SELECT ISNULL(PrevPlan.A_P_MaterialID,CurrentPlan.A_P_MaterialID) as A_P_Material,[{0}],[{1}],[{2}],[{3}],[{4}],[{5}],[{6}] FROM (";
            template +=" SELECT A_P_MaterialID,SUM(ThisMonthBalAmt_) [{0}] FROM (SELECT AdvPlan.A_P_PlanDate,AdvPlan.A_P_MaterialID,AdvPlan.UsageAmt,IsNull(AdvUsage.PurchaseAmt,0) as PurchasedAmt,AdvPlan.UsageAmt-IsNull(AdvUsage.PurchaseAmt,0) as ThisMonthBalAmt_ FROM (SELECT AP.A_P_PlanDate,APD.A_P_MaterialID,APD.UsageAmt";
            template +=" FROM A_P_Plan AP INNER JOIN A_P_PlanDetail APD ";
            template +=" ON AP.ID=APD.A_P_PlanID ) as AdvPlan LEFT JOIN";
            template +=" (SELECT APED.AP_MaterialID,SUM(APPD.PurchasedQty*APED.UnitCost) AS PurchaseAmt,APE.AP_PlanMonth";
            template +=" FROM AP_EnquiryDetail APED INNER JOIN AP_Enquiry APE ON APE.ID=APED.AP_EnquiryID";
            template +=" INNER JOIN AP_PurchasedDetail APPD ON APED.ID=APPD.AP_EnquiryDetailID";
            template +=" Group By aped.AP_MaterialID,APE.AP_PlanMonth) as AdvUsage";
            template +=" ON AdvPlan.A_P_PlanDate=AdvUsage.AP_PlanMonth";
            template +=" and AdvPlan.A_P_MaterialID=AdvUsage.AP_MaterialID) PrevMonthBalAmt_ThisMonthBalAmt_";
            template +=" where A_P_PlanDate<'{1}'";
            template +=" Group by A_P_MaterialID) PrevPlan";
            template +=" FULL OUTER JOIN (SELECT A_P_MaterialID,SUM(ISNULL([{1}],0)) as [{1}],SUM(ISNULL([{2}],0)) as [{2}],SUM(ISNULL([{3}],0)) as [{3}],SUM(ISNULL([{4}],0)) as [{4}],SUM(ISNULL([{5}],0)) as [{5}],SUM(ISNULL([{6}],0)) as [{6}]";
            template +=" FROM ( SELECT AP.A_P_PlanDate,APD.A_P_MaterialID,APD.UsageAmt as PlanAmount FROM A_P_Plan AP INNER JOIN A_P_PlanDetail APD ";
            template +=" ON AP.ID=APD.A_P_PlanID WHERE AP.A_P_PlanDate>='{1}') as AdvPlan ";
            template +=" PIVOT(SUM(PlanAmount) for A_P_PlanDate in([{1}],[{2}],[{3}],[{4}],[{5}],[{6}]))as Openning";
            template +=" Group By A_P_MaterialID) CurrentPlan";
            template +=" ON PrevPlan.A_P_MaterialID=CurrentPlan.A_P_MaterialID) AP_Planning";
            template +=" LEFT JOIN  (SELECT AP_MaterialID, SUM(ISNULL([{1}],0)) as [Used_{1}], SUM(ISNULL([{2}],0)) as [Used_{2}], SUM(ISNULL([{3}],0)) as [Used_{3}],";
            template +=" SUM(ISNULL([{4}],0)) as [Used_{4}],SUM(ISNULL([{5}],0)) as [Used_{5}],SUM(ISNULL([{6}],0)) as [Used_{6}]";
            template +=" FROM (SELECT APED.AP_MaterialID,SUM(APPD.PurchasedQty*APED.UnitCost) AS PurchaseAmt,APE.AP_PlanMonth";
            template +=" FROM AP_EnquiryDetail APED INNER JOIN AP_Enquiry APE ON APE.ID=APED.AP_EnquiryID";
            template +=" INNER JOIN AP_PurchasedDetail APPD ON APED.ID=APPD.AP_EnquiryDetailID";
            template += " Group By aped.AP_MaterialID,APE.AP_PlanMonth) as AdvUsage";
            template +=" PIVOT(SUM(PurchaseAmt) for AP_PlanMonth in([{1}],[{2}],[{3}],[{4}],[{5}],[{6}]))as Openning";
            template +=" Group By AP_MaterialID) AP_Using";
            template +=" ON AP_Planning.A_P_Material=AP_Using.AP_MaterialID";

            string param0 = startDate.AddMonths(-1).ToString("yyyyMMdd");
            string param1 = startDate.AddMonths(0).ToString("yyyyMMdd");
            string param2 = startDate.AddMonths(1).ToString("yyyyMMdd");
            string param3 = startDate.AddMonths(2).ToString("yyyyMMdd");
            string param4 = startDate.AddMonths(3).ToString("yyyyMMdd");
            string param5 = startDate.AddMonths(4).ToString("yyyyMMdd");
            string param6 = startDate.AddMonths(5).ToString("yyyyMMdd");
            string param7 = month[startDate.Month - 1];
            string param8 = month[startDate.Month];
            string param9 = month[startDate.Month + 1];
            string param10 = month[startDate.Month + 2];
            string param11 = month[startDate.Month + 3];
            string param12 = month[startDate.Month + 4];

            string queryString = string.Format(template,param0,param1,param2,param3,param4,param5,param6,param7,param8,param9,param10,param11,param12);

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

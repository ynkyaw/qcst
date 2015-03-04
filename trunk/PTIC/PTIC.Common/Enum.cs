/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/04/17 (yyyy/MM/dd)
 * Description: Common enum defination
 */

namespace PTIC.Common
{
    /// <summary>
    /// Common enum defination class
    /// </summary>
    public class Enum
    {
        public enum CustomerClass
        {
            A = 1,
            B = 2,
            C = 3
        }

        /// <summary>
        /// Question form : Survey question form
        /// </summary>
        public enum QuestionForm
        {
            Toyo = 1,
            Lion = 2,
            Acid = 3
        }

        /// <summary>
        /// Customer type
        /// </summary>
        public enum CustomerType
        { 
            EndUser = 0,
            RetailOutlet = 1,
            WholeSaleOutlet = 2,
            Company = 3,
            Government = 4,
            Branch = 5
        }

        /// <summary>
        /// Marketing type
        /// </summary>
        public enum MarketingType
        {
            DailyMarketing = 0,
            Telemarketing = 1
        }

        /// <summary>
        /// Cash payment type / Installment time
        /// </summary>
        public enum PayType
        {
            First = 0,
            Partial = 1,
            Final = 2
        }

        /// <summary>
        /// Cash receipt type
        /// </summary>
        public enum CashReceiptType
        {
            Cash = 0,
            Cheque = 1,
            Remittance = 2
        }

        /// <summary>
        /// SaleType
        /// </summary>
        public enum SaleType
        {
            Credit = 0,
            Consignment = 1
        }

        /// <summary>
        /// Voucher type
        /// </summary>
        public enum VoucherType
        { 
            Credit = 0, // Credit Sale Invoice
            Cash = 1 // Cash Sale Invoice
        }

        /// <summary>
        /// By what is Warehouse stock changed
        /// </summary>
        public enum WarehouseStockBy
        { 
            Factory = 0,
            Warehouse = 1,
            Vehicle = 2,
            CustomerOrSale = 3,
            Opening = 4,
            Service = 5
        }

        /// <summary>
        /// By what is Vehicle stock changed
        /// </summary>
        public enum VehicleStockBy
        {
            Warehouse = 0,
            CustomerOrSale = 1,
            Service = 2
        }

        /// <summary>
        /// Describe whether warehouse movement has been requested or received
        /// </summary>
        public enum WarehouseMovementStatus
        {
            Requested = 0,
            Received = 1
        }

        /// <summary>
        /// Describe in where service item (sales) exists
        /// </summary>
        public enum SalesServiceWhereami
        {
            Vehicle = 0,
            Showroom = 1,
            ServiceTeamOrSubstore = 2,
            MainStore = 3, // Factory
            Customer = 4
        }

        /// <summary>
        /// 
        /// </summary>
        public enum SvcTransfer
        {
            Vehicle = 0, 
            Showroom = 1, 
            ServiceTeamOrSubstore = 2, 
            Customer = 3,
            MainStore = 4
        }

        public enum CustomerSalesService // Customer အားဆောင်ရွက်ပေးမှု
        { 
            NewBattery = 0,
            CVC_Battery = 1,
            Repair = 2,
            Other = 3
        }

        /// <summary>
        /// Transport Type ID
        /// </summary>
        public enum PredefinedTransportType
        {
            ExpressID = 1,
            TrainID = 2,
            ShipID = 3,
            AirplaneID = 4,
            VanID = 5,
            OtherID = 6
        }

        /// <summary>
        /// Predefined warehouse ID
        /// </summary>
        public enum PredefinedWarehouse
        {
            FactoryMainStoreID = 1,
            SSBSubStoreID = 2,
            TGGN_ID = 3,
            NOKP_ID = 4
        }

        /// <summary>
        /// Predefined department ID
        /// </summary>
        public enum PredefinedDepartment
        { 
            PTIC = 1,
            HO = 2,
            ExportNImport = 3,
            DirectorOffice = 4,
            AdminNHR = 5,
            Finance = 6,
            Sales = 7,
            Marketing = 8,
            MDOffice = 9
        }

        /// <summary>
        /// POSM usage purpose
        /// </summary>
        public enum POSM_UsagePurpose
        { 
            Outlet = 0,
            Retailer = 1,
            Trip = 2,
            Present = 3,
            Office = 4,
            Other = 5
        }

        /// <summary>
        /// A P request purpose
        /// </summary>
        public enum A_P_RequestPurpose
        {
            Outlet = 0,
            Retailer = 1,
            Trip = 2,
            Present = 3,
            Office = 4,
            Other = 5
        }

        /// <summary>
        /// POSM return purpose
        /// </summary>
        public enum POSM_ReturnPurpose
        {
            Outlet = 0,
            Retailer = 1,
            Trip = 2,
            Present = 3,
            Office = 4,
            Other = 5
        }

        public enum MonthOfYear
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }
              
        /// <summary>
        /// သတင်းရရှိသည့်စနစ်
        /// </summary>
        public enum ReceivedVia
        {
            Phone = 1,
            Mail = 2,
            People = 3,
            Own = 4            
        }

        public enum Day
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday= 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7
        }

        /// <summary>
        /// 
        /// </summary>
        public enum FormStatus
        { 
            Reported = 0,
            Confirmed = 1,
            Rejected = 2 
        }

        /// <summary>
        /// Message sender's action
        /// </summary>
        public enum MessageSenderAction
        {
            Send = 0,
            Reply = 1,
            Forward = 2
        }

        public enum MessageBox 
        {
            Draft = 0,
            Inbox = 1,
            Sentbox = 2,
            Trash = 3
        }

        /// <summary>
        /// Status to show whether user message has been reported or confirmed or rejected
        /// </summary>
        public enum UserMessageStatus
        {
            Pending = 0,
            Confirmed = 1,
            Rejected = 2
        }

        /// <summary>
        /// Customer transition
        /// </summary>
        public enum CustomerTransition
        { 
            Waiting = 0,
            Permanent = 1
        }
    }
}

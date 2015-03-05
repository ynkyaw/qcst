/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: (yyyy/MM/dd)
 * Description: PTIC web service file
 */
using System;
using System.Collections.Generic;
using System.Data;
using PTIC.Sale.BL;
using PTIC.Web.API.Contract.Data;
using PTIC.Common.BL;
using PTIC.Sale.Entities;
using PTIC.Marketing.BL;
using AGL.Util;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Web.API.Contract
{
    /// <summary>
    /// PTIC web service class 
    /// </summary>
    /// 
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class Service :
        IService
    {
        private string _product = "PTIC Web Service Provider";
        private string _description = "RESTful web service of Proven Technology Industrial Co.,Ltd";
        private string _version = "Version 1.0.0";
        private string _author = "Asia Green Leaf Co.,Ltd";

        #region Service Info
        public Info GetInfo()
        {
            Info info = new Info()
            {
                Product = this._product,
                Description = this._description,
                Version = this._version,
                Author = this._author
            };
            return info;
        }
        #endregion

        #region CUSTOMER
        public List<PTIC.Web.API.Contract.Data.Customer> GetCustomers()
        {
            DataTable dt = null;
            List<PTIC.Web.API.Contract.Data.Customer> customers = null;
            try
            {
                customers = new List<PTIC.Web.API.Contract.Data.Customer>();
                CustomerBL customerBL = new CustomerBL();
                dt = customerBL.GetAll();
                foreach (DataRow row in dt.Rows)
                {
                    customers.Add(new PTIC.Web.API.Contract.Data.Customer()
                    {
                        CustomerID = (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), -1),
                        AddrID = (int)DataTypeParser.Parse(row["AddrID"], typeof(int), -1),
                        TownID = (int?)DataTypeParser.Parse(row["TownID"], typeof(int), null),
                        TownshipID = (int?)DataTypeParser.Parse(row["TownshipID"], typeof(int), null),
                        RouteID = (int?)DataTypeParser.Parse(row["RouteID"], typeof(int), null),
                        TripID = (int?)DataTypeParser.Parse(row["TripID"], typeof(int), null),
                        CusType = (int)DataTypeParser.Parse(row["CusType"], typeof(int), -1),
                        CustomerName = (string)DataTypeParser.Parse(row["CusName"], typeof(string), string.Empty),
                        ContactPersonName = (string)DataTypeParser.Parse(row["ConPersonName"], typeof(string), string.Empty),
                        BankAccNo = (string)DataTypeParser.Parse(row["BankAccNo"], typeof(string), string.Empty),
                        CreditAmount = (decimal)DataTypeParser.Parse(row["CreditAmount"], typeof(decimal), 0),
                        CreditLimit = (int)DataTypeParser.Parse(row["CreditLimit"], typeof(int), 0),
                        CreditBalance = (decimal)DataTypeParser.Parse(row["CreditBalance"], typeof(decimal), 0)
                    });
                }
                return customers;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetCustomers
                throw e;
            }
        }

        public List<PTIC.Web.API.Contract.Data.Customer> GetCustomerByRouteID(string routeID)
        {
            if (string.IsNullOrEmpty(routeID))
                return null;
            int rID = (int)DataTypeParser.Parse(routeID, typeof(int), -1);
            DataTable dt = null;
            List<PTIC.Web.API.Contract.Data.Customer> customers = null;
            try
            {
                customers = new List<PTIC.Web.API.Contract.Data.Customer>();
                CustomerBL customerBL = new CustomerBL();
                dt = customerBL.GetByRoutID(rID);
                foreach (DataRow row in dt.Rows)
                {
                    customers.Add(new PTIC.Web.API.Contract.Data.Customer()
                    {
                        CustomerID = (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), -1),
                        AddrID = (int)DataTypeParser.Parse(row["AddrID"], typeof(int), -1),
                        TownID = (int)DataTypeParser.Parse(row["TownID"], typeof(int), -1),
                        Town = (string)DataTypeParser.Parse(row["Town"], typeof(string), string.Empty),
                        TownshipID = (int)DataTypeParser.Parse(row["TownshipID"], typeof(int), -1),
                        Township = (string)DataTypeParser.Parse(row["Township"], typeof(string), string.Empty),
                        RouteID = (int?)DataTypeParser.Parse(row["RouteID"], typeof(int), null),
                        TripID = (int?)DataTypeParser.Parse(row["TripID"], typeof(int), null),
                        CusType = (int)DataTypeParser.Parse(row["CusType"], typeof(int), -1),
                        CustomerName = (string)DataTypeParser.Parse(row["CusName"], typeof(string), string.Empty),
                        ContactPersonName = (string)DataTypeParser.Parse(row["ConPersonName"], typeof(string), string.Empty),
                        CreditAmount = (decimal)DataTypeParser.Parse(row["CreditAmount"], typeof(decimal), 0),
                        CreditLimit = (int)DataTypeParser.Parse(row["CreditLimit"], typeof(int), 0),
                        CreditBalance = (decimal)DataTypeParser.Parse(row["CreditBalance"], typeof(decimal), 0)
                    });
                }
                return customers;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetCustomers
                throw;
            }
        }

        public List<PTIC.Web.API.Contract.Data.Customer> GetCustomerByTripID(string tripID)
        {
            if (string.IsNullOrEmpty(tripID))
                return null;
            int tID = (int)DataTypeParser.Parse(tripID, typeof(int), -1);
            DataTable dt = null;
            List<PTIC.Web.API.Contract.Data.Customer> customers = null;
            try
            {
                customers = new List<PTIC.Web.API.Contract.Data.Customer>();
                CustomerBL customerBL = new CustomerBL();
                dt = customerBL.GetByTripID(tID);
                foreach (DataRow row in dt.Rows)
                {
                    customers.Add(new PTIC.Web.API.Contract.Data.Customer()
                    {
                        CustomerID = (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), -1),
                        AddrID = (int)DataTypeParser.Parse(row["AddrID"], typeof(int), -1),
                        TownID = (int)DataTypeParser.Parse(row["TownID"], typeof(int), -1),
                        Town = (string)DataTypeParser.Parse(row["Town"], typeof(string), string.Empty),
                        TownshipID = (int)DataTypeParser.Parse(row["TownshipID"], typeof(int), -1),
                        Township = (string)DataTypeParser.Parse(row["Township"], typeof(string), string.Empty),
                        RouteID = (int?)DataTypeParser.Parse(row["RouteID"], typeof(int), null),
                        TripID = (int?)DataTypeParser.Parse(row["TripID"], typeof(int), null),
                        CusType = (int)DataTypeParser.Parse(row["CusType"], typeof(int), -1),
                        CustomerName = (string)DataTypeParser.Parse(row["CusName"], typeof(string), string.Empty),
                        ContactPersonName = (string)DataTypeParser.Parse(row["ConPersonName"], typeof(string), string.Empty),
                        CreditAmount = (decimal)DataTypeParser.Parse(row["CreditAmount"], typeof(decimal), 0),
                        CreditLimit = (int)DataTypeParser.Parse(row["CreditLimit"], typeof(int), 0),
                        CreditBalance = (decimal)DataTypeParser.Parse(row["CreditBalance"], typeof(decimal), 0)
                    });
                }
                return customers;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetCustomers
                throw;
            }
        }

        public string AddCustomer(PTIC.Web.API.Contract.Data.Customer newCustomer)
        {
            if (newCustomer == null)
                return null;
            // TODO: Validation input @AddCustomer in Service.svc
            PTIC.Sale.Entities.Customer newPotentialCustomer = new PTIC.Sale.Entities.Customer()
            {
                CusName = newCustomer.CustomerName,
                Phone1 = newCustomer.Phone1,
                Phone2 = newCustomer.Phone2,
                CusDate = DateTime.Now,
                CusClassID = 3, // Class C
                IsPotential = true, // it is a temp customer
                RouteID = newCustomer.RouteID,
                TripID = newCustomer.TripID
            };
            PTIC.Sale.Entities.Address newAddress = new PTIC.Sale.Entities.Address()
            {
                TownID = (int?)DataTypeParser.Parse(newCustomer.TownID, typeof(int), null),
                TownshipID = (int?)DataTypeParser.Parse(newCustomer.TownshipID, typeof(int), null)
            };
            PTIC.Sale.Entities.ContactPerson newContactPerson = new PTIC.Sale.Entities.ContactPerson()
            {
                ContactPersonName = newCustomer.ContactPersonName,
                DOB = DateTime.Now.AddYears(-16),
            };
            // Set a new inserted customer ID
            return (string)DataTypeParser.Parse(new CustomerBL().Add(newPotentialCustomer, newAddress, newContactPerson), typeof(string), string.Empty);
        }
        #endregion

        #region ROUTE
        public List<PTIC.Web.API.Contract.Data.Route> GetRoutes()
        {
            DataTable tbRoute = null;
            List<PTIC.Web.API.Contract.Data.Route> routes = null;
            try
            {
                tbRoute = new RouteBL().GetAll();
                routes = new List<PTIC.Web.API.Contract.Data.Route>();
                foreach (DataRow row in tbRoute.Rows)
                {
                    routes.Add(new PTIC.Web.API.Contract.Data.Route()
                    {
                        RouteID = (int)DataTypeParser.Parse(row["RouteID"], typeof(int), -1),
                        RouteName = (string)DataTypeParser.Parse(row["RouteName"], typeof(string), string.Empty),
                        Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), String.Empty)
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return routes;
        }
        #endregion

        #region TRIP
        public List<PTIC.Web.API.Contract.Data.Trip> GetTrips()
        {
            DataTable tbTrip = null;
            List<PTIC.Web.API.Contract.Data.Trip> trips = null;
            try
            {
                tbTrip = new TripBL().GetAll();
                trips = new List<PTIC.Web.API.Contract.Data.Trip>();
                foreach (DataRow row in tbTrip.Rows)
                {
                    trips.Add(new PTIC.Web.API.Contract.Data.Trip()
                    {
                        TripID = (int)DataTypeParser.Parse(row["TripID"], typeof(int), -1),
                        TripName = (string)DataTypeParser.Parse(row["TripName"], typeof(string), string.Empty),
                        TripPeriod = (int)DataTypeParser.Parse(row["TripPeriod"], typeof(int), 0),
                        Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), String.Empty)
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return trips;
        }
        #endregion

        #region PRODUCT
        public List<PTIC.Web.API.Contract.Data.Product> GetProducts()
        {
            DataTable tbProducts = null;
            List<PTIC.Web.API.Contract.Data.Product> products = null;

            try
            {
                tbProducts = new ProductBL().GetAll();
                products = new List<PTIC.Web.API.Contract.Data.Product>();
                foreach (DataRow row in tbProducts.Rows)
                {
                    products.Add(new PTIC.Web.API.Contract.Data.Product()
                    {
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                        ProductName = (string)DataTypeParser.Parse(row["ProductName"], typeof(string), string.Empty),
                        NoPerPack = (int)DataTypeParser.Parse(row["NoPerPack"], typeof(int), string.Empty)
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return products;
        }

        public List<ProductPrice> GetPriceList()
        {
            DataTable tbProduct = null;
            List<ProductPrice> products = null;

            tbProduct = new ProductBL().GetPriceList();
            products = new List<ProductPrice>();
            foreach (DataRow row in tbProduct.Rows)
            {
                products.Add(new ProductPrice()
                {
                    ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                    ProductName = (string)DataTypeParser.Parse(row["ProductName"], typeof(string), string.Empty),
                    BrandName = (string)DataTypeParser.Parse(row["BrandName"], typeof(string), string.Empty),
                    Plate = (int)DataTypeParser.Parse(row["Plate"], typeof(int), 0),
                    AcidPrice = (decimal)DataTypeParser.Parse(row["AcidPrice"], typeof(decimal), 0),
                    WholeSalePrice = (decimal)DataTypeParser.Parse(row["WSPrice"], typeof(decimal), 0),
                    RetailSalePrice = (decimal)DataTypeParser.Parse(row["RSPrice"], typeof(decimal), 0),
                    WSPriceWithAcid = (decimal)DataTypeParser.Parse(row["WSPriceWithAcid"], typeof(decimal), 0),
                    RSPriceWithAcid = (decimal)DataTypeParser.Parse(row["RSPriceWithAcid"], typeof(decimal), 0)
                });
            }
            return products;
        }
        #endregion

        #region DELIVERY
        public List<PTIC.Web.API.Contract.Data.Delivery> GetDeliveries()
        {
            DataTable tbPlannedOrders = null;
            List<PTIC.Web.API.Contract.Data.Delivery> deliveries = null;
            try
            {
                tbPlannedOrders = new DeliveryBL().GetPlanned(); // Get planned order (Status : 0)
                deliveries = new List<PTIC.Web.API.Contract.Data.Delivery>();
                foreach (DataRow row in tbPlannedOrders.Rows)
                {
                    deliveries.Add(new PTIC.Web.API.Contract.Data.Delivery()
                    {
                        DeliveryID = (int)DataTypeParser.Parse(row["DeliveryID"], typeof(int), -1),
                        OrderID = (int)DataTypeParser.Parse(row["OrderID"], typeof(int), -1),
                        OrderNo = (string)DataTypeParser.Parse(row["OrderNo"], typeof(string), string.Empty),
                        VenID = (int)DataTypeParser.Parse(row["VenID"], typeof(int), -1),
                        CusID = (int)DataTypeParser.Parse(row["CusID"], typeof(int), -1),
                        SalesPersonID = (int)DataTypeParser.Parse(row["SalesPersonID"], typeof(int), -1),
                        GateID = (int)DataTypeParser.Parse(row["GateID"], typeof(int), -1),
                        DeliveryNo = (string)DataTypeParser.Parse(row["DeliveryNo"], typeof(string), string.Empty),
                        DeliveryDate = ((DateTime)DataTypeParser.Parse(row["DeliveryDate"], typeof(DateTime), DateTime.Now)).ToString("yyyy-MM-dd"),
                        Status = (bool)DataTypeParser.Parse(row["Status"], typeof(bool), false),
                    });
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return deliveries;
        }

        public List<PTIC.Web.API.Contract.Data.DeliveryDetail> GetDeliveryDetailsByDeliveryID(string delivery_id)
        {
            if (string.IsNullOrEmpty(delivery_id))
                return null;
            int deliveryID = (int)DataTypeParser.Parse(delivery_id, typeof(int), -1);
            if (deliveryID == -1)
                return null;
            //SqlConnection conn = null;
            DataTable tbDetails = null;
            List<PTIC.Web.API.Contract.Data.DeliveryDetail> details = null;
            try
            {
                //conn = DBManager.GetInstance().GetDbConnection();
                tbDetails = new DeliveryDetailBL().GetByDeliveryID(deliveryID);
                details = new List<PTIC.Web.API.Contract.Data.DeliveryDetail>();
                foreach (DataRow row in tbDetails.Rows)
                {
                    details.Add(new PTIC.Web.API.Contract.Data.DeliveryDetail()
                    {
                        DeliveryDetailID = (int)DataTypeParser.Parse(row["DeliveryDetailID"], typeof(int), -1),
                        DeliveryID = (int)DataTypeParser.Parse(row["DeliveryID"], typeof(int), -1),
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                        OrderQty = (int)DataTypeParser.Parse(row["OrderQty"], typeof(int), -1),
                        DeliverQty = (int)DataTypeParser.Parse(row["DeliverQty"], typeof(int), -1)
                    });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return details;
        }
        #endregion

        #region BANK
        public List<PTIC.Web.API.Contract.Data.Bank> GetBanks()
        {
            DataTable dt = null;
            List<PTIC.Web.API.Contract.Data.Bank> banks = null;
            try
            {
                banks = new List<PTIC.Web.API.Contract.Data.Bank>();
                BankBL bankBL = new BankBL();
                dt = bankBL.GetAll();
                foreach (DataRow row in dt.Rows)
                {
                    banks.Add(new PTIC.Web.API.Contract.Data.Bank()
                    {
                        BankID = (int)DataTypeParser.Parse(row["BankID"], typeof(int), -1),
                        BankName = (string)DataTypeParser.Parse(row["Bank"], typeof(string), string.Empty),
                        TownID = (int?)DataTypeParser.Parse(row["TownID"], typeof(int), null),
                        BankAddress = (string)DataTypeParser.Parse(row["BankAddress"], typeof(string), string.Empty),
                        Phone = (string)DataTypeParser.Parse(row["Phone"], typeof(string), string.Empty),
                    });
                }
                return banks;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetBanks
                throw e;
            }
        }
        #endregion

        #region SALES INVOICE
        public List<PTIC.Web.API.Contract.Data.Invoice> GetInvoicesByRouteID(string routeID)
        {
            if (string.IsNullOrEmpty(routeID))
                return null;
            int rouetID = (int)DataTypeParser.Parse(routeID, typeof(int), -1);
            if (rouetID == -1)
                return null;
            //SqlConnection conn = null;
            DataTable tbInvoices = null;
            List<PTIC.Web.API.Contract.Data.Invoice> invoices = null;
            try
            {
                tbInvoices = new ReportBL().GetInvoicesByRouteID(rouetID);
                invoices = new List<PTIC.Web.API.Contract.Data.Invoice>();
                foreach (DataRow row in tbInvoices.Rows)
                {
                    invoices.Add(new PTIC.Web.API.Contract.Data.Invoice()
                    {
                        ID = (int)DataTypeParser.Parse(row["InvoiceID"], typeof(int), -1),
                        DeliveryID = (int)DataTypeParser.Parse(row["DeliveryID"], typeof(int), -1),
                        CusID = (int)DataTypeParser.Parse(row["CusID"], typeof(int), -1),
                        SaleType = (int)DataTypeParser.Parse(row["SaleType"], typeof(int), -1),
                        TransportTypeID = (int)DataTypeParser.Parse(row["TransportTypeID"], typeof(int), -1),
                        TransportGateID = (int)DataTypeParser.Parse(row["TransportGateID"], typeof(int), -1),
                        InvoiceNo = (string)DataTypeParser.Parse(row["InvoiceNo"], typeof(string), string.Empty),
                        SalesDate = (DateTime)DataTypeParser.Parse(row["SalesDate"], typeof(DateTime), DateTime.Now),
                        BalanceAmt = (decimal)DataTypeParser.Parse(row["BalanceAmt"], typeof(decimal), 0)
                    });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return invoices;
        }

        public List<PTIC.Web.API.Contract.Data.Invoice> GetInvoicesByTripID(string trip_id)
        {
            if (string.IsNullOrEmpty(trip_id))
                return null;
            int tripID = (int)DataTypeParser.Parse(trip_id, typeof(int), -1);
            if (tripID == -1)
                return null;

            DataTable tbInvoices = null;
            List<PTIC.Web.API.Contract.Data.Invoice> invoices = null;
            try
            {
                tbInvoices = new ReportBL().GetInvoicesByTripID(tripID);
                invoices = new List<PTIC.Web.API.Contract.Data.Invoice>();
                foreach (DataRow row in tbInvoices.Rows)
                {
                    invoices.Add(new PTIC.Web.API.Contract.Data.Invoice()
                    {
                        ID = (int)DataTypeParser.Parse(row["InvoiceID"], typeof(int), -1),
                        DeliveryID = (int)DataTypeParser.Parse(row["DeliveryID"], typeof(int), -1),
                        CusID = (int)DataTypeParser.Parse(row["CusID"], typeof(int), -1),
                        SaleType = (int)DataTypeParser.Parse(row["SaleType"], typeof(int), -1),
                        TransportTypeID = (int)DataTypeParser.Parse(row["TransportTypeID"], typeof(int), -1),
                        TransportGateID = (int)DataTypeParser.Parse(row["TransportGateID"], typeof(int), -1),
                        InvoiceNo = (string)DataTypeParser.Parse(row["InvoiceNo"], typeof(string), string.Empty),
                        SalesDate = (DateTime)DataTypeParser.Parse(row["SalesDate"], typeof(DateTime), DateTime.Now),
                        BalanceAmt = (decimal)DataTypeParser.Parse(row["BalanceAmt"], typeof(decimal), 0)
                    });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return invoices;
        }

        public List<SalesInvoiceDetail> GetSalesInvoiceDetailsByInvoiceID(string invoice_id)
        {
            if (string.IsNullOrEmpty(invoice_id))
                return null;
            int invoiceID = (int)DataTypeParser.Parse(invoice_id, typeof(int), -1);
            if (invoiceID == -1)
                return null;
            DataTable tbDetails = null;
            List<SalesInvoiceDetail> details = null;
            try
            {
                tbDetails = new InvoiceBL().GetSaleDetailByInvoiceID(invoiceID);
                details = new List<SalesInvoiceDetail>();
                foreach (DataRow row in tbDetails.Rows)
                {
                    details.Add(new SalesInvoiceDetail()
                    {
                        ID = (int)DataTypeParser.Parse(row["ID"], typeof(int), -1),
                        InvoiceID = (int)DataTypeParser.Parse(row["InvoiceID"], typeof(int), -1),
                        BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                        SalePrice = (int)DataTypeParser.Parse(row["SalePrice"], typeof(int), -1),
                        Qty = (int)DataTypeParser.Parse(row["Qty"], typeof(int), -1),
                        Package = (int)DataTypeParser.Parse(row["Package"], typeof(int), -1),
                        Amount = (decimal)DataTypeParser.Parse(row["Amount"], typeof(decimal), -1),
                        CustomerID = (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), -1),
                    });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return details;
        }

        public List<PTIC.Web.API.Contract.Data.Payment> GetPaymentDetailsByInvoiceID(string invoice_id)
        {
            if (string.IsNullOrEmpty(invoice_id))
                return null;
            int invoiceID = (int)DataTypeParser.Parse(invoice_id, typeof(int), -1);
            if (invoiceID == -1)
                return null;
            DataTable tbDetails = null;
            List<PTIC.Web.API.Contract.Data.Payment> details = null;
            try
            {
                tbDetails = new PaymentBL().GetAllReceipt(invoiceID);
                details = new List<PTIC.Web.API.Contract.Data.Payment>();
                foreach (DataRow row in tbDetails.Rows)
                {
                    details.Add(new PTIC.Web.API.Contract.Data.Payment()
                    {
                        InvoiceID = (int)DataTypeParser.Parse(row["InvoiceID"], typeof(int), -1),
                        PayType = (int)DataTypeParser.Parse(row["PayType"], typeof(int), -1),
                        CashReceiptType = (int)DataTypeParser.Parse(row["CashReceiptType"], typeof(int), -1),
                        SalesPerson = (string)DataTypeParser.Parse(row["EmpName"], typeof(string), string.Empty),
                        ReceiptNo = (string)DataTypeParser.Parse(row["ReceiptNo"], typeof(string), string.Empty),
                        //PayDate = ((DateTime)DataTypeParser.Parse(row["PayDate"], typeof(DateTime), DateTime.Now)).ToString("yyyy-MM-dd"),
                        PayDate = (DateTime)DataTypeParser.Parse(row["PayType"], typeof(DateTime), DateTime.Now),
                        PaidAmt = (decimal)DataTypeParser.Parse(row["PaidAmt"], typeof(decimal), -1),
                        BalanceAmt = (int)DataTypeParser.Parse(row["BalanceAmt"], typeof(int), -1),
                    });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return details;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newCreditInvoice"></param>
        public void AddCreditInvoice(Data.Invoice newCreditInvoice)
        {
            if (newCreditInvoice == null ||
                newCreditInvoice.InvoiceDetails == null || newCreditInvoice.InvoiceDetails.Count < 1)
            {
                throw new Exception("Please fill invoice and sale products correctly!");
            }

            InvoiceBL invoiceSaver = null;
            List<SaleDetail> details = null;
            try
            {
                invoiceSaver = new InvoiceBL();
                details = new List<SaleDetail>();
                // Set credit invoice
                Sale.Entities.Invoice invoice = new Sale.Entities.Invoice()
                {
                    SalesDate = newCreditInvoice.SalesDate,
                    DeliveryID = newCreditInvoice.DeliveryID.HasValue ? newCreditInvoice.DeliveryID.Value : (int?)null,
                    CusID = newCreditInvoice.CusID,
                    SalesPersonID = newCreditInvoice.SalesPersonID,
                    TransportTypeID = newCreditInvoice.TransportTypeID,
                    TransportGateID = newCreditInvoice.TransportGateID.HasValue ? newCreditInvoice.TransportGateID.Value : (int?)null,
                    SaleType = newCreditInvoice.SaleType,
                    GateInvNo = newCreditInvoice.GateInvNo,
                    TransportCharges = newCreditInvoice.TransportCharges,
                    VoucherType = (int)PTIC.Common.Enum.VoucherType.Credit,
                    TotalAmt = newCreditInvoice.TotalAmt,
                    //Remark = (string)DataTypeParser.Parse(txtRemark.Text, typeof(string), null),
                    InvoiceNo = newCreditInvoice.InvoiceNo
                };
                // Set sales details
                foreach (SalesInvoiceDetail svcDetail in newCreditInvoice.InvoiceDetails)
                {
                    SaleDetail newSaleDetailRecord = new SaleDetail()
                    {
                        ProductID = svcDetail.ProductID,
                        SalePrice = svcDetail.SalePrice,
                        Qty = svcDetail.Qty,
                        Amount = svcDetail.Qty * svcDetail.SalePrice,
                        Package = svcDetail.Package,
                    };
                    details.Add(newSaleDetailRecord);
                }
                // Sold from warehouse or vehicle
                // TODO: do not pass zero as default
                int vehicleID = newCreditInvoice.VehicleID.HasValue ? newCreditInvoice.VehicleID.Value : 0;
                int warehouseID = newCreditInvoice.WarehouseID.HasValue ? newCreditInvoice.WarehouseID.Value : 0;

                // Save
                invoiceSaver.Add(
                    invoice,
                    details,
                    vehicleID,
                    warehouseID);
                if (!invoiceSaver.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(invoiceSaver.ValidationResults) as ValidationResult;
                    throw new Exception(err.Message);
                }
            }
            catch (Exception e)
            {
                // TODO: log error                
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newCashInvoice"></param>
        public void AddCashInvoice
            (
                Data.Invoice newCashInvoice, 
                Data.CommDiscount newCommDiscount, 
                Data.Tax newTax,
                int vehicleID
            )
        {
            if (newCashInvoice == null)
            {
                throw new Exception("Null Invoice!");
            }
            else if(newCashInvoice.InvoiceDetails == null || newCashInvoice.InvoiceDetails.Count < 1)
            {
                throw new Exception("Null InvoiceDetails!");
            }

            InvoiceBL invoiceSaver = null;
            List<SaleDetail> details = null;
            PTIC.Sale.Entities.CommDiscount commDis = null;
            PTIC.Sale.Entities.Tax tax = null;
            try
            {
                invoiceSaver = new InvoiceBL();
                details = new List<SaleDetail>();

                // Set Invoice
                PTIC.Sale.Entities.Invoice invoice = new Sale.Entities.Invoice()
                {
                    CusID = newCashInvoice.CusID,
                    SalesPersonID = newCashInvoice.SalesPersonID,
                    SalesDate = newCashInvoice.SalesDate,
                    InvoiceNo = string.IsNullOrEmpty(newCashInvoice.InvoiceNo) ? null : newCashInvoice.InvoiceNo,
                    TransportTypeID = (int)PTIC.Common.Enum.PredefinedTransportType.VanID, // Purpose: Skip field validation, it is not saved in db
                    
                    TotalAmt = newCashInvoice.TotalAmt,
                    CommDiscAmt = newCashInvoice.CommDiscAmt,
                    OtherAmt = newCashInvoice.OtherAmt,
                    NetAmt = newCashInvoice.NetAmt
                };                                
                // Set cash sales details
                foreach (SalesInvoiceDetail svcDetail in newCashInvoice.InvoiceDetails)
                {
                    SaleDetail newSaleDetailRecord = new SaleDetail()
                    {
                        ProductID = svcDetail.ProductID,
                        SalePrice = svcDetail.SalePrice,
                        Qty = svcDetail.Qty,
                        Package = svcDetail.Package,
                        Amount = svcDetail.Qty * svcDetail.SalePrice,
                    };
                    details.Add(newSaleDetailRecord);
                }
                // Set CommDiscount if present
                if (newCommDiscount != null)
                {
                    commDis = new Sale.Entities.CommDiscount()
                    {
                        PackingAmt = newCommDiscount.PackingAmt,
                        SaleCommAmt = newCommDiscount.SaleCommAmt,
                        CashCommAmt = newCommDiscount.CashCommAmt,
                        OtherCommAmt = newCommDiscount.OtherCommAmt,
                        RefundAmt = newCommDiscount.RefundAmt,
                        NeedAmt = newCommDiscount.NeedAmt,
                        TotalCommAmt = newCommDiscount.TotalCommAmt,
                    };
                }
                // Set Tax if present
                if (newTax != null)
                {
                    tax = new Sale.Entities.Tax()
                    {
                        InsuranceAmt = newTax.InsuranceAmt,
                        TaxAmt = newTax.TaxAmt,
                        TransportAmt = newTax.TransportAmt,
                        GateInvNo = newTax.GateInvNo,
                        TotalAmt = newTax.TotalAmt
                    };
                }
                // Save into db
                int? insertedInvoiceID = invoiceSaver.CashSaleFromVehicle(invoice, details, vehicleID, commDis, tax);
                if (!invoiceSaver.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(invoiceSaver.ValidationResults) as ValidationResult;
                    throw new Exception(err.Message);
                }
                else // Successful validation
                {
                    // Success in db also
                    if (!insertedInvoiceID.HasValue)
                    {
                        throw new Exception("Cannot save Cash Sale!");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region CASH COLLECTION
        /// <summary>
        ///
        /// </summary>
        /// <param name="newPayment"></param>
        public void AddPayment(Data.Payment newPayment)
        {
            try
            {
                if (newPayment == null)
                    throw new Exception("Null payment!");

                PaymentBL paymentSaver = new PaymentBL();
                PTIC.Sale.Entities.Payment payment = new Sale.Entities.Payment() 
                {
                    ReceiptNo = newPayment.ReceiptNo,
                    BankID = newPayment.BankID,
                    SalesPersonID = newPayment.SalesPersonID,
                    InvoiceID = newPayment.InvoiceID,
                    PayDate = newPayment.PayDate,
                    CommDisAmt = newPayment.CommDisAmt,
                    OtherAmt = newPayment.OtherAmt,
                    PaidAmt = newPayment.PaidAmt
                };
                // Set PayType
                if (newPayment.PayType == (int)PTIC.Common.Enum.PayType.First)
                {
                    payment.PayType = PTIC.Common.Enum.PayType.First;
                }
                else if (newPayment.PayType == (int)PTIC.Common.Enum.PayType.Partial)
                {
                    payment.PayType = PTIC.Common.Enum.PayType.Partial;
                }
                else if (newPayment.PayType == (int)PTIC.Common.Enum.PayType.Final)
                {
                    payment.PayType = PTIC.Common.Enum.PayType.Final;
                }
                // Set CashReceiptType
                if (newPayment.CashReceiptType == (int)PTIC.Common.Enum.CashReceiptType.Cash)
                {
                    payment.CashReceiptType = PTIC.Common.Enum.CashReceiptType.Cash;
                }
                else if (newPayment.CashReceiptType == (int)PTIC.Common.Enum.CashReceiptType.Cheque)
                {
                    payment.CashReceiptType = PTIC.Common.Enum.CashReceiptType.Cheque;
                }
                else if (newPayment.CashReceiptType == (int)PTIC.Common.Enum.CashReceiptType.Remittance)
                {
                    payment.CashReceiptType = PTIC.Common.Enum.CashReceiptType.Remittance;
                }

                // Save payment
                int? insertedPaymentID = paymentSaver.Add(payment);
                if (!paymentSaver.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(paymentSaver.ValidationResults) as ValidationResult;
                    throw new Exception(err.Message);
                }
                else // Successful validation
                {
                    // Success in db also
                    if (!insertedPaymentID.HasValue)
                    {
                        throw new Exception("Cannot save payment! :'(");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
        #endregion

        #region BRAND
        public List<PTIC.Web.API.Contract.Data.Brand> GetBrands()
        {
            DataTable dt = null;
            List<PTIC.Web.API.Contract.Data.Brand> brands = null;
            try
            {
                brands = new List<PTIC.Web.API.Contract.Data.Brand>();
                BrandBL brandBL = new BrandBL();
                dt = brandBL.GetAll();
                foreach (DataRow row in dt.Rows)
                {
                    brands.Add(new PTIC.Web.API.Contract.Data.Brand()
                    {
                        ID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                        BrandName = (string)DataTypeParser.Parse(row["BrandName"], typeof(string), string.Empty)
                    });
                }
                return brands;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetBanks
                throw e;
            }
        }

        public List<PTIC.Web.API.Contract.Data.CompetitorBrand> GetCompetitorBrands()
        {
            DataTable dt = null;
            List<PTIC.Web.API.Contract.Data.CompetitorBrand> competitorbrands = null;
            try
            {
                competitorbrands = new List<PTIC.Web.API.Contract.Data.CompetitorBrand>();
                BrandBL brandBL = new BrandBL();
                dt = brandBL.GetAllCompetitorBrand();
                foreach (DataRow row in dt.Rows)
                {
                    competitorbrands.Add(new PTIC.Web.API.Contract.Data.CompetitorBrand()
                    {
                        ID = (int)DataTypeParser.Parse(row["ID"], typeof(int), -1),
                        CompetitorBrands = (string)DataTypeParser.Parse(row["CompetitorBrand"], typeof(string), string.Empty),
                        Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), string.Empty)
                    });
                }
                return competitorbrands;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetBanks
                throw e;
            }
        }
        #endregion

        #region PRODUCTSUBCATEGORY
        public List<PTIC.Web.API.Contract.Data.ProductSubCategory> GetProductSubCategory()
        {
            DataTable dt = null;
            List<PTIC.Web.API.Contract.Data.ProductSubCategory> productSubCategory = null;
            try
            {
                productSubCategory = new List<PTIC.Web.API.Contract.Data.ProductSubCategory>();
                SubCategoryBL prodcutSubCatBL = new SubCategoryBL();
                dt = prodcutSubCatBL.GetAll();
                foreach (DataRow row in dt.Rows)
                {
                    productSubCategory.Add(new PTIC.Web.API.Contract.Data.ProductSubCategory()
                    {
                        ID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                        CategoryID = (int)DataTypeParser.Parse(row["CategoryID"], typeof(int), -1),
                        SubCategoryName = (string)DataTypeParser.Parse(row["SubCategoryName"], typeof(string), string.Empty),
                        Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), string.Empty)
                    });
                }
                return productSubCategory;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetBanks
                throw e;
            }
        }
        #endregion

        #region PRODUCTCATEGORY
        public List<PTIC.Web.API.Contract.Data.ProductCategory> GetProductCategory()
        {
            DataTable dt = null;
            List<PTIC.Web.API.Contract.Data.ProductCategory> productCategory = null;
            try
            {
                productCategory = new List<PTIC.Web.API.Contract.Data.ProductCategory>();
                CategoryBL productCatBL = new CategoryBL();
                dt = productCatBL.GetAll();
                foreach (DataRow row in dt.Rows)
                {
                    productCategory.Add(new PTIC.Web.API.Contract.Data.ProductCategory()
                    {
                        ID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                        BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                        CategoryName = (string)DataTypeParser.Parse(row["CategoryName"], typeof(string), string.Empty),
                        Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), string.Empty)
                    });
                }
                return productCategory;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetBanks
                throw e;
            }
        }
        #endregion

        #region TRANSPORTTYPE
        public List<PTIC.Web.API.Contract.Data.TransportType> GetTransportTypes()
        {
            DataTable dt = null;
            List<PTIC.Web.API.Contract.Data.TransportType> transportType = null;
            try
            {
                transportType = new List<PTIC.Web.API.Contract.Data.TransportType>();
                TransportTypeBL transportBL = new TransportTypeBL();
                dt = transportBL.GetAll();
                foreach (DataRow row in dt.Rows)
                {
                    transportType.Add(new PTIC.Web.API.Contract.Data.TransportType()
                    {
                        TransportTypeID = (int)DataTypeParser.Parse(row["TransportTypeID"], typeof(int), -1),
                        TransportTypeName = (string)DataTypeParser.Parse(row["TransportTypeName"], typeof(string), string.Empty)
                    });
                }
                return transportType;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetBanks
                throw e;
            }
        }
        #endregion

        #region TRANSPORTGATE
        public List<PTIC.Web.API.Contract.Data.TransportGate> GetTransportGates()
        {
            DataTable dt = null;
            List<PTIC.Web.API.Contract.Data.TransportGate> transportGate = null;
            try
            {
                transportGate = new List<PTIC.Web.API.Contract.Data.TransportGate>();
                TransportGateBL transportgateBL = new TransportGateBL();
                dt = transportgateBL.GetAll();
                foreach (DataRow row in dt.Rows)
                {
                    transportGate.Add(new PTIC.Web.API.Contract.Data.TransportGate()
                    {
                        TransportGateID = (int)DataTypeParser.Parse(row["TransportGateID"], typeof(int), -1),
                        TransportTypeID = (int)DataTypeParser.Parse(row["TransportTypeID"], typeof(int), -1),
                        GateName = (string)DataTypeParser.Parse(row["GateName"], typeof(string), string.Empty),
                        Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), string.Empty)
                    });
                }
                return transportGate;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetBanks
                throw e;
            }
        }
        #endregion

        #region EMPLOYEE
        public List<Employee> GetEmployee()
        {
            DataTable dt = null;
            List<Employee> employees = null;
            try
            {
                employees = new List<Employee>();
                EmployeeBL employeeBL = new EmployeeBL();
                dt = employeeBL.GetAll();
                foreach (DataRow row in dt.Rows)
                {
                    employees.Add(new Employee()
                    {
                        ID = (int)DataTypeParser.Parse(row["EmployeeID"], typeof(int), -1),
                        EmpName = (string)DataTypeParser.Parse(row["EmpName"], typeof(string), string.Empty),
                        PostName = (string)DataTypeParser.Parse(row["PostName"], typeof(string), string.Empty),
                        DeptName = (string)DataTypeParser.Parse(row["DeptName"], typeof(string), string.Empty)
                    });
                }
                return employees;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetBanks
                throw e;
            }
        }
        #endregion

        #region ORDER
        public void AddOrder(List<PTIC.Web.API.Contract.Data.Order> newOrders)
        {
            if (newOrders == null || newOrders.Count < 1)
                return;

            OrderBL orderSaver = null;
            try
            {
                orderSaver = new OrderBL();

                foreach (PTIC.Web.API.Contract.Data.Order newOrder in newOrders)
                {
                    // Set order
                    Sale.Entities.Order order = new Sale.Entities.Order()
                    {
                        CusID = (int)DataTypeParser.Parse(newOrder.CusID, typeof(int), -1),
                        OrderReceieverID = (int)DataTypeParser.Parse(newOrder.OrderReceieverID, typeof(int), -1),
                        OrderDate = newOrder.OrderDate,
                        //IsMain = false,
                        //IsDevice = false
                    };
                    // Set order detail
                    List<Sale.Entities.OrderDetail> orderDetails = new List<Sale.Entities.OrderDetail>();
                    foreach (PTIC.Web.API.Contract.Data.OrderDetail detail in newOrder.OrderDetails)
                    {
                        orderDetails.Add(new Sale.Entities.OrderDetail()
                        {
                            //ID = (int)DataTypeParser.Parse(detail.OrderDetailID, typeof(int), -1),
                            //OrderID = (int)DataTypeParser.Parse(row.Cells["colDetailOrderID"].Value, typeof(int), -1),
                            ProductID = (int)DataTypeParser.Parse(detail.ProductID, typeof(int), -1),
                            WSPrice = (decimal)DataTypeParser.Parse(detail.WSPrice, typeof(decimal), 0),
                            RSPrice = (decimal)DataTypeParser.Parse(detail.RSPrice, typeof(decimal), 0),
                            Qty = (int)DataTypeParser.Parse(detail.Qty, typeof(int), 0),
                            Amount = (decimal)DataTypeParser.Parse(detail.Amount, typeof(decimal), 0),
                            Remark = (string)DataTypeParser.Parse(detail.Remark, typeof(string), null),
                        });
                    }
                    // Save a new order into DB
                    // TODO: all orders must be under one transaction
                    orderSaver.Add(order, orderDetails);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<PTIC.Web.API.Contract.Data.OrderDetail> GetOrderDetailByOrderID(string order_id)
        {
            if (string.IsNullOrEmpty(order_id))
                return null;
            int orderID = (int)DataTypeParser.Parse(order_id, typeof(int), -1);
            if (orderID == -1)
                return null;
            //SqlConnection conn = null;
            DataTable tbDetails = null;
            List<PTIC.Web.API.Contract.Data.OrderDetail> details = null;
            try
            {
                //conn = DBManager.GetInstance().GetDbConnection();
                tbDetails = new OrderDetailBL().GetByOrderID(orderID);
                details = new List<PTIC.Web.API.Contract.Data.OrderDetail>();
                foreach (DataRow row in tbDetails.Rows)
                {
                    details.Add(new PTIC.Web.API.Contract.Data.OrderDetail()
                    {
                        OrderDetailID = (int)DataTypeParser.Parse(row["OrderDetailID"], typeof(int), -1),
                        OrderID = (int)DataTypeParser.Parse(row["OrderID"], typeof(int), -1),
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                        WSPrice = (decimal)DataTypeParser.Parse(row["WSPrice"], typeof(decimal), 0),
                        RSPrice = (decimal)DataTypeParser.Parse(row["RSPrice"], typeof(decimal), 0),
                        Qty = (int)DataTypeParser.Parse(row["Qty"], typeof(int), 0),
                        Amount = (decimal)DataTypeParser.Parse(row["Amount"], typeof(decimal), 0),
                        Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), string.Empty)
                    });
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return details;
        }
        #endregion

        #region SalesReturn
        public void AddSalesReturn(List<PTIC.Web.API.Contract.Data.SalesReturnIn> newSalesReturns)
        {
            if (newSalesReturns == null || newSalesReturns.Count < 1)
                return;

            SaleReturnInBL salesReturnSaver = null;
            try
            {
                salesReturnSaver = new SaleReturnInBL();
                int VenID =-1;
                int affected = -1;
                foreach (PTIC.Web.API.Contract.Data.SalesReturnIn newSalesReturn in newSalesReturns)
                {
                    // Set order
                    Sale.Entities.SaleReturnIn salesReturn = new Sale.Entities.SaleReturnIn()
                    {
                        SaleDetailID = (int)DataTypeParser.Parse(newSalesReturn.SaleDetailID, typeof(int), -1),
                        ProuductID = (int)DataTypeParser.Parse(newSalesReturn.ProuductID, typeof(int), -1),
                        Date = (DateTime)DataTypeParser.Parse(newSalesReturn.Date, typeof(DateTime), DateTime.Now),
                        SalePersonID = (int)DataTypeParser.Parse(newSalesReturn.SalePersonID, typeof(int), -1),
                        Qty = (int)DataTypeParser.Parse(newSalesReturn.Qty, typeof(int), 0),
                        Remark = (string)DataTypeParser.Parse(newSalesReturn.Remark, typeof(string), string.Empty)                     
                    };

                    

                    VenID = (int)DataTypeParser.Parse(newSalesReturn.VenID, typeof(int), -1);
                    //// Save a new salesReturn into DB
                    salesReturnSaver.Insert(salesReturn,null,VenID,null);                   
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region DailyMarketingPlan
        public List<PTIC.Web.API.Contract.Data.MarketingPlan> GetDailyMarketingPlan(string startdate, string enddate)
        {
            //SqlConnection conn = null;
            DataTable tbDailyMarketingPlan = null;
            List<PTIC.Web.API.Contract.Data.MarketingPlan> dailymarketingplan = null;
            try
            {
                //conn = DBManager.GetInstance().GetDbConnection();
                tbDailyMarketingPlan = new MarketingPlanBL().GetMarketingPlanBy(Convert.ToDateTime(startdate), Convert.ToDateTime(enddate)); // Get Daily Marketing planned by (Status : 1, MarketingType : 0)
                dailymarketingplan = new List<PTIC.Web.API.Contract.Data.MarketingPlan>();
                if (tbDailyMarketingPlan == null) return dailymarketingplan;

                foreach (DataRow row in tbDailyMarketingPlan.Rows)
                {
                    dailymarketingplan.Add(new PTIC.Web.API.Contract.Data.MarketingPlan()
                    {
                        ID = (int)DataTypeParser.Parse(row["MarketingPlanID"], typeof(int), -1),
                        CustomerID = (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), -1),
                        EmpID = (int)DataTypeParser.Parse(row["EmpID"], typeof(int), -1),
                        PlanDate = (DateTime)DataTypeParser.Parse(row["PlanDate"], typeof(DateTime), DateTime.Now),
                        MarketingType = (int)DataTypeParser.Parse(row["MarketingType"], typeof(int), -1),
                        Status = (int)DataTypeParser.Parse(row["Status"], typeof(int), -1)
                    });
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return dailymarketingplan;
        }
        #endregion

        #region MobileServicePlan
        public List<PTIC.Web.API.Contract.Data.MobileServicePlan> GetMobileServicePlan(string startdate, string enddate)
        {
            //SqlConnection conn = null;
            DataTable tbMobileServicePlan = null;
            List<PTIC.Web.API.Contract.Data.MobileServicePlan> mobileserviceplan = null;
            try
            {
                //conn = DBManager.GetInstance().GetDbConnection();
                tbMobileServicePlan = new MobileServicePlanBL().GetMobileServiceLogsWithoutDetailsBy(Convert.ToDateTime(startdate), Convert.ToDateTime(enddate)); // Get Daily Marketing planned by (Status : 1, MarketingType : 0)
                mobileserviceplan = new List<PTIC.Web.API.Contract.Data.MobileServicePlan>();
                if (tbMobileServicePlan == null) return mobileserviceplan;
                foreach (DataRow row in tbMobileServicePlan.Rows)
                {
                    mobileserviceplan.Add(new PTIC.Web.API.Contract.Data.MobileServicePlan()
                    {
                        ID = (int)DataTypeParser.Parse(row["MobileServicePlanID"], typeof(int), -1),
                        CustomerID = (int)DataTypeParser.Parse(row["CustomerID"], typeof(int), -1),
                        TownshipID = (int)DataTypeParser.Parse(row["TownshipID"], typeof(int), -1),
                        CusTypeID = (int)DataTypeParser.Parse(row["CusType"], typeof(int), -1),
                        SvcPlanNo = (string)DataTypeParser.Parse(row["SvcPlanNo"], typeof(string), string.Empty),
                        SvcPlanDate = (DateTime)DataTypeParser.Parse(row["SvcPlanDate"], typeof(DateTime), DateTime.Now)
                    });
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return mobileserviceplan;
        }
        #endregion

        #region BATTERY STATUS
        public List<PTIC.Web.API.Contract.Data.BatteryStatus> GetBatteryStatus()
        {
            DataTable tbBatteryStatus = null;
            List<PTIC.Web.API.Contract.Data.BatteryStatus> batteryStatus = null;
            try
            {
                tbBatteryStatus = new ReportBL().GetServiceBatteryStatus();
                batteryStatus = new List<PTIC.Web.API.Contract.Data.BatteryStatus>();
                foreach (DataRow row in tbBatteryStatus.Rows)
                {
                    string WhereAmI = null;
                    if ((int)DataTypeParser.Parse(row["Whereami"], typeof(int), 0) == (int)PTIC.Common.Enum.SalesServiceWhereami.Vehicle)
                    {
                        WhereAmI = "Van";
                    }
                    else if ((int)DataTypeParser.Parse(row["Whereami"], typeof(int), 0) == (int)PTIC.Common.Enum.SalesServiceWhereami.Showroom)
                    {
                        WhereAmI = "Show Room";
                    }
                    else if ((int)DataTypeParser.Parse(row["Whereami"], typeof(int), 0) == (int)PTIC.Common.Enum.SalesServiceWhereami.ServiceTeamOrSubstore)
                    {
                        WhereAmI = "SSB";
                    }
                    else if ((int)DataTypeParser.Parse(row["Whereami"], typeof(int), 0) == (int)PTIC.Common.Enum.SalesServiceWhereami.MainStore)
                    {
                        WhereAmI = "Factory";
                    }
                    else
                    {
                        WhereAmI = "Customer";
                    }

                    batteryStatus.Add(new PTIC.Web.API.Contract.Data.BatteryStatus()
                    {
                        BrandName = (string)DataTypeParser.Parse(row["BrandName"], typeof(string), null),
                        ProductName = (string)DataTypeParser.Parse(row["ProductName"], typeof(string),null),
                        ReceivedDate = (DateTime)DataTypeParser.Parse(row["ReceivedDate"], typeof(DateTime), DateTime.Now),
                        Name = (string)DataTypeParser.Parse(row["Name"], typeof(string), null),
                        InShowRoom =(bool)DataTypeParser.Parse(row["InShowRoom"],typeof(bool),false),
                        InVehicle = (bool)DataTypeParser.Parse(row["InVehicle"], typeof(bool), false),
                        InServiceTeam = (bool)DataTypeParser.Parse(row["InServiceTeam"], typeof(bool), false),
                        InMainStore = (bool)DataTypeParser.Parse(row["InMainStore"], typeof(bool), false),
                        Whereami = WhereAmI
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return batteryStatus;
        }
        #endregion

        #region Vehicle
        public List<Vehicle> GetVehicles()
        {
            DataTable dt = null;
            List<PTIC.Web.API.Contract.Data.Vehicle> vehicles= null;
            try
            {
                vehicles = new List<PTIC.Web.API.Contract.Data.Vehicle>();
                VehicleBL vanBL = new VehicleBL();
                dt = vanBL.GetAll();

                foreach (DataRow row in dt.Rows)
                {
                    vehicles.Add(new PTIC.Web.API.Contract.Data.Vehicle()
                    {
                        VehicleID = (int)DataTypeParser.Parse(row["VehicleID"], typeof(int), -1),
                        VenNo = (string)DataTypeParser.Parse(row["VenNo"], typeof(string), string.Empty)
                    });
                }
                return vehicles;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetVehicles
                throw e;
            }
        }
        #endregion

        #region AP
        public List<AP_Material> GetAP_Materials()
        {
            DataTable dt = null;
            List<PTIC.Web.API.Contract.Data.AP_Material> ap_materials = null;
            try
            {
                ap_materials = new List<PTIC.Web.API.Contract.Data.AP_Material>();
                AP_MaterialBL apBL = new AP_MaterialBL();
                dt = apBL.GetAllMaterial();
                foreach (DataRow row in dt.Rows)
                {
                    ap_materials.Add(new PTIC.Web.API.Contract.Data.AP_Material()
                    {
                        AP_MaterialID = (int)DataTypeParser.Parse(row["A_P_MaterialID"], typeof(int), -1),
                        APMaterialName = (string)DataTypeParser.Parse(row["APMaterialName"], typeof(string), string.Empty),
                        APSubCategoryID = (int)DataTypeParser.Parse(row["APSubCategoryID"], typeof(int), -1),
                        Size = (string)DataTypeParser.Parse(row["Size"], typeof(string), string.Empty)                       
                    });
                }
                return ap_materials;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetBanks
                throw e;
            }
        }

        public List<AP_SubCategory> GetAP_SubCategories()
        {
            DataTable dt = null;
            List<PTIC.Web.API.Contract.Data.AP_SubCategory> ap_subcategories = null;
            try
            {
                ap_subcategories = new List<PTIC.Web.API.Contract.Data.AP_SubCategory>();
                AP_MaterialBL ap_subcatBL = new AP_MaterialBL();
                dt = ap_subcatBL.GetAllSubCategory();
                foreach (DataRow row in dt.Rows)
                {
                    ap_subcategories.Add(new PTIC.Web.API.Contract.Data.AP_SubCategory()
                    {
                        AP_SubCategoryID = (int)DataTypeParser.Parse(row["APSubCategoryID"], typeof(int), -1),
                        APSubCategoryName = (string)DataTypeParser.Parse(row["APSubCategoryName"], typeof(string), string.Empty)
                    });
                }
                return ap_subcategories;
            }
            catch (Exception e)
            {
                // TODO: Handle Exception @GetBanks
                throw e;
            }
        }
        #endregion

    }
}

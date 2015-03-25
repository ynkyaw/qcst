/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2015/03/17 (yyyy/MM/dd)
 * Description: Data manipulator/Data automation class
 */
using System;
using System.Data;
using System.Data.SqlClient;
using AGL.Util;
using PTIC.Sale.BL;
using PTIC.Sale.Entities;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.Configuration;
using System.Reflection;
using log4net;
using log4net.Config;
using System.Collections.Generic;

namespace PTIC.Tool.DataAutomation
{
    /// <summary>
    /// Data manipulation processor for PTIC database
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// Logger for DataManipulator
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(DataManager));

        #region Private Methods
        /// <summary>
        /// Set database connection string to be added into ConnectionStringSettings of application
        /// </summary>
        /// <param name="connString"></param>
        private void SetDBConnectionString(string connString)
        {
            var settings = ConfigurationManager.ConnectionStrings;
            var element = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            var collection = typeof(ConfigurationElementCollection).GetField("bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
            element.SetValue(settings, false);
            collection.SetValue(settings, false);
            settings.Add(new ConnectionStringSettings("PTIC.Properties.Settings.PTICConnectionString", connString));

            _logger.Info("Target connection string : " + connString);
        }

        /// <summary>
        /// Get Invoice entity from Invoice DataRow
        /// </summary>
        /// <param name="rowInvByCus">DataRow</param>
        /// <returns></returns>
        private Invoice GetInvoiceFrom(DataRow row)
        {
            if (row == null)
            {
                _logger.Error("Cannot get Invoice entity from Invoice DataRow!");
                throw new Exception("Cannot get Invoice entity from Invoice DataRow!");
            }
            return new Invoice()
            {
                ID = (int)DataTypeParser.Parse(row["ID"], typeof(int), -1),
                SalesDate = (DateTime)DataTypeParser.Parse(row["SalesDate"], typeof(DateTime), DateTime.Now),
                DeliveryID = (int?)DataTypeParser.Parse(row["DeliveryID"], typeof(int), null),
                CusID = (int)DataTypeParser.Parse(row["CusID"], typeof(int), -1),
                SalesPersonID = (int)DataTypeParser.Parse(row["SalesPersonID"], typeof(int), -1),
                TransportTypeID = (int)DataTypeParser.Parse(row["TransportTypeID"], typeof(int), -1),
                TransportGateID = (int?)DataTypeParser.Parse(row["TransportGateID"], typeof(int), null),
                SaleType = (int)DataTypeParser.Parse(row["SaleType"], typeof(int), (int)Common.Enum.SaleType.Credit),
                GateInvNo = (string)DataTypeParser.Parse(row["GateInvNo"], typeof(string), null),
                TransportCharges = (int)DataTypeParser.Parse(row["TransportCharges"], typeof(int), 0),
                VoucherType = (int)Common.Enum.VoucherType.Credit,
                TotalAmt = (decimal)DataTypeParser.Parse(row["TotalAmt"], typeof(decimal), 0),
                Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), null),
                InvoiceNo = (string)DataTypeParser.Parse(row["InvoiceNo"], typeof(string), null)
            };
        }

        /// <summary>
        /// Get SaleDetail entity from SaleDetail DataRow
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private SaleDetail GetSaleDetailFrom(DataRow row)
        {
            if (row == null)
            {
                _logger.Error("Cannot get SaleDetail entity from SaleDetail DataRow!");
                throw new Exception("Cannot get SaleDetail entity from SaleDetail DataRow!");
            }
            return new SaleDetail()
            {
                ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                SalePrice = (decimal)DataTypeParser.Parse(row["SalePrice"], typeof(decimal), -1),
                Qty = (int)DataTypeParser.Parse(row["Qty"], typeof(int), -1),
                Package = (int)DataTypeParser.Parse(row["Package"], typeof(int), -1),
                Amount = (decimal)DataTypeParser.Parse(row["Amount"], typeof(decimal), -1)
            };
        }

        /// <summary>
        /// Get Customer entity from Customer DataRow
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Customer GetCustomerFrom(DataRow row) 
        {
            if (row == null)
            {
                _logger.Error("Cannot get Customer entity from Customer DataRow!");
                throw new Exception("Cannot get Customer entity from Customer DataRow!");
            }
            return new Customer()
            {
                // TODO: check whether to pass null or empty in string data type
                ID = (int)DataTypeParser.Parse(row["ID"], typeof(int), -1), // not insert into db
                AddrID = (int)DataTypeParser.Parse(row["AddrID"], typeof(int), -1), // not insert into db
                CusCode = (string)DataTypeParser.Parse(row["CusCode"], typeof(string), string.Empty),
                CusName = (string)DataTypeParser.Parse(row["CusName"], typeof(string), string.Empty),
                Phone1 = (string)DataTypeParser.Parse(row["Phone1"], typeof(string), string.Empty),
                Phone2 = (string)DataTypeParser.Parse(row["Phone2"], typeof(string), string.Empty),
                Fax = (string)DataTypeParser.Parse(row["Fax"], typeof(string), string.Empty),
                Email = (string)DataTypeParser.Parse(row["Email"], typeof(string), string.Empty),
                Website = (string)DataTypeParser.Parse(row["Website"], typeof(string), string.Empty),
                BankID = (int?)DataTypeParser.Parse(row["BankID"], typeof(int), null),
                BankAccNo = (string)DataTypeParser.Parse(row["BankAccNo"], typeof(string), string.Empty),
                RouteID = (int?)DataTypeParser.Parse(row["RouteID"], typeof(int), null),
                TripID = (int?)DataTypeParser.Parse(row["TripID"], typeof(int), null),
                CusType = (int)DataTypeParser.Parse(row["CusType"], typeof(int), -1),
                CusClassID = (int)DataTypeParser.Parse(row["CusClassID"], typeof(int), -1),
                CreditAmount = (decimal)DataTypeParser.Parse(row["CreditAmount"], typeof(decimal), 0),
                CreditLimit = (int)DataTypeParser.Parse(row["CreditLimit"], typeof(int), 0),
                CusDate = (DateTime)DataTypeParser.Parse(row["CusDate"], typeof(DateTime), DateTime.Now),
                Remark = (string)DataTypeParser.Parse(row["BankAccNo"], typeof(string), null),
                // TODO: Get photos of customer
                //Photo1 = (byte[])rowCus["Photo1"],
                //Photo2 = (byte[])rowCus["Photo2"],
                //Photo3 = (byte[])rowCus["Photo3"],
                //Photo4 = (byte[])rowCus["Photo4"],
                //Photo5 = (byte[])rowCus["Photo5"],
            };
        }

        /// <summary>
        /// Get ContactPerson entity from ContactPerson DataRow
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private ContactPerson GetContactPersonFrom(DataRow row)
        {
            if (row == null)
            {
                _logger.Error("Cannot get ContactPerson entity from ContactPerson DataRow!");
                throw new Exception("Cannot get ContactPerson entity from ContactPerson DataRow!");
            }
            return new ContactPerson() 
            {
                AddrID = (int)DataTypeParser.Parse(row["AddrID"], typeof(int), -1), // not insert into db
                ContactPersonName = (string)DataTypeParser.Parse(row["ConPersonName"], typeof(string), null),
                DOB = (DateTime)DataTypeParser.Parse(row["DOB"], typeof(DateTime), null),
                Post = (string)DataTypeParser.Parse(row["Post"], typeof(string), null),
                NRC = (string)DataTypeParser.Parse(row["NRC"], typeof(string), null),
                MobilePhone = (string)DataTypeParser.Parse(row["MobilePhone"], typeof(string), null),
                HomePhone = (string)DataTypeParser.Parse(row["HomePhone"], typeof(string), null),
                Email = (string)DataTypeParser.Parse(row["Email"], typeof(string), null),
                Membership = (string)DataTypeParser.Parse(row["Membership"], typeof(string), null),
                Education = (string)DataTypeParser.Parse(row["Education"], typeof(string), null),
                SpouseName = (string)DataTypeParser.Parse(row["SpouseName"], typeof(string), null),
                Race = (string)DataTypeParser.Parse(row["Race"], typeof(string), null),
                Religion = (int)DataTypeParser.Parse(row["Religion"], typeof(int), 0),
                Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), null)
            };
        }

        /// <summary>
        /// Get Owner entity from Owner DataRow
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Owner GetOwnerFrom(DataRow row)
        { 
            if(row == null)
            {
                _logger.Error("Cannot get Owner entity from Owner DataRow!");
                throw new Exception("Cannot get Owner entity from Owner DataRow!");
            }
            return new Owner() 
            {
                AddrID = (int)DataTypeParser.Parse(row["AddrID"], typeof(int), -1), // not insert into db
                OwnerName = (string)DataTypeParser.Parse(row["OwnerName"], typeof(string), null),
                DOB = (DateTime)DataTypeParser.Parse(row["DOB"], typeof(DateTime), null),
                NRC = (string)DataTypeParser.Parse(row["NRC"], typeof(string), null),
                Fax = (string)DataTypeParser.Parse(row["Fax"], typeof(string), null),
                MobilePhone = (string)DataTypeParser.Parse(row["MobilePhone"], typeof(string), null),
                HomePhone = (string)DataTypeParser.Parse(row["HomePhone"], typeof(string), null),
                OtherBussiness = (string)DataTypeParser.Parse(row["OtherBussiness"], typeof(string), null),
                Membership = (string)DataTypeParser.Parse(row["Membership"], typeof(string), null),
                Education = (string)DataTypeParser.Parse(row["Education"], typeof(string), null),
                SpouseName = (string)DataTypeParser.Parse(row["SpouseName"], typeof(string), null),
                Race = (string)DataTypeParser.Parse(row["Race"], typeof(string), null),
                Religion = (int)DataTypeParser.Parse(row["Religion"], typeof(int), 0),
                Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), null)
            };
        }

        /// <summary>
        /// Get Address entity from Address DataRow
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Address GetAddressFrom(DataRow row)
        {
            if (row == null)
            {
                _logger.Error("Cannot get Address entity from Address DataRow!");
                throw new Exception("Cannot get Address entity from Address DataRow!");
            }
            // TODO: check whether to pass null or empty in string data type
            return new Address() 
            {
                StateDivisionID = (int?)DataTypeParser.Parse(row["StateDivisionID"], typeof(int), null),
                TownID = (int?)DataTypeParser.Parse(row["TownID"], typeof(int), null),
                TownshipID = (int?)DataTypeParser.Parse(row["TownshipID"], typeof(int), null),
                Hno = (string)DataTypeParser.Parse(row["Hno"], typeof(string), string.Empty),
                Street = (string)DataTypeParser.Parse(row["Street"], typeof(string), string.Empty),
                Quartar = (string)DataTypeParser.Parse(row["Quartar"], typeof(string), string.Empty),
                Country = (string)DataTypeParser.Parse(row["Country"], typeof(string), string.Empty),
            };
        }

        /// <summary>
        /// Copy data of Customer including respective Address, ContactPerson, Owner,
        /// Invoice and SalesDetail to specific target database.
        /// </summary>
        /// <param name="dtCustomer"></param>
        /// <param name="dtAddressOfCustomer"></param>
        /// <param name="dtContactPerson"></param>
        /// <param name="dtAddressOfContactPerson"></param>
        /// <param name="dtOwner"></param>
        /// <param name="dtAddressOfOwner"></param>
        /// <param name="dtCreditInvoice"></param>
        /// <param name="dtSalesDetail"></param>
        /// <param name="targetConnString"></param>
        /// <param name="targetConnString">Target database (PTIC) connection string.</param>
        private void Copy(
                DataTable dtCustomer,
                DataTable dtAddressOfCustomer,
                DataTable dtContactPerson,
                DataTable dtAddressOfContactPerson,
                DataTable dtOwner,
                DataTable dtAddressOfOwner,
                DataTable dtCreditInvoice,
                DataTable dtSalesDetail,
                string targetConnString
            )
        {
            CustomerBL cusSaver = null;
            InvoiceBL invoiceSaver = null;
            try
            {
                // Validation
                if(dtCustomer == null || dtCustomer.Rows.Count < 1)
                {
                    _logger.Info("No source customers!");
                    throw new Exception("No need to copy because there is no customer in source!");
                }
                if (dtAddressOfCustomer == null || dtAddressOfCustomer.Rows.Count < 1)
                {
                    _logger.Error("No source address of customer!");
                    throw new Exception("No source address of customer!");
                }

                if (dtContactPerson == null || dtContactPerson.Rows.Count < 1)
                    _logger.Warn("No contact person in source!");
                if (dtAddressOfContactPerson == null || dtAddressOfContactPerson.Rows.Count < 1)
                    _logger.Warn("No address of contact person!");
                if (dtOwner == null || dtOwner.Rows.Count < 1)
                    _logger.Warn("No owner in source");
                if (dtAddressOfOwner == null || dtAddressOfOwner.Rows.Count < 1)
                    _logger.Warn("No address of owner!");
                if (dtCreditInvoice == null || dtCreditInvoice.Rows.Count < 1)
                    _logger.Info("No invoice (credit).");

                // Set target database connection
                SetDBConnectionString(targetConnString);
                // Instiantiate service object
                cusSaver = new CustomerBL();
                invoiceSaver = new InvoiceBL();

                // Loop source Customer
                DateTime now = DateTime.Now;
                foreach (DataRow rowCus in dtCustomer.Rows)
                {
                    ContactPerson contactPerson = new ContactPerson() // Create object whether respective data exists or not, to insert into db table
                    {
                        ContactPersonName = string.Empty, // default
                        DOB = now // default
                    };
                    Owner owner = new Owner() // Create object whether respective data exists or not, to insert into db table
                    {
                        OwnerName = string.Empty, // default
                        DOB = now // default
                    };
                    Address addressOfContactPerson = new Address(); // Create object whether respective data exists or not, to insert into db table
                    Address addressOfOwner = new Address(); // Create object whether respective data exists or not, to insert into db table
                    // Get Customer
                    Customer customer = GetCustomerFrom(rowCus);
                    // Get Address of Customer
                    DataRow rowAddressOfCus = DataUtil.GetDataRowBy(dtAddressOfCustomer, "ID", customer.AddrID);
                    if (rowAddressOfCus == null)
                    {
                        _logger.Error("Lack of address of customer!");
                        throw new Exception("Invalid data: lack of Address of Customer!");
                    }                    
                    Address addressOfCus = GetAddressFrom(rowAddressOfCus);
                    // Contact person
                    DataRow rowContactPerson = DataUtil.GetDataRowBy(dtContactPerson, "CusID", customer.ID);
                    if (rowContactPerson != null)
                    {
                        // Get ContactPerson
                        contactPerson = GetContactPersonFrom(rowContactPerson);                        
                        // Get Address of ContactPerson
                        DataRow rowAddressOfContactPerson = DataUtil.GetDataRowBy(dtAddressOfContactPerson, "ID", contactPerson.AddrID);
                        if (rowAddressOfContactPerson != null)
                        {
                            addressOfContactPerson = GetAddressFrom(rowAddressOfContactPerson);
                            if (addressOfContactPerson == null)
                            {
                                _logger.Error("Lack of address of contact person!");
                                throw new Exception("Invalid data: lack of Address of ContactPerson!");
                            }
                        }
                    }// END of if (rowContactPerson != null)
                    // Owner
                    DataRow rowOwner = DataUtil.GetDataRowBy(dtOwner, "CusID", customer.ID);
                    if (rowOwner != null)
                    {
                        // Get Owner
                        owner = GetOwnerFrom(rowOwner);                        
                        // Get Address of Owner
                        DataRow rowAddressOfOwner = DataUtil.GetDataRowBy(dtAddressOfOwner, "ID", owner.AddrID);
                        if (rowAddressOfOwner != null)
                        {
                            addressOfOwner = GetAddressFrom(rowAddressOfOwner);
                            if (addressOfOwner == null)
                            {
                                _logger.Error("Lack of address of owner!");
                                throw new Exception("Invalid data: lack of Address of Owner!");
                            }
                        }
                    }// END of if (rowOwner != null)
                    // Insert Customer, ContactPerson, Owner and their Address
                    int? insertedCustomerID = cusSaver.Add(
                                                            customer, addressOfCus,
                                                            contactPerson, addressOfContactPerson,
                                                            owner, addressOfOwner);                    
                    if (!cusSaver.ValidationResults.IsValid) // validation fail
                    {
                        ValidationResult err = DataUtil.GetFirst(cusSaver.ValidationResults) as ValidationResult;
                        _logger.Error(err);
                        throw new Exception(err.Message);
                    }
                    else if(!insertedCustomerID.HasValue || insertedCustomerID.Value < 1)
                    {
                        _logger.Error("Cannot copy : Null customer ID returned!");
                        throw new Exception("Cannot copy customer!");
                    }
                    // Log inserted customer
                    _logger.Info(
                            string.Format(
                                "Inserted customer ID = {0}, Source customer ID = {1}\nCustomer = {2}\nAddress = {3}\nContact Person = {4}\nAddress = {5}\nOwner = {6}\nAddress = {7}",
                                insertedCustomerID.Value, customer.ID, customer, dtAddressOfCustomer, contactPerson, addressOfContactPerson, owner, addressOfOwner)
                        );
                    // *** Invoice (credit) ***
                    // Get credit invoice(s) by a current customer
                    DataTable dtInvoiceByCustomer = DataUtil.GetDataTableBy(dtCreditInvoice, "CusID", customer.ID);
                    if(dtInvoiceByCustomer != null && dtInvoiceByCustomer.Rows.Count > 0)
                    {
                        // Loop selected invoice by customer
                        foreach (DataRow rowInvByCus in dtInvoiceByCustomer.Rows)
                        {
                            // Get Invoice
                            Invoice newInvoice = GetInvoiceFrom(rowInvByCus);
                            if (newInvoice == null)
                                continue;
                            // SalesDetail in a credit invoice
                            if (dtSalesDetail == null || dtSalesDetail.Rows.Count < 1)
                                continue;
                            List<SaleDetail> newSaleDetails = new List<SaleDetail>();
                            DataTable dtSalesDetailByCustomer = DataUtil.GetDataTableBy(dtSalesDetail, "InvoiceID", newInvoice.ID);
                            foreach (DataRow rowSaleDetail in dtSalesDetailByCustomer.Rows)
                            {
                                // Get SalesDetail
                                SaleDetail salesDetail = GetSaleDetailFrom(rowSaleDetail);
                                if (salesDetail != null)
                                    newSaleDetails.Add(salesDetail); // Add into list
                            }
                            // Insert Invoice and SalesDetails
                            int? insertedInvoiceID = invoiceSaver.Add(newInvoice, newSaleDetails, 0, 0); // Pass vehicle and warehouse ID Zero to bypass stock control
                            if (!invoiceSaver.ValidationResults.IsValid)
                            {
                                ValidationResult err = DataUtil.GetFirst(invoiceSaver.ValidationResults) as ValidationResult;
                                _logger.Error(err);
                                throw new Exception(err.Message);
                            }
                            // Log inserted invoice
                            _logger.Info(
                                    string.Format("Inserted invoice ID = {0}\n{1}", insertedCustomerID.Value, newInvoice)
                                );
                            // TODO: log inserted SalesDetail
                        }// END of foreach (DataRow rowInvByCus in dtInvoiceByCustomer.Rows)
                    }// END of if(dtInvoiceByCustomer != null && dtInvoiceByCustomer.Rows.Count > 0)
                }// END of foreach(DataRow rowCus in dtCustomer.Rows)
                _logger.Info("COPIED SUCCESSFULLY.");
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw new Exception("Caught exception while copying source to target database!");
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Copy data of Customer including respective Address, ContactPerson, Owner,
        /// Invoice and SalesDetail from specific source database to specific target database.
        /// </summary>
        /// <param name="srcConnString">Source database (PTIC) connection string.</param>
        /// <param name="targetConnString">Target database (PTIC) connection string.</param>
        /// <param name="customerID">Start customer ID (Starting from this ID)</param>
        public void Copy(
            string srcConnString, string targetConnString,
            int customerID
            )
        {
            SqlConnection srcConn = null;
            SqlCommand cmd = null;
            DataTable dtCustomer = null;
            DataTable dtAddressOfCustomer = null;
            DataTable dtContactPerson = null;
            DataTable dtAddressOfContactPerson = null;
            DataTable dtOwner = null;
            DataTable dtAddressOfOwner = null;
            try
            {
                if (string.IsNullOrEmpty(srcConnString) || srcConnString.Length < 1 ||
                    string.IsNullOrEmpty(targetConnString) || targetConnString.Length < 1)
                {
                    _logger.Error("Lack of input : connection string!");
                    throw new Exception("Please specify source and target connection string!");
                }
                dtCustomer = new DataTable("Customer");
                dtAddressOfCustomer = new DataTable("AddressOfCustomer");
                dtContactPerson = new DataTable("ContactPerson");
                dtAddressOfContactPerson = new DataTable("AddressOfContactPerson");
                dtOwner = new DataTable("Owner");
                dtAddressOfOwner = new DataTable("AddressOfOwner");
                srcConn = new SqlConnection(srcConnString);
                srcConn.Open();
                //transaction = src.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = srcConn;

                /*** Customer ***/
                // Get Customer begun by specific customer id
                cmd.CommandText = "SELECT * FROM Customer WHERE IsDeleted = 0 AND ID >= @cusID";
                cmd.Parameters.AddWithValue("@cusID", customerID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtCustomer);
                cmd.Parameters.Clear();
                // Get ContactPerson by source Customer
                cmd.CommandText = "SELECT * FROM ContactPerson"
                                                    + " WHERE CusID IN (SELECT ID FROM Customer WHERE IsDeleted = 0 AND ID >= @cusID)";
                cmd.Parameters.AddWithValue("@cusID", customerID);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtContactPerson);
                cmd.Parameters.Clear();
                // Get Owner by source Customer
                cmd.CommandText = "SELECT * FROM Owner"
                                                + " WHERE CusID IN (SELECT ID FROM Customer WHERE IsDeleted = 0 AND ID >= @cusID)";
                cmd.Parameters.AddWithValue("@cusID", customerID);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtOwner);
                cmd.Parameters.Clear();
                // Get Address of Customer
                cmd.CommandText = "SELECT * FROM Address"
                                                    + " WHERE ID IN (SELECT AddrID FROM Customer WHERE IsDeleted = 0 AND ID >= @cusID)";
                cmd.Parameters.AddWithValue("@cusID", customerID);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtAddressOfCustomer);
                cmd.Parameters.Clear();
                // Get Address of ContactPerson 
                cmd.CommandText = "SELECT * FROM Address"
                                                    + " WHERE ID IN (SELECT AddrID FROM ContactPerson WHERE IsDeleted = 0 AND CusID >= @cusID)";
                cmd.Parameters.AddWithValue("@cusID", customerID);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtAddressOfContactPerson);
                cmd.Parameters.Clear();
                // Get Address of Owner
                cmd.CommandText = "SELECT * FROM Address"
                                                    + " WHERE ID IN (SELECT AddrID FROM Owner WHERE IsDeleted = 0 AND CusID >= @cusID)";
                cmd.Parameters.AddWithValue("@cusID", customerID);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtAddressOfOwner);
                cmd.Parameters.Clear();

                // *** Invoice (credit) ***
                InvoiceBL creditInvoiceSaver = new InvoiceBL();
                // Get invoice by customers
                DataTable dtCreditInvoice = new DataTable();
                cmd.CommandText = "SELECT * FROM Invoice"
                                                + " WHERE VoucherType = 0 AND IsDeleted = 0"
                                                    + " AND CusID IN (SELECT ID FROM Customer WHERE IsDeleted = 0 AND ID >= @cusID)";
                cmd.Parameters.AddWithValue("@cusID", customerID);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtCreditInvoice);
                cmd.Parameters.Clear();
                // Get SalesDetail by customers
                DataTable dtSalesDetail = new DataTable();
                cmd.CommandText = "SELECT * FROM SalesDetail AS detail"
                                                + " INNER JOIN Invoice AS inv ON inv.ID = detail.InvoiceID"
                                                + " WHERE detail.IsDeleted = 0 AND inv.IsDeleted = 0 AND VoucherType = 0"
                                                + " AND inv.CusID IN (SELECT ID FROM Customer WHERE IsDeleted = 0 AND ID >= @cusID)";
                cmd.Parameters.AddWithValue("@cusID", customerID);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dtSalesDetail);
                cmd.Parameters.Clear();

                // Copy source datatable to target database
                Copy(
                    dtCustomer, dtAddressOfCustomer, 
                    dtContactPerson, dtAddressOfContactPerson, 
                    dtOwner, dtAddressOfOwner, 
                    dtCreditInvoice, dtSalesDetail,
                    targetConnString);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
            }
            finally 
            {
                if (srcConn != null && srcConn.State == ConnectionState.Open)
                    srcConn.Close();
            }
        }
        
        #endregion

        #region Constructors
        public DataManager()
        {
            // Configure logger
            XmlConfigurator.Configure();
        }
        #endregion
    }
}

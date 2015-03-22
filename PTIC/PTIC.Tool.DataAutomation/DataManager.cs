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
        /// Copy data of Customer including respective Address, ContactPerson, Owner,
        /// Invoice and SalesDetail to specific target database.
        /// </summary>
        /// <param name="dtCustomer"></param>
        /// <param name="dtAddressOfCustomer"></param>
        /// <param name="dtContactPerson"></param>
        /// <param name="dtAddressOfContactPerson"></param>
        /// <param name="dtOwner"></param>
        /// <param name="dtAddressOfOwner"></param>
        /// <param name="targetConnString">Target database (PTIC) connection string.</param>
        private void Copy(
                DataTable dtCustomer,
                DataTable dtAddressOfCustomer,
                DataTable dtContactPerson,
                DataTable dtAddressOfContactPerson,
                DataTable dtOwner,
                DataTable dtAddressOfOwner,
                string targetConnString
            )
        {
            CustomerBL cusSaver = null;
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

                // Set target database connection
                SetDBConnectionString(targetConnString);

                // Loop source Customer
                cusSaver = new CustomerBL();
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

                    Customer customer = new Customer()
                    {
                        // TODO: check whether to pass null or empty in string data type
                        ID = (int)DataTypeParser.Parse(rowCus["ID"], typeof(int), -1), // not insert into db
                        AddrID = (int)DataTypeParser.Parse(rowCus["AddrID"], typeof(int), -1), // not insert into db
                        CusCode = (string)DataTypeParser.Parse(rowCus["CusCode"], typeof(string), string.Empty),
                        CusName = (string)DataTypeParser.Parse(rowCus["CusName"], typeof(string), string.Empty),
                        Phone1 = (string)DataTypeParser.Parse(rowCus["Phone1"], typeof(string), string.Empty),
                        Phone2 = (string)DataTypeParser.Parse(rowCus["Phone2"], typeof(string), string.Empty),
                        Fax = (string)DataTypeParser.Parse(rowCus["Fax"], typeof(string), string.Empty),
                        Email = (string)DataTypeParser.Parse(rowCus["Email"], typeof(string), string.Empty),
                        Website = (string)DataTypeParser.Parse(rowCus["Website"], typeof(string), string.Empty),
                        BankID = (int?)DataTypeParser.Parse(rowCus["BankID"], typeof(int), null),
                        BankAccNo = (string)DataTypeParser.Parse(rowCus["BankAccNo"], typeof(string), string.Empty),
                        RouteID = (int?)DataTypeParser.Parse(rowCus["RouteID"], typeof(int), null),
                        TripID = (int?)DataTypeParser.Parse(rowCus["TripID"], typeof(int), null),
                        CusType = (int)DataTypeParser.Parse(rowCus["CusType"], typeof(int), -1),
                        CusClassID = (int)DataTypeParser.Parse(rowCus["CusClassID"], typeof(int), -1),
                        CreditAmount = (decimal)DataTypeParser.Parse(rowCus["CreditAmount"], typeof(decimal), 0),
                        CreditLimit = (int)DataTypeParser.Parse(rowCus["CreditLimit"], typeof(int), 0),
                        CusDate = (DateTime)DataTypeParser.Parse(rowCus["CusDate"], typeof(DateTime), DateTime.Now),
                        Remark = (string)DataTypeParser.Parse(rowCus["BankAccNo"], typeof(string), null),
                        //Photo1 = (byte[])rowCus["Photo1"],
                        //Photo2 = (byte[])rowCus["Photo2"],
                        //Photo3 = (byte[])rowCus["Photo3"],
                        //Photo4 = (byte[])rowCus["Photo4"],
                        //Photo5 = (byte[])rowCus["Photo5"],
                    };
                    // Address of Customer
                    DataRow rowAddressOfCus = DataUtil.GetDataRowBy(dtAddressOfCustomer, "ID", customer.AddrID);
                    if (rowAddressOfCus == null)
                    {
                        _logger.Error("Lack of address of customer!");
                        throw new Exception("Invalid data: lack of Address of Customer!");
                    }
                    Address addressOfCus = new Address()
                    {
                        // TODO: check whether to pass null or empty in string data type
                        StateDivisionID = (int?)DataTypeParser.Parse(rowAddressOfCus["StateDivisionID"], typeof(int), null),
                        TownID = (int?)DataTypeParser.Parse(rowAddressOfCus["TownID"], typeof(int), null),
                        TownshipID = (int?)DataTypeParser.Parse(rowAddressOfCus["TownshipID"], typeof(int), null),
                        Hno = (string)DataTypeParser.Parse(rowAddressOfCus["Hno"], typeof(string), string.Empty),
                        Street = (string)DataTypeParser.Parse(rowAddressOfCus["Street"], typeof(string), string.Empty),
                        Quartar = (string)DataTypeParser.Parse(rowAddressOfCus["Quartar"], typeof(string), string.Empty),
                        Country = (string)DataTypeParser.Parse(rowAddressOfCus["Country"], typeof(string), string.Empty),
                    };
                    // Contact person
                    DataRow rowContactPerson = DataUtil.GetDataRowBy(dtContactPerson, "CusID", customer.ID);
                    if (rowContactPerson != null)
                    {
                        contactPerson.AddrID = (int)DataTypeParser.Parse(rowContactPerson["AddrID"], typeof(int), -1); // not insert into db
                        contactPerson.ContactPersonName = (string)DataTypeParser.Parse(rowContactPerson["ConPersonName"], typeof(string), null);
                        contactPerson.DOB = (DateTime)DataTypeParser.Parse(rowContactPerson["DOB"], typeof(DateTime), null);
                        contactPerson.Post = (string)DataTypeParser.Parse(rowContactPerson["Post"], typeof(string), null);
                        contactPerson.NRC = (string)DataTypeParser.Parse(rowContactPerson["NRC"], typeof(string), null);
                        contactPerson.MobilePhone = (string)DataTypeParser.Parse(rowContactPerson["MobilePhone"], typeof(string), null);
                        contactPerson.HomePhone = (string)DataTypeParser.Parse(rowContactPerson["HomePhone"], typeof(string), null);
                        contactPerson.Email = (string)DataTypeParser.Parse(rowContactPerson["Email"], typeof(string), null);
                        contactPerson.Membership = (string)DataTypeParser.Parse(rowContactPerson["Membership"], typeof(string), null);
                        contactPerson.Education = (string)DataTypeParser.Parse(rowContactPerson["Education"], typeof(string), null);
                        contactPerson.SpouseName = (string)DataTypeParser.Parse(rowContactPerson["SpouseName"], typeof(string), null);
                        contactPerson.Race = (string)DataTypeParser.Parse(rowContactPerson["Race"], typeof(string), null);
                        contactPerson.Religion = (int)DataTypeParser.Parse(rowContactPerson["Religion"], typeof(int), 0);
                        contactPerson.Remark = (string)DataTypeParser.Parse(rowContactPerson["Remark"], typeof(string), null);
                        // Address of ContactPerson
                        DataRow rowAddressOfContactPerson = DataUtil.GetDataRowBy(dtAddressOfContactPerson, "ID", contactPerson.AddrID);
                        if (rowAddressOfContactPerson != null)
                        {
                            addressOfContactPerson.StateDivisionID = (int?)DataTypeParser.Parse(rowAddressOfContactPerson["StateDivisionID"], typeof(int), null);
                            addressOfContactPerson.TownID = (int?)DataTypeParser.Parse(rowAddressOfContactPerson["TownID"], typeof(int), null);
                            addressOfContactPerson.TownshipID = (int?)DataTypeParser.Parse(rowAddressOfContactPerson["TownshipID"], typeof(int), null);
                            addressOfContactPerson.Hno = (string)DataTypeParser.Parse(rowAddressOfContactPerson["Hno"], typeof(string), string.Empty);
                            addressOfContactPerson.Street = (string)DataTypeParser.Parse(rowAddressOfContactPerson["Street"], typeof(string), string.Empty);
                            addressOfContactPerson.Quartar = (string)DataTypeParser.Parse(rowAddressOfContactPerson["Quartar"], typeof(string), string.Empty);
                            addressOfContactPerson.Country = (string)DataTypeParser.Parse(rowAddressOfContactPerson["Country"], typeof(string), string.Empty);
                        }
                    }// END of if (rowContactPerson != null)
                    // Owner
                    DataRow rowOwner = DataUtil.GetDataRowBy(dtOwner, "CusID", customer.ID);
                    if (rowOwner != null)
                    {
                        owner.AddrID = (int)DataTypeParser.Parse(rowOwner["AddrID"], typeof(int), -1); // not insert into db
                        owner.OwnerName = (string)DataTypeParser.Parse(rowOwner["OwnerName"], typeof(string), null);
                        owner.DOB = (DateTime)DataTypeParser.Parse(rowOwner["DOB"], typeof(DateTime), null);
                        owner.NRC = (string)DataTypeParser.Parse(rowOwner["NRC"], typeof(string), null);
                        owner.Fax = (string)DataTypeParser.Parse(rowOwner["Fax"], typeof(string), null);
                        owner.MobilePhone = (string)DataTypeParser.Parse(rowOwner["MobilePhone"], typeof(string), null);
                        owner.HomePhone = (string)DataTypeParser.Parse(rowOwner["HomePhone"], typeof(string), null);
                        owner.OtherBussiness = (string)DataTypeParser.Parse(rowOwner["OtherBussiness"], typeof(string), null);
                        owner.Membership = (string)DataTypeParser.Parse(rowOwner["Membership"], typeof(string), null);
                        owner.Education = (string)DataTypeParser.Parse(rowOwner["Education"], typeof(string), null);
                        owner.SpouseName = (string)DataTypeParser.Parse(rowOwner["SpouseName"], typeof(string), null);
                        owner.Race = (string)DataTypeParser.Parse(rowOwner["Race"], typeof(string), null);
                        owner.Religion = (int)DataTypeParser.Parse(rowContactPerson["Religion"], typeof(int), 0);
                        owner.Remark = (string)DataTypeParser.Parse(rowContactPerson["Remark"], typeof(string), null);
                        // Address of Owner
                        DataRow rowAddressOfOwner = DataUtil.GetDataRowBy(dtAddressOfOwner, "ID", owner.AddrID);
                        if (rowAddressOfOwner != null)
                        {
                            addressOfOwner.StateDivisionID = (int?)DataTypeParser.Parse(rowAddressOfOwner["StateDivisionID"], typeof(int), null);
                            addressOfOwner.TownID = (int?)DataTypeParser.Parse(rowAddressOfOwner["TownID"], typeof(int), null);
                            addressOfOwner.TownshipID = (int?)DataTypeParser.Parse(rowAddressOfOwner["TownshipID"], typeof(int), null);
                            addressOfOwner.Hno = (string)DataTypeParser.Parse(rowAddressOfOwner["Hno"], typeof(string), string.Empty);
                            addressOfOwner.Street = (string)DataTypeParser.Parse(rowAddressOfOwner["Street"], typeof(string), string.Empty);
                            addressOfOwner.Quartar = (string)DataTypeParser.Parse(rowAddressOfOwner["Quartar"], typeof(string), string.Empty);
                            addressOfOwner.Country = (string)DataTypeParser.Parse(rowAddressOfOwner["Country"], typeof(string), string.Empty);
                        }
                    }// END of if (rowOwner != null)

                    // Insert into db
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
                                "Inserted customer ID = {0}\nCustomer = {1}\nAddress = {2}\nContact Person = {3}\nAddress\nOwner = {4}\nAddress = {5}", 
                                insertedCustomerID.Value, customer, dtAddressOfCustomer, contactPerson, addressOfContactPerson, owner, addressOfOwner)
                        );

                    // TODO: Invoice (credit)

                }// END of foreach(DataRow rowCus in dtCustomer.Rows)
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

                // Copy source datatable to taget database
                Copy(
                    dtCustomer, dtAddressOfCustomer, 
                    dtContactPerson, dtAddressOfContactPerson, 
                    dtOwner, dtAddressOfOwner, 
                    targetConnString);

                // TODO: Invoice (credit)
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

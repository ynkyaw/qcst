using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PTIC.VC;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using System.Text.RegularExpressions;
using log4net;
using log4net.Config;
using PTIC.Sale.BL;
using PTIC.Util;
using PTIC.VC.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Sale.Setup
{
    public partial class frmCustomerInformation : Form
    {

        /// <summary>
        /// Logger for frmCustomerInformation
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmCustomerInformation));

        /// <summary>
        /// 
        /// </summary>
        Dictionary<string, string> imageStore = new Dictionary<string, string>();

        /// <summary>
        /// Years indicating customer must be at least 16 years old
        /// </summary>
        private readonly int MaxBirthYears = -16;

        Customer customer = new Customer();
        Address address = new Address();
        Address owneraddress = new Address();
        Address contactpersonaddress = new Address();
        ContactPerson contactperson = new ContactPerson();
        Owner owner = new Owner();
        DataTable bankTbl = null;
        DataTable townTbl = null;
        DataTable townshipTbl = null;
        DataTable statedibisionTbl = null;
        DataTable routeTbl = null;
        DataTable tripTbl = null;
        DataTable cusclassTbl = null;
        DataTable custypeTbl = null;

        public frmCustomerInformation()
        {
            InitializeComponent();
            // Set foucus on Customer Name
            txtCustomerName.Select();
            txtCustomerName.Focus();

            // Configure logger
            XmlConfigurator.Configure();

            dtpCustomer.MaxDate = DateTime.Now;
            LoadNBindCustomerTownLink();
            LoadNBindContactTownLink();
            LoadNBindOwnerTownLink();
            LoadData();
            BindCombos();

            // Set image list view renderer
            //SetImageRenderer();                        
            //imgList.ImageSize = new Size(150, 200);
        }

        public frmCustomerInformation(Customer customer, Address address)
        {
            InitializeComponent();
            // Set foucus on Customer Name
            txtCustomerName.Select();
            txtCustomerName.Focus();
            // Configure logger
            XmlConfigurator.Configure();

            this.customer = customer;
            this.address = address;

            txtHno.Text = string.IsNullOrEmpty(this.address.Hno) ? "" : this.address.Hno;
            txtStreet.Text = string.IsNullOrEmpty(this.address.Street) ?  "" : this.address.Street;
            txtQuarter.Text = string.IsNullOrEmpty(this.address.Quartar) ? "" : this.address.Quartar;
            txtCountry.Text = string.IsNullOrEmpty(this.address.Country) ? "" : this.address.Country;

            LoadNBindCustomerTownLink();
            LoadNBindContactTownLink();
            LoadNBindOwnerTownLink();
            LoadData();
            BindCombos();
            txtCustomerName.Focus();
            // Set image list view renderer
            //SetImageRenderer();
        }

        #region Private Method
        private void LoadNBindCustomerTownLink()
        {
            DataSet ds = new DataSet();

            BindingSource bdSDivision = new BindingSource();
            BindingSource bdTown = new BindingSource();
            BindingSource bdTownship = new BindingSource();
            
            try
            {                
                statedibisionTbl = new SDivisionBL().GetAll().Copy();
                townTbl = new TownBL().GetAll().Copy();
                townshipTbl = new TownshipBL().GetAll().Copy();

                // add three datatables into a single dataset
                ds.Tables.Add(statedibisionTbl);
                ds.Tables.Add(townTbl);
                ds.Tables.Add(townshipTbl);

                // create data relations among three tables
                DataRelation relSDivision_Town = new DataRelation("SDivsion_Town",
                       statedibisionTbl.Columns["SDivisionID"], townTbl.Columns["StateDivisionID"]);
                DataRelation relTown_Township = new DataRelation("Town_Township",
                       townTbl.Columns["TownID"], townshipTbl.Columns["TownID"]);
                ds.Relations.Add(relSDivision_Town);
                ds.Relations.Add(relTown_Township);

                bdSDivision.DataSource = ds;
                bdSDivision.DataMember = statedibisionTbl.TableName;

                bdTown.DataSource = bdSDivision;
                bdTown.DataMember = "SDivsion_Town";

                bdTownship.DataSource = bdTown;
                bdTownship.DataMember = "Town_Township";
                
                cmbStateDivision.DataSource = bdSDivision;
                cmbTown.DataSource = bdTown;
                cmbTownship.DataSource = bdTownship;
                if (address.StateDivisionID == null && address.TownID == null && address.TownshipID == null)
                {
                    // What's up? Ask AKK
                }
                else
                {
                    cmbStateDivision.SelectedValue = this.address.StateDivisionID;
                    cmbTown.SelectedValue = this.address.TownID;

                    if (this.address.TownshipID == null)
                    {
                        cmbTownship.SelectedValue = -1;
                        // cmbOwnerTownship.SelectedValue = -1;
                        cmbTrip.Enabled = true;
                        cmbRoute.Enabled = false;
                    }
                    else
                    {
                        cmbTownship.SelectedValue = this.address.TownshipID;
                        cmbTrip.Enabled = false;
                        cmbRoute.Enabled = true;
                    }
                }

                if (customer.Photo1 != null)
                {
                    Image img = PTIC.Util.ImageConverter.ToImage(customer.Photo1);
                    //img.Tag = "Photo1"; // It does not work here and not reliable
                    imgList.Images.Add("Photo1", img); // Key, Value                    
                    // TODO: Value must be changed as Title
                    imageStore.Add("Photo1", "Photo1"); // Key, Value
                }
                if (customer.Photo2 != null)
                {
                    Image img = PTIC.Util.ImageConverter.ToImage(customer.Photo2);
                    imgList.Images.Add("Photo2", img); // Key, Value
                    imageStore.Add("Photo2", "Photo2"); // Key, Value
                }
                if (customer.Photo3 != null)
                {
                    Image img = PTIC.Util.ImageConverter.ToImage(customer.Photo3);
                    imgList.Images.Add("Photo3", img); // Key, Value
                    imageStore.Add("Photo3", "Photo3"); // Key, Value
                }
                if (customer.Photo4 != null)
                {
                    Image img = PTIC.Util.ImageConverter.ToImage(customer.Photo4);
                    imgList.Images.Add("Photo4", img); // Key, Value
                    imageStore.Add("Photo4", "Photo4"); // Key, Value
                }
                if (customer.Photo5 != null)
                {
                    Image img = PTIC.Util.ImageConverter.ToImage(customer.Photo5);
                    imgList.Images.Add("Photo5", img); // Key, Value
                    imageStore.Add("Photo5", "Photo5"); // Key, Value
                }
                SetImageKey();
                ImageCouting();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
            }
        }

        private void ImageCouting()
        {
            lblImageCount.Text = imgList.Images.Count + " of 5";
        }

        private void LoadNBindOwnerTownLink()
        {
            // contactTbl = new ContactPersonBL().GetAll(customer.ID, conn);          

            DataSet ds = new DataSet();

            BindingSource bdSDivision = new BindingSource();
            BindingSource bdTown = new BindingSource();
            BindingSource bdTownship = new BindingSource();
            
            try
            {
                DataTable ownerTbl = new OwnerBL().GetAll(customer.ID);
                statedibisionTbl = new SDivisionBL().GetAll().Copy();
                townTbl = new TownBL().GetAll().Copy();
                townshipTbl = new TownshipBL().GetAll().Copy();

                // add three datatables into a single dataset
                ds.Tables.Add(statedibisionTbl);
                ds.Tables.Add(townTbl);
                ds.Tables.Add(townshipTbl);

                // create data relations among three tables
                DataRelation relSDivision_Town = new DataRelation("SDivsion_Town",
                       statedibisionTbl.Columns["SDivisionID"], townTbl.Columns["StateDivisionID"]);
                DataRelation relTown_Township = new DataRelation("Town_Township",
                       townTbl.Columns["TownID"], townshipTbl.Columns["TownID"]);
                ds.Relations.Add(relSDivision_Town);
                ds.Relations.Add(relTown_Township);

                bdSDivision.DataSource = ds;
                bdSDivision.DataMember = statedibisionTbl.TableName;

                bdTown.DataSource = bdSDivision;
                bdTown.DataMember = "SDivsion_Town";

                bdTownship.DataSource = bdTown;
                bdTownship.DataMember = "Town_Township";

                cmbOwnerStateDivision.DataSource = bdSDivision;
                cmbOwnerTown.DataSource = bdTown;
                cmbOwnerTownship.DataSource = bdTownship;

                if (ownerTbl.Rows.Count > 0)
                {
                    int TownID = (int)DataTypeParser.Parse(ownerTbl.Rows[0]["TownID"].ToString(), typeof(int), -1);
                    int? TownshipID = (int?)DataTypeParser.Parse(ownerTbl.Rows[0]["TownshipID"].ToString(), typeof(int), null);
                    int StateDivisionID = (int)DataTypeParser.Parse(ownerTbl.Rows[0]["StateDivisionID"].ToString(), typeof(int), -1);

                    cmbOwnerStateDivision.SelectedValue = StateDivisionID;

                    if (TownshipID == null)
                    {
                        cmbOwnerTownship.SelectedValue = -1;
                        cmbTrip.Enabled = true;
                        cmbRoute.Enabled = false;
                    }
                    else
                    {
                        cmbOwnerTownship.SelectedValue = TownshipID;
                        cmbTrip.Enabled = false;
                        cmbRoute.Enabled = true;
                    }
                    cmbOwnerTown.SelectedValue = TownID;
                }

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
            }
        }

        private void LoadNBindContactTownLink()
        {
            DataSet ds = new DataSet();

            BindingSource bdSDivision = new BindingSource();
            BindingSource bdTown = new BindingSource();
            BindingSource bdTownship = new BindingSource();
            
            try
            {                
                DataTable contactTbl = new ContactPersonBL().GetAll(customer.ID);
                statedibisionTbl = new SDivisionBL().GetAll().Copy();
                townTbl = new TownBL().GetAll().Copy();
                townshipTbl = new TownshipBL().GetAll().Copy();

                // add three datatables into a single dataset
                ds.Tables.Add(statedibisionTbl);
                ds.Tables.Add(townTbl);
                ds.Tables.Add(townshipTbl);

                // create data relations among three tables
                DataRelation relSDivision_Town = new DataRelation("SDivsion_Town",
                       statedibisionTbl.Columns["SDivisionID"], townTbl.Columns["StateDivisionID"]);
                DataRelation relTown_Township = new DataRelation("Town_Township",
                       townTbl.Columns["TownID"], townshipTbl.Columns["TownID"]);
                ds.Relations.Add(relSDivision_Town);
                ds.Relations.Add(relTown_Township);

                bdSDivision.DataSource = ds;
                bdSDivision.DataMember = statedibisionTbl.TableName;

                bdTown.DataSource = bdSDivision;
                bdTown.DataMember = "SDivsion_Town";

                bdTownship.DataSource = bdTown;
                bdTownship.DataMember = "Town_Township";

                cmbContactSDiv.DataSource = bdSDivision;
                cmbContactTown.DataSource = bdTown;
                cmbContactTownship.DataSource = bdTownship;

                if (contactTbl.Rows.Count > 0)
                {
                    int TownID = (int)DataTypeParser.Parse(contactTbl.Rows[0]["TownID"].ToString(), typeof(int), -1);
                    int? TownshipID = (int?)DataTypeParser.Parse(contactTbl.Rows[0]["TownshipID"].ToString(), typeof(int), null);
                    int StateDivisionID = (int)DataTypeParser.Parse(contactTbl.Rows[0]["StateDivisionID"].ToString(), typeof(int), -1);

                    if (StateDivisionID == -1)
                    {
                        cmbContactSDiv.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbContactSDiv.SelectedValue = StateDivisionID;
                    }

                    if (TownshipID == null)
                    {
                        cmbContactTownship.SelectedValue = -1;
                    }
                    else
                    {
                        cmbContactTownship.SelectedValue = TownshipID;

                    }
                    cmbContactTown.SelectedValue = TownID;
                }

            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
            }            
        }

        private void LoadData()
        {
            try
            {
                bankTbl = new BankBL().GetAll();
                routeTbl = new RouteBL().GetAll();

                // generate the data to insert
                DataRow routeInsert = routeTbl.NewRow();
                routeInsert["RouteID"] = -1;
                routeInsert["RouteName"] = "-";
                // insert in the Index 0 place
                routeTbl.Rows.InsertAt(routeInsert, 0);

                tripTbl = new TripBL().GetAll();
                // generate the data to insert
                DataRow tripInsert = tripTbl.NewRow();
                tripInsert["TripID"] = -1;
                tripInsert["TripName"] = "-";
                // insert in the Index 0 place
                tripTbl.Rows.InsertAt(tripInsert, 0);

                cusclassTbl = new CustomerClassBL().GetAll();
                custypeTbl = new CusTypeBL().GetData();                
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
            }
        }

        private void BindCombos()
        {
            // Bindin ComboBank
            DataRow row = bankTbl.NewRow();
            row["Bank"] = "None";
            bankTbl.Rows.InsertAt(row, 0);
            cmbBank.DataSource = bankTbl;
            cmbBank.DisplayMember = "Bank";
            cmbBank.ValueMember = "BankID";

            // Bindin ComboTown
            //cmbTown.DataSource = townTbl;
            //cmbTown.DisplayMember = "Town";
            //cmbTown.ValueMember = "TownID";

            //cmbOwnerTown.DataSource = ownertownTbl;
            //cmbOwnerTown.DisplayMember = "Town";
            //cmbOwnerTown.ValueMember = "TownID";

            //cmbContactTown.DataSource = contacttownTbl;
            //cmbContactTown.DisplayMember = "Town";
            //cmbContactTown.ValueMember = "TownID";

            //// Bindin ComboTownship
            //cmbTownship.DataSource = townshipTbl;
            //cmbTownship.DisplayMember = "Township";
            //cmbTownship.ValueMember = "TownshipID";

            //cmbOwnerTownship.DataSource = ownertownshipTbl;
            //cmbOwnerTownship.DisplayMember = "Township";
            //cmbOwnerTownship.ValueMember = "TownshipID";

            //cmbContactTownship.DataSource = contacttownshipTbl;
            //cmbContactTownship.DisplayMember = "Township";
            //cmbContactTownship.ValueMember = "TownshipID";

            //// Bindin ComboStateDivision
            //cmbStateDivision.DataSource = statedibisionTbl;
            //cmbStateDivision.DisplayMember = "StateDivisionName";
            //cmbStateDivision.ValueMember = "SDivisionID";

            //cmbContactSDiv.DataSource = contactstatedibisionTbl;
            //cmbContactSDiv.DisplayMember = "StateDivisionName";
            //cmbContactSDiv.ValueMember = "SDivisionID";

            //cmbOwnerStateDivision.DataSource = ownerstatedibisionTbl;
            //cmbOwnerStateDivision.DisplayMember = "StateDivisionName";
            //cmbOwnerStateDivision.ValueMember = "SDivisionID";

            // Bindin ComboRoute
            cmbRoute.DataSource = routeTbl;
            cmbRoute.DisplayMember = "RouteName";
            cmbRoute.ValueMember = "RouteID";

            // Bindin ComboTirp
            cmbTrip.DataSource = tripTbl;
            cmbTrip.DisplayMember = "TripName";
            cmbTrip.ValueMember = "TripID";

            // Bindin CusClass
            cmbCusClass.DataSource = cusclassTbl;
            cmbCusClass.DisplayMember = "CusClass";
            cmbCusClass.ValueMember = "CustomerClassID";

            cmbCustomerClass.DataSource = cusclassTbl;
            cmbCustomerClass.DisplayMember = "CusClass";
            cmbCustomerClass.ValueMember = "CustomerClassID";

            // Binding CusType 
            cmbCustomerType.DataSource = custypeTbl;
            cmbCustomerType.DisplayMember = "CusTypeName";
            cmbCustomerType.ValueMember = "CusTypeID";
        }

        private void LoadNBindContact_Owner()
        {
            DataTable contactTbl = null;
            DataTable ownerTbl = null;
            try
            {
                contactTbl = new ContactPersonBL().GetAll(customer.ID);
                ownerTbl = new OwnerBL().GetAll(customer.ID);

                // Bind CustomerInfo into Customer Form
                txtCodeNo.Text = customer.CusCode;
                txtCustomerName.Text = customer.CusName;
                txtPhone1.Text = customer.Phone1;
                txtPhone2.Text = customer.Phone2;
                txtFax.Text = customer.Fax;
                txtEmail.Text = customer.Email;
                txtWebsite.Text = customer.Website;
                cmbBank.SelectedValue = customer.BankID;
                txtBankAcc.Text = customer.BankAccNo;
                //    txtHno.Text = address.Hno;
                txtStreet.Text = (string)DataTypeParser.Parse(address.Street,typeof(string),string.Empty);
                txtQuarter.Text = (string)DataTypeParser.Parse(address.Quartar, typeof(string), string.Empty);
                cmbTown.SelectedValue = (int?)DataTypeParser.Parse(address.TownID,typeof(int),null);
                // Add photos                
                //imgList.Images.AddRange(new Image[] 
                //                        {
                //                        PTIC.Util.ImageConverter.ToImage(customer.Photo1),
                //                        PTIC.Util.ImageConverter.ToImage(customer.Photo2),
                //                        PTIC.Util.ImageConverter.ToImage(customer.Photo3),
                //                        PTIC.Util.ImageConverter.ToImage(customer.Photo4),
                //                        PTIC.Util.ImageConverter.ToImage(customer.Photo5)
                //                        });

                //SetImageIndex();

                if (address.TownshipID == null)
                {
                    cmbTownship.SelectedValue = -1;
                    cmbTrip.Enabled = true;
                    if (customer.TripID == null)
                    {
                        cmbTrip.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbTrip.SelectedValue = customer.TripID;
                    }
                    cmbRoute.SelectedIndex = 0;
                    cmbRoute.Enabled = false;
                }
                else
                {
                    cmbTownship.SelectedValue = address.TownshipID;
                    cmbRoute.Enabled = true;
                    if (customer.RouteID == null)
                    {
                        cmbRoute.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbRoute.SelectedValue = customer.RouteID;
                    }
                    cmbTrip.SelectedIndex = 0;
                    cmbTrip.Enabled = false;
                }
                cmbStateDivision.SelectedValue = address.StateDivisionID;                
                cmbCustomerType.SelectedValue = (int)DataTypeParser.Parse(customer.CusType, typeof(int), -1);
                //cmbCusClass.SelectedValue = (int)DataTypeParser.Parse(customer.CusClassID, typeof(int), -1);
                cmbCustomerClass.SelectedValue = (int)DataTypeParser.Parse(customer.CusClassID, typeof(int), -1);
                txtCreditAmt.Text = customer.CreditAmount.ToString("N0");
                txtCreditLimit.Text = (string)DataTypeParser.Parse(customer.CreditLimit.ToString(), typeof(string), null);
                if (customer.CusDate > DateTime.Now)
                {
                    ToastMessageBox.Show(Resource.errDateTime, Color.Red);
                    return;
                }
                dtpCustomer.Value = (DateTime)DataTypeParser.Parse(customer.CusDate, typeof(DateTime), DateTime.Now);

                //Binding to ContactPerson Form
                if (contactTbl.Rows.Count > 0)
                {
                    contactperson.AddrID = (int?)DataTypeParser.Parse(contactTbl.Rows[0]["AddrID"].ToString(), typeof(int), null);
                    contactperson.ID = (int)DataTypeParser.Parse(contactTbl.Rows[0]["ContactPersonID"].ToString(), typeof(int), -1);
                    contactperson.CusID = (int)DataTypeParser.Parse(contactTbl.Rows[0]["CusID"].ToString(), typeof(int), -1);
                    txtName.Text = contactTbl.Rows[0]["ConPersonName"].ToString();
                    dtpDOB.Value = (DateTime)DataTypeParser.Parse(contactTbl.Rows[0]["DOB"].ToString(), typeof(DateTime), DateTime.Now);
                    txtNRC.Text = contactTbl.Rows[0]["NRC"].ToString();
                    txtPosition.Text = contactTbl.Rows[0]["Post"].ToString();
                    txtEmail.Text = contactTbl.Rows[0]["Email"].ToString();
                    txtMobile.Text = contactTbl.Rows[0]["MobilePhone"].ToString();
                    txtHomePhone.Text = contactTbl.Rows[0]["HomePhone"].ToString();
                    txtMembership.Text = contactTbl.Rows[0]["Membership"].ToString();
                    txtEdu.Text = contactTbl.Rows[0]["Education"].ToString();
                    txtWifeORHusband.Text = contactTbl.Rows[0]["SpouseName"].ToString();
                    txtRace.Text = contactTbl.Rows[0]["Race"].ToString();
                    int religionindex = (int)DataTypeParser.Parse(contactTbl.Rows[0]["Religion"], typeof(int), -1);
                    //cmbReligion.SelectedValue = (int)DataTypeParser.Parse(ownerrow["Religion"], typeof(int), -1);
                    cmbContactReligion.SelectedIndex = religionindex;
                    txtRemark.Text = contactTbl.Rows[0]["Remark"].ToString();

                    // Address 
                    txtNo.Text = contactTbl.Rows[0]["Hno"].ToString();
                    txtContactStreet.Text = contactTbl.Rows[0]["Street"].ToString();
                    txtContactQuarter.Text = contactTbl.Rows[0]["Quartar"].ToString();                    
                    int i = (int)DataTypeParser.Parse(contactTbl.Rows[0]["TownID"].ToString(), typeof(int), -1);
                }
                //cmbContactTown.SelectedValue = (int)DataTypeParser.Parse(contactTbl.Rows[0]["TownID"].ToString(), typeof(int), -1);
                //cmbContactTownship.SelectedValue = (int)DataTypeParser.Parse(contactTbl.Rows[0]["TownshipID"].ToString(), typeof(int), -1);
                //cmbContactSDiv.SelectedValue = (int)DataTypeParser.Parse(contactTbl.Rows[0]["StateDivisionID"].ToString(), typeof(int), -1);                
                foreach (DataRow ownerrow in ownerTbl.Rows)
                { // Bind Owner Info into Form
                    owner.AddrID = (int)DataTypeParser.Parse(ownerrow["AddrID"].ToString(), typeof(int), -1);
                    owner.OwnerID = (int)DataTypeParser.Parse(ownerrow["OwnerID"].ToString(), typeof(int), -1);
                    owner.CusID = (int)DataTypeParser.Parse(ownerrow["CusID"].ToString(), typeof(int), -1);
                    txtOwner.Text = ownerrow["OwnerName"].ToString();
                    dtpOwnerDOB.Value = (DateTime)DataTypeParser.Parse(ownerrow["DOB"].ToString(), typeof(DateTime), -1);
                    txtOwnerNRC.Text = ownerrow["NRC"].ToString();
                    txtFax.Text = ownerrow["Fax"].ToString();
                    txtOwnerMobile.Text = ownerrow["MobilePhone"].ToString();
                    txtOwnerHomePhone.Text = ownerrow["HomePhone"].ToString();
                    txtOwnerMembership.Text = ownerrow["Membership"].ToString();
                    txtOwnerEdu.Text = ownerrow["Education"].ToString();
                    txtOwnerOtherBus.Text = ownerrow["OtherBussiness"].ToString();
                    txtOwnerSpouse.Text = ownerrow["SpouseName"].ToString();
                    txtOwnerRace.Text = ownerrow["Race"].ToString();

                    //cmbReligion.SelectedValue = (int)DataTypeParser.Parse(ownerrow["Religion"], typeof(int), -1);
                    cmbReligion.SelectedIndex = (int)DataTypeParser.Parse(ownerrow["Religion"], typeof(int), 0);
                    txtOwnerRemark.Text = ownerrow["Remark"].ToString();

                    // Address 
                    txtOwnerNo.Text = ownerrow["Hno"].ToString();
                    txtOwnerStreet.Text = ownerrow["Street"].ToString();
                    txtOwnerQuarter.Text = ownerrow["Quartar"].ToString();
                    //cmbOwnerTown.SelectedValue = (int)DataTypeParser.Parse(ownerrow["TownID"].ToString(), typeof(int), -1);
                    //cmbOwnerTownship.SelectedValue = (int)DataTypeParser.Parse(ownerrow["TownshipID"].ToString(), typeof(int), -1);
                    //cmbOwnerStateDivision.SelectedValue = (int)DataTypeParser.Parse(ownerrow["StateDivisionID"].ToString(), typeof(int), -1);

                    // Load image(s)
                    //imgLstView.
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
            }            
        }
        
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {

            int ChkTownshipID = (int)DataTypeParser.Parse(cmbTownship.SelectedValue, typeof(int), -1);
            int ChkTownID = (int)DataTypeParser.Parse(cmbTown.SelectedValue, typeof(int), -1);
            int ChkRouteID = (int)DataTypeParser.Parse(cmbRoute.SelectedValue, typeof(int), -1);
            int ChkTripID = (int)DataTypeParser.Parse(cmbTrip.SelectedValue, typeof(int), -1);

            bool IsEqual = false;

            if (ChkRouteID != -1)
            {
                DataTable dtTownshipInRoute = new TownshipInRouteBL().GetTownshipInRouteByTownshipID(ChkTownshipID);
                foreach (DataRow row in dtTownshipInRoute.Rows)
                {
                    if ((int)DataTypeParser.Parse(row["RouteID"], typeof(int), -1) == ChkRouteID)
                    {
                        IsEqual = true;
                        break;
                    }
                }
                if (IsEqual == false)
                {
                    MessageBox.Show("ရွေးချယ်ထားသောလမ်းကြောင်းသည် သတ်မှတ်ထားသော မြို့နယ်နှင့်မကိုက်ညီပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if(ChkTripID != -1)
            {
                DataTable dtTownInTrip = new TownInTripBL().GetTownInTripByTownID(ChkTownID);
                foreach (DataRow row in dtTownInTrip.Rows)
                {

                    if ((int)DataTypeParser.Parse(dtTownInTrip.Rows[0]["TripID"], typeof(int), -1) == ChkTripID)
                    {
                        IsEqual = true;
                        break;
                    }
                }
                if(IsEqual == false)
                {
                    MessageBox.Show("ရွေးချယ်ထားသောခရီးစဉ်သည် သတ်မှတ်ထားသော မြို့နှင့်မကိုက်ညီပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Saving Data for Insert and Update
            int? affectrow = 0;
            CustomerBL cusSaver = null;
            try
            {
                cusSaver = new CustomerBL();

                customer.CusCode = String.IsNullOrEmpty(txtCodeNo.Text) ? "" : txtCodeNo.Text;
                customer.CusName = String.IsNullOrEmpty(txtCustomerName.Text) ? "" : txtCustomerName.Text;
                customer.Phone1 = String.IsNullOrEmpty(txtPhone1.Text) ? "" : txtPhone1.Text;
                customer.Phone2 = String.IsNullOrEmpty(txtPhone2.Text) ? "" : txtPhone2.Text;
                customer.Fax = String.IsNullOrEmpty(txtFax.Text) ? "" : txtFax.Text;
                customer.Email = String.IsNullOrEmpty(txtEmail.Text) ? "" : txtEmail.Text;
                customer.Website = String.IsNullOrEmpty(txtWebsite.Text) ? "" : txtWebsite.Text;
                customer.BankID = (int?)DataTypeParser.Parse(cmbBank.SelectedValue, typeof(int), null);
                customer.BankAccNo = String.IsNullOrEmpty(txtBankAcc.Text) ? "" : txtBankAcc.Text;
                if (cmbRoute.Enabled == true)
                {
                    customer.RouteID = (int?)DataTypeParser.Parse(cmbRoute.SelectedValue, typeof(int), null);
                    customer.TripID = (int?)DataTypeParser.Parse("", typeof(int), null);
                }
                else if (cmbTrip.Enabled == true)
                {
                    customer.RouteID = (int?)DataTypeParser.Parse("", typeof(int), null);
                    customer.TripID = (int?)DataTypeParser.Parse(cmbTrip.SelectedValue, typeof(int), null);
                }
                customer.CusType = (int)DataTypeParser.Parse(cmbCustomerType.SelectedValue, typeof(int), -1);
                customer.CusClassID = (int)DataTypeParser.Parse(cmbCustomerClass.SelectedValue, typeof(int), -1);
                customer.CreditAmount = (decimal)DataTypeParser.Parse(txtCreditAmt.Text, typeof(decimal), 0);
                customer.CreditLimit = (int)DataTypeParser.Parse(txtCreditLimit.Text, typeof(int), 0);
                customer.CusDate = dtpCustomer.Value;
                customer.Remark = txtRemark.Text;

                // Images
                int imgCount = imgList.Images.Count;
                customer.Photo1 = imgCount > 0 ? PTIC.Util.ImageConverter.ToByteArray(imgList.Images[0]) : null;
                customer.Photo2 = imgCount > 1 ? PTIC.Util.ImageConverter.ToByteArray(imgList.Images[1]) : null;
                customer.Photo3 = imgCount > 2 ? PTIC.Util.ImageConverter.ToByteArray(imgList.Images[2]) : null;
                customer.Photo4 = imgCount > 3 ? PTIC.Util.ImageConverter.ToByteArray(imgList.Images[3]) : null;
                customer.Photo5 = imgCount > 4 ? PTIC.Util.ImageConverter.ToByteArray(imgList.Images[4]) : null;

                // Address
                address.StateDivisionID = (int?)DataTypeParser.Parse(cmbStateDivision.SelectedValue, typeof(int), null);
                address.TownID = (int?)DataTypeParser.Parse(cmbTown.SelectedValue, typeof(int), null);
                address.TownshipID = (int?)DataTypeParser.Parse(cmbTownship.SelectedValue, typeof(int), null);
                address.Hno = txtHno.Text;
                address.Street = txtStreet.Text;
                address.Quartar = txtQuarter.Text;
                address.Country = txtCountry.Text;

                //contactperson.CusID = CusID;
                contactperson.ContactPersonName = (string)DataTypeParser.Parse(txtName.Text, typeof(string), null);
                contactperson.DOB = (DateTime)DataTypeParser.Parse(dtpDOB.Value, typeof(DateTime), null);
                contactperson.Post = (string)DataTypeParser.Parse(txtPosition.Text, typeof(string), null);
                contactperson.NRC = (string)DataTypeParser.Parse(txtNRC.Text, typeof(string), null);
                contactperson.MobilePhone = (string)DataTypeParser.Parse(txtMobile.Text, typeof(string), null);
                contactperson.HomePhone = (string)DataTypeParser.Parse(txtHomePhone.Text, typeof(string), null);
                contactperson.Email = (string)DataTypeParser.Parse(txtEmail.Text, typeof(string), null);
                contactperson.Membership = (string)DataTypeParser.Parse(txtMembership.Text, typeof(string), null);
                contactperson.Education = (string)DataTypeParser.Parse(txtEdu.Text, typeof(string), null);
                contactperson.SpouseName = (string)DataTypeParser.Parse(txtWifeORHusband.Text, typeof(string), null);
                contactperson.Race = (string)DataTypeParser.Parse(txtRace.Text, typeof(string), null);
                if ((int)DataTypeParser.Parse(cmbContactReligion.SelectedIndex, typeof(int), null) == -1)
                {
                    contactperson.Religion = 0;
                }
                else
                {
                    contactperson.Religion = (int)DataTypeParser.Parse(cmbContactReligion.SelectedIndex, typeof(int), null);
                }
                contactperson.Remark = (string)DataTypeParser.Parse(txtRemark.Text, typeof(string), null);

                // Address
                contactpersonaddress.StateDivisionID = (int?)DataTypeParser.Parse(cmbContactSDiv.SelectedValue, typeof(int), null);
                contactpersonaddress.TownID = (int?)DataTypeParser.Parse(cmbContactTown.SelectedValue, typeof(int), null);
                contactpersonaddress.TownshipID = (int?)DataTypeParser.Parse(cmbContactTownship.SelectedValue, typeof(int), null);
                contactpersonaddress.Hno = txtNo.Text;
                contactpersonaddress.Street = txtContactStreet.Text;
                contactpersonaddress.Quartar = txtContactQuarter.Text;
                contactpersonaddress.Country = "";

                // Owner Information
                owner.OwnerName = (string)DataTypeParser.Parse(txtOwner.Text, typeof(string), null);
                owner.DOB = (DateTime)DataTypeParser.Parse(dtpOwnerDOB.Value, typeof(DateTime), null);
                owner.NRC = (string)DataTypeParser.Parse(txtNRC.Text, typeof(string), null);
                owner.Fax = (string)DataTypeParser.Parse(txtFax.Text, typeof(string), null);
                owner.MobilePhone = (string)DataTypeParser.Parse(txtOwnerMobile.Text, typeof(string), null);
                owner.HomePhone = (string)DataTypeParser.Parse(txtOwnerHomePhone.Text, typeof(string), null);
                owner.OtherBussiness = (string)DataTypeParser.Parse(txtOwnerOtherBus.Text, typeof(string), null);
                owner.Membership = (string)DataTypeParser.Parse(txtOwnerMembership.Text, typeof(string), null);
                owner.Education = (string)DataTypeParser.Parse(txtOwnerEdu.Text, typeof(string), null);
                owner.SpouseName = (string)DataTypeParser.Parse(txtOwnerSpouse.Text, typeof(string), null);
                owner.Race = (string)DataTypeParser.Parse(txtOwnerRace.Text, typeof(string), null);

                if ((int)DataTypeParser.Parse(cmbReligion.SelectedIndex, typeof(int), null) == -1)
                {
                    owner.Religion = 0;
                }
                else
                {
                    owner.Religion = (int)DataTypeParser.Parse(cmbReligion.SelectedIndex, typeof(int), null);
                }
                owner.Remark = (string)DataTypeParser.Parse(txtOwnerRemark.Text, typeof(string), null);

                // Owner Address
                owneraddress.StateDivisionID = (int?)DataTypeParser.Parse(cmbOwnerStateDivision.SelectedValue, typeof(int), null);
                owneraddress.TownID = (int?)DataTypeParser.Parse(cmbOwnerTown.SelectedValue, typeof(int), null);
                owneraddress.TownshipID = (int?)DataTypeParser.Parse(cmbOwnerTownship.SelectedValue, typeof(int), null);
                owneraddress.Hno = txtOwnerNo.Text;
                owneraddress.Street = txtOwnerStreet.Text;
                owneraddress.Quartar = txtOwnerQuarter.Text;
                owneraddress.Country = "";

                if (customer.ID != 0)
                {
                    affectrow = cusSaver.UpdateByCustomerID(customer, address, owner, owneraddress, contactperson, contactpersonaddress);
                }
                else
                {
                    affectrow = cusSaver.Add(customer, address, contactperson, contactpersonaddress, owner, owneraddress);
                }

                if (!cusSaver.ValidationResults.IsValid) // validation fail
                {
                    ValidationResult err = DataUtil.GetFirst(cusSaver.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        "Customer",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else // successful validation
                {
                    // Success in db also
                    if (affectrow.HasValue && affectrow.Value > 0)
                    {
                        ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                        this.Close();
                    }
                    else
                        ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(
                        err.Message,
                        "Customer",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                _logger.Error(err);
            }
        }

        private void frmCustomerInformation_Load(object sender, EventArgs e)
        {
            dtpCustomer.MaxDate = DateTime.Now;
            // dtpDOB.MaxDate = DateTime.Today.AddYears(this.MaxBirthYears);            
            // dtpOwnerDOB.MaxDate = DateTime.Today.AddYears(this.MaxBirthYears);

            if (customer.ID != 0)
            {
                LoadNBindContact_Owner();
                customer.AddrID = customer.AddrID;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {

        }

        private void cmbTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox cmb = (ComboBox)sender;
            //if (cmb.SelectedValue == null) return;
            //int selectedIndex = cmb.SelectedIndex;
            //int selectedValue = (int)cmb.SelectedValue;
            //if (selectedValue == 1)
            //{
            //    cmbTrip.Enabled = false;
            //    cmbRoute.Enabled = true;
            //}
            //else
            //{
            //    cmbRoute.Enabled = false;
            //    cmbTrip.Enabled = true;
            //}

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tagOwner)
            {
                txtOwner.Focus();
            }
            else if (tabControl1.SelectedTab == tabContactPerson)
            {
                txtName.Focus();
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (txtEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("ပုံစံမှားယွင်းနေပါသည်။\r\nemail address များသည် character သုံးလုံးအထက်တွင်ရှိရပါမည်။ e.g-something@gmail.com", "သတိပေးချက်",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtEmail.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        public static bool isValidUrl(ref string url)
        {
            string pattern = (@"([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }

        private void txtWebsite_Validating(object sender, CancelEventArgs e)
        {
            if (txtWebsite.Text.Length > 0)
            {
                string url = txtWebsite.Text;
                if (!isValidUrl(ref url))
                {
                    ToastMessageBox.Show("ပံုစံမွားေနပါတယ္ ! e.g-google.com", Color.Red);
                    e.Cancel = true;
                }
            }
        }

        private void cmbTown_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.SelectedValue == null) return;
            int selectedIndex = cmb.SelectedIndex;
            int selectedValue = (int)cmb.SelectedValue;
            if (selectedValue == 1)
            {
                cmbTrip.Enabled = false;
                cmbRoute.Enabled = true;
            }
            else
            {
                cmbRoute.Enabled = false;
                cmbTrip.Enabled = true;
            }
        }

        private void btnAddImg_Click(object sender, EventArgs e)
        {
            AddImage();
            ImageCouting();
        }

        private void btnDeleteImg_Click(object sender, EventArgs e)
        {
            if (lstViewImage.SelectedItems.Count < 1)
                return;
            if (MessageBox.Show("Are you sure to delete a selected photo?", "Photo Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            if (!string.IsNullOrEmpty(lstViewImage.SelectedItems[0].ImageKey))
                // Delete selected image
                DeleteImage(lstViewImage.SelectedItems[0].ImageKey, customer.ID);
            ImageCouting();
        }

        private void lstViewImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ListView view = sender as ListView;
            //if (view.SelectedItems.Count < 1)
            //    return;
            //// Open ImageViewer
            //var aaaa = view.SelectedItems[0];
            //int imgIndex = view.SelectedItems[0].ImageIndex;
            //if (imgIndex >= 0 && imgIndex < imgList.Images.Count)
            //{
            //    frmImageViewer imgViewer = new frmImageViewer(imgList.Images[imgIndex]);
            //    UIManager.OpenForm(imgViewer);                
            //}

        }

        private void lstViewImage_DoubleClick(object sender, EventArgs e)
        {
            ListView view = sender as ListView;
            if (view.SelectedItems.Count < 1)
                return;
            // Open ImageViewer
            if (!string.IsNullOrEmpty(view.SelectedItems[0].ImageKey))
            {
                string imgKey = view.SelectedItems[0].ImageKey;
                frmImageViewer imgViewer = new frmImageViewer(imgList.Images[imgKey]);
                UIManager.OpenForm(imgViewer);
            }

            //int imgIndex = view.SelectedItems[0].ImageIndex;
            //if (imgIndex >= 0 && imgIndex < imgList.Images.Count)
            //{
            //    frmImageViewer imgViewer = new frmImageViewer(imgList.Images[imgIndex]);
            //    UIManager.OpenForm(imgViewer);
            //}
        }

        #region Private Methods
        //private void SetImageRenderer()
        //{
        //    Assembly assembly = Assembly.GetAssembly(typeof(ImageListView));
        //    ImageListView.ImageListViewRenderer renderer =
        //        assembly.CreateInstance("Manina.Windows.Forms.ImageListViewRenderers+ZoomingRenderer")
        //            as ImageListView.ImageListViewRenderer;
        //    imgLstView.SetRenderer(renderer);
        //}
        //private void Set

        private void AddImage()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string tmpKey = "TmpKey";
                for (int i = 0, j = 0; i < openFileDialog.FileNames.Length; i++, j++)
                {
                    string fileName = openFileDialog.FileNames[i];
                    // If photo count is less than 5, add image to ImageList
                    if (imgList.Images.Count < 5)
                    {
                        Image img = Image.FromFile(fileName);
                        // TODO: Value muste be changed as Title
                        foreach (var key in imageStore.Keys)
                        {
                            if (key.Equals(tmpKey + j))
                                j++;
                        }
                        imgList.Images.Add(tmpKey + j, img);
                        imageStore.Add(tmpKey + j, tmpKey + j);
                    }
                    else
                    {
                        if (imgList.Images.Count == 5)
                        {
                            MessageBox.Show(Resource.errImageCountOver, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    }
                }
                //SetImageIndex();
                SetImageKey();
            }
        }

        //private void SetImageIndex()
        //{
        //    lstViewImage.Items.Clear();
        //    // Set ImageIndex
        //    for (int i = 0; i < imgList.Images.Count; i++)
        //    {
        //        ListViewItem item = new ListViewItem();
        //        item.ImageIndex = i;
        //        item.ToolTipText = "Please double-click to view image.";
        //        //item.Text = imgList.Images[i].Tag.ToString();

        //        //var allPropertyItem = imgList.Images[i].PropertyItems;
        //        //ASCIIEncoding encoding = new ASCIIEncoding();
        //        ////string imgTitle = encoding.GetString(allPropertyItem[1].Value);
        //        //const int metTitle = 0x0320;
        //        //var imgTitle = allPropertyItem.FirstOrDefault(x => x.Id == metTitle);
        //        //if(imgTitle != null)
        //        //    item.Text = encoding.GetString(imgTitle.Value);

        //        lstViewImage.Items.Add(item);
        //    }    
        //}

        private void SetImageKey()
        {
            lstViewImage.Items.Clear();
            foreach (var entry in imageStore)
            {
                ListViewItem item = new ListViewItem();
                item.ImageKey = entry.Key;
                item.ToolTipText = "Please double-click to view image.";
                lstViewImage.Items.Add(item);
            }
        }

        private void DeleteImage(string columnName, int customerID)
        {
            // Delete from DB Table
            if (columnName.StartsWith("TmpKey"))// Delete image that has not been saved into database, from ListView
                DeleteImage(columnName);
            else if (!string.IsNullOrEmpty(columnName))
            {
                int afftectedRows = new CustomerBL().DeletePhotoBy(columnName, customerID);
                if (afftectedRows > 0)
                {
                    // Delete image that has been in database, from ListView
                    DeleteImage(columnName);
                }
            }
        }

        private void DeleteImage(string columnName)
        {
            // Remove image from both ListView and ImageList
            lstViewImage.Items.RemoveByKey(columnName);
            imgList.Images.RemoveByKey(columnName);

            // Remove entry fom imageStore
            imageStore.Remove(columnName);
            // Reset ImageKey of image
            SetImageKey();
        }
        #endregion

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectedCusType = (int)DataTypeParser.Parse(cmbCustomerType.SelectedValue, typeof(int), -1);

            if (SelectedCusType != (int)PTIC.Common.Enum.CustomerType.WholeSaleOutlet && SelectedCusType != (int)PTIC.Common.Enum.CustomerType.RetailOutlet)
            {
                cmbTrip.Enabled = true;
                cmbRoute.Enabled = true;
                cmbTrip.SelectedIndex = 0;
                cmbRoute.SelectedIndex = 0;
            }
            else
            {
                if ((int)DataTypeParser.Parse(cmbTown.SelectedValue, typeof(int), -1) == 1)
                {
                    cmbRoute.Enabled = true;
                    cmbTrip.Enabled = false;
                }
                else
                {
                    cmbRoute.Enabled = false;
                    cmbTrip.Enabled = true;
                }
            }
        }

        private void txtCreditAmt_TextChanged(object sender, EventArgs e)
        {
           //KeyPressF
        }

        private void txtCreditAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressfunction.CheckInt(sender, e);
        }

        private void txtCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressfunction.CheckInt(sender, e);
        }
    }
}

/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/03/22 (yyyy/MM/dd)
 * Description: Setup form for a temp/potential customer
 */
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using PTIC.VC.Util;
using PTIC.Sale.BL;

namespace PTIC.VC.Sale.Setup
{
    public partial class frmNewCustomer : Form
    {
        /// <summary>
        /// Logger for frmTempCustomer
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmNewCustomer));

        private bool _isPotentialCustomer = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void TempCustomerSaveHandler(object sender, TempCustomerSaveEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event TempCustomerSaveHandler TempCustomerSavedHandler;

        #region Events
        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (string.IsNullOrEmpty(txtBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtBox, "Please enter field value!");
            }
        }

        private void txtBox_Validated(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            errorProvider.SetError(txtBox, string.Empty);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if(IsValid())
            Save();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Load and bind necessary data
        /// </summary>
        private void LoadNBind()
        {            
            try
            {                
                DataSet ds = new DataSet();
                BindingSource bdTown = new BindingSource();
                BindingSource bdTownship = new BindingSource();

                DataTable dtTown = new TownBL().GetAll();
                DataTable dtTownship = new TownshipBL().GetAll();

                ds.Tables.Add(dtTown);
                ds.Tables.Add(dtTownship);

                DataRelation relTown_Township = new DataRelation("Town_Township", 
                    dtTown.Columns["TownID"], dtTownship.Columns["TownID"]);
                ds.Relations.Add(relTown_Township);

                bdTown.DataSource = ds;
                bdTown.DataMember = dtTown.TableName;

                bdTownship.DataSource = bdTown;
                bdTownship.DataMember = "Town_Township";

                cmbTown.DataSource = bdTown;
                cmbTownship.DataSource = bdTownship;


                DataTable dtCusType = new CusTypeBL().GetData();
                cmbCusType.DataSource = dtCusType;
                cmbCusType.DisplayMember = "CusTypeName";
                cmbCusType.ValueMember = "CusTypeID";
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
                ToastMessageBox.Show(Resource.FailedToLoadData, Color.Red);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Save()
        {            
            try
            {
                Customer newCustomer = new Customer()
                {
                    CusName = txtCustomerName.Text,
                    Phone1 = txtPh1.Text,
                    Phone2 = txtPh2.Text,
                    CusDate = (DateTime)DataTypeParser.Parse(dtpCusDate.Value,typeof(DateTime),DateTime.Now),
                    CusClassID = 3, // Class C
                    CusType = (int)DataTypeParser.Parse(cmbCusType.SelectedValue,typeof(int),-1),
                    //IsPotential = false // it is a temp customer
                    IsPotential = this._isPotentialCustomer
                };
                Address newAddress = new Address()
                {
                    TownID = (int)DataTypeParser.Parse(cmbTown.SelectedValue, typeof(int), -1),
                    TownshipID = (int)DataTypeParser.Parse(cmbTownship.SelectedValue, typeof(int), -1)
                };
                ContactPerson newContactPerson = new ContactPerson()
                {
                    ContactPersonName = txtContactPersonName.Text,
                    DOB = DateTime.Now.AddYears(-16),
                };
                // Set a new inserted customer ID
                newCustomer.ID = new CustomerBL().Add(newCustomer, newAddress, newContactPerson);
                // If a new customer ID is present
                if (newCustomer.ID > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    // Send data back to caller
                    TempCustomerSaveEventArgs tempCustomerArg = new TempCustomerSaveEventArgs(newCustomer, newContactPerson, newAddress);
                    TempCustomerSavedHandler(this, tempCustomerArg);
                    // Close this form
                    this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            catch (SqlException sqle)
            {
                ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                _logger.Error(sqle);
            }
            finally
            {
                this.Close();
            }
        }
        #endregion

        #region Constructor

        private frmNewCustomer() 
        {
            InitializeComponent();
            // Set foucs on Customer Name
            this.txtCustomerName.Select();
            this.txtCustomerName.Focus();
        }

        public frmNewCustomer(bool isPotentialCustomer)
        {
            InitializeComponent();
            // Set foucs on Customer Name
            this.txtCustomerName.Select();
            this.txtCustomerName.Focus();
            // whether it is a potential customer
            this._isPotentialCustomer = isPotentialCustomer;
            // Configure logger 
            XmlConfigurator.Configure();
            // Load and bind necessary data
            LoadNBind();
        }
        #endregion

        #region Inner Class
        public class TempCustomerSaveEventArgs : EventArgs
        {
            Customer _customer = null;
            ContactPerson _contactPersonOfCustomer = null;
            Address _address = null;
            public TempCustomerSaveEventArgs(Customer savedCustomer, ContactPerson contactPerson, Address address)
            {
                this._customer = savedCustomer;
                this._contactPersonOfCustomer = contactPerson;
                this._address = address;
            }
            public Customer SavedTempCustomer 
            {
                get { return this._customer; }
            }
            public ContactPerson SavedContactPerson
            {
                get { return this._contactPersonOfCustomer; }
            }
            public Address SavedAddress
            {
                get { return this._address; }
            }
        }
        #endregion

        private void cmbCusType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTownship_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPh2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPh1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContactPersonName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    
    }
}

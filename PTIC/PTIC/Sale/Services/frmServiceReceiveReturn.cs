using System;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Sale.BL;
using PTIC.Common.BL;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Sale.Entities;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.VC.Sale.Services
{
    public partial class frmServiceReceiveReturn : Form
    {
        private bool _occuredChanges;

        public delegate void ServiceReceivedReturnHandler(object sender, ServiceReceivedReturnedEventArgs e);

        public ServiceReceivedReturnHandler ServiceReceivedReturnedHandler;

        /// <summary>
        /// DataTable for Ven
        /// </summary>
        private DataTable dtVen = null;

        /// <summary>
        /// DataTable for SubStore
        /// </summary>
        private DataTable dtSubStore = null;

        /// <summary>
        /// DataTable for Employee
        /// </summary>
        private DataTable dtEmployee = null;

        /// <summary>
        /// DataTable for Product
        /// 
        /// </summary>
        private DataTable dtProduct = null;

        /// <summary>
        /// SalesService Entities
        /// </summary>
        SalesService salesService = new SalesService();

        /// <summary>
        /// ServicedCustomer Entities
        /// </summary>
        ServicedCustomer servicedCustomer = new ServicedCustomer();


        /// <summary>
        /// VenID
        /// </summary>
        /// 
        int? VenID = null;

        /// <summary>
        /// WarehouseID
        /// </summary>
        int? WarehouseID = null;

        /// <summary>
        /// ServieStatus Entites
        /// </summary>
        ServiceBatteryStatus _serviceStatus = new ServiceBatteryStatus();      

        /// <summary>
        /// DataTable for Customers
        /// </summary>
        /// 
        DataTable dtCustomer = null;

        /// <summary>
        /// DataTable Town
        /// </summary>
        /// 
        DataTable dtTown = null;

        /// <summary>
        /// DataTable Township
        /// </summary>
        /// 
        DataTable dtTownship = null;

        public frmServiceReceiveReturn()
        {
            InitializeComponent();
            LoadNBind();
            // cmbBrand.SelectedIndexChanged += cmbBrand_SelectedIndexChanged;
            rdoVenNo.Checked = true;
            chkGroupUserInfo.Checked = true;
        }

        public frmServiceReceiveReturn(bool IsReceived)
            : this()
        {
            if (IsReceived)
            {
                cmbGiver.DropDownStyle = ComboBoxStyle.Simple;
              
                //cmbTaker.DataSource = dtEmployee;
                // Show employees just from Sales and Marketing departments
                List<Tuple<string, object>> queryBuilder = new List<Tuple<string, object>>();
                Tuple<string, object> tpSales = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                Tuple<string, object> tpMk = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                queryBuilder.Add(tpSales);
                queryBuilder.Add(tpMk);
                cmbTaker.DataSource = DataUtil.GetDataTableByOR(dtEmployee, queryBuilder);

                cmbTaker.DisplayMember = "EmpName";
                cmbTaker.ValueMember = "EmployeeID";
            }            
        }

        public frmServiceReceiveReturn(SalesService _saleService, ServiceBatteryStatus _serviceBatteryStatus, int ReturnToCustomer)
            : this()
        {
            this.salesService = _saleService;
            this._serviceStatus = _serviceBatteryStatus;

            salesService.IsReturned = true;
            DisableContol();
            cmbTaker.DropDownStyle = ComboBoxStyle.Simple;
            lblHeaderPCat.Text = ">    Service Return";
            this.Text = "Service Return";
            //cmbGiver.DataSource = dtEmployee;
            //cmbGiver.DisplayMember = "EmpName";
            //cmbGiver.ValueMember = "EmployeeID";
            groupBox1.Visible = false;
            rdoShowRoom.Visible = false;
            rdoVenNo.Visible = false;
            cmbWarehouseORVen.Visible = false;
            lblPurchasedDate.Visible = false;
            txtPurchasedDate.Visible = false;
            LoadNBindReturn();

            List<Tuple<string, object>> queryBuilder = new List<Tuple<string, object>>();
            Tuple<string, object> tpSales = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
            Tuple<string, object> tpMk = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
            queryBuilder.Add(tpSales);
            queryBuilder.Add(tpMk);
            cmbGiver.DataSource = DataUtil.GetDataTableByOR(dtEmployee, queryBuilder);

            cmbGiver.DisplayMember = "EmpName";
            cmbGiver.ValueMember = "EmployeeID";
        }

        #region Private Methods
        private void DisableContol()
        {
            dtpProductionDate.Enabled = false;
            cmbBrand.Enabled = false;
            cmbProduct.Enabled = false;
            cmbTaker.Enabled = false;
            cmbTown.Enabled = false;
            cmbTownship.Enabled = false;
            cmbWarehouseORVen.Enabled = false;
            rdoShowRoom.Enabled = false;
            rdoVenNo.Enabled = false;
            txtJobCardNo.Enabled = false;
            txtContactPerson.Enabled = false;
            txtPh1.Enabled = false;
            txtPh2.Enabled = false;
            txtPurchasedDate.Enabled = false;
            txtRouteTrip.Enabled = false;
            txtServiceNo.Enabled = false;
            txtTownTownship.Enabled = false;
            txtWarrantyNo.Enabled = false;
            
        }

        private void LoadNBind()
        {            
            try
            {                
                // Load Vehicles
                dtVen = new VehicleBL().GetAll();

                //  Load SubStore
                dtSubStore = new WarehouseBL().GetAllSubStore();

                //  Load Employee
                dtEmployee = new EmployeeBL().GetAll();

                // Load Product
                dtProduct = new ProductBL().GetAll();

                // Load Brand
                cmbBrand.DataSource = new BrandBL().GetOwnBrands();

                // Load Customers
                cmbCustomer.DataSource =this.dtCustomer = new CustomerBL().GetAll();
                cmbCustomer.DisplayMember = "CusName";
                cmbCustomer.ValueMember = "CustomerID";

                // Load Town
                cmbTown.DataSource = new TownBL().GetAll();

                // Load Township
                this.dtTownship = new TownshipBL().GetAll();                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void LoadNBindReturn()
        {
            dtpReceivedDate.Value = (DateTime)DataTypeParser.Parse(salesService.ReceivedDate, typeof(DateTime), DateTime.Now);
            cmbProduct.SelectedValue = (int)DataTypeParser.Parse(salesService.ProductID, typeof(int), -1);
            txtServiceNo.Text = (string)DataTypeParser.Parse(salesService.SalesServiceNo, typeof(string), String.Empty);
            txtJobCardNo.Text = (string)DataTypeParser.Parse(salesService.JobCardNo, typeof(string), String.Empty);
            txtWarrantyNo.Text = (string)DataTypeParser.Parse(salesService.WarrantyNo, typeof(string), String.Empty);

            DataTable dtServicedCustomer = new ServicedCustomerBL().GetAllBySvcCustomerID(salesService.ServicedCustomerID);
            if (dtServicedCustomer == null || dtServicedCustomer.Rows.Count < 1) return;
            if ((int)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["CustomerID"], typeof(int), -1) != -1)
            {
                cmbCustomer.SelectedValue = (int)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["CustomerID"], typeof(int), -1);
            }
            else
            {
                chkGroupUserInfo.Checked = false;
                cmbCustomer.Text = (string)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["UserName"], typeof(string), string.Empty);
                txtContactPerson.Text = (string)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["ContactPerson"], typeof(string), string.Empty);
                cmbTown.SelectedValue = (int)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["TownID"], typeof(int), -1);
                cmbTownship.SelectedValue = (int)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["TownshipID"], typeof(int), -1);
                txtPh1.Text = (string)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["Phone1"], typeof(string), string.Empty);
                txtPh2.Text = (string)DataTypeParser.Parse(dtServicedCustomer.Rows[0]["Phone2"], typeof(string), string.Empty);
            }
            //dtpProductionDate.Value = (DateTime)DataTypeParser.Parse(salesService.ProductionDate, typeof(DateTime), DateTime.Now);
           // dtpPurchasedDate.Value = (DateTime)DataTypeParser.Parse(salesService.PurchaseDate, typeof(DateTime), DateTime.Now);
            //txtUserName.Text = (string)DataTypeParser.Parse(salesService.UserName, typeof(string), String.Empty);
            //txtContactPerson.Text = (string)DataTypeParser.Parse(salesService.ContactPersion, typeof(string), String.Empty);
            //txtPh1.Text = (string)DataTypeParser.Parse(salesService.PhNo1, typeof(string), String.Empty);
            //txtPh2.Text = (string)DataTypeParser.Parse(salesService.PhNo2, typeof(string), String.Empty);
        }

        private void SaveSvcReceive()
        {
            if (rdoVenNo.Checked == true)
            {
                VenID = (int?)DataTypeParser.Parse(cmbWarehouseORVen.SelectedValue, typeof(int), null);
            }
            else
            {
                WarehouseID = (int)DataTypeParser.Parse(cmbWarehouseORVen.SelectedValue, typeof(int), null);
            }            
            int sup = 0;
            SalesServiceBL salesServiceSaver = null;
            try
            {
                salesServiceSaver = new SalesServiceBL();
                if (chkGroupUserInfo.Checked)
                {
                    salesService.ReceivedDate = (DateTime)DataTypeParser.Parse(dtpReceivedDate.Value, typeof(DateTime), null);
                    salesService.ProductionDate = (string)DataTypeParser.Parse(dtpProductionDate.Value, typeof(string), string.Empty);
                    salesService.PurchaseDate = (string)DataTypeParser.Parse(txtPurchasedDate.Text, typeof(string), String.Empty);
                    salesService.Giver = (string)DataTypeParser.Parse(cmbGiver.Text, typeof(string), null);
                    salesService.TakerID = (int?)DataTypeParser.Parse(cmbTaker.SelectedValue, typeof(int), null);
                    salesService.ProductID = (int)DataTypeParser.Parse(cmbProduct.SelectedValue, typeof(int), -1);
                    //salesService.CusID = (int?)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int),null);
                    //salesService.TownID = null;
                    //salesService.TownshipID = null;
                    //salesService.UserName = string.Empty;
                    //salesService.ContactPersion = string.Empty;
                    //salesService.PhNo1 = string.Empty;
                    //salesService.PhNo2 = string.Empty;
                    salesService.JobCardNo = (string)DataTypeParser.Parse(txtJobCardNo.Text, typeof(string), String.Empty);
                    salesService.WarrantyNo = (string)DataTypeParser.Parse(txtWarrantyNo.Text, typeof(string), null);

                    servicedCustomer.CustomerID = (int?)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), -1);
                    servicedCustomer.TownID = null;
                    servicedCustomer.TownshipID = null;
                    servicedCustomer.UserName = string.Empty;
                    servicedCustomer.ContactPerson = string.Empty;
                    servicedCustomer.Phone1 = string.Empty;
                    servicedCustomer.Phone2 = string.Empty;
                }
                else
                {
                    salesService.ReceivedDate = (DateTime)DataTypeParser.Parse(dtpReceivedDate.Value, typeof(DateTime), null);
                    salesService.ProductionDate = (string)DataTypeParser.Parse(dtpProductionDate.Value, typeof(string), string.Empty);
                    salesService.PurchaseDate = (string)DataTypeParser.Parse(txtPurchasedDate.Text, typeof(string), null);
                    salesService.Giver = (string)DataTypeParser.Parse(cmbGiver.Text, typeof(string), null);
                    salesService.TakerID = (int?)DataTypeParser.Parse(cmbTaker.SelectedValue, typeof(int), null);
                    salesService.ProductID = (int)DataTypeParser.Parse(cmbProduct.SelectedValue, typeof(int), -1);
                    //salesService.CusID = (int?)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), null);
                    //salesService.TownID = (int?)DataTypeParser.Parse(cmbTown.SelectedValue, typeof(int), null);
                    //salesService.TownshipID = (int?)DataTypeParser.Parse(cmbTownship.SelectedValue, typeof(int), null);
                    //salesService.UserName = (string)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(string), string.Empty);
                    //salesService.ContactPersion = (string)DataTypeParser.Parse(txtContactPerson.Text, typeof(string), null);
                    //salesService.PhNo1 = (string)DataTypeParser.Parse(txtPh1.Text, typeof(string), String.Empty);
                    //salesService.PhNo2 = (string)DataTypeParser.Parse(txtPh2.Text, typeof(string), null);
                    salesService.JobCardNo = (string)DataTypeParser.Parse(txtJobCardNo.Text, typeof(string), null);
                    salesService.WarrantyNo = (string)DataTypeParser.Parse(txtWarrantyNo.Text, typeof(string), null);
                  
                  servicedCustomer.CustomerID =null;
                  servicedCustomer.TownID = (int?)DataTypeParser.Parse(cmbTown.SelectedValue, typeof(int), null);
                  servicedCustomer.TownshipID = (int?)DataTypeParser.Parse(cmbTownship.SelectedValue, typeof(int), null);
                  servicedCustomer.UserName = (string)DataTypeParser.Parse(cmbCustomer.Text, typeof(string), string.Empty);
                  servicedCustomer.ContactPerson = (string)DataTypeParser.Parse(txtContactPerson.Text, typeof(string), null);
                  servicedCustomer.Phone1 = (string)DataTypeParser.Parse(txtPh1.Text, typeof(string), String.Empty);
                  servicedCustomer.Phone2 = (string)DataTypeParser.Parse(txtPh2.Text, typeof(string), null);                   
                }

                sup = salesServiceSaver.SalesServiceReceivedInsert(salesService, servicedCustomer, VenID, WarehouseID);
                // Check field validation failed or not
                if (!salesServiceSaver.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(salesServiceSaver.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else if (sup > 0) // Valid and successful
                {
                    this._occuredChanges = true;
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved, Color.Green);
                    this.Close();
                }
                else
                    MessageBox.Show(
                        Resource.errFailedToSave,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        ex.Message,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void SaveSvcReturn()
        {            
            int sup = 0;
            try
            {                
                salesService.ReturnedDate = (DateTime)DataTypeParser.Parse(dtpReceivedDate.Value, typeof(DateTime), DateTime.Now);
                salesService.IsBackward = true;
                salesService.GiverID = (int?)DataTypeParser.Parse(cmbGiver.SelectedValue, typeof(int), 0);
                sup = new SalesServiceBL().SalesServiceTransferReturnInsert(
                    salesService, _serviceStatus, null, null, 
                    GlobalCache.LoginUser.EmpID,
                    (int)PTIC.Common.Enum.SalesServiceWhereami.Customer);

                if (sup > 0)
                {
                    this._occuredChanges = true;
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved, Color.Green);
                    this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (salesService.IsReturned) // Service Return
                SaveSvcReturn();
            else
                SaveSvcReceive(); // Service Receive
        }

        private void rdoVenNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoVenNo.Checked == true)
            {
                if (dtVen.Rows.Count > 0)
                {
                    cmbWarehouseORVen.DataSource = dtVen;
                    cmbWarehouseORVen.ValueMember = "VehicleID";
                    cmbWarehouseORVen.DisplayMember = "VenNo";
                }
            }
        }

        private void rdoShowRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoShowRoom.Checked == true)
            {
                if (dtSubStore.Rows.Count > 0)
                {
                    cmbWarehouseORVen.DataSource = dtSubStore;
                    cmbWarehouseORVen.ValueMember = "ID";
                    cmbWarehouseORVen.DisplayMember = "Warehouse";
                }
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmServicePages));
            this.Close();
        }

        public void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            int brandID = (int)DataTypeParser.Parse(cmbBrand.SelectedValue, typeof(int), 0);
            if (brandID < 1)
                return;
            DataTable dtResultProducts = DataUtil.GetDataTableBy(this.dtProduct, "BrandID", brandID);
            cmbProduct.DataSource = dtResultProducts;
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
        }
       
        /// <summary>
        /// 
        /// </summary>
        private void ClearValues()
        {
            // clear field values
            txtContactPerson.Text = string.Empty;
            txtPh1.Text = string.Empty;
            txtPh2.Text = string.Empty;
            txtTownTownship.Text = String.Empty;
            txtRouteTrip.Text = String.Empty;
           cmbTown.SelectedIndex = -1;
            cmbTownship.SelectedIndex = -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedCustomer"></param>
        private void SetValuesBySelectedCustomer(DataRowView selectedCustomer)
        {
            string contactPerson = (string)DataTypeParser.Parse(selectedCustomer["ConPersonName"], typeof(string), string.Empty);
            string Phone1 = (string)DataTypeParser.Parse(selectedCustomer["Phone1"], typeof(string), string.Empty);
            string MobilePhone = (string)DataTypeParser.Parse(selectedCustomer["MobilePhone"], typeof(string), String.Empty);
            string Township = (string)DataTypeParser.Parse(selectedCustomer["Township"], typeof(string), String.Empty);
            string Town = (string)DataTypeParser.Parse(selectedCustomer["Town"], typeof(string), String.Empty);
            string Route = (string)DataTypeParser.Parse(selectedCustomer["RouteName"], typeof(string), String.Empty);
            string Trip = (string)DataTypeParser.Parse(selectedCustomer["TripName"], typeof(string), String.Empty);

            if (Township == String.Empty || Route == String.Empty)
            {
                txtTownTownship.Text = Town;
                txtRouteTrip.Text = Trip;
            }
            else
            {
                txtTownTownship.Text = Township;
                txtRouteTrip.Text = Route;
            }
            // set field values
            txtContactPerson.Text = contactPerson;
            txtPh1.Text = Phone1;
            txtPh2.Text = MobilePhone;

            //txtContactPerson.Text = contactPerson;
            //txtRoute.Text = route;
            //txtTrip.Text = trip;
            //txtCreditLimitAmt.Text = creditLimitAmt.ToString("N0");
        }
       
        private void cmbCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            DataRowView selectedCustomerRow = cmb.SelectedItem as DataRowView;
            ClearValues();
            if (selectedCustomerRow == null)
            {
                return;
            }
            SetValuesBySelectedCustomer(selectedCustomerRow);  
        }

        private void chkGroupUserInfo_CheckedChanged(object sender, EventArgs e)
        {
            ClearValues();
            if (chkGroupUserInfo.Checked)
            {
                chkGroupUserInfo.Text = "OutletUser Info";
                cmbCustomer.DropDownStyle = ComboBoxStyle.DropDown;
                cmbTown.Visible = false;
                cmbTownship.Visible = false;
                txtContactPerson.Enabled = false;
                txtPh1.Enabled = false;
                txtPh2.Enabled = false;
                txtRouteTrip.Enabled = false;
                txtTownTownship.Enabled = false;
                lblTripRouteORTown.Text = "လမ်းကြောင်း / ခရီးစဉ်";
                lblTownTownship.Text = "မြို့ / မြို့နယ်";
               
            }
            else
            {
                chkGroupUserInfo.Text = "EndUser Info";
                cmbCustomer.SelectedIndex = -1;
                cmbCustomer.DropDownStyle = ComboBoxStyle.Simple;
                cmbTown.Enabled = true;
                cmbTownship.Enabled = true;
                lblTripRouteORTown.Text = "မြို့";
                lblTownTownship.Text = "မြို့နယ်";
                cmbTown.Visible = true;
                cmbTownship.Visible = true;
                txtContactPerson.Enabled = true;
                txtPh1.Enabled = true;
                txtPh2.Enabled = true;
                lblPh1.Enabled = true;
                lblPh2.Enabled = true;
                lblPurchasedDate.Enabled = true;
                lblTacker.Enabled = true;
                lblUserName.Enabled = true;
                lblGiver.Enabled = true;
                lblTownTownship.Enabled = true;
                lblTripRouteORTown.Enabled = true;
                lblContactPerson.Enabled = true;
                txtPurchasedDate.Enabled = true;
            }
        }

        private void cmbTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TownID = (int)DataTypeParser.Parse(cmbTown.SelectedValue,typeof(int),-1);
            DataTable dtTmpTownship = DataUtil.GetDataTableBy(this.dtTownship, "TownID", TownID);
            if (dtTmpTownship != null)
            {
                cmbTownship.DataSource = dtTmpTownship;
                cmbTownship.Enabled = true;
            }
            else
            {
                cmbTownship.Enabled = false;
                cmbTownship.SelectedIndex = -1;
            }
        }

        #region Inner Classes
        public class ServiceReceivedReturnedEventArgs : EventArgs 
        {
            private bool _occuredChanges;
            public ServiceReceivedReturnedEventArgs(bool occuredChanges)
            {
                this._occuredChanges = occuredChanges;
            }
            public bool OccuredChanges
            {
                get { return this._occuredChanges; }
            }
        }            
        #endregion

        private void frmServiceReceiveReturn_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.ServiceReceivedReturnedHandler == null)
                return;
            ServiceReceivedReturnedEventArgs eArg = new ServiceReceivedReturnedEventArgs(this._occuredChanges);
            ServiceReceivedReturnedHandler(this, eArg);
        }


    }
}

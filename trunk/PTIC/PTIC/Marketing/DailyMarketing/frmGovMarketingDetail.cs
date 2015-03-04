/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/03/28 (yyyy/MM/dd)
 * Description: Government Marketing Detail form
 */
using System;using PTIC.Common;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.Common.BL;
using PTIC.Marketing.DailyMarketing;
using PTIC.Sale.Order;
using PTIC.Util;
using PTIC.Sale.BL;
using PTIC.Sale.Entities;

namespace PTIC.VC.Marketing.DailyMarketing
{
    public partial class frmGovMarketingDetail : Form
    {
        /// <summary>
        /// Logger for frmGovMarketingDetail
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmGovMarketingDetail));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void GovMarketingDetailSaveHandler(object sender, GovMarketingDetailSaveEventArgs e);
        
        /// <summary>
        /// 
        /// </summary>
        public event GovMarketingDetailSaveHandler GovMarketingDetailSavedHandler;

        /// <summary>
        /// 
        /// </summary>
        private GovernmentMarketingDetail _governmentMarketingDetail = null;

        //private Address _address = null;
        private Township _township = null;

        /// <summary>
        /// Flag indicating frmDailyMarketingDetail form should be closed after saved
        /// </summary>
        private bool _needToClose = false;

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Need to close this form after saved
            _needToClose = true;
            Save();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            //frmOrder orderForm = new frmOrder(_governmentMarketingDetail.OrderID);
            frmOrder orderForm = new frmOrder(_governmentMarketingDetail.OrderID, _governmentMarketingDetail.CusID, _township);
            // set call back handler
            orderForm.OrderSavedHandler += new frmOrder.OrderSaveHandler(OrderSave_CallBack);
            UIManager.OpenForm(orderForm);
        }

        private void btnTender_Click(object sender, EventArgs e)
        {
            GovernmentMarketingDetail govMkDetail = new GovernmentMarketingDetail();
            govMkDetail.ID = (int)DataTypeParser.Parse(this._governmentMarketingDetail.ID, typeof(int), -1);
            govMkDetail.TenderInfoID = (int)DataTypeParser.Parse(this._governmentMarketingDetail.TenderInfoID, typeof(int), -1);
            //govMkDetail.MinistryName = (string)DataTypeParser.Parse(txtMinistry.Text.Trim(), typeof(string), string.Empty);
            govMkDetail.Department = (string)DataTypeParser.Parse(txtMinistryDept.Text.Trim(), typeof(string), string.Empty);
            //govMkDetail.ContactPerson = (string)DataTypeParser.Parse(txtContactPerson.Text.Trim(), typeof(string), string.Empty);

            string customerName = cmbCustomer.Text;
            string contactPersonName = txtContactPerson.Text;
            //frmGovTenderInfo tenderForm = new frmGovTenderInfo(_governmentMarketingDetail, customerName, contactPersonName);
            frmGovTenderInfo tenderForm = new frmGovTenderInfo(govMkDetail, customerName, contactPersonName);
            tenderForm.TenderSavedHandler += new frmGovTenderInfo.TenderSaveHandler(TenderSave_CallBack);
            UIManager.OpenForm(tenderForm);
            
        }

        /// <summary>
        /// When user click Service button, Service Detail form is appeared with data if data already exists. If data not yet exists, only show government
        /// marketing data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnService_Click(object sender, EventArgs e)
        {
            GovernmentMarketingDetail govMkDetail = new GovernmentMarketingDetail();
            govMkDetail.ID = (int)DataTypeParser.Parse(this._governmentMarketingDetail.ID, typeof(int), -1);
            govMkDetail.ServiceID = (int?)DataTypeParser.Parse(this._governmentMarketingDetail.ServiceID, typeof(int), null);
            //govMkDetail.MinistryName = (string)DataTypeParser.Parse(txtMinistry.Text.Trim(), typeof(string), string.Empty);
            govMkDetail.CusID = (int)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), 0);
            govMkDetail.Department = (string)DataTypeParser.Parse(txtMinistryDept.Text.Trim(), typeof(string), string.Empty);
            //govMkDetail.ContactPerson = (string)DataTypeParser.Parse(txtContactPerson.Text.Trim(), typeof(string), string.Empty);
            govMkDetail.OrderID = (int?)DataTypeParser.Parse(this._governmentMarketingDetail.OrderID, typeof(int), null);

            string customerName = cmbCustomer.Text;
            ContactPerson contactPerson = new ContactPerson() 
            {
                ContactPersonName = txtContactPerson.Text,
                Post = txtContactPosition.Text,
                MobilePhone = txtContactPhone.Text
            };
            frmGovServiceDetail serviceForm = new frmGovServiceDetail(govMkDetail, customerName, contactPerson);
            serviceForm.serviceSavedHandler += new frmGovServiceDetail.ServiceSaveHandler(ServiceSave_CallBack);

            UIManager.OpenForm(serviceForm);

            //if (_governmentMarketingDetail.ServiceID > 0)
            //{
            //    frmGovServiceDetail serviceForm = new frmGovServiceDetail(govMkDetail);
            //    serviceForm.serviceSavedHandler += new frmGovServiceDetail.ServiceSaveHandler(ServiceSave_CallBack);

            //    UIManager.OpenForm(serviceForm);
            //}
            //else
            //{
            //    if (string.Empty != govMkDetail.Department)
            //    {
            //        frmGovServiceDetail serviceForm = new frmGovServiceDetail(govMkDetail);

            //        serviceForm.serviceSavedHandler += new frmGovServiceDetail.ServiceSaveHandler(ServiceSave_CallBack);
            //        UIManager.OpenForm(serviceForm);
            //    }
            //}

        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmDailyMarketingPage));
            this.Close();
        }

        private void cmbCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            DataRowView selectedCustomerRow = cmb.SelectedItem as DataRowView;
            ClearValues();
            if (selectedCustomerRow == null)
                return;

            SetValuesBySelectedCustomer(selectedCustomerRow);
        }

        private void OrderSave_CallBack(object sender, frmOrder.OrderSaveEventArgs e)
        {
            if (e.OrderID.HasValue) // If order id has been created
            {
                // Set order id to be refered by GovMarketingDetail
                _governmentMarketingDetail.OrderID = e.OrderID;
                // No need to close this form after saved
                _needToClose = false;
                // Save GovMarketingDetail
                Save();
            }
        }

        private void TenderSave_CallBack(object sender, frmGovTenderInfo.TenderSaveEventArgs e)
        {
            if (e.TenderInfoID.HasValue) // If tender id has been created
            {
                // Set tender id to be refered by GovMarketingDetail
                _governmentMarketingDetail.TenderInfoID = e.TenderInfoID;
                // No need to close this form after saved
                _needToClose = false;
                // Save GovMarketingDetail
                Save();
            }
        }

        private void ServiceSave_CallBack(object sender, frmGovServiceDetail.ServiceSaveEventArgs e)
        {
            if (e.ServiceID.HasValue) // If tender id has been created
            {
                // Set tender id to be refered by GovMarketingDetail
                _governmentMarketingDetail.ServiceID = e.ServiceID;
                // No need to close this form after saved
                _needToClose = false;
                // Save GovMarketingDetail
                Save();
            }
        }
        #endregion

        #region Private Methods
        private void Save()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                int? affectedRow = null;
                GovernmentMarketingDetailBL detailSaver = new GovernmentMarketingDetailBL();
                GovernmentMarketingDetail govMkDetail = new GovernmentMarketingDetail() 
                {
                    ID = this._governmentMarketingDetail.ID,
                    MarketingPlanID = this._governmentMarketingDetail.MarketingPlanID,
                    CusID = this._governmentMarketingDetail.CusID,
                    //MinistryName = txtMinistry.Text,
                    Department = txtMinistryDept.Text,
                    //ContactPerson = txtContactPerson.Text,
                    //Position = txtContactPosition.Text,
                    //ContactPhone = txtContactPhone.Text,
                    Matter = cmbCase.Text,
                    Date = dtpDate.Value,
                    Address = txtAddress.Text,
                    Phone1 = txtPhone1.Text,
                    Phone2 = txtPhone2.Text,
                    EmpID = (int)DataTypeParser.Parse(cmbEmployee.SelectedValue, typeof(int), -1),
                    VenID = (int)DataTypeParser.Parse(cmbVehicle.SelectedValue, typeof(int), -1),
                    Remark = txtRemark.Text,
                    ServiceID = this._governmentMarketingDetail.ServiceID,
                    OrderID = this._governmentMarketingDetail.OrderID,
                    TenderInfoID = this._governmentMarketingDetail.TenderInfoID
                };

                if (govMkDetail.VenID == -1)
                {
                    MessageBox.Show("Please specify a vehicle no!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Save a government marketing detail
                if (govMkDetail.ID.HasValue) // an existing detail
                {
                    // Update
                    affectedRow = detailSaver.UpdateByGovDetailID(govMkDetail, conn);
                }
                else // New detail
                {
                    this._governmentMarketingDetail.ID = affectedRow = detailSaver.Add(govMkDetail, conn);
                }
                if (affectedRow > 0)
                {
                    // If a caller exists
                    if (GovMarketingDetailSavedHandler != null)
                    {
                        // return value to sender
                        GovMarketingDetailSaveEventArgs govMarketingDetailSaveEventArg = new GovMarketingDetailSaveEventArgs(true);
                        GovMarketingDetailSavedHandler(this, govMarketingDetailSaveEventArg);
                    }

                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    if (this._needToClose)
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
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void SetValuesBySelectedCustomer(DataRowView selectedCustomer)
        {
            // Set contact info
            string contactPersonName = (string)DataTypeParser.Parse(selectedCustomer["ConPersonName"], typeof(string), string.Empty);
            string contactPersonPosition = (string)DataTypeParser.Parse(selectedCustomer["Post"], typeof(string), string.Empty);
            string contactPersonPhone = (string)DataTypeParser.Parse(selectedCustomer["MobilePhone"], typeof(string), string.Empty);
            txtContactPerson.Text = contactPersonName;
            txtContactPosition.Text = contactPersonPosition;
            txtContactPhone.Text = contactPersonPhone;
            // Set phone no
            txtPhone1.Text = (string)DataTypeParser.Parse(selectedCustomer["Phone1"], typeof(string), string.Empty);
            txtPhone2.Text = (string)DataTypeParser.Parse(selectedCustomer["Phone2"], typeof(string), string.Empty);

            // Set address
            string address = string.Empty;
            // No            
            address += string.IsNullOrEmpty(selectedCustomer["Hno"].ToString()) ? string.Empty : selectedCustomer["Hno"].ToString() + ", ";
            // Street
            address += string.IsNullOrEmpty(selectedCustomer["Street"].ToString()) ? string.Empty : selectedCustomer["Street"].ToString() + ", ";
            // Quarter
            address += string.IsNullOrEmpty(selectedCustomer["Quartar"].ToString()) ? string.Empty : selectedCustomer["Quartar"].ToString() + ", ";
            // Township
            address += string.IsNullOrEmpty(selectedCustomer["Township"].ToString()) ? string.Empty : selectedCustomer["Township"].ToString() + ", ";
            // Town
            address += string.IsNullOrEmpty(selectedCustomer["Town"].ToString()) ? string.Empty : selectedCustomer["Town"].ToString() + ", ";
            // State / Division
            address += string.IsNullOrEmpty(selectedCustomer["StateDivisionName"].ToString()) ? string.Empty : selectedCustomer["StateDivisionName"].ToString() + ", ";

            txtAddress.Text = address;

            // Set customer id
            if (this._governmentMarketingDetail == null)
                this._governmentMarketingDetail = new GovernmentMarketingDetail();
            this._governmentMarketingDetail.CusID = (int)DataTypeParser.Parse(selectedCustomer["CustomerID"], typeof(int), -1);

            // Set town id and township id
            if(this._township == null)
                this._township = new Township();
            this._township.TownID = (int)DataTypeParser.Parse(selectedCustomer["TownID"], typeof(int), -1);
            this._township.TownshipID = (int)DataTypeParser.Parse(selectedCustomer["TownshipID"], typeof(int), -1);
        }

        private void ClearValues()
        {
            txtContactPerson.Text = string.Empty;
            txtContactPosition.Text = string.Empty;
            txtContactPhone.Text = string.Empty;
        }

        /// <summary>
        /// Load and bind necessary data
        /// </summary>
        private void LoadNBind()
        {            
            try
            {                
                // Load employee
                DataTable employeeTbl = new EmployeeBL().GetAll();

                DataTable dtEmployeesByDept = null;
                if (GlobalCache.is_sale == false)
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(employeeTbl, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                }
                else
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(employeeTbl, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                }
                cmbEmployee.ValueMember = "EmployeeID";
                cmbEmployee.DisplayMember = "EmpName";

                // Load vehicle
                cmbVehicle.DataSource = new VehicleBL().GetAll();
                // Load just government customer
                cmbCustomer.DataSource = 
                    DataUtil.GetDataTableBy(new CustomerBL().GetAll(), "CusType", (int)PTIC.Common.Enum.CustomerType.Government);
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
            }            
        }

        private void SetValues(GovernmentMarketingDetail govMkDetailVal)
        { 
            //txtMinistry.Text = govMkDetailVal.MinistryName;
            cmbCustomer.SelectedValue = govMkDetailVal.CusID;
            txtMinistryDept.Text = govMkDetailVal.Department;
            //txtContactPerson.Text = govMkDetailVal.ContactPerson;
            //txtContactPosition.Text = govMkDetailVal.Position;
            //txtContactPhone.Text = govMkDetailVal.ContactPhone;
            cmbCase.Text = govMkDetailVal.Matter;
            dtpDate.Value = govMkDetailVal.Date;
            //txtAddress.Text = govMkDetailVal.Address;
            //txtPhone1.Text = govMkDetailVal.Phone1;
            //txtPhone2.Text = govMkDetailVal.Phone2;
            if (govMkDetailVal.EmpID > -1)
                cmbEmployee.SelectedValue = govMkDetailVal.EmpID;
            if (govMkDetailVal.VenID > -1)
                cmbVehicle.SelectedValue = govMkDetailVal.VenID;
            //cmbCustomer.SelectedValue = govMkDetailVal.CusID;
            txtRemark.Text = govMkDetailVal.Remark;
        }
        #endregion

        #region Constructors
        public frmGovMarketingDetail()
        {
            InitializeComponent();
            // Load and bind necessary data
            LoadNBind();
            if (cmbEmployee.Items.Count > 0)
                cmbEmployee.SelectedIndex = 0;
            if (cmbVehicle.Items.Count > 0)
                cmbVehicle.SelectedIndex = 0;
            // Instantiate GovernmentMarketingDetail that represent this detail
            if (this._governmentMarketingDetail == null)
                this._governmentMarketingDetail = new GovernmentMarketingDetail();
        }

        public frmGovMarketingDetail(GovernmentMarketingDetail govMkDetail, Township township) : this()
        {
            this._governmentMarketingDetail = govMkDetail;
            this._township = township;
            SetValues(this._governmentMarketingDetail);
        }
        #endregion

        #region Inner Class
        public class GovMarketingDetailSaveEventArgs : EventArgs
        {
            private bool _occuredChanges = false;
            public GovMarketingDetailSaveEventArgs(bool occuredChanges)
            {
                this._occuredChanges = occuredChanges;
            }
            public bool OccuredChanges
            {
                get { return this._occuredChanges; }
            }
        }
        #endregion
                        
    }
}

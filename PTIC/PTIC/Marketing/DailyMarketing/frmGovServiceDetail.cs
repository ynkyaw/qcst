using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using PTIC.Common.BL;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using PTIC.Sale.BL;
using PTIC.Sale.Entities;
using PTIC.Util;
using PTIC.VC;
using PTIC.VC.Util;

namespace PTIC.Marketing.DailyMarketing
{
    public partial class frmGovServiceDetail : Form
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmGovServiceDetail));
        
        public delegate void ServiceSaveHandler(object sender, ServiceSaveEventArgs e);
        
        public event ServiceSaveHandler serviceSavedHandler;

        private GovernmentMarketingDetail _govMkDetail;

        private MobileServiceDetail _service = null;

        private ServiceDetail _serviceDetail = null;

        private bool _needToClose = false;

        /// <summary>
        /// Index of Brand column from DataGridView
        /// </summary>
        private int _indexBrandColumn = -1;

        /// <summary>
        /// Index of Product column from DataGridView
        /// </summary>
        private int _indexProductColumn = -1;

        /// <summary>
        /// Record table for different Proudcts
        /// </summary>
        private DataTable _dtProduct = null;

        /// <summary>
        /// ComboBox shown in grid column Product
        /// </summary>
        private ComboBox _cmbProduct = null;

        private int cust_ID = 0;

        public frmGovServiceDetail()
        {
            InitializeComponent();
            dgvServiceRecord.AutoGenerateColumns = false;
            _service = new MobileServiceDetail();
            _serviceDetail = new ServiceDetail();
            this._indexBrandColumn = dgvServiceRecord.Columns.IndexOf(dgvServiceRecord.Columns["colBrand"]);
            this._indexProductColumn = dgvServiceRecord.Columns.IndexOf(dgvServiceRecord.Columns["colProduct"]);
            LoadNBind();
            DataUtil.AddInitialNewRow(dgvServiceRecord);
        }
       
        public frmGovServiceDetail(
            GovernmentMarketingDetail govMkDetail, string customerName, ContactPerson contactPerson)
        {
            InitializeComponent();
            dgvServiceRecord.AutoGenerateColumns = false;
            _service = new MobileServiceDetail();
            _serviceDetail = new ServiceDetail();

            txtMinistry.Text = customerName;
            txtContactPerson.Text = contactPerson.ContactPersonName;
            txtPost.Text = contactPerson.Post;
            txtContactPersonPhNo.Text = contactPerson.MobilePhone;

            if (govMkDetail.ServiceID != null)
            {
                _service.ID = (int?)DataTypeParser.Parse(govMkDetail.ServiceID, typeof(int), null);
                _serviceDetail.ServiceID = (int)DataTypeParser.Parse(govMkDetail.ServiceID, typeof(int), -1);
                _service.ServicePlanID = null;
                _service.OrderID = govMkDetail.OrderID;
                FillServiceDetail(govMkDetail.ServiceID);
            }
            this._govMkDetail = govMkDetail;
            FillNSetReadOnly();
           // gridComboBind();
                        
            this._indexBrandColumn = dgvServiceRecord.Columns.IndexOf(dgvServiceRecord.Columns["colBrand"]);
            this._indexProductColumn = dgvServiceRecord.Columns.IndexOf(dgvServiceRecord.Columns["colProduct"]);
            LoadNBind();
            this.cust_ID = govMkDetail.CusID;
            try
            {
                LoadNBindMobileServiceRecords(this._govMkDetail.ServiceID);
                DataUtil.AddInitialNewRow(dgvServiceRecord);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        private void LoadNBindMobileServiceRecords(int? mobileServiceDetailID)
        {         
            dgvServiceRecord.DataSource = new MobileServiceRecordBL().GetByMobileServiceDetailID(mobileServiceDetailID);
        }

        private void FillNSetReadOnly()
        {
            // txtServiceNo.Text = govMkDetail.ServiceID;
            //txtContactPerson.Text = govMkDetail.ContactPerson;
            // txtServicePlanNo.Text = govMkDetail.ServiceID;
            //txtPost.Text = govMkDetail.Position;

            txtDeptName.Text = _govMkDetail.Department;

            cmbEmployee.SelectedValue = _govMkDetail.EmpID;
            cmbVehicle.SelectedValue = _govMkDetail.VenID;
          
            txtServiceNo.ReadOnly = true;
            txtContactPerson.ReadOnly = true;
            txtServicePlanNo.ReadOnly = true;
            txtPost.ReadOnly = true;
        }

        private void FillServiceDetail(int? serviceID)
        {
            try
            {
                DataTable dtServiceDetail = new MobileServiceDetailBL().GetByMobileServiceDetailID((int)serviceID);
                if (dtServiceDetail != null && dtServiceDetail.Rows.Count==1)
                {
                    txtSugForUsage.Text =(string) DataTypeParser.Parse(dtServiceDetail.Rows[0]["SugForUsage"],typeof(string),string.Empty);
                    txtResonNotService.Text =(string) DataTypeParser.Parse( dtServiceDetail.Rows[0]["ResonNotService"],typeof(string),string.Empty);
                    dtpAppointedDate.Value = (DateTime)DataTypeParser.Parse(dtServiceDetail.Rows[0]["AppointedDate"], typeof(DateTime), DateTime.Now);
                    dtpServiceDate.Value = (DateTime)DataTypeParser.Parse(dtServiceDetail.Rows[0]["ServicedDate"], typeof(DateTime), DateTime.Now);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
            }
        }

        private void LoadandBindByserviceID(int? serviceID)
        {
            try
            {
                int tenderID = (int)DataTypeParser.Parse(serviceID, typeof(int), -1);
                DataTable TblService = new ServiceBL().GetByServiceID(serviceID);
                if (TblService.Rows.Count == 1)
                {
                    DataRow drService = TblService.Rows[0];
                    txtServiceNo.Text = drService["ServiceNo"].ToString();
                    txtServicePlanNo.Text = drService["ServicePlanNo"].ToString();
                    txtSugForUsage.Text = "";
                    txtContactPerson.Text = drService["SalesPersonID"].ToString();
                    txtContactPersonPhNo.Text = "";
                    txtPost.Text = "";
                    txtResonNotService.Text = "";
                    dtpAppointedDate.Value = Convert.ToDateTime(drService["ServiceRecDate"]); 
                   // cmbCustomer.SelectedValue =(int)DataTypeParser.Parse(drService["CusID"].ToString(),typeof(int),0);
                    cmbEmployee.SelectedValue = 0;
                    cmbVehicle.SelectedValue = (int)DataTypeParser.Parse(drService["VenID"].ToString(), typeof(int), 0);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
            }
        }
        public frmGovServiceDetail(MobileServiceDetail service, string servicePlanNo)
            :this()
        {
            dgvServiceRecord.AutoGenerateColumns = false;
            // Set ServicePlanNo
            txtServicePlanNo.Text = servicePlanNo;
            this._service = service;
            // Load by MobileServiceDetail By ID
            LoadNBindByServiceID(service.ID);
            this.cust_ID = service.CusID;
        }

        #region Private Methods
        private void LoadNBindByServiceID(int? ServiceID)
        {
            try
            {
                if (ServiceID.HasValue)
                {
                    DataTable dtService = new ServiceBL().GetByServiceID(ServiceID.Value);
                    if (dtService.Rows.Count > 0)
                    {
                        // TODO:
                        // Set value to fields

                        // Load Mobile service records

                    }

                    //cmbBrand.SelectedValue = (int)DataTypeParser.Parse(dtDetail.Rows[0]["BrandID"], typeof(int), -1);
                    //dtpMarketedDate.Value = (DateTime)DataTypeParser.Parse(dtDetail.Rows[0]["MarketedDate"], typeof(DateTime), DateTime.Now);
                    //_marketingDetail.OrderID = (int?)DataTypeParser.Parse(dtDetail.Rows[0]["OrderID"], typeof(int), null);
                    //_marketingDetail.A_P_UsageID = (int?)DataTypeParser.Parse(dtDetail.Rows[0]["A_P_UsageID"], typeof(int), null);
                    //_marketingDetail.CustomerComplaintID = (int?)DataTypeParser.Parse(dtDetail.Rows[0]["CustomerComplaintID"], typeof(int), null);
                    //_marketingDetail.CompetitorActivityID = (int?)DataTypeParser.Parse(dtDetail.Rows[0]["CompetitorActivityID"], typeof(int), null);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        #endregion

        #region Inner Class
        public class ServiceDetailSaveEventArgs : EventArgs
        {
            private bool _occuredChanges = false;

            public ServiceDetailSaveEventArgs(bool occuredChanges)
            {
                this._occuredChanges = occuredChanges;
            }
            public bool OccuredChanges
            {
                get { return this._occuredChanges; }
            }
        }

        public class ServiceSaveEventArgs : EventArgs
        {
            private int? _ServiceID = null;
            public ServiceSaveEventArgs(int? ServiceID)
            {
                this._ServiceID = ServiceID;
             // Testing Data
              //  this._ServiceID = 3;
            }
            public int? ServiceID
            {
                get { return this._ServiceID; }
            }
        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Delete the whole MobileSerivceDetail
            if (MessageBox.Show(Resource.qstSureToDeleteMobileServiceDetail, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.No)
                return;
            if (!this._service.ID.HasValue)
            {
                this.Close();
                return;
            }
            DeleteServiceDetail(_service.ID);
        }

        private void DeleteServiceDetail(int? _mobileServiceDetailID)
        {
            int affectedRow = 0;
            try
            {
                int msDetailID = (int)DataTypeParser.Parse(_mobileServiceDetailID, typeof(int), -1);
                affectedRow = new MobileServiceDetailBL().DeleteByMobileServiceDetailID(msDetailID);

                if (affectedRow > 0)
                {
                    this.Close();
                    // Show successful message
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved, Color.Green);
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Need to close this form after saved
            _needToClose = true;
            // Save Mobile Service Detail
            Save();
        }

        private void Save()
        {
            MobileServiceDetailBL msServiceSaver = null;
            //ServiceDetailBL msDetailSaver = null;
            MobileServiceRecordBL msRecordSaver = null;
            MobileServiceDetail msService = null;
            try
            {
                msService = new MobileServiceDetail()
                {
                    ID = _service.ID,
                  //  ServicePlanID = _service.ServicePlanID,
                    ServicePlanID = null,
                    OrderID = _service.OrderID,
                    ServiceNo = txtServiceNo.Text,
                    CusID = this.cust_ID,            
                    EmpID = (int)DataTypeParser.Parse(cmbEmployee.SelectedValue, typeof(int), -1),
                    ServicedDate = dtpServiceDate.Value,
                    //IsCustomer =
                    SugForUsage = txtSugForUsage.Text,
                    ResonNotService = txtResonNotService.Text,
                    AppointedDate = dtpAppointedDate.Value
                };
                int? affectedRows = null;
                msServiceSaver = new MobileServiceDetailBL();
                msRecordSaver = new MobileServiceRecordBL();
                if (_service.ID.HasValue) // An existing  service 
                {
                    // Set ServiceID
                   msService.ID = (int)DataTypeParser.Parse(_service.ID, typeof(int), null);
                    // Update mobile service detail (master)
                    affectedRows = msServiceSaver.UpdateByMobileServiceDetailID(msService);

                    DataTable dt = dgvServiceRecord.DataSource as DataTable;
                    if (dt == null || dt.Rows.Count < 1) // If mobile service record(s) are not present, no work for it
                    {
                        goto Status;
                    }
                    // New Mobile Service Record
                    DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                    foreach (DataRow row in dvInsert.ToTable().Rows)
                    {
                        MobileServiceRecord newMobileServiceRecord = new MobileServiceRecord()
                        {
                           //MSuvDetailID = (int)DataTypeParser.Parse(row["MSuvDetailID"], typeof(int), -1),
                            MSuvDetailID = (int)DataTypeParser.Parse(_service.ID, typeof(int), -1),
                            //BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                            //ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                            UsedPlace = (string)DataTypeParser.Parse(row["UsedPlace"], typeof(string), string.Empty),
                            MachineNo = (string)DataTypeParser.Parse(row["MachineNo"], typeof(string), string.Empty),
                            ProductionDate = (string)DataTypeParser.Parse(row["ProductionDate"], typeof(string), string.Empty),
                            Volt = (int)DataTypeParser.Parse(row["Volt"], typeof(int), 0),
                            ChargingAmp = (float)DataTypeParser.Parse(row["ChargingAmp"], typeof(float), 0),
                            OutAmp = (float)DataTypeParser.Parse(row["OutAmp"], typeof(float), 0),
                            Acid1 = (float)DataTypeParser.Parse(row["Acid1"], typeof(float), 0),
                            Acid2 = (float)DataTypeParser.Parse(row["Acid2"], typeof(float), 0),
                            Acid3 = (float)DataTypeParser.Parse(row["Acid3"], typeof(float), 0),
                            Acid4 = (float)DataTypeParser.Parse(row["Acid4"], typeof(float), 0),
                            Acid5 = (float)DataTypeParser.Parse(row["Acid5"], typeof(float), 0),
                            Acid6 = (float)DataTypeParser.Parse(row["Acid6"], typeof(float), 0),
                            Serving = (string)DataTypeParser.Parse(row["Serving"], typeof(string), string.Empty)
                        };
                        // Insert service record into database
                        affectedRows += msRecordSaver.Add(newMobileServiceRecord);
                    }

                    // Existing Mobile Service Record
                    DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                    foreach (DataRow row in dvUpdate.ToTable().Rows)
                    {
                        MobileServiceRecord mdMobileServiceRecord = new MobileServiceRecord()
                        {
                            ID = (int)DataTypeParser.Parse(row["MobileServiceRecordID"], typeof(int), -1),
                           // MSuvDetailID = (int)DataTypeParser.Parse(row["MSuvDetailID"], typeof(int), -1),
                            MSuvDetailID = (int)DataTypeParser.Parse(_service.ID, typeof(int), -1),
                            //BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                            //ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                            UsedPlace = (string)DataTypeParser.Parse(row["UsedPlace"], typeof(string), string.Empty),
                            MachineNo = (string)DataTypeParser.Parse(row["MachineNo"], typeof(string), string.Empty),
                            ProductionDate = (string)DataTypeParser.Parse(row["ProductionDate"], typeof(string), string.Empty),
                            Volt = (int)DataTypeParser.Parse(row["Volt"], typeof(int), 0),
                            ChargingAmp = (float)DataTypeParser.Parse(row["ChargingAmp"], typeof(float), 0),
                            OutAmp = (float)DataTypeParser.Parse(row["OutAmp"], typeof(float), 0),
                            Acid1 = (float)DataTypeParser.Parse(row["Acid1"], typeof(float), 0),
                            Acid2 = (float)DataTypeParser.Parse(row["Acid2"], typeof(float), 0),
                            Acid3 = (float)DataTypeParser.Parse(row["Acid3"], typeof(float), 0),
                            Acid4 = (float)DataTypeParser.Parse(row["Acid4"], typeof(float), 0),
                            Acid5 = (float)DataTypeParser.Parse(row["Acid5"], typeof(float), 0),
                            Acid6 = (float)DataTypeParser.Parse(row["Acid6"], typeof(float), 0),
                            Serving = (string)DataTypeParser.Parse(row["Serving"], typeof(string), string.Empty)
                        };
                        // Update mobile service record
                        affectedRows += msRecordSaver.UpdateByMobileServiceRecordID(mdMobileServiceRecord);
                    }                    
                }
                else // New  service detail
                {                    
                    // Add new mobile service detail
                    List<MobileServiceRecord> newMobileServiceRecords = new List<MobileServiceRecord>();
                    foreach (DataGridViewRow row in dgvServiceRecord.Rows)
                    {
                        if (row.IsNewRow)
                            break;
                        MobileServiceRecord newMobileServiceRecord = new MobileServiceRecord()
                        {
                            MSuvDetailID = (int)DataTypeParser.Parse(row.Cells["colMSuvDetailID"].Value, typeof(int), -1),
                            //BrandID = (int)DataTypeParser.Parse(row.Cells["colBrand"].Value, typeof(int), -1),
                            //ProductID = (int)DataTypeParser.Parse(row.Cells["colProduct"].Value, typeof(int), -1),
                            UsedPlace = (string)DataTypeParser.Parse(row.Cells["colUsedPlace"].Value, typeof(string), string.Empty),
                            MachineNo = (string)DataTypeParser.Parse(row.Cells["colMachineNo"].Value, typeof(string), string.Empty),
                            ProductionDate = (string)DataTypeParser.Parse(row.Cells["colProductionDate"].Value, typeof(string), string.Empty),
                            Volt = (int)DataTypeParser.Parse(row.Cells["colVolt"].Value, typeof(int), 0),
                            ChargingAmp = (float)DataTypeParser.Parse(row.Cells["colChargingAmp"].Value, typeof(float), 0),
                            OutAmp = (float)DataTypeParser.Parse(row.Cells["colOutAmp"].Value, typeof(float), 0),
                            Acid1 = (float)DataTypeParser.Parse(row.Cells["colAcid1"].Value, typeof(float), 0),
                            Acid2 = (float)DataTypeParser.Parse(row.Cells["colAcid2"].Value, typeof(float), 0),
                            Acid3 = (float)DataTypeParser.Parse(row.Cells["colAcid3"].Value, typeof(float), 0),
                            Acid4 = (float)DataTypeParser.Parse(row.Cells["colAcid4"].Value, typeof(float), 0),
                            Acid5 = (float)DataTypeParser.Parse(row.Cells["colAcid5"].Value, typeof(float), 0),
                            Acid6 = (float)DataTypeParser.Parse(row.Cells["colAcid6"].Value, typeof(float), 0),
                            Serving = (string)DataTypeParser.Parse(row.Cells["colServing"].Value, typeof(string), string.Empty)
                        };
                        // Add it into List
                        newMobileServiceRecords.Add(newMobileServiceRecord);
                    }
                    // Add new mobile service detail and records
                    this._service.ID = affectedRows = msServiceSaver.Add(msService, newMobileServiceRecords);
                }
            Status:
                if (affectedRows.HasValue && affectedRows.Value > 0)
                {
                     if (serviceSavedHandler != null)
                     {
                    // Return value to caller
                    ServiceSaveEventArgs ServiceSaveEventArg = new ServiceSaveEventArgs(_service.ID);
                    serviceSavedHandler(this, ServiceSaveEventArg);
                    }
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    if (this._needToClose)
                        this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                ToastMessageBox.Show(Resource.errFailedToSave);
            }
        }

        private void LoadNBind()
        {           
            try
            {                
                // Load Employee Data
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
                cmbEmployee.DataSource = dtEmployeesByDept;
                cmbEmployee.ValueMember = "EmployeeID";
                cmbEmployee.DisplayMember = "EmpName";

                // Load Vehicle
                cmbVehicle.DataSource = new VehicleBL().GetAll();

                cmbEmployee.DisplayMember = "EmpName";
                cmbEmployee.ValueMember = "EmployeeID";

                cmbVehicle.DisplayMember = "VenNo";
                cmbVehicle.ValueMember = "VehicleID";

                // Load Brand
                colBrand.DataSource = new BrandBL().GetOwnBrands();
                // Load Product
                colProduct.DataSource = this._dtProduct = new ProductBL().GetAll();
                // Set binding fields
                colBrand.DisplayMember = "BrandName";
                colBrand.ValueMember = "BrandID";

                colProduct.DisplayMember = "ProductName";
                colProduct.ValueMember = "ProductID";
            }
            catch (Exception e)
            {
                ToastMessageBox.Show(Resource.errFailedToSave);
                _logger.Error(e);
            }            
        }

        private void dgvServiceRecord_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //dgvServiceRecord.Rows[e.RowIndex].Cells["ClnNo"].Value = (e.RowIndex + 1).ToString();
            this.dgvServiceRecord.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvServiceRecord_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_cmbProduct != null)
            {
                _cmbProduct.DropDown -= new EventHandler(cmbProduct_DropDown);
            }
        }

        private void cmbProduct_DropDown(object sender, EventArgs e)
        {
            int brandID = (int)DataTypeParser.Parse(dgvServiceRecord.CurrentRow.Cells[_indexBrandColumn].Value, typeof(int), 0);
            if (brandID < 1)
                return;
            DataTable dtResultProducts = DataUtil.GetDataTableBy(this._dtProduct, "BrandID", brandID);
            _cmbProduct.DataSource = dtResultProducts;
        }

        private void dgvServiceRecord_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Register an event to filter displaying value of Product column
            if (dgvServiceRecord.CurrentRow != null && dgvServiceRecord.CurrentCell.ColumnIndex == _indexProductColumn)
            {
                _cmbProduct = e.Control as ComboBox;
                if (_cmbProduct != null)
                {
                    _cmbProduct.DropDown += new EventHandler(cmbProduct_DropDown);
                }
            }
        }

        private void dgvServiceRecord_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvServiceRecord.DataSource as DataTable);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                //    dgvMarketingPlan.BeginEdit(true);
                // e.SuppressKeyPress = true;
                int iColumn = dgvServiceRecord.CurrentCell.ColumnIndex;
                int iRow = dgvServiceRecord.CurrentCell.RowIndex;
                if (iColumn == colServing.Index)
                {
                    if (iRow + 1 >= dgvServiceRecord.Rows.Count)
                    {
                        DataTable serviceTbl = dgvServiceRecord.DataSource as DataTable;
                        DataRow newRow = serviceTbl.NewRow();
                        serviceTbl.Rows.Add(newRow);
                        this.dgvServiceRecord.DataSource = serviceTbl;
                        dgvServiceRecord[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvServiceRecord.CurrentCell = dgvServiceRecord[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvServiceRecord.CurrentCell = dgvServiceRecord[dgvServiceRecord.CurrentCell.ColumnIndex + 1, dgvServiceRecord.CurrentCell.RowIndex];
                    }
                    catch (Exception ie)
                    {
                    }
                }
                return true;
            }            
            return base.ProcessCmdKey(ref msg, keyData);
        }
   
    }
}

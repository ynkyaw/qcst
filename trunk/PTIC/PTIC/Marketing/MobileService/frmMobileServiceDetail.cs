/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/MM/dd)
 * Description: Mobile Service Detail form
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using PTIC.Marketing.Entities;
using PTIC.Common.BL;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Sale.Order;
using log4net.Config;
using PTIC.Sale.BL;
using PTIC.Sale.Entities;

namespace PTIC.VC.Marketing.MobileService
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMobileServiceDetail : Form
    {
        /// <summary>
        /// Logger for frmMobileServiceDetail
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmMobileServiceDetail));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void MobileServiceDetailSaveHandler(object sender, MobileServiceDetailSaveEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event MobileServiceDetailSaveHandler MobileServiceDetailSavedHandler;

        /// <summary>
        /// 
        /// </summary>
        private MobileServiceDetail _mobileServiceDetail = null;

        /// <summary>
        /// Flag indicating frmMobileServiceDetail form should be closed after saved
        /// </summary>
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

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Need to close this form after saved
            _needToClose = true;
            // Save Mobile Service Detail
            Save();
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

        private void cmbProduct_DropDown(object sender, EventArgs e)
        {
            int brandID = (int)DataTypeParser.Parse(dgvServiceRecord.CurrentRow.Cells[_indexBrandColumn].Value, typeof(int), 0);
            if (brandID < 1)
                return;
            DataTable dtResultProducts = DataUtil.GetDataTableBy(this._dtProduct, "BrandID", brandID);
            _cmbProduct.DataSource = dtResultProducts;
        }

        private void dgvServiceRecord_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_cmbProduct != null)
            {
                _cmbProduct.DropDown -= new EventHandler(cmbProduct_DropDown);
            }
        }

        private void btnDeleteMobileServiceDetail_Click(object sender, EventArgs e)
        {
            // Delete the whole MobileSerivceDetail
            if (MessageBox.Show(Resource.qstSureToDeleteMobileServiceDetail, 
                Resource.deleteConfirmation, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.No)
                return;
            if (!_mobileServiceDetail.ID.HasValue)
            {
                this.Close();
                return;
            }

            // Delete mobile service detail
            DeleteMobileServiceDetail(_mobileServiceDetail.ID);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (_mobileServiceDetail == null) // if it is a direct mobile service detail and there is no mobile service plan for it
                _mobileServiceDetail = new MobileServiceDetail();
            //frmOrder orderForm = new frmOrder(_mobileServiceDetail.OrderID);
            int? customerID = (int?)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), null);
            if (!customerID.HasValue)
            {
                MessageBox.Show("Please select customer!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Township township = null;
            DataRowView selectedCustomerRow = cmbCustomer.SelectedItem as DataRowView;
            if (selectedCustomerRow == null)
            {
                MessageBox.Show("Please select customer!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            township = new Township() 
            {
                TownID = (int)DataTypeParser.Parse(selectedCustomerRow["TownID"], typeof(int), -1),
                TownshipID = (int)DataTypeParser.Parse(selectedCustomerRow["TownshipID"], typeof(int), -1)
            };
            frmOrder orderForm = new frmOrder(_mobileServiceDetail.OrderID, customerID, township);
            //set call back handler
            orderForm.OrderSavedHandler += new frmOrder.OrderSaveHandler(OrderSave_CallBack);
            UIManager.OpenForm(orderForm);
        }

        private void OrderSave_CallBack(object sender, frmOrder.OrderSaveEventArgs e)
        {
            if (e.OrderID.HasValue) // If order id has been created
            {
                // Set order id to be refered by MarketingDetail
                _mobileServiceDetail.OrderID = e.OrderID;
                // No need to close this form after saved
                _needToClose = false;
                // Save 
                Save();
            }
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

        private void dgvServiceRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.ColumnIndex < 0)
                return;
            if (dgv.Columns[e.ColumnIndex].Name.Equals("colDelete"))
            {
                if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == System.Windows.Forms.DialogResult.No)
                    return;

                DataGridViewRow selectedRow = dgv.CurrentRow;
                DataRowState selectedRowState = (selectedRow.DataBoundItem as DataRowView).Row.RowState;
                if (selectedRowState == DataRowState.Added || selectedRowState == DataRowState.Detached)
                {
                    // Delete row just from GridView because it is a new row that has not been in Database
                    dgv.Rows.RemoveAt(selectedRow.Index);
                    return;
                }

                int mobileServiceRecordID = (int)DataTypeParser.Parse(selectedRow.Cells["colMobileServiceRecordID"].Value, typeof(int), -1);
                if (mobileServiceRecordID == -1)
                {
                    MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // delete a selected mobile service record from system
                    DeleteMobileServiceRecord(mobileServiceRecordID, dgv);
                }
            }
        }

        private void btnDeleteServiceRecord_Click(object sender, EventArgs e)
        {            
            DataGridViewRow selectedRow = dgvServiceRecord.CurrentRow;
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == System.Windows.Forms.DialogResult.No)
                return;

            if (selectedRow == null)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }

            if (selectedRow.Index == 0) 
            {
                DataTable dtAPRequest = dgvServiceRecord.DataSource as DataTable;
                DataRow newRow = dtAPRequest.NewRow();
                dtAPRequest.Rows.Add(newRow);
                this.dgvServiceRecord.DataSource = dtAPRequest;
                dgvServiceRecord.Rows.RemoveAt(0);
                return;
            }
        


            DataRowState selectedRowState = (selectedRow.DataBoundItem as DataRowView).Row.RowState;
            if (selectedRowState == DataRowState.Added || selectedRowState == DataRowState.Detached)
            {
                // Delete row just from GridView because it is a new row that has not been in Database
                dgvServiceRecord.Rows.Remove(selectedRow);
                return;
            }

            int mobileServiceRecordID = (int)DataTypeParser.Parse(selectedRow.Cells["colMobileServiceRecordID"].Value, typeof(int), -1);
            if (mobileServiceRecordID == -1)
            {
                MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // delete a selected mobile service record from system
                DeleteMobileServiceRecord(mobileServiceRecordID, dgvServiceRecord);
            }
        }

        private void lblMobileServiceSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMobileServicePage));
            this.Close();
        }

        private void dgvServiceRecord_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            // Set row number
            if (null != dgv)
            {
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void dgvServiceRecord_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                //    dgvMarketingPlan.BeginEdit(true);
                // e.SuppressKeyPress = true;
                int iColumn = dgvServiceRecord.CurrentCell.ColumnIndex;
                int iRow = dgvServiceRecord.CurrentCell.RowIndex;
                if (iColumn == dgvServiceRecord.Columns[colServing.Index].Index)
                {
                    if (iRow + 1 >= dgvServiceRecord.Rows.Count)
                    {
                        DataTable dtAPRequest = dgvServiceRecord.DataSource as DataTable;
                        DataRow newRow = dtAPRequest.NewRow();
                        dtAPRequest.Rows.Add(newRow);
                        this.dgvServiceRecord.DataSource = dtAPRequest;
                        dgvServiceRecord[1, iRow+1].Selected = true;
                        
                    }
                    else
                    {
                        dgvServiceRecord.CurrentCell = dgvServiceRecord[1, iRow+1];
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
        #endregion

        #region Private Methods
        private void LoadNBindByMobileServiceDetailID(int? mobileServiceDetailID)
        {
            try
            {
                if (mobileServiceDetailID != null && mobileServiceDetailID.HasValue)
                {
                    DataTable dtDetail = new MobileServiceDetailBL().GetByMobileServiceDetailID(mobileServiceDetailID.Value);
                    if (dtDetail.Rows.Count > 0)
                    {
                        // Set value to fields
                        this._mobileServiceDetail.OrderID = (int?)DataTypeParser.Parse(dtDetail.Rows[0]["OrderID"], typeof(int), null);
                        txtServiceNo.Text = (string)DataTypeParser.Parse(dtDetail.Rows[0]["ServiceNo"], typeof(string), string.Empty);
                        cmbTownship.SelectedValue = (int)DataTypeParser.Parse(dtDetail.Rows[0]["TownshipID"], typeof(int), -1);
                        cmbCustomerType.SelectedValue = (int)DataTypeParser.Parse(dtDetail.Rows[0]["CusTypeID"], typeof(int), -1);
                        cmbCustomer.SelectedValue = (int)DataTypeParser.Parse(dtDetail.Rows[0]["CusID"], typeof(int), -1);
                        cmbEmployee.SelectedValue = (int)DataTypeParser.Parse(dtDetail.Rows[0]["EmpID"], typeof(int), -1);
                        dtpServicedDate.Value = (DateTime)DataTypeParser.Parse(dtDetail.Rows[0]["ServicedDate"], typeof(DateTime), DateTime.Now);
                        txtSugForUsage.Text = (string)DataTypeParser.Parse(dtDetail.Rows[0]["SugForUsage"], typeof(string), string.Empty);
                        txtResonNotService.Text = (string)DataTypeParser.Parse(dtDetail.Rows[0]["ResonNotService"], typeof(string), string.Empty);
                        DateTime AppointedDate = (DateTime)DataTypeParser.Parse(dtDetail.Rows[0]["AppointedDate"], typeof(DateTime), DateTime.MinValue);

                        if (AppointedDate == DateTime.MinValue)
                        {
                            dtpAppointedDate.Checked = false;
                        }
                        else
                        {
                            dtpAppointedDate.Checked = true;
                            dtpAppointedDate.Value = (DateTime)DataTypeParser.Parse(AppointedDate, typeof(DateTime), DateTime.Now);
                        }
                    }
                }
                // Load Mobile service records and in case of MobileServiceDetailID is null, it will load schema
                LoadNBindMobileServiceRecords(mobileServiceDetailID);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        private void LoadNBindMobileServiceRecords(int? mobileServiceDetailID)
        {
            dgvServiceRecord.DataSource = new MobileServiceRecordBL().GetByMobileServiceDetailID(mobileServiceDetailID);
        }

        private void LoadNBind()
        {
            try
            {
                DataSet ds = new DataSet();
                BindingSource bdTownship = new BindingSource();
                BindingSource bdTownshipWithCusType = new BindingSource();
                BindingSource bdCustomer = new BindingSource();

                DataTable dtTownship = new TownshipBL().GetAll();
                DataTable dtTownshipWithCusType = new TownshipBL().GetWithCustomerType();
                DataTable dtCustomer = new CustomerBL().GetAll();

                // add town and customer tables into a dataset
                ds.Tables.Add(dtTownship);
                ds.Tables.Add(dtTownshipWithCusType);
                ds.Tables.Add(dtCustomer);

                // create data relation between town and customer
                DataRelation relTownship_CusType = new DataRelation("Township_CusType",
                        dtTownship.Columns["TownshipID"], dtTownshipWithCusType.Columns["TownshipID"]);
                DataRelation relCusType_Customer = new DataRelation("CusType_Customer",
                        dtTownshipWithCusType.Columns["CusType"], dtCustomer.Columns["CusType"], false);
                // add relation into a dataset
                ds.Relations.Add(relTownship_CusType);
                ds.Relations.Add(relCusType_Customer);

                bdTownship.DataSource = ds;
                bdTownship.DataMember = dtTownship.TableName;

                bdTownshipWithCusType.DataSource = bdTownship;
                bdTownshipWithCusType.DataMember = "Township_CusType";

                bdCustomer.DataSource = bdTownshipWithCusType;
                bdCustomer.DataMember = "CusType_Customer";

                // Township
                cmbTownship.DataSource = bdTownship;
                // Customer Type
                cmbCustomerType.DataSource = bdTownshipWithCusType;
                // Customer
                cmbCustomer.DataSource = bdCustomer;

                // Load Employee Data
                //  cmbEmployee.DataSource = new EmployeeBL().GetAll(conn);
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

                /*
                // Load Brand
                colBrand.DataSource = new BrandBL().GetOwnBrands();
                // Load Product
                colProduct.DataSource = this._dtProduct = new ProductBL().GetAll();
                // Set binding fields
                colBrand.DisplayMember = "BrandName";
                colBrand.ValueMember = "BrandID";

                colProduct.DisplayMember = "ProductName";
                colProduct.ValueMember = "ProductID";
                 */ 
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw e;
                //ToastMessageBox.Show(Resource.errFailedToSave);
            }
        }

        private void Save()
        {
            MobileServiceDetailBL msDetailSaver = null;
            MobileServiceRecordBL msRecordSaver = null;
            MobileServiceDetail msDetail = null;
            try
            {
                msDetailSaver = new MobileServiceDetailBL();
                msRecordSaver = new MobileServiceRecordBL();
                // if it is a direct mobile service detail and there is no mobile service plan for it
                if (_mobileServiceDetail == null)
                    _mobileServiceDetail = new MobileServiceDetail();

                msDetail = new MobileServiceDetail()
                {
                    ID = _mobileServiceDetail.ID,
                    ServicePlanID = _mobileServiceDetail.ServicePlanID,
                    OrderID = _mobileServiceDetail.OrderID,
                    ServiceNo = txtServiceNo.Text,
                    CusID = (int)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), -1),
                    EmpID = (int)DataTypeParser.Parse(cmbEmployee.SelectedValue, typeof(int), -1),
                    ServicedDate = dtpServicedDate.Value,       
                    IsCustomer = rdoCustomer.Checked,
                    SugForUsage = txtSugForUsage.Text,
                    ResonNotService = txtResonNotService.Text,
                    AppointedDate = dtpAppointedDate.Checked ? dtpAppointedDate.Value : DateTime.MinValue
                };

                int? affectedRows = null;
                if (_mobileServiceDetail.ID.HasValue) // An existing mobile service detail
                {
                    // Set MobileServiceDetailID
                    msDetail.ID = (int)DataTypeParser.Parse(_mobileServiceDetail.ID, typeof(int), null);
                    // Update mobile service detail (master)
                    affectedRows = msDetailSaver.UpdateByMobileServiceDetailID(msDetail);

                    DataTable dt = dgvServiceRecord.DataSource as DataTable;
                    if (dt == null || dt.Rows.Count < 1) // If mobile service record(s) are not present, no work for it
                    {
                        goto Status;
                    }
                    // New Mobile Service Record
                    DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                    foreach (DataRow row in dvInsert.ToTable().Rows)
                    {
                        //if (row.IsNull("ProductID"))
                        //    continue;
                        MobileServiceRecord newMobileServiceRecord = new MobileServiceRecord()
                        {
                            MSuvDetailID = (int)DataTypeParser.Parse(row["MSuvDetailID"], typeof(int), msDetail.ID),
                            //BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                            //ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                            Brand = (string)DataTypeParser.Parse(row["Brand"], typeof(string), null),
                            Product = (string)DataTypeParser.Parse(row["Product"], typeof(string), null),
                            UsedPlace = (string)DataTypeParser.Parse(row["UsedPlace"], typeof(string), string.Empty),
                            MachineNo = (string)DataTypeParser.Parse(row["MachineNo"], typeof(string), string.Empty),
                            ProductionDate = (string)DataTypeParser.Parse(row["ProductionDate"], typeof(string), string.Empty),
                            Volt = (int)DataTypeParser.Parse(row["Volt"], typeof(int), 0),
                            ChargingAmp = DataTypeParser.ParseToFloat(row["ChargingAmp"]),
                            OutAmp = DataTypeParser.ParseToFloat(row["OutAmp"]),
                            Acid1 = DataTypeParser.ParseToFloat(row["Acid1"]),
                            Acid2 = DataTypeParser.ParseToFloat(row["Acid2"]),
                            Acid3 = DataTypeParser.ParseToFloat(row["Acid3"]),
                            Acid4 = DataTypeParser.ParseToFloat(row["Acid4"]),
                            Acid5 = DataTypeParser.ParseToFloat(row["Acid5"]),
                            Acid6 = DataTypeParser.ParseToFloat(row["Acid6"]),
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
                            MSuvDetailID = (int)DataTypeParser.Parse(row["MSuvDetailID"], typeof(int), -1),
                            //BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                            //ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                            Brand = (string)DataTypeParser.Parse(row["Brand"], typeof(string), null),
                            Product = (string)DataTypeParser.Parse(row["Product"], typeof(string), null),
                            UsedPlace = (string)DataTypeParser.Parse(row["UsedPlace"], typeof(string), string.Empty),
                            MachineNo = (string)DataTypeParser.Parse(row["MachineNo"], typeof(string), string.Empty),
                            ProductionDate = (string)DataTypeParser.Parse(row["ProductionDate"], typeof(string), string.Empty),
                            Volt = (int)DataTypeParser.Parse(row["Volt"], typeof(int), 0),
                            ChargingAmp = DataTypeParser.ParseToFloat(row["ChargingAmp"]),
                            OutAmp = DataTypeParser.ParseToFloat(row["OutAmp"]),
                            Acid1 = DataTypeParser.ParseToFloat(row["Acid1"]),
                            Acid2 = DataTypeParser.ParseToFloat(row["Acid2"]),
                            Acid3 = DataTypeParser.ParseToFloat(row["Acid3"]),
                            Acid4 = DataTypeParser.ParseToFloat(row["Acid4"]),
                            Acid5 = DataTypeParser.ParseToFloat(row["Acid5"]),
                            Acid6 = DataTypeParser.ParseToFloat(row["Acid6"]),
                            Serving = (string)DataTypeParser.Parse(row["Serving"], typeof(string), string.Empty)
                        };
                        // Update mobile service record
                        affectedRows += msRecordSaver.UpdateByMobileServiceRecordID(mdMobileServiceRecord);
                    }
                }
                else // New mobile service detail
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
                            
                            //Brand = (string)DataTypeParser.Parse(row.Cells[colBrand.Index].Value, typeof(string), null),
                            Product = (string)DataTypeParser.Parse(row.Cells[colProduct.Index].Value, typeof(string), null),
                            UsedPlace = (string)DataTypeParser.Parse(row.Cells["colUsedPlace"].Value, typeof(string), string.Empty),
                            MachineNo = (string)DataTypeParser.Parse(row.Cells["colMachineNo"].Value, typeof(string), string.Empty),
                            ProductionDate = (string)DataTypeParser.Parse(row.Cells["colProductionDate"].Value, typeof(string), string.Empty),
                            Volt = (int)DataTypeParser.Parse(row.Cells["colVolt"].Value, typeof(int), 0),
                            ChargingAmp = DataTypeParser.ParseToFloat(row.Cells["colChargingAmp"].Value),
                            OutAmp = DataTypeParser.ParseToFloat(row.Cells["colOutAmp"].Value),
                            Acid1 = DataTypeParser.ParseToFloat(row.Cells["colAcid1"].Value),
                            Acid2 = DataTypeParser.ParseToFloat(row.Cells["colAcid2"].Value),
                            Acid3 = DataTypeParser.ParseToFloat(row.Cells["colAcid3"].Value),
                            Acid4 = DataTypeParser.ParseToFloat(row.Cells["colAcid4"].Value),
                            Acid5 = DataTypeParser.ParseToFloat(row.Cells["colAcid5"].Value),
                            Acid6 = DataTypeParser.ParseToFloat(row.Cells["colAcid6"].Value),
                            Serving = (string)DataTypeParser.Parse(row.Cells["colServing"].Value, typeof(string), string.Empty)
                        };
                        // Add it into List
                        newMobileServiceRecords.Add(newMobileServiceRecord);
                    }
                    // Add new mobile service detail and records
                    this._mobileServiceDetail.ID = affectedRows = msDetailSaver.Add(msDetail, newMobileServiceRecords);
                }
            Status:
                if (affectedRows.HasValue && affectedRows.Value > 0)
                {
                    if (MobileServiceDetailSavedHandler != null) // if this form is not a direct mobile service detail and there is a caller
                    {
                        // Return value to caller
                        MobileServiceDetailSaveEventArgs mobileServiceDetailSaveEventArg = new MobileServiceDetailSaveEventArgs(true);
                        MobileServiceDetailSavedHandler(this, mobileServiceDetailSaveEventArg);
                    }
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    if (this._needToClose)
                        this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            catch (Exception e)
            {
                //ToastMessageBox.Show(Resource.errFailedToSave);
                _logger.Error(e);
                throw e;
            }
        }

        private void DeleteMobileServiceDetail(int? _mobileServiceDetailID)
        {
            int affectedRow = 0;
            try
            {
                int msDetailID = (int)DataTypeParser.Parse(_mobileServiceDetailID, typeof(int), -1);
                affectedRow = new MobileServiceDetailBL().DeleteByMobileServiceDetailID(msDetailID);
                if (affectedRow > 0)
                {
                    // Return value to caller
                    MobileServiceDetailSaveEventArgs mobileServiceDetailSaveEventArg = new MobileServiceDetailSaveEventArgs(true);
                    MobileServiceDetailSavedHandler(this, mobileServiceDetailSaveEventArg);
                    // Close this form
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

        private void DisableReadWrite()
        {
            txtContactPerson.ReadOnly = true;
            txtPost.ReadOnly = true;
            txtContactPersonPhNo.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtPh1.ReadOnly = true;
            txtPh2.ReadOnly = true;
        }

        private void ClearValues()
        {
            // enable read-write to fields
            EnableReadWrite();
            // clear fields
            txtContactPerson.Clear();
            txtPost.Clear();
            txtContactPersonPhNo.Clear();
            txtAddress.Clear();
            txtPh1.Clear();
            txtPh2.Clear();
        }

        private void EnableReadWrite()
        {
            txtContactPerson.ReadOnly = false;
            txtPost.ReadOnly = false;
            txtContactPersonPhNo.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtPh1.ReadOnly = false;
            txtPh2.ReadOnly = false;
        }

        private void SetValuesBySelectedCustomer(DataRowView selectedCustomer)
        {
            txtContactPerson.Text = (string)DataTypeParser.Parse(selectedCustomer["ConPersonName"], typeof(string), string.Empty);
            txtContactPersonPhNo.Text = (string)DataTypeParser.Parse(selectedCustomer["MobilePhone"], typeof(string), string.Empty);
            txtPh1.Text = (string)DataTypeParser.Parse(selectedCustomer["Phone1"], typeof(string), string.Empty);
            txtPh2.Text = (string)DataTypeParser.Parse(selectedCustomer["Phone2"], typeof(string), string.Empty);
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

            string s = address;
            if (s.LastIndexOf(',').Equals(s.Length - 1))
            {
                s = s.Remove(s.Length - 1);
            }
            txtAddress.Text = s;

            // Disable read-write to fields
            DisableReadWrite();
        }

        private void DeleteMobileServiceRecord(int mobileServiceRecordID, DataGridView dgv)
        {
            try
            {
                // delete a selected mobile service record
                int affectedRows = new MobileServiceRecordBL().DeleteByID(mobileServiceRecordID);
                if (affectedRows > 0)
                {
                    // remove row @gridvew also
                    dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
                    // Add a new row if no more row exist
                    DataTable dt = dgv.DataSource as DataTable;
                    if (dgv.Rows.Count == 0)
                    {
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                    }
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
                else
                    MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Constructors
        public frmMobileServiceDetail()
        {
            InitializeComponent();
            // Configure logger
            XmlConfigurator.Configure();
            // Get column index of grid combos
            this._indexBrandColumn = dgvServiceRecord.Columns.IndexOf(dgvServiceRecord.Columns["colBrand"]);
            this._indexProductColumn = dgvServiceRecord.Columns.IndexOf(dgvServiceRecord.Columns["colProduct"]);
            // Disable auto generating columns
            dgvServiceRecord.AutoGenerateColumns = false;
            // Load necessary data
            LoadNBind();
            // Load schema
            LoadNBindByMobileServiceDetailID(null);
            DataUtil.AddInitialNewRow(dgvServiceRecord);
            
        }

        public frmMobileServiceDetail(
            MobileServiceDetail mobileServiceDetail, 
            string servicePlanNo, 
            int townshipID, int customerTypeID, int customerID)
            : this()
        {
            // Set ServicePlanNo
            txtServicePlanNo.Text = servicePlanNo;
            this._mobileServiceDetail = mobileServiceDetail;

            // Load by MobileServiceDetail By ID
            LoadNBindByMobileServiceDetailID(_mobileServiceDetail.ID);
            DataUtil.AddInitialNewRow(dgvServiceRecord);
            // Set button image if MobileServiceDetail has an order
            if (this._mobileServiceDetail.OrderID.HasValue)
                btnOrder.BackgroundImage = Resource.btn_green_vertical;
            // Set township , customer type, customer in accordance with customer that has been planned and disable all
            cmbTownship.SelectedValue = townshipID;
            cmbCustomerType.SelectedValue = customerTypeID;
            cmbCustomer.SelectedValue = customerID;
            cmbTownship.Enabled = cmbCustomerType.Enabled = cmbCustomer.Enabled = false;
            rdoCustomer.Enabled = rdoNonCustomer.Enabled = false;
        }
        #endregion

        #region Inner Class
        public class MobileServiceDetailSaveEventArgs : EventArgs
        {
            private bool _occuredChanges = false;

            public MobileServiceDetailSaveEventArgs(bool occuredChanges)
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

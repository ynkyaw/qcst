/*
 * Author:
 * Create date: 2014/02/26 (yyyy/MM/dd)
 * Description: A P Usage form
 */
using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using PTIC.Common.BL;
using PTIC.VC.Util;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using PTIC.Util;
using PTIC.Common;
using PTIC.Sale.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.VC.Marketing.A_P
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmA_PUsage : Form
    {
        /// <summary>
        /// Logger for frmDailyMarketingLog
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmA_PUsage));

        private DataTable _dtAPCategory = null;
        /// <summary>
        /// Record table for different A&P types
        /// </summary>
        //private DataTable _dtAPSubCat = null;

        /// <summary>
        /// Record table for different A&P
        /// </summary>
        //private DataTable _dtAP = null;

        /// <summary>
        /// 
        /// </summary>
        private BindingSource _bdAPSubCategory, _bdFilteredPOSM, _bdUnfilteredPOSM;

        private int _indexAPCategoryColumn = -1;
        /// <summary>
        /// Index of A&P type column from DataGridView
        /// </summary>
        private int _indexAPSubCatColumn = -1;

        /// <summary>
        /// Index of A&P column from DataGridView
        /// </summary>
        private int _indexAPColumn = -1;

        /// <summary>
        /// 
        /// </summary>
        private ComboBox cmbAPCat = null;

        private ComboBox cmbAPSub = null;
        /// <summary>
        /// 
        /// </summary>
        private ComboBox cmbAP = null;

        /// <summary>
        /// 
        /// </summary>
        private int? _A_P_UsageID = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void A_PUsageSaveHandler(object sender, A_PUsageSaveEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event A_PUsageSaveHandler A_PUsagSavedHandler;
        
        #region Events
        private void cmbCustomerName_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            DataRowView selectedCustomerRow = cmb.SelectedItem as DataRowView;
            ClearValues();
            if (selectedCustomerRow == null)            
                return;
            SetValuesBySelectedCustomer(selectedCustomerRow);  
        }

        private void dgvAPUsageDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0)
            //    return;
            //var gv = sender as DataGridView;
            //string curColumName = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
            ////DataGridViewComboBoxCell curCatCell = gv.cu.Rows[e.RowIndex].Cells["colAP_CategoryID"] as DataGridViewComboBoxCell;
            //DataGridViewComboBoxCell curSubCell = gv.Rows[e.RowIndex].Cells["colA_P_SubCatID"] as DataGridViewComboBoxCell;
            //DataGridViewComboBoxCell curCell = gv.Rows[e.RowIndex].Cells["colA_PID"] as DataGridViewComboBoxCell;
            //if (curColumName.Equals("colA_PID"))
            //{
            //    // Set A P Size by selected A_PID
                
            //    DataTable dt = curCell.DataSource as DataTable;
            //    DataRow rowResult = DataUtil.GetDataRowBy(dt, "A_P_MaterialID", curCell.Value);
            //    if (rowResult != null)
            //        gv.Rows[e.RowIndex].Cells["colA_P_Size"].Value = rowResult["Size"];
            //}
            //else if (curColumName.Equals("colA_P_SubCatID"))
            //{
                
            //    //dgvAPUsageDetail.CurrentRow.Cells[5].Value = curCell;
            //}
            //else if (curColumName.Equals("colAP_CategoryID"))
            //{
            //    int APcatID = (int)DataTypeParser.Parse(dgvAPUsageDetail.CurrentRow.Cells[3].Value, typeof(int), 0);
            //    if (APcatID < 1)
            //        return;
            //    DataTable dtResultsub = DataUtil.GetDataTableBy(this._dtAPSubCat, "APCategoryID", APcatID);
            //    //colA_P_SubCatID.DataSource = dtResultsub;                
            //    curSubCell.DataSource = dtResultsub;
            //    //dgvAPUsageDetail.CurrentRow.Cells[4].Value = curSubCell;
            //}
        }

        private void dgvAPUsageDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {            
            // Register an event to filter displaying value of A&P column
            //if (dgvAPUsageDetail.CurrentRow != null && dgvAPUsageDetail.CurrentCell.ColumnIndex == colAP_CategoryID.Index)
            //{
            //    cmbAP = e.Control as ComboBox;
            //    if (cmbAP != null)
            //    {
            //        cmbAP.SelectedIndexChanged += new EventHandler(cmbAP_SelectedIndexChanged);
            //    }
            //}
            //else if (dgvAPUsageDetail.CurrentRow != null && dgvAPUsageDetail.CurrentCell.ColumnIndex == 4)
            //{
            //    cmbAPSub = e.Control as ComboBox;
            //    if (cmbAPSub != null)
            //    {
            //        cmbAPSub.SelectedIndexChanged += new EventHandler(cmbAPSub_SelectedIndexChanged);
            //    }
            //}
            //else if (dgvAPUsageDetail.CurrentRow != null && dgvAPUsageDetail.CurrentCell.ColumnIndex == 3)
            //{
            //    cmbAPCat = e.Control as ComboBox;
            //    if (cmbAPCat != null)
            //    {
            //        cmbAPCat.SelectedIndexChanged += new EventHandler(cmbAPCat_SelectedIndexChanged);
            //    }
            //}

            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            }
        }

        void cmbAPCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //DataGridViewComboBoxCell curSubCell = dgvAPUsageDetail.CurrentRow.Cells["colA_P_SubCatID"] as DataGridViewComboBoxCell;
            //int APcatID = (int)DataTypeParser.Parse(cmbAPCat.SelectedValue, typeof(int), 0);//dgvAPUsageDetail.CurrentRow.Cells[3].Value
            //if (APcatID < 1)
            //    return;
            //DataTable dtResultsub = DataUtil.GetDataTableBy(this._dtAPSubCat, "APCategoryID", APcatID);
                            
            //curSubCell.DataSource = dtResultsub;
            
        }

        void cmbAP_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewComboBoxCell curCell = dgvAPUsageDetail.CurrentRow.Cells["colA_PID"] as DataGridViewComboBoxCell;
            DataTable dt = curCell.DataSource as DataTable;
            int apmatid = 0;
            int APID = (int)DataTypeParser.Parse(cmbAP.SelectedValue, typeof(int), -1);
            foreach (DataGridViewRow dr in dgvAPUsageDetail.Rows)
            {
                apmatid = (int)DataTypeParser.Parse(dr.Cells["colA_PID"].Value, typeof(int), 0);
                if (APID == apmatid)
                    dgvAPUsageDetail.CurrentRow.Cells["colA_PID"].ErrorText = "This AP Material is already filled!"; return;
            }
            dgvAPUsageDetail.CurrentRow.Cells["colA_PID"].ErrorText = null;

            DataRow rowResult = DataUtil.GetDataRowBy(dt, "A_P_MaterialID", cmbAP.SelectedValue);//curCell.Value
            if (rowResult != null)
            {
                dgvAPUsageDetail.CurrentRow.Cells["colA_P_Size"].Value = rowResult["Size"];                
            }
        }

        void cmbAPSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataGridViewComboBoxCell curCell = dgvAPUsageDetail.CurrentRow.Cells["colA_PID"] as DataGridViewComboBoxCell;
            //int APsubID = (int)DataTypeParser.Parse(cmbAPSub.SelectedValue, typeof(int), 0);//dgvAPUsageDetail.CurrentRow.Cells[4].Value
            //if (APsubID < 1)
            //    return;
            //DataTable dtResultAP = DataUtil.GetDataTableBy(this._dtAP, "APSubCategoryID", APsubID);
            
            //curCell.DataSource = dtResultAP;
        }    
        
        private void dgvAPUsageDetail_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (cmbAP != null && e.ColumnIndex == 5)
            //{
            //    cmbAP.SelectedIndexChanged -= new EventHandler(cmbAP_SelectedIndexChanged);
            //    dgvAPUsageDetail.CurrentRow.Cells[e.ColumnIndex].ErrorText = null;
                    
            //}
            //if (cmbAPSub != null && e.ColumnIndex == 4)
            //{
            //    cmbAPSub.SelectedIndexChanged -= new EventHandler(cmbAPSub_SelectedIndexChanged);
            //    dgvAPUsageDetail.CurrentRow.Cells[e.ColumnIndex].ErrorText = null;
            //}
            //if (cmbAPCat != null && e.ColumnIndex == 3)
            //{
            //    cmbAPCat.SelectedIndexChanged -= new EventHandler(cmbAPCat_SelectedIndexChanged);
            //    dgvAPUsageDetail.CurrentRow.Cells[e.ColumnIndex].ErrorText = null;
            //}
        }        

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save A & P Usage
            Save();
        }        

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAPUsageDetail.CurrentRow.IsNewRow || dgvAPUsageDetail.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.No)
                return;

            DataGridViewRow selectedRow = dgvAPUsageDetail.CurrentRow;
            if((selectedRow.DataBoundItem as DataRowView).Row.RowState == DataRowState.Added)
            {
                // Delete row just from GridView because it is a new row that has not been in Database
                dgvAPUsageDetail.Rows.RemoveAt(selectedRow.Index);
                return;
            }
            
            int dAPUsageDetailID = (int)DataTypeParser.Parse(selectedRow.Cells["colA_P_UsageDetailID"].Value, typeof(int), -1);
            if (dAPUsageDetailID == -1)
            {
                MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Delete a selected AP material
                int selectedVenID = (int)DataTypeParser.Parse(cmbVehicle.SelectedValue, typeof(int), -1);
                DeleteA_P_UsageDetail(dAPUsageDetailID, selectedVenID);
            }
        }

        private void dgvAPUsageDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //if (e.ColumnIndex < 6 && e.ColumnIndex > 2)
            //{
            //    dgvAPUsageDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Need to select a value!!!";
            //}
            //else
            //{
            //    dgvAPUsageDetail.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Data Type Error!!!";
            //}
        }

        private void dgvAPUsageDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            int newInteger = 0;
            int Qty = 0;
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            int APMaterialID = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colA_PID.Index].Value, typeof(int), -1);
            int VenID = (int)DataTypeParser.Parse(cmbVehicle.SelectedValue, typeof(int), -1);
            DataTable dt = new AP_EnquiryBL().GetBalanceByAPMaterialIDVenID(APMaterialID, VenID);
            if (dt.Rows.Count < 1)
            {
                Qty = 0;
            }
            else
            {
                Qty = (int)DataTypeParser.Parse(dt.Rows[0]["Qty"], typeof(int), 0);
            }
            
            if (e.ColumnIndex == colA_PID.Index)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells["colA_PID"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
                        if (row.Cells["colA_PID"].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed!";
                            MessageBox.Show("Duplicate not allowed!", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
            else if (e.ColumnIndex == colQty.Index)
            {
                if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger <= 0)
                {
                    dgv.Rows[e.RowIndex].ErrorText = "အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။";
                    ToastMessageBox.Show("အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။", Color.Red);
                }
            }

            if (Qty < newInteger)
            {
                string BalanceQty = String.Format("လက်ကျန် '{0}' သာရှိတော့သဖြင့် မလုံလောက်ပါ။", Qty);
                dgv.Rows[e.RowIndex].ErrorText = BalanceQty;
                MessageBox.Show(BalanceQty, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvAPUsageDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvAPUsageDetail.CurrentCell.ColumnIndex;
                int iRow = dgvAPUsageDetail.CurrentCell.RowIndex;
                if (iColumn == dgvAPUsageDetail.Columns[colRemark.Index].Index)
                {
                    if (iRow + 1 >= dgvAPUsageDetail.Rows.Count)
                    {
                        DataTable dtAPEnquiry = dgvAPUsageDetail.DataSource as DataTable;
                        DataRow newRow = dtAPEnquiry.NewRow();
                        dtAPEnquiry.Rows.Add(newRow);
                        dgvAPUsageDetail.DataSource = dtAPEnquiry;
                        dgvAPUsageDetail[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvAPUsageDetail.CurrentCell = dgvAPUsageDetail[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvAPUsageDetail.CurrentCell = dgvAPUsageDetail[dgvAPUsageDetail.CurrentCell.ColumnIndex + 1, dgvAPUsageDetail.CurrentCell.RowIndex];
                    }
                    catch (Exception)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Private Methods
        private void Save()
        {
            SqlConnection conn = null;
            A_P_UsageBL A_P_UsageSaver = null;
            A_P_UsageDetailBL A_P_UsageDetailSaver = null;
            A_P_Usage A_P_Usage = null;
            int? affectedRows = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                A_P_UsageSaver = new A_P_UsageBL();
                A_P_UsageDetailSaver = new A_P_UsageDetailBL();
                A_P_Usage = new A_P_Usage()
                {
                    //A_P_UsageID = (int)DataTypeParser.Parse(this._A_P_UsageID, typeof(int), -1),
                    CusID = (int)DataTypeParser.Parse(cmbCustomerName.SelectedValue, typeof(int), -1),
                    DeptID = (int)DataTypeParser.Parse(cmbDepartment.SelectedValue, typeof(int), (int)PTIC.Common.Enum.PredefinedDepartment.Marketing),
                    VenID = (int)DataTypeParser.Parse(cmbVehicle.SelectedValue, typeof(int), -1),
                    SalesPersonID = (int)DataTypeParser.Parse(cmbEmployeeName.SelectedValue, typeof(int), -1),
                    Date = (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.Now),
                    //Advertisement =
                    //IsPTIC =
                };

                if (_A_P_UsageID == null) // Add new A_P_Usage and details
                {
                    List<A_P_UsageDetail> A_P_UsageDetails = new List<A_P_UsageDetail>();
                    foreach (DataGridViewRow row in dgvAPUsageDetail.Rows)
                    {
                        if (row.IsNewRow)
                            break;
                        A_P_UsageDetail APUsageDetail = new A_P_UsageDetail()
                        {
                            A_P_UsageID = (int)DataTypeParser.Parse(row.Cells["colA_P_UsageID"].Value, typeof(int), -1),
                            A_P_MaterialID = (int)DataTypeParser.Parse(row.Cells["colA_PID"].Value, typeof(int), -1),
                            BrandID = (int)DataTypeParser.Parse(row.Cells["colBrand"].Value, typeof(int), -1),
                            Qty = (int)DataTypeParser.Parse(row.Cells["colQty"].Value, typeof(int), 0),
                            Remark = (string)DataTypeParser.Parse(row.Cells["colRemark"].Value, typeof(string), string.Empty)
                        };
                        A_P_UsageDetails.Add(APUsageDetail);
                    }
                    // make A_P_Usage present in this form
                    _A_P_UsageID = affectedRows = A_P_UsageSaver.Add(A_P_Usage, A_P_UsageDetails, conn);

                    // Check field validation failed or not
                    if (!A_P_UsageSaver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(A_P_UsageSaver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            this.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                else // Update existing A_P_Usage and details
                {
                    A_P_Usage.A_P_UsageID = (int)DataTypeParser.Parse(this._A_P_UsageID, typeof(int), null);
                    // Update A_P_Usage (master)
                    affectedRows = A_P_UsageSaver.UpdateByA_P_UsageID(A_P_Usage, conn);

                    DataTable dt = dgvAPUsageDetail.DataSource as DataTable;
                    // New A_P_Usage Detail (detail)
                    DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                    foreach (DataRow row in dvInsert.ToTable().Rows)
                    {
                        A_P_UsageDetail newAPUsageDetail = new A_P_UsageDetail()
                        {
                            //A_P_UsageID = (int)DataTypeParser.Parse(row["A_P_UsageID"], typeof(int), -1),
                            A_P_UsageID = (int)DataTypeParser.Parse(_A_P_UsageID, typeof(int), -1),
                            A_P_MaterialID = (int)DataTypeParser.Parse(row["A_P_MaterialID"], typeof(int), -1),
                            BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                            Qty = (int)DataTypeParser.Parse(row["Qty"], typeof(int), 0),
                            Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), string.Empty)
                        };
                        affectedRows += A_P_UsageDetailSaver.Add(newAPUsageDetail, A_P_Usage.VenID, conn);

                        // Check field validation failed or not
                        if (!A_P_UsageDetailSaver.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(A_P_UsageDetailSaver.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                this.Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Update A_P_Usage Detail (detail)
                    DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                    foreach (DataRow row in dvUpdate.ToTable().Rows)
                    {
                        A_P_UsageDetail uA_P_UsageDetail = new A_P_UsageDetail() 
                        {
                            A_P_UsageDetailID = (int)DataTypeParser.Parse(row["A_P_UsageDetailID"], typeof(int), -1),
                            A_P_UsageID = (int)DataTypeParser.Parse(row["A_P_UsageID"], typeof(int), -1),
                            A_P_MaterialID = (int)DataTypeParser.Parse(row["A_P_MaterialID"], typeof(int), -1),
                            BrandID = (int)DataTypeParser.Parse(row["BrandID"], typeof(int), -1),
                            Qty = (int)DataTypeParser.Parse(row["Qty"], typeof(int), -1),
                            Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), -1)
                        };
                        affectedRows += A_P_UsageDetailSaver.UpdateByA_P_UsageDetailID(uA_P_UsageDetail, A_P_Usage.VenID, conn);

                        // Check field validation failed or not
                        if (!A_P_UsageDetailSaver.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(A_P_UsageDetailSaver.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                this.Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                if (affectedRows.HasValue && affectedRows.Value > 0)
                {
                    // return value to sender
                    A_PUsageSaveEventArgs A_PUsageSaveEventArg = new A_PUsageSaveEventArgs(_A_P_UsageID);
                    A_PUsagSavedHandler(this, A_PUsageSaveEventArg);

                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
                ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void DeleteA_P_UsageDetail(int dAPUsageDetailID, int vehicleID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // Delete a selected detail
                int affectedRows = new A_P_UsageDetailBL().DeleteByA_P_UsageDetailID(dAPUsageDetailID, vehicleID, conn);
                if (affectedRows > 0)
                {
                    // remove row @gridvew also
                    dgvAPUsageDetail.Rows.RemoveAt(dgvAPUsageDetail.CurrentRow.Index);
                    if (dgvAPUsageDetail.RowCount == 0)
                    {
                        DataUtil.AddInitialNewRow(dgvAPUsageDetail);
                    }
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
                else
                    MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException sql)
            {
                _logger.Error(sql);
                MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void LoadNBindNecessaryData()
        {             
            try
            {                
                // Load and bind employee
                DataTable employeeTbl = new EmployeeBL().GetAll();
                DataTable dtEmployeesByDept = null;
                //if (GlobalCache.is_sale == false)
                if(Program.module != Program.Module.Sale)
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(employeeTbl, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                }
                else
                {
                    dtEmployeesByDept = DataUtil.GetDataTableBy(employeeTbl, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                }
                cmbEmployeeName.DataSource = dtEmployeesByDept;
                cmbEmployeeName.ValueMember = "EmployeeID";
                cmbEmployeeName.DisplayMember = "EmpName";

                // Load and bind customer
                cmbCustomerName.DataSource = new CustomerBL().GetAll();
                // Load and bind Vehicle
                cmbVehicle.DataSource = new VehicleBL().GetAll();
                // Load A&P Type and A&P
                //_dtAPCategory = new AP_MaterialBL().GetAllCategory(conn);
                //_dtAPSubCat = new AP_MaterialBL().GetAllSubCategory(conn);
                //_dtAP = new AP_MaterialBL().GetAllMaterial(conn);

                // Bind
                //colAP_CategoryID.DataSource = _dtAPCategory;
                //colA_P_SubCatID.DataSource = _dtAPSubCat;
                //colA_PID.DataSource = _dtAP;

                _bdAPSubCategory = new BindingSource();
                _bdAPSubCategory.DataSource = new APSubCategoryDAO().SelectAllAPSubCat();

                colA_P_SubCatID.DataSource = _bdAPSubCategory;
                colA_P_SubCatID.DisplayMember = "APSubCategoryName";
                colA_P_SubCatID.ValueMember = "AP_SubCategoryID";

                DataTable dtPOSM = new APMaterialDAO().SelectAllWithAPSubCat();
                _bdUnfilteredPOSM = new BindingSource();
                DataView undv = new DataView(dtPOSM);

                _bdUnfilteredPOSM.DataSource = undv;
                colA_PID.DataSource = _bdUnfilteredPOSM;
                colA_PID.DisplayMember = "APMaterialName";
                colA_PID.ValueMember = "AP_MaterialID";

                _bdFilteredPOSM = new BindingSource();
                DataView fdv = new DataView(dtPOSM);
                _bdFilteredPOSM.DataSource = fdv;

                // Load and bind brand
                colBrand.DataSource = new BrandBL().GetAll();
                colBrand.ValueMember = "BrandID";
                colBrand.DisplayMember = "BrandName";

                // Load deparment
                cmbDepartment.DataSource = new DepartmentBL().GetAll();
                if (cmbDepartment.DataSource != null)
                    cmbDepartment.SelectedValue = (int)PTIC.Common.Enum.PredefinedDepartment.Marketing;
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
            }            
        }

        private void LoadNBindByA_P_UsageID(int A_P_UsageID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // Load A_P_Usage
                DataTable master = new A_P_UsageBL().GetByA_P_UsageID(A_P_UsageID, conn);
                if (master.Rows.Count > 0)
                {                    
                    // Load customer
                    cmbCustomerName.SelectedValue = DataTypeParser.Parse(master.Rows[0]["CusID"], typeof(int), -1);
                    // Load employee
                    cmbEmployeeName.SelectedValue = DataTypeParser.Parse(master.Rows[0]["SalesPersonID"], typeof(int), -1);
                    // Load department
                    cmbDepartment.SelectedValue = DataTypeParser.Parse(master.Rows[0]["DeptID"], typeof(int), -1);
                    // Vehicle
                    cmbVehicle.SelectedValue = DataTypeParser.Parse(master.Rows[0]["VenID"], typeof(int), -1);
                    // Date
                    dtpDate.Value = (DateTime)DataTypeParser.Parse(master.Rows[0]["Date"], typeof(DateTime), DateTime.Now);
                    // Advertisement
                    // IsPTIC
                }
                // Load A_P_UsageDetail
                dgvAPUsageDetail.DataSource = new A_P_UsageDetailBL().GetByA_P_UsageID(A_P_UsageID, conn);
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void SetValuesBySelectedCustomer(DataRowView selectedCustomer)
        {
            txtContactPerson.Text = (string)DataTypeParser.Parse(selectedCustomer["ConPersonName"], typeof(string), string.Empty);
            txtContactPersonPhNo.Text = (string)DataTypeParser.Parse(selectedCustomer["MobilePhone"], typeof(string), string.Empty);
            txtCustomerType.Text = (string)DataTypeParser.Parse(selectedCustomer["CusTypeName"], typeof(string), string.Empty);
            // date
            // vehicle
            txtPh1.Text = (string)DataTypeParser.Parse(selectedCustomer["Phone1"], typeof(string), string.Empty);
            txtPh2.Text = (string)DataTypeParser.Parse(selectedCustomer["Phone2"], typeof(string), string.Empty);
            string address = string.Empty;
            // No            
            //address += (string)DataTypeParser.Parse(selectedCustomer["Hno"], typeof(string), string.Empty) + ", ";
            //// Street
            //address += (string)DataTypeParser.Parse(selectedCustomer["Street"], typeof(string), string.Empty) + ", ";
            //// Quarter
            //address += (string)DataTypeParser.Parse(selectedCustomer["Quartar"], typeof(string), string.Empty) + ", ";
            //// Township
            //address += (string)DataTypeParser.Parse(selectedCustomer["Township"], typeof(string), string.Empty) + ", ";
            //// Town
            //address += (string)DataTypeParser.Parse(selectedCustomer["Town"], typeof(string), string.Empty) + ", ";
            //// State / Division
            //address += (string)DataTypeParser.Parse(selectedCustomer["StateDivisionName"], typeof(string), string.Empty);

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
            
            // Disable read-write to fields
            DisableReadWrite();
        }

        private void ClearValues()
        {
            // enable read-write to fields
            EnableReadWrite();
            // clear fields
            txtContactPerson.Clear();
            txtContactPersonPhNo.Clear();
            txtCustomerType.Clear();
            // date
            // vehicle
            txtPh1.Clear();
            txtPh2.Clear();
            txtAddress.Clear();
        }

        private void EnableReadWrite()
        {
            txtContactPerson.ReadOnly = false;
            txtContactPersonPhNo.ReadOnly = false;
            txtCustomerType.ReadOnly = false;
            // date
            // vehicle
            txtPh1.ReadOnly = false;
            txtPh2.ReadOnly = false;
            txtAddress.ReadOnly = false;
        }

        private void DisableReadWrite()
        {
            txtContactPerson.ReadOnly = true;
            txtContactPersonPhNo.ReadOnly = true;
            txtCustomerType.ReadOnly = true;
            // date
            // vehicle
            txtPh1.ReadOnly = true;
            txtPh2.ReadOnly = true;
            txtAddress.ReadOnly = true;
        }

        private void SetBoundFieldNColumnIndex()
        {
            // Disable auto generating columns
            dgvAPUsageDetail.AutoGenerateColumns = false;

            // Get column index of grid combo
            this._indexAPCategoryColumn = dgvAPUsageDetail.Columns.IndexOf(dgvAPUsageDetail.Columns[3]);
            this._indexAPSubCatColumn = dgvAPUsageDetail.Columns.IndexOf(dgvAPUsageDetail.Columns[4]);
            this._indexAPColumn = dgvAPUsageDetail.Columns.IndexOf(dgvAPUsageDetail.Columns[5]);

            //colAP_CategoryID.DisplayMember = "CategoryName";
            //colAP_CategoryID.ValueMember = "APCategoryID";
            // A&P type data bound column
            //colA_P_SubCatID.DisplayMember = "APSubCategoryName";
            //colA_P_SubCatID.ValueMember = "APSubCategoryID";
            // A&P data bound column
            //colA_PID.DisplayMember = "APMaterialName";
            //colA_PID.ValueMember = "A_P_MaterialID";
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Instantiate a new A & P Usage
        /// </summary>
        public frmA_PUsage()
        {
            InitializeComponent();
            // Load and bind necessary data
            LoadNBindNecessaryData();
            SetBoundFieldNColumnIndex();
            // Load and bind schema
            LoadNBindByA_P_UsageID(-1);
            DataUtil.AddInitialNewRow(dgvAPUsageDetail);
        }
        
        public frmA_PUsage(int? A_P_UsageID, int cusID)
           // : this()
        {
            InitializeComponent();
            // Load and bind necessary data
            LoadNBindNecessaryData();
            SetBoundFieldNColumnIndex();
            this.cmbCustomerName.SelectedValue = cusID;
            this._A_P_UsageID = A_P_UsageID;
            int intA_P_UsageID = (int)DataTypeParser.Parse(this._A_P_UsageID, typeof(int), -1);
            // Load A P Usage and detail
            LoadNBindByA_P_UsageID(intA_P_UsageID);
            DataUtil.AddInitialNewRow(dgvAPUsageDetail);
        }
        #endregion

        #region Inner Class
        public class A_PUsageSaveEventArgs : EventArgs
        {
            private int? _A_PUsageID = null;
            public A_PUsageSaveEventArgs(int? A_PUsageID)
            {
                this._A_PUsageID = A_PUsageID;
            }
            public int? A_PUsageID
            {
                get { return this._A_PUsageID; }
            }
        }
        #endregion

        private void dgvAPUsageDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colA_PID.Index)
                {
                    int AP_SubCat = (int)DataTypeParser.Parse(this.dgvAPUsageDetail[e.ColumnIndex - 1, e.RowIndex].Value, typeof(int), 0);
                    if (AP_SubCat == 0) return;
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvAPUsageDetail[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = _bdFilteredPOSM;

                    this._bdFilteredPOSM.Filter = "AP_SubCategoryID = " + this.dgvAPUsageDetail[e.ColumnIndex - 1, e.RowIndex].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvAPUsageDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.colA_PID.Index)
                {
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvAPUsageDetail[e.ColumnIndex, e.RowIndex];
                    dgcb.DataSource = _bdUnfilteredPOSM;
                    //  this.bdfilteredPOSM.RemoveFilter();
                }

                if (dgvAPUsageDetail.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colQty.Index)
                {
                    dgvAPUsageDetail.Rows[e.RowIndex].ErrorText = String.Empty;
                    dgvAPUsageDetail.CurrentRow.Cells[colQty.Index].Value = 0;
                }
            }
            catch
            {
            }
        }

        private void dgvAPUsageDetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvAPUsageDetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

    }
}

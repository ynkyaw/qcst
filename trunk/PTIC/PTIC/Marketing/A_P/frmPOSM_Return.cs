/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/13 (yyyy/MM/dd)
 * Description: POSM return form
 */
using System;using PTIC.Common;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using log4net.Config;
using PTIC.Util;
using log4net;
using System.Data.SqlClient;
using PTIC.Common.BL;
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;

namespace PTIC.VC.Marketing.A_P
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmPOSM_Return : Form
    {
        /// <summary>
        /// Logger for frmPosmReturn
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmPOSM_Return));

        /// <summary>
        /// 
        /// </summary>
        private BindingSource _bdAPSubCategory, _bdFilteredPOSM, _bdUnfilteredPOSM;

        /// <summary>
        /// 
        /// </summary>
        private DataTable _dtDepartment = null;

        /// <summary>
        /// 
        /// </summary>
        private DataTable _dtVehicles = null;

        /// <summary>
        /// 
        /// </summary>
        private DataTable _dtEmployee = null;

        private AP_Return _AP_Return = null;

        #region Events
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvReturnDetail.CurrentCell.ColumnIndex;
                int iRow = dgvReturnDetail.CurrentCell.RowIndex;
                if (iColumn == dgvReturnDetail.Columns[colRemark.Index].Index)
                {
                    if (iRow + 1 >= dgvReturnDetail.Rows.Count)
                    {
                        DataTable dtAPEnquiry = dgvReturnDetail.DataSource as DataTable;
                        DataRow newRow = dtAPEnquiry.NewRow();
                        dtAPEnquiry.Rows.Add(newRow);
                        this.dgvReturnDetail.DataSource = dtAPEnquiry;
                        dgvReturnDetail[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvReturnDetail.CurrentCell = dgvReturnDetail[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvReturnDetail.CurrentCell = dgvReturnDetail[dgvReturnDetail.CurrentCell.ColumnIndex + 1, dgvReturnDetail.CurrentCell.RowIndex];
                    }
                    catch (Exception)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void lblFilter_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Visible)
            {
                pnlFilter.Visible = false;
                lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
                pnlEntry.Visible = true;
            }
            else
            {
                pnlFilter.Visible = true;
                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
                pnlEntry.Visible = false;
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmA_PMain));
            this.Close();
        }

        private void cmbFromTo_DepartmentVehicle_SelectedValueChanged(object sender, EventArgs e)
        {
            if (sender == null)
                return;
            //if(rdoFromDept.Checked && rdoToDept.Checked)
            //    CheckDepartmentSelection(sender);
            //else if(rdoFromVen.Checked && rdoToVen.Checked)
            //    CheckVehicleSelection(sender);

            CheckDepartmentSelection(sender);
            CheckVehicleSelection(sender);

            ///** FromDepartment and ToDepartment must not be same **/
            //try
            //{
            //    int fromDeptID = (int)DataTypeParser.Parse(cmbFromDepartment.SelectedValue, typeof(int),
            //            (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
            //    int toDeptID = (int)DataTypeParser.Parse(cmbToDepartment.SelectedValue, typeof(int),
            //        (int)PTIC.Common.Enum.PredefinedDepartment.AdminNHR);
            //    if (fromDeptID == toDeptID)
            //    {
            //        if (this._dtDepartment != null)
            //            if(sender == cmbToDepartment)
            //                cmbFromDepartment.SelectedValue = DataUtil.GetRandomNumber(
            //                (int)this._dtDepartment.Rows[0]["ID"], (int)this._dtDepartment.Rows[this._dtDepartment.Rows.Count - 1]["ID"],
            //                new int[] { (int)cmbToDepartment.SelectedValue});
            //            else
            //                cmbToDepartment.SelectedValue = DataUtil.GetRandomNumber(
            //                (int)this._dtDepartment.Rows[0]["ID"], (int)this._dtDepartment.Rows[this._dtDepartment.Rows.Count - 1]["ID"],
            //                new int[] { (int)cmbFromDepartment.SelectedValue });
            //        else
            //        {
            //            cmbFromDepartment.SelectedValue = -1; // Set unselected
            //            cmbToDepartment.SelectedValue = -1;
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    cmbFromDepartment.SelectedValue = -1;
            //    cmbToDepartment.SelectedValue = -1;
            //}
        }

        private void cmbEmployee_SelectedValueChanged(object sender, EventArgs e)
        {
            if (sender == null)
                return;
            /** FromEmployee and ToEmployee must not be same **/
            try
            {
                int fromEmployeeID = (int)DataTypeParser.Parse(cmbFromEmployee.SelectedValue, typeof(int), -1);
                int toEmployeeID = (int)DataTypeParser.Parse(cmbToEmployee.SelectedValue, typeof(int), 0);

                if (fromEmployeeID == toEmployeeID)
                {
                    if (this._dtEmployee != null)
                    {
                        if (sender == cmbToEmployee)
                            cmbFromEmployee.SelectedValue = DataUtil.GetRandomNumber(
                                (int)this._dtEmployee.Rows[0]["EmployeeID"], (int)this._dtEmployee.Rows[this._dtEmployee.Rows.Count - 1]["EmployeeID"],
                                new int[] { (int)cmbToEmployee.SelectedValue });
                        else
                            cmbToEmployee.SelectedValue = DataUtil.GetRandomNumber(
                                (int)this._dtEmployee.Rows[0]["EmployeeID"], (int)this._dtEmployee.Rows[this._dtEmployee.Rows.Count - 1]["EmployeeID"],
                                new int[] { (int)cmbFromEmployee.SelectedValue });
                    }
                    else
                    {
                        cmbFromEmployee.SelectedValue = -1; // Set unselected
                        cmbToEmployee.SelectedValue = -1;
                    }
                }
            }
            catch (Exception)
            {
                cmbFromEmployee.SelectedValue = -1;
                cmbToEmployee.SelectedValue = -1;
            }
        }

        private void dgvReturnDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colA_P_Material.Index)
                {
                    int AP_SubCat = (int)DataTypeParser.Parse(this.dgvReturnDetail[e.ColumnIndex - 1, e.RowIndex].Value, typeof(int), 0);
                    if (AP_SubCat == 0) return;
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvReturnDetail[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = _bdFilteredPOSM;

                    this._bdFilteredPOSM.Filter = "AP_SubCategoryID = " + this.dgvReturnDetail[e.ColumnIndex - 1, e.RowIndex].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvReturnDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.colA_P_Material.Index)
                {
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvReturnDetail[e.ColumnIndex, e.RowIndex];
                    dgcb.DataSource = _bdUnfilteredPOSM;
                    //  this.bdfilteredPOSM.RemoveFilter();
                }
            }
            catch
            {
            }

            if (dgvReturnDetail.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colReturnQty.Index)
            {
                dgvReturnDetail.Rows[e.RowIndex].ErrorText = String.Empty;
                dgvReturnDetail.CurrentRow.Cells[colReturnQty.Index].Value = 0;
            }
            else if (dgvReturnDetail.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colA_P_Material.Index)
            {
                dgvReturnDetail.Rows[e.RowIndex].ErrorText = String.Empty;
                dgvReturnDetail.CurrentRow.Cells[colA_P_Material.Index].Value = -1;
                //  dgvPosmPurchasedIn.CurrentRow.Cells[colPosm.Index].Value = 1;
            }
        }

        private void dgvReturnDetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvReturnDetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvReturnDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            }
        }

        private void dgvReturnDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Do nothing
        }

        private void dgvReturnDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int newInteger = 0;
            //   decimal newDecimal = 0;
            var dgv = sender as DataGridView;
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (e.ColumnIndex == colA_P_Material.Index)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells["colA_P_Material"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
                        if (row.Cells["colA_P_Material"].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed!";
                            MessageBox.Show("Duplicate not allowed!", "တားမြစ်ချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
            else if (e.ColumnIndex == colReturnQty.Index)
            {
                if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger <= 0)
                {
                    dgv.Rows[e.RowIndex].ErrorText = "အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။";
                    ToastMessageBox.Show("အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။", Color.Red);
                }
            }
        }

        private void cmbFromDeptOrVen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DeptID = (int)DataTypeParser.Parse(cmbFromDeptOrVen.SelectedValue, typeof(int), -1);       

            DataTable dtEmployeesByDept = DataUtil.GetDataTableBy(_dtEmployee, "DeptID", DeptID);
            cmbFromEmployee.DataSource = dtEmployeesByDept;
            cmbFromEmployee.ValueMember = "EmployeeID";
            cmbFromEmployee.DisplayMember = "EmpName";
        }

        private void cmbToDeptOrVen_SelectedIndexChanged(object sender, EventArgs e)
        {
           int DeptID = (int)DataTypeParser.Parse(cmbToDeptOrVen.SelectedValue, typeof(int), -1);
          
            DataTable dtEmployeesByDept = DataUtil.GetDataTableBy(_dtEmployee, "DeptID", DeptID);
            cmbToEmployee.DataSource = dtEmployeesByDept;
            cmbToEmployee.ValueMember = "EmployeeID";
            cmbToEmployee.DisplayMember = "EmpName";
        }

        private void rdoFromDept_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbFromDeptOrVen.DataSource = this._dtDepartment;
        }

        private void rdoFromVen_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbFromDeptOrVen.DataSource = this._dtVehicles;
            this.cmbFromEmployee.DataSource = this._dtEmployee;
        }

        private void rdoToDept_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbToDeptOrVen.DataSource = this._dtDepartment.Copy();
        }

        private void rdoToVen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFromVen.Checked && rdoToVen.Checked)
            {               
                MessageBox.Show("ကားအချင်းချင်း Return လုပ်ခွင့်မရှိပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                rdoToDept.Checked = true;
                return;
            }

            this.cmbToDeptOrVen.DataSource = this._dtVehicles.Copy();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReturnDetail.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete a selected row?", "Remove confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;

                //if (MessageBox.Show("Are you sure you want to delete a selected row?", "Remove confirmation",
                //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                //{
                //    dgvReturnDetail.Rows.Remove(dgvReturnDetail.CurrentRow);
                //    DataUtil.AddInitialNewRow(dgvReturnDetail);
                //    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                //}

                DataGridViewRow selectedRow = dgvReturnDetail.CurrentRow;
                if ((selectedRow.DataBoundItem as DataRowView).Row.RowState == DataRowState.Added)
                {
                    // Delete row just from GridView because it is a new row that has not been in Database
                    dgvReturnDetail.Rows.RemoveAt(selectedRow.Index);
                    return;
                }
                int ap_ReturnDetailID = (int)DataTypeParser.Parse(selectedRow.Cells[colAP_ReturnDetailID.Index].Value, typeof(int), -1);
                if (ap_ReturnDetailID == -1)
                {
                    MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Delete a selected AP material
                    AP_Return ap_Return = new AP_Return();
                    if (rdoFromDept.Checked)
                        ap_Return.FromDeptID = (int?)DataTypeParser.Parse(cmbFromDeptOrVen.SelectedValue, typeof(int), null);
                    else
                        ap_Return.FromVenID = (int?)DataTypeParser.Parse(cmbFromDeptOrVen.SelectedValue, typeof(int), null);

                    if (rdoToDept.Checked)
                        ap_Return.ToDeptID = (int?)DataTypeParser.Parse(cmbToDeptOrVen.SelectedValue, typeof(int), null);
                    else
                        ap_Return.ToVenID = (int?)DataTypeParser.Parse(cmbToDeptOrVen.SelectedValue, typeof(int), null);
                    DeleteA_P_ReturnDetail(ap_ReturnDetailID, ap_Return);
                }
            }
            else
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete, Color.Red);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvReturnDetail.DataSource as DataTable);
            dgvReturnDetail.CurrentCell = dgvReturnDetail.Rows[dgvReturnDetail.RowCount - 1].Cells[colA_P_SubCategory.Index];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReturnNo.Text))
            {
                MessageBox.Show(Resource.err_fill_return_no, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Save();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime date = dtpKW_Date.Value;
            int returnedDepartmentID = (int)DataTypeParser.Parse(cmbKW_FromDepartment.SelectedValue, typeof(int), -1);
            Search(date, returnedDepartmentID);
        }
        #endregion

        #region Private Methods
        private void LoadNBindNecessaryData()
        {            
            try
            {                                
                // Load and bind deparment
                this._dtDepartment = new DepartmentBL().GetAll();
                /** Change column names to common names to be used as a datasource in a single ComboBox **/
                this._dtDepartment.Columns["DeptName"].ColumnName = "Despt";
                // Load and bind vehicle
                this._dtVehicles = new VehicleBL().GetAll();
                this._dtVehicles.Columns["VehicleID"].ColumnName = "ID";
                this._dtVehicles.Columns["VenNo"].ColumnName = "Despt";

                this.cmbFromDeptOrVen.DataSource = this._dtDepartment;
                this.cmbToDeptOrVen.DataSource = this._dtDepartment.Copy();
                this.cmbKW_FromDepartment.DataSource = this._dtDepartment.Copy();

                //cmbFromDepartment.DataSource = _dtDepartment;
                //cmbToDepartment.DataSource = _dtDepartment.Copy();

                //if (this.cmbDepartment.DataSource != null)
                //    cmbDepartment.SelectedValue = (int)DataTypeParser.Parse(GlobalCache.LoginEmployee.DeptID, typeof(int),
                //        (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                if (cmbToDeptOrVen.DataSource != null)
                    cmbToDeptOrVen.SelectedValue = GlobalCache.LoginEmployee.DeptID;

                // Load and bind employee
                this._dtEmployee = new EmployeeBL().GetAll();
                cmbFromEmployee.DataSource = _dtEmployee;
                cmbToEmployee.DataSource = _dtEmployee.Copy();
                if (_dtEmployee != null)
                    cmbToEmployee.SelectedValue = GlobalCache.LoginEmployee.ID;

                // Load and bind brand
                //colBrand.DataSource = new BrandBL().GetAll(conn);
                //colBrand.ValueMember = "BrandID";
                //colBrand.DisplayMember = "BrandName";

                _bdAPSubCategory = new BindingSource();
                _bdAPSubCategory.DataSource = new APSubCategoryDAO().SelectAllAPSubCat();

                colA_P_SubCategory.DataSource = _bdAPSubCategory;
                colA_P_SubCategory.DisplayMember = "APSubCategoryName";
                colA_P_SubCategory.ValueMember = "AP_SubCategoryID";

                DataTable dtPOSM = new APMaterialDAO().SelectAllWithAPSubCat();
                _bdUnfilteredPOSM = new BindingSource();
                DataView undv = new DataView(dtPOSM);

                _bdUnfilteredPOSM.DataSource = undv;
                colA_P_Material.DataSource = _bdUnfilteredPOSM;
                colA_P_Material.DisplayMember = "APMaterialName";
                colA_P_Material.ValueMember = "AP_MaterialID";

                _bdFilteredPOSM = new BindingSource();
                DataView fdv = new DataView(dtPOSM);
                _bdFilteredPOSM.DataSource = fdv;

                // Bind POSM usage purpose
                colReturnPurpose.DataSource = GetReturnPurposeEnum();
                colReturnPurpose.ValueMember = "ReturnPurpose";
                colReturnPurpose.DisplayMember = "ReturnPurposeDespt";
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }            
        }

        private object GetPOSM_ReturnTableStructure()
        {
            DataTable dtPOSM = new DataTable();
            DataColumn cAP_ReturnDetailID = new DataColumn("AP_ReturnDetailID", typeof(int));
            DataColumn cAP_Subcategory = new DataColumn("APSubCategoryID", typeof(int));
            DataColumn cAP_Material = new DataColumn("A_P_MaterialID", typeof(int));
            DataColumn cReturnQty = new DataColumn("ReturnQty", typeof(int));
            DataColumn cReturnPurpose = new DataColumn("ReturnPurpose", typeof(int));
            DataColumn cRemark = new DataColumn("Remark", typeof(string));
            DataColumn cFromDeptID = new DataColumn("FromDeptID", typeof(int));
            DataColumn cFromVenID = new DataColumn("FromVenID", typeof(int));
            DataColumn cFromEmpID = new DataColumn("FromEmpID", typeof(int));
            DataColumn cToDeptID = new DataColumn("ToDeptID", typeof(int));
            DataColumn cToVenID = new DataColumn("ToVenID", typeof(int));
            DataColumn cToEmpID = new DataColumn("ToEmpID", typeof(int));
            DataColumn cReturnDate = new DataColumn("ReturnDate", typeof(int));
            DataColumn cReturnNo = new DataColumn("ReturnNo", typeof(int));

            dtPOSM.Columns.AddRange(new DataColumn[] { 
                cAP_ReturnDetailID, cAP_Subcategory, cAP_Material, cReturnQty, cReturnPurpose, cRemark,
                cFromDeptID, cFromVenID, cFromEmpID, cToDeptID, cToVenID, cToEmpID, cReturnDate, cReturnNo
            });
            return dtPOSM;
        }

        private DataTable GetReturnPurposeEnum()
        {
            DataTable dtUsagePurpose = new DataTable();
            DataColumn cPurpose = new DataColumn("ReturnPurpose", typeof(int));
            DataColumn cPurposeDespt = new DataColumn("ReturnPurposeDespt", typeof(string));
            dtUsagePurpose.Columns.AddRange(new DataColumn[] 
            {
                cPurpose, cPurposeDespt
            });
            DataRow nRow = dtUsagePurpose.NewRow();

            nRow[cPurpose] = 0;
            nRow[cPurposeDespt] = "Outlet များပေး";
            dtUsagePurpose.Rows.Add(nRow);

            nRow = dtUsagePurpose.NewRow();
            nRow[cPurpose] = 1;
            nRow[cPurposeDespt] = "Retailer များပေး";
            dtUsagePurpose.Rows.Add(nRow);

            nRow = dtUsagePurpose.NewRow();
            nRow[cPurpose] = 2;
            nRow[cPurposeDespt] = "ခရီးစဉ်";
            dtUsagePurpose.Rows.Add(nRow);

            nRow = dtUsagePurpose.NewRow();
            nRow[cPurpose] = 3;
            nRow[cPurposeDespt] = "လက်ဆောင်ပေး";
            dtUsagePurpose.Rows.Add(nRow);

            nRow = dtUsagePurpose.NewRow();
            nRow[cPurpose] = 4;
            nRow[cPurposeDespt] = "ရုံးသုံး";
            dtUsagePurpose.Rows.Add(nRow);

            nRow = dtUsagePurpose.NewRow();
            nRow[cPurpose] = 5;
            nRow[cPurposeDespt] = "အခြား";
            dtUsagePurpose.Rows.Add(nRow);

            return dtUsagePurpose;
        }

        private void CheckDepartmentSelection(object sender)
        {
            if (rdoFromDept.Checked && rdoToDept.Checked)
            {
                /** FromDepartment and ToDepartment must not be same **/
                try
                {
                    int fromDeptID = (int)DataTypeParser.Parse(cmbFromDeptOrVen.SelectedValue, typeof(int),
                            (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                    int toDeptID = (int)DataTypeParser.Parse(cmbToDeptOrVen.SelectedValue, typeof(int),
                        (int)PTIC.Common.Enum.PredefinedDepartment.AdminNHR);
                    if (fromDeptID == toDeptID)
                    {
                        if (this._dtDepartment != null)
                        {
                            if (sender == cmbToDeptOrVen)
                                cmbFromDeptOrVen.SelectedValue = DataUtil.GetRandomNumber(
                                (int)this._dtDepartment.Rows[0]["ID"], (int)this._dtDepartment.Rows[this._dtDepartment.Rows.Count - 1]["ID"],
                                new int[] { (int)cmbToDeptOrVen.SelectedValue });
                            else
                                cmbToDeptOrVen.SelectedValue = DataUtil.GetRandomNumber(
                                (int)this._dtDepartment.Rows[0]["ID"], (int)this._dtDepartment.Rows[this._dtDepartment.Rows.Count - 1]["ID"],
                                new int[] { (int)cmbFromDeptOrVen.SelectedValue });
                        }
                        else
                        {
                            cmbFromDeptOrVen.SelectedValue = -1; // Set unselected
                            cmbToDeptOrVen.SelectedValue = -1;
                        }
                    }
                }
                catch (Exception)
                {
                    cmbFromDeptOrVen.SelectedValue = -1;
                    cmbToDeptOrVen.SelectedValue = -1;
                }
            }
        }

        private void CheckVehicleSelection(object sender)
        {
            if (rdoFromVen.Checked && rdoToVen.Checked)
            {
                /** FromVehicle and ToVehicle must not be same **/
                try
                {
                    int fromVenID = (int)DataTypeParser.Parse(cmbFromDeptOrVen.SelectedValue, typeof(int), -1);
                    int toVenID = (int)DataTypeParser.Parse(cmbToDeptOrVen.SelectedValue, typeof(int), -1);
                    if (fromVenID == toVenID)
                    {
                        if (this._dtVehicles != null)
                        {
                            if (sender == cmbToDeptOrVen)
                                cmbFromDeptOrVen.SelectedValue = DataUtil.GetRandomNumber(
                                (int)this._dtVehicles.Rows[0]["ID"], (int)this._dtVehicles.Rows[this._dtVehicles.Rows.Count - 1]["ID"],
                                new int[] { (int)cmbToDeptOrVen.SelectedValue });
                            else
                                cmbToDeptOrVen.SelectedValue = DataUtil.GetRandomNumber(
                                (int)this._dtVehicles.Rows[0]["ID"], (int)this._dtVehicles.Rows[this._dtVehicles.Rows.Count - 1]["ID"],
                                new int[] { (int)cmbFromDeptOrVen.SelectedValue });
                        }
                        else
                        {
                            cmbFromDeptOrVen.SelectedValue = -1; // Set unselected
                            cmbToDeptOrVen.SelectedValue = -1;
                        }
                    }
                }
                catch (Exception)
                {
                    cmbFromDeptOrVen.SelectedValue = -1;
                    cmbToDeptOrVen.SelectedValue = -1;
                }
            }
        }

        private void Save()
        {
            SqlConnection conn = null;
            AP_ReturnBL AP_ReturnSaver = null;
            AP_Return ap_Return = null;
            bool isSuccessful = false;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                AP_ReturnSaver = new AP_ReturnBL();
                ap_Return = new AP_Return()
                {
                    ID = this._AP_Return != null ? this._AP_Return.ID : null,
                    ReturnDate = (DateTime)DataTypeParser.Parse(dtpReturnDate.Value, typeof(DateTime), DateTime.Now),
                    ReturnNo = (string)DataTypeParser.Parse(txtReturnNo.Text, typeof(string), null),
                    //FromDeptID = (int?)DataTypeParser.Parse(cmbFromDepartment.SelectedValue, typeof(int), null)
                    //FromVenID = (int?)DataTypeParser.Parse(cmbfromven, typeof(int), null),
                    FromEmpID = (int)DataTypeParser.Parse(cmbFromEmployee.SelectedValue, typeof(int), -1),
                    //ToDeptID = (int?)DataTypeParser.Parse(, typeof(int), null),
                    //ToVenID = (int?)DataTypeParser.Parse(, typeof(int), null),
                    ToEmpID = (int)DataTypeParser.Parse(cmbToEmployee.SelectedValue, typeof(int), -1)
                };
                if (rdoFromDept.Checked)
                    ap_Return.FromDeptID = (int?)DataTypeParser.Parse(cmbFromDeptOrVen.SelectedValue, typeof(int), null);
                else
                    ap_Return.FromVenID = (int?)DataTypeParser.Parse(cmbFromDeptOrVen.SelectedValue, typeof(int), null);

                if (rdoToDept.Checked)
                    ap_Return.ToDeptID = (int?)DataTypeParser.Parse(cmbToDeptOrVen.SelectedValue, typeof(int), null);
                else
                    ap_Return.ToVenID = (int?)DataTypeParser.Parse(cmbToDeptOrVen.SelectedValue, typeof(int), null);

                if (!ap_Return.ID.HasValue) // Add a new AP return and detail
                {
                    List<AP_ReturnDetail> newAP_ReturnDetails = new List<AP_ReturnDetail>();
                    foreach (DataGridViewRow row in dgvReturnDetail.Rows)
                    {
                        if (row.IsNewRow)
                            break;
                        AP_ReturnDetail newDetail = new AP_ReturnDetail()
                        {
                            //AP_ReturnID = (int)DataTypeParser.Parse(row.Cells[colA].Value, typeof(int), -1),
                            AP_MaterialID = (int)DataTypeParser.Parse(row.Cells[colA_P_Material.Index].Value, typeof(int), -1),
                            ReturnQty = (int)DataTypeParser.Parse(row.Cells[colReturnQty.Index].Value, typeof(int), -1),
                            ReturnPurpose = (int)DataTypeParser.Parse(row.Cells[colReturnPurpose.Index].Value, typeof(int), -1),
                            Remark = (string)DataTypeParser.Parse(row.Cells[colRemark.Index].Value, typeof(string), null),
                        };
                        
                        if(rdoFromDept.Checked)
                        {
                            int DeptID = (int)DataTypeParser.Parse(cmbFromDeptOrVen.SelectedValue, typeof(int), -1);
                            DataTable StockInDepartment = new AP_ReturnBL().GetAP_StockInDepartmentByAPID(newDetail.AP_MaterialID,DeptID);
                            if (StockInDepartment.Rows.Count < 1)
                            {
                                MessageBox.Show("ဖြည့်သွင်းထားသော A & P လုံးဝမရှိပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            int Qty = (int)DataTypeParser.Parse(StockInDepartment.Rows[0]["Qty"], typeof(int), 0);
                            string AP_MaterialName = (string)DataTypeParser.Parse(StockInDepartment.Rows[0]["APMaterialName"], typeof(string), string.Empty);
                            if (newDetail.ReturnQty > Qty)
                            {
                                MessageBox.Show(AP_MaterialName + " : " + Qty + " ခုသာကျန်သည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            int VenID = (int)DataTypeParser.Parse(cmbFromDeptOrVen.SelectedValue, typeof(int), -1);
                            DataTable StockInVen = new AP_ReturnBL().GetAP_StockInVehicleByAPID(newDetail.AP_MaterialID, VenID);
                            if (StockInVen.Rows.Count < 1)
                            {
                                MessageBox.Show("ဖြည့်သွင်းထားသော A & P လုံးဝမရှိပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            int Qty = (int)DataTypeParser.Parse(StockInVen.Rows[0]["Qty"], typeof(int), 0);
                            string AP_MaterialName = (string)DataTypeParser.Parse(StockInVen.Rows[0]["APMaterialName"], typeof(string), string.Empty);
                            if (newDetail.ReturnQty > Qty)
                            {
                                MessageBox.Show(AP_MaterialName + " : " + Qty + " ခုသာကျန်သည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        newAP_ReturnDetails.Add(newDetail);
                    }// END of foreach (DataGridViewRow row in dgvReturnDetail.Rows)
                    if (this._AP_Return == null)
                        this._AP_Return = new AP_Return();
                    // Insert new return and detail
                    this._AP_Return.ID = AP_ReturnSaver.Add(ap_Return, newAP_ReturnDetails, conn);
                    if (this._AP_Return.ID.HasValue && this._AP_Return.ID.Value > 0)
                        isSuccessful = true;
                }
                else // Update existing AP Return and detail
                {
                    // TODO: Update POSM return master

                    DataTable dt = dgvReturnDetail.DataSource as DataTable;
                    // New A_P_Return Detail (detail)
                    DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                    List<AP_ReturnDetail> newAP_ReturnDetails = new List<AP_ReturnDetail>();
                    foreach (DataRow row in dvInsert.ToTable().Rows)
                    {
                        AP_ReturnDetail newDetail = new AP_ReturnDetail()
                        {
                            AP_MaterialID = (int)DataTypeParser.Parse(row["A_P_MaterialID"], typeof(int), -1),
                            ReturnQty = (int)DataTypeParser.Parse(row["ReturnQty"], typeof(int), -1),
                            ReturnPurpose = (int)DataTypeParser.Parse(row["ReturnPurpose"], typeof(int), -1),
                            Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), null),
                        };
                        if (newDetail.AP_MaterialID != -1)
                            newAP_ReturnDetails.Add(newDetail);
                    }
                    // Add  new detail to db
                    this._AP_Return.ID = AP_ReturnSaver.Add(ap_Return, newAP_ReturnDetails, conn);
                    if (this._AP_Return.ID.HasValue && this._AP_Return.ID.Value > 0)
                        isSuccessful = true;

                    // Update A_P_Return Detail (detail)
                    DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                    if (dvUpdate.ToTable().Rows.Count > 0)
                    {
                        MessageBox.Show(Resource.err_prohibit_save_returned_ap,
                            Resource.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (isSuccessful)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    // After saved, reload data.
                    DateTime date = dtpKW_Date.Value;
                    int returnedDepartmentID = (int)DataTypeParser.Parse(cmbKW_FromDepartment.SelectedValue, typeof(int), -1);
                    Search(date, returnedDepartmentID);
                    //this.Close();
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

        private void DeleteA_P_ReturnDetail(int ap_ReturnDetailID, AP_Return ap_Return)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // Delete a selected detail
                int affectedRows = new AP_ReturnDetailBL().DeleteByID(ap_ReturnDetailID, ap_Return, conn);
                if (affectedRows > 0)
                {
                    // remove row @gridvew also
                    dgvReturnDetail.Rows.RemoveAt(dgvReturnDetail.CurrentRow.Index);
                    if (dgvReturnDetail.RowCount == 0)
                    {
                        DataUtil.AddInitialNewRow(dgvReturnDetail);
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

        private void Search(DateTime date, int returnedDepartmentID)
        {
            DataTable dtResult = new AP_ReturnDetailBL().GetBy(date, returnedDepartmentID);
            this.dgvReturnDetail.DataSource = dtResult;
            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                DataRow row = dtResult.Rows[0];
                DateTime returnedDate = (DateTime)DataTypeParser.Parse(row["ReturnDate"], typeof(DateTime), DateTime.Now);
                string returnNo = (string)DataTypeParser.Parse(row["ReturnNo"], typeof(string), string.Empty);
                int? fromDeptID = (int?)DataTypeParser.Parse(row["FromDeptID"], typeof(int), null);
                int? fromVenID = (int?)DataTypeParser.Parse(row["FromVenID"], typeof(int), null);
                int fromEmpID = (int)DataTypeParser.Parse(row["FromEmpID"], typeof(int), -1);
                int? toDeptID = (int?)DataTypeParser.Parse(row["ToDeptID"], typeof(int), null);
                int? toVenID = (int?)DataTypeParser.Parse(row["ToVenID"], typeof(int), null);
                int toEmpID = (int)DataTypeParser.Parse(row["ToEmpID"], typeof(int), -1);

                dtpReturnDate.Value = returnedDate;
                txtReturnNo.Text = returnNo;
                if (fromDeptID.HasValue)
                {
                    rdoFromDept.Checked = true;
                    cmbFromDeptOrVen.SelectedValue = fromDeptID;
                }
                else
                {
                    rdoFromVen.Checked = true;
                    cmbFromDeptOrVen.SelectedValue = fromVenID;
                }
                if (toDeptID.HasValue)
                {
                    rdoToDept.Checked = true;
                    cmbToDeptOrVen.SelectedValue = toDeptID;
                }
                else
                {
                    rdoToVen.Checked = true;
                    cmbToDeptOrVen.SelectedValue = toVenID;
                }
                cmbFromEmployee.SelectedValue = fromEmpID;
                cmbToEmployee.SelectedValue = toEmpID;
                // Set A P return id
                if (this._AP_Return == null)
                    this._AP_Return = new AP_Return();
                this._AP_Return.ID = (int?)DataTypeParser.Parse(row["AP_ReturnID"], typeof(int), null);
            }
        }
        #endregion

        #region Constructors
        public frmPOSM_Return()
        {
            InitializeComponent();
            pnlFilter.Visible = false;
            lblFilter.Text = "▼ Show Advance Search"; //Show filter information";

            // Disable auto generating columns
            dgvReturnDetail.AutoGenerateColumns = false;
            // Configure logger
            XmlConfigurator.Configure();
            // Load and bind necessary data : brand, AP sub-category...
            LoadNBindNecessaryData();
            // Bind POSM data structure
            dgvReturnDetail.DataSource = GetPOSM_ReturnTableStructure();
            // Add an initial new row
            DataUtil.AddInitialNewRow(dgvReturnDetail);
        }

        #endregion

        private void frmPOSM_Return_Load(object sender, EventArgs e)
        {
           
        }

        private void frmPOSM_Return_Load_1(object sender, EventArgs e)
        {
            cmbToDeptOrVen.SelectedValue = 8;//Marketing
            cmbToDeptOrVen.Enabled = false;
        }

        //private void dgvReturnDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    int newInteger = 0;
        //    //   decimal newDecimal = 0;
        //    var dgv = sender as DataGridView;
        //    if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
        //    if (e.ColumnIndex == colA_P_Material.Index)
        //    {
        //        foreach (DataGridViewRow row in dgv.Rows)
        //        {
        //            if (row.Index != e.RowIndex & !row.IsNewRow)
        //            {
        //                if (row.Cells["colA_P_Material"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
        //                if (row.Cells["colA_P_Material"].FormattedValue.ToString() == e.FormattedValue.ToString())
        //                {
        //                    dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed!";
        //                    MessageBox.Show("Duplicate not allowed!", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                }
        //            }
        //        }
        //    }
        //    else if (e.ColumnIndex == colReturnQty.Index)
        //    {
        //        if (!int.TryParse(e.FormattedValue.ToString(),
        //                out newInteger) || newInteger <= 0)
        //        {
        //            dgv.Rows[e.RowIndex].ErrorText = "အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။";
        //            ToastMessageBox.Show("အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။", Color.Red);
        //        }
        //    }
        //}

        //private void cmbFromDeptOrVen_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int DeptID = (int)DataTypeParser.Parse(cmbFromDeptOrVen.SelectedValue, typeof(int), -1);

        //    DataTable dtEmployeesByDept = DataUtil.GetDataTableBy(_dtEmployee, "DeptID", DeptID);
        //    cmbFromEmployee.DataSource = dtEmployeesByDept;
        //    cmbFromEmployee.ValueMember = "EmployeeID";
        //    cmbFromEmployee.DisplayMember = "EmpName";
        //}

        //private void cmbToDeptOrVen_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int DeptID = (int)DataTypeParser.Parse(cmbToDeptOrVen.SelectedValue, typeof(int), -1);

        //    DataTable dtEmployeesByDept = DataUtil.GetDataTableBy(_dtEmployee, "DeptID", DeptID);
        //    cmbToEmployee.DataSource = dtEmployeesByDept;
        //    cmbToEmployee.ValueMember = "EmployeeID";
        //    cmbToEmployee.DisplayMember = "EmpName";
        //}
    }
}

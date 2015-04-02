using System;
using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Util;
using PTIC.Common.BL;
using System.Data.SqlClient;
using PTIC.Sale.BL;
using PTIC.Util;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;

namespace PTIC.VC.Marketing.A_P
{
    public partial class frmPosmRequest : Form
    {
        private int? AP_Request = null;

        public delegate void POSM_RequestSaveHandler(object sender, POSM_RequestEventArgs e);

        public event POSM_RequestSaveHandler POSM_RequestSavedHandler;

        DataTable dtAPSubCategory, dtPOSM;

        BindingSource bdAPSubCategory, bdfilteredPOSM, bdunfilteredPOSM;

        ComboBox cmb;

        DataTable dtEmployees = null;

        DataTable dtAP_RequestWithDetail = null;

        DataTable dtAPTransferList = null;

        #region Constructors

        public frmPosmRequest()
        {
            InitializeComponent();
            // Select Department
            rdoDept.Checked = true;
            LoadNBind();
            //  DataGridView Intialize Row
            DataUtil.AddInitialNewRow(dgvPosmRequest);
        }

        public frmPosmRequest(int AP_RequestID)
        {
            InitializeComponent();
            // Select Department
            LoadNBind();
            rdoDept.Checked = true;
            dgvPosmRequest.AutoGenerateColumns = false;
            DataTable dtPosmRequestDetail = DataUtil.GetDataTableBy(dtAP_RequestWithDetail, "AP_RequestID", AP_RequestID);
            if (dtPosmRequestDetail.Rows.Count > 0)
            {
                int? VenID = (int?)DataTypeParser.Parse(dtPosmRequestDetail.Rows[0]["RequestVenID"], typeof(int), null);
                int? DeptID = (int)DataTypeParser.Parse(dtPosmRequestDetail.Rows[0]["RequestDeptID"], typeof(int), null);
                int EmployeeID = (int)DataTypeParser.Parse(dtPosmRequestDetail.Rows[0]["RequesterID"], typeof(int), -1);
                DateTime RequestDate = (DateTime)DataTypeParser.Parse(dtPosmRequestDetail.Rows[0]["RequestDate"], typeof(int), DateTime.Now);

                int? FromDeptID = (int)DataTypeParser.Parse(dtPosmRequestDetail.Rows[0]["FromDeptID"],typeof(int),-1);
               // int? ToVenID = (int)DataTypeParser.Parse(dtPosmRequestDetail.Rows[0]["ToVenID"], typeof(int), null);
                int FromEmpID = (int)DataTypeParser.Parse(dtPosmRequestDetail.Rows[0]["FromEmpID"], typeof(int), -1);

                cmbGiverDept.SelectedValue = FromDeptID;
                cmbGiver.SelectedValue = FromEmpID;

                dtpRequestDate.Value = RequestDate;
                if (VenID == null)
                {
                    cmbDeptVen.SelectedValue = DeptID;
                }
                else
                {
                    cmbDeptVen.SelectedValue = VenID;
                }
                cmbEmployee.SelectedValue = EmployeeID;
            }

            DataTable dtPosmRequest = DataUtil.GetDataTableBy(this.dtAP_RequestWithDetail, "AP_RequestID", AP_RequestID);

            if ((int?)DataTypeParser.Parse(dtPosmRequest.Rows[0]["ToEmpID"], typeof(int), null) != null)
            {
                dgvPosmRequest.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnSave.Enabled = false;
            }
            dgvPosmRequest.DataSource = dtPosmRequest;
            colDescription.ValueMember = "RequestPurpose";
        }


        public frmPosmRequest(int? AP_RequestID)
        {
            InitializeComponent();
            // Select Department
            LoadNBind();
            rdoDept.Checked = true;
            dgvPosmRequest.AutoGenerateColumns = false;
            DataTable dtPosmRequestDetail = DataUtil.GetDataTableBy(dtAP_RequestWithDetail, "AP_RequestID", AP_RequestID);
            if (dtPosmRequestDetail.Rows.Count > 0)
            {
                int? VenID = (int?)DataTypeParser.Parse(dtPosmRequestDetail.Rows[0]["RequestVenID"], typeof(int), null);
                int? DeptID = (int?)DataTypeParser.Parse(dtPosmRequestDetail.Rows[0]["RequestDeptID"], typeof(int), null);
                int EmployeeID = (int)DataTypeParser.Parse(dtPosmRequestDetail.Rows[0]["RequesterID"], typeof(int), -1);
                DateTime RequestDate = (DateTime)DataTypeParser.Parse(dtPosmRequestDetail.Rows[0]["RequestDate"], typeof(int), DateTime.Now);
                dtpRequestDate.Value = RequestDate;
                if (VenID == null)
                {
                    cmbDeptVen.SelectedValue = DeptID;
                }
                else
                {
                    cmbDeptVen.SelectedValue = VenID;
                }
                cmbEmployee.SelectedValue = EmployeeID;
            }

            DataTable dtPosmRequest = DataUtil.GetDataTableBy(this.dtAP_RequestWithDetail, "AP_RequestID", AP_RequestID);

            if ((int?)DataTypeParser.Parse(dtPosmRequest.Rows[0]["ToEmpID"], typeof(int), null) != null)
            {
                dgvPosmRequest.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnSave.Enabled = false;
            }
            dgvPosmRequest.DataSource = dtPosmRequest;
            colDescription.ValueMember = "RequestPurpose";
        }

        #endregion


        #region Private Methods
        private void LoadNBind()
        {
            SqlConnection conn = null;
            conn = DBManager.GetInstance().GetDbConnection();
            try
            {
                //  Bind Employees Into DataTable
                dtEmployees = new EmployeeBL().GetAll();
                cmbGiverDept.DataSource = new DepartmentBL().GetAll();
                cmbGiverDept.ValueMember = "ID";
                cmbGiverDept.DisplayMember = "DeptName";
                dtAPTransferList = new AP_TransferListBL().GetAll();
            }
            catch (SqlException Sqle)
            {

                throw Sqle;
            }
            //  APSubCategory & POSM Link
            dtAPSubCategory = new APSubCategoryDAO().SelecteAllAPSubCatWithoutNonAP();
            dtPOSM = new APMaterialDAO().SelectAllWithAPSubCat();

            bdAPSubCategory = new BindingSource();
            bdAPSubCategory.DataSource = dtAPSubCategory;

            colAPSubCategory.DataSource = bdAPSubCategory;
            colAPSubCategory.DisplayMember = "APSubCategoryName";
            colAPSubCategory.ValueMember = "AP_SubCategoryID";


            bdunfilteredPOSM = new BindingSource();
            DataView undv = new DataView(dtPOSM);

            bdunfilteredPOSM.DataSource = undv;
            colPosm.DataSource = bdunfilteredPOSM;
            colPosm.DisplayMember = "APMaterialName";
            colPosm.ValueMember = "AP_MaterialID";


            bdfilteredPOSM = new BindingSource();
            DataView fdv = new DataView(dtPOSM);
            bdfilteredPOSM.DataSource = fdv;

            //  AP_RequestDetail Bind Into DataGridview
            dgvPosmRequest.AutoGenerateColumns = false;
            this.dtAP_RequestWithDetail = new AP_RequestDetailBL().GetAll();
            dgvPosmRequest.DataSource = this.dtAP_RequestWithDetail.Clone();

            // Request Purpose Column
            List<RequestPurposes> _RequestPurpose = new List<RequestPurposes>();
            _RequestPurpose.Add(new RequestPurposes { RequestPurpose = 0, RequestPurposeName = "Outlet များပေး" });
            _RequestPurpose.Add(new RequestPurposes { RequestPurpose = 1, RequestPurposeName = "Retailer များပေး" });
            _RequestPurpose.Add(new RequestPurposes { RequestPurpose = 2, RequestPurposeName = "ခရီးစဉ်" });
            _RequestPurpose.Add(new RequestPurposes { RequestPurpose = 3, RequestPurposeName = "လက်ဆောင်ပေး" });
            _RequestPurpose.Add(new RequestPurposes { RequestPurpose = 4, RequestPurposeName = "ရုံးသုံး" });
            _RequestPurpose.Add(new RequestPurposes { RequestPurpose = 5, RequestPurposeName = "အခြား" });
            colDescription.DataSource = _RequestPurpose;
            colDescription.DisplayMember = "RequestPurposeName";
            colDescription.ValueMember = "RequestPurpose";
        }

        private void cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvPosmRequest.CurrentCell.ColumnIndex == 0)
            {
                //  this.dgvAPEnquiry[1, this.dgvAPEnquiry.CurrentCell.RowIndex].Value = 0;
            }
        }

        private void Save()
        {
            SqlConnection conn = null;
            int AP_RequestID = -1;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                // Get DataTable From DataGridView
                DataTable dt = dgvPosmRequest.DataSource as DataTable;

                #region Entites AP_Request

                AP_Request _AP_Request = new AP_Request();
                _AP_Request.RequestDate = (DateTime)DataTypeParser.Parse(dtpRequestDate.Value, typeof(DateTime), DateTime.Now);
                if (rdoDept.Checked)
                {
                    _AP_Request.RequestDeptID = (int?)DataTypeParser.Parse(cmbDeptVen.SelectedValue, typeof(int), -1);
                    _AP_Request.RequestVenID = null;
                }
                else
                {
                    _AP_Request.RequestDeptID = null;
                    _AP_Request.RequestVenID = (int?)DataTypeParser.Parse(cmbDeptVen.SelectedValue, typeof(int), -1);
                }
                _AP_Request.RequesterID = (int)DataTypeParser.Parse(cmbEmployee.SelectedValue, typeof(int), -1);
                _AP_Request.IssueDeptID = (int)DataTypeParser.Parse(cmbGiverDept.SelectedValue, typeof(int), -1);
                _AP_Request.IssueEmployeeID = (int)DataTypeParser.Parse(cmbGiver.SelectedValue, typeof(int), -1);

                List<AP_RequestDetail> insertAP_RequestDetail = new List<AP_RequestDetail>();
                List<AP_RequestDetail> updateAP_RequestDetail = new List<AP_RequestDetail>();
                List<AP_RequestDetail> deleteAP_RequestDetail = new List<AP_RequestDetail>();

                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);

                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    AP_RequestDetail _AP_RequestDetail = new AP_RequestDetail()
                    {
                        AP_RequestID = (int)DataTypeParser.Parse(row["AP_RequestID"], typeof(int), -1),
                        AP_MaterialID = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1),
                        RequestQty = (int)DataTypeParser.Parse(row["RequestQty"].ToString(), typeof(int), 0),
                        RequestPurpose = (int)DataTypeParser.Parse(row["RequestPurpose"], typeof(int), -1),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };
                    if (_AP_RequestDetail.AP_MaterialID != -1 && _AP_RequestDetail.RequestQty != 0 && _AP_RequestDetail.RequestPurpose != -1)
                    {
                        insertAP_RequestDetail.Add(_AP_RequestDetail);
                    }
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    AP_RequestDetail _AP_RequestDetail = new AP_RequestDetail()
                    {
                        ID = (int)DataTypeParser.Parse(row["AP_RequestDetailID"], typeof(int), -1),
                        AP_RequestID = (int)DataTypeParser.Parse(row["AP_RequestID"], typeof(int), -1),
                        AP_MaterialID = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1),
                        RequestQty = (int)DataTypeParser.Parse(row["RequestQty"].ToString(), typeof(int), 0),
                        RequestPurpose = (int)DataTypeParser.Parse(row["RequestPurpose"].ToString(), typeof(int), 0),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };
                    deleteAP_RequestDetail.Add(_AP_RequestDetail);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);

                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    AP_RequestDetail _AP_RequestDetail = new AP_RequestDetail()
                     {
                         ID = (int)DataTypeParser.Parse(row["AP_RequestDetailID"], typeof(int), -1),
                         AP_RequestID = (int)DataTypeParser.Parse(row["AP_RequestID"], typeof(int), -1),
                         AP_MaterialID = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1),
                         RequestQty = (int)DataTypeParser.Parse(row["RequestQty"].ToString(), typeof(int), 0),
                         RequestPurpose = (int)DataTypeParser.Parse(row["RequestPurpose"], typeof(int), 0),
                         Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                     };
                    if (_AP_RequestDetail.AP_RequestID != -1 && _AP_RequestDetail.AP_MaterialID != -1 && _AP_RequestDetail.ID != -1 && _AP_RequestDetail.RequestQty != 0)
                    {
                        updateAP_RequestDetail.Add(_AP_RequestDetail);
                    }
                    AP_RequestID = _AP_RequestDetail.AP_RequestID;
                }

                #endregion
                int insertedRequestID = 0;
                if (AP_RequestID != -1 && updateAP_RequestDetail.Count > 0)
                {
                    insertedRequestID += new AP_RequestDetailBL().UpdateID(updateAP_RequestDetail, conn);
                }
                else if (AP_RequestID == -1 && insertAP_RequestDetail.Count > 0)
                {
                    insertedRequestID += new AP_RequestDetailBL().Add(_AP_Request, insertAP_RequestDetail, conn);
                }

                if (insertedRequestID > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    AP_Request = insertedRequestID;
                    if (POSM_RequestSavedHandler == null)
                        UIManager.MdiChildOpenForm(typeof(frmPosmTransferList));
                    this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave);
            }
            catch (SqlException Sqle)
            {
                throw Sqle;
            }
        }

        #endregion

        #region Events

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmPosmTransferList));
            this.Close();
        }

        private void dgvPosmRequest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }

            if (this.dgvPosmRequest.CurrentCell.ColumnIndex == 0 && (e.Control is ComboBox))
            {
                cmb = e.Control as ComboBox;
                cmb.SelectionChangeCommitted += new EventHandler(cmb_SelectionChangeCommitted);
            }
        }

        private void dgvPosmRequest_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colPosm.Index)
                {
                    int AP_SubCat = (int)DataTypeParser.Parse(this.dgvPosmRequest[e.ColumnIndex - 1, e.RowIndex].Value, typeof(int), 0);
                    if (AP_SubCat == 0) return;
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvPosmRequest[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdfilteredPOSM;

                    this.bdfilteredPOSM.Filter = "AP_SubCategoryID = " + this.dgvPosmRequest[e.ColumnIndex - 1, e.RowIndex].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvPosmRequest_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.colPosm.Index)
                {
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvPosmRequest[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdunfilteredPOSM;
                    //  this.bdfilteredPOSM.RemoveFilter();
                }
            }
            catch { }
            if (dgvPosmRequest.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colQuantity.Index)
            {
                dgvPosmRequest.Rows[e.RowIndex].ErrorText = String.Empty;
                dgvPosmRequest.CurrentRow.Cells[colQuantity.Index].Value = 0;
            }
            else if (dgvPosmRequest.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colPosm.Index)
            {
                dgvPosmRequest.Rows[e.RowIndex].ErrorText = String.Empty;
                dgvPosmRequest.CurrentRow.Cells[colPosm.Index].Value = -1;
                //  dgvPosmPurchasedIn.CurrentRow.Cells[colPosm.Index].Value = 1;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvPosmRequest.CurrentCell.ColumnIndex;
                int iRow = dgvPosmRequest.CurrentCell.RowIndex;
                if (iColumn == dgvPosmRequest.Columns[colRemark.Index].Index)
                {
                    if (iRow + 1 >= dgvPosmRequest.Rows.Count)
                    {
                        DataTable dtAPRequest = dgvPosmRequest.DataSource as DataTable;
                        DataRow newRow = dtAPRequest.NewRow();
                        dtAPRequest.Rows.Add(newRow);
                        this.dgvPosmRequest.DataSource = dtAPRequest;
                        dgvPosmRequest[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvPosmRequest.CurrentCell = dgvPosmRequest[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvPosmRequest.CurrentCell = dgvPosmRequest[dgvPosmRequest.CurrentCell.ColumnIndex + 1, dgvPosmRequest.CurrentCell.RowIndex];
                    }
                    catch (Exception ie)
                    {
                    }
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void rdoDept_CheckedChanged(object sender, EventArgs e)
        {            
            try
            {                
                if (rdoDept.Checked)
                {
                    // Department, Ven & Employee
                    cmbDeptVen.DataSource = new DepartmentBL().GetAll();
                    cmbDeptVen.ValueMember = "ID";
                    cmbDeptVen.DisplayMember = "DeptName";
                    cmbDeptVen.SelectedValue = (int)PTIC.Common.Enum.PredefinedDepartment.Marketing;
                }
                else
                {
                    try
                    {
                        //  Vehicle Binding
                        cmbDeptVen.DataSource = new VehicleBL().GetAll();
                        cmbDeptVen.DisplayMember = "VenNo";
                        cmbDeptVen.ValueMember = "VehicleID";

                        // Employee Binding
                        DataTable dtEmployeesByDept = null;
                        if (Program.module == Program.Module.Marketing)
                        {
                            dtEmployeesByDept = DataUtil.GetDataTableBy(dtEmployees, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                        }
                        else
                        {
                            dtEmployeesByDept = DataUtil.GetDataTableBy(dtEmployees, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                        }

                        cmbEmployee.DataSource = dtEmployeesByDept;
                        cmbEmployee.ValueMember = "EmployeeID";
                        cmbEmployee.DisplayMember = "EmpName";

                        cmbGiver.DataSource = dtEmployeesByDept;
                        cmbGiver.ValueMember = "EmployeeID";
                        cmbGiver.DisplayMember = "EmpName";
                    }
                    catch (Exception exe)
                    {
                        throw exe;
                    }
                }
            }
            catch (Exception exe)
            {
                throw exe;
            }

        }

        private void cmbDeptVen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoDept.Checked)
            {
                int DeptID = (int)DataTypeParser.Parse(cmbDeptVen.SelectedValue, typeof(int), -1);

                DataTable dtEmployeesByDept = DataUtil.GetDataTableBy(dtEmployees, "DeptID", DeptID);
                cmbEmployee.DataSource = dtEmployeesByDept;
                cmbEmployee.ValueMember = "EmployeeID";
                cmbEmployee.DisplayMember = "EmpName";

            }
        }

        private void dgvPosmRequest_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvPosmRequest.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvPosmRequest.DataSource as DataTable);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPosmRequest.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure want to delete Selected Row?", "အတည်ပြုချက်", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int Index = dgvPosmRequest.CurrentRow.Index;
                    dgvPosmRequest.Rows.RemoveAt(Index);
                }
            }
            else
            {
                MessageBox.Show(Resource.errSelectRowToDelete, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resource.msgSureSave, "သတိပေးချက်", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                return;
            Save();
        }

        #endregion

        private void dgvPosmRequest_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void dgvPosmRequest_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvPosmRequest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int newInteger = 0;
            //   decimal newDecimal = 0;
            var dgv = sender as DataGridView;
            int Qty = 0;
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            int APMaterialID = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colPosm.Index].Value, typeof(int), -1);
            int DeptID = (int)DataTypeParser.Parse(cmbGiverDept.SelectedValue, typeof(int), -1);
            DataTable dt = new AP_EnquiryBL().GetBalanceByAPMaterialIDDeptID(APMaterialID, DeptID);
            if (dt.Rows.Count < 1)
            {
                Qty = 0;
            }
            else
            {
                // APMaterialName = (string)DataTypeParser.Parse(dt.Rows[0]["APMaterialName"], typeof(string), String.Empty);
                Qty = (int)DataTypeParser.Parse(dt.Rows[0]["Qty"], typeof(int), 0);
            }
            if (e.ColumnIndex == colPosm.Index)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells["colPosm"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
                        if (row.Cells["colPosm"].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed!";
                            MessageBox.Show("Duplicate not allowed!", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
            else if (e.ColumnIndex == colQuantity.Index)
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

        private void cmbGiverDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DeptID = (int)DataTypeParser.Parse(cmbGiverDept.SelectedValue, typeof(int), -1);

            DataTable dtEmployeesByDept = DataUtil.GetDataTableBy(dtEmployees, "DeptID", DeptID);
            cmbGiver.DataSource = dtEmployeesByDept;
            cmbGiver.ValueMember = "EmployeeID";
            cmbGiver.DisplayMember = "EmpName";
        }

        private void frmPosmRequest_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (POSM_RequestSavedHandler != null)
            {
                // Send AP_RequestID to caller
                POSM_RequestEventArgs eArg = new POSM_RequestEventArgs(this.AP_Request);
                POSM_RequestSavedHandler(this, eArg);
            }
        }

        private void frmPosmRequest_Load(object sender, EventArgs e)
        {
            if (this.POSM_RequestSavedHandler != null) // there is a caller
                this.btnIssue.Visible = true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int TmpAP_RequestID = (int)DataTypeParser.Parse(dgvPosmRequest.Rows[0].Cells[colAP_RequestID.Index].Value,typeof(int),-1);
            DataTable dtAPIssueInfo = DataUtil.GetDataTableBy(dtAPTransferList, "AP_RequestID", TmpAP_RequestID);

            int AP_IssueDeptID = (int)DataTypeParser.Parse(dtAPIssueInfo.Rows[0]["IssueDeptID"], typeof(int), -1);
            int AP_IssueEmployeeID = (int)DataTypeParser.Parse(dtAPIssueInfo.Rows[0]["IssueEmployeeID"], typeof(int), -1);
            frmPosmRecieve _frmPosmRecieve = new frmPosmRecieve(TmpAP_RequestID, AP_IssueDeptID, AP_IssueEmployeeID);
            UIManager.OpenForm(_frmPosmRecieve);
            this.Close();            
        }
    }

    #region Inner Class
    public class POSM_RequestEventArgs : EventArgs
    {
        private int? _AP_RequestID = null;
        public POSM_RequestEventArgs(int? AP_RequestID)
        {
            this._AP_RequestID = AP_RequestID;
        }
        public int? AP_RequestID
        {
            get { return this._AP_RequestID; }
        }
    }
    #endregion
}

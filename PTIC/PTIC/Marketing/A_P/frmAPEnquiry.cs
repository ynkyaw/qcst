using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Marketing.Setup;
using System.Data.SqlClient;
using PTIC.Marketing.BL;
using PTIC.Util;
using PTIC.Marketing.Entities;
using PTIC.VC.Util;
using PTIC.VC.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.VC.Marketing.A_P
{
    public partial class frmAPEnquiry : Form
    {
        DataTable dtAPSubCategory, dtPOSM;

        BindingSource bdAPSubCategory, bdfilteredPOSM, bdunfilteredPOSM;

        ComboBox cmb;

        private int _AP_EnquiryID;

        private DateTime? EnquiryDate;

        private int APEnquiryIDByList;

        public frmAPEnquiry()
        {
            InitializeComponent();
            pnlFilter.Visible = false;
            lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
            this.EnquiryDate = null;
            LoadNBind();
            DataUtil.AddInitialNewRow(dgvAPEnquiry);
            dgvAPEnquiry.Rows[dgvAPEnquiry.Rows.Count - 1].Cells[colEnquiryDate.Index].Value = DateTime.Now;
        }

        public frmAPEnquiry(DateTime? EnquiryDate, DateTime? CloseDate, String COORemark, int APEnquiryID)
        {
            InitializeComponent();
            txtCOOFRemark.Text = COORemark;
            dtpAP_PlanDate.Enabled = false;
            pnlFilter.Visible = false;
            if (CloseDate.Value != DateTime.MinValue)
            {
                dtpEndDate.Enabled = false;
                chkEndDate.Enabled = false;
                btnSave.Enabled = false;
                btnConfirm.Enabled = false;
                btnNew.Enabled = false;
            }

            //if (EnquiryDate.Value.ToShortDateString() != CloseDate.Value.ToShortDateString())
            //{
            //    dtpEndDate.Enabled = false;
            //    chkEndDate.Enabled = false;
            //}

            lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
            this.EnquiryDate = EnquiryDate;
            dtpAP_PlanDate.Value = (DateTime)DataTypeParser.Parse(EnquiryDate, typeof(DateTime), DateTime.Now);
            this.APEnquiryIDByList = APEnquiryID;
            //LoadNBind();
            //DataUtil.AddInitialNewRow(dgvAPEnquiry);
            // dgvAPEnquiry.Rows[dgvAPEnquiry.Rows.Count - 1].Cells[colEnquiryDate.Index].Value = DateTime.Now;
            //   dgvAPEnquiry.CurrentRow.Cells[colEnquiryDate.Index].Value = DateTime.Now;
        }

        #region Events

        private void lblFilter_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Visible)
            {
                // pnlFilter.Visible = false;
                lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
                pnlGrid.Visible = true;
            }
            else
            {
                // pnlFilter.Visible = true;
                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
                pnlGrid.Visible = false;
            }
        }

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(typeof(frmSupplier));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvAPEnquiry.CurrentCell.ColumnIndex;
                int iRow = dgvAPEnquiry.CurrentCell.RowIndex;
                if (dgvAPEnquiry.Rows[iRow].ErrorText != string.Empty) return true;
                if (iColumn == dgvAPEnquiry.Columns[colRemark.Index].Index)
                {
                    if (iRow + 1 >= dgvAPEnquiry.Rows.Count)
                    {
                        DataTable dtAPEnquiry = dgvAPEnquiry.DataSource as DataTable;
                        DataRow newRow = dtAPEnquiry.NewRow();
                        dtAPEnquiry.Rows.Add(newRow);
                        this.dgvAPEnquiry.DataSource = dtAPEnquiry;
                        dgvAPEnquiry[0, iRow + 1].Selected = true;
                        dgvAPEnquiry.Rows[dgvAPEnquiry.Rows.Count - 1].Cells[colEnquiryDate.Index].Value = DateTime.Now;
                        dgvAPEnquiry.Rows[dgvAPEnquiry.Rows.Count - 1].Cells[colAccepted.Index].ReadOnly = true;
                    }
                    else
                    {
                        dgvAPEnquiry.CurrentCell = dgvAPEnquiry[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvAPEnquiry.CurrentCell = dgvAPEnquiry[dgvAPEnquiry.CurrentCell.ColumnIndex + 1, dgvAPEnquiry.CurrentCell.RowIndex];

                    }
                    catch (Exception ie)
                    {
                    }
                }
                return true;
            }
            //else if (keyData == Keys.Delete)
            //{
            //    if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        foreach (DataGridViewRow item in this.dgvMarketingPlan.SelectedRows)
            //        {
            //            dgvMarketingPlan.Rows.RemoveAt(item.Index);
            //        }
            //        Save();
            //        if (dgvMarketingPlan.RowCount == 0)
            //        {
            //            DataRow newRow = marketingplanTbl.NewRow();
            //            marketingplanTbl.Rows.Add(newRow);
            //            this.dgvMarketingPlan.DataSource = marketingplanTbl;
            //            ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
            //        }
            //    }
            //    return true;
            // }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Private Methods

        public void LoadNBind()
        {
            try
            {
                //  GetEnquiryDate
                DateTime Date = (DateTime)DataTypeParser.Parse(dtpAP_PlanDate.Value, typeof(DateTime), DateTime.Now);
                //  Current Month
                int Month = Date.Month;
                int Year = Date.Year;
                //  Next 2 Month
                DateTime NextMonth = Date.AddMonths(2);
                int Next2Month = 0;
                if (NextMonth.Year == Year)
                {
                    Next2Month = NextMonth.Month;
                }
                else
                {
                    Next2Month = 12;
                }
                //  Selected Planed APMaterial By DateRange
                DataTable dtAPMaterial = new AP_EnquiryBL().GetAcceptEnquiryAP_MaterialListByDate(Month, Next2Month,Year);
                
                dtPOSM = dtAPMaterial;
                dtAPSubCategory = new AP_EnquiryBL().GetAcceptEnquiryAP_SubCategoryListByDate(Month, Next2Month, Year);

                DataTable dtSupplier = new SupplierBL().GetAll();
                colSupplier.DataSource = dtSupplier;
                colSupplier.DisplayMember = "SupplierName";
                colSupplier.ValueMember = "SupplierID";

                //dtAPSubCategory = new APSubCategoryDAO().SelectAllAPSubCat();
                //dtPOSM = new APMaterialDAO().SelectAllWithAPSubCat(); -- Posm change

                bdAPSubCategory = new BindingSource();
                bdAPSubCategory.DataSource = dtAPSubCategory;

                colAPSubCat.DataSource = bdAPSubCategory;
                colAPSubCat.DisplayMember = "APSubCategoryName";
                colAPSubCat.ValueMember = "AP_SubCategoryID";

                bdunfilteredPOSM = new BindingSource();
                DataView undv = new DataView(dtPOSM);

                bdunfilteredPOSM.DataSource = undv;
                colPosm.DataSource = bdunfilteredPOSM;
                colPosm.DisplayMember = "APMaterialName";
                colPosm.ValueMember = "AP_MaterialID";

                bdfilteredPOSM = new BindingSource();
                DataView fdv = new DataView(dtPOSM);
                bdfilteredPOSM.DataSource = fdv;

                DataTable dtGrid = new AP_EnquiryBL().GetAllDetail(this.EnquiryDate);
                dgvAPEnquiry.AllowUserToAddRows = false;
                dgvAPEnquiry.AutoGenerateColumns = false;
                dgvAPEnquiry.DataSource = dtGrid;
                colEnquiryDate.DataPropertyName = "EnquiryDate";
                colAPSubCat.DisplayMember = "APSubCategoryName";
                colAPSubCat.ValueMember = "AP_SubCategoryID";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion

        private void dgvPosmPurchasedIn_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colPosm.Index)
                {
                    int AP_SubCat = (int)DataTypeParser.Parse(this.dgvAPEnquiry[e.ColumnIndex - 1, e.RowIndex].Value, typeof(int), 0);
                    if (AP_SubCat == 0) return;
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvAPEnquiry[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdfilteredPOSM;

                    this.bdfilteredPOSM.Filter = "AP_SubCategoryID = " + this.dgvAPEnquiry[e.ColumnIndex - 1, e.RowIndex].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvPosmPurchasedIn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.colPosm.Index)
                {
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvAPEnquiry[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdunfilteredPOSM;

                    //  this.bdfilteredPOSM.RemoveFilter();
                }
                if (dgvAPEnquiry.Rows[e.RowIndex].ErrorText != string.Empty && e.ColumnIndex == colRequiredDate.Index)
                {
                    dgvAPEnquiry.Rows[e.RowIndex].Cells[colRequiredDate.Index].Value = null;
                    dgvAPEnquiry.Rows[e.RowIndex].ErrorText = string.Empty;
                }
                if (dgvAPEnquiry.Rows[e.RowIndex].ErrorText != string.Empty && e.ColumnIndex == colPosm.Index)
                {
                    dgvAPEnquiry.Rows[e.RowIndex].Cells[colPosm.Index].Value = -1;
                    dgvAPEnquiry.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }

            catch { }

        }

        private void dgvPosmPurchasedIn_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }

            if (this.dgvAPEnquiry.CurrentCell.ColumnIndex == 0 && (e.Control is ComboBox))
            {
                cmb = e.Control as ComboBox;
                cmb.SelectionChangeCommitted += new EventHandler(cmb_SelectionChangeCommitted);
            }

            e.Control.KeyPress -= new KeyPressEventHandler(KeyPressfunction.CheckInt);//This line of code resolved my issue
            if (dgvAPEnquiry.CurrentCell.ColumnIndex == dgvAPEnquiry.Columns["colQty"].Index || dgvAPEnquiry.CurrentCell.ColumnIndex == dgvAPEnquiry.Columns["colUnitCost"].Index)
            {
                TextBox itemID = e.Control as TextBox;
                if (itemID != null)
                {
                    itemID.KeyPress += new KeyPressEventHandler(KeyPressfunction.CheckInt);
                }
            }
        }

        private void cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvAPEnquiry.CurrentCell.ColumnIndex == 0)
            {
                //  this.dgvAPEnquiry[1, this.dgvAPEnquiry.CurrentCell.RowIndex].Value = 0;
            }
        }

        private void dgvPosmPurchasedIn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvAPEnquiry_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void dgvAPEnquiry_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvAPEnquiry.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvAPEnquiry_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvAPEnquiry.CurrentCell == null) return;
            if (dgvAPEnquiry.Rows[dgvAPEnquiry.CurrentCell.RowIndex].ErrorText != string.Empty) return;
            Save();
        }

        private void Save()
        {
            AP_EnquiryBL enquirySaver = null;
            try
            {
                enquirySaver = new AP_EnquiryBL();                

                DataTable dt = dgvAPEnquiry.DataSource as DataTable;

                String tmp = (String)DataTypeParser.Parse(dt.Rows[0]["COORemark"].ToString(), typeof(String), String.Empty);
                StringBuilder strBuilder = new StringBuilder(tmp);
                DateTime? EndDate;
                if (chkEndDate.Checked)
                {
                    EndDate = (DateTime?)DataTypeParser.Parse(dtpEndDate.Value, typeof(DateTime), null);
                }
                else
                {
                    EndDate = null;
                }

                if (txtCOORemark.Text != String.Empty)
                {
                    strBuilder.Append("* " + txtCOORemark.Text + Environment.NewLine);
                }

                AP_Enquiry _AP_Enquiry = new AP_Enquiry()
                {
                    OpenDate = (DateTime)DataTypeParser.Parse(dtpAP_PlanDate.Value, typeof(DateTime), DateTime.Now),
                    CloseDate = (DateTime?)DataTypeParser.Parse(EndDate, typeof(DateTime), null),
                    COORemrak = (String)DataTypeParser.Parse(strBuilder.ToString(), typeof(String), String.Empty),
                    AP_PlanMoth = dtpAP_PlanDate.Value
                };

                List<AP_EnquiryDetail> insertAP_EnquiryDetail = new List<AP_EnquiryDetail>();
                List<AP_EnquiryDetail> updateAP_EnquiryDetail = new List<AP_EnquiryDetail>();
                List<AP_EnquiryDetail> deleteAP_EnquiryDetail = new List<AP_EnquiryDetail>();

                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    AP_EnquiryDetail _AP_EnquiryDetail = new AP_EnquiryDetail()
                    {
                        EnquiryDate = (DateTime)DataTypeParser.Parse(row["EnquiryDate"], typeof(DateTime), DateTime.Now),
                        SupplierID = (int)DataTypeParser.Parse(row["SupplierID"], typeof(int), -1),
                        AP_MaterialID = (int)DataTypeParser.Parse(row["AP_MaterialID"], typeof(int), -1),
                        ApprovedQty = (int)DataTypeParser.Parse(row["ApprovedQty"], typeof(int), 0),
                        UnitCost = (decimal)DataTypeParser.Parse(row["UnitCost"], typeof(decimal), 0),
                        IsAccepted = (bool)DataTypeParser.Parse(row["IsAccepted"], typeof(bool), false),
                        LastRequireDate = (DateTime)DataTypeParser.Parse(row["LastRequireDate"], typeof(DateTime), DateTime.Now),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty),
                        DateAdded = DateTime.Now,
                        LastModified=DateTime.Now

                    };
                    if (_AP_EnquiryDetail.LastRequireDate == DateTime.MinValue)
                    {
                        MessageBox.Show("နောက်ဆုံးရလိုသည့်နေ့စွဲဖြည့်ပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (_AP_EnquiryDetail.SupplierID != -1 && _AP_EnquiryDetail.AP_MaterialID != -1 && _AP_EnquiryDetail.ApprovedQty != 0 && _AP_EnquiryDetail.UnitCost != 0)
                    {
                        insertAP_EnquiryDetail.Add(_AP_EnquiryDetail);
                    }
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    AP_EnquiryDetail _AP_EnquiryDetail = new AP_EnquiryDetail()
                   {
                       ID = (int)DataTypeParser.Parse(row["AP_EnquiryDetailID"].ToString(), typeof(int), -1),
                       AP_EnquiryID = (int)DataTypeParser.Parse(row["AP_EnquiryID"].ToString(), typeof(int), -1),
                       EnquiryDate = (DateTime)DataTypeParser.Parse(row["EnquiryDate"].ToString(), typeof(DateTime), DateTime.Now),
                       SupplierID = (int)DataTypeParser.Parse(row["SupplierID"].ToString(), typeof(int), -1),
                       AP_MaterialID = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1),
                       ApprovedQty = (int)DataTypeParser.Parse(row["ApprovedQty"].ToString(), typeof(int), 0),
                       UnitCost = (decimal)DataTypeParser.Parse(row["UnitCost"].ToString(), typeof(decimal), 0),
                       IsAccepted = (bool)DataTypeParser.Parse(row["IsAccepted"], typeof(bool), false),
                       Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                   };
                    deleteAP_EnquiryDetail.Add(_AP_EnquiryDetail);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    AP_EnquiryDetail _AP_EnquiryDetail = new AP_EnquiryDetail()
                    {
                        ID = (int)DataTypeParser.Parse(row["AP_EnquiryDetailID"].ToString(), typeof(int), -1),
                        AP_EnquiryID = (int)DataTypeParser.Parse(row["AP_EnquiryID"].ToString(), typeof(int), -1),
                        EnquiryDate = (DateTime)DataTypeParser.Parse(row["EnquiryDate"].ToString(), typeof(DateTime), DateTime.Now),
                        SupplierID = (int)DataTypeParser.Parse(row["SupplierID"].ToString(), typeof(int), -1),
                        AP_MaterialID = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1),
                        ApprovedQty = (int)DataTypeParser.Parse(row["ApprovedQty"].ToString(), typeof(int), 0),
                        UnitCost = (decimal)DataTypeParser.Parse(row["UnitCost"].ToString(), typeof(decimal), 0),
                        IsAccepted = (bool)DataTypeParser.Parse(row["IsAccepted"].ToString(), typeof(bool), false),
                        LastRequireDate = (DateTime)DataTypeParser.Parse(row["LastRequireDate"], typeof(DateTime), DateTime.Now),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };
                    if (_AP_EnquiryDetail.LastRequireDate == DateTime.MinValue)
                    {
                        MessageBox.Show("နောက်ဆုံးရလိုသည့်နေ့စွဲဖြည့်ပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else 
                    if (_AP_EnquiryDetail.SupplierID != -1 && _AP_EnquiryDetail.AP_MaterialID != -1 && _AP_EnquiryDetail.ApprovedQty != 0 && _AP_EnquiryDetail.UnitCost != 0)
                    {
                        updateAP_EnquiryDetail.Add(_AP_EnquiryDetail);
                    }
                    _AP_Enquiry.ID = _AP_EnquiryDetail.ID;
                    _AP_EnquiryID = _AP_Enquiry.ID;
                }

                int affectedRows = 0;
                if (APEnquiryIDByList == 0)
                {
                    if (insertAP_EnquiryDetail.Count > 0 && _AP_Enquiry != null && APEnquiryIDByList != 0)
                    {
                        _AP_Enquiry.ID = (int)DataTypeParser.Parse(APEnquiryIDByList, typeof(int), -1);
                        affectedRows += enquirySaver.EditByID(_AP_Enquiry, updateAP_EnquiryDetail, insertAP_EnquiryDetail);
                    }
                    if (insertAP_EnquiryDetail.Count > 0 && _AP_Enquiry != null)
                    {
                        affectedRows += enquirySaver.Add(_AP_Enquiry, insertAP_EnquiryDetail);
                    }
                    else if (_AP_Enquiry != null && APEnquiryIDByList != -1)
                    {
                        _AP_Enquiry.ID = (int)DataTypeParser.Parse(APEnquiryIDByList, typeof(int), -1);
                        affectedRows += enquirySaver.UpdateAPEnquiry(_AP_Enquiry);
                    }
                    //


                    //else
                    //{
                    //    ToastMessageBox.Show("Blank APEnquiryDetail Data!");
                    //    return;
                    //}

                }
                else
                {
                    if ((updateAP_EnquiryDetail.Count > 0 || insertAP_EnquiryDetail.Count > 0) && _AP_Enquiry != null)
                    {
                        _AP_Enquiry.ID = (int)DataTypeParser.Parse(APEnquiryIDByList, typeof(int), -1);
                        affectedRows += enquirySaver.EditByID(_AP_Enquiry, updateAP_EnquiryDetail, insertAP_EnquiryDetail);
                    }
                    else if (_AP_Enquiry != null && APEnquiryIDByList != -1)
                    {
                        _AP_Enquiry.ID = (int)DataTypeParser.Parse(APEnquiryIDByList, typeof(int), -1);
                        affectedRows += enquirySaver.UpdateAPEnquiry(_AP_Enquiry);
                    }
                    else
                    {
                        ToastMessageBox.Show("Blank APEnquiryDetail Data!");
                        return;
                    }
                }

                // Check validation
                if (enquirySaver.ValidationResults == null)
                {
                    this.Close();
                }
                else if (!enquirySaver.ValidationResults.IsValid)
                {
                    ValidationResult error = (ValidationResult)DataUtil.GetFirst(enquirySaver.ValidationResults);
                    MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (affectedRows > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave);
            }
            catch (SqlException sqle)
            {
                // _logger.Error(sqle);
            }            
        }

        private void dgvAPEnquiry_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                    if ((int)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colAPEnquiryID.Index].Value, typeof(int), 0) != 0)
                    {
                        dgv.Rows[r.Index].ReadOnly = true;
                        dgv.Rows[r.Index].Cells[colAccepted.Index].ReadOnly = false;

                        if ((int)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colAP_EnquiryDetailID.Index].Value, typeof(int), -1) == -1)
                        {
                            dgv.Rows[r.Index].Cells[colAccepted.Index].ReadOnly = true;
                        }
                        else
                        {
                            dgv.Rows[r.Index].Cells[colAccepted.Index].ReadOnly = false;
                        }
                    }

                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEndDate.Checked)
            {
                dtpEndDate.Visible = true;
                dtpEndDate.Enabled = true;
            }
            else
            {
                dtpEndDate.Visible = false;
                dtpEndDate.Enabled = false;
            }
        }

        private void dgvAPEnquiry_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAPEnquiry.Rows.Count > 0 && (e.ColumnIndex == colUnitCost.Index || e.ColumnIndex == colQty.Index))
            {
                int Quantity = (int)DataTypeParser.Parse(dgvAPEnquiry.CurrentRow.Cells[colQty.Index].Value, typeof(int), 0);
                decimal UnitCost = (decimal)DataTypeParser.Parse(dgvAPEnquiry.CurrentRow.Cells[colUnitCost.Index].Value, typeof(decimal), 0);

                dgvAPEnquiry.CurrentRow.Cells[colAmt.Index].Value = Quantity * UnitCost;
            }
        }

        private void txtCOOFRemark_KeyDown(object sender, KeyEventArgs e)
        {
            ContextMenu blankContextMenu = new ContextMenu();
            txtCOOFRemark.ContextMenu = blankContextMenu;
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmAPEnquiryList));
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (dgvAPEnquiry.CurrentCell == null) return;
            if (dgvAPEnquiry.Rows[dgvAPEnquiry.CurrentCell.RowIndex].ErrorText != string.Empty) return;
            DataUtil.AddNewRow(dgvAPEnquiry.DataSource as DataTable);
            dgvAPEnquiry.Rows[dgvAPEnquiry.Rows.Count - 1].Cells[colEnquiryDate.Index].Value = DateTime.Now;
            dgvAPEnquiry.Rows[dgvAPEnquiry.Rows.Count - 1].Cells[colAccepted.Index].ReadOnly = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void dgvAPEnquiry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var dgv = sender as DataGridView;
            if (e.ColumnIndex == dgv.Columns["colPrev"].Index) // Load လက်ကျန်
            {
                int TotalQty = 0;
                int APMaterialID = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colPosm.Index].Value, typeof(int), -1);

                DataTable dt = new AP_EnquiryBL().GetBalanceByAPMaterialID(APMaterialID);
                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show("လက်ကျန်မရှိတော့ပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                foreach (DataRow row in dt.Rows)
                {
                    TotalQty += (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), 0);
                }

                int DeptID = (int)DataTypeParser.Parse(GlobalCache.LoginEmployee.DeptID, typeof(int), -1);

                DataTable dtBalanceByDeptID = DataUtil.GetDataTableBy(dt, "DeptID", DeptID);
                string APMaterialName = (string)DataTypeParser.Parse(dtBalanceByDeptID.Rows[0]["APMaterialName"], typeof(string), String.Empty);
                decimal Qty = (decimal)DataTypeParser.Parse(dtBalanceByDeptID.Rows[0]["Qty"], typeof(decimal), 0);
                string BalanceMessage = String.Format("စုစုပေါင်းလက်ကျန်အရေအတွက်\n   {0} = {1} \n\n လက်ကျန်အရေအတွက်\n   {2} = {3}", APMaterialName, TotalQty, APMaterialName, Qty);
                MessageBox.Show(BalanceMessage, "လက်ကျန်", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void chkPosm_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            var dgv = dgvAPEnquiry as DataGridView;
            if (dgv == null) return;
            string DeptName = String.Empty;

            if (dgv.SelectedRows.Count > 0) // Load လက်ကျန်
            {
                int TotalQty = 0;
                int APMaterialID = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colPosm.Index].Value, typeof(int), -1);

                DataTable dt = new AP_EnquiryBL().GetBalanceByAPMaterialID(APMaterialID);
                if (dt.Rows.Count < 1)
                {
                    MessageBox.Show("လက်ကျန်မရှိတော့ပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                foreach (DataRow row in dt.Rows)
                {
                    TotalQty += (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), 0);
                }

                int DeptID = (int)DataTypeParser.Parse(GlobalCache.LoginEmployee.DeptID, typeof(int), -1);

                DataTable dtBalanceByDeptID = DataUtil.GetDataTableBy(dt, "DeptID", DeptID);
                string APMaterialName = string.Empty;
                decimal Qty = 0;
                if (dtBalanceByDeptID != null)
                {
                    APMaterialName = (string)DataTypeParser.Parse(dtBalanceByDeptID.Rows[0]["APMaterialName"], typeof(string), String.Empty);
                    Qty = (decimal)DataTypeParser.Parse(dtBalanceByDeptID.Rows[0]["Qty"], typeof(decimal), 0);
                }
                switch (GlobalCache.LoginEmployee.DeptID)
                {
                    case 1: DeptName = PTIC.Common.Enum.PredefinedDepartment.PTIC.ToString();
                        break;
                    case 2: DeptName = PTIC.Common.Enum.PredefinedDepartment.HO.ToString();
                        break;
                    case 3: DeptName = PTIC.Common.Enum.PredefinedDepartment.ExportNImport.ToString();
                        break;
                    case 4: DeptName = PTIC.Common.Enum.PredefinedDepartment.DirectorOffice.ToString();
                        break;
                    case 5: DeptName = PTIC.Common.Enum.PredefinedDepartment.AdminNHR.ToString();
                        break;
                    case 6: DeptName = PTIC.Common.Enum.PredefinedDepartment.Finance.ToString();
                        break;
                    case 7: DeptName = PTIC.Common.Enum.PredefinedDepartment.Sales.ToString();
                        break;
                    case 8: DeptName = PTIC.Common.Enum.PredefinedDepartment.Marketing.ToString();
                        break;
                    case 9: DeptName = PTIC.Common.Enum.PredefinedDepartment.MDOffice.ToString();
                        break;

                }

                string BalanceMessage = String.Format("ဌာနအားလုံး၏ စုစုပေါင်းလက်ကျန်\n   {0} = {1} \n\n  {4} ဌာန၏လက်ကျန်\n   {2} = {3}", APMaterialName, TotalQty, APMaterialName, Qty, DeptName);
                MessageBox.Show(BalanceMessage, "လက်ကျန်", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAPEnquiry.SelectedRows.Count > 0)
            {
                int AP_EnquiryDetailID = (int)DataTypeParser.Parse(dgvAPEnquiry.CurrentRow.Cells[colAP_EnquiryDetailID.Index].Value, typeof(int), -1);
                if (AP_EnquiryDetailID == -1)
                {

                    if (MessageBox.Show("Are you sure want to delete Selected Row?", "အတည်ပြုချက်", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {

                        int Index = dgvAPEnquiry.CurrentRow.Index;
                        if (dgvAPEnquiry.Rows.Count == 1)
                        {
                            DataUtil.AddNewRow(dgvAPEnquiry.DataSource as DataTable);
                            dgvAPEnquiry.Rows[dgvAPEnquiry.Rows.Count - 1].Cells[colEnquiryDate.Index].Value = DateTime.Now;
                            dgvAPEnquiry.Rows[dgvAPEnquiry.Rows.Count - 1].Cells[colAccepted.Index].ReadOnly = true;
                        }
                        dgvAPEnquiry.Rows.RemoveAt(Index);
                    }
                }
                else
                {
                    MessageBox.Show("စုံစမ်းပြီးသော POSM များကိုဖျက်ခွင့်မရှိပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(Resource.errSelectRowToDelete, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvAPEnquiry_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == this.colRequiredDate.Index)
            {
                if ((DateTime)DataTypeParser.Parse(dgvAPEnquiry.Rows[e.RowIndex].Cells[colRequiredDate.Index].Value, typeof(DateTime), DateTime.Now) < dtpAP_PlanDate.Value)
                {
                    dgvAPEnquiry.Rows[e.RowIndex].ErrorText = "ရလိုသည့်နေ့မှားယွင်းနေပါသည်။!";
                    MessageBox.Show("ရလိုသည့်နေ့မှားယွင်းနေပါသည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
                else
                {
                    dgvAPEnquiry.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }

            if (e.ColumnIndex == colPosm.Index)
            {
            //    DateTime Date = (DateTime)DataTypeParser.Parse(dgvAPEnquiry.Rows[e.RowIndex].Cells[colEnquiryDate.Index].Value, typeof(DateTime), DateTime.Now);
            //    //  Current Month
            //    int Month = Date.Month;
            //    int Year = Date.Year;
            //    //  Next 2 Month
            //    DateTime NextMonth = Date.AddMonths(2);
            //    int Next2Month = 0;
            //    if (NextMonth.Year == Year)
            //    {
            //        Next2Month = NextMonth.Month;
            //    }
            //    else
            //    {
            //        Next2Month = 12;
            //    }
            //    //  Selected Planed APMaterial By DateRange
            //    DataTable dtAPMaterial = new AP_EnquiryBL().GetAcceptEnquiryAP_MaterialListByDate(Month, Next2Month);
            //    bool APContain = false;
            //    foreach (DataRow row in dtAPMaterial.Rows)
            //    {
            //        if ((int)DataTypeParser.Parse(row["AP_MaterialID"], typeof(int), -1) == (int)DataTypeParser.Parse(dgvAPEnquiry.Rows[e.RowIndex].Cells[colPosm.Index].Value, typeof(int), -1))
            //        {
            //            APContain = true;
            //            break;
            //        }
            //    }

            //    if (APContain == false)
            //    {
            //        dgvAPEnquiry.Rows[e.RowIndex].ErrorText = "ရွေးချယ်ထားသော POSM ကို Plan လုပ်မထားပါ။";
            //        MessageBox.Show("ရွေးချယ်ထားသော POSM ကို Plan လုပ်မထားပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }

            }
        }

        private void dtpEnquiryDate_ValueChanged(object sender, EventArgs e)
        {
            LoadNBind();            
            DataUtil.AddNewRow(dgvAPEnquiry.DataSource as DataTable);
          
            //dgvAPEnquiry.Rows[dgvAPEnquiry.Rows.Count - 1].Cells[colEnquiryDate.Index].Value = dtpEnquiryDate.Value;
            dgvAPEnquiry.Rows[dgvAPEnquiry.Rows.Count - 1].Cells[colAccepted.Index].ReadOnly = true;
            if (dgvAPEnquiry.CurrentCell == null)
            {
                btnConfirm.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnSave.Enabled = false;
            }
        }

    }

}

using System;using PTIC.Common;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Util;
using PTIC.VC.Util;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using System.Collections;
using PTIC.Marketing.A_P;

namespace PTIC.VC.Marketing.A_P
{
    public partial class frmPosmPurchasedIn : Form
    {
        DataTable brandTbl = new DataTable();

        private int _APStockInID = -1;

        private DataTable _dtStockInDetail = null; // All AP_StockInDetail

        private Hashtable fieldhashtable = new Hashtable();

        DataTable dtAPSubCategory, dtPOSM;

        BindingSource bdAPSubCategory, bdfilteredPOSM, bdunfilteredPOSM;

        ComboBox cmb;

        AP_EnquiryDetail _apEnquiryDetail = new AP_EnquiryDetail();
        int APSubCategoryID = -1;
        int BalanceQty = 0;
        string APMaterialName, APSubCategoryName = String.Empty;

        public frmPosmPurchasedIn()
        {
            InitializeComponent();
            //  Auto-Generate Columns false
            dgvPosmPurchasedIn.AutoGenerateColumns = false;
        }

        public frmPosmPurchasedIn(AP_EnquiryDetail _apEnquiryDetail, int APSubCategoryID, string APMaterialName, string APSubCategoryName, int BalanceQty)
            : this()
        {
            this._apEnquiryDetail = _apEnquiryDetail;
            this.APSubCategoryID = APSubCategoryID;
            this.APMaterialName = APMaterialName;
            this.APSubCategoryName = APSubCategoryName;
            this.BalanceQty = BalanceQty;
            LoadNBind();
            LoadNBindCombo();
        }

        #region Private Methods
        private void LoadNBind()
        {
            SqlConnection conn = null;
            DataTable dtAP_PurchasedInDetail = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                dtAP_PurchasedInDetail = new AP_PurchasedDetailBL().GetAllAP_PurchasedDetailByAP_EnquiryDetailID(this._apEnquiryDetail.ID);
                if (dtAP_PurchasedInDetail.Rows.Count < 1)
                {                    
                    dgvPosmPurchasedIn.DataSource = dtAP_PurchasedInDetail;
                    DataUtil.AddInitialNewRow(dgvPosmPurchasedIn);
                    dgvPosmPurchasedIn.CurrentRow.ReadOnly = true;
                    //dgvPosmPurchasedIn.CurrentRow.Cells[colPurchasedDate.Index].ReadOnly = false;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colPosm.Index].Value = this._apEnquiryDetail.AP_MaterialID;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colAPSubCategory.Index].Value = this.APSubCategoryID;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colUnitCost.Index].Value = _apEnquiryDetail.UnitCost;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colAP_EnquiryDetailID.Index].Value = _apEnquiryDetail.ID;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colQuantity.Index].Value = this.BalanceQty;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colPurchasedDate.Index].Value = DateTime.Now;
                    dgvPosmPurchasedIn.Rows[dgvPosmPurchasedIn.Rows.Count - 1].ReadOnly = true;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colPresentQty.Index].ReadOnly = false;
                }
                else
                {
                    dtAP_PurchasedInDetail.Clear();
                    dgvPosmPurchasedIn.DataSource = dtAP_PurchasedInDetail;
                    DataUtil.AddInitialNewRow(dgvPosmPurchasedIn);
                    dgvPosmPurchasedIn.CurrentRow.ReadOnly = true;
                    //dgvPosmPurchasedIn.CurrentRow.Cells[colPurchasedDate.Index].ReadOnly = false;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colPosm.Index].Value = this._apEnquiryDetail.AP_MaterialID;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colAPSubCategory.Index].Value = this.APSubCategoryID;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colUnitCost.Index].Value = _apEnquiryDetail.UnitCost;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colAP_EnquiryDetailID.Index].Value = _apEnquiryDetail.ID;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colQuantity.Index].Value = this.BalanceQty;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colPurchasedDate.Index].Value = DateTime.Now;
                    dgvPosmPurchasedIn.Rows[dgvPosmPurchasedIn.Rows.Count - 1].ReadOnly = true;
                    dgvPosmPurchasedIn.CurrentRow.Cells[colPresentQty.Index].ReadOnly = false;
                    //dgvPosmPurchasedIn.CurrentRow.ReadOnly = true;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        private void LoadNBindCombo()
        {
            try
            {
                dtAPSubCategory = new APSubCategoryDAO().SelectAllAPSubCat();
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
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private void Save()
        {
            SqlConnection conn = null;
            try
            {
                DataTable dt = dgvPosmPurchasedIn.DataSource as DataTable;
                if (dt == null) return;
                int affectedRows = 0;
                conn = DBManager.GetInstance().GetDbConnection();

                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    AP_PurchasedDetail _APPurchasedDetail = new AP_PurchasedDetail()
                    {
                        AP_EnquiryDetailID = (int)DataTypeParser.Parse(row["AP_EnquiryDetailID"].ToString(), typeof(int), -1),
                        EntryPersonID = (int)DataTypeParser.Parse(GlobalCache.LoginUser.EmpID, typeof(int), -1),
                        DeptID = (int)PTIC.Common.Enum.PredefinedDepartment.Marketing,
                        PurchasedDate = (DateTime)DataTypeParser.Parse(row["PurchasedDate"].ToString(),typeof(DateTime),DateTime.Now),
                        PurchasedQty = (int)DataTypeParser.Parse(row["PurchasedQty"].ToString(), typeof(int), 0),
                        PresentQty = (int)DataTypeParser.Parse(row["PresentQty"].ToString(), typeof(int), 0),
                        Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), String.Empty)
                    };
                    if (_APPurchasedDetail.AP_EnquiryDetailID != -1 && _APPurchasedDetail.EntryPersonID != -1 && _APPurchasedDetail.DeptID > -1 && _APPurchasedDetail.PurchasedQty > 0)
                    {
                        affectedRows = new AP_PurchasedDetailBL().Insert(_APPurchasedDetail, this._apEnquiryDetail.AP_MaterialID, conn);
                    }
                }

                //// delete
                //DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                //foreach (DataRow row in dvDelete.ToTable().Rows)
                //{
                //    AP_StockInDetail _APStockInDetail = new AP_StockInDetail()
                //    {
                //        ID = (int)DataTypeParser.Parse(row["APStockInDetailID"].ToString(), typeof(int), -1),
                //        APMaterialID = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1),
                //       // BrandID = (int)DataTypeParser.Parse(row["BrandID"].ToString(), typeof(int), -1),
                //        Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), 0),
                //        Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), String.Empty),
                //        UnitCost = (decimal)DataTypeParser.Parse(row["UnitCost"].ToString(), typeof(decimal), 0)
                //    };
                //    if (_APStockInDetail.APMaterialID != -1 && _APStockInDetail.BrandID != -1)
                //    {

                //    }
                //}

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    affectedRows = 1;
                }

                if (affectedRows > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave);
            }



            //    //foreach (DataGridViewRow row in dgvAPPlanDetail.Rows)
            //    //{
            //    //    if (row.IsNewRow) break;
            //    //    else
            //    //    {
            //    //}
            //    //}
            //    int affectedRows = 0;
            //    if (_APPlanId == -1) // Add new order and details
            //    {
            //        if (insertApPlanDetails.Count > 0 && _APStockIn != null)
            //            affectedRows += apPlanBL.Add(_APStockIn, insertApPlanDetails, conn);
            //        else
            //        {
            //            ToastMessageBox.Show("Blank A & P Detail Data!");
            //            return;
            //        }

            //    }
            //    else // Update an existing order and details
            //    {
            //        // Update order by A & P Plan ID
            //        _APStockIn.A_P_PlanID = _APPlanId;
            //        //apPlan.SalePlanAmt = (int)DataTypeParser.Parse(txtSalesPlanAmount.Text, typeof(int), -1);
            //        //apPlan.Status = 0;

            //        if (insertApPlanDetails.Count > 0) affectedRows += apPlanBL.Update(_APStockIn, insertApPlanDetails, conn);
            //        if (deleteAPStockInDetail.Count > 0) affectedRows += apPlanDetailBL.Delete(deleteAPStockInDetail, conn);
            //        if (updateApPlanDetails.Count > 0) affectedRows += apPlanDetailBL.Update(_APStockIn, updateApPlanDetails, conn);
            //        affectedRows = apPlanBL.UpdateByAPPlanID(_APStockIn, conn);

            //    }
            //    if (affectedRows > 0)
            //    {
            //        ToastMessageBox.Show(Resource.msgSuccessfullySaved);

            //    }
            //    else
            //        ToastMessageBox.Show(Resource.errFailedToSave);
            //}
            catch (SqlException sqle)
            {
                //_logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void AddingNewRow(DataGridView dgv)
        {
            if (dgv.Rows.Count > 0 && dgv != null)
            {
                dgv.Rows[dgv.Rows.Count - 1].Cells[colAPSubCategory.Index].Value = this.APSubCategoryID;
                dgv.Rows[dgv.Rows.Count - 1].Cells[colPosm.Index].Value = this._apEnquiryDetail.AP_MaterialID;
                dgv.Rows[dgv.Rows.Count - 1].Cells[colAP_EnquiryDetailID.Index].Value = this._apEnquiryDetail.ID;
                dgv.Rows[dgv.Rows.Count - 1].Cells[colQuantity.Index].Value = this.BalanceQty;
                dgv.Rows[dgv.Rows.Count - 1].Cells[colUnitCost.Index].Value = this._apEnquiryDetail.UnitCost;
                dgv.Rows[dgv.Rows.Count - 1].Cells[colPurchasedDate.Index].Value = DateTime.Now;
                dgv.Rows[dgv.Rows.Count - 1].ReadOnly = true;
                dgv.Rows[dgv.Rows.Count - 1].Cells[colQuantity.Index].ReadOnly = false;
                dgv.Rows[dgv.Rows.Count - 1].Cells[colPurchasedDate.Index].ReadOnly = false;
                dgv.Rows[dgv.Rows.Count - 1].Cells[colPresentQty.Index].ReadOnly = false;
            }
        }

        #endregion
        private void lblFilter_Click(object sender, EventArgs e)
        {
        }

        private void dgvPosmPurchasedIn_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }

            if (this.dgvPosmPurchasedIn.CurrentCell.ColumnIndex == 0 && (e.Control is ComboBox))
            {
                cmb = e.Control as ComboBox;
                cmb.SelectionChangeCommitted += new EventHandler(cmb_SelectionChangeCommitted);
            }
        }

        private void cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvPosmPurchasedIn.CurrentCell.ColumnIndex == 0)
            {
                //  this.dgvAPEnquiry[1, this.dgvAPEnquiry.CurrentCell.RowIndex].Value = 0;
            }
        }

        private void dgvPosmPurchasedIn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvPosmPurchasedIn_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvPosmPurchasedIn.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvPosmPurchasedIn_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int newInteger = 0;
            decimal newDecimal = 0;
            var dgv = sender as DataGridView;
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            //if (e.ColumnIndex == colPosm.Index)
            //{
            //    foreach (DataGridViewRow row in dgvPosmPurchasedIn.Rows)
            //    {
            //        if (row.Index != e.RowIndex & !row.IsNewRow)
            //        {
            //            if (row.Cells["colPosm"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
            //            if (row.Cells["colPosm"].FormattedValue.ToString() == e.FormattedValue.ToString())
            //            {
            //                dgvPosmPurchasedIn.Rows[e.RowIndex].ErrorText = "Duplicate not allowed!";
            //                MessageBox.Show("Duplicate not allowed!", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            }
            //        }
            //    }
            //}
            if (e.ColumnIndex == colQuantity.Index)
            {
                if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger <= 0)
                {
                    dgvPosmPurchasedIn.Rows[e.RowIndex].ErrorText = "အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။";
                    ToastMessageBox.Show("အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။", Color.Red);
                    dgvPosmPurchasedIn[colQuantity.Index,dgvPosmPurchasedIn.CurrentRow.Index].Selected = true;
                }
            }
            else if (e.ColumnIndex == colUnitCost.Index)
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(),
                       out newDecimal) || newDecimal <= 0)
                {
                    dgvPosmPurchasedIn.Rows[e.RowIndex].ErrorText = "‌ငွေပမာဏမှားယွင်း‌နေပါသည်။";
                    ToastMessageBox.Show("‌ငွေပမာဏမှားယွင်း‌နေပါသည်။", Color.Red);
                }
            }

            if (e.ColumnIndex == colQuantity.Index)
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(),
                       out newDecimal) || newDecimal > this.BalanceQty)
                {
                    dgvPosmPurchasedIn.Rows[e.RowIndex].ErrorText = "ဝယ်ယူမည့်အရေအတွက်သည် လက်ကျန်အရေအတွက်ထက်များနေသည်။";
                    MessageBox.Show("‌ခွင့်ပြုအရေအတွက် " + this.BalanceQty + " ခုသာကျန်တော့သည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }

        private void dgvPosmPurchasedIn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.colPosm.Index)
                {
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvPosmPurchasedIn[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdunfilteredPOSM;

                    //  this.bdfilteredPOSM.RemoveFilter();
                }

            }

            catch { }

            if (dgvPosmPurchasedIn.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colQuantity.Index)
            {
                dgvPosmPurchasedIn.Rows[e.RowIndex].ErrorText = String.Empty;
                dgvPosmPurchasedIn.CurrentRow.Cells[colQuantity.Index].Value = 0;
                dgvPosmPurchasedIn[colQuantity.Index, dgvPosmPurchasedIn.CurrentRow.Index].Selected = true;
                //dgvPosmPurchasedIn.CurrentRow.Cells[colUnitCost.Index].Value = 0;
            }
            else if (dgvPosmPurchasedIn.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colPosm.Index)
            {
                dgvPosmPurchasedIn.Rows[e.RowIndex].ErrorText = String.Empty;
                dgvPosmPurchasedIn.CurrentRow.Cells[colPosm.Index].Value = -1;
                dgvPosmPurchasedIn[colPosm.Index, dgvPosmPurchasedIn.CurrentRow.Index].Selected = true;
                //  dgvPosmPurchasedIn.CurrentRow.Cells[colPosm.Index].Value = 1;
            }
            else if (dgvPosmPurchasedIn.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colUnitCost.Index)
            {
                dgvPosmPurchasedIn.Rows[e.RowIndex].ErrorText = String.Empty;
                dgvPosmPurchasedIn.CurrentRow.Cells[colUnitCost.Index].Value = 0;
                //dgvPosmPurchasedIn.CurrentRow.Cells[colUnitCost.Index].Value = 0;
            }


        }

        private void dgvPosmPurchasedIn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPosmPurchasedIn.Rows.Count > 0)
            {
                int Quantity = (int)DataTypeParser.Parse(dgvPosmPurchasedIn.CurrentRow.Cells[colQuantity.Index].Value, typeof(int), 1);
                decimal UnitCost = (decimal)DataTypeParser.Parse(dgvPosmPurchasedIn.CurrentRow.Cells[colUnitCost.Index].Value, typeof(decimal), 1);

                dgvPosmPurchasedIn.CurrentRow.Cells[colAmount.Index].Value = Quantity * UnitCost;
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvPosmPurchasedIn.CurrentCell.ColumnIndex;
                int iRow = dgvPosmPurchasedIn.CurrentCell.RowIndex;
                if (iColumn == dgvPosmPurchasedIn.Columns[colAmount.Index].Index && (int)DataTypeParser.Parse(dgvPosmPurchasedIn.CurrentRow.Cells[colAP_PurchasedDetailID.Index].Value, typeof(int), 0) != 0)
                {
                    if (iRow + 1 >= dgvPosmPurchasedIn.Rows.Count)
                    {
                        DataTable dtAPEnquiry = dgvPosmPurchasedIn.DataSource as DataTable;
                        DataRow newRow = dtAPEnquiry.NewRow();
                        dtAPEnquiry.Rows.Add(newRow);
                        this.dgvPosmPurchasedIn.DataSource = dtAPEnquiry;
                        AddingNewRow(dgvPosmPurchasedIn);
                        dgvPosmPurchasedIn[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        try
                        {
                            dgvPosmPurchasedIn.CurrentCell = dgvPosmPurchasedIn[0, iRow + 1];
                        }
                        catch (Exception)
                        {

                        }

                    }
                }
                else
                {
                    try
                    {
                        dgvPosmPurchasedIn.CurrentCell = dgvPosmPurchasedIn[dgvPosmPurchasedIn.CurrentCell.ColumnIndex + 1, dgvPosmPurchasedIn.CurrentCell.RowIndex];
                    }
                    catch (Exception ie)
                    {
                    }
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            if ((int)DataTypeParser.Parse(dgvPosmPurchasedIn.Rows[dgvPosmPurchasedIn.Rows.Count - 1].Cells[colAP_PurchasedDetailID.Index].Value, typeof(int), 0) != 0)
            {
                DataUtil.AddNewRow(dgvPosmPurchasedIn.DataSource as DataTable);
                AddingNewRow(dgvPosmPurchasedIn);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvPosmPurchasedIn.CurrentRow.ErrorText == String.Empty)
            {
                if (MessageBox.Show("Are you sure want to save?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes)
                    return;
                    Save();
            }
        }

        private void dtpStockInDate_ValueChanged(object sender, EventArgs e)
        {
            // LoadNBind();
        }

        private void dgvPosmPurchasedIn_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                    if ((int)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colAP_PurchasedDetailID.Index].Value, typeof(int), 0) != 0)
                    {
                        dgv.Rows[r.Index].ReadOnly = true;
                        //dgv.Rows[r.Index].Cells[colAccepted.Index].ReadOnly = false;
                    }

                    if (dgv.Rows.Count > 0)
                    {
                        int Quantity = (int)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colQuantity.Index].Value, typeof(int), 1);
                        decimal UnitCost = (decimal)DataTypeParser.Parse(dgvPosmPurchasedIn.Rows[r.Index].Cells[colUnitCost.Index].Value, typeof(decimal), 1);

                        dgvPosmPurchasedIn.Rows[r.Index].Cells[colAmount.Index].Value = Quantity * UnitCost;
                    }
                }
            }

        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            dgvPosmPurchasedIn.AutoGenerateColumns = false;
            dgvPosmPurchasedIn.DataSource = this._dtStockInDetail;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //fieldhashtable.Clear();
            //// fieldhashtable.Add("", (DateTime)DataTypeParser.Parse(cmbPOSM.SelectedValue, typeof(DateTime),DateTime.Now));
            //if (chkBrand.Checked)
            //{
            //    int BrandID = (int)DataTypeParser.Parse(cmbBrand.SelectedValue, typeof(int), -1);
            //    fieldhashtable.Add("BrandID", BrandID);
            //}
            //if (chkPosm.Checked)
            //{
            //    fieldhashtable.Add("APMaterialID", (int)DataTypeParser.Parse(cmbPOSM.SelectedValue, typeof(int), -1));
            //}
            //if (chkAPSubCat.Checked)
            //{
            //    fieldhashtable.Add("ID", (int)DataTypeParser.Parse(cmbAPSubCat.SelectedValue, typeof(int), -1));
            //}
            //dgvPosmPurchasedIn.AutoGenerateColumns = false;
            //dgvPosmPurchasedIn.DataSource = DataUtil.GetDataTableByExactFields(this._dtStockInDetail, fieldhashtable);
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmEnquiryAcceptedList));
            this.Close();
        }

        private void dgvPosmPurchasedIn_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colPosm.Index)
                {
                    int AP_SubCat = (int)DataTypeParser.Parse(this.dgvPosmPurchasedIn[e.ColumnIndex - 1, e.RowIndex].Value, typeof(int), 0);
                    if (AP_SubCat == 0) return;
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvPosmPurchasedIn[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdfilteredPOSM;

                    this.bdfilteredPOSM.Filter = "AP_SubCategoryID = " + this.dgvPosmPurchasedIn[e.ColumnIndex - 1, e.RowIndex].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dtpPurchasedDate_ValueChanged(object sender, EventArgs e)
        {
            LoadNBind();
            DataUtil.AddInitialNewRow(dgvPosmPurchasedIn);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Delete
            if (dgvPosmPurchasedIn.CurrentRow.IsNewRow || dgvPosmPurchasedIn.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;

            DataGridViewRow selectedRow = dgvPosmPurchasedIn.CurrentRow;
            int APPurchasedDetailID = (int)DataTypeParser.Parse(selectedRow.Cells["colAP_PurchasedDetailID"].Value, typeof(int), -1);
            if (APPurchasedDetailID == -1)
            {
                int Index = dgvPosmPurchasedIn.CurrentRow.Index;
                dgvPosmPurchasedIn.Rows.RemoveAt(Index);
                ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                //MessageBox.Show(Resource.errSuccessfullyDeleted, ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("ပစ္စည်းရောက်ပြီးဖြစ်၍ ပြင်ခွင့်မရှိပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
                // delete a selected order
                // DeleteAPPlanDetail(APStockInDetailID);
            }
        }

        private void DeleteAPPlanDetail(int APStockInDetailID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // delete an order detail
                //  int affectedRows = new A_P_PlanDetailBL().DeleteByAPPlanDetailID(APStockInDetailID, conn);
                int affectedRows = new AP_StockInBL().DeleteByAPStockInDetailID(APStockInDetailID, conn);
                if (affectedRows > 0)
                {
                    dgvPosmPurchasedIn.Rows.RemoveAt(dgvPosmPurchasedIn.CurrentRow.Index);
                    if (dgvPosmPurchasedIn.RowCount == 0)
                    {
                        DataTable apPlanDetailTbl = dgvPosmPurchasedIn.DataSource as DataTable;
                        DataRow newRow = apPlanDetailTbl.NewRow();
                        apPlanDetailTbl.Rows.Add(newRow);
                        dgvPosmPurchasedIn.DataSource = apPlanDetailTbl;
                    }
                    // show successful msg and close this
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                    LoadNBind();
                }

            }
            catch (SqlException sql)
            {
                // _logger.Error(sql);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

    }
}

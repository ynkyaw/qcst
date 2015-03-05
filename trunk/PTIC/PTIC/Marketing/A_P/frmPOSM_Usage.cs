/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/13 (yyyy/MM/dd)
 * Description: POSM Usage form
 */
using System;using PTIC.Common;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PTIC.VC.Marketing.A_P;
using log4net;
using log4net.Config;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Common.BL;
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.Marketing.BL;
using PTIC.Util;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.A_P
{
    /// <summary>
    /// POSM Usage
    /// </summary>
    public partial class frmPOSM_Usage : Form
    {
        /// <summary>
        /// Logger for frmPOSM_Usage
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmPOSM_Usage));

        /// <summary>
        /// 
        /// </summary>
        private BindingSource _bdAPSubCategory, _bdFilteredPOSM, _bdUnfilteredPOSM;

        private DataTable _dtEmployees;

        /// <summary>
        /// A & P Material stock in departments
        /// </summary>
        private DataTable _dtAPStockInDepartment;

        #region Events
        private void lblBakToAP_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmA_PMain));
            this.Close();
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
                        this.dgvAPUsageDetail.DataSource = dtAPEnquiry;
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
                    catch (Exception ie)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAPUsageDetail.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete a selected row?", "Remove confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //Save();
                    dgvAPUsageDetail.Rows.Remove(dgvAPUsageDetail.CurrentRow);
                    DataUtil.AddInitialNewRow(dgvAPUsageDetail);
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
            }
            else
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete, Color.Red);
            }
        }

        private void dgvAPUsageDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colA_P_Material.Index)
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
                if (e.ColumnIndex == this.colA_P_Material.Index)
                {
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvAPUsageDetail[e.ColumnIndex, e.RowIndex];
                    dgcb.DataSource = _bdUnfilteredPOSM;
                    //  this.bdfilteredPOSM.RemoveFilter();
                }
            }
            catch
            {
            }

            if (dgvAPUsageDetail.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colQty.Index)
            {
                dgvAPUsageDetail.Rows[e.RowIndex].ErrorText = String.Empty;
                dgvAPUsageDetail.CurrentRow.Cells[colQty.Index].Value = 0;
            }
            else if (dgvAPUsageDetail.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colA_P_Material.Index)
            {
                dgvAPUsageDetail.Rows[e.RowIndex].ErrorText = String.Empty;
                dgvAPUsageDetail.CurrentRow.Cells[colA_P_Material.Index].Value = -1;
                //  dgvPosmPurchasedIn.CurrentRow.Cells[colPosm.Index].Value = 1;
            }         
        }

        private void dgvAPUsageDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            }            
        }

        private void dgvAPUsageDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // TODO: handle data validation error
        }

        private void dgvAPUsageDetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvAPUsageDetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvAPUsageDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int requiredQty = 0; // user required qty
            //int balanceQty; // Qty in deparment
            //string APMaterialName;
            var dgv = sender as DataGridView;
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            //int APMaterialID = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colA_P_Material.Index].Value, typeof(int), -1);
            //int DeptID = (int)DataTypeParser.Parse(cmbDepartment.SelectedValue, typeof(int), -1);
            //DataTable dt = new AP_EnquiryBL().GetBalanceByAPMaterialIDDeptID(APMaterialID, DeptID);
            //if (dt.Rows.Count < 1)
            //{
            //    balanceQty = 0;
            //}
            //else
            //{
            //    APMaterialName = (string)DataTypeParser.Parse(dt.Rows[0]["APMaterialName"], typeof(string), String.Empty);
            //    balanceQty = (int)DataTypeParser.Parse(dt.Rows[0]["Qty"], typeof(int), 0);
            //}

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
                            MessageBox.Show("Duplicate not allowed!", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
            else if (e.ColumnIndex == colQty.Index)
            {
                if (!int.TryParse(e.FormattedValue.ToString(),
                        out requiredQty) || requiredQty <= 0)
                {
                    dgv.Rows[e.RowIndex].ErrorText = "အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။";
                    ToastMessageBox.Show("အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။", Color.Red);
                }
            }
            //if (balanceQty < requiredQty)
            //{
            //    String.Format("လက်ကျန် '{0}' သာရှိတော့သဖြင့် မလုံလောက်ပါ။", balanceQty);
            //    dgv.Rows[e.RowIndex].ErrorText = balanceQty.ToString();
            //    MessageBox.Show(balanceQty.ToString(), "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DeptID = (int)DataTypeParser.Parse(cmbDepartment.SelectedValue, typeof(int), -1);

            DataTable dtEmployeesByDept = DataUtil.GetDataTableBy(_dtEmployees, "DeptID", DeptID);
            cmbEmployee.DataSource = dtEmployeesByDept;
            cmbEmployee.ValueMember = "EmployeeID";
            cmbEmployee.DisplayMember = "EmpName";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        
        #endregion

        #region Private Methods
        private DataTable GetUsagePurposeEnum()
        {
            DataTable dtUsagePurpose = new DataTable();
            DataColumn cPurpose = new DataColumn("UsagePurpose", typeof(int));
            DataColumn cPurposeDespt = new DataColumn("UsagePurposeDespt", typeof(string));
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
            nRow[cPurposeDespt] = "လက်ဆောင်";
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

        private void LoadNBindNecessaryData()
        {
            SqlConnection conn = null;
            try
            {
                // Get db connection
                conn = DBManager.GetInstance().GetDbConnection();
                // Load and bind deparment
                cmbDepartment.DataSource = new DepartmentBL().GetAll();
                if (cmbDepartment.DataSource != null)
                    cmbDepartment.SelectedValue = (int)DataTypeParser.Parse(GlobalCache.LoginEmployee.DeptID, typeof(int),
                        (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                // Load and bind employee
                cmbEmployee.DataSource =_dtEmployees= new EmployeeBL().GetAll();
                //cmbEmployee.ValueMember = "EmployeeID";
                //cmbEmployee.DisplayMember = "EmpName";
                // Load and bind brand
                colBrand.DataSource = new BrandBL().GetAll();
                colBrand.ValueMember = "BrandID";
                colBrand.DisplayMember = "BrandName";

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
                colUsagePurpose.DataSource = GetUsagePurposeEnum();
                colUsagePurpose.ValueMember = "UsagePurpose";
                colUsagePurpose.DisplayMember = "UsagePurposeDespt";

                // Load A & P Material stock in departments
                this._dtAPStockInDepartment = new AP_StockInDepartmentBL().GetAll();
            }
            catch(SqlException sqle)
            {
                _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void LoadBy(int POSM_UsageID)
        {
            this.dgvAPUsageDetail.DataSource = new POSM_UsageDetailBL().GetByUsageID(POSM_UsageID);
        }

        private DataTable GetPOSM_UsageTableStructure()
        {
            DataTable dtPOSM = new DataTable();
            DataColumn cBrand = new DataColumn("BrandID", typeof(int));
            DataColumn cAP_Subcategory = new DataColumn("APSubCategoryID", typeof(int));
            DataColumn cAP_Material = new DataColumn("A_P_MaterialID", typeof(int));
            DataColumn cQty = new DataColumn("Qty", typeof(int));
            DataColumn cUsagePurpose = new DataColumn("UsagePurpose", typeof(int));
            DataColumn cRemark = new DataColumn("Remark", typeof(string));
            dtPOSM.Columns.AddRange(new DataColumn[] { 
                cBrand, cAP_Subcategory, cAP_Material, cQty, cUsagePurpose, cRemark
            });
            return dtPOSM;
        }

        private void Save()
        {
            SqlConnection conn = null;
            POSM_UsageBL usageSaver = null;
            try 
            {
                conn = DBManager.GetInstance().GetDbConnection();
                usageSaver = new POSM_UsageBL();
                POSM_Usage usage = new POSM_Usage() 
                {
                    DeptID = (int)DataTypeParser.Parse(cmbDepartment.SelectedValue, typeof(int), -1),
                                   //(int)PTIC.Common.Enum.PredefinedDepartment.Marketing),
                    //InchargeID = (int)DataTypeParser.Parse(cmbEmployee.SelectedValue, typeof(int), GlobalCache.LoginEmployee.ID),
                    InchargeID = (int)DataTypeParser.Parse(cmbEmployee.SelectedValue, typeof(int), -1),
                    Date = (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.MinValue)
                };
                // Check usage form
                string formValidationMsg = string.Empty;
                if (usage.DeptID == -1)
                    formValidationMsg = Resource.err_fill_department;
                else if(usage.InchargeID == -1)
                    formValidationMsg = Resource.err_fill_incharge;
                else if(usage.Date == DateTime.MinValue)
                    formValidationMsg = Resource.err_fill_date;
                if (!formValidationMsg.Equals(string.Empty))
                {
                    MessageBox.Show(formValidationMsg, Resource.Error,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<POSM_UsageDetail> usageDetails = new List<POSM_UsageDetail>();
                foreach (DataGridViewRow row in dgvAPUsageDetail.Rows)
                {
                    if (row.IsNewRow)
                        break;
                    POSM_UsageDetail detail = new POSM_UsageDetail() 
                    {
                        A_P_MaterialID = (int)DataTypeParser.Parse(row.Cells[colA_P_Material.Index].Value, typeof(int), -1),
                        BrandID = (int)DataTypeParser.Parse(row.Cells[colBrand.Index].Value, typeof(int), -1),
                        //POSM_UsageID = (int)DataTypeParser.Parse(row.Cells[colA_P_UsageID.Index].Value, typeof(int), -1),
                        Qty = (int)DataTypeParser.Parse(row.Cells[colQty.Index].Value, typeof(int), -1),
                        UsagePurpose = (int)DataTypeParser.Parse(row.Cells[colUsagePurpose.Index].Value, typeof(int), 
                                                    PTIC.Common.Enum.POSM_UsagePurpose.Other),
                        Remark = (string)DataTypeParser.Parse(row.Cells[colRemark.Index].Value, typeof(string), null),
                    };
                    usageDetails.Add(detail);
                }
                // Save 
                if (usageSaver.Add(usage, usageDetails, conn).HasValue)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    this.Close();
                    UIManager.MdiChildOpenForm(typeof(frmA_PMain));
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            catch(SqlException sqle)
            {
                _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion

        #region Constructor
        public frmPOSM_Usage()
        {
            InitializeComponent();
            // Disable auto generating columns
            dgvAPUsageDetail.AutoGenerateColumns = false;
            // Configure logger
            XmlConfigurator.Configure();
            // Load and bind necessary data : brand, AP sub-category,...
            LoadNBindNecessaryData();
            // Bind POSM data structure
            dgvAPUsageDetail.DataSource = GetPOSM_UsageTableStructure();
            // Add an initial new row
            DataUtil.AddInitialNewRow(dgvAPUsageDetail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="POSM_UsageID"></param>
        public frmPOSM_Usage(int POSM_UsageID, DateTime date, int departmentID, int inchargeID)
            : this()
        {
            // Disable Usage form data and control
            this.dtpDate.Enabled = this.cmbDepartment.Enabled = this.cmbEmployee.Enabled
                 = btnSave.Enabled = btnDelete.Enabled = dgvAPUsageDetail.Enabled = false;            
            this.dtpDate.Value = date;
            this.cmbDepartment.SelectedValue = departmentID;
            this.cmbEmployee.SelectedValue = inchargeID;
            LoadBy(POSM_UsageID);
        }
        #endregion

        private void dgvAPUsageDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Check balance qty in department to fullfill required qty
            if (colQty.Index != e.ColumnIndex || this._dtAPStockInDepartment == null)
                return;
            var dgv = sender as DataGridView;
            int requiredQty = 0;
            int balanceQty = 0;
            int AP_MaterialID = (int)DataTypeParser.Parse(dgv.Rows[e.RowIndex].Cells[colA_P_Material.Index].Value, typeof(int), -1);
            int deptID = (int)DataTypeParser.Parse(cmbDepartment.SelectedValue, typeof(int), -1);
            requiredQty = (int)DataTypeParser.Parse(dgv.Rows[e.RowIndex].Cells[colQty.Index].Value, typeof(int), 0);
            if (AP_MaterialID == -1 || deptID == -1 || requiredQty == 0)
                return;
            
            List<Tuple<string, object>> queryBuilder = new List<Tuple<string, object>>();
            Tuple<string, object> tpAP = Tuple.Create<string, object>("AP_MaterialID", AP_MaterialID);
            Tuple<string, object> tpDept = Tuple.Create<string, object>("DeptID", deptID);
            queryBuilder.Add(tpAP);
            queryBuilder.Add(tpDept);
            DataTable dt = DataUtil.GetDataTableByAND(this._dtAPStockInDepartment, queryBuilder);
            if (dt == null || dt.Rows.Count < 1) // if required A P Material has not existed in department
            {
                dgv.Rows[e.RowIndex].ErrorText = "Insufficient quantity";
                MessageBox.Show(string.Format(Resource.warn_txt_ap_doesnot_exist_in_dept, cmbDepartment.Text),
                    Resource.msg_hd_ap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            balanceQty = (int)DataTypeParser.Parse(dt.Rows[0]["Qty"], typeof(int), 0);

            if (requiredQty > balanceQty)
            {
                dgv.Rows[e.RowIndex].ErrorText = "Insufficient quantity";
                MessageBox.Show(string.Format(Resource.warn_txt_insufficient_ap_qty, balanceQty),
                    "သတိပေးချက်",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}

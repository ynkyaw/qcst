using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.BL;
using PTIC.Marketing.DA;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.VC;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.VC.Marketing;
using PTIC.VC.Marketing.Telemarketing;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Marketing.Telemarketing
{
    public partial class frmTeleMarketingMonthlyPlan : Form
    {
        DataTable dtIntialTeleMarketingPlan = null;
        DataTable dtGroupCustomer = null;

        public frmTeleMarketingMonthlyPlan()
        {
            InitializeComponent();
            //  Get Start and End of Date in Month
            int intMonth = DateTime.Now.Month;
            int intYear = DateTime.Now.Year;
            int intDaysThisMonth = DateTime.DaysInMonth(intYear, intMonth);
            DateTime oBeginnngOfThisMonth = new DateTime(intYear, intMonth, 1);
            DateTime EndOfThisMonth = new DateTime(intYear, intMonth, intDaysThisMonth);
            dtpFromDate.Value = oBeginnngOfThisMonth;
            dtpToDate.Value = EndOfThisMonth;

            LoadNBindData();
            DataUtil.AddInitialNewRow(dgvIntialTeleMarketingPlan);
        }

        #region Private Methods
        private void LoadNBindData()
        {
            try
            {
                //  CustomerInGroup
                dtGroupCustomer = new CustomersInGroupBL().GetAll();

                // Group Column
                DataTable dtGroup = new GroupDA().SelectAll();
                if (dtGroup != null)
                {
                    colCustomerGroup.DataSource = dtGroup;
                    colCustomerGroup.DisplayMember = "GroupName";
                    colCustomerGroup.ValueMember = "ID";
                }

                //  Select IntialMarketingPlan By DateRange
                DateTime FromDate = (DateTime)DataTypeParser.Parse(dtpFromDate.Value, typeof(DateTime), DateTime.Now);
                DateTime ToDate = (DateTime)DataTypeParser.Parse(dtpToDate.Value, typeof(DateTime), DateTime.Now);

                dtIntialTeleMarketingPlan = new InitialTeleMarketingPlanBL().GetByDateRange(FromDate, ToDate);
                if (dtIntialTeleMarketingPlan != null)
                {
                    //  Auto-Generate Columns false for DataGridView and Binding
                    dgvIntialTeleMarketingPlan.AutoGenerateColumns = false;
                    dgvIntialTeleMarketingPlan.DataSource = dtIntialTeleMarketingPlan;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Save()
        {
            int? affectedrows = 0;
            InitialTeleMarketingPlanBL initialTeleMarketingSaver = null;
            try
            {
                initialTeleMarketingSaver = new InitialTeleMarketingPlanBL();
                //  InitialTeleMarketingPlan DataGridView DataSource Into Datatable
                DataTable dt = dgvIntialTeleMarketingPlan.DataSource as DataTable;

                List<PTIC.Marketing.Entities.MarketingPlan> insertMarketingPlan = new List<PTIC.Marketing.Entities.MarketingPlan>();
                List<PTIC.Marketing.Entities.MarketingPlan> updateMarketingPlan = new List<PTIC.Marketing.Entities.MarketingPlan>();
                List<PTIC.Marketing.Entities.MarketingPlan> deleteMarketingPlan = new List<PTIC.Marketing.Entities.MarketingPlan>();


                //  Insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    InitialTeleMarketingPlan initialTeleMarketingPlan = new InitialTeleMarketingPlan()
                    {
                        ID = (int)DataTypeParser.Parse(row["TeleMarketingInitialPlanID"], typeof(int), -1),
                        PlanDate = (DateTime)DataTypeParser.Parse(row["PlanDate"], typeof(DateTime), DateTime.Now),
                        GroupID = (int)DataTypeParser.Parse(row["GroupID"].ToString(), typeof(int), -1),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };

                    DataTable dtGroupCustomerByGroupID = DataUtil.GetDataTableBy(dtGroupCustomer, "GroupID", initialTeleMarketingPlan.GroupID);
                    if (dtGroupCustomerByGroupID != null)
                    {
                        foreach (DataRow cusrow in dtGroupCustomerByGroupID.Rows)
                        {
                            PTIC.Marketing.Entities.MarketingPlan _marketingPlan = new Entities.MarketingPlan();
                            _marketingPlan.CustomerID = (int)DataTypeParser.Parse(cusrow["CustomerID"], typeof(int), -1);
                            _marketingPlan.PlanDate = (DateTime)DataTypeParser.Parse(initialTeleMarketingPlan.PlanDate, typeof(DateTime), DateTime.Now);
                            // _marketingPlan.EmpID = (int)DataTypeParser.Parse(GlobalCache.LoginEmployee.ID, typeof(int), -1);     
                            _marketingPlan.Status = (int)PTIC.Common.Enum.FormStatus.Reported;
                            _marketingPlan.MarketingType = (int)PTIC.Common.Enum.MarketingType.Telemarketing;
                            insertMarketingPlan.Add(_marketingPlan);
                        }
                    }
                    else
                    {
                        foreach (DataRow cusrow in dtGroupCustomer.Clone().Rows)
                        {
                            PTIC.Marketing.Entities.MarketingPlan _marketingPlan = new Entities.MarketingPlan();
                            _marketingPlan.CustomerID = (int)DataTypeParser.Parse(cusrow["CustomerID"], typeof(int), -1);
                            _marketingPlan.PlanDate = (DateTime)DataTypeParser.Parse(initialTeleMarketingPlan.PlanDate, typeof(DateTime), DateTime.Now);
                            // _marketingPlan.EmpID = (int)DataTypeParser.Parse(GlobalCache.LoginEmployee.ID, typeof(int), -1);                         
                            _marketingPlan.MarketingType = 1;
                            insertMarketingPlan.Add(_marketingPlan);
                        }
                    }

                    affectedrows = initialTeleMarketingSaver.Add(initialTeleMarketingPlan, insertMarketingPlan);

                    if (!initialTeleMarketingSaver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(initialTeleMarketingSaver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            "InitialTeleMarketingPlan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                }
               
                if (affectedrows.HasValue && affectedrows.Value > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    LoadNBindData();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            catch (SqlException Sqle)
            {
                //TODO:
                throw Sqle;
            }
        }



        private void ClearButton()
        {
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnView.Enabled = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvIntialTeleMarketingPlan.CurrentCell.ColumnIndex;
                int iRow = dgvIntialTeleMarketingPlan.CurrentCell.RowIndex;
                if (iColumn == dgvIntialTeleMarketingPlan.Columns[colRemark.Index].Index)
                {
                    if ((int)DataTypeParser.Parse(dgvIntialTeleMarketingPlan.CurrentRow.Cells[colTeleMarketingPlanID.Index].Value, typeof(int), -1) == -1)
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }

                    if (iRow + 1 >= dgvIntialTeleMarketingPlan.Rows.Count)
                    {
                        DataTable dtAPRequest = dgvIntialTeleMarketingPlan.DataSource as DataTable;
                        DataRow newRow = dtAPRequest.NewRow();
                        dtAPRequest.Rows.Add(newRow);
                        this.dgvIntialTeleMarketingPlan.DataSource = dtAPRequest;
                        dgvIntialTeleMarketingPlan[0, iRow + 1].Selected = true;
                        //dgvIntialMarketingPlan.CurrentCell = dgvIntialMarketingPlan[0, iRow + 1];
                    }
                    else
                    {
                        dgvIntialTeleMarketingPlan.CurrentCell = dgvIntialTeleMarketingPlan[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvIntialTeleMarketingPlan.CurrentCell = dgvIntialTeleMarketingPlan[dgvIntialTeleMarketingPlan.CurrentCell.ColumnIndex + 1, dgvIntialTeleMarketingPlan.CurrentCell.RowIndex];
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (dgvIntialTeleMarketingPlan.CurrentRow == null)
            {
                DataUtil.AddInitialNewRow(dgvIntialTeleMarketingPlan);
            }
            else if ((int)DataTypeParser.Parse(dgvIntialTeleMarketingPlan.CurrentRow.Cells[colTeleMarketingPlanID.Index].Value, typeof(int), -1) != -1)
            {
                DataUtil.AddNewRow(dgvIntialTeleMarketingPlan.DataSource as DataTable);
                dgvIntialTeleMarketingPlan[colIntialPlanDate.Index, dgvIntialTeleMarketingPlan.CurrentRow.Index + 1].Selected = true;
            }

            //if (dgvIntialTeleMarketingPlan == null) return;
            //DataUtil.AddNewRow(dgvIntialTeleMarketingPlan.DataSource as DataTable);
            //dgvIntialTeleMarketingPlan.CurrentCell = dgvIntialTeleMarketingPlan.Rows[dgvIntialTeleMarketingPlan.Rows.Count - 1].Cells[0];
        }

        private void dgvIntialTeleMarketingPlan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                e.CellStyle.Font = new System.Drawing.Font("Myanmar3", 10F);
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }
        }

        private void dgvIntialTeleMarketingPlan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvIntialTeleMarketingPlan.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvIntialTeleMarketingPlan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            //  Set Row number
            foreach (DataGridViewRow r in dgv.Rows)
            {
                dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if ((int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colTeleMarketingPlanID.Index].Value, typeof(int), -1) != -1)
                {
                    dgv.Rows[row.Index].ReadOnly = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            InitialTeleMarketingPlanBL _initialTeleMarketingPlanBL = new InitialTeleMarketingPlanBL();
            InitialTeleMarketingPlan _intialTeleMarketingPlan = new InitialTeleMarketingPlan();
            if (dgvIntialTeleMarketingPlan.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete); return;
            }
            else
            {
                if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    _intialTeleMarketingPlan.ID = (int)DataTypeParser.Parse(dgvIntialTeleMarketingPlan.SelectedRows[0].Cells[colTeleMarketingPlanID.Index].Value, typeof(int), -1);
                if (_intialTeleMarketingPlan.ID == -1)
                {
                    dgvIntialTeleMarketingPlan.Rows.RemoveAt(dgvIntialTeleMarketingPlan.SelectedRows[0].Index);
                    ClearButton();
                    return;
                }
                int affectedrow = _initialTeleMarketingPlanBL.Delete(_intialTeleMarketingPlan);
                if (affectedrow > 0)
                {
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                    ClearButton();
                    LoadNBindData();
                }
                else
                {
                    MessageBox.Show(Resource.errCantDelete, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            int InitialTeleMarketingPlan = (int)DataTypeParser.Parse(dgvIntialTeleMarketingPlan.CurrentRow.Cells[colTeleMarketingPlanID.Index].Value, typeof(int), -1);
            frmTeleMarketingLog _frmTeleMarketingLog = new frmTeleMarketingLog(InitialTeleMarketingPlan);
            UIManager.MdiChildOpenForm(_frmTeleMarketingLog);
        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));
            this.Close();
        }

        private void dgvIntialTeleMarketingPlan_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (e.ColumnIndex == colCustomerGroup.Index || e.ColumnIndex == colIntialPlanDate.Index)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex && !row.IsNewRow)
                    {
                        if (row.Cells["colCustomerGroup"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "")
                            return;
                        DateTime tmp = (DateTime)DataTypeParser.Parse(dgv.Rows[row.Index].Cells["colIntialPlanDate"].FormattedValue, typeof(DateTime), DateTime.MinValue);
                        DateTime tmp1 = (DateTime)DataTypeParser.Parse(dgv.CurrentRow.Cells["colIntialPlanDate"].FormattedValue, typeof(DateTime), DateTime.MinValue);

                        if (row.Cells["colCustomerGroup"].FormattedValue.ToString() == e.FormattedValue.ToString() && (tmp.ToShortDateString() == tmp1.ToShortDateString()))
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
                            MessageBox.Show("Duplicate Not Allowed!");
                            return;
                        }
                        else
                        {
                            dgv.Rows[e.RowIndex].ErrorText = String.Empty;
                        }
                    }
                }
            }
        }

        private void dgvIntialTeleMarketingPlan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if ((e.ColumnIndex == colCustomerGroup.Index || e.ColumnIndex == colIntialPlanDate.Index) && dgv.Rows[e.RowIndex].ErrorText != String.Empty) // Customer Group ID
            {
                dgv.CurrentRow.Cells[colCustomerGroup.Index].Value = -1;
                dgv.CurrentRow.Cells[colIntialPlanDate.Index].Value = DateTime.Now;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }

        }

        private void dgvIntialTeleMarketingPlan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            dtpToDate.Value = UIManager.ChangeAnotherdtpOndtpChange(dtpFromDate);
            LoadNBindData();
            DataUtil.AddInitialNewRow(dgvIntialTeleMarketingPlan);
        }



    }
}

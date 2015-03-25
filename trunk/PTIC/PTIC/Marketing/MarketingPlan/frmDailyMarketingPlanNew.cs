using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Marketing.DailyMarketing;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Marketing.Entities;
using PTIC.Sale.BL;
using System.Data.SqlClient;
using PTIC.Marketing.MarketingPlan;
using Microsoft.Practices.EnterpriseLibrary.Validation;


namespace PTIC.VC.Marketing.MarketingPlan
{
    public partial class frmDailyMarketingPlanNew : Form
    {
        /// <summary>
        /// DataTable for GetInitialMarketingPlan By From Date , To Date
        /// </summary>
        DataTable dtIntialMarketingPlan = null;

        ComboBox cmb;

        bool IsUpdate = false;
        int RowIndex = -1;

        #region Constructors
        public frmDailyMarketingPlanNew()
        {
            InitializeComponent();
            LoadNBindData();
            DataUtil.AddInitialNewRow(dgvIntialMarketingPlan);
            // Get Start and End of Date

            int intMonth = dtpFromDate.Value.Month;
            int intYear = dtpFromDate.Value.Year;
            int intDaysThisMonth = DateTime.DaysInMonth(intYear, intMonth);
            DateTime oBeginnngOfThisMonth = new DateTime(intYear, intMonth, 1);
            DateTime EndOfThisMonth = new DateTime(intYear, intMonth, intDaysThisMonth);
            dtpFromDate.Value = oBeginnngOfThisMonth;
            dtpToDate.Value = EndOfThisMonth;
        }
        #endregion

        #region Private Methods
        private DataTable GetDayEnum()
        {
            DataTable dtDay = new DataTable();
            DataColumn day = new DataColumn("Day", typeof(int));
            DataColumn name = new DataColumn("Name", typeof(string));
            dtDay.Columns.AddRange(new DataColumn[] 
            {
                day, name
            });
            DataRow nRow = dtDay.NewRow();

            nRow[day] = (int)PTIC.Common.Enum.Day.Monday;
            nRow[name] = PTIC.Common.Enum.Day.Monday;
            dtDay.Rows.Add(nRow);

            nRow = dtDay.NewRow();
            nRow[day] = (int)PTIC.Common.Enum.Day.Tuesday;
            nRow[name] = PTIC.Common.Enum.Day.Tuesday;
            dtDay.Rows.Add(nRow);

            nRow = dtDay.NewRow();
            nRow[day] = (int)PTIC.Common.Enum.Day.Wednesday;
            nRow[name] = PTIC.Common.Enum.Day.Wednesday;
            dtDay.Rows.Add(nRow);

            nRow = dtDay.NewRow();
            nRow[day] = (int)PTIC.Common.Enum.Day.Thursday;
            nRow[name] = PTIC.Common.Enum.Day.Thursday;
            dtDay.Rows.Add(nRow);

            nRow = dtDay.NewRow();
            nRow[day] = (int)PTIC.Common.Enum.Day.Friday;
            nRow[name] = PTIC.Common.Enum.Day.Friday;
            dtDay.Rows.Add(nRow);

            nRow = dtDay.NewRow();
            nRow[day] = (int)PTIC.Common.Enum.Day.Saturday;
            nRow[name] = PTIC.Common.Enum.Day.Saturday;
            dtDay.Rows.Add(nRow);

            nRow = dtDay.NewRow();
            nRow[day] = (int)PTIC.Common.Enum.Day.Sunday;
            nRow[name] = PTIC.Common.Enum.Day.Sunday;
            dtDay.Rows.Add(nRow);

            return dtDay;
        }


        private void LoadNBindData()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // Route Column
                DataTable dtRoute = new RouteBL().GetAll();
                if (dtRoute != null)
                {
                    colRoute.DataSource = dtRoute;
                    colRoute.DisplayMember = "RouteName";
                    colRoute.ValueMember = "RouteID";
                }

                // Days Column
                colIntialPlanDate.DataSource = GetDayEnum();
                colIntialPlanDate.ValueMember = "Day";
                colIntialPlanDate.DisplayMember = "Name";


                //  Select IntialMarketingPlan By DateRange
                DateTime FromDate = (DateTime)DataTypeParser.Parse(dtpFromDate.Value, typeof(DateTime), DateTime.Now);
                DateTime ToDate = (DateTime)DataTypeParser.Parse(dtpToDate.Value, typeof(DateTime), DateTime.Now);

                dtIntialMarketingPlan = new InitialMarketingPlanBL().GetAllByDateRange(FromDate, ToDate);
                if (dtIntialMarketingPlan != null)
                {
                    //  Auto-Generate Columns false for DataGridView and Binding
                    dgvIntialMarketingPlan.AutoGenerateColumns = false;
                    dgvIntialMarketingPlan.DataSource = dtIntialMarketingPlan;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Save()
        {
            SqlConnection conn = null;
            InitialMarketingPlanBL initialMarketingPlanSaver = null;
            int? affectedrows = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                initialMarketingPlanSaver = new InitialMarketingPlanBL();

                //  InitialMarketingPlan DataGridView DataSource Into Datatable
                DataTable dt = dgvIntialMarketingPlan.DataSource as DataTable;

                //  Insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    InitialMarketingPlan initialMarketingPlan = new InitialMarketingPlan()
                    {
                        InitialPlanDate = (DateTime)DataTypeParser.Parse(dtpFromDate.Value, typeof(DateTime), DateTime.Now),
                        RouteID = (int)DataTypeParser.Parse(row["RouteID"].ToString(), typeof(int), -1),
                        Day = (int)DataTypeParser.Parse(row["Day"].ToString(), typeof(int), -1),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };

                    affectedrows = initialMarketingPlanSaver.Add(initialMarketingPlan);

                    if (!initialMarketingPlanSaver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(initialMarketingPlanSaver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            "InitialMarketingPlan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {

                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);

                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    InitialMarketingPlan initialMarketingPlan = new InitialMarketingPlan()
                     {
                         ID = (int)DataTypeParser.Parse(row["IntialMarketingPlanID"], typeof(int), -1),
                         InitialPlanDate = (DateTime)DataTypeParser.Parse(dtpFromDate.Value, typeof(DateTime), DateTime.Now),
                         RouteID = (int)DataTypeParser.Parse(row["RouteID"].ToString(), typeof(int), -1),
                         Day = (int)DataTypeParser.Parse(row["Day"].ToString(), typeof(int), -1),
                         Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                     };

                    affectedrows = initialMarketingPlanSaver.Update(initialMarketingPlan);

                    if (!initialMarketingPlanSaver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(initialMarketingPlanSaver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            "InitialMarketingPlan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        dgvIntialMarketingPlan.Rows[RowIndex].ReadOnly = false;
                        dgvIntialMarketingPlan.CurrentCell = dgvIntialMarketingPlan.Rows[RowIndex].Cells[colIntialPlanDate.Index];                       
                        
                        return;
                    }

                }

                if (affectedrows.HasValue && affectedrows.Value > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    LoadNBindData();
                    ClearButton();
                }                
            }
            catch (SqlException Sqle)
            {
                //TODO:
                throw Sqle;
            }
        }
        #endregion

        #region Events
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvIntialMarketingPlan.CurrentCell.ColumnIndex;
                int iRow = dgvIntialMarketingPlan.CurrentCell.RowIndex;
                if (iColumn == dgvIntialMarketingPlan.Columns[colRemark.Index].Index)
                {
                    if (HasNewRow(dgvIntialMarketingPlan)) return base.ProcessCmdKey(ref msg, keyData);
                    Validate();
                    if (dgvIntialMarketingPlan.CurrentRow.ErrorText != String.Empty)
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }
                    else if((int)DataTypeParser.Parse(dgvIntialMarketingPlan.CurrentRow.Cells[colInitialMarketingPlanID.Index].Value,typeof(int),-1) == -1)
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }

                    if (iRow + 1 >= dgvIntialMarketingPlan.Rows.Count)
                    {
                        DataTable dtAPRequest = dgvIntialMarketingPlan.DataSource as DataTable;
                        DataRow newRow = dtAPRequest.NewRow();
                        dtAPRequest.Rows.Add(newRow);
                        this.dgvIntialMarketingPlan.DataSource = dtAPRequest;
                        dgvIntialMarketingPlan[0, iRow + 1].Selected = true;
                        btnNew.Enabled = false;
                        //dgvIntialMarketingPlan.CurrentCell = dgvIntialMarketingPlan[0, iRow + 1];
                    }
                    else
                    {
                        dgvIntialMarketingPlan.CurrentCell = dgvIntialMarketingPlan[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvIntialMarketingPlan.CurrentCell = dgvIntialMarketingPlan[dgvIntialMarketingPlan.CurrentCell.ColumnIndex + 1, dgvIntialMarketingPlan.CurrentCell.RowIndex];
                    }
                    catch (Exception ie)
                    {
                    }
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvIntialMarketingPlan.SelectedRows.Count > 0)
            {
                PTIC.Marketing.Entities.MarketingPlan _marketingPlan = new PTIC.Marketing.Entities.MarketingPlan();
                _marketingPlan.PlanDate = dtpFromDate.Value;
                _marketingPlan.InitialMarketingPlanID = (int)DataTypeParser.Parse(dgvIntialMarketingPlan.CurrentRow.Cells[colInitialMarketingPlanID.Index].Value, typeof(int), -1);
                int RouteID = (int)DataTypeParser.Parse(dgvIntialMarketingPlan.CurrentRow.Cells[colRouteID.Index].Value, typeof(int), -1);
                int Day = (int)DataTypeParser.Parse(dgvIntialMarketingPlan.CurrentRow.Cells[colIntialPlanDate.Index].Value, typeof(int), -1);

                //this.Close();
                frmDailyMarketingPlanCustomer _frmDailyMarketingPlanCustomer = new frmDailyMarketingPlanCustomer(RouteID, _marketingPlan, Day);
                UIManager.MdiChildOpenForm(_frmDailyMarketingPlanCustomer);
            }
            else
            {
                ToastMessageBox.Show(Resource.errSelectRow, Color.Red);
            }
        }

        private void lblHeaderPCat_Click(object sender, EventArgs e)
        {

        }

        private void lblFilter_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Visible)
            {
                pnlFilter.Visible = false;
                lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
                pnlGrid.Visible = true;
            }
            else
            {
                pnlFilter.Visible = true;
                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
                pnlGrid.Visible = false;
            }
        }
        #endregion

        private void ClearButton()
        {
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnView.Enabled = true;
        }

        private bool HasNewRow(DataGridView dgv)
        {
            int? DailyMarketingInitialPlanID = (int?)DataTypeParser.Parse(dgv.Rows[dgv.Rows.Count - 1].Cells[colInitialMarketingPlanID.Index].Value, typeof(int), null);

            if (DailyMarketingInitialPlanID != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            if (dgvIntialMarketingPlan == null) return;
            if (!HasNewRow(dgvIntialMarketingPlan))
            {
                if (dgvIntialMarketingPlan.CurrentRow.ErrorText == String.Empty)
                {
                    DataUtil.AddNewRow(dgvIntialMarketingPlan.DataSource as DataTable);
                    dgvIntialMarketingPlan.CurrentCell = dgvIntialMarketingPlan.Rows[dgvIntialMarketingPlan.Rows.Count - 1].Cells[0];
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvIntialMarketingPlan.CurrentRow.ErrorText == string.Empty)
            {
                Save();
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            LoadNBindData();
            DataUtil.AddInitialNewRow(dgvIntialMarketingPlan);
        }

        private void dgvIntialMarketingPlan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvIntialMarketingPlan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.Rows.Count < 1) return;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if ((int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colInitialMarketingPlanID.Index].Value, typeof(int), -1) != -1)
                {
                    dgv.Rows[row.Index].ReadOnly = true;
                }
            }

            //foreach (DataGridViewRow row in dgv.Rows)
            //{
            //    int Day = (int)DataTypeParser.Parse(row.Cells[colIntialPlanDate.Index].Value, typeof(int), 0);
            //    // Set Day type text
            //    switch (Day)
            //    {
            //        case 1:
            //            row.Cells[colIntialPlanDate.Index].Value = PTIC.Common.Enum.Day.Monday;
            //            break;
            //        case 2:
            //            row.Cells["colIntialPlanDate"].Value = PTIC.Common.Enum.Day.Tuesday;
            //            break;
            //        case 3:
            //            row.Cells["colIntialPlanDate"].Value = PTIC.Common.Enum.Day.Wednesday;
            //            break;
            //        case 4:
            //            row.Cells["colIntialPlanDate"].Value = PTIC.Common.Enum.Day.Thursday;
            //            break;
            //        case 5:
            //            row.Cells["colIntialPlanDate"].Value = PTIC.Common.Enum.Day.Friday;
            //            break;
            //        case 6:
            //            row.Cells["colIntialPlanDate"].Value = PTIC.Common.Enum.Day.Saturday;
            //            break;
            //        case 7:
            //            row.Cells["colIntialPlanDate"].Value = PTIC.Common.Enum.Day.Sunday;
            //            break;
            //        default:
            //            break;
            //    }

            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            InitialMarketingPlanBL _InitialMarketingPlanBL = new InitialMarketingPlanBL();
            InitialMarketingPlan _InitialMarketingPlan = new InitialMarketingPlan();

            if (dgvIntialMarketingPlan.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete); return;
            }
            else
            {
                if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    _InitialMarketingPlan.ID = (int)DataTypeParser.Parse(dgvIntialMarketingPlan.SelectedRows[0].Cells[colInitialMarketingPlanID.Index].Value, typeof(int), -1);
                if (_InitialMarketingPlan.ID == -1)
                {
                    dgvIntialMarketingPlan.Rows.RemoveAt(dgvIntialMarketingPlan.SelectedRows[0].Index);
                    ClearButton();
                    return;
                }
                int affectedrow = _InitialMarketingPlanBL.Delete(_InitialMarketingPlan);
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

        private void dgvIntialMarketingPlan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                e.CellStyle.Font = new System.Drawing.Font("Myanmar3", 10F);
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;

            }

            if (this.dgvIntialMarketingPlan.CurrentCell.ColumnIndex == 0 && (e.Control is ComboBox))
            {
                cmb = e.Control as ComboBox;
                cmb.SelectionChangeCommitted += new EventHandler(cmb_SelectionChangeCommitted);
            }
        }

        private void cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvIntialMarketingPlan.CurrentCell.ColumnIndex == 0)
            {
                //  this.dgvAPEnquiry[1, this.dgvAPEnquiry.CurrentCell.RowIndex].Value = 0;
            }
        }


        private void dgvIntialMarketingPlan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvIntialMarketingPlan.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            //  Get Start and End of Date in Month
            dtpToDate.Value = UIManager.ChangeAnotherdtpOndtpChange(dtpFromDate);

            LoadNBindData();
            DataUtil.AddInitialNewRow(dgvIntialMarketingPlan);
            //int intMonth =dtpFromDate.Value.Month;
            //int intYear = dtpFromDate.Value.Year;
            //int intDaysThisMonth = DateTime.DaysInMonth(intYear, intMonth);
            //DateTime oBeginnngOfThisMonth = new DateTime(intYear, intMonth, dtpFromDate.Value.Day);
            //DateTime EndOfThisMonth = new DateTime(intYear, intMonth, intDaysThisMonth);
            //dtpFromDate.Value = oBeginnngOfThisMonth;
            //dtpToDate.Value = EndOfThisMonth;
        }

        //private void Validate()
        //{
        //    if ((string)DataTypeParser.Parse(dgvIntialMarketingPlan.CurrentRow.Cells["colRoute"].FormattedValue, typeof(string), string.Empty) == string.Empty)
        //    {
        //        dgvIntialMarketingPlan.CurrentRow.ErrorText = "လမ်းကြောင်းရွေးပါ။";
        //        MessageBox.Show("လမ်းကြောင်းရွေးပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    else if ((string)DataTypeParser.Parse(dgvIntialMarketingPlan.CurrentRow.Cells["colIntialPlanDate"].FormattedValue, typeof(string), string.Empty) == string.Empty)
        //    {
        //        dgvIntialMarketingPlan.CurrentRow.ErrorText = "နေ့ရွေးပါ။";
        //        MessageBox.Show("နေ့ရွေးပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //}

        private void dgvIntialMarketingPlan_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //var dgv = sender as DataGridView;
            //if (dgv == null) return;

            //if (e.ColumnIndex == colRoute.Index || e.ColumnIndex == colIntialPlanDate.Index)
            //{
            //    foreach (DataGridViewRow row in dgv.Rows)
            //    {
            //        if (row.Index != e.RowIndex && !row.IsNewRow)
            //        {
            //            if (row.Cells["colRoute"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "")
            //                return;
            //            string tmp = (string)DataTypeParser.Parse(dgv.Rows[row.Index].Cells["colIntialPlanDate"].FormattedValue, typeof(string), null);
            //            string tmp1 = (string)DataTypeParser.Parse(dgv.CurrentRow.Cells["colIntialPlanDate"].FormattedValue, typeof(string), null);

            //            if (row.Cells["colRoute"].FormattedValue.ToString() == e.FormattedValue.ToString() && tmp == tmp1)
            //            {
            //                dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
            //                MessageBox.Show("Duplicate Not Allowed!");
            //                break;
            //            }
            //            else
            //            {
            //                dgv.Rows[e.RowIndex].ErrorText = string.Empty;
            //            }
            //        }
            //    }
            //}
        }

        private void dgvIntialMarketingPlan_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.CurrentRow == null) return;

            if (dgv.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colRoute.Index)
            {
                dgv.CurrentRow.Cells[colRoute.Index].Value = -1;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            else if (dgv.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colIntialPlanDate.Index)
            {
                dgv.CurrentRow.Cells[colIntialPlanDate.Index].Value = -1;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
        }

        private void dgvIntialMarketingPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvIntialMarketingPlan_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (IsUpdate == false && (int)DataTypeParser.Parse(dgvIntialMarketingPlan.Rows[dgvIntialMarketingPlan.Rows.Count - 1].Cells[colInitialMarketingPlanID.Index].Value, typeof(int), -1) != -1)
            {
                IsUpdate = true;
                RowIndex = (int)DataTypeParser.Parse(dgvIntialMarketingPlan.CurrentRow.Index, typeof(int), -1);
                dgvIntialMarketingPlan.CurrentRow.ReadOnly = false;
                btnNew.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (RowIndex == (int)DataTypeParser.Parse(dgvIntialMarketingPlan.CurrentRow.Index, typeof(int), -1))
            {
                dgvIntialMarketingPlan.CurrentRow.ReadOnly = false;
                btnNew.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (RowIndex != -1)
            {
                dgvIntialMarketingPlan.Rows[RowIndex].ReadOnly = false;
                dgvIntialMarketingPlan.CurrentCell = dgvIntialMarketingPlan.Rows[RowIndex].Cells[colIntialPlanDate.Index];
            }
        }
    }
}

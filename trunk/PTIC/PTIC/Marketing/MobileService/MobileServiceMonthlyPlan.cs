using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Util;
using System.Data.SqlClient;
using PTIC.Common;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using PTIC.Marketing.BL;
using PTIC.VC;
using PTIC.Marketing.Entities;
using PTIC.Marketing.MarketingPlan;
using PTIC.VC.Marketing;

namespace PTIC.Marketing.MobileService
{
    public partial class MobileServiceMonthlyPlan : Form
    {
        DataTable dtIntialMobileMarketingPlan = null;

        #region Constructors
     
        public MobileServiceMonthlyPlan()
        {
            InitializeComponent();
            LoadNBindData();

            DataUtil.AddInitialNewRow(dgvIntialMobileMarketingPlan);
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
        private void Save()
        {
            SqlConnection conn = null;
            int affectedrows = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                
                //  InitialMarketingPlan DataGridView DataSource Into Datatable
                DataTable dt = dgvIntialMobileMarketingPlan.DataSource as DataTable;

                //  Insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    InitialMobileServicePlan initialMobileServicePlan = new InitialMobileServicePlan()
                    {
                        InitialPlanDate = (DateTime)DataTypeParser.Parse(dtpFromDate.Value, typeof(DateTime), DateTime.Now),
                        RouteID = (int)DataTypeParser.Parse(row["RouteID"].ToString(), typeof(int), -1),
                        Day = (int)DataTypeParser.Parse(row["Day"].ToString(), typeof(int), -1),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };
                    if (initialMobileServicePlan.RouteID != -1)
                    {
                        affectedrows = new InitialMobileServicePlanBL().Add(initialMobileServicePlan);
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
                    InitialMobileServicePlan initialMobileServicePlan = new InitialMobileServicePlan()
                    {
                        ID = (int)DataTypeParser.Parse(row["InitialMobileServicePlanID"], typeof(int), -1),
                        InitialPlanDate = (DateTime)DataTypeParser.Parse(dtpFromDate.Value, typeof(DateTime), DateTime.Now),
                        RouteID = (int)DataTypeParser.Parse(row["RouteID"].ToString(), typeof(int), -1),
                        Day = (int)DataTypeParser.Parse(row["Day"].ToString(), typeof(int), -1),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };
                    if (initialMobileServicePlan.RouteID != -1)
                    {
                        affectedrows = new InitialMobileServicePlanBL().Update(initialMobileServicePlan);
                    }
                }

                if (affectedrows > 0)
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
                
                dtIntialMobileMarketingPlan = new InitialMobileServicePlanBL().GetAllByDateRange(FromDate, ToDate);
                if (dtIntialMobileMarketingPlan != null)
                {
                    //  Auto-Generate Columns false for DataGridView and Binding
                    dgvIntialMobileMarketingPlan.AutoGenerateColumns = false;
                    dgvIntialMobileMarketingPlan.DataSource = dtIntialMobileMarketingPlan;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvIntialMobileMarketingPlan.DataSource as DataTable);
            dgvIntialMobileMarketingPlan.CurrentCell = dgvIntialMobileMarketingPlan.Rows[dgvIntialMobileMarketingPlan.Rows.Count - 1].Cells[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvIntialMobileMarketingPlan.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure want to delete Selected Row?", "အတည်ပြုချက်", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int Index = dgvIntialMobileMarketingPlan.CurrentRow.Index;
                    dgvIntialMobileMarketingPlan.Rows.RemoveAt(Index);
                }
            }
            else
            {
                MessageBox.Show(Resource.errSelectRowToDelete, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvIntialMobileMarketingPlan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                e.CellStyle.Font = new System.Drawing.Font("Myanmar3", 10F);
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;

            }
        }

        private void dgvIntialMobileMarketingPlan_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvIntialMobileMarketingPlan.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvIntialMobileMarketingPlan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvIntialMobileMarketingPlan.SelectedRows.Count > 0)
            {
                MobileServicePlan _mobileServicePlan = new MobileServicePlan();
                _mobileServicePlan.SvcPlanDate = dtpFromDate.Value;
                _mobileServicePlan.InitialMobileServicePlanID = (int)DataTypeParser.Parse(dgvIntialMobileMarketingPlan.CurrentRow.Cells[colInitialMobileServicePlanID.Index].Value, typeof(int), -1);
                int RouteID = (int)DataTypeParser.Parse(dgvIntialMobileMarketingPlan.CurrentRow.Cells[colRouteID.Index].Value, typeof(int), -1);
                int Day = (int)DataTypeParser.Parse(dgvIntialMobileMarketingPlan.CurrentRow.Cells[colIntialPlanDate.Index].Value, typeof(int), -1);
                
            
                frmMobileServicePlanCustomer _frmDailyMarketingPlanCustomer = new frmMobileServicePlanCustomer(RouteID, _mobileServicePlan, Day);
                UIManager.MdiChildOpenForm(_frmDailyMarketingPlanCustomer);
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            LoadNBindData();
            DataUtil.AddInitialNewRow(dgvIntialMobileMarketingPlan);
        }

        private void dgvIntialMobileMarketingPlan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
                if ((int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colInitialMobileServicePlanID.Index].Value, typeof(int), -1) != -1)
                {
                    dgv.Rows[row.Index].ReadOnly = true;
                }
            }
        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));
            this.Close();
        }

        private void dgvIntialMobileMarketingPlan_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (e.ColumnIndex == colRoute.Index || e.ColumnIndex == colIntialPlanDate.Index)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex && !row.IsNewRow)
                    {
                        if (row.Cells["colRoute"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "")
                            return;
                        DateTime tmp = (DateTime)DataTypeParser.Parse(dgv.Rows[row.Index].Cells["colIntialPlanDate"].FormattedValue, typeof(DateTime), DateTime.MinValue);
                        DateTime tmp1 = (DateTime)DataTypeParser.Parse(dgv.CurrentRow.Cells["colIntialPlanDate"].FormattedValue, typeof(DateTime), DateTime.MinValue);

                        if (row.Cells["colRoute"].FormattedValue.ToString() == e.FormattedValue.ToString() && (tmp.ToShortDateString() == tmp1.ToShortDateString()))
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
    }
}

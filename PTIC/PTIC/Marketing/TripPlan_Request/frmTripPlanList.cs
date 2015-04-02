using System;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using PTIC.VC.Util;
using PTIC.VC.Marketing.DailyMarketing;
using PTIC.Sale.SalePlanning;

namespace PTIC.VC.Marketing.MarketingPlan
{
    public partial class frmTripPlanList : Form
    {
        /// <summary>
        /// Logger for frmTripPlanList
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmTripPlanList));


        public bool is_sale { get; set; }

        public frmTripPlanList()
        {
            InitializeComponent();
            dgvTripPlanList.AutoGenerateColumns = false;
            SetDefaultValue();
            LoadNBindTripPlanList();
        }
    
        private void SetDefaultValue()
        {
            int intMonth = dtpStart.Value.Month;
            int intYear = dtpStart.Value.Year;
            int intDaysThisMonth = DateTime.DaysInMonth(intYear, intMonth);
            DateTime oBeginnngOfThisMonth = new DateTime(intYear, intMonth, 1);
            DateTime EndOfThisMonth = new DateTime(intYear, intMonth, intDaysThisMonth);

            dtpStart.Value = oBeginnngOfThisMonth;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //to view
            frmTripPlan frm = new frmTripPlan();
            frm.Show();
        }
              
        private void button1_Click(object sender, EventArgs e)
        {
            frmTripPlan newFrmTripPlan = new frmTripPlan();
            // Set call back handler            
            newFrmTripPlan.TripPlanSavedHandler += new frmTripPlan.TripPlanSaveHandler(newFrmTripPlan_CallBack);
            UIManager.OpenForm(newFrmTripPlan);         
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All trip plans for 3 months will be reported.");
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu conmenu = new ContextMenu();
                MenuItem item1 = new MenuItem("View Detail Plan");
                MenuItem item2 = new MenuItem("Edit Detail Plan");

                item1.Click += new System.EventHandler(ViewPlan);
                conmenu.MenuItems.Add(item1);

                item2.Click += new System.EventHandler(EditPlan);
                conmenu.MenuItems.Add(item2);

                conmenu.Show(dgvTripPlanList, new Point(e.X, e.Y));
            }
        }

        private void ViewPlan(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            frmTripPlan frm = new frmTripPlan();
            frm.Show();
        }

        private void EditPlan(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            frmTripPlan frm = new frmTripPlan();
            frm.Show();
        }

        private void butAddNew_Click(object sender, EventArgs e)
        {
            frmTripPlan newFrmTripPlan = new frmTripPlan();
            // Set call back handler            
            newFrmTripPlan.TripPlanSavedHandler += new frmTripPlan.TripPlanSaveHandler(newFrmTripPlan_CallBack);
            UIManager.OpenForm(newFrmTripPlan);
        }

        private void butSearch_Click(object sender, EventArgs e)
        {
            DateTime startDate = (DateTime)DataTypeParser.Parse(dtpStart.Value, typeof(DateTime), DateTime.Now);
            DateTime endDate = (DateTime)DataTypeParser.Parse(dtpEnd.Value, typeof(DateTime), DateTime.Now);
            
            startDate = new DateTime(startDate.Year, startDate.Month, 1);
            endDate = new DateTime(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));

            if (Program.module == Program.Module.Sale)
            {
                dgvTripPlanList.DataSource = new TripPlanBL().SelectBy(startDate, endDate, true);
            }
            else if(Program.module == Program.Module.Marketing)
            {
                dgvTripPlanList.DataSource = new TripPlanBL().SelectBy(startDate, endDate, false);
            }
        }

        private void LoadNBindTripPlanList()
        {
            try
            {                
                DateTime fromDate = dtpStart.Value;
                DateTime toDate = dtpEnd.Value;                                
                dgvTripPlanList.DataSource = new TripPlanBL().SelectBy(fromDate, toDate, GlobalCache.is_sale);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        private void dgvTripPlanList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvTripPlanList.CurrentRow.IsNewRow || dgvTripPlanList.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectModifyRecord);
                return;
            }
            // Get an order
            DataGridViewRow selectedRow = dgvTripPlanList.CurrentRow;
            TripPlan mTripPlan = new TripPlan()
            {

                ID = (int)DataTypeParser.Parse(selectedRow.Cells["clnTripPlanID"].Value, typeof(int), -1),
                TripPlanName = selectedRow.Cells["clnTripPlanName"].Value.ToString(),
                FromDate = (DateTime)DataTypeParser.Parse(selectedRow.Cells["clnFromDate"].Value, typeof(DateTime), DateTime.Now),
                ToDate = (DateTime)DataTypeParser.Parse(selectedRow.Cells["clnToDate"].Value, typeof(DateTime), DateTime.Now)
            };

            frmTripPlan newFrmTripPlan = new frmTripPlan(mTripPlan);
            // Set call back handler            
            newFrmTripPlan.TripPlanSavedHandler += new frmTripPlan.TripPlanSaveHandler(newFrmTripPlan_CallBack);
            UIManager.OpenForm(newFrmTripPlan);
        }

        private void newFrmTripPlan_CallBack(object sender, frmTripPlan.TripPlanSaveEventArgs e)
        {
            if (e.OccuredChanges)
                LoadNBindTripPlanList();
        }

        private void dgvTripPlanList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void lblSalePage_Click(object sender, EventArgs e)
        {
            if (GlobalCache.is_sale == false)
            {
                UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));
                this.Close();
            }
            else
            {
                UIManager.MdiChildOpenForm(typeof(frmSalePlanningPage));
                this.Close();
            }
        }

        private void frmTripPlanList_Load(object sender, EventArgs e)
        {
            dgvTripPlanList.RowHeadersDefaultCellStyle.BackColor = Color.Black;
            dgvTripPlanList.RowTemplate.Height = Config.LayoutConfig.GridViewRowHeight;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if(dtpStart.Value.CompareTo(dtpEnd.Value)>0)
            {
                dtpEnd.Value = dtpStart.Value;
            }

            dtpEnd.MinDate = dtpStart.Value;  
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTripPlanList.CurrentRow == null)
                return;
            if (dgvTripPlanList.CurrentRow.IsNewRow || dgvTripPlanList.SelectedRows.Count < 1)
            {
                MessageBox.Show(Resource.errSelectRowToDelete, this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            DataGridViewRow selectedRow = dgvTripPlanList.CurrentRow;
            if (selectedRow == null)
                return;

            int selectedTripPlanID = (int)DataTypeParser.Parse(selectedRow.Cells[clnTripPlanID.Index].Value, typeof(int), -1);
            // Delete a selected trip plan
            DeleteTripPlan(selectedTripPlanID);
        }

        private void DeleteTripPlan(int tripPlanID)
        {
            try
            {
                int affectedRows = new TripPlanBL().DeleteByTripPlanID(tripPlanID);
                if (affectedRows > 0)
                {
                    dgvTripPlanList.Rows.RemoveAt(dgvTripPlanList.CurrentRow.Index);
                    // show successful msg and close this
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
         
    }
}

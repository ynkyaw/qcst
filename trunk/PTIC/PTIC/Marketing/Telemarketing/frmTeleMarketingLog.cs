using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Marketing.BL;
using log4net;
using PTIC.VC.Util;
using PTIC.Marketing.Entities;
using PTIC.Util;

namespace PTIC.VC.Marketing.Telemarketing
{
    public partial class frmTeleMarketingLog : Form
    {

        /// <summary>
        /// Logger for frmNewOrder
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmTeleMarketingLog));
        int InitialTeleMarketingPlan = -1;

        #region Events
        private void dgvTelemarketingLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0)
            //    return;

            //if (dgvTelemarketingLog.CurrentCell.ColumnIndex == 3)
            //{
            //    frmTelemarketingDetail frmTelemarketingDetail = new frmTelemarketingDetail();
            //    frmTelemarketingDetail.Show();
            //}

        }

        private void dgvTelemarketingLog_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvTelemarketingLog.Rows[e.RowIndex].Cells["colNo"].Value = (e.RowIndex + 1).ToString();
        }

        private void dgvTelemarketingLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgvTelemarketingLogVar = sender as DataGridView;
            if (e.RowIndex < 0 || e.ColumnIndex != dgvTelemarketingLog.Columns["colTeleMarketingDetail"].Index)
                return;
            //DateTime planDate = (DateTime)DataTypeParser.Parse(dgvTelemarketingLogVar.CurrentRow.Cells[colPlanDate.Index].Value, typeof(DateTime), DateTime.MinValue);
            //if (planDate.ToShortDateString() != DateTime.Now.ToShortDateString())
            //{
            //    MessageBox.Show("သွားရမည့်နေ့မဟုတ်ပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            // Parameters to frmTeleyMarketingDetail
            TeleMarketingDetail teleMarketingDetail = new TeleMarketingDetail()
            {
                //ID = (int?)DataTypeParser.Parse(dgvLog[e.ColumnIndex, e.RowIndex].Value, typeof(int), null),
                ID = (int?)DataTypeParser.Parse(dgvTelemarketingLog.Rows[e.RowIndex].Cells["colmarketingDetailID"].Value, typeof(int), null),
                CusID = (int?)DataTypeParser.Parse(dgvTelemarketingLog.Rows[e.RowIndex].Cells["colCusID"].Value, typeof(int), null),
                EmpID = (int?)DataTypeParser.Parse(dgvTelemarketingLog.Rows[e.RowIndex].Cells["colEmpID"].Value, typeof(int), null),
                MarketingPlanID = (int?)DataTypeParser.Parse(dgvTelemarketingLog.Rows[e.RowIndex].Cells["colMarketingPlanID"].Value, typeof(int), null),
            };
            if (teleMarketingDetail.MarketingPlanID == null)
                return;

            int customerType = (int)DataTypeParser.Parse(dgvTelemarketingLog.Rows[e.RowIndex].Cells["colCusType"].Value, typeof(int), -1);
            int customerName = (int)DataTypeParser.Parse(dgvTelemarketingLog.Rows[e.RowIndex].Cells["colCusID"].Value, typeof(int), -1);
            int township = (int)DataTypeParser.Parse(dgvTelemarketingLog.Rows[e.RowIndex].Cells["colTownshipID"].Value, typeof(int), -1);
            string employeeName = (string)DataTypeParser.Parse(dgvTelemarketingLog.Rows[e.RowIndex].Cells["colEmpName"].Value, typeof(string), string.Empty);

            // Open frmMarketingDetails
            frmTelemarketingDetail frmTelemarketingDetail = new frmTelemarketingDetail(customerType, customerName, township, employeeName, teleMarketingDetail);
            // set call back handler
            frmTelemarketingDetail.TeleMarketingDetailSavedHandlers += new frmTelemarketingDetail.TeleMarketingDetailSavedHandler(TeleMarketingDetailSaved_CallBack);
            UIManager.OpenForm(frmTelemarketingDetail);
        }

        private void TeleMarketingDetailSaved_CallBack(object sender, frmTelemarketingDetail.TeleMarketingDetailSaveEventArgs e)
        {
            // If marketing detail occured changes, reload marketing log
            if (e.OccuredChanges)
                LoadNBindMarketingLog(dtpStartDate.Value, dtpEndDate.Value);
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmTeleMarketingPage));
            this.Close();
        }

        private void dgvTelemarketingLog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgLog = sender as DataGridView;
            foreach (DataGridViewRow row in dgLog.Rows)
            {
                // Set New / Modify detail
                int hasDetail = (int)DataTypeParser.Parse(row.Cells["colIsMarketed"].Value, typeof(int), 0);
                if (hasDetail == 0)
                    row.Cells["colTelemarketingDetail"].Value = Resource.Add;
                else
                    row.Cells["colTelemarketingDetail"].Value = Resource.Modify;
            }
        }

        private void lblFilter_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Visible)
            {
                pnlFilter.Visible = false;
                lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
            }
            else
            {
                pnlFilter.Visible = true;
                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadNBindMarketingLog(dtpStartDate.Value, dtpEndDate.Value);
        }
        #endregion

        #region Constructors
        public frmTeleMarketingLog()
        {
            InitializeComponent();
            dgvTelemarketingLog.AutoGenerateColumns = false;
            // Load log first and last date of this month
            DateTime curDate = DateTime.Now;
            int intMonth = curDate.Month;
            int intYear = curDate.Year;
            int intDaysInThisMonth = DateTime.DaysInMonth(intYear, intMonth);
            DateTime startDate = new DateTime(intYear, intMonth, 1);
            DateTime endDate = new DateTime(intYear, intMonth, intDaysInThisMonth);
            dtpStartDate.Value = startDate;
            dtpEndDate.Value = endDate;
            LoadNBindMarketingLog(startDate, endDate);
        }

        public frmTeleMarketingLog(int InitialTeleMarketingPlanID)
        {
            InitializeComponent();
            this.InitialTeleMarketingPlan = InitialTeleMarketingPlanID;
            BindDataGidView(this.InitialTeleMarketingPlan);
        }
        #endregion

        #region Private Methods
        private void BindDataGidView(int InitialTeleMarketingPlan)
        {            
            try
            {                
                dgvTelemarketingLog.AutoGenerateColumns = false;
                DataTable dtMarketingPlan = new DataTable();
                // TODO: Get telemarketing log by initialTelemarketingPlanID instead of filtering via all logs
                //dtMarketingPlan = new MarketingPlanBL().GetTelemarketingLog();
                //dtMarketingPlan = new MarketingPlanBL().GetMarketingPlan(1,conn);
             //   DataTable dtTeleMarketingPlanByID = DataUtil.GetDataTableBy(dtMarketingPlan, "TeleMarketingInitialPlan", InitialTeleMarketingPlan);
                DataTable dtTeleMarketingPlanByID = new MarketingPlanBL().GetDailyMarketingLogByInitialTeleMarketingPlanID(InitialTeleMarketingPlan);
                if (dtTeleMarketingPlanByID != null)
                {
                    dgvTelemarketingLog.DataSource = dtTeleMarketingPlanByID;
                }
                else
                {
                    dgvTelemarketingLog.DataSource = dtMarketingPlan.Clone();
                }
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
            }            
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        private void LoadNBindMarketingLog(DateTime startDate, DateTime endDate)
        {
            try
            {
                dgvTelemarketingLog.DataSource = new MarketingPlanBL().GetTelemarketingLogBy(startDate, endDate);
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
            }
        }        
        #endregion

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.Value = UIManager.ChangeAnotherdtpOndtpChange(dtpStartDate);
        }
                                
    }
}

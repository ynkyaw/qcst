/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/MM/dd)
 * Description: Daily Marketing Log form
 */
using System;
using System.Windows.Forms;
using log4net;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.Sale.Entities;
using PTIC.Marketing.Entities;

namespace PTIC.VC.Marketing.DailyMarketing
{
    /// <summary>
    /// Daily Marketing Log form
    /// </summary>
    public partial class frmDailyMarketingLog : Form
    {
        /// <summary>
        /// Logger for frmDailyMarketingLog
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmDailyMarketingLog));

        private int InitialMarketingPlanID = -1;

        private bool _searchByMarketedDateRange = false;

        #region Events
        private void dgvMarketingLog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgLog = sender as DataGridView;
            foreach (DataGridViewRow row in dgLog.Rows)
            {
                int customerType = (int)DataTypeParser.Parse(row.Cells["colCusType"].Value, typeof(int), 0);
                // Set customer type text
                switch(customerType)
                {
                    case 0:
                        row.Cells["colCustomerType"].Value = Resource.EndUser;
                        break;
                    case 1:
                        row.Cells["colCustomerType"].Value = Resource.RetailOutlet;
                        break;
                    case 2:
                        row.Cells["colCustomerType"].Value = Resource.WholesaleOutlet;
                        break;
                    case 3:
                        row.Cells["colCustomerType"].Value = Resource.Company;
                        break;
                    case 4:
                        row.Cells["colCustomerType"].Value = Resource.Government;
                        break;
                    default:
                        row.Cells["colCustomerType"].Value = Resource.EndUser;
                        break;
                }
                // Set New / Modify detail
                int hasDetail = (int)DataTypeParser.Parse(row.Cells["colIsMarketed"].Value, typeof(int), 0);
                if (hasDetail == 0)
                    row.Cells["colMarketingDetail"].Value = Resource.Add;
                else
                    row.Cells["colMarketingDetail"].Value = Resource.Modify;
            }
        }

        private void dgvMarketingLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgvLog = sender as DataGridView;
            if (e.RowIndex < 0 || e.ColumnIndex != dgvLog.Columns["colMarketingDetail"].Index)
                return;
            
            // Parameters to frmDailyMarketingDetail
            MarketingDetail marketingDetail = new MarketingDetail()
            {
                ID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colMarketingDetailID"].Value, typeof(int), null),
                //CusID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colDetailCusID"].Value, typeof(int), null),
                //EmpID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colDetailEmpID"].Value, typeof(int), null),
                CusID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colCusID"].Value, typeof(int), null),
                EmpID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colEmpID"].Value, typeof(int), null),
                MarketingPlanID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colMarketingPlanID"].Value, typeof(int), null),
            };
                        
            int customerTypeID = (int)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colCusType"].Value, typeof(int), 0);
            string customerType = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colCustomerType"].Value, typeof(string), string.Empty);
            string customerName = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colCusName"].Value, typeof(string), string.Empty);
            string township = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colTownship"].Value, typeof(string), string.Empty);
            string employeeName = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colEmpName"].Value, typeof(string), string.Empty);
            bool isPotentialCustomer = (bool)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells[colIsPotential.Index].Value, typeof(bool), false);

            //Address address = new Address() 
            //{
            //    TownID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colTownID"].Value, typeof(int), null),
            //    TownshipID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colTownshipID"].Value, typeof(int), null),
            //};
            
            Township townShip = new Township() 
            {
                TownID = (int)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colTownID"].Value, typeof(int), -1),
                TownshipID = (int)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colTownshipID"].Value, typeof(int), -1),
                TownshipName = township
            };

            Customer cus = new Customer() 
            {
                CusType = customerTypeID,
                CusName = customerName,
                IsPotential = isPotentialCustomer
            };
            // Open frmMarketingDetails            
            frmDailyMarketingDetail frmMarketingDetail = new frmDailyMarketingDetail(cus, customerType, employeeName, townShip, marketingDetail);
            // set call back handler                        
            frmMarketingDetail.DailyMarketingDetailSavedHandler += new frmDailyMarketingDetail.DailyMarketingDetailSaveHandler(DailyMarketingDetailSavedFromPlan_CallBack);
            UIManager.OpenForm(frmMarketingDetail);
        }

        private void DailyMarketingDetailSaved_CallBack(object sender, frmDailyMarketingDetail.DailyMarketingDetailSaveEventArgs e)
        {
            // If marketing detail occured changes, reload marketing log
            if (e.OccuredChanges)
            {                
                LoadNBindLogByPlannedDateRange(dtpPlannedStartDate.Value, dtpPlannedEndDate.Value);
            }
        }

        private void DailyMarketingDetailSavedFromPlan_CallBack(object sender, frmDailyMarketingDetail.DailyMarketingDetailSaveEventArgs e)
        {
            // If marketing detail occured changes, reload marketing log
            if (e.OccuredChanges)
            {
                int intMonth = dtpPlannedStartDate.Value.Month;
                int intYear = DateTime.Now.Year;
                int intDaysThisMonth = DateTime.DaysInMonth(intYear, intMonth);
                DateTime oBeginnngOfThisMonth = new DateTime(intYear, intMonth, 1);
                DateTime EndOfThisMonth = new DateTime(intYear, intMonth, intDaysThisMonth);              
                
                if(this._searchByMarketedDateRange)
                    LoadNBindLogByMarketedDateRange(oBeginnngOfThisMonth, EndOfThisMonth);
                else
                    LoadNBindLogByPlannedDateRange(oBeginnngOfThisMonth, EndOfThisMonth);
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmDailyMarketingPage));
            this.Close();
        }

        private void dgvMarketingLog_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvMarketingLog.Rows[e.RowIndex].Cells["colNo"].Value = (e.RowIndex + 1).ToString();
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

        private void btnSearchByPlannedDate_Click(object sender, EventArgs e)
        {
            LoadNBindLogByPlannedDateRange(dtpPlannedStartDate.Value, dtpPlannedEndDate.Value);
            this._searchByMarketedDateRange = false;
        }

        private void btnSearchByMarketedDate_Click(object sender, EventArgs e)
        {
            LoadNBindLogByMarketedDateRange(dtpPlannedStartDate.Value, dtpPlannedEndDate.Value);
            this._searchByMarketedDateRange = true;
        }
        #endregion

        #region Private Methods
        private void LoadNBindLogByPlannedDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                dgvMarketingLog.DataSource = new MarketingPlanBL().GetDailyMarketingLogByPlannedDateRange(startDate, endDate);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }

        private void LoadNBindLogByMarketedDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                dgvMarketingLog.DataSource = new MarketingPlanBL().GetDailyMarketingLogByMarketedDateRange(startDate, endDate);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }

        //private void LoadNBindMarketingLogByDateRangeAndRouteID(DateTime startDate, DateTime endDate, int routeID)
        //{
        //    try
        //    {
        //        dgvMarketingLog.DataSource = new MarketingPlanBL().GetDailyMarketingLogByDateRangeAndRouteID(startDate, endDate, routeID);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.Error(e);
        //    }          
        //}

        private void LoadNBindMarketingLogByInitialMarketingPlanID(int InitialMarketingPlanID)
        {
            try
            {
                dgvMarketingLog.DataSource = new MarketingPlanBL().GetDailyMarketingLogByInitialMarketingPlanID(InitialMarketingPlanID);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }
        #endregion

        #region Constructors
        public frmDailyMarketingLog()
        {
            InitializeComponent();
            // Disable auto generating columns
            dgvMarketingLog.AutoGenerateColumns = false;
            // Load log first and last date of this month
            DateTime curDate = DateTime.Now;
            int intMonth = curDate.Month;
            int intYear = curDate.Year;
            int intDaysInThisMonth = DateTime.DaysInMonth(intYear, intMonth);
            DateTime startDate = new DateTime(intYear, intMonth, 1);
            DateTime endDate = new DateTime(intYear, intMonth, intDaysInThisMonth);
            dtpPlannedStartDate.Value = startDate;
            dtpPlannedEndDate.Value = endDate;

            LoadNBindLogByPlannedDateRange(startDate, endDate);
        }

        public frmDailyMarketingLog(int InitialMarketingPlanID)
        {
            InitializeComponent();
            // Disable auto generating columns
            dgvMarketingLog.AutoGenerateColumns = false;
            this.InitialMarketingPlanID = InitialMarketingPlanID;
            LoadNBindMarketingLogByInitialMarketingPlanID(this.InitialMarketingPlanID);
        }
        #endregion

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
           dtpPlannedEndDate.Value = UIManager.ChangeAnotherdtpOndtpChange(dtpPlannedStartDate);
        }
                                                           
    }
}

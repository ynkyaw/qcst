/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/MM/dd)
 * Description: Mobile Service Log form
 */
using System;
using System.Windows.Forms;
using log4net;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.Marketing.Entities;
using PTIC.VC.Marketing.Telemarketing;
using log4net.Config;

namespace PTIC.VC.Marketing.MobileService
{
    /// <summary>
    /// Mobile Service Log form
    /// </summary>
    public partial class frmMobileServiceLog : Form
    {
        /// <summary>
        /// Logger for frmMobileServiceLog
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmMobileServiceLog));

        int InitialMobileServicePlanID = -1;

        #region Events
        private void dgvMobileServiceLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var dgvLog = sender as DataGridView;
            if (e.ColumnIndex == dgvLog.Columns["colServiceDetail"].Index) // Load mobile service detail
            {
                MobileServiceDetail mServiceDetail = new MobileServiceDetail() 
                {
                    ID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colMobileServiceDetailID"].Value, typeof(int), null),
                    ServicePlanID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colMobileServicePlanID"].Value, typeof(int), null)
                };
                string servicePlanNo = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colSvcPlanNo"].Value, typeof(string), string.Empty);
                int townshipID = (int)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells[colTownshipID.Index].Value, typeof(int), -1);
                int customerTypeID = (int)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells[colCusType.Index].Value, typeof(int), -1);
                int customerID = (int)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells[colCustomerID.Index].Value, typeof(int), -1);
                                
                frmMobileServiceDetail frmMServiceDetail = new frmMobileServiceDetail(
                    mServiceDetail, servicePlanNo, 
                    townshipID, customerTypeID, customerID);
                frmMServiceDetail.MobileServiceDetailSavedHandler += 
                    new frmMobileServiceDetail.MobileServiceDetailSaveHandler(MobileServiceDetailSaved_CallBack);
                UIManager.OpenForm(frmMServiceDetail);
            }
            else if (e.ColumnIndex == dgvLog.Columns["colTeleDetail"].Index) // Load telemarketing detail
            {
                // TODO: Load Telemarketing detail form
                // (int customerType, int customerName, int township, string employeeName, TeleMarketingDetail teleMarketingDetail)
                int? telMarketingDetailID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colTeleMarketingDetailID"].Value, typeof(int), null);
                int TownshipID = (int)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells[colTownshipID.Index].Value, typeof(int), -1);
              
                if (telMarketingDetailID.HasValue)
                {
                    frmTelemarketingDetail formTelemarketingDetail = new frmTelemarketingDetail(telMarketingDetailID,TownshipID);
                    UIManager.OpenForm(formTelemarketingDetail);
                }
            }
        }

        void MobileServiceDetailSaved_CallBack(object sender, frmMobileServiceDetail.MobileServiceDetailSaveEventArgs e)
        {
            // If mobile service detail occured changes, reload mobile service log
            if (e.OccuredChanges)
                LoadNBindMobileServiceLogBy(dtpStartDate.Value, dtpEndDate.Value);
        }

        private void dgvMobileServiceLog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgLog = sender as DataGridView;
            // Set row number
            if (null != dgLog)
            {
                foreach (DataGridViewRow r in dgLog.Rows)
                {
                    dgLog.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }

            // Set cell button caption
            foreach (DataGridViewRow row in dgLog.Rows)
            {
                int customerType = (int)DataTypeParser.Parse(row.Cells["colCusType"].Value, typeof(int), 0);
                // Set customer type text
                switch (customerType)
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
                        row.Cells["colCusType"].Value = Resource.EndUser;
                        break;
                }
                // Set New / Modify mobile service detail
                int hasMobileServiceDetail = (int)DataTypeParser.Parse(row.Cells["colIsServiced"].Value, typeof(int), 0);
                if (hasMobileServiceDetail == 0)
                    row.Cells["colServiceDetail"].Value = Resource.Add;
                else
                    row.Cells["colServiceDetail"].Value = Resource.Modify;
                // Set View telemarketing detail
                int? teleDetailID = (int?)DataTypeParser.Parse(row.Cells["colTeleMarketingDetailID"].Value, typeof(int), null);
                if(teleDetailID.HasValue)
                    row.Cells["colTeleDetail"].Value = Resource.View;
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

        private void lblMobileServiceSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMobileServicePage));
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadNBindMobileServiceLogBy(dtpStartDate.Value, dtpEndDate.Value);
        }
        #endregion

        #region Private Method
        private void LoadNBindMobileServiceLogBy(DateTime startDate, DateTime endDate)
        {
            try
            {
                dgvMobileServiceLog.DataSource = new MobileServicePlanBL().GetMobileServiceLogsBy(startDate, endDate);
            }
            catch (Exception e)
            {
                throw e;
                _logger.Error(e);
            }
        }

        private void LoadNBindMobileServiceLogByInitialMobileServicePlanID(int InitialMobileServicePlanID)
        {
            try
            {
                dgvMobileServiceLog.DataSource = new MobileServicePlanBL().GetMobileServiceLogsByInitialMobileServicePlanID(InitialMobileServicePlanID);
            }
            catch (Exception e)
            {
                throw e;
                _logger.Error(e);
            }
        }
        #endregion

        #region Constructors
        public frmMobileServiceLog()
        {
            InitializeComponent();
            // Disable auto generating columns
            dgvMobileServiceLog.AutoGenerateColumns = false;

            // Configure logger 
            XmlConfigurator.Configure();            
            // Load log first and last date of this month

            DateTime curDate = DateTime.Now;
            int intMonth = curDate.Month;
            int intYear = curDate.Year;
            int intDaysInThisMonth = DateTime.DaysInMonth(intYear, intMonth);
            DateTime startDate = new DateTime(intYear, intMonth, 1);
            DateTime endDate = new DateTime(intYear, intMonth, intDaysInThisMonth);
            dtpStartDate.Value = startDate;
            dtpEndDate.Value = endDate;

            LoadNBindMobileServiceLogBy(startDate, endDate);
        }

        public frmMobileServiceLog(int InitialMobileServicePlanID)
        {
            InitializeComponent();
            this.InitialMobileServicePlanID = InitialMobileServicePlanID;
            // Disable auto generating columns
            dgvMobileServiceLog.AutoGenerateColumns = false;
            // Configure logger 
            XmlConfigurator.Configure();
            // Load log first and last date of this month
            DateTime curDate = DateTime.Now;
            int intMonth = curDate.Month;
            int intYear = curDate.Year;
            int intDaysInThisMonth = DateTime.DaysInMonth(intYear, intMonth);
            DateTime startDate = new DateTime(intYear, intMonth, 1);
            DateTime endDate = new DateTime(intYear, intMonth, intDaysInThisMonth);
            dtpStartDate.Value = startDate;
            dtpEndDate.Value = endDate;

            LoadNBindMobileServiceLogByInitialMobileServicePlanID(this.InitialMobileServicePlanID);
        }        
        #endregion

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.Value = UIManager.ChangeAnotherdtpOndtpChange(dtpStartDate);
        }
                                       
    }
}

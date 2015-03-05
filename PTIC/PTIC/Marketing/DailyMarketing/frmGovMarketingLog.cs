/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/26 (yyyy/mm/dd)
 * Description: Government Marketing Log form
 */
using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using System.Data.SqlClient;
using PTIC.Marketing.BL;
using PTIC.Marketing.Entities;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Sale.Entities;

namespace PTIC.VC.Marketing.DailyMarketing
{
    public partial class frmGovMarketingLog : Form
    {
        /// <summary>
        /// Logger for frmGovMarketingLog
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmGovMarketingLog));

        #region Events
        private void dgvGovMarketingLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgvLog = sender as DataGridView;
            if (e.RowIndex < 0 || e.ColumnIndex != dgvLog.Columns["colUpdateDetail"].Index)
                return;

            DateTime Date = (DateTime)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colDate"].Value, typeof(DateTime), DateTime.Now);
            GovernmentMarketingDetail govMkDetail = new GovernmentMarketingDetail()
            {
                ID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colGovernmentMarketingID"].Value, typeof(int), null),
                MarketingPlanID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colMarketingPlanID"].Value, typeof(int), null),
                //MinistryName = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colMinistryName"].Value, typeof(string), string.Empty),
                Department = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colDepartment"].Value, typeof(string), string.Empty),
                //ContactPerson = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colContactPerson"].Value, typeof(string), string.Empty),
                //Position = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colPosition"].Value, typeof(string), string.Empty),
                //ContactPhone = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colContactPhone"].Value, typeof(string), string.Empty),
                Matter = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colMatter"].Value, typeof(string), string.Empty),
                Date = (DateTime)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colDate"].Value, typeof(DateTime), DateTime.Now),
                Address = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colAddress"].Value, typeof(string), string.Empty),
                Phone1 = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colPhone1"].Value, typeof(string), string.Empty),
                Phone2 = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colPhone2"].Value, typeof(string), string.Empty),
                EmpID = (int)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colEmpID"].Value, typeof(int), -1),
                CusID = (int)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colCusID"].Value, typeof(int), -1),
                VenID = (int)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colVenID"].Value, typeof(int), -1),
                Remark = (string)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colRemark"].Value, typeof(string), string.Empty),
                ServiceID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colServiceID"].Value, typeof(int), null),
                OrderID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colOrderID"].Value, typeof(int), null),
                TenderInfoID = (int?)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colTenderInfoID"].Value, typeof(int), null),
            };

            Township address = new Township()
            {
                TownID = (int)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colTownID"].Value, typeof(int), -1),
                TownshipID = (int)DataTypeParser.Parse(dgvLog.Rows[e.RowIndex].Cells["colTownshipID"].Value, typeof(int), -1),
            };

            frmGovMarketingDetail frmGovMkDetail = new frmGovMarketingDetail(govMkDetail, address);
            frmGovMkDetail.GovMarketingDetailSavedHandler += new frmGovMarketingDetail.GovMarketingDetailSaveHandler(GovMarketingDetailSaved_CallBack);
            UIManager.OpenForm(frmGovMkDetail);
        }

        private void GovMarketingDetailSaved_CallBack(object sender, frmGovMarketingDetail.GovMarketingDetailSaveEventArgs e)
        { 
            // If government marketing detail occured changes, reload gov marketing log
            if (e.OccuredChanges)
                LoadNBindLogs();
        }
        #endregion

        #region Private Methods
        private void LoadNBindLogs()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                dgvGovMarketingLog.DataSource = new GovernmentMarketingDetailBL().GetGovMarketingLogs(conn);
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion

        #region Constructors
        public frmGovMarketingLog()
        {
            InitializeComponent();
            // Disable auto generating columns
            dgvGovMarketingLog.AutoGenerateColumns = false;
            // Load and bind government marketing logs
            LoadNBindLogs();
        }
        #endregion

        private void dgvGovMarketingLog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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
            // Set column button caption
            foreach (DataGridViewRow row in dgLog.Rows)
            {
                // Set New / Modify detail
                int hasDetail = (int)DataTypeParser.Parse(row.Cells["colIsMarketed"].Value, typeof(int), 0);
                if (hasDetail == 0)
                    row.Cells["colUpdateDetail"].Value = Resource.Add;
                else
                    row.Cells["colUpdateDetail"].Value = Resource.Modify;
            }
        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmDailyMarketingPage));
            this.Close();
        }

        
             
    }
}

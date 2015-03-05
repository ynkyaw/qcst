using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Util;
using PTIC.Common.BL;
using Microsoft.Reporting.WinForms;

namespace PTIC.ReportViewer
{
    public partial class frmRV_AP_UsageCustomersViewer : Form
    {
        public frmRV_AP_UsageCustomersViewer()
        {
            InitializeComponent();
        }

        #region Private Methods
        private void Search()
        {
            DateTime StartDate, EndDate;
            if (rdoDaily.Checked)
            {
                StartDate = (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.Now);
                EndDate = (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.Now);
            }
            else if (rdoWeekly.Checked)
            {
                StartDate = (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.Now);
                DateTime tmp = dtpDate.Value.AddDays(6);
                EndDate = tmp;
            }
            else if (rdoMonthly.Checked)
            {
                StartDate = (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.Now);
                EndDate = UIManager.ChangeAnotherdtpOndtpChange(dtpDate);
            }
            else if (rdoDateRange.Checked)
            {
                StartDate = (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.Now);
                EndDate = (DateTime)DataTypeParser.Parse(dtpEnd.Value, typeof(DateTime), DateTime.Now);
            }
            else
            {
                StartDate = (DateTime)DataTypeParser.Parse(dtpDate.Value, typeof(DateTime), DateTime.Now);
                int intYear = dtpDate.Value.Year;
                DateTime EndOfThisMonth = new DateTime(intYear, 12, 31);
                EndDate = EndOfThisMonth;
            }


            if (rdoPosmNotUsedCus.Checked)
            {
                DataTable dt = new RP_AP_UsageCustomersBL().GetAPUsageCustomersBy(StartDate,EndDate, false);
                rpAPusageCustomersViewer.Visible = true;
                rpAPusageCustomersViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.AP_NonUsageCustomers.rdlc";
                rpAPusageCustomersViewer.LocalReport.DataSources.Clear();
                rpAPusageCustomersViewer.LocalReport.DataSources.Add(new ReportDataSource("APUsageCustomersDataSet", dt));
                rpAPusageCustomersViewer.RefreshReport();
            }
            else if (rdoUnUsedPosmByCus.Checked)
            {
                DataTable dt = new RP_AP_UsageCustomersBL().GetCustomerNotUsedPOSMSelectBy(StartDate, EndDate);
                rpAPusageCustomersViewer.Visible = true;
                rpAPusageCustomersViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.CustomerUnUsedPosmReport.rdlc";
                rpAPusageCustomersViewer.LocalReport.DataSources.Clear();
                rpAPusageCustomersViewer.LocalReport.DataSources.Add(new ReportDataSource("CustomerUnUsedDataSet", dt));
                rpAPusageCustomersViewer.RefreshReport();
            }
            else
            {
                DataTable dt = new RP_AP_UsageCustomersBL().GetAPUsageCustomersBy(StartDate, EndDate, true);
                rpAPusageCustomersViewer.Visible = true;
                rpAPusageCustomersViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.AP_UsageCustomers.rdlc";
                rpAPusageCustomersViewer.LocalReport.DataSources.Clear();
                rpAPusageCustomersViewer.LocalReport.DataSources.Add(new ReportDataSource("APUsageCustomersWithAPDataSet", dt));
                rpAPusageCustomersViewer.RefreshReport();
            }
        }
        #endregion

        private void lblFilter_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Visible)
            {
                pnlFilter.Visible = false;
                lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
            }
            else
            {
                //   pnlFilter.Visible = true;
                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
            }
        }

        private void AP_UsageCustomersViewer_Load(object sender, EventArgs e)
        {
            this.rpAPusageCustomersViewer.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void AP_UsageCustomersViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpAPusageCustomersViewer.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}

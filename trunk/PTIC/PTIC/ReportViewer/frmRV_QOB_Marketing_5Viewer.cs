using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Common.BL;
using Microsoft.Reporting.WinForms;

namespace PTIC.ReportViewer
{
    public partial class frmRV_QOB_Marketing_5Viewer : Form
    {
        public frmRV_QOB_Marketing_5Viewer()
        {
            InitializeComponent();
        }

        #region Private Methods
        private void Search()
        {
            int Year = dtpStartDate.Value.Year;
            DateTime StartDate = new DateTime(Year, 1, 1);
           
            DataTable dt = new ReportBL().GetComplaintImprovementQOBBy(StartDate);
            rpViewerMarketingQOB5.Visible = true;
            rpViewerMarketingQOB5.LocalReport.ReportEmbeddedResource = "PTIC.Report.Marketing_QOB5.rdlc";
            rpViewerMarketingQOB5.LocalReport.DataSources.Clear();
            rpViewerMarketingQOB5.LocalReport.DataSources.Add(new ReportDataSource("Marketing_QOB5DataSet", dt));
            rpViewerMarketingQOB5.RefreshReport();
        }
        #endregion

        private void frmRV_QOB_Marketing_5Viewer_Load(object sender, EventArgs e)
        {

            this.rpViewerMarketingQOB5.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void frmRV_QOB_Marketing_5Viewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpViewerMarketingQOB5.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;
using PTIC.Common.BL;
using Microsoft.Reporting.WinForms;

namespace PTIC.ReportViewer
{
    public partial class frmRV_Sales_QOB2Viewer : Form
    {        
        #region Events
        private void frmRV_Sales_QOB2Viewer_Load(object sender, EventArgs e)
        {
            reportViewer.RefreshReport();
            this.reportViewer.RefreshReport();
        }

        private void frmRV_Sales_QOB2Viewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            reportViewer.LocalReport.ReleaseSandboxAppDomain();
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

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            OnDateChangeOccured();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(
                dtpStartDate.Value,
                dtpEndDate.Value
                );
        }
        #endregion

        #region Private Methods
        private void OnDateChangeOccured()
        {
            dtpEndDate.Value = dtpStartDate.Value.AddYears(2);
        }

        private void Search(DateTime startDate, DateTime endDate)
        {
            ReportBL reporter = new ReportBL();
            DataTable dt = reporter.GetSalesQOB2(startDate, endDate);

            reportViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.Sales_QOB2.rdlc";
            reportViewer.LocalReport.DataSources.Clear();

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet_SalesQOB2", dt));

            reportViewer.RefreshReport();
        }
        #endregion

        #region Constructor
        public frmRV_Sales_QOB2Viewer()
        {
            InitializeComponent();
            OnDateChangeOccured();
        }
        #endregion        
                
    }
}

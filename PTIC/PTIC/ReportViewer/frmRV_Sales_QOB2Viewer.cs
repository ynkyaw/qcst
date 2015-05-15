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
            string brand = "";
            if (comboBox1.SelectedValue != null)
            {
                if ((int)comboBox1.SelectedValue > 0)
                {
                    brand = "WHERE B.ID=" + comboBox1.SelectedValue + "  ";
                }
            }
            ReportBL reporter = new ReportBL();
            DataTable dt = reporter.GetSalesQOB2(brand,startDate, endDate);

            reportViewer.LocalReport.ReportEmbeddedResource = "PTIC.Report.Sales_QOB2.rdlc";
            reportViewer.LocalReport.DataSources.Clear();

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet_SalesQOB2", dt));
            ReportParameter paramStd = new ReportParameter("Std", numericUpDown1.Value + "%");
            reportViewer.LocalReport.SetParameters(new ReportParameter[] { paramStd });

            reportViewer.RefreshReport();
        }
        #endregion

        #region Constructor
        public frmRV_Sales_QOB2Viewer()
        {
            InitializeComponent();
            OnDateChangeOccured();
            DataTable dt = PTIC.Sale.DA.BrandDA.SelectAll();
            dt.Rows.InsertAt(dt.NewRow(), 0);
            dt.Rows[0][0] = 0;
            dt.Rows[0][1] = "All";
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "BrandId";
            comboBox1.DisplayMember = "BrandName";
        }
        #endregion        

                
    }
}

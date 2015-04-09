using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace PTIC.Report
{
    public partial class frmPrintPreview : Form
    {
        public frmPrintPreview(DataSet.PrintDataSet.uv_SalesPlanDetailsDataTable ds,DateTime dt)
        {
            InitializeComponent();
            Report.SalesPlan rptSalesPlan = new SalesPlan();
            //rptSalesPlan.SetDataSource(ds);
            //crystalReportViewer1.ReportSource = rptSalesPlan;
            //crystalReportViewer1.RefreshReport();
            DataTable data = ds.Copy();
            reportViewer1.LocalReport.ReportEmbeddedResource = "PTIC.Report.Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("uv_SalesPlanDetails", data));
            reportViewer1.RefreshReport();
        }

        private void frmPrintPreview_Load(object sender, EventArgs e)
        {


            this.reportViewer1.RefreshReport();
        }
    }
}

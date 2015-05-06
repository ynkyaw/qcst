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
    //DataTable data = ds.Copy();
    //        reportViewer1.LocalReport.ReportEmbeddedResource = "PTIC.Report.Report1.rdlc";
    //        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("uv_SalesPlanDetails", data));
    //        reportViewer1.RefreshReport();
    public partial class frmPrintPreview : Form
    {
        public frmPrintPreview(DataSet.PrintDataSet.tblSalesPlanDataTable dt,DateTime planMonth)
        {
            InitializeComponent();
            reportViewer1.LocalReport.ReportEmbeddedResource = "PTIC.Report.rptSalesPlanForProductuion.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("SalesPlan",dt.Copy()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("paramMonth", planMonth.ToString("MMMM")));
            string dateStr = planMonth.ToString("yyyy") + " ခုနှစ်၊ " + planMonth.ToString("MMMM") + " လ၊ (" + planMonth.ToString("dd") + ")ရက်။";
            reportViewer1.LocalReport.SetParameters(new ReportParameter("yyyy", dateStr));
            
            
        }

        private void frmPrintPreview_Load(object sender, EventArgs e)
        {


            this.reportViewer1.RefreshReport();
        }
    }
}

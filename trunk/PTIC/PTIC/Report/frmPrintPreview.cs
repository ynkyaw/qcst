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
        public frmPrintPreview(DataSet.PrintDataSet ds,DateTime dt)
        {
            InitializeComponent();
            Report.SalesPlan rptSalesPlan = new SalesPlan();
            rptSalesPlan.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rptSalesPlan;
            
            crystalReportViewer1.RefreshReport();
        }

        private void frmPrintPreview_Load(object sender, EventArgs e)
        {

          
        }
    }
}

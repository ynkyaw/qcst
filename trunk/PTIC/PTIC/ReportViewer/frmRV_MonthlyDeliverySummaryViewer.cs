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
using PTIC.Sale.BL;

namespace PTIC.ReportViewer
{
    public partial class frmRV_MonthlyDeliverySummaryViewer : Form
    {
        DataTable dtBrand = null;
        public frmRV_MonthlyDeliverySummaryViewer()
        {
            InitializeComponent();
            dtBrand = new BrandBL().GetOwnBrands();
        }

        private void frmRV_MonthlyDeliverySummaryViewer_Load(object sender, EventArgs e)
        {
            cmbBrand.DataSource = dtBrand;            
            //this.rpMonthlyDeliverySummary.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime SalesDate = (DateTime)DataTypeParser.Parse(dtpStartDate.Value, typeof(DateTime), DateTime.Now);
            int BrandID = (int)DataTypeParser.Parse(cmbBrand.SelectedValue, typeof(int), -1);
            Search(SalesDate,BrandID);
        }

        #region Private Methods
        private void Search(DateTime SalesDate,int BrandID)
        {
            ReportBL reporter = new ReportBL();
            DataTable dt = reporter.GetMonthlyDeliverySummaryByDate(SalesDate,BrandID);
            ReportParameter deliveryDate = new ReportParameter("DeliveryDate", SalesDate.ToString("MMM,yyyy"));

            rpMonthlyDeliverySummary.LocalReport.ReportEmbeddedResource = "PTIC.Report.MonthlyDeliverySummary.rdlc";
            rpMonthlyDeliverySummary.LocalReport.DataSources.Clear();

            this.rpMonthlyDeliverySummary.LocalReport.SetParameters(new ReportParameter[] { deliveryDate });

            rpMonthlyDeliverySummary.LocalReport.DataSources.Add(new ReportDataSource("MonthlyDeliverySummaryDataSet", dt));

            rpMonthlyDeliverySummary.RefreshReport();
        }
        #endregion

        private void frmRV_MonthlyDeliverySummaryViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpMonthlyDeliverySummary.LocalReport.ReleaseSandboxAppDomain();
        }

    }
}

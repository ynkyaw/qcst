using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.ReportViewer;

namespace PTIC.Sale
{
    public partial class frmSalesReportPage : Form
    {
        public frmSalesReportPage()
        {
            InitializeComponent();
        }

        private void btnSalesQOB5_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_Sales_QOB3Viewer());
        }

        private void btnSalesQOB6_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_Sales_QOB6Viewer());
        }

        private void btnSalesQOB1_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_Sales_QOB1Viewer());
        }

        private void btnSalesQOB2_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_Sales_QOB2Viewer());
        }

        private void btnMonthlySalesByCustomer_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_MonthlySalesByCustomerViewer());
        }

        private void btnSalesByRegion_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_MonthlySalesByRegion());
        }

        private void btnMonthlyDeliverySummary_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_MonthlyDeliverySummaryViewer());
        }

        private void btnYearlySalesSummary_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_YearlySalesQty());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(new PTIC.Sale.Report.frmMonthlySalesReport());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(new PTIC.Sale.Report.frmDailySalesByBrand());
        }
    }
}

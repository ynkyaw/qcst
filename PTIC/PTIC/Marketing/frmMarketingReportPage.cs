using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.ReportViewer;

namespace PTIC.Marketing
{
    public partial class frmMarketingReportPage : Form
    {
        public frmMarketingReportPage()
        {
            InitializeComponent();
        }

        private void btnAPBalance_Click(object sender, EventArgs e)
        {
            frmRV_AP_BalanceViewer frmAP_BalanceViewer = new frmRV_AP_BalanceViewer();
            UIManager.OpenForm(frmAP_BalanceViewer);
        }

        private void btnAPUsageCustomer_Click(object sender, EventArgs e)
        {
            frmRV_AP_UsageCustomersViewer frmAP_UsageCustomersViewer = new frmRV_AP_UsageCustomersViewer();
            UIManager.OpenForm(frmAP_UsageCustomersViewer);
        }

        private void btnCustomerTransition_Click(object sender, EventArgs e)
        {            
            UIManager.OpenForm(new frmRV_CustomerTransition());
        }

        private void btnWaitingOrPermanentCustomer_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_WaitingOrPermanentCustomer());
        }

        private void btnCompanyContact_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_CompanyContactViewer());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_DailyMarketingOutletViewer());
        }

        private void btnYearlyCustomerTransition_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_YearlyCustomerTransition());
        }

        private void btnMarketingNewOutletQOB_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_QOB_Marketing_2Viewer());
        }

        private void btnQOB5_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(new frmRV_QOB_Marketing_5Viewer());
        }
    }
}

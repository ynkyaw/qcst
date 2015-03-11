using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using PTIC.Marketing;
using PTIC.VC.Marketing.Telemarketing;
using PTIC.VC.Marketing.MobileService;
using PTIC.VC.Marketing.A_P;
using PTIC.Marketing.Survey;
using PTIC.Marketing.MessageInOut;
using PTIC.Marketing.TripPlan_Request;
using PTIC.Marketing.Complaint;
using PTIC.Marketing.MarketingPlan.Company_Plan;

namespace PTIC.VC.Marketing
{
    public partial class frmMarketingDock : DockContent
    {
        public frmMarketingDock()
        {
            InitializeComponent();
        }

        private void btnMarketingSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
           UIManager.MdiChildOpenForm(typeof(frmMarketingPlanPage));
        }

        private void btnMarketing_Click(object sender, EventArgs e)
        {
           UIManager.MdiChildOpenForm(typeof(frmDailyMarketingPage));
        }

        private void btnTeleMarketing_Click(object sender, EventArgs e)
        {
           UIManager.MdiChildOpenForm(typeof(frmTeleMarketingPage));
        }

        private void btnMobileService_Click(object sender, EventArgs e)
        {
           UIManager.MdiChildOpenForm(typeof(frmMobileServicePage));
        }

        private void frmMarketingDock_Load(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingReportPage));
        }

        private void btnMsgInOut_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmTripRequestPage));
        }

        private void btnSurvey_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSurveyPage));
        }

        private void btnCRM_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmComplaintPage));
        }

        private void btnAandP_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmA_PMain));
        }

        private void btnMessageInOut_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMsgInOutPage));
        }

        private void btnCompanyPlan_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCompanyPlanPage));
        }
    }
}

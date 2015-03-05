using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC;
using PTIC.Marketing;
using PTIC.VC.Marketing.DailyMarketing;
using PTIC.Marketing.DailyMarketing;
using PTIC.VC.Marketing.MarketingPlan;
using PTIC.Marketing.Telemarketing;
using PTIC.Marketing.MobileService;
using PTIC.Marketing.MarketingPlan;

namespace PTIC.VC.Marketing
{
    public partial class frmMarketingPlanPage : Form
    {
        public frmMarketingPlanPage()
        {
            InitializeComponent();         
        }

        private void btnTripPlan_Click(object sender, EventArgs e)
        {
            this.Close();
            //Program.toyo.closeAll();
            GlobalCache.is_sale = false;
            //frmTripPlanList frm = new frmTripPlanList();           
            //frm.Show();
            UIManager.MdiChildOpenForm(typeof(frmTripPlanList));
        }      

        private void btnMarketingPlan_Click(object sender, EventArgs e)
        {
            this.Close();
          //  UIManager.MdiChildOpenForm(typeof(frmDailyMarketingPlan));
            UIManager.MdiChildOpenForm(typeof(frmDailyMarketingPlanNew));
        }

        private void btnMonthlyPlan_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frm6MonthPlan));
        }

        private void btn6MonthPlan_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frm6MonthPlanSummary));
            //frm6MonthPlanSummary frm = new frm6MonthPlanSummary();
            //frm.MdiParent = Program.toyo;
            //frm.Show();
        }

        private void btnTelemarketingPlan_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmTeleMarketingMonthlyPlan));
        }

        private void btnMobSrvMonthlyPlan_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmMobileServiceMonthlyPlan));
            //UIManager.MdiChildOpenForm(typeof(MobileServiceMonthlyPlan));
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            //UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
        }

        private void btnTrip_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmTripRequestList));
            this.Close();
        }

        private void btnConfirmTelemarketingPlan_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmConfirmTelemarketingPlan));
            this.Close();
        }

        private void btnConfirmMobileServicePlan_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmConfirmMobileServicePlan));
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(PTIC.Marketing.MarketingPlan.Company_Plan.frmCompanyPlan));
            this.Close();
        }

       
                
    }
}

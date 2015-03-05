using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Marketing.DailyMarketing;
using PTIC.VC.Marketing.MarketingPlan;
using PTIC.Marketing.DailyMarketing;
using PTIC.Marketing;


namespace PTIC.VC.Sale.Trip
{
    public partial class frmTripPlanPage : Form
    {
        public frmTripPlanPage()
        {
            InitializeComponent();
        }

        private void btn3MonthPlan_Click(object sender, EventArgs e)
        {
           // To do
            GlobalCache.is_sale = true;
            UIManager.MdiChildOpenForm(typeof(frmTripPlanList));
        }

        private void btnTripRequest_Click(object sender, EventArgs e)
        {
            int intMonth = DateTime.Now.Month;
            int intYear = DateTime.Now.Year;
            DateTime oBeginnngOfThisMonth = DateTime.Now;
            oBeginnngOfThisMonth = new DateTime(intYear, intMonth, 1);
            
            //  2nd Month
            int intDays2ndMonth = DateTime.DaysInMonth(intYear, intMonth);
            DateTime endOfMonth = new DateTime(intYear, intMonth, intDays2ndMonth);

            if (Program.module == Program.Module.Marketing)
            {
                frmTripPlan _frmTripPlan = new frmTripPlan(oBeginnngOfThisMonth, endOfMonth, false);
                UIManager.OpenForm(_frmTripPlan);
            }
            else if (Program.module == Program.Module.Sale)
            {
                frmTripPlan _frmTripPlan = new frmTripPlan(oBeginnngOfThisMonth, endOfMonth, true);
                UIManager.OpenForm(_frmTripPlan);
            }
        }

        private void btnRoutePlan_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmRoutePlan));
        }

    }
}

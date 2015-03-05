using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC;
using PTIC.VC.Marketing.DailyMarketing;

namespace PTIC.Marketing.TripPlan_Request
{
    public partial class frmTripRequestPage : Form
    {
        public frmTripRequestPage()
        {
            InitializeComponent();
        }

        private void btnTripRequest_Click(object sender, EventArgs e)
        {
            int intMonth = DateTime.Now.Month;
            int intYear = DateTime.Now.Year;
            // 1st Month
          //  int intDaysThisMonth = DateTime.DaysInMonth(intYear, intMonth-1);
            DateTime oBeginnngOfThisMonth = new DateTime(intYear, intMonth-1, 1);
            //  2nd Month
            int intDays2ndMonth = DateTime.DaysInMonth(intYear,intMonth);
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
    }
}

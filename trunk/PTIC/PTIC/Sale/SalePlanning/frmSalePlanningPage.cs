using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing;
using PTIC.VC.Marketing.MarketingPlan;
using PTIC.VC.Sale.Trip;
using PTIC.VC;
using PTIC.VC.Sale.OfficeSales;

namespace PTIC.Sale.SalePlanning
{
    public partial class frmSalePlanningPage : Form
    {
        public frmSalePlanningPage()
        {
            InitializeComponent();
        }

        private void btnSalesPlanforProduction_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSalesPlan4Production));
            this.Close();
        }

        private void btnTripPlan_Click(object sender, EventArgs e)
        {
            // To do
            GlobalCache.is_sale = true;
            UIManager.MdiChildOpenForm(typeof(frmTripPlanList));
            this.Close();
        }

        private void btnRoutePlan_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmRoutePlan));
            this.Close();
        }

       
    }
}

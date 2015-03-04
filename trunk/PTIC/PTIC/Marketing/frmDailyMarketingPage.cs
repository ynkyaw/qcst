using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.DailyMarketing;
using PTIC.VC.Marketing.DailyMarketing;
using PTIC.Marketing;

namespace PTIC.VC.Marketing
{
    public partial class frmDailyMarketingPage : Form
    {
        public frmDailyMarketingPage()
        {
            InitializeComponent();
        }

        private void btnMarketingLog_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmDailyMarketingLog));
        }

        private void btnGovMarketingLog_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmGovMarketingLog));
        }

        private void btnMarketingDetail_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.OpenForm(typeof(frmNonCustomerDailyMarketingDetail));                        
        }

        private void btnGovMarketingDetail_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmGovMarketingDetail));
        }

        private void btnTripRequest_Click(object sender, EventArgs e)
        {
            this.Close();
            GlobalCache.is_sale = false;
            UIManager.MdiChildOpenForm(typeof(frmTripRequestList));
        }
    }
}

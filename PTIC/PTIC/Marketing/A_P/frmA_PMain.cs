using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Marketing.A_P;
using PTIC.Marketing.A_P;

namespace PTIC.VC.Marketing.A_P
{
    public partial class frmA_PMain : Form
    {
        public frmA_PMain()
        {
            InitializeComponent();
        }

        private void btnPurchasedIn_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmPosmPurchasedIn));
            this.Close();
        }

        private void btnAPPlanSummary_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmAPPlanSummary));
            this.Close();
        }

        private void btnAPEnquiry_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmAPEnquiry));
            this.Close();
        }

        private void btnPosmRequest_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmPosmRequest));
            this.Close();
        }

        private void btnPsomEnquiryList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmAPEnquiryList));
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAPUsage_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmPOSM_Usage));
            this.Close();
        }

        private void btnPosmTransferList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmPosmTransferList));
            this.Close();
        }

        private void btnPOSM_Return_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmPOSM_Return));
            this.Close();
        }

        private void btnPurchasedInList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmPosmPurchasedInLists));
        }

        private void btnAPEnquiry_Click_1(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmEnquiryAcceptedList));
            this.Close();
        }

        private void btnAPUsageList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmPOSM_UsageList));
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmPosmReturnList));
            this.Close();
        }
    }
}

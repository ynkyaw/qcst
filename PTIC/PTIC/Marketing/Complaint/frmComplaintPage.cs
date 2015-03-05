using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PTIC.Marketing.Complaint
{
    public partial class frmComplaintPage : Form
    {
        public frmComplaintPage()
        {
            InitializeComponent();
        }

        private void btnCustomerComplaint_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCustomerComplaintReceive));
            this.Close();
        }

        private void btnCusComplaintRegistered_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCustomerComplaintRegistered));
            this.Close();
        }

        private void btnCustomerComplaintRecList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCustomerComplaintReceiveList));
            this.Close();
        }

        private void btnCusComplaintRegList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCustomerComplaintRegisterList));
            this.Close();
        }

        private void btnComplaintSummaryReport_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCustomerComplainSummary));
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Marketing.MessageInOut;

namespace PTIC.Marketing.MessageInOut
{
    public partial class frmMsgInOutPage : Form
    {
        public frmMsgInOutPage()
        {
            InitializeComponent();
        }

        private void btnComposeMsg_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmComposeMessage));
            this.Close();
        }

        private void btnDeptToDeptConfirm_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMessageConfirm));
            this.Close();
        }

        private void btnMsgInOutRecord_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMsgDeptToDeptLog));
            this.Close();
        }

        private void btnMsgInOut_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMessageInOut));
            this.Close();
        }

        private void btnExternalComposeMsg_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmExternalComposeMessage));
            this.Close();
        }
    }
}

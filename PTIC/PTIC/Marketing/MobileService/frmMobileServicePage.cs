using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Marketing.MobileService;

namespace PTIC.VC.Marketing.MobileService
{
    public partial class frmMobileServicePage : Form
    {
        public frmMobileServicePage()
        {
            InitializeComponent();
        }

        private void btnMobileServiceLog_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMobileServiceLog));
        }

        private void btnMobileServiceDetail_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMobileServiceDetail));
        }
    }
}

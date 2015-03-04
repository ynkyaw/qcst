using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using PTIC.VC.Auth;
using PTIC.Marketing;

namespace PTIC.VC.Marketing
{
    public partial class frmMarketingMain : Form
    {
        public frmLogin frmLogin;
        private frmMarketingDock marketing_Dock = new frmMarketingDock();

        public frmMarketingMain()
        {
            InitializeComponent();
            marketing_Dock.CloseButtonVisible = false;
            marketing_Dock.Dock = System.Windows.Forms.DockStyle.Left;
            marketing_Dock.Show(dockPanel, DockState.DockLeft);  
        }

        public frmMarketingMain(frmLogin frmLogin):this()
        {
            this.frmLogin = frmLogin;
            this.frmLogin.Visible = false;
        }

        private void frmMarketingMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.frmLogin.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Sale.Services;
using PTIC.Sale.Services;

namespace PTIC.VC.Sale.Services
{
    public partial class frmServicePages : Form
    {
        public frmServicePages()
        {
            InitializeComponent();
        }

        private void btnServiceReceive_Click(object sender, EventArgs e)
        {
            this.Close();
            frmServiceReceiveReturn frmServiceReceive = new frmServiceReceiveReturn(true);
            UIManager.OpenForm(frmServiceReceive);
         }

        private void btnServiceBatterySatatus_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmServiceBatteryStatus));
            this.Close();
        }

        private void btnServiceBatteryList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmServiceBatteries));
            this.Close();
        }

        private void btnServiceReturn_Click(object sender, EventArgs e)
        {
            this.Close();
            frmServiceReceiveReturn frmServiceReceive = new frmServiceReceiveReturn(false);
            UIManager.OpenForm(frmServiceReceive);          
        }

        private void btnBatteriesInFactory_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmServiceBatteriesInFactory));
            this.Close();
        }
    }
}

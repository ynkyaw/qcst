using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.Order;

namespace PTIC.VC.Marketing.Telemarketing
{
    public partial class frmTeleMarketingPage : Form
    {
        public frmTeleMarketingPage()
        {
            InitializeComponent();
        }

        private void btnMarketingLog_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmTeleMarketingLog));
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.OpenForm(typeof(frmOrder));          
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmOrders));
        }


    }
}

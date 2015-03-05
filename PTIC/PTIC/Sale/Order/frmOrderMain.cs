using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.Delivery;
using PTIC.VC.Sale.Delivery;
using PTIC.VC.Sale.Inventory;
using PTIC.Sale.Report;

namespace PTIC.Sale.Order
{
    public partial class frmOrderMain : Form
    {
        public frmOrderMain()
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.OpenForm(typeof(frmOrder));          
        }

        private void btnOrderList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmOrders));
            this.Close();
        }

        private void btnLostOrder_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmLostOrders));
            this.Close();
        }

        private void btnUnDeliver_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmDelivery));
            this.Close();
        }

        private void btnDeliver_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmDeliveredList));
            this.Close();
        }

        private void btnDeliveryNote_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmNewDeliveryNote));
            this.Close();           
        }

        private void btnDeliveryPlan_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmDeliveryPlan));
            this.Close();
        }

        private void btnDeliveryNoteList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmDeliveryNoteList));
            this.Close();
        }

       
    }
}

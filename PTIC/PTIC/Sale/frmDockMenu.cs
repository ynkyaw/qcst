/*  Author  :   Aung KO KO
     Date     :   9 Feb 2014
     Description    :  DockMenu on frmSaleMain
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using PTIC.Sale.Setup;
using PTIC.Sale;
using PTIC.Sale.Order;
using PTIC.Sale.Delivery;
using PTIC.VC.Sale.OfficeSales;
using PTIC.VC.Sale.Trip;
using PTIC.VC.Sale.Inventory;
using PTIC.Sale.SalePlanning;
using PTIC.VC.Sale.Services;
using PTIC.Sale.CashCollection;
using PTIC.Marketing.MessageInOut;

namespace PTIC.VC.Sale
{
     public partial class frmDockMenu : DockContent
    {
        public frmDockMenu()
        {
            InitializeComponent();
        }

        private void bntSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmOrderMain));
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSalePlanningPage));
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSalesPage));
        }

        private void btnTrip_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmTripPlanPage));
        }

        private void btnHO_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmInventoryStorePage));
        }

        private void btnDataTransfer_Click(object sender, EventArgs e)
        {

        }

        private void btnService_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmServicePages));
        }

        private void btnCashCollection_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCashCollectionPage));
        }

        private void btnMsgInOut_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMsgInOutPage));
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSalesReportPage));
        }
       
    }
}

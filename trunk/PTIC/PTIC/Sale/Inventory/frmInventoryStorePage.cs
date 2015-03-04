using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.OfficeSales;
using PTIC.VC.Sale.OfficeSales;

namespace PTIC.VC.Sale.Inventory
{
    public partial class frmInventoryStorePage : Form
    {
        public frmInventoryStorePage()
        {
            InitializeComponent();
        }

        private void btnFG_Request_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmFinishedGoodsRequest));
            this.Close();
        }

        private void btnFG_Receive_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(FinishedGoodRequestRecieve));
            this.Close();
        }

        private void btnWarehouseInOut_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmShowroomStockList));
            this.Close();
        }

        private void btnVenInOut_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmVanStockList));
            this.Close();
        }

        private void btnShowRoomMovement_Click(object sender, EventArgs e)
        {
            this.Close();
            frmShowRoomMovement frmShowRoom = new frmShowRoomMovement();
            UIManager.OpenForm(frmShowRoom);           
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnVanReturn_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmVenReturn));
            this.Close();
        }

        private void btnSalesReturn_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSalesReturn));
        }

        private void btnVanReturnList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmVenReturnList));
        }

        private void btnSalesReturnList_Click(object sender, EventArgs e)
        {

        }

                
    }
}

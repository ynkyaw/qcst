using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.OfficeSales;
using PTIC.VC.Sale.CashCollection;
using PTIC.Sale.CashCollection;
using System.Threading;

namespace PTIC.VC.Sale.OfficeSales
{
    public partial class frmSalesPage : Form
    {
        public frmSalesPage()
        {
            InitializeComponent();
        }

        private void btnSalePlan4Production_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSalesPlan4Production));
            this.Close();
        }

        private void btnCashSale_Click(object sender, EventArgs e)
        {
            //this.Close();
            frmCashSalesInvoice invoice = new frmCashSalesInvoice();
           // UIManager.MdiChildOpenForm(typeof(frmCashSalesInvoice));
            UIManager.OpenForm(invoice);
          
        }

        private void btnStuffSale_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmEmpSales));
            this.Close();
        }

        private void btnRecievedVoucher_Click(object sender, EventArgs e)
        {
            //this.Close();
            //UIManager.MdiChildOpenForm(typeof(frmInvoice));
            frmInvoice productinvoice = new frmInvoice();
            UIManager.OpenForm(productinvoice);            
        }

        private void btnVoucherList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmInvoiceList));
            this.Close();
        }

        private void btnCashSaleInvoices_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCashSalesInvoices));
            this.Close();
        }

        private void btnStuffSale_Click_1(object sender, EventArgs e)
        {

        }
    
    }
}

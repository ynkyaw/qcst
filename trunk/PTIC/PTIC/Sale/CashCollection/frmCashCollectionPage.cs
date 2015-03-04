using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Sale.CashCollection;

namespace PTIC.Sale.CashCollection
{
    public partial class frmCashCollectionPage : Form
    {
        public frmCashCollectionPage()
        {
            InitializeComponent();
        }

        private void DebtorsList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmDebtors));
            this.Close();
        }

        private void btnReceiptVoucher_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.OpenForm(typeof(frmReceipt));    
        }

        private void btnRecipt_MultiInvoices_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(typeof(frmReceipt_MultiInvoices));
            this.Close();
        }

        private void btnReceiptVoucherList_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmReceiptVoucherList));
            this.Close();
        }

        private void btnReciptList_MultiInvoices_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmReceiptVoucherList_MultipleInvoices));
            this.Close();
        }
    }
}

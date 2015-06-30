using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProvenCashCollectionUpdater
{
    public partial class frmCashCollectionTools : Form
    {
        #region Inner Class
        protected class CustomerCreditBalanec 
        {
            public int CusID { get; set; }
            public decimal BalanceAmount { get; set; }
        }
        #endregion

        public frmCashCollectionTools()
        {
            InitializeComponent();
            txtFilePath.Enabled = false;
            rtxtLog.ReadOnly=true;
            dgvCustomerList.Enabled = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void btnRunUpdate_Click(object sender, EventArgs e)
        {
           new System.Threading.Thread(UpdateReciept).Start();
        }

        private void UpdateReciept() 
        {
        
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(openFileDialog.FileName)) 
            {
            
            }
        }
    }
}

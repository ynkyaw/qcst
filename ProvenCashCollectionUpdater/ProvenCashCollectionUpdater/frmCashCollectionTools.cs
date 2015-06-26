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

        }

        private void UpdateReciept() 
        {
        
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}

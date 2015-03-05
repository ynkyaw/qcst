using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PTIC.VC.Sale.Inventory
{
    public partial class frmShowroomStockList : Form
    {
        public frmShowroomStockList()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmInventoryStorePage));
            this.Close();
        }

        private void dgvShowRoomInList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
            }
        }

        private void dgvOutList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
            }
        }

        
    }
}

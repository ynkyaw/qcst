using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.BL;
using PTIC.VC.Util;

namespace PTIC.Marketing.Complaint
{
    public partial class frmCustomerComplaintReceiveList : Form
    {
        public frmCustomerComplaintReceiveList()
        {
            InitializeComponent();
            LoadNBind(dtpReceivedDate);
        }

        #region Private Methods
        private void LoadNBind(DateTimePicker dtpReceive)
        {
            int ReceiveMonth = dtpReceive.Value.Month;
            int ReceiveYear = dtpReceive.Value.Year;

            //  Auto-Generate Columns False
            dgvComplaintReceive.AutoGenerateColumns = false;
            //  Bind Data into DataGrid
            dgvComplaintReceive.DataSource = new ComplaintReceiveBL().GetComplaintReceiveByReceiveDate(ReceiveMonth, ReceiveYear);

        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadNBind(dtpReceivedDate);
        }

        private void dgvComplaintReceive_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (dgvComplaintReceive == null) return;
            if (dgvComplaintReceive.SelectedRows.Count > 0)
            {
                // Call CustomerComplaintRegister
                int ComplaintReceiveID = (int)DataTypeParser.Parse(dgvComplaintReceive.CurrentRow.Cells[colComplaintReceivedID.Index].Value, typeof(int), -1);
                frmCustomerComplaintRegistered _frmCustomerComplaintRegistered = new frmCustomerComplaintRegistered(ComplaintReceiveID);
                UIManager.OpenForm(_frmCustomerComplaintRegistered);
                LoadNBind(dtpReceivedDate);
            }
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmComplaintPage));
            this.Close();
        }
    }
}

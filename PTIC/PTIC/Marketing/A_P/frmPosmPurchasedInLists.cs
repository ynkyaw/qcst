using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.VC.Marketing.A_P;

namespace PTIC.Marketing.A_P
{
    public partial class frmPosmPurchasedInLists : Form
    {
        public frmPosmPurchasedInLists()
        {
            InitializeComponent();
            dgvAPEnquiryApprovedList.AutoGenerateColumns = false;

            pnlFilter.Hide();
            LoadNBind();
        }

        #region Private Methods
        private void LoadNBind()
        {

            dgvAPEnquiryApprovedList.DataSource = new AP_EnquiryBL().GetAllAPEnquiryByIsAccepted();
        }
        #endregion

        private void dgvAPEnquiryApprovedList_SelectionChanged(object sender, EventArgs e)
        {
            dgvPosmList.AutoGenerateColumns = false;
            if (dgvAPEnquiryApprovedList.DataSource == null || dgvAPEnquiryApprovedList.SelectedRows.Count < 1) return;

            int APEnquiryDetailID = (int)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colAPEnquiryDetailID.Index].Value, typeof(int), -1);
            dgvPosmList.DataSource = new AP_PurchasedDetailBL().GetAllAP_PurchasedDetailByAP_EnquiryDetailID(APEnquiryDetailID);


        }

        private void dgvPosmList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            int TotalQty = 0;
            decimal TotalAmt = 0;
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                    if (dgv.Rows.Count > 0)
                    {
                        int Quantity = (int)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colQuantity.Index].Value, typeof(int), 1);
                        decimal UnitCost = (decimal)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colPurchasedUnitCost.Index].Value, typeof(decimal), 1);

                        dgv.Rows[r.Index].Cells[colAmount.Index].Value = Quantity * UnitCost;

                        TotalQty += Quantity;
                        TotalAmt += (decimal)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colAmount.Index].Value ,typeof(decimal),0);
                    }
                }

                txtTotalAmt.Text = TotalAmt.ToString("N0");
                txtTotalQty.Text = TotalQty.ToString("N0");
            }
        }

        private void dgvAPEnquiryApprovedList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                    int ApprovedQty = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colQty.Index].Value, typeof(int), 0);
                    int PurchasedQty = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colPurchasedQty.Index].Value, typeof(int), 0);
                    int RevisedQty = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colRevisedQty.Index].Value, typeof(int), 0);

                    dgv.Rows[row.Index].Cells[colTotalQty.Index].Value = ApprovedQty - PurchasedQty - RevisedQty;
                }

            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmA_PMain));
        }

        private void dgvAPEnquiryApprovedList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
        }

        private void chkPosm_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

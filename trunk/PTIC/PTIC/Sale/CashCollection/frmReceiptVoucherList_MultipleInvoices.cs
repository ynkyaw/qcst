using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using PTIC.Common.BL;

namespace PTIC.Sale.CashCollection
{
    public partial class frmReceiptVoucherList_MultipleInvoices : Form
    {
        #region Private Methods
        private DataTable GetDetailSchema()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] 
            {
                new DataColumn("TotalAmt", typeof(decimal)),
                new DataColumn("CommDisAmt", typeof(decimal)),
                new DataColumn("OtherAmt", typeof(decimal)),
                new DataColumn("PaidAmt", typeof(decimal)),
                new DataColumn("BalanceAmt", typeof(decimal)),
            });
            return dt;
        }

        private void LoadFilterData()
        {
            // Load and bind customers
            cmbCustomer.DataSource = new CustomerBL().GetAll();
            // Load and bind department
            cmbDepartment.DataSource = new DepartmentBL().GetAll();
        }

        private void Search()
        {
            DateTime? startDate = null;
            DateTime? endDate = null;
            int? customerID = null;
            int? departmentID = null;
            if (dtpStartDate.Checked && dtpEndDate.Checked)
            {
                startDate = dtpStartDate.Value;
                endDate = dtpEndDate.Value;
            }
            if (chkCustomerName.Checked)
                customerID = (int?)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), null);
            if (chkDepartment.Checked)
                departmentID = (int?)DataTypeParser.Parse(cmbDepartment.SelectedValue, typeof(int), null);
            try
            {
                DataTable results = new MultiInvoicesPaymentBL().GetBy(startDate, endDate, customerID, departmentID);
                dgvReceipt.DataSource = results;
                if (results == null || results.Rows.Count < 1)
                { 
                    // Clear detail and sale invoice list
                    dgvDetail.DataSource = GetDetailSchema();
                    lstBxSalesInvoices.DataSource = null;
                    lstBxSalesInvoices.DisplayMember = "InvoiceNo";
                    lstBxSalesInvoices.ValueMember = "InvoiceID";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Events
        private void dgvReceipt_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.Rows.Count < 1 || dgv.CurrentRow == null)
                return;
                        
            decimal totalAmt = (decimal)DataTypeParser.Parse(dgv.CurrentRow.Cells[colTotalAmt.Index].Value, typeof(decimal), 0);
            decimal commDisAmt = (decimal)DataTypeParser.Parse(dgv.CurrentRow.Cells[colCommDisAmt.Index].Value, typeof(decimal), 0);
            decimal otherAmt = (decimal)DataTypeParser.Parse(dgv.CurrentRow.Cells[colOtherAmt.Index].Value, typeof(decimal), 0);
            decimal paidAmt = (decimal)DataTypeParser.Parse(dgv.CurrentRow.Cells[colPaidAmt.Index].Value, typeof(decimal), 0);
            decimal balanceAmt = (decimal)DataTypeParser.Parse(dgv.CurrentRow.Cells[colBalanceAmt.Index].Value, typeof(decimal), 0);

            DataTable dt = dgvDetail.DataSource as DataTable;
            dt.Rows.Clear();
            DataRow newRow = dt.NewRow();
            newRow["TotalAmt"] = totalAmt;
            newRow["CommDisAmt"] = commDisAmt;
            newRow["OtherAmt"] = otherAmt;
            newRow["PaidAmt"] = paidAmt;
            newRow["BalanceAmt"] = balanceAmt;
            dt.Rows.Add(newRow);            

            // Set 
            string receiptNo = (string)DataTypeParser.Parse(dgv.CurrentRow.Cells[colInvoiceNo.Index].Value, typeof(string), string.Empty);
            this.lstBxSalesInvoices.DataSource = new MultiInvoicesPaymentBL().GetByReceiptNo(receiptNo);
        }

        private void dgvReceipt_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.Rows.Count < 1) 
                return;
            //int salesType = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[dgvColSaleTypeText.Index].Value, typeof(int), 0);

            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Show row header
                dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();

                // Show pay type description
                if ((int)DataTypeParser.Parse(row.Cells[colPayType.Index].Value, typeof(int), 0) ==
                    (int)PTIC.Common.Enum.PayType.First)
                {
                    row.Cells[colPayTypeText.Index].Value = PTIC.Common.Enum.PayType.First;
                }
                else if ((int)DataTypeParser.Parse(row.Cells[colPayType.Index].Value, typeof(int), 0) ==
                    (int)PTIC.Common.Enum.PayType.Partial)
                {
                    row.Cells[colPayTypeText.Index].Value = PTIC.Common.Enum.PayType.Partial;
                }
                else
                {
                    row.Cells[colPayTypeText.Index].Value = PTIC.Common.Enum.PayType.Final;
                }

                // Show cash receipt type
                if ((int)DataTypeParser.Parse(row.Cells[colCashReceiptType.Index].Value, typeof(int), 0) ==
                    (int)PTIC.Common.Enum.CashReceiptType.Cash)
                {
                    row.Cells[colCashReceiptTypeText.Index].Value = PTIC.Common.Enum.CashReceiptType.Cash;
                }
                else if ((int)DataTypeParser.Parse(row.Cells[colCashReceiptType.Index].Value, typeof(int), 0) ==
                    (int)PTIC.Common.Enum.CashReceiptType.Cheque)
                {
                    row.Cells[colCashReceiptTypeText.Index].Value = PTIC.Common.Enum.CashReceiptType.Cheque;
                }
                else
                {
                    row.Cells[colCashReceiptTypeText.Index].Value = PTIC.Common.Enum.CashReceiptType.Remittance;
                }
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCashCollectionPage));
            this.Close();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (sender is DateTimePicker && sender != null)
            {
                dtpStartDate.Checked = dtpEndDate.Checked = (sender as DateTimePicker).Checked;
            }
        }

        private void chkCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox && sender != null)
            {
                cmbCustomer.Enabled = (sender as CheckBox).Checked;
            }
        }

        private void chkDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox && sender != null)
            {
                cmbDepartment.Enabled = (sender as CheckBox).Checked;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        #endregion

        #region Constructors
        public frmReceiptVoucherList_MultipleInvoices()
        {
            InitializeComponent();
            this.dgvReceipt.AutoGenerateColumns = false;
            this.dgvDetail.AutoGenerateColumns = false;
            // Load and bind detail schema
            this.dgvDetail.DataSource = GetDetailSchema();
            // Load and bind all receipt (multiple invoices)
            //this.dgvReceipt.DataSource = new MultiInvoicesPaymentBL().GetAll();
            // Load and bind filter data
            LoadFilterData();
        }
        #endregion
                                        
    }
}

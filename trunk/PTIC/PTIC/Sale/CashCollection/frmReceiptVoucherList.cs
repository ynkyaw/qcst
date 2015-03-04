using System;
using System.Data;
using PTIC.Common;
using System.Windows.Forms;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using System.Data.SqlClient;
using System.Drawing;
using PTIC.Common.BL;

namespace PTIC.Sale.CashCollection
{
    public partial class frmReceiptVoucherList : Form
    {
        #region Events
        private void dgvPayment_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView && gridView.Rows.Count > 0)
            {
                decimal tmpBalance = (decimal)DataTypeParser.Parse(gridView.Rows[0].Cells["colTotalAmt"].Value, typeof(decimal), 0);
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                    if ((int)DataTypeParser.Parse(r.Cells[colPayTypeText.Index].Value, typeof(int), 0) == 0)
                    {
                        r.Cells[colPaymentType.Index].Value = PTIC.Common.Enum.PayType.First;
                    }
                    else if ((int)DataTypeParser.Parse(r.Cells[colPayTypeText.Index].Value, typeof(int), 0) == 1)
                    {
                        r.Cells[colPaymentType.Index].Value = PTIC.Common.Enum.PayType.Partial;
                    }
                    else
                    {
                        r.Cells[colPaymentType.Index].Value = PTIC.Common.Enum.PayType.Final;
                    }

                    if ((int)DataTypeParser.Parse(r.Cells[colCashTypeID.Index].Value, typeof(int), 0) == 0)
                    {
                        r.Cells[colCashType.Index].Value = PTIC.Common.Enum.CashReceiptType.Cash;
                    }
                    else if ((int)DataTypeParser.Parse(r.Cells[colCashTypeID.Index].Value, typeof(int), 0) == 1)
                    {
                        r.Cells[colCashType.Index].Value = PTIC.Common.Enum.CashReceiptType.Cheque;
                    }
                    else
                    {
                        r.Cells[colCashType.Index].Value = PTIC.Common.Enum.CashReceiptType.Remittance;
                    }

                    decimal paidAmt = (decimal)DataTypeParser.Parse(r.Cells["colPaidAmt"].Value, typeof(decimal), 0);
                    decimal commDis = (decimal)DataTypeParser.Parse(r.Cells[colCommission.Index].Value, typeof(decimal), 0);
                    decimal tax = (decimal)DataTypeParser.Parse(r.Cells[colTax.Index].Value, typeof(decimal), 0);
                    // Calculate balance (running total)
                    tmpBalance = (tmpBalance - paidAmt - commDis) + tax;
                    r.Cells[colBalance.Index].Value = tmpBalance;
                }
                // If balance amount is greater than zero, format it in red as notified
                if (tmpBalance > 0)
                {
                    DataGridViewRow row = gridView.Rows[gridView.Rows.Count - 1];
                    DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                    cellStyle.BackColor = Color.OrangeRed;
                    row.Cells[colBalance.Index].Style = cellStyle;
                }
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmCashCollectionPage));
            this.Close();
        }

        private void dgvVouchers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ReceiptNo = (string)DataTypeParser.Parse(dgvVouchers.CurrentRow.Cells["colInvoiceNo"].Value, typeof(string), String.Empty);
            LoadNBindPayment(ReceiptNo);
        }

        private void dgvVouchers_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.CurrentRow == null)
                return;
            string ReceiptNo = (string)DataTypeParser.Parse(dgv.CurrentRow.Cells[colReceiptNo.Index].Value, typeof(string), String.Empty);
            LoadNBindPayment(ReceiptNo);
        }

        private void dgvVouchers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;
            if (dgv.CurrentRow == null) return;
            int salesType = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[dgvColSaleTypeText.Index].Value, typeof(int), 0);

            foreach (DataGridViewRow row in dgv.Rows)
            {
                dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();

                // Show pay type description
                if ((int)DataTypeParser.Parse(row.Cells[colInstallmentData.Index].Value, typeof(int), 0) ==
                    (int)PTIC.Common.Enum.PayType.First)
                {
                    row.Cells[colInstallment.Index].Value = PTIC.Common.Enum.PayType.First;
                }
                else if ((int)DataTypeParser.Parse(row.Cells[colInstallmentData.Index].Value, typeof(int), 0) ==
                    (int)PTIC.Common.Enum.PayType.Partial)
                {
                    row.Cells[colInstallment.Index].Value = PTIC.Common.Enum.PayType.Partial;
                }
                else
                {
                    row.Cells[colInstallment.Index].Value = PTIC.Common.Enum.PayType.Final;
                }

                // Show cash receipt type
                if ((int)DataTypeParser.Parse(row.Cells[colPaymentTypeData.Index].Value, typeof(int), 0) ==
                    (int)PTIC.Common.Enum.CashReceiptType.Cash)
                {
                    row.Cells[colPayment.Index].Value = PTIC.Common.Enum.CashReceiptType.Cash;
                }
                else if ((int)DataTypeParser.Parse(row.Cells[colPaymentTypeData.Index].Value, typeof(int), 0) ==
                    (int)PTIC.Common.Enum.CashReceiptType.Cheque)
                {
                    row.Cells[colPayment.Index].Value = PTIC.Common.Enum.CashReceiptType.Cheque;
                }
                else
                {
                    row.Cells[colPayment.Index].Value = PTIC.Common.Enum.CashReceiptType.Remittance;
                }
            }
        }

        private void lblHeaderPCat_Click(object sender, EventArgs e)
        {
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

        #region Private Methods
        private void LoadNBindReceipts()
        {
            try
            {
                DataTable dtVouchers = new InvoiceBL().GetAllPayment();
                if (dtVouchers.Rows.Count > 0)                
                    dgvVouchers.DataSource = dtVouchers;                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void LoadNBindPayment(string receiptNo)
        {
            try
            {
                this.dgvPayment.DataSource = new PaymentBL().GetAllReceiptByReceiptNo(receiptNo);
            }
            catch (Exception e)
            {
                throw e;
            }
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
                dgvVouchers.DataSource = new PaymentBL().GetBy(startDate, endDate, customerID, departmentID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Constructors
        public frmReceiptVoucherList()
        {
            InitializeComponent();
            // Disable Auto generate Columns
            dgvPayment.AutoGenerateColumns = false;
            dgvVouchers.AutoGenerateColumns = false;
            // Load and bind filter data
            LoadFilterData();
            // Load and bind 
            //LoadNBindReceipts();
        }        
        #endregion
                        
    }
}

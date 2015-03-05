using System;
using System.Data;
using PTIC.Common;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC.Util;
using PTIC.VC.Sale.OfficeSales;
using PTIC.Sale.BL;
using PTIC.Util;
using log4net;
using log4net.Config;
using PTIC.VC;
using System.Drawing;
using System.Collections.Generic;
using PTIC.Common.BL;

namespace PTIC.Sale.OfficeSales
{
    public partial class frmInvoiceList : Form
    {
        /// <summary>
        /// Logger for frmInvoiceList
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmInvoiceList));

        #region Events
        private void dgvVouchers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int total = 0;
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                    if ((int)DataTypeParser.Parse(r.Cells[dgvColSaleTypeText.Index].Value, typeof(int), 0) == 0)
                        r.Cells[dgvColSaleType.Index].Value = PTIC.Common.Enum.SaleType.Credit.ToString();
                    else
                        r.Cells[dgvColSaleType.Index].Value = PTIC.Common.Enum.SaleType.Consignment.ToString();

                }
            }

            foreach (DataGridViewRow row in dgvVouchers.Rows)
            {
                try
                {
                    total += (int)DataTypeParser.Parse(row.Cells["dgvColEachVoucherAmt"].Value, typeof(int), 0);
                }
                catch (StackOverflowException ex)
                {
                }
            }
            txtAllVoucherAmt.Text = total.ToString("N0");
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (sender is DateTimePicker && sender != null)
            {
                dtpOrderStart.Checked = dtpOrderEnd.Checked = (sender as DateTimePicker).Checked;
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSalesPage));
            this.Close();
        }

        private void dgvSaleDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int total = 0;
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }

            foreach (DataGridViewRow row in dgvSaleDetail.Rows)
            {
                try
                {
                    total += (int)DataTypeParser.Parse(row.Cells["clnAmount"].Value, typeof(int), 0);
                }
                catch (StackOverflowException ex)
                {
                }
            }
            txtTotalAmount.Text = total.ToString("N0");
        }

        private void dgvVouchers_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.RowCount < 1) return;
            int InvoiceID = (int)DataTypeParser.Parse(dgvVouchers.CurrentRow.Cells["dgvInvoiceVoucher"].Value, typeof(int), -1);
            LoadNBindSaleDetails(InvoiceID);
        }

        private void chkEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox && sender != null)
            {
                cmbEmployee.Enabled = (sender as CheckBox).Checked;
            }
        }

        private void chkCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox && sender != null)
            {
                cmbCustomer.Enabled = (sender as CheckBox).Checked;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime? startDate = null;
            DateTime? endDate = null;
            int? employeeID = null;
            int? customerID = null;
            if (dtpOrderStart.Checked && dtpOrderEnd.Checked)
            {
                startDate = dtpOrderStart.Value;
                endDate = dtpOrderEnd.Value;
            }
            if (chkEmployee.Checked)
                employeeID = (int?)DataTypeParser.Parse(cmbEmployee.SelectedValue, typeof(int), null);
            if (chkCustomerName.Checked)
                customerID = (int?)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), null);
            // Search and bind data
            LoadNBindCreditSaleInvoice(startDate, endDate, employeeID, customerID);
        }
        #endregion

        #region Private Methods
        private void LoadFilterData()
        {
            // Load and bind employees only from Sales and Marketing departments
            List<Tuple<string, object>> queryBuilder = new List<Tuple<string, object>>();
            Tuple<string, object> tpSales = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
            Tuple<string, object> tpMk = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
            queryBuilder.Add(tpSales);
            queryBuilder.Add(tpMk);
            cmbEmployee.DataSource = DataUtil.GetDataTableByOR(new EmployeeBL().GetAll(), queryBuilder);
            // Load and bind customers
            cmbCustomer.DataSource = new CustomerBL().GetAll();
        }

        private void LoadNBindCreditSaleInvoice(DateTime? startDate, DateTime? endDate, int? employeeID, int? customerID)
        {
            try
            {
                DataTable dtResult = new InvoiceBL().GetCreditSaleInvoice(startDate, endDate, employeeID, customerID);
                dgvVouchers.DataSource = dtResult;
                if (dtResult == null || dtResult.Rows.Count < 1)
                    dgvSaleDetail.DataSource = null;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                ToastMessageBox.Show(Resource.FailedToLoadData, Color.Red);
            }
        }

        /*
        private void LoadNBindInvoiceVoucher()
        {
            try
            {
                DataTable dtVouchers = new InvoiceBL().GetAll();

                dgvVouchers.AutoGenerateColumns = false;
                dgvVouchers.DataSource = DataUtil.GetDataTableBy(dtVouchers, "VoucherType", 0);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                ToastMessageBox.Show(Resource.FailedToLoadData, Color.Red);
            }
        }
        */

        private void LoadNBindSaleDetails(int invoiceID)
        {
            try
            {
                DataTable dtSaleDetail = new InvoiceBL().GetSaleDetailByInvoiceID(invoiceID);
                dgvSaleDetail.AutoGenerateColumns = false;
                dgvSaleDetail.DataSource = dtSaleDetail;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                ToastMessageBox.Show(Resource.FailedToLoadData, Color.Red);
            }
        }
        #endregion

        #region Constructors
        public frmInvoiceList()
        {
            InitializeComponent();
            dgvVouchers.AutoGenerateColumns = false;
            // Configure logger
            XmlConfigurator.Configure();
            // Load and bind filter data
            LoadFilterData();
        }
        #endregion

    }
}

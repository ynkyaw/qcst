/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/22 (yyyy/MM/dd)
 * Description: Invoice List (Cash sale)
 */
using System.Windows.Forms;
using log4net;
using log4net.Config;
using PTIC.VC;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using System.Drawing;
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.Common;
using System;
using System.Collections.Generic;
using PTIC.Util;
using PTIC.Common.BL;
using System.Data;

namespace PTIC.VC.Sale.OfficeSales
{
    public partial class frmCashSalesInvoices : Form
    {
        /// <summary>
        /// Logger for frmCashSalesInvoices
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmCashSalesInvoices));

        #region Events
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (sender is DateTimePicker && sender != null)
            {
                dtpOrderStart.Checked = dtpOrderEnd.Checked = (sender as DateTimePicker).Checked;
            }
        }

        private void dgvInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            int invoiceID = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells["colInvoiceID"].Value, typeof(int), -1);
            if (invoiceID < 0)
            {
                ToastMessageBox.Show(Resource.FailedToLoadData + " [Sale Items]", Color.Red);
                return;
            }
            LoadNBindProducts(invoiceID);
        }

        private void dgvInvoice_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Set row number on invoice grid view
            SetRowNumber(sender as DataGridView);
        }

        private void dgvSaleDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Set row number on sale detail grid view
            SetRowNumber(sender as DataGridView);
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

        private void lblSetup_Click(object sender, System.EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSalesPage));
            this.Close();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
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
            LoadNBindCashSaleInvoice(startDate, endDate, employeeID, customerID);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Load and bind cash sale invoices
        /// </summary>
        private void LoadNBindCashSaleInvoice(DateTime? startDate, DateTime? endDate, int? employeeID, int? customerID)
        {
            try
            {
                DataTable dtResult = new InvoiceBL().GetCashSaleInvoice(startDate, endDate, employeeID, customerID);
                dgvInvoice.DataSource = dtResult;
                if (dtResult == null || dtResult.Rows.Count < 1)
                    dgvSaleDetail.DataSource = null;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                ToastMessageBox.Show(Resource.FailedToLoadData, Color.Red);
            }
        }

        /// <summary>
        /// Load and bind sale items by invoice ID
        /// </summary>
        /// <param name="InvoiceID">invoice ID</param>
        private void LoadNBindProducts(int invoiceID)
        {
            try
            {
                dgvSaleDetail.DataSource = new InvoiceBL().GetSaleDetailByInvoiceID(invoiceID);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                ToastMessageBox.Show(Resource.FailedToLoadData + " [Sale Items]", Color.Red);
            }
        }

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

        /// <summary>
        /// Set row number on a specific DataGridView
        /// </summary>
        /// <param name="dgv">DataGridView to be numbered</param>
        private void SetRowNumber(DataGridView dgv)
        {
            if (null != dgv)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                }
            }
        }
        #endregion

        #region Constructor
        public frmCashSalesInvoices()
        {
            InitializeComponent();
            // Disable columns auto-generatioon
            dgvInvoice.AutoGenerateColumns = false;
            dgvSaleDetail.AutoGenerateColumns = false;
            // Configure logger
            XmlConfigurator.Configure();
            // Load and bind filter data
            LoadFilterData();
        }
        #endregion
                                                
    }
}

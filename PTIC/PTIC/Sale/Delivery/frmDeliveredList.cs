/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/22 (yyyy/MM/dd)
 * Description: Delivery form
 */
using System;
using System.Data;
using PTIC.Common;
using System.Windows.Forms;
using System.Data.SqlClient;
using log4net;
using PTIC.VC.Util;
using PTIC.Sale.Order;
using log4net.Config;
using PTIC.Sale.BL;
using PTIC.VC.Validation;
using PTIC.Util;
using System.Collections.Generic;
using PTIC.Common.BL;

namespace PTIC.Sale.Delivery
{
    /// <summary>
    /// Form for delivered orders
    /// </summary>
    public partial class frmDeliveredList : Form
    {
        /// <summary>
        /// Logger for frmNewOrder
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmDeliveredList));

        // Page setting
        private int _totalRecords = 0;
        private int _pageSize = 0;
        private int _pageCount = 0;
        //private int _currentPage = 1;
        private int _currentPage = 0;

        #region Events
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (sender is DateTimePicker && sender != null)
            {
                dtpOrderStart.Checked = dtpOrderEnd.Checked = (sender as DateTimePicker).Checked;
            }
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

        private void dgvdeliveredOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            var dgv = sender as DataGridView;
            object selectedDeliveryID = null;
            if ((selectedDeliveryID = dgv.Rows[e.RowIndex].Cells["colDeliveryID"].Value) != null)
            {
                int deliveryID = (int)DataTypeParser.Parse(selectedDeliveryID, typeof(int), -1);
                if (deliveryID != -1)
                {
                    // load order details
                    LoadNBindDeliveryDetailsByDeliveryID(deliveryID);
                }
            }
        }

        private void lblDelivery_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmOrderMain));
            this.Close();
        }

        private void dgvDeliveredOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void dgvDeliveryDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(true);
        }

        private void btnFillGrid_Click(object sender, EventArgs e)
        {
            LoadDeliveredOrders();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            GoNext();
            if (this._currentPage + 1 >= this._pageCount)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;

                btnPrevious.Enabled = true;
                btnFirst.Enabled = true;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            GoLast();

            btnLast.Enabled = false;
            btnNext.Enabled = false;

            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            GoPrevious();
            if (this._currentPage + 1 == 1)
            {
                btnPrevious.Enabled = false;
                btnFirst.Enabled = false;

                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            GoFirst();

            btnLast.Enabled = true;
            btnNext.Enabled = true;

            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
        }
        #endregion

        #region Private Methods
        private void LoadNBindDeliveredOrders()
        {
            try
            {
                dgvDeliveredOrders.DataSource = new DeliveryBL().GetDelivered();
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }

        private void LoadNBindDeliveryDetailsByDeliveryID(int deliveryID)
        {
            try
            {
                using (DataTable tblDeliveryDetails = new DeliveryDetailBL().GetByDeliveryID(deliveryID))
                {
                    dgvDeliveryDetails.DataSource = tblDeliveryDetails;
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }
        }

        private void ShowPageStatus()
        {
            // Show paging status
            this.lblStatus.Text = (this._pageCount == 0 ? "0" : (this._currentPage + 1).ToString()) +
                                            " / " + this._pageCount.ToString();
        }

        private void SetDefaultPageSetting()
        {
            this._totalRecords = 0;
            this._pageSize = 0;
            this._pageCount = 0;
            //this._currentPage = 1;
            this._currentPage = 0;
        }

        private void LoadPage(DateTime? startDate, DateTime? endDate, int? employeeID, int? customerID)
        {
            DataTable dtResult = new DeliveryBL().GetDeliveredTop(startDate, endDate, employeeID, customerID, this._currentPage, this._pageSize);
            this.dgvDeliveredOrders.DataSource = dtResult;
            if (dtResult == null || dtResult.Rows.Count < 1)
                dgvDeliveryDetails.DataSource = null;
        }

        private void VisualizePageButton()
        {
            this.btnFirst.Enabled = true;
            this.btnPrevious.Enabled = true;
            this.lblStatus.Enabled = true;
            this.btnNext.Enabled = true;
            this.btnLast.Enabled = true;

            if (this._pageCount == 0 || this._currentPage + 1 == this._pageCount)
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;

                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
            else if (this._currentPage == 0)
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
            }
        }

        private void SetPageSetting(DateTime? startDate, DateTime? endDate, int? employeeID, int? customerID, int pageSize)
        {
            // Page navigator setting
            this._pageSize = pageSize;
            this._totalRecords = GetCount(startDate, endDate, employeeID, customerID);
            this._pageCount = this._totalRecords / this._pageSize;

            // Adjust page count if the last page contains partial page.
            if (this._totalRecords % this._pageSize > 0)
                this._pageCount++;
        }

        private int GetCount(DateTime? startDate, DateTime? endDate, int? employeeID, int? customerID)
        {
            return new DeliveryBL().GetCount(startDate, endDate, employeeID, customerID);
        }

        private void LoadDeliveredOrders()
        {
            // Set default page setting value
            SetDefaultPageSetting();

            // Load page without date filter
            //LoadPage(null, null);

            // Enable/disable page navigation button
            VisualizePageButton();
        }

        private void ResetPageSetting(int pageSize)
        {
            this._totalRecords = 0;
            this._pageSize = pageSize;
            this._pageCount = 0;
            this._currentPage = 0;
        }

        private void GoFirst()
        {
            this._currentPage = 0;
            Search(false);
        }

        private void GoPrevious()
        {
            if (this._currentPage == this._pageCount)
                this._currentPage = this._pageCount - 1;

            this._currentPage--;

            if (this._currentPage < 1)
                this._currentPage = 0;

            Search(false);
        }

        private void GoNext()
        {
            this._currentPage++;

            if (this._currentPage > (this._pageCount - 1))
                this._currentPage = this._pageCount - 1;
            Search(false);
        }

        private void GoLast()
        {
            this._currentPage = this._pageCount - 1;
            Search(false);
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
        /// Show search result on grid
        /// </summary>
        /// <param name="onClickSearchButton">True is via clicking on search button, otherwise false</param>
        private void Search(bool onClickSearchButton)
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

            int pageSize = (int)DataTypeParser.Parse(this.txtPageSize.Text, typeof(int), 15);
            // Reset page setting if onClicked Search button
            if (onClickSearchButton)
            {
                ResetPageSetting(pageSize);
            }
            // Set page setting
            SetPageSetting(startDate, endDate, employeeID, customerID, pageSize);
            // Load lost order page
            LoadPage(startDate, endDate, employeeID, customerID);
            // Show page status
            ShowPageStatus();
            // Enable/disable page navigation button
            VisualizePageButton();
        }
        #endregion

        #region Constructors
        public frmDeliveredList()
        {
            InitializeComponent();
            // Configure logger
            XmlConfigurator.Configure();
            // Disable auto generating columns
            dgvDeliveredOrders.AutoGenerateColumns = false;
            dgvDeliveryDetails.AutoGenerateColumns = false;
            // Allow only interger in PageSize
            txtPageSize.ValidationExpression = PatternRule.NaturalNumberNonZero;
            // Load delivered orders
            LoadDeliveredOrders();
            // Load filter data
            LoadFilterData();
        }
        #endregion
        
    }
}

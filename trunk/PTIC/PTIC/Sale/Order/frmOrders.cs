/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/22 (yyyy/MM/dd)
 * Description: Orders form
 */
using System;
using System.Data;
using PTIC.Common;
using System.Windows.Forms;
using log4net;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.VC.Util;
using PTIC.Sale.Delivery;
using PTIC.Sale.BL;
using log4net.Config;
using PTIC.VC.Validation;
using PTIC.Common.BL;

namespace PTIC.Sale.Order
{
    /// <summary>
    /// Form for order lists
    /// </summary>
    public partial class frmOrders : Form
    {
        /// <summary>
        /// Logger for frmOrders
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmOrders));

        // Page setting
        private int _totalRecords = 0;
        private int _pageSize = 0;
        private int _pageCount = 0;
        //private int _currentPage = 1;
        private int _currentPage = 0;

        #region Events
        private void btnToDeliver_Click(object sender, EventArgs e)
        {
            string orderNo = null;
            if (string.IsNullOrEmpty(orderNo = txtOrderNo.Text))
                return;
            // TODO: handle call back function
            // Open undelivered form 
            UIManager.OpenForm(new frmDelivery(orderNo));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow.IsNewRow || dgvOrders.SelectedRows.Count < 1 || dgvOrderDetails.DataSource == null)
            {
                ToastMessageBox.Show(Resource.errSelectModifyRecord);
                return;
            }
            if ((int)dgvOrders.CurrentRow.Cells[colIsDelivered.Index].Value == 1)
            {
                MessageBox.Show("Order is already deliver! \n Can't be Delete Delivered Order","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.No)
                return;
            // Get selected order
            DataGridViewRow selectedRow = dgvOrders.CurrentRow;
            int orderID = (int)DataTypeParser.Parse(selectedRow.Cells["colOrderID"].Value, typeof(int), -1);
            DeleteOrder(orderID);
        }

        private void lblOrder_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmOrderMain));
            this.Close();
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtOrderNo.Clear();
            //if (e.RowIndex < 0)
            //    return;
            //var dgv = sender as DataGridView;
            //object selectedOrderID = null;
            //if ((selectedOrderID = dgv.Rows[e.RowIndex].Cells["colOrderID"].Value) != null)
            //{
            //    int orderID = (int)DataTypeParser.Parse(selectedOrderID, typeof(int), -1);
            //    if (orderID != -1)
            //    {
            //        // Show OrderNo
            //        txtOrderNo.Text = (string)DataTypeParser.Parse(dgv.Rows[e.RowIndex].Cells["colOrderNo"].Value, typeof(string), string.Empty);
            //        // Load order details
            //        LoadNBindOrderDetails(orderID);
            //    }
            //}
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            txtOrderNo.Clear();
            var dgv = sender as DataGridView;
            if (dgv == null || dgv.CurrentRow == null || dgv.CurrentRow.Index < 0)
                return;
            object selectedOrderID = null;
            if ((selectedOrderID = dgv.Rows[dgv.CurrentRow.Index].Cells["colOrderID"].Value) != null)
            {
                int orderID = (int)DataTypeParser.Parse(selectedOrderID, typeof(int), -1);
                if (orderID != -1)
                {
                    // Show OrderNo
                    txtOrderNo.Text = 
                        (string)DataTypeParser.Parse(dgv.Rows[dgv.CurrentRow.Index].Cells["colOrderNo"].Value, typeof(string), string.Empty);
                    // Load order details
                    LoadNBindOrderDetails(orderID);
                }
            }
        }

        private void dgvOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            // Set status caption
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if ((int)DataTypeParser.Parse(row.Cells["colIsDelivered"].Value, typeof(int), 0) == 1)
                    row.Cells["colStatus"].Value = Resource.Delivered;
                else
                    row.Cells["colStatus"].Value = Resource.Undelivered;
            }
            // Set row number
            if (null != dgv)
            {
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //FillOrders();
            SetDefaultPageSetting();
            // Load page with data filter
            LoadPage(dtpOrderStart.Value, dtpOrderEnd.Value);
            // Enable/disable page navigation button
            VisualizePageButton();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // TODO: Do not allow to modify planned / delivered order
            if (dgvOrders.CurrentRow.IsNewRow || dgvOrders.SelectedRows.Count < 1 || dgvOrderDetails.DataSource == null)
            {
                
                ToastMessageBox.Show(Resource.errSelectModifyRecord);
                return;
            }
            if ((int)dgvOrders.CurrentRow.Cells[colIsDelivered.Index].Value == 1) 
            {
                MessageBox.Show("Order is already deliver! \n Can't be Edit Delivered Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Get an order
            DataGridViewRow selectedRow = dgvOrders.CurrentRow;
            Entities.Order mdOrder = new Entities.Order()
            {
                ID = (int)DataTypeParser.Parse(selectedRow.Cells["colOrderID"].Value, typeof(int), -1),
                CusID = (int)DataTypeParser.Parse(selectedRow.Cells["colCusID"].Value, typeof(int), -1),
                OrderReceieverID = (int)DataTypeParser.Parse(selectedRow.Cells["colOrderReceieverID"].Value, typeof(int), -1),
                OrderNo = (string)DataTypeParser.Parse(selectedRow.Cells["colOrderNo"].Value, typeof(string), string.Empty),
                OrderDate = (DateTime)DataTypeParser.Parse(selectedRow.Cells["colOrderDate"].Value, typeof(DateTime), DateTime.Now),
            };
            int townID = (int)DataTypeParser.Parse(selectedRow.Cells["colTownID"].Value, typeof(int), -1);
            // Get order details
            //DataRowCollection mdOrderDetails = (dgvOrderDetails.DataSource as DataTable).Rows;
            frmOrder frmOrder = new frmOrder(mdOrder, townID, (dgvOrderDetails.DataSource as DataTable).Copy());
            frmOrder.OrderSavedHandler += new Order.frmOrder.OrderSaveHandler(frmOrder_CallBack);
            UIManager.OpenForm(frmOrder);
        }

        private void frmOrder_CallBack(object sender, frmOrder.OrderSaveEventArgs e)
        {
            // If changes occured, reload orders
            if (e.OccuredChanges)
            {
                LoadOrders();
                //LoadNBindOrders();
            }
        }

        private void dgvOrderDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            // Set row number
            if (null != dgv)
            {
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void btnFillGrid_Click(object sender, EventArgs e)
        {
            LoadOrders();            
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            GoFirst();

            btnLast.Enabled = true;
            btnNext.Enabled = true;

            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
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
        #endregion

        #region Private Methods
        /*
        private void LoadNBindOrders()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                dgvOrders.DataSource = new OrderBL().GetAll(conn);
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
                throw;
            }
            finally 
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        */

        private void LoadNBindOrderDetails(int orderID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                using (DataTable tblOrderDetails = new OrderDetailBL().GetByOrderID(orderID))
                {
                    dgvOrderDetails.DataSource = tblOrderDetails;
                }
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
                throw;
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void DeleteOrder(int orderID)
        {
            SqlConnection conn = null;
            int affectedRow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                affectedRow = new OrderBL().DeleteByOrderID(orderID, conn);
                if (affectedRow > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    // Reload orders
                    LoadOrders();
                    //LoadNBindOrders();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave);
            }
            catch (SqlException sqle)
            {
                ToastMessageBox.Show(Resource.errFailedToSave);
                _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        /***** Paging *****/
        #region Paging
        private void FillOrders()
        {
            // Enable paging control button
            EnablePaging(dtpOrderStart.Value, dtpOrderEnd.Value);
            // Load page without date filter
            LoadPage(null, null);
        }

        private void EnablePaging(DateTime? startDate, DateTime? endDate)
        {
            this.btnFirst.Enabled = true;
            this.btnPrevious.Enabled = true;
            this.lblStatus.Enabled = true;
            this.btnNext.Enabled = true;
            this.btnLast.Enabled = true;

            // For Page view.
            this._pageSize = int.Parse(this.txtPageSize.Text);
            this._totalRecords = GetCount(startDate, endDate);
            this._pageCount = this._totalRecords / this._pageSize;

            // Adjust page count if the last page contains partial page.
            if (this._totalRecords % this._pageSize > 0)
                this._pageCount++;
        }

        private void SetDefaultPageSetting()
        {
            this._totalRecords = 0;
            this._pageSize = 0;
            this._pageCount = 0;
            //this._currentPage = 1;
            this._currentPage = 0;
        }

        private int GetCount(DateTime? startDate, DateTime? endDate)
        {
            return new OrderBL().GetOrderCount(startDate, endDate);
        }

        private void LoadPage(DateTime? startDate, DateTime? endDate)
        {
            int CustomerID = (int)DataTypeParser.Parse(cmbCustomer.SelectedValue,typeof(int), -1);
            int DeptID = (int)DataTypeParser.Parse(cmbDept.SelectedValue, typeof(int), -1);
            // TODO: Clear OrderDetail

            EnablePaging(startDate, endDate);

            // Populate DataGridView
            this.dgvOrders.DataSource = new OrderBL().Get(startDate, endDate, CustomerID,DeptID,this._currentPage, this._pageSize);
            // Show paging status
            this.lblStatus.Text = (this._currentPage + 1).ToString() +
                                            " / " + this._pageCount.ToString();
        }

        private void GoFirst()
        {
            this._currentPage = 0;
            // Load page with data filter
            LoadPage(dtpOrderStart.Value, dtpOrderEnd.Value);
            //LoadPage(null, null);
        }

        private void GoPrevious()
        {
            if (this._currentPage == this._pageCount)
                this._currentPage = this._pageCount - 1;

            this._currentPage--;

            if (this._currentPage < 1)
                this._currentPage = 0;

            // Load page with data filter
            LoadPage(dtpOrderStart.Value, dtpOrderEnd.Value);
            //LoadPage(null, null);
        }

        private void GoNext()
        {
            this._currentPage++;

            if (this._currentPage > (this._pageCount - 1))
                this._currentPage = this._pageCount - 1;
            // Load page with data filter
            LoadPage(dtpOrderStart.Value, dtpOrderEnd.Value);
            //LoadPage(null, null);
        }

        private void GoLast()
        {
            this._currentPage = this._pageCount - 1;
            // Load page with data filter
            LoadPage(dtpOrderStart.Value, dtpOrderEnd.Value);
            //LoadPage(null, null);
        }

        private void VisualizePageButton()
        {
            if (dgvOrders.Rows.Count < 1 || this._currentPage + 1 == this._pageCount)
            {
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }            
            this.btnFirst.Enabled = false;
            this.btnPrevious.Enabled = false;
        }

        private void LoadOrders()
        {
            // Load and bind customers
            DataTable dtCustomer = new CustomerBL().GetAll();
            DataRow rowUnselect = dtCustomer.NewRow();
            rowUnselect["CustomerID"] = -1;
            rowUnselect["CusName"] = "-- Unselect --";
            dtCustomer.Rows.InsertAt(rowUnselect, 0);
            cmbCustomer.DataSource = dtCustomer;
            // Load and bind department
            DataTable dtDept = new DepartmentBL().GetAll();
            DataRow rowUnselectDept = dtDept.NewRow();
            rowUnselectDept["ID"] = -1;
            rowUnselectDept["DeptName"] = "-- Unselect --";
            dtDept.Rows.InsertAt(rowUnselectDept, 0);
            cmbDept.DataSource = dtDept;

            //FillOrders();
            SetDefaultPageSetting();
            // Load page without date filter
            //LoadPage(null, null);
            // Enable/disable page navigation button
            VisualizePageButton();
        }
        #endregion
        /***** End of Paging *****/
        #endregion

        #region Constructors
        public frmOrders()
        {
            InitializeComponent();
            // Configure logger
            XmlConfigurator.Configure();

            // Disable auto-generating columns
            dgvOrders.AutoGenerateColumns = false;
            dgvOrderDetails.AutoGenerateColumns = false;
            // Allow only interger in PageSize
            txtPageSize.ValidationExpression = PatternRule.NaturalNumberNonZero;
            
            // Load order list
            LoadOrders();
            //LoadNBindOrders();
        }
        #endregion
                                                        
    }
}

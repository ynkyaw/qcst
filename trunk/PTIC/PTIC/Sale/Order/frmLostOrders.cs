/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/22 (yyyy/MM/dd)
 * Description: Lost Orders form
 */
using System.Windows.Forms;
using System.Data.SqlClient;
using log4net;
using PTIC.Sale.DA;
using PTIC.VC;
using PTIC.Sale.BL;
using System;
using PTIC.VC.Validation;
using PTIC.Common;
using System.Data;
using PTIC.VC.Util;

namespace PTIC.Sale.Order
{
    /// <summary>
    /// Form for lost orders
    /// </summary>
    public partial class frmLostOrders : Form
    {
        /// <summary>
        /// Logger for frmLostOrder
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmLostOrders));

        // Page setting
        private int _totalRecords = 0;
        private int _pageSize = 0;
        private int _pageCount = 0;
        //private int _currentPage = 1;
        private int _currentPage = 0;

        #region Events
        private void lblBakToOrder_Click(object sender, System.EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmOrderMain));
            this.Close();
        }

        private void dgvLostOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void lblFilter_Click(object sender, System.EventArgs e)
        {
            if (pnlFilter.Visible)
            {
                pnlFilter.Visible = false;
                lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
            }
            else
            {
                pnlFilter.Visible = true;

                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
            }
        }

        private void dtpLostOrderStart_EnabledChanged(object sender, System.EventArgs e)
        {
            dtpLostOrderEnd.Enabled = dtpLostOrderStart.Enabled;
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            Search(true);
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

        private void btnFillGrid_Click(object sender, EventArgs e)
        {
            LoadLostOrders();
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

        private void btnLast_Click(object sender, EventArgs e)
        {
            GoLast();

            btnLast.Enabled = false;
            btnNext.Enabled = false;

            btnFirst.Enabled = true;
            btnPrevious.Enabled = true;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (sender == dtpLostOrderStart)
                dtpLostOrderEnd.Checked = dtpLostOrderStart.Checked;
            else if (sender == dtpLostOrderEnd)
                dtpLostOrderStart.Checked = dtpLostOrderEnd.Checked;
        }
        #endregion        

        #region Private Methods        
        private void LoadLostOrders()
        {            
            int pSize = (int)DataTypeParser.Parse(txtPageSize.Text, typeof(int), 15);
            // Set default page size if absent
            txtPageSize.Text = pSize.ToString();
            // Reset page setting for fist page loading
            ResetPageSetting(pSize);
            
            // Load page without date filter
            //LoadPageFill();

            // Enable/disable page navigation button
            VisualizePageButton();
        }

        private void LoadNBindFilterData()
        {            
            try
            {
                DataSet ds = new DataSet();
                BindingSource bdTown = new BindingSource();
                BindingSource bdCustomer = new BindingSource();
                DataRow rowUnselect = null;

                DataTable dtTown = new TownBL().GetAll();
                rowUnselect = dtTown.NewRow();
                rowUnselect["TownID"] = -1;
                rowUnselect["Town"] = "-- Unselect --";
                dtTown.Rows.InsertAt(rowUnselect, 0);

                DataTable dtCustomer = new CustomerBL().GetAll();

                // add town and customer tables into a dataset
                ds.Tables.Add(dtTown);
                ds.Tables.Add(dtCustomer);

                // create data relation between town and customer
                DataRelation relTown_Customer = new DataRelation("Town_Customer", dtTown.Columns["TownID"], dtCustomer.Columns["TownID"]);
                // add relation into a dataset
                ds.Relations.Add(relTown_Customer);                
                bdTown.DataSource = ds;
                bdTown.DataMember = dtTown.TableName;

                bdCustomer.DataSource = bdTown;
                bdCustomer.DataMember = relTown_Customer.RelationName;

                cmbTown.DataSource = bdTown;
                cmbCustomer.DataSource = bdCustomer;
                
                DataTable dtProduct = new ProductBL().GetAll();                
                rowUnselect = dtProduct.NewRow();
                rowUnselect["ProductID"] = -1;
                rowUnselect["ProductName"] = "-- Unselect --";
                dtProduct.Rows.InsertAt(rowUnselect, 0);

                mbProduct.DataSource = dtProduct;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                throw;
            }           
        }

        /// <summary>
        /// Show search result on grid
        /// </summary>
        /// <param name="onClickSearchButton">True is via clicking on search button, otherwise false</param>
        private void Search(bool onClickSearchButton)
        {                        
            DateTime? startDate = null;
            DateTime? endDate = null;
            if (dtpLostOrderStart.Checked && dtpLostOrderEnd.Checked)
            {
                startDate = dtpLostOrderStart.Value;
                endDate = dtpLostOrderEnd.Value;
            }
            int? customerID = (int?)cmbCustomer.SelectedValue > 0 ? (int?)cmbCustomer.SelectedValue : null;
            int? productID = (int?)mbProduct.SelectedValue > 0 ? (int?)mbProduct.SelectedValue : null;
            int? townID = (int?)cmbTown.SelectedValue > 0 ? (int?)cmbTown.SelectedValue : null;
            int pageSize = (int)DataTypeParser.Parse(this.txtPageSize.Text, typeof(int), 15);

            // Reset page setting if onClicked Search button
            if (onClickSearchButton)
            {
                ResetPageSetting(pageSize);                
            }
            // Set page setting
            SetPageSetting(startDate, endDate, customerID, townID, productID, pageSize);
            // Load lost order page
            LoadPage(startDate, endDate, customerID, townID, productID);            
            // Show page status
            ShowPageStatus();
            // Enable/disable page navigation button
            VisualizePageButton();
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

        private void LoadPage(DateTime? startDate, DateTime? endDate, int? customerID, int? townID, int? productID)
        {                        
            // Populate DataGridView
            this.dgvLostOrders.DataSource = new OrderBL().GetLostTop(startDate, endDate, customerID, townID, productID, 
                this._currentPage, this._pageSize);
        }

        private void ShowPageStatus()
        {
            // Show paging status
            this.lblStatus.Text = (this._pageCount == 0 ? "0" : (this._currentPage + 1).ToString()) +
                                            " / " + this._pageCount.ToString();
        }

        //private void LoadPageFill()
        //{
        //    EnablePaging(null, null);

        //    // Populate DataGridView
        //    this.dgvLostOrders.DataSource = new OrderBL().GetLostTop(this._currentPage, this._pageSize);
        //    // Show paging status
        //    this.lblStatus.Text = (this._currentPage + 1).ToString() +
        //                                    " / " + this._pageCount.ToString();
        //}

        //private void EnablePaging(DateTime? startDate, DateTime? endDate)
        //{
        //    this.btnFirst.Enabled = true;
        //    this.btnPrevious.Enabled = true;
        //    this.lblStatus.Enabled = true;
        //    this.btnNext.Enabled = true;
        //    this.btnLast.Enabled = true;

        //    // For Page view.
        //    this._pageSize = int.Parse(this.txtPageSize.Text);
        //    this._totalRecords = GetCountLost(startDate, endDate);
        //    this._pageCount = this._totalRecords / this._pageSize;

        //    // Adjust page count if the last page contains partial page.
        //    if (this._totalRecords % this._pageSize > 0)
        //        this._pageCount++;
        //}

        private void EnablePagingLost(DateTime? startDate, DateTime? endDate, int? customerID, int? townID, int? productID)
        {
            this.btnFirst.Enabled = true;
            this.btnPrevious.Enabled = true;
            this.lblStatus.Enabled = true;
            this.btnNext.Enabled = true;
            this.btnLast.Enabled = true;

            // For Page view.
            this._pageSize = int.Parse(this.txtPageSize.Text);
            this._totalRecords = GetCountLost(startDate, endDate, customerID, townID, productID);
            this._pageCount = this._totalRecords / this._pageSize;

            // Adjust page count if the last page contains partial page.
            if (this._totalRecords % this._pageSize > 0)
                this._pageCount++;
        }

        private int GetCountLost(DateTime? startDate, DateTime? endDate, int? customerID, int? townID, int? productID)
        {
            return new OrderBL().GetLostCount(startDate, endDate, customerID, townID, productID);
        }

        private int GetCountLost(DateTime? startDate, DateTime? endDate)
        {
            return new OrderBL().GetLostCount(startDate, endDate);
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
            else if(this._currentPage == 0)
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
            }
        }

        private void ResetPageSetting(int pageSize)
        {
            this._totalRecords = 0;
            this._pageSize = pageSize;
            this._pageCount = 0;            
            this._currentPage = 0;
        }

        private void SetPageSetting(
            DateTime? startDate, DateTime? endDate, 
            int? customerID, int? townID, int? productID,
            int pageSize
            )
        {
            //this.btnFirst.Enabled = true;
            //this.btnPrevious.Enabled = true;
            //this.lblStatus.Enabled = true;
            //this.btnNext.Enabled = true;
            //this.btnLast.Enabled = true;

            // Page navigator setting
            this._pageSize = pageSize;            
            this._totalRecords = GetCountLost(startDate, endDate, customerID, townID, productID);
            this._pageCount = this._totalRecords / this._pageSize;

            // Adjust page count if the last page contains partial page.
            if (this._totalRecords % this._pageSize > 0)
                this._pageCount++;
        }
        #endregion

        #region Constructors
        public frmLostOrders()
        {
            InitializeComponent();
            // disable auto generating columns
            dgvLostOrders.AutoGenerateColumns = false;
            //Load Combo boxes
            LoadNBindFilterData();
            // Allow only interger in PageSize
            txtPageSize.ValidationExpression = PatternRule.NaturalNumberNonZero;
            // Load lost ordres
            LoadLostOrders();
        }
        #endregion

        

    }
}

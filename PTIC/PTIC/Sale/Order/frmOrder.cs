/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/22 (yyyy/MM/dd)
 * Description: New / Edit order form
 */
using System;
using System.Collections.Generic;
using System.Data;
using PTIC.Common;
using System.Windows.Forms;
using System.Data.SqlClient;
using log4net;
using PTIC.Common.BL;
using PTIC.Sale.Entities;
using PTIC.VC;
using PTIC.VC.Util;
using System.Drawing;
using log4net.Config;
using PTIC.Util;
using PTIC.Formatting;
using PTIC.Sale.BL;
using PTIC.VC.Sale.Setup;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using PTIC.VC.Validation;

namespace PTIC.Sale.Order
{
    /// <summary>
    /// Form for new/existing order
    /// </summary>
    public partial class frmOrder : Form
    {
        /// <summary>
        /// Logger for frmOrder
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmOrder));

        /// <summary>
        /// Order to be modified
        /// </summary>
        private Entities.Order _mdOrder = null;

        /// <summary>
            //0 = End User (Retail)
            //1 = Retail Outlet (Retail)
            //2 = Wholesale Outlet (Wholesale)
            //3 = Company (Retail)
            //4 = Government (?)
        /// </summary>
        //private int _customerType = 0;

        /// <summary>
        /// Product prices table
        /// </summary>
        //private DataTable _dtProductPrices = null;

        /// <summary>
        /// 
        /// </summary>
        //private int _customerID, _townshipID, _customerTypeID = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void OrderSaveHandler(object sender, OrderSaveEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        public event OrderSaveHandler OrderSavedHandler;
        
        #region Events
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            //UIManager.OpenForm(typeof(frmNewCustomer));
            frmNewCustomer formTmpCustomer = new frmNewCustomer(false);
            // Set call back function
            formTmpCustomer.TempCustomerSavedHandler += new frmNewCustomer.TempCustomerSaveHandler(formTmpCustomer_CallBack);
            // Open an entry form for a temp customer
            UIManager.OpenForm(formTmpCustomer);
        }

        void formTmpCustomer_CallBack(object sender, frmNewCustomer.TempCustomerSaveEventArgs e)
        {
            // Reload data
            LoadNBind();
            // Set a selected town
            cmbTown.SelectedValue = e.SavedAddress.TownID;
            // Set a selected customer
            cmbCustomer.SelectedValue = e.SavedTempCustomer.ID;
        }

        private void lblBakToOrder_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmOrderMain));
            this.Close();
        }

        private void cmbCustomer_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            DataRowView selectedCustomerRow = cmb.SelectedItem as DataRowView;
            ClearValues();
            if (selectedCustomerRow == null)
            {
                return;
            }
            SetValuesBySelectedCustomer(selectedCustomerRow);  
        }

        private void dgvOrderDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            var gv = sender as DataGridView;
            string curColumName = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
            DataGridViewRow curRow = gv.Rows[e.RowIndex];
            if (curColumName.Equals("colRSPrice") || curColumName.Equals("colWSPrice") || curColumName.Equals("colQty"))
            {
                // Set whole sale price as sale price
                decimal salePrice = Convert.ToDecimal(DataTypeParser.Parse(curRow.Cells["colWSPrice"].Value, typeof(decimal), 0));

                // Validate whole sale price
                if (curColumName.Equals("colWSPrice"))
                {
                     if (salePrice <= 0)
                    {
                        MessageBox.Show(Resource.DefinePrice,
                            "သတိပေးချက်",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }                    
                }
                
                int qty = (int)DataTypeParser.Parse(curRow.Cells["colQty"].Value, typeof(int), 0);
                // Set amount = whole sale * qty
                curRow.Cells["colAmount"].Value = salePrice * qty;
            }
            else if (curColumName.Equals("colProductID"))
            {
                // Get and set Whole sale price and Retail sale price
                int selectedProductID = (int)DataTypeParser.Parse(curRow.Cells["colProductID"].Value, typeof(int), -1);
                if (selectedProductID == -1)
                    return;                
                // Get and set Whole sale price and Retail sale price by Order Date                
                PriceChange productPrice = new PriceChangeBL().GetPrice(selectedProductID, dtpOrderDate.Value);
                if(productPrice != null)
                {                    
                    curRow.Cells["colWSPrice"].Value = productPrice.WSPrice;
                    curRow.Cells["colRSPrice"].Value = productPrice.RSPrice;
                }
                else // If there is no price defined, set 0 as default
                {
                    curRow.Cells["colWSPrice"].Value = 0;
                    curRow.Cells["colRSPrice"].Value = 0;
                }
            }
            else if (curColumName.Equals("colAmount")) // Calculate summary of amount
            {
                txtTotalAmount.Text = (string)DataTypeParser.Parse(CalculateTotalAmount(gv), typeof(string), "0");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save a new order
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetail.CurrentRow.IsNewRow || dgvOrderDetail.SelectedRows.Count < 1)
            {
                MessageBox.Show(Resource.errSelectRowToDelete, this.Text, 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;            
            
            DataGridViewRow selectedRow = dgvOrderDetail.CurrentRow;
            if (selectedRow != null && (selectedRow.DataBoundItem as DataRowView).Row.RowState == DataRowState.Added)
            {
                // Delete row just from GridView because it is a new row that has not been in Database
                dgvOrderDetail.Rows.RemoveAt(selectedRow.Index);
                // Add initial new row because there is no more row
                AddInitialNewRow();
                return;
            }

            int orderDetailID = (int)DataTypeParser.Parse(selectedRow.Cells["colOrderDetailID"].Value, typeof(int), -1);
            if (orderDetailID == -1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete, Color.Red);
            }
            else
            {
                // delete a selected order
                DeleteOrderDetail(orderDetailID);
            }
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvOrderDetail.CurrentCell.ColumnIndex;
                int iRow = dgvOrderDetail.CurrentCell.RowIndex;
                if (iColumn == dgvOrderDetail.Columns["colRemark"].Index)
                {
                    if (dgvOrderDetail.CurrentRow.ErrorText != String.Empty) return true;
                    if (iRow + 1 >= dgvOrderDetail.Rows.Count)
                    {
                        DataUtil.AddNewRow(dgvOrderDetail.DataSource as DataTable);
                        dgvOrderDetail[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        try
                        {
                            dgvOrderDetail.CurrentCell = dgvOrderDetail[0, iRow + 1];
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else
                {
                    try
                    {
                        dgvOrderDetail.CurrentCell = dgvOrderDetail[dgvOrderDetail.CurrentCell.ColumnIndex + 1, dgvOrderDetail.CurrentCell.RowIndex];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        private void dgvOrderDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            // Set text format            
            decimal totalAmt = (decimal)DataTypeParser.Parse(txtTotalAmount.Text, typeof(decimal), 0);
            txtTotalAmount.Text = totalAmt.ToString(TextFormat.WholeNumber);
        }

        private void dgvOrderDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {           
        }

        private void dgvOrderDetail_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
        }        

        private void dgvOrderDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvOrderDetail.DataSource as DataTable);
            dgvOrderDetail.CurrentCell = dgvOrderDetail.Rows[dgvOrderDetail.RowCount - 1].Cells["colProductID"];
        }

        private void dgvOrderDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (e.ColumnIndex == colProductID.Index)
            {
                foreach (DataGridViewRow row in dgvOrderDetail.Rows)
                {
                    if (row.Index != e.RowIndex && !row.IsNewRow)
                    {
                        if (row.Cells["colProductID"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") 
                            return;
                        if (row.Cells["colProductID"].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgvOrderDetail.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
                            MessageBox.Show("Duplicate Not Allowed!", this.Text, 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            dgvOrderDetail.Rows[e.RowIndex].ErrorText = String.Empty;
                        }
                    }
                }
            }
        }

        private void dgvOrderDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var gv = sender as DataGridView;
            if (gv == null || gv.CurrentRow == null) 
                return;

            /*
            if (e.ColumnIndex == colProductID.Index && gv.Rows[e.RowIndex].ErrorText != String.Empty) // Product ID
            {
                gv.CurrentRow.Cells[colProductID.Index].Value = -1;
                gv.CurrentRow.Cells[colRSPrice.Index].Value = 0;
                gv.CurrentRow.Cells[colWSPrice.Index].Value = 0;
                gv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
             */ 
            if (e.ColumnIndex == colQty.Index && dgvOrderDetail.Rows[e.RowIndex].ErrorText != String.Empty) // Qty
            {
                gv.CurrentRow.Cells[colQty.Index].Value = 0;
                gv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            else if (e.ColumnIndex == colProductID.Index)
            {                
                decimal salePrice = (decimal)DataTypeParser.Parse(gv.CurrentRow.Cells[colRSPrice.Index].Value, typeof(decimal), 0);
                decimal wsPrice = (decimal)DataTypeParser.Parse(gv.CurrentRow.Cells[colWSPrice.Index].Value, typeof(decimal), 0);
                if (salePrice <= 0 && wsPrice <= 0)
                {
                    MessageBox.Show(Resource.DefinePrice,
                        "သတိပေးချက်",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    gv.CurrentRow.Cells["colProductID"].Value = -1;
                    return;
                }
            }
        }

        private void dgvOrderDetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvOrderDetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            dtpOrderDate.MaxDate = DateTime.Today;
        }

        private void dgvOrderDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            if (dgvOrderDetail.CurrentCell.ColumnIndex == colQty.Index || dgvOrderDetail.CurrentCell.ColumnIndex == colWSPrice.Index)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }


        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {            
            KeyPressfunction.CheckInt(sender, e);
        }

        private void dgvOrderDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            var gv = sender as DataGridView;
            if (gv != null)
                txtTotalAmount.Text = (string)DataTypeParser.Parse(CalculateTotalAmount(gv), typeof(string), "0");
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        private void InitializeComponentAndData()
        {
            InitializeComponent();
            // Configure logger
            XmlConfigurator.Configure();
            // Disable auto generating columns
            dgvOrderDetail.AutoGenerateColumns = false;
            // Instantiate Order not assign yet
            if (_mdOrder == null)
                _mdOrder = new Entities.Order();
            // Load necessary data
            LoadNBind();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadNBind()
        {            
            try
            {                
                DataSet ds = new DataSet();
                BindingSource bdTown = new BindingSource();
                BindingSource bdCustomer = new BindingSource();

                DataTable dtTown = new TownBL().GetAll();
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
                bdCustomer.DataMember = "Town_Customer";

                cmbTown.DataSource = bdTown;
                cmbCustomer.DataSource = bdCustomer;

                // Load employees                                                                                                
                List<Tuple<string, object>> queryBuilder = new List<Tuple<string, object>>();
                Tuple<string, object> tpSales = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
                Tuple<string, object> tpMk = Tuple.Create<string, object>("DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
                queryBuilder.Add(tpSales);
                queryBuilder.Add(tpMk);
                cmbReceiver.DataSource = DataUtil.GetDataTableByOR(new EmployeeBL().GetAll(), queryBuilder);

                // Load products
                colProductID.DataSource = new ProductBL().GetAll();                
                // Set display member and value member for product
                colProductID.DisplayMember = "ProductName";
                colProductID.ValueMember = "ProductID";

                //cmbCustomer.SelectedValue = _customerID;
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderID">Nullable Order ID</param>
        private void LoadNBindByOrderID(int? orderID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                int intOrderID = (int)DataTypeParser.Parse(orderID, typeof(int), -1);
                using (DataTable tblOrderDetails = new OrderDetailBL().GetByOrderID(intOrderID))
                {
                    // Bind order details
                    dgvOrderDetail.DataSource = tblOrderDetails;
                }
                // Instantiate Order not assign yet
                if(_mdOrder == null)
                    _mdOrder = new Entities.Order();
                // Make order present in current form
                _mdOrder.ID = orderID;
                if (!orderID.HasValue)
                    return;
                DataTable dtSelectedOrder = new OrderBL().GetByID(orderID.Value);
                if (dtSelectedOrder != null && dtSelectedOrder.Rows.Count > 0)
                {
                    DataRow row = dtSelectedOrder.Rows[0];
                    // Set town and customer
                    cmbTown.SelectedValue = (int)DataTypeParser.Parse(row["TownID"], typeof(int), 0);
                    cmbCustomer.SelectedValue = (int)DataTypeParser.Parse(row["CusID"], typeof(int), 0);
                    dtpOrderDate.Value = (DateTime)DataTypeParser.Parse(row["OrderDate"], typeof(DateTime), DateTime.Now);
                    cmbReceiver.SelectedValue = (int)DataTypeParser.Parse(row["OrderReceieverID"], typeof(int), 0);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdOrder"></param>
        /// <param name="townID"></param>
        /// <param name="mdOrderDetails"></param>
        private void LoadNBindOrderAndDetails(Entities.Order mdOrder, int townID, DataTable mdOrderDetails)
        {
            // Set an existing order to be modified
            this._mdOrder = mdOrder;
            // Load order
            cmbTown.SelectedValue = townID;
            cmbCustomer.SelectedValue = mdOrder.CusID;
            txtOrderNo.Text = mdOrder.OrderNo;
            dtpOrderDate.Value = mdOrder.OrderDate;
            cmbReceiver.SelectedValue = mdOrder.OrderReceieverID;
            //txtCreditAmount
            // TODO: အကြွေးလက်ကျန်ပြရန်
            // Load order details
            dgvOrderDetail.DataSource = mdOrderDetails;
            // see an order in edit mode            
            lblOrder.Text = lblOrder.Text + " [ Edit ]";
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearValues()
        {            
            // clear field values
            txtContactPerson.Text = string.Empty;
            txtRoute.Text = string.Empty;
            txtTrip.Text = string.Empty;
            txtCreditLimitAmt.Text = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedCustomer"></param>
        private void SetValuesBySelectedCustomer(DataRowView selectedCustomer)
        {
            string contactPerson = (string)DataTypeParser.Parse(selectedCustomer["ConPersonName"], typeof(string), string.Empty);
            string route = (string)DataTypeParser.Parse(selectedCustomer["RouteName"], typeof(string), string.Empty);
            string trip = (string)DataTypeParser.Parse(selectedCustomer["TripName"], typeof(string), string.Empty);
            //string creditLimitAmt = (string)DataTypeParser.Parse(selectedCustomer["CreditAmount"], typeof(string), string.Empty);
            decimal creditLimitAmt = (decimal)DataTypeParser.Parse(selectedCustomer["CreditAmount"], typeof(decimal), 0);
            // Set customer type
            //_customerType = (int)DataTypeParser.Parse(selectedCustomer["CusType"], typeof(int), 0); // default End User

            // set field values
            txtContactPerson.Text = contactPerson;
            txtRoute.Text = route;
            txtTrip.Text = trip;
            txtCreditLimitAmt.Text = creditLimitAmt.ToString("N0");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetailIDs"></param>
        /// <returns></returns>
        private int DeleteOrderDetail(int[] orderDetailIDs) 
        {            
            OrderDetailBL orderDetailSaver = null;
            int affectedRows = 0;
            try
            {                
                orderDetailSaver = new OrderDetailBL();
                foreach(int id in orderDetailIDs)
                {
                    affectedRows += orderDetailSaver.DeleteByOrderDetailID(id);
                }
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
            }          
            return affectedRows;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Save()
        {            
            OrderBL orderSaver = null;
            OrderDetailBL orderDetailSaver = null;
            Entities.Order order = null;
            int? affectedRows = null;
            List<OrderDetail> orderDetails = null;
            try
            {                
                orderSaver = new OrderBL();
                orderDetailSaver = new OrderDetailBL();
                orderDetails = new List<OrderDetail>();
                order = new Entities.Order() 
                {
                    // OrderID
                    CusID = (int)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), -1),
                    OrderReceieverID = (int)DataTypeParser.Parse(cmbReceiver.SelectedValue, typeof(int), -1),
                    //OrderNo = txtOrderNo.Text,
                    OrderDate = dtpOrderDate.Value,
                    IsMain = false,
                    IsDevice = false
                };
                
                if (_mdOrder == null || !_mdOrder.ID.HasValue || _mdOrder.ID < 1) // Add new order and details
                {
                    foreach (DataGridViewRow row in dgvOrderDetail.Rows)
                    {
                        if (row.IsNewRow)
                            break;
                        OrderDetail orderDetail = new OrderDetail()
                        {
                            ID = (int)DataTypeParser.Parse(row.Cells["colOrderDetailID"].Value, typeof(int), -1),
                            OrderID = (int)DataTypeParser.Parse(row.Cells["colDetailOrderID"].Value, typeof(int), -1),
                            ProductID = (int)DataTypeParser.Parse(row.Cells["colProductID"].Value, typeof(int), -1),
                            WSPrice = Convert.ToDecimal(DataTypeParser.Parse(row.Cells["colWSPrice"].Value, typeof(decimal), 0)),
                            RSPrice = Convert.ToDecimal(DataTypeParser.Parse(row.Cells["colRSPrice"].Value, typeof(decimal), 0)),
                            Qty = (int)DataTypeParser.Parse(row.Cells["colQty"].Value, typeof(int), 0),
                            Amount = Convert.ToDecimal(DataTypeParser.Parse(row.Cells["colAmount"].Value, typeof(decimal), 0)),
                            Remark = (string)DataTypeParser.Parse(row.Cells["colRemark"].Value, typeof(string), string.Empty),
                        };
                        // Add it into list                        
                        orderDetails.Add(orderDetail);
                    }
                                                                                
                    // Save and make order present in current form                    
                    _mdOrder.ID = affectedRows = orderSaver.Add(order, orderDetails);
                    // Check field validation failed or not
                    if (!orderSaver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(orderSaver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            this.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                else // Update an existing order and details
                {
                    // Update order by order ID (master)
                    order.ID = _mdOrder.ID;
                    affectedRows = orderSaver.UpdateByOrderID(order);
                    if (!orderSaver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(orderSaver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            this.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    // DataTable bound to DataGridView
                    DataTable dt = dgvOrderDetail.DataSource as DataTable;

                    // Clear OrderDetail list before addition
                    orderDetails.Clear();
                    // New Order Details (detail)
                    DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                    foreach (DataRow row in dvInsert.ToTable().Rows)
                    {
                        OrderDetail newOrderDetail = new OrderDetail()
                        {
                            OrderID = (int)DataTypeParser.Parse(_mdOrder.ID, typeof(int), -1),
                            ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                            WSPrice = Convert.ToDecimal(DataTypeParser.Parse(row["WSPrice"], typeof(decimal), 0)),
                            RSPrice = Convert.ToDecimal(DataTypeParser.Parse(row["RSPrice"], typeof(decimal), 0)),
                            Qty = (int)DataTypeParser.Parse(row["Qty"], typeof(int), -1),
                            Amount = Convert.ToDecimal(DataTypeParser.Parse(row["Amount"], typeof(decimal), 0)),
                            Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), string.Empty),
                        };                        
                        // Add it into list                        
                        orderDetails.Add(newOrderDetail);
                    }
                    // Save into db
                    if (orderDetails.Count > 0)
                    {
                        affectedRows = orderDetailSaver.Add(orderDetails);
                        // Check validation
                        if (!orderDetailSaver.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(orderDetailSaver.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                this.Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }
                    
                    // Update Order Detail (detail)
                    orderDetails.Clear();
                    DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                    foreach (DataRow row in dvUpdate.ToTable().Rows)
                    {
                        OrderDetail mdOrderDetail = new OrderDetail()
                        {
                            ID = (int)DataTypeParser.Parse(row["OrderDetailID"], typeof(int), -1),
                            OrderID = (int)DataTypeParser.Parse(_mdOrder.ID, typeof(int), -1),
                            ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                            WSPrice = Convert.ToDecimal(DataTypeParser.Parse(row["WSPrice"], typeof(decimal), 0)),
                            RSPrice = Convert.ToDecimal(DataTypeParser.Parse(row["RSPrice"], typeof(decimal), 0)),
                            Qty = (int)DataTypeParser.Parse(row["Qty"], typeof(int), -1),
                            Amount = Convert.ToDecimal(DataTypeParser.Parse(row["Amount"], typeof(decimal), 0)),
                            Remark = (string)DataTypeParser.Parse(row["Remark"], typeof(string), string.Empty),
                        };
                        // Add it into list                        
                        orderDetails.Add(mdOrderDetail);
                        // Update                        
                        /*
                        if (mdOrderDetail.ProductID != -1 && mdOrderDetail.Qty != 0)
                        {
                            affectedRows += orderDetailSaver.UpdateByOrderDetailID(mdOrderDetail);
                        }
                         */ 
                    }
                    // Update
                    if (orderDetails.Count > 0)
                    {
                        affectedRows = orderDetailSaver.UpdateByOrderDetailID(orderDetails);
                        // Check validation
                        if (!orderDetailSaver.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(orderDetailSaver.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                this.Text,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }
                } // END of Update an existing order and details
                if (affectedRows.HasValue && affectedRows.Value > 0)
                {
                    // If a caller exist
                    if (OrderSavedHandler != null)
                    {
                        // return value to sender
                        OrderSaveEventArgs orderSavedArg = new OrderSaveEventArgs(_mdOrder.ID, true);
                        OrderSavedHandler(this, orderSavedArg);
                    }
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    this.Close();
                }
                else
                    MessageBox.Show(Resource.errFailedToSave, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(e);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        private void DeleteOrderDetail(int orderDetailID)
        {            
            try
            {                
                // delete an order detail
                int affectedRows = new OrderDetailBL().DeleteByOrderDetailID(orderDetailID);
                if (affectedRows > 0)
                {
                    dgvOrderDetail.Rows.RemoveAt(dgvOrderDetail.CurrentRow.Index);
                    //If there is no row, add an empty new row
                    if (dgvOrderDetail.Rows.Count < 1)
                        AddInitialNewRow();
                    // Show successful msg and close this
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(e);
            }            
        }

        private void AddInitialNewRow()
        {
            DataTable dt = dgvOrderDetail.DataSource as DataTable;
            if (dgvOrderDetail.Rows.Count == 0)
            {
                DataRow newRow = dt.NewRow();
                dt.Rows.Add(newRow);
            }
        }

        /***** Validation *****/
        private bool checkRequiredData()
        {
            bool chck = false;                        
            if (cmbCustomer.SelectedValue != null && cmbReceiver.SelectedValue != null
                && txtTotalAmount.Text != "")
                chck = true;

            return chck;
        }
        /***** End of Vallidation *****/

        private decimal CalculateTotalAmount(DataGridView gv)
        {
            decimal summaryAmt = 0;
            if (gv == null || gv.DataSource == null)
                return summaryAmt;

            DataView dvCurrent = new DataView((gv.DataSource as DataTable), string.Empty, string.Empty, DataViewRowState.CurrentRows);
            foreach (DataRow row in dvCurrent.ToTable().Rows)
            {
                //if (row.RowState != DataRowState.Deleted && row.RowState != DataRowState.Detached)
                summaryAmt += (int)DataTypeParser.Parse(row["Amount"], typeof(int), 0);
            }            
            return summaryAmt;
        }

        private void LoadExistingOrder(int? orderID)
        {
            InitializeComponentAndData();
            // Load necessary data
            LoadNBind();
            LoadNBindByOrderID(orderID);
            // Add initial new row if there is now row
            AddInitialNewRow();
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for a direct new order when it is not part of other form.
        /// </summary>
        public frmOrder()
        {
            InitializeComponent();
            // Disable auto generating columns
            dgvOrderDetail.AutoGenerateColumns = false;
            // Instantiate Order not assign yet
            if (_mdOrder == null)
                _mdOrder = new Entities.Order();
            // Load necessary data
            LoadNBind();
            // Load table scheme
            LoadNBindByOrderID(null);
            // Add a new row
            AddInitialNewRow();

            dgvOrderDetail.CausesValidation = true;
        }


        public frmOrder(int customerId,int townId)
        {
            InitializeComponent();
            // Disable auto generating columns
            dgvOrderDetail.AutoGenerateColumns = false;
            // Instantiate Order not assign yet
            if (_mdOrder == null)
                _mdOrder = new Entities.Order();
            // Load necessary data
            LoadNBind();
            // Load table scheme
            LoadNBindByOrderID(null);
            // Add a new row
            AddInitialNewRow();

            dgvOrderDetail.CausesValidation = true;
            cmbTown.SelectedValue = townId;
            cmbCustomer.SelectedValue = customerId;

            cmbCustomer.Enabled = false;
            cmbTown.Enabled = false;
            btnAddNewCustomer.Enabled = false;


        }
                
        /// <summary>
        /// Constructor for an existing order when it is part of other form
        /// </summary>
        /// <param name="orderID"></param>
        public frmOrder(int? orderID)
        {
            LoadExistingOrder(orderID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="cusID"></param>
        public frmOrder(int? orderID, int? cusID, Township township)
        {
            LoadExistingOrder(orderID);

            if (!orderID.HasValue && township != null)
            {
                this.cmbTown.SelectedValue = (int)DataTypeParser.Parse(township.TownID, typeof(int), -1);
                this.cmbCustomer.SelectedValue = (int)DataTypeParser.Parse(cusID, typeof(int), -1);
            }
            // Disable town combo and customer combo
            this.cmbTown.Enabled = this.cmbCustomer.Enabled = false;
            this.btnAddNewCustomer.Enabled = false;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mdOrder"></param>
        /// <param name="townID"></param>
        /// <param name="mdOrderDetails"></param>
        public frmOrder(Entities.Order mdOrder, int townID, DataTable mdOrderDetails)
        {
            InitializeComponentAndData();
            LoadNBindOrderAndDetails(mdOrder, townID, mdOrderDetails);
            // Add initial new row if there is now row
            AddInitialNewRow();
            // Set total amount
            txtTotalAmount.Text = (string)DataTypeParser.Parse(CalculateTotalAmount(dgvOrderDetail), typeof(string), "0");
        }                

        #endregion

        #region Inner Class
        public class OrderSaveEventArgs : EventArgs
        {
            private int? _orderID = null;
            private bool _occuredChanges;
            public OrderSaveEventArgs(int? orderID, bool occuredChanges)
            {
                this._orderID = orderID;
                this._occuredChanges = occuredChanges;
            }            
            public int? OrderID
            {
                get { return this._orderID; }
            }
            public bool OccuredChanges 
            {
                get { return this._occuredChanges; }
            }
        }
        #endregion                
    }
}

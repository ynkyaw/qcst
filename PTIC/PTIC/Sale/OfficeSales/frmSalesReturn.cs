using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using PTIC.Common;
using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using PTIC.Sale.DA;
using PTIC.Util;
using PTIC.Sale.Entities;
using PTIC.VC.Sale.Inventory;

namespace PTIC.VC.Sale.OfficeSales
{
    public partial class frmSalesReturn : Form
    {
        /// <summary>
        /// Record table for different Product
        /// </summary>
        /// 

        bool _isAfterSave = false;

        private DataTable _dtProduct = null;

        /// <summary>
        /// Index of SaleInvoiceNo column from DataGridView
        /// </summary>
        private int _indexInvoiceNoColumn = -1;

        ///<summary></summary>
        ///Index of Product column from DataGridView
        ///
        private int _indexProductColumn = -1;

        /// <summary>
        /// ComboBox of InvoiceNo from DataGridView
        /// </summary>
        private ComboBox _cmbInvoiceNo = null;

        /// <summary>
        /// ComboBox of Product from DataGridView
        /// </summary>
        private ComboBox _cmbProduct = null;

        /// <summary>
        /// DataTable for Ven
        /// </summary>
        private DataTable dtVen = null;

        /// <summary>
        /// DataTable for SubStore
        /// </summary>
        private DataTable dtSubStore = null;

        /// <summary>
        /// SaleReturnIn Entities
        /// </summary>
        public SaleReturnIn saleReturnIn = new SaleReturnIn();

        int? VenID = 0;
        int? WarehouseID = 0;

        int tmp = 0;

        public frmSalesReturn()
        {
            InitializeComponent();
            this._indexInvoiceNoColumn = dgvSalesReturn.Columns.IndexOf(dgvSalesReturn.Columns["colInvoiceNo"]);
            this._indexProductColumn = dgvSalesReturn.Columns.IndexOf(dgvSalesReturn.Columns["colProduct"]);

            // Auto-Generate Columns False
            dgvSalesReturn.AutoGenerateColumns = false;
            //dgvSalesReturn.DataSource = new PaymentBL().GetSalesReturn(0, 0);        
            dtpReturnDate.Value = DateTime.Now;
            LoadNBind();
            LoadNBindSalesReturn((int)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), 0), (DateTime)DataTypeParser.Parse(dtpReturnDate.Value, typeof(DateTime), DateTime.Now));
            rdoVenNo.Checked = true;
            DataUtil.AddInitialNewRow(dgvSalesReturn);
        }

        #region Private Methods
        public void LoadNBind()
        {
            try
            {
                // Load Vehicles
                dtVen = new VehicleBL().GetAll();
                //  Load SubStore
                dtSubStore = new WarehouseBL().GetAllSubStore();
                // Bind SalePerson
                txtSalesPersonName.Text = GlobalCache.LoginUser.EmpName;

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
            }
            catch (SqlException Sqle)
            {
                // ToastMessageBox.Show(Resource.errFailedToSave);  // To do
            }
        }

        public void LoadNBindSalesReturn(int CustomerID, DateTime SaleReturnDate)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                if (CustomerID == 0) return;
                DataTable dtSaleReturnIn = new SaleReturnInBL().GetSaleReturnInByDate(dtpReturnDate.Value, CustomerID);
                DataTable dtDebtors = new PaymentBL().GetDebtorsList(CustomerID);
                DataTable dtSaleInvoice = PaymentDA.SelectDebtorsListByQuery(CustomerID);
                this._dtProduct = new PaymentBL().GetSalesDetail();

                //if (dtSaleReturnIn.Rows.Count > 0)
                //{
                //    dgvSalesReturn.DataSource = dtSaleReturnIn;
                //}
                //else
                //if
                //{
                dgvSalesReturn.DataSource = new PaymentBL().GetSalesReturn(0, 0);
                DataUtil.AddInitialNewRow(dgvSalesReturn);
                // }

                if (dtSaleInvoice.Rows.Count < 1)
                {
                    colInvoiceNo.DataSource = dtSaleInvoice;
                    colInvoiceNo.DisplayMember = "InvoiceNo";
                    colInvoiceNo.ValueMember = "InvoiceID";

                }
                else
                {
                    colInvoiceNo.DataSource = dtSaleInvoice;
                    colInvoiceNo.DisplayMember = "InvoiceNo";
                    colInvoiceNo.ValueMember = "InvoiceID";
                }


                colProduct.DataSource = this._dtProduct;
                colProduct.DisplayMember = "ProductName";
                colProduct.ValueMember = "ProductID";


                //dgvSalesReturn.CurrentRow.Cells[colSalesDetailsID.Index].Value = (int)DataTypeParser.Parse(dtSaleInvoice.Rows[0]["SalesDetailID"], typeof(int), 0);


                if (dtDebtors.Rows.Count == 0)
                {
                    txtRouteTrip.Text = "";
                    colInvoiceNo.DataSource = dtSaleInvoice;
                    return;
                }
                string RouteName = (string)DataTypeParser.Parse(dtDebtors.Rows[0]["RouteName"], typeof(string), null);
                string TripName = (string)DataTypeParser.Parse(dtDebtors.Rows[0]["TripName"], typeof(string), null);

                if (RouteName == null)
                {
                    txtRouteTrip.Text = TripName;
                }
                else
                {
                    txtRouteTrip.Text = RouteName;
                }

            }
            catch (SqlException Sqle)
            {
                //ToastMessageBox.Show(Resource.errFailedToSave);  // To do
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CustomerID = (int)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), -1);
            DateTime SaleReturnDate = (DateTime)DataTypeParser.Parse(dtpReturnDate.Value, typeof(DateTime), DateTime.Now);
            LoadNBindSalesReturn(CustomerID, SaleReturnDate);
        }

        private void dgvSalesReturn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvSalesReturn_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Register an event to filter displaying value of Customer Type column
            if (dgvSalesReturn.CurrentRow != null && dgvSalesReturn.CurrentCell.ColumnIndex == _indexProductColumn)
            {
                _cmbProduct = e.Control as ComboBox;
                if (_cmbProduct != null)
                {
                    _cmbProduct.DropDown += new EventHandler(cmbProduct_DropDown);
                }
            }
        }

        private void cmbProduct_DropDown(object sender, EventArgs e)
        {
            object t = dgvSalesReturn.CurrentRow.Cells[0].Value;
            int InvoiceID = (int)DataTypeParser.Parse(dgvSalesReturn.CurrentRow.Cells[_indexInvoiceNoColumn].Value, typeof(int), 0);
            if (InvoiceID < 1)
                return;
            DataTable dtResultProducts = DataUtil.GetDataTableBy(this._dtProduct, "InvoiceID", InvoiceID);
            _cmbProduct.DataSource = dtResultProducts;
        }

        private void dgvSalesReturn_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_cmbProduct != null)
            {
                _cmbProduct.DropDown -= new EventHandler(cmbProduct_DropDown);
            }
        }

        private void frmSalesReturn_Load(object sender, EventArgs e)
        {

        }

        private void dgvSalesReturn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (sender is DataGridView && (e.ColumnIndex == _indexProductColumn))
            {
                DataGridView dgv = (DataGridView)sender;
                if (dgvSalesReturn.Equals(dgv))
                {
                    SqlConnection conn = null;
                    DataTable dt = null;

                    try
                    {
                        conn = DBManager.GetInstance().GetDbConnection();
                        int InvoiceID = (int)DataTypeParser.Parse(dgvSalesReturn.CurrentRow.Cells[_indexInvoiceNoColumn].Value.ToString(), typeof(int), -1);
                        int ProductID = (int)DataTypeParser.Parse(dgvSalesReturn.CurrentRow.Cells[_indexProductColumn].Value.ToString(), typeof(int), -1);
                        dt = new PaymentBL().GetSalesReturn(InvoiceID, ProductID);

                        foreach (DataRow row in dt.Rows)
                        {
                            dgvSalesReturn[colPrice.Index, dgvSalesReturn.CurrentRow.Index].Value = row["SalePrice"].ToString();
                            dgvSalesReturn[colQty.Index, dgvSalesReturn.CurrentRow.Index].Value = row["Qty"].ToString();
                            dgvSalesReturn[colSalesDetailsID.Index, dgvSalesReturn.CurrentRow.Index].Value = row["SalesDetailID"].ToString();
                        }

                    }
                    catch (SqlException Sqle)
                    {
                    }
                    finally
                    {
                        DBManager.GetInstance().CloseDbConnection();
                    }

                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvSalesReturn.CurrentCell.ColumnIndex;
                int iRow = dgvSalesReturn.CurrentCell.RowIndex;
                if (iColumn == dgvSalesReturn.Columns[colRemark.Index].Index)
                {
                    if (iRow + 1 >= dgvSalesReturn.Rows.Count)
                    {
                        DataTable dt = dgvSalesReturn.DataSource as DataTable;
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        this.dgvSalesReturn.DataSource = dt;
                        dgvSalesReturn[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvSalesReturn.CurrentCell = dgvSalesReturn[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvSalesReturn.CurrentCell = dgvSalesReturn[iColumn + 1, iRow];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvSalesReturn.Rows[dgvSalesReturn.CurrentRow.Index].ErrorText != String.Empty)
                MessageBox.Show(Resource.errFailedToSave);
            else
                Save();
        }

        private void Save()
        {

            if (rdoVenNo.Checked == true)
            {
                VenID = (int?)DataTypeParser.Parse(cmbWarehouseORVen.SelectedValue, typeof(int), null);
            }
            else
            {
                WarehouseID = (int?)DataTypeParser.Parse(cmbWarehouseORVen.SelectedValue, typeof(int), null);
            }

            DataTable dt = dgvSalesReturn.DataSource as DataTable;
            SqlConnection conn = null;
            int sup = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);

                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    saleReturnIn.SaleDetailID = (int)DataTypeParser.Parse(row["SalesDetailID"], typeof(int), 0);
                    saleReturnIn.ProuductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), 0);
                    saleReturnIn.Date = (DateTime)DataTypeParser.Parse(dtpReturnDate.Value, typeof(DateTime), DateTime.Now);
                    saleReturnIn.SalePersonID = (int)DataTypeParser.Parse(GlobalCache.LoginUser.EmpID, typeof(int), 0);
                    saleReturnIn.Qty = (int)DataTypeParser.Parse(row["Qty"], typeof(int), 0);
                    //  saleReturnIn.Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), null);
                    saleReturnIn.Remark = String.Empty;

                    SaleDetail salesDetail = new SaleDetail();
                    salesDetail.InvoiceID = (int)DataTypeParser.Parse(row["InvoiceID"], typeof(int), -1);
                    salesDetail.SalePrice = (decimal)DataTypeParser.Parse(row["SalePrice"], typeof(decimal), 0);

                    if (saleReturnIn.SaleDetailID != 0 && saleReturnIn.ProuductID != 0 && saleReturnIn.SalePersonID != 0 && saleReturnIn.Qty != 0)
                    {
                        sup = new SaleReturnInBL().Insert(saleReturnIn, salesDetail, VenID, WarehouseID);
                    }
                }

                //// delete
                //DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                //foreach (DataRow row in dvDelete.ToTable().Rows)
                //{
                //    bank.BankID = (int)DataTypeParser.Parse(row["BankID"].ToString(), typeof(int), -1);
                //    sup = new BankBL().Delete(bank, conn);
                //}

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    saleReturnIn.SalesReturnInID = (int)DataTypeParser.Parse(row["SalesReturnInID"].ToString(), typeof(int), 0);
                    saleReturnIn.SaleDetailID = (int)DataTypeParser.Parse(row["SalesDetailID"].ToString(), typeof(int), 0);
                    saleReturnIn.ProuductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), 0);
                    saleReturnIn.Date = (DateTime)DataTypeParser.Parse(dtpReturnDate.Value, typeof(DateTime), DateTime.Now);
                    saleReturnIn.SalePersonID = (int)DataTypeParser.Parse(GlobalCache.LoginUser.EmpID, typeof(int), 0);
                    saleReturnIn.Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), 0);
                    //  saleReturnIn.Remark = (string)DataTypeParser.Parse(row["Remark"].ToString(), typeof(string), null);
                    saleReturnIn.Remark = String.Empty;
                    if (saleReturnIn.SaleDetailID != 0 && saleReturnIn.ProuductID != 0 && saleReturnIn.SalePersonID != 0 && saleReturnIn.Qty != 0)
                    {
                        sup = new SaleReturnInBL().UpdateBySalesReturnInID(saleReturnIn, VenID, WarehouseID, conn);
                    }
                }

                if (sup > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved, Color.GreenYellow);
                    dgvSalesReturn.DataSource = null;
                    _isAfterSave = true;
                    LoadNBindSalesReturn((int)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), 0), (DateTime)DataTypeParser.Parse(dtpReturnDate.Value, typeof(DateTime), DateTime.Now));
                    LoadNBind();
                    _isAfterSave = false;
                }
            }
            catch (SqlException Sqle)
            {
                throw Sqle;
            }
        }

        private void dgvSalesReturn_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;
            int Qtyleft = 0;
            decimal TotalAmount = 0;
            int SelectedInvoiceID = (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colInvoiceID.Index].Value, typeof(int), -1);
            DataTable dtBalanceAmount = new SaleReturnInBL().GetBalanceAmountToReturn(SelectedInvoiceID);

            if (!_isAfterSave)
            {
                if (e.ColumnIndex == colProduct.Index || e.ColumnIndex == colQty.Index)
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Index != e.RowIndex & !row.IsNewRow)
                        {
                            if (row.Cells["colProduct"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
                            if (row.Cells["colProduct"].FormattedValue.ToString() == e.FormattedValue.ToString() && row.Cells[colInvoiceID.Index].FormattedValue.ToString() == dgv.CurrentRow.Cells[colInvoiceID.Index].FormattedValue.ToString() && row.Index != dgv.CurrentRow.Index)
                            {
                                dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
                                MessageBox.Show("Duplicate Not Allowed!");
                                // return;
                            }
                            else
                            {
                                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
                            }
                        }

                        if (row.Cells[colInvoiceID.Index].FormattedValue.ToString() == row.Cells[colInvoiceID.Index].FormattedValue.ToString())
                        {
                            TotalAmount = +(int)DataTypeParser.Parse(row.Cells[colQty.Index].Value, typeof(int), 0) * (decimal)DataTypeParser.Parse(row.Cells[colPrice.Index].Value, typeof(decimal), 0);

                        }
                    }

                    if (dtBalanceAmount.Rows.Count > 0)
                    {
                        if (TotalAmount >= (decimal)DataTypeParser.Parse(dtBalanceAmount.Rows[0]["TotalBalance"], typeof(decimal), 0))
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Wrong Amount";
                            MessageBox.Show("အကြွေးလက်ကျန်ငွေထက် ကျော်လွန်၍ Return လုပ်ခွင့်မရှိပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }


                DataTable dt = new SaleReturnInBL().GetSaleQtyToReturn((int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colSalesDetailsID.Index].Value, typeof(int), 0), (int)DataTypeParser.Parse(dgv.CurrentRow.Cells[colProduct.Index].Value, typeof(int), 0));
                if (dt.Rows.Count > 0)
                {
                    //Logic Leak Error
                    //if ((int)DataTypeParser.Parse(dt.Rows[0]["Result"], typeof(int), -1) == -1)
                    if ((int)DataTypeParser.Parse(dt.Rows[0]["Result"], typeof(int), -1) == -1)
                    {
                        Qtyleft = (int)DataTypeParser.Parse(dt.Rows[0]["SaleDetailQty"], typeof(int), 0);
                    }
                    else
                    {
                        Qtyleft = (int)DataTypeParser.Parse(dt.Rows[0]["Result"], typeof(int), 0);
                    }
                }

                if (e.ColumnIndex == dgv.CurrentRow.Cells[colQty.Index].ColumnIndex)
                {
                    int newInteger;
                    if (dgv.Rows[e.RowIndex].IsNewRow) { return; }
                    if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                    {
                        //e.Cancel = true;             
                        btnSave.Enabled = false;
                        dgv.Rows[e.RowIndex].ErrorText = "Amount must be fill";
                    }
                    if ((int)DataTypeParser.Parse(e.FormattedValue.ToString(), typeof(int), 0) > Qtyleft)
                    {
                        if (dgv.CurrentRow.Cells[colInvoiceNo.Index].Value.ToString() != string.Empty && !_isAfterSave)
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Amount is Invalid!";
                            MessageBox.Show("Amount is Invalid { " + Qtyleft + " }");
                            dgv.CurrentRow.Cells[colQty.Index].Value = Qtyleft;
                            return;
                        }
                        else
                        {
                            btnSave.Enabled = false;
                            dgv.Rows[e.RowIndex].ErrorText = "Amount is Invalid";
                        }
                    }
                    else if (!int.TryParse(e.FormattedValue.ToString(),
                            out newInteger) || newInteger < 0)
                    {
                        //e.Cancel = true;
                        btnSave.Enabled = false;
                        dgv.Rows[e.RowIndex].ErrorText = "Amount must be integer";
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        dgv.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                }
            }
           
           
        }

        private void rdoVenNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoVenNo.Checked == true)
            {
                if (dtVen.Rows.Count > 0)
                {
                    cmbWarehouseORVen.DataSource = dtVen;
                    cmbWarehouseORVen.ValueMember = "VehicleID";
                    cmbWarehouseORVen.DisplayMember = "VenNo";
                }
            }
        }

        private void rdoShowRoom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoShowRoom.Checked == true)
            {
                if (dtSubStore.Rows.Count > 0)
                {
                    cmbWarehouseORVen.DataSource = dtSubStore;
                    cmbWarehouseORVen.ValueMember = "ID";
                    cmbWarehouseORVen.DisplayMember = "Warehouse";
                }
            }
        }

        private void dgvSalesReturn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (dgv.Rows[e.RowIndex].ErrorText == "Wrong Amount" && e.ColumnIndex == colProduct.Index)
            {
                dgv.CurrentRow.Cells[colQty.Index].Value = 0;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            else if (dgv.Rows[e.RowIndex].ErrorText == "Wrong Amount" && e.ColumnIndex == colQty.Index)
            {
                dgv.CurrentRow.Cells[colQty.Index].Value = 0;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            else if (dgv.Rows[e.RowIndex].ErrorText != String.Empty && colQty.Index == e.ColumnIndex)
            {
                // dgv.CurrentRow.Cells[colQty.Index].Value = tmp;
                dgv.CurrentRow.Cells[colQty.Index].Value = 0;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            else if (dgv.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colProduct.Index)
            {
                dgv.CurrentRow.Cells[colProduct.Index].Value = -1;
                dgv.CurrentRow.Cells[colQty.Index].Value = 0;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
        }

        private void lblSalePage_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmInventoryStorePage));
            this.Close();
        }

        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            int CustomerID = (int)DataTypeParser.Parse(cmbCustomer.SelectedValue, typeof(int), -1);
            DateTime SaleReturnDate = (DateTime)DataTypeParser.Parse(dtpReturnDate.Value, typeof(DateTime), DateTime.Now);
            LoadNBindSalesReturn(CustomerID, SaleReturnDate);
        }

        private void dgvSalesReturn_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void dgvSalesReturn_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvSalesReturn.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvSalesReturn.CurrentRow;
            if (selectedRow == null)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            else if (dgvSalesReturn.Rows.Count <= 1)
            {
                return;
            }

            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.No)
                return;

            DataRowState selectedRowState = (selectedRow.DataBoundItem as DataRowView).Row.RowState;
            dgvSalesReturn.Rows.RemoveAt(selectedRow.Index);
            return;
        }


    }
}

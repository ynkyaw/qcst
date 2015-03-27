using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.BL;
using PTIC.VC.Sale.OfficeSales;
using log4net;
using log4net.Config;
using PTIC.Util;
using PTIC.Common.TableType;
using PTIC.VC.Util;
using PTIC.VC.Sale.Inventory;

namespace PTIC.Sale.OfficeSales
{
    public partial class frmVenReturn : Form
    {
        /// <summary>
        /// Logger for frmVenReturn
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmVenReturn));

        #region Events
        private void lblSalePage_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmInventoryStorePage));
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (dgvVenReturn.CurrentCell == null)
                return true;
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvVenReturn.CurrentCell.ColumnIndex;
                int iRow = dgvVenReturn.CurrentCell.RowIndex;
                //if (iColumn == dgvVenReturn.Columns["colRemark"].Index)
                if (iColumn == colRemark.Index)
                {
                    if (iRow + 1 >= dgvVenReturn.Rows.Count)
                    {
                        DataTable dt = dgvVenReturn.DataSource as DataTable;
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        this.dgvVenReturn.DataSource = dt;
                        dgvVenReturn[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        try
                        {
                            dgvVenReturn.CurrentCell = dgvVenReturn[0, iRow + 1];
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
                        dgvVenReturn.CurrentCell = dgvVenReturn[iColumn + 1, iRow];
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
            DataTable dtVanReturn = dgvVenReturn.DataSource as DataTable;
            if (dtVanReturn == null) return;

            foreach (DataGridViewRow row in dgvVenReturn.Rows)
            {
                int ProductID = (int)DataTypeParser.Parse(dgvVenReturn.Rows[row.Index].Cells[colProduct.Index].Value, typeof(int), -1);
                int Qty = (int)DataTypeParser.Parse(dgvVenReturn.Rows[row.Index].Cells[colQty.Index].Value, typeof(int), -1);
                //  Checing Stock In hand or Not in Vehicle
                int VenID = (int)DataTypeParser.Parse(cmbVehicle.SelectedValue, typeof(int), -1);
                DataTable dtStockInVehicle = new DeliveryBL().GetStockInVehicle(VenID, ProductID);

                if (dtStockInVehicle.Rows.Count <= 0)
                {
                    MessageBox.Show("ကားပေါ်တွင်လက်ကျန်မရှိပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (Qty > (int)DataTypeParser.Parse(dtStockInVehicle.Rows[0]["Qty"], typeof(int), -1))
                {
                    MessageBox.Show("လက်ကျန်မလုံလောက်ပါ။ ယခုကားပေါ်တွင် '" + (string)DataTypeParser.Parse(dtStockInVehicle.Rows[0]["ProductName"], typeof(string), string.Empty) + " ' လက်ကျန် : " + (int)DataTypeParser.Parse(dtStockInVehicle.Rows[0]["Qty"], typeof(int), -1), "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVenReturn.CurrentRow.IsNewRow || dgvVenReturn.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;

            DataGridViewRow selectedRow = dgvVenReturn.CurrentRow;
            if (selectedRow != null && (selectedRow.DataBoundItem as DataRowView).Row.RowState == DataRowState.Added)
            {
                // Delete row just from GridView because it is a new row that has not been in Database
                dgvVenReturn.Rows.RemoveAt(selectedRow.Index);
                // Add initial new row because there is no more row
                AddInitialNewRow();
                return;
            }

            int productID = (int)DataTypeParser.Parse(selectedRow.Cells["colProduct"].Value, typeof(int), -1);
            if (productID == -1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete, Color.Red);
            }
            else
            {
                // delete a selected record from db
                DeleteVenReturnRow(productID);
            }
        }

        private void dgvVenReturn_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == colProduct.Index)
            {
                foreach (DataGridViewRow row in dgvVenReturn.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells["colProduct"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
                        if (row.Cells["colProduct"].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgvVenReturn.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
                            MessageBox.Show("Duplicate not Allowed!");
                        }
                    }
                }
            }
            else if (e.ColumnIndex == colQty.Index)
            {
                int newInteger;
                if (dgvVenReturn.Rows[e.RowIndex].IsNewRow)
                    return;
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dgvVenReturn.Rows[e.RowIndex].ErrorText = "Quantity cannot be empty!";
                    MessageBox.Show(Resource.errMustFillQty);
                }
                else if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger < 1)
                {
                    dgvVenReturn.Rows[e.RowIndex].ErrorText = "Quantity must be greater than zero!";
                    dgvVenReturn.CurrentRow.Cells[colQty.Index].Value = 1;
                    MessageBox.Show(Resource.errQtyMustBeInt);
                }
            }
        }

        private void dgvVenReturn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(dgvVenReturn.Rows[e.RowIndex].ErrorText) || dgvVenReturn.CurrentRow == null) // if there is no error
                return;
            if (e.ColumnIndex == colProduct.Index && dgvVenReturn.Rows[e.RowIndex].ErrorText !=String.Empty)
            {
                dgvVenReturn.CurrentRow.Cells[colProduct.Index].Value = -1;
                dgvVenReturn.CurrentRow.Cells[colQty.Index].Value = String.Empty;
                dgvVenReturn.CurrentRow.Cells[colRemark.Index].Value = String.Empty;
                dgvVenReturn.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            else if (e.ColumnIndex == colQty.Index && dgvVenReturn.Rows[e.RowIndex].ErrorText != String.Empty)
            {
                dgvVenReturn.CurrentRow.Cells[colQty.Index].Value = 1;
                dgvVenReturn.Rows[e.RowIndex].ErrorText = String.Empty;
            }
        }

        private void dgvVenReturn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // TODO: handle data error
        }
        #endregion

        #region Private Methods
        private void LoadNBindNecessaryData()
        {            
            try
            {                
                // Bind ShowRooms
                cmbShowroom.DataSource = new WarehouseBL().GetAllSubStore();
                // Bind Vehicles
                cmbVehicle.DataSource = new VehicleBL().GetAll();
                // Bind Product
                colProduct.ValueMember = "ProductID";
                colProduct.DisplayMember = "ProductName";
                colProduct.DataSource = new ProductBL().GetAll();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                ToastMessageBox.Show(Resource.FailedToLoadData, Color.Red);
            }            
        }

        private void Save()
        { 
            SqlConnection conn = null;
            int affectedRows = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                List<StockTableType> newStocks = new List<StockTableType>();
                int warehouseId = (int)cmbShowroom.SelectedValue; 
                int vehicleID = (int)cmbVehicle.SelectedValue;
                foreach (DataGridViewRow row in dgvVenReturn.Rows)
                {
                    if (row.IsNewRow)
                        break;
                    StockTableType newStock = new StockTableType() 
                    {                        
                        ProductID = (int)DataTypeParser.Parse(row.Cells[colProduct.Index].Value, typeof(int), -1),
                        PlaceID = warehouseId,
                        Place  = 0, // 0 = warehouse, 1 = vehicle
                        SalePersonID = (int)DataTypeParser.Parse(cboSalesPerson.SelectedValue, typeof(int), 0),
                        // If Place is warehouse, 0 = Factory, 1 = Warehouse, 2 = Vehicle, 3 = CustomerOrSale, 4 = Opening.
                        // Else if vehicle, 0 = Warehouse, 1 = CustomerOrSale, 2 = Service.
                        StockBy  = 0,
                        Qty = (int)DataTypeParser.Parse(row.Cells[colQty.Index].Value, typeof(int), 0),
                        Date  = (DateTime)DataTypeParser.Parse(dtpReturnDate.Value, typeof(DateTime), DateTime.Now),
                        Remark = (string)DataTypeParser.Parse(row.Cells[colRemark.Index].Value, typeof(string), null),
                    };
                    // Add into stock list
                    newStocks.Add(newStock);
                }

                affectedRows = new VehicleBL().VenReturn(newStocks, vehicleID, conn);
                if (affectedRows > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    this.Close();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            catch (SqlException Sqle)
            {
                _logger.Error(Sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void DeleteVenReturnRow(int productID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                //int affectedRows = new OrderDetailBL().DeleteByOrderDetailID(orderDetailID, conn);
                // TODO: Delete ven return record from database
                int affectedRows = 0;
                if (affectedRows > 0)
                {
                    dgvVenReturn.Rows.RemoveAt(dgvVenReturn.CurrentRow.Index);
                    //If there is no row, add an empty new row
                    if (dgvVenReturn.Rows.Count < 1)
                        AddInitialNewRow();
                    // Show successful msg and close this
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
            }
            catch (SqlException sql)
            {
                _logger.Error(sql);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void AddInitialNewRow()
        {
            DataTable dt = dgvVenReturn.DataSource as DataTable;
            if (dgvVenReturn.Rows.Count == 0)
            {
                DataRow newRow = dt.NewRow();
                dt.Rows.Add(newRow);
            }
        }
        #endregion

        #region Constructors
        public frmVenReturn()
        {
            InitializeComponent();
            // Disable auto generation columns
            dgvVenReturn.AutoGenerateColumns = false;
            // Configure logger 
            XmlConfigurator.Configure();
            // Set sale person name
            if (GlobalCache.LoginUser != null)
                txtSalesPersonName.Text = GlobalCache.LoginUser.EmpName;
            // Load and bind warhouses and vehicles
            LoadNBindNecessaryData();
            // Bind empty DataTable with defined schema to GridView
            DataTable dtEmpty = new DataTable("VenReturnTable");            
            dtEmpty.Columns.Add("ProductID", typeof(int));
            dtEmpty.Columns.Add("Qty", typeof(int));            
            dtEmpty.Columns.Add("Remark", typeof(string));
            dgvVenReturn.DataSource = dtEmpty;
            DataUtil.AddInitialNewRow(dgvVenReturn);


            // NewlyAdded Code
            cboSalesPerson.DataSource = new PTIC.Common.BL.EmployeeBL().GetEmployeeFromMarketingAndSale();
            cboSalesPerson.DisplayMember = "EmpName";
            cboSalesPerson.ValueMember = "EmployeeID";


        }
        #endregion

        private void dgvVenReturn_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null)return;
            foreach(DataGridViewRow row in dgv.Rows)
            {
                dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
                        
    }
}

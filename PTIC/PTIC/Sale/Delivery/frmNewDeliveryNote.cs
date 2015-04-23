using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.BL;
using PTIC.Util;
using PTIC.Common.BL;
using PTIC.VC.Util;
using PTIC.VC;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Common;
using PTIC.Sale.DA;

namespace PTIC.Sale.Delivery
{
    public partial class frmNewDeliveryNote : Form
    {
        /// <summary>
        /// Record table for different Proudcts
        /// </summary>
        private DataTable _dtProduct = null;

        /// <summary>
        /// Index of Brand column from DataGridView
        /// </summary>
        private int _indexBrandColumn = -1;

        /// <summary>
        /// Index of Product column from DataGridView
        /// </summary>
        private int _indexProductColumn = -1;

        /// <summary>
        /// ComboBox shown in grid column Product
        /// </summary>
        private ComboBox _cmbProduct = null;

        DataTable deliveryListFromDeliveryPlan;

        public frmNewDeliveryNote()
        {
            InitializeComponent();
            this._indexBrandColumn = dgvDeliveryNote.Columns.IndexOf(dgvDeliveryNote.Columns["clnBrandName"]);
            this._indexProductColumn = dgvDeliveryNote.Columns.IndexOf(dgvDeliveryNote.Columns["clnProductName"]);
            LoadNBind();
            if (dgvDeliveryNote == null) return;
            DataUtil.AddInitialNewRow(dgvDeliveryNote);
        }

        #region Private Methods
        private void LoadNBind()
        {
            try
            {
                // Load Brand
                clnBrandName.DataSource = new BrandBL().GetOwnBrands();
                // Load Product
                clnProductName.DataSource = this._dtProduct = new ProductBL().GetAll();
                // Set binding fields
                clnBrandName.DisplayMember = "BrandName";
                clnBrandName.ValueMember = "BrandID";

                clnProductName.DisplayMember = "ProductName";
                clnProductName.ValueMember = "ProductID";

                deliveryListFromDeliveryPlan = DeliveryDA.SelectDeliveryProductList();

                // Load employees
                cmbEmp.DataSource = DataUtil.GetDataTableBy(new EmployeeBL().GetAll(), "DeptID",
                    (int)PTIC.Common.Enum.PredefinedDepartment.Sales);

                // Load vehicles
                DataTable dtVehicle = new VehicleBL().GetAll();
                cmbRealVen.DataSource = dtVehicle;
                // cmbVenNo.DataSource = dtVehicle;

                dgvDeliveryNote.AutoGenerateColumns = false;
                dgvDeliveryNote.DataSource = new DeliveryNoteBL().GetDeliveryNoteDetail(0);

            }
            catch (Exception e)
            {
                // TODO: handle exception
            }
        }

        private void Save()
        {
            DeliveryNote deliverynote = null;
            int? affectedrow = 0;
            try
            {
                DataTable dtWarehouse = new WarehouseDA().SelectSubtore();
                int warehouseID = (int)DataTypeParser.Parse(dtWarehouse.Rows[0]["WarehouseID"], typeof(int), 0);

                deliverynote = new DeliveryNote()
                {
                    Date = (DateTime)DataTypeParser.Parse(dtpDeliveryDisplay.Value, typeof(DateTime), DateTime.Now),
                    VenID = (int?)DataTypeParser.Parse(cmbRealVen.SelectedValue, typeof(int), null),
                    EmpID = (int)DataTypeParser.Parse(cmbEmp.SelectedValue, typeof(int), -1),
                    //WareHouseID = (int)DataTypeParser.Parse(cmbShowRoom.SelectedValue, typeof(int), -1)
                };

                // Add new deliverynote detail
                DataTable dtDeliveryNoteTbl = dgvDeliveryNote.DataSource as DataTable;
                List<DeliveryNoteDetail> newDeliveryNoteDetailRecords = new List<DeliveryNoteDetail>();
                foreach (DataRow row in dtDeliveryNoteTbl.Rows)
                {
                    //if (row.IsNewRow)
                    //    break;
                    DeliveryNoteDetail newDeliveryNoteDetailRecord = new DeliveryNoteDetail()
                    {
                        ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                        DeliveryQty = (int)DataTypeParser.Parse(row["DeliveryQty"].ToString(), typeof(int), 0),
                        WareHouseQty = (int)DataTypeParser.Parse(row["ShowRoomQty"].ToString(), typeof(int), 0),
                        ExtraQty = (int)DataTypeParser.Parse(row["ExtraQty"].ToString(), typeof(int), 0)
                    };
                    if (newDeliveryNoteDetailRecord.DeliveryQty != -1 || newDeliveryNoteDetailRecord.ExtraQty != -1 && newDeliveryNoteDetailRecord.ProductID != -1)
                    {
                        if ((newDeliveryNoteDetailRecord.DeliveryQty + newDeliveryNoteDetailRecord.ExtraQty) <= 0)
                        {
                            MessageBox.Show("အရေအတွက် '၀' မဖြစ်ရပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        // add into List
                        newDeliveryNoteDetailRecords.Add(newDeliveryNoteDetailRecord);
                    }
                }

                affectedrow = new DeliveryNoteBL().Add(deliverynote, newDeliveryNoteDetailRecords,warehouseID);

                if (affectedrow > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    this.Close();
                }
                else
                {
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                }

            }
            catch (SqlException Sqle)
            {
                // To do
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion


        #region Events
      
        private void dgvDeliveryNote_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var gv = sender as DataGridView;
            string curColumName = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
            DataGridViewRow curRow = gv.Rows[e.RowIndex];
            if (curColumName.Equals("clnOrder") || curColumName.Equals("clnShowRoom") || curColumName.Equals("clnExtra"))
            {
                int order = (int)DataTypeParser.Parse(curRow.Cells["clnOrder"].Value, typeof(int), 0);
                //int ShowRoom = (int)DataTypeParser.Parse(curRow.Cells["clnShowRoom"].Value, typeof(int), 0);
                int Extra = (int)DataTypeParser.Parse(curRow.Cells["clnExtra"].Value, typeof(int), 0);
                int _tmpAmount = 0;
                for (int i = clnOrder.Index; i < clnAmount.Index; i++)
                {
                    _tmpAmount += (int)DataTypeParser.Parse(dgvDeliveryNote.CurrentRow.Cells[i].Value, typeof(int), 0);
                }
                curRow.Cells["clnAmount"].Value = _tmpAmount;

            }
            int totalAmt = 0;
            //DataTable dt = dgvDeliveryNote.DataSource as DataTable;
            foreach (DataGridViewRow row in dgvDeliveryNote.Rows)
            {
                totalAmt += (int)DataTypeParser.Parse(dgvDeliveryNote.Rows[row.Index].Cells[clnAmount.Index].Value, typeof(int), 0);
            }
            txtTotalAmt.Text = totalAmt.ToString("N0");
        }

        private void dgvDeliveryNote_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Register an event to filter displaying value of Product column
            if (dgvDeliveryNote.CurrentRow != null && dgvDeliveryNote.CurrentCell.ColumnIndex == _indexProductColumn)
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
            int brandID = (int)DataTypeParser.Parse(dgvDeliveryNote.CurrentRow.Cells[_indexBrandColumn].Value, typeof(int), 0);
            if (brandID < 1)
                return;
            DataTable dtResultProducts = DataUtil.GetDataTableBy(this._dtProduct, "BrandID", brandID);
            _cmbProduct.DataSource = dtResultProducts;
        }

        private void dgvDeliveryNote_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_cmbProduct != null)
            {
                _cmbProduct.DropDown -= new EventHandler(cmbProduct_DropDown);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (dgvDeliveryNote.CurrentCell == null) return true;
                int iColumn = dgvDeliveryNote.CurrentCell.ColumnIndex;
                int iRow = dgvDeliveryNote.CurrentCell.RowIndex;
                if (iColumn == dgvDeliveryNote.Columns["clnAmount"].Index)
                {
                    if (iRow + 1 >= dgvDeliveryNote.Rows.Count)
                    {
                        if (dgvDeliveryNote.CurrentRow.ErrorText == String.Empty)
                        {
                            DataUtil.AddNewRow(dgvDeliveryNote.DataSource as DataTable);
                            dgvDeliveryNote[0, iRow + 1].Selected = true;
                        }
                    }
                    else
                    {
                        dgvDeliveryNote.CurrentCell = dgvDeliveryNote[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvDeliveryNote.CurrentCell = dgvDeliveryNote[dgvDeliveryNote.CurrentCell.ColumnIndex + 1, dgvDeliveryNote.CurrentCell.RowIndex];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvDeliveryNote_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //e.Cancel = true;
            if (e.ColumnIndex == clnExtra.Index)
            {
                int newInteger;
                if (dgvDeliveryNote.Rows[e.RowIndex].IsNewRow) { return; }
                if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger < 0)
                {
                    dgvDeliveryNote.CurrentRow.Cells[e.RowIndex].ErrorText = "Amount must be integer";
                    MessageBox.Show("Amount must be integer!");
                    dgvDeliveryNote.CurrentRow.Cells[e.RowIndex].ErrorText = String.Empty;
                    dgvDeliveryNote.CurrentRow.Cells[e.ColumnIndex].Value = 0;
                }
                else
                {
                    dgvDeliveryNote.CurrentCell.ErrorText = string.Empty;
                }
            }

            var dgv = sender as DataGridView;
            if (e.ColumnIndex == clnProductName.Index)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells["clnProductName"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
                        if (row.Cells[clnBrandName.Index].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;

                        if (row.Cells["clnProductName"].FormattedValue.ToString() == e.FormattedValue.ToString() && row.Cells[clnBrandName.Index].FormattedValue.ToString() == dgv.CurrentRow.Cells[clnBrandName.Index].FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed";
                            dgv.Rows[e.RowIndex].Cells[clnProductName.Index].ErrorText = "Duplicate not allowed";
                            MessageBox.Show("Duplicate Not Allowed!");
                            return;
                        }
                    }
                }
            }

        }

        private void dgvDeliveryNote_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == clnExtra.Index || e.ColumnIndex == clnAmount.Index || e.ColumnIndex == clnProductName.Index || e.ColumnIndex == clnBrandName.Index)
            {
                if (dgvDeliveryNote.CurrentCell == null) return;
                int deliverQty = (int)DataTypeParser.Parse(dgvDeliveryNote.CurrentRow.Cells[clnOrder.Index].Value.ToString(), typeof(int), 0);
                int extraQty = (int)DataTypeParser.Parse(dgvDeliveryNote.CurrentRow.Cells[clnExtra.Index].Value.ToString(), typeof(int), 0);
                int totalQty = deliverQty + extraQty;
                int productID = (int)DataTypeParser.Parse(dgvDeliveryNote.CurrentRow.Cells[clnProductName.Index].Value.ToString(), typeof(int), 0);
                string productName = (string)DataTypeParser.Parse(
                        dgvDeliveryNote.CurrentRow.Cells[clnProductName.Index].FormattedValue, typeof(string), string.Empty);
                DataTable dt = new DeliveryDetailBL().GetStockQtyByProductID(productID);
                if (dt.Rows.Count < 1) return; // Product Undefined
                int stockQty = (int)DataTypeParser.Parse(dt.Rows[0]["Qty"], typeof(int), 0);

                if (totalQty > stockQty)
                {
                    dgvDeliveryNote.Rows[e.RowIndex].ErrorText = productName + " လက်ကျန် " + stockQty + " သာရှိပါသည်။";
                    MessageBox.Show(
                        productName + " လက်ကျန် " + stockQty + " သာရှိပါသည်။",
                        this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error
                        );
                    dgvDeliveryNote.CurrentRow.Cells[e.ColumnIndex].Value = 0;
                    dgvDeliveryNote.Rows[e.RowIndex].ErrorText = String.Empty;
                }
            }

            var dgv = sender as DataGridView;
            if (dgv == null) return;

            if (dgv.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == clnProductName.Index)
            {
                dgv.CurrentRow.Cells[clnProductName.Index].Value = -1;
                dgv.Rows[e.RowIndex].Cells[clnProductName.Index].ErrorText = string.Empty;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
            }
            else if (dgv.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == clnBrandName.Index)
            {
                dgv.CurrentRow.Cells[clnBrandName.Index].Value = -1;
                dgv.Rows[e.RowIndex].ErrorText = String.Empty;
                dgv.Rows[e.RowIndex].Cells[clnProductName.Index].ErrorText = string.Empty;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDeliveryNote.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dgvDeliveryNote.SelectedRows)
                    {                        
                        dgvDeliveryNote.Rows.RemoveAt(item.Index);

                        int totalAmt = 0;
                        //DataTable dt = dgvDeliveryNote.DataSource as DataTable;
                        foreach (DataGridViewRow row in dgvDeliveryNote.Rows)
                        {
                            totalAmt += (int)DataTypeParser.Parse(dgvDeliveryNote.Rows[row.Index].Cells[clnAmount.Index].Value, typeof(int), 0);
                        }
                        txtTotalAmt.Text = totalAmt.ToString("N0");

                        ToastMessageBox.Show(Resource.errSuccessfullyDeleted);

                    }

                }
            }
            else
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete, Color.Red);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvDeliveryNote.Rows.Count > 0)
            {
                DataUtil.AddNewRow(dgvDeliveryNote.DataSource as DataTable);
            }
            else
            {
                DataUtil.AddInitialNewRow(dgvDeliveryNote);
            }
        }

        private void dgvDeliveryNote_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            Save();
        }


        #endregion

        private void dgvDeliveryNote_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int totalAmt = 0;
            //DataTable dt = dgvDeliveryNote.DataSource as DataTable;
            foreach (DataGridViewRow row in dgvDeliveryNote.Rows)
            {
                totalAmt += (int)DataTypeParser.Parse(dgvDeliveryNote.Rows[row.Index].Cells[clnAmount.Index].Value, typeof(int), 0);
            }
            txtTotalAmt.Text = totalAmt.ToString("N0");
        }

        private void btnLoadOrder_Click(object sender, EventArgs e)
        {
            if (btnLoadOrder.Text == "Load Order")
            {
                string query = string.Format("VenId={0} AND DeliveryDate=#{1}#", cmbRealVen.SelectedValue, dtpDeliveryDisplay.Value.Date);
                DataRow[] dr = deliveryListFromDeliveryPlan.Select(query);
                if (dr.Length > 0)
                {
                    DataTable gridData = dgvDeliveryNote.DataSource as DataTable;
                    gridData.Rows.Clear();
                    foreach (DataRow row in dr)
                    {
                        gridData.Rows.Add(0, 0, row["ProductID"], row["ProductName"], row["BrandName"], row["DeliverTotalQty"], 0, 0, row["DeliverTotalQty"], row["BrandId"]);
                    }
                    dgvDeliveryNote.AutoGenerateColumns = false;
                    dgvDeliveryNote.DataSource = gridData;
                    dgvDeliveryNote.Enabled = false;
                    btnLoadOrder.Text = "Reset";
                }
            }
            else 
            {
                dgvDeliveryNote.AutoGenerateColumns = false;
                dgvDeliveryNote.DataSource = new DeliveryNoteBL().GetDeliveryNoteDetail(0);
                dgvDeliveryNote.Enabled = true;
                DataUtil.AddInitialNewRow(dgvDeliveryNote);
                btnLoadOrder.Text = "Load Order";
            }
        }


    }
}

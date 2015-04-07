using System;
using System.Collections.Generic;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Sale.Entities;
using PTIC.Common.BL;
using PTIC.Sale.DA;
using PTIC.Sale.Order;
using PTIC.Sale.BL;
using PTIC.Sale.Report;
using PTIC.ReportViewer;


namespace PTIC.VC.Sale.Delivery
{
    public partial class frmDeliveryNote : Form
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

        /// <summary>
        /// DeliveryNoteID
        /// </summary>
        /// 
        int DeliveryNoteID = 0;

        // Variables for Delviery List
        int SalesPersonID = -1;
        DateTime DeliveryDate;
        int VenID = -1;
        List<PTIC.Sale.Entities.Delivery> deliveryList = null;

        bool VenFilter = false;

        public frmDeliveryNote()
        {
            InitializeComponent();
            this._indexBrandColumn = dgvDeliveryNote.Columns.IndexOf(dgvDeliveryNote.Columns["clnBrandName"]);
            this._indexProductColumn = dgvDeliveryNote.Columns.IndexOf(dgvDeliveryNote.Columns["clnProductName"]);
            // Disable auto generating columns
            dgvDeliveryNote.AutoGenerateColumns = false;

            // Create DataTable
            DataTable dtscheme = new DataTable();
            DataColumn brand = new DataColumn("BrandID", typeof(int));
            DataColumn product = new DataColumn("ProductID", typeof(int));
            DataColumn qty = new DataColumn("DeliverQty", typeof(int));
            DataColumn showroom = new DataColumn("WareHouseQty", typeof(int));
            DataColumn Extra = new DataColumn("ExtraQty", typeof(int));
            DataColumn Total = new DataColumn("TotalQty", typeof(int));
            dtscheme.Columns.AddRange(new DataColumn[] { brand, product, qty, showroom, Extra, Total });
            dgvDeliveryNote.DataSource = dtscheme;
            txtTotalAmt.Text = "";
            LoadNBind();

            DeliveryNote deliverynote = new DeliveryNote()
            {
                Date = (DateTime)DataTypeParser.Parse(dtpDeliveryDisplay.Value, typeof(DateTime), DateTime.Now),
                EmpID = (int)DataTypeParser.Parse(cmbEmpDisplay.SelectedValue, typeof(int), -1)
                //VenID = (int)DataTypeParser.Parse(cmbVenNo.SelectedValue, typeof(int), -1)
            };
            LoadNGridData(deliverynote);
        }

        public frmDeliveryNote(int SalesPersonID, DateTime DeliveryDate, int VenID, List<PTIC.Sale.Entities.Delivery> deliveryList)
        {
            InitializeComponent();
            this._indexBrandColumn = dgvDeliveryNote.Columns.IndexOf(dgvDeliveryNote.Columns["clnBrandName"]);
            this._indexProductColumn = dgvDeliveryNote.Columns.IndexOf(dgvDeliveryNote.Columns["clnProductName"]);
            this.SalesPersonID = SalesPersonID;
            this.DeliveryDate = DeliveryDate;
            this.VenID = VenID;
            this.deliveryList = deliveryList;

            // Disable auto generating columns
            dgvDeliveryNote.AutoGenerateColumns = false;

            // Create DataTable
            DataTable dtscheme = new DataTable();
            DataColumn brand = new DataColumn("BrandID", typeof(int));
            DataColumn product = new DataColumn("ProductID", typeof(int));
            DataColumn qty = new DataColumn("DeliverQty", typeof(int));
            DataColumn showroom = new DataColumn("WareHouseQty", typeof(int));
            DataColumn Extra = new DataColumn("ExtraQty", typeof(int));
            DataColumn Total = new DataColumn("TotalQty", typeof(int));
            dtscheme.Columns.AddRange(new DataColumn[] { brand, product, qty, showroom, Extra, Total });
            dgvDeliveryNote.DataSource = dtscheme;
            txtTotalAmt.Text = "";
            LoadNBind();

            cmbEmpDisplay.SelectedValue = this.SalesPersonID;
            dtpDeliveryDisplay.Value = this.DeliveryDate;
            cmbVenNo.SelectedValue = this.VenID;

            DeliveryNote deliverynote = new DeliveryNote()
            {
                Date = (DateTime)DataTypeParser.Parse(this.DeliveryDate, typeof(DateTime), DateTime.Now),
                EmpID = (int)DataTypeParser.Parse(this.SalesPersonID, typeof(int), -1),
                // VenID = (int)DataTypeParser.Parse(cmbVenNo.SelectedValue, typeof(int), -1)
            };
            LoadNGridData(deliverynote);

        }



        #region Private Method
        private void DeleteSaleDetail(int DeliveryNoteDetailID, DataGridView dgv)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // delete a selected product
                int affectedRows = new DeliveryNoteBL().DeleteByDeliveryNoteDetailID(DeliveryNoteDetailID, conn);
                if (affectedRows > 0)
                {
                    // remove row @gridvew also
                    dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
                else
                    MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException sql)
            {
                // _logger.Error(sql);
                MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void LoadNGridData(DeliveryNote deliverynote)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                txtTotalAmt.Text = "";

                //DataTable dtchkDeliveryNote = new DeliveryNoteBL().GetFromOriginByDate(deliverynote, conn);
                //if (dtchkDeliveryNote.Rows.Count > 0)
                //{
                //    //cmbShowRoom.SelectedValue = (int)DataTypeParser.Parse(dtchkDeliveryNote.Rows[0]["WareHouseID"].ToString(), typeof(int), -1);
                //    btnRequest.Enabled = false;
                //    btnAdd.Enabled = false;
                //    dgvDeliveryNote.Enabled = false;
                //    btnPrint.Enabled = true;
                //    btnDelete.Enabled = false;
                //    DeliveryNoteID = (int)DataTypeParser.Parse(dtchkDeliveryNote.Rows[0]["DeliveryNoteID"].ToString(), typeof(int), -1);
                //    DataTable dtDeliveryNoteDetail = new DeliveryNoteBL().GetDeliveryNoteDetail(DeliveryNoteID, conn);
                //    dgvDeliveryNote.DataSource = dtDeliveryNoteDetail;
                //    cmbVenNo.SelectedValue = (int)DataTypeParser.Parse(dtchkDeliveryNote.Rows[0]["VenID"], typeof(int), -1);
                //}
                //else
                //{


                if (VenFilter == false)
                {
                    DataTable dtVanInDeliveryNote = new DeliveryNoteBL().GetDeliveryNoteByDate(deliverynote);
                    cmbVenNo.DataSource = dtVanInDeliveryNote.DefaultView.ToTable(true, "VenID", "VenNo");
                    cmbVenNo.ValueMember = "VenID";
                    cmbVenNo.DisplayMember = "VenNo";
                }

                deliverynote.VenID = (int)DataTypeParser.Parse(cmbVenNo.SelectedValue, typeof(int), -1);
                DataTable dtDeliveryNote = new DeliveryNoteBL().GetDeliveryNoteByDate(deliverynote);
                if (dtDeliveryNote.Rows.Count > 0)
                {
                    btnPrint.Enabled = false;
                    btnRequest.Enabled = true;
                    dgvDeliveryNote.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnPrint.Enabled = false;
                    btnRequest.Enabled = false;
                    dgvDeliveryNote.Enabled = false;
                    btnDelete.Enabled = false;
                }

                DataColumn Extra = new DataColumn("ExtraQty", typeof(int));
                dtDeliveryNote.Columns.Add(Extra);

                DataColumn Total = new DataColumn("TotalQty", typeof(int));
                dtDeliveryNote.Columns.Add(Total);

                dgvDeliveryNote.DataSource = dtDeliveryNote;
                if (dtDeliveryNote.Rows.Count > 0)
                {
                    cmbVenNo.SelectedValue = (int)DataTypeParser.Parse(dtDeliveryNote.Rows[0]["VenID"], typeof(int), -1);
                }
                //}
                VenFilter = false;

            }
            catch (SqlException Sqle)
            {
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

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

                // Load employees
                //cmbSalePerson.DataSource = new EmployeeBL().GetAll(conn);
                cmbSalePerson.DataSource = DataUtil.GetDataTableBy(new EmployeeBL().GetAll(), "DeptID",
                    (int)PTIC.Common.Enum.PredefinedDepartment.Sales);

                cmbEmpDisplay.DataSource = DataUtil.GetDataTableBy(new EmployeeBL().GetAll(), "DeptID",
                    (int)PTIC.Common.Enum.PredefinedDepartment.Sales);

                cmbEmp.DataSource = DataUtil.GetDataTableBy(new EmployeeBL().GetAll(), "DeptID",
                    (int)PTIC.Common.Enum.PredefinedDepartment.Sales);

                // Load vehicles
                DataTable dtVehicle = new VehicleBL().GetAll();
                cmbRealVen.DataSource = dtVehicle;
               // cmbVenNo.DataSource = dtVehicle;
            }
            catch (Exception e)
            {
                // TODO: handle exception
            }
        }

        private void Save()
        {
            SqlConnection conn = null;
            DeliveryNote deliverynote = null;
            int? affectedrow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                DataTable dtWarehouse = new WarehouseDA().SelectSubtore();
                int warehouseID = (int)DataTypeParser.Parse(dtWarehouse.Rows[0]["WarehouseID"], typeof(int), 0);

                int PreVenID = (int)DataTypeParser.Parse(cmbVenNo.SelectedValue, typeof(int), -1);
                int PreEmpID = (int)DataTypeParser.Parse(cmbEmpDisplay.SelectedValue, typeof(int), -1);

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

              affectedrow = new DeliveryNoteBL().Add(deliverynote, newDeliveryNoteDetailRecords, warehouseID);

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


        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Enter)
        //    {
        //        int iColumn = dgvDeliveryNote.CurrentCell.ColumnIndex;
        //        int iRow = dgvDeliveryNote.CurrentCell.RowIndex;
        //        if (iColumn == dgvDeliveryNote.Columns.Count - 1)
        //        {
        //            if (iRow + 1 >= dgvDeliveryNote.Rows.Count)
        //            {
        //                DataTable dt = dgvDeliveryNote.DataSource as DataTable;
        //                DataRow newRow = dt.NewRow();
        //                dt.Rows.Add(newRow);
        //                this.dgvDeliveryNote.DataSource = dt;
        //                dgvDeliveryNote[0, iRow + 1].Selected = true;
        //            }
        //            else
        //            {
        //                dgvDeliveryNote.CurrentCell = dgvDeliveryNote[0, iRow + 1];
        //            }
        //        }
        //        else
        //        {
        //            dgvDeliveryNote.CurrentCell = dgvDeliveryNote[iColumn + 1, iRow];
        //        }
        //        return true;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        #endregion



        private void dtpDeliveryNoteDate_ValueChanged(object sender, EventArgs e)
        {
            //LoadNGridData();
        }

        private void cmbVenNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeliveryNote deliverynote = new DeliveryNote()
            {
                EmpID = (int)DataTypeParser.Parse(cmbEmpDisplay.SelectedValue, typeof(int), -1),
                VenID = (int)DataTypeParser.Parse(cmbVenNo.SelectedValue, typeof(int), -1),
                Date = (DateTime)DataTypeParser.Parse(dtpDeliveryDisplay.Value, typeof(DateTime), DateTime.Now)
            };
            VenFilter = true;
            LoadNGridData(deliverynote);
        }

        private void cmbSalePerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadNGridData();
        }

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

        private void btnRequest_Click(object sender, EventArgs e)
        {
            DataTable dtDeliveryNote = dgvDeliveryNote.DataSource as DataTable;
            if (dtDeliveryNote == null) return;

            foreach (DataGridViewRow row in dgvDeliveryNote.Rows)
            {
                int ProductID = (int)DataTypeParser.Parse(dgvDeliveryNote.Rows[row.Index].Cells[clnProductName.Index].Value, typeof(int), -1);
                int Qty = (int)DataTypeParser.Parse(dgvDeliveryNote.Rows[row.Index].Cells[clnAmount.Index].Value, typeof(int), -1);
                string productName = (string)DataTypeParser.Parse(
                        dgvDeliveryNote.Rows[row.Index].Cells[clnProductName.Index].FormattedValue, typeof(string), string.Empty);

                DataTable dtStockInSubStore = new DeliveryBL().GetStockInSubStore(ProductID, (int)PTIC.Common.Enum.PredefinedWarehouse.SSBSubStoreID);
                if (dtStockInSubStore.Rows.Count <= 0)
                {
                    MessageBox.Show(productName + " သည် Sub Store တွင် လက်ကျန် လုံးဝမရှိပါ။ Factory သို့ ပစ္စည်းတောင်းပါ။",
                        this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    dgvDeliveryNote.CurrentRow.Cells[clnAmount.Index].Value = 0;
                    dgvDeliveryNote.CurrentRow.Cells[clnExtra.Index].Value = 0;
                    return;
                }

                if (Qty > (int)DataTypeParser.Parse(dtStockInSubStore.Rows[0]["Qty"], typeof(int), -1))
                {
                    MessageBox.Show("Sub Store တွင်လက်ကျန်မလုံလောက်ပါ။ Factory သို့ပစ္စည်းတောင်းပါ။" + Environment.NewLine + "ထုတ်ကုန်အမည် : " + (string)DataTypeParser.Parse(dtStockInSubStore.Rows[0]["ProductName"], typeof(string), string.Empty)
                                                 + Environment.NewLine + "လက်ကျန် : " + (int)DataTypeParser.Parse(dtStockInSubStore.Rows[0]["Qty"], typeof(int), -1), "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    dgvDeliveryNote.CurrentRow.Cells[clnAmount.Index].Value = 0;
                    dgvDeliveryNote.CurrentRow.Cells[clnExtra.Index].Value = 0;
                    return;
                }
            }
            // Save into db
            Save();
        }

        private void dgvDeliveryNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView dgv = sender as DataGridView;
            //if (dgv.Columns[e.ColumnIndex].Name.Equals("colDelete"))
            //{
            //    if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            //    == System.Windows.Forms.DialogResult.No)
            //        return;

            //    DataGridViewRow selectedRow = dgv.CurrentRow;
            //    DataRowState selectedRowState = (selectedRow.DataBoundItem as DataRowView).Row.RowState;
            //    if (selectedRowState == DataRowState.Added || selectedRowState == DataRowState.Detached)
            //    {
            //        // Delete row just from GridView because it is a new row that has not been in Database
            //        dgv.Rows.RemoveAt(selectedRow.Index);
            //        return;
            //    }

            //    int DeliveryNoteDetailID = (int)DataTypeParser.Parse(selectedRow.Cells["colDeliveryNoteID"].Value, typeof(int), -1);
            //    if (DeliveryNoteDetailID == -1)
            //    {
            //        MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    else
            //    {
            //        // delete a selected product from database
            //        DeleteSaleDetail(DeliveryNoteDetailID, dgv);
            //    }
            //}
        }

        private void lblDelivery_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmOrderMain));
            this.Close();
        }

        private void dgvDeliveryNote_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            int totalAmt = 0;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                    if ((int)DataTypeParser.Parse(gridView.Rows[r.Index].Cells[clnOrder.Index].Value, typeof(int), 0) > 0 &&
                        (int)DataTypeParser.Parse(gridView.Rows[r.Index].Cells[clnProductName.Index].Value, typeof(int), -1) != -1)
                    {
                        gridView.Rows[r.Index].Cells[clnProductName.Index].ReadOnly = true;
                        gridView.Rows[r.Index].Cells[clnBrandName.Index].ReadOnly = true;
                    }

                    //totalAmt += (int)DataTypeParser.Parse(r.Cells["clnAmount"].Value, typeof(int), 0);
                }

                foreach (DataGridViewRow row in dgvDeliveryNote.Rows)
                {
                    int order = (int)DataTypeParser.Parse(row.Cells["clnOrder"].Value, typeof(int), 0);
                    int Extra = (int)DataTypeParser.Parse(row.Cells["clnExtra"].Value, typeof(int), 0);
                    int tmp = order + Extra;
                    dgvDeliveryNote.Rows[row.Index].Cells[clnAmount.Index].Value = tmp;

                    totalAmt += (int)DataTypeParser.Parse(dgvDeliveryNote.Rows[row.Index].Cells[clnAmount.Index].Value, typeof(int), 0);
                }
                txtTotalAmt.Text = totalAmt.ToString("N0");
            }

            DataTable dt = dgvDeliveryNote.DataSource as DataTable;
            if (dt.Rows.Count < 1) return;
            foreach (DataRow row in dt.Rows)
            {
                if (dt.Columns.Contains("TotalQty"))
                    try
                    {
                        totalAmt += (int)DataTypeParser.Parse(row["TotalQty"].ToString(), typeof(int), 0);
                    }
                    catch (Exception)
                    {
                    }
            }

        }

        private void dgvDeliveryNote_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //ToastMessageBox.Show(Resource.errQty, Color.Red);
            //e.Cancel = true;
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

        private void dgvDeliveryNote_CellEndEdit(object sender, DataGridViewCellEventArgs e)
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
                        int BrandID = (int)DataTypeParser.Parse(item.Cells[clnBrandName.Index].Value, typeof(int), -1);
                        int ProductID = (int)DataTypeParser.Parse(item.Cells[clnProductName.Index].Value, typeof(int), -1);
                        int DeliverQty = (int)DataTypeParser.Parse(item.Cells[clnOrder.Index].Value, typeof(int), 0);

                        if (BrandID != -1 && ProductID != -1 && DeliverQty > 0)
                        {
                            ToastMessageBox.Show("ဖျက်ခွင့်မရှိပါ။", Color.Red);
                        }
                        else
                        {
                            dgvDeliveryNote.Rows.RemoveAt(item.Index);
                            ToastMessageBox.Show(Resource.errSuccessfullyDeleted);

                        }
                    }

                }
            }
            else
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete, Color.Red);
            }
        }

        private void dgvShowRoom_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
            pnlFilter.Visible = false;
            pnlGrid.Visible = true;

            DeliveryNote deliverynote = new DeliveryNote()
            {
                Date = (DateTime)DataTypeParser.Parse(dtpDeliveryNoteDate.Value, typeof(DateTime), DateTime.Now),
                EmpID = (int)DataTypeParser.Parse(cmbSalePerson.SelectedValue, typeof(int), -1),
                VenID = (int?)DataTypeParser.Parse(DBNull.Value, typeof(int), null)
            };

            cmbEmpDisplay.SelectedValue = deliverynote.EmpID;
            dtpDeliveryDisplay.Value = deliverynote.Date;
            LoadNGridData(deliverynote);
        }

        private void dgvDeliveryNote_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvDeliveryNote.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //frmDeliveryNoteDetailViewer viewer = new frmDeliveryNoteDetailViewer(this.DeliveryNoteID);
            frmRV_DeliveryNoteViewer viewer = new frmRV_DeliveryNoteViewer(this.DeliveryNoteID);
            UIManager.MdiChildOpenForm(viewer);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvDeliveryNote.Rows.Count > 0)
            {
                DataUtil.AddNewRow(dgvDeliveryNote.DataSource as DataTable);
                dgvDeliveryNote.Enabled = true;
                btnRequest.Enabled = true;
                btnDelete.Enabled = true;
                dgvDeliveryNote.CurrentRow.ReadOnly = false;
            }
            else
            {
                DataUtil.AddInitialNewRow(dgvDeliveryNote);
                dgvDeliveryNote.Enabled = true;
                btnRequest.Enabled = true;
                dgvDeliveryNote.CurrentRow.ReadOnly = false;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblFilter_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Visible)
            {
                // pnlFilter.Visible = false;
                lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
                pnlFilter.Visible = false;
                //  pnlGrid.Visible = true;
            }
            else
            {
                // pnlFilter.Visible = true;
                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
                pnlFilter.Visible = true;
                // pnlGrid.Visible = false;
            }
        }

        private void btnLoadOrder_Click(object sender, EventArgs e)
        {
            //DataTable deliveryListFromDeliveryPlan = DeliveryDA.SelectBy();
        }
    }
}

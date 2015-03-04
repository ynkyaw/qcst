using System;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Sale.DA;
using PTIC.VC.Util;
using PTIC.VC;
using PTIC.Sale.BL;
using PTIC.Util;
using System.Drawing;

namespace PTIC.Sale.Setup
{
    public partial class frmPackingDiscount : Form
    {
        /// <summary>
        /// Record table for different Brand
        /// </summary>
        private DataTable _dtBrand = null;

        /// <summary>
        /// Record table for different Product
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
        /// 
        /// </summary>
        private ComboBox _cmBProduct = null;

        //DataTable productTbl = null;
        DataTable packingdiscountTbl = null;
        PackingDiscount packingdiscount = new PackingDiscount();

        public frmPackingDiscount()
        {
            InitializeComponent();
            this._indexBrandColumn = dgvsetuppackingdis.Columns.IndexOf(dgvsetuppackingdis.Columns["BrandID"]);
            this._indexProductColumn = dgvsetuppackingdis.Columns.IndexOf(dgvsetuppackingdis.Columns["ProductID"]);
            LoadData();
            BindData();            
            if (dgvsetuppackingdis.RowCount < 1)
            {
                DataRow newRow = packingdiscountTbl.NewRow();
                packingdiscountTbl.Rows.Add(newRow);
                this.dgvsetuppackingdis.DataSource = packingdiscountTbl;   
            }
        }

        #region Private Method
        private void LoadData()  //Load Town Data for Grid
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                BrandID.DataSource = _dtBrand = new BrandBL().GetAll();
                ProductID.DataSource=_dtProduct = new ProductBL().GetAll();
                packingdiscountTbl = new PackingDiscountBL().GetAll(conn);

                BrandID.DisplayMember = "BrandName";
                BrandID.ValueMember = "BrandID";

                ProductID.DisplayMember = "ProductName";
                ProductID.ValueMember = "ProductID";
            }
            catch (SqlException sqle)
            {

            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void BindData()  // Bind Data into DataGridView
        {
            // Auto Generate Columns
            dgvsetuppackingdis.AutoGenerateColumns = false;

            //ProductID.DataSource = productTbl;
            //ProductID.DisplayMember = "ProductName";
            //ProductID.ValueMember = "ProductID";

            dgvsetuppackingdis.DataSource = packingdiscountTbl;
        }

        private void Save()
        {
            DataTable dt = dgvsetuppackingdis.DataSource as DataTable;
            int sup = 0;
            if (dt == null)
                return;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    packingdiscount.ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1);
                    packingdiscount.AmtPerPack = (int)DataTypeParser.Parse(row["AmtPerPack"].ToString(), typeof(int), -1);
                    packingdiscount.PackQty  = (int)DataTypeParser.Parse(row["PackQty"].ToString(), typeof(int), -1);
                    if (packingdiscount.AmtPerPack < 1)
                    {
                        ToastMessageBox.Show("ေလွ်ာ့ေစ်း ျဖည့္ပါ");
                    }
                    else if (packingdiscount.PackQty < 1)
                    {
                        ToastMessageBox.Show("ပါကင္အေရအတြက္ ျဖည့္ပါ");
                    }
                    else
                    {
                        sup = new PackingDiscountBL().Insert(packingdiscount, conn);
                    }
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    packingdiscount.PackingDiscountID = (int)DataTypeParser.Parse(row["PackingDiscountID"].ToString(), typeof(int), -1);
                    sup = new PackingDiscountBL().Delete(packingdiscount, conn);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    packingdiscount.PackingDiscountID = (int)DataTypeParser.Parse(row["PackingDiscountID"].ToString(), typeof(int), -1);
                    packingdiscount.ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1);
                    packingdiscount.AmtPerPack = (int)DataTypeParser.Parse(row["AmtPerPack"].ToString(), typeof(int), -1);
                    packingdiscount.PackQty = (int)DataTypeParser.Parse(row["PackQty"].ToString(), typeof(int), -1);
                    sup = new PackingDiscountBL().Update(packingdiscount, conn);
                }

                if (sup > 0)
                {
                    LoadData();
                    BindData();
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }

            }
            catch (Exception sqle)
            {
                // show error message
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        #endregion

        #region Event Handler
        
        private void dgvsetuppackingdis_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvsetuppackingdis.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvsetuppackingdis.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dgvsetuppackingdis.SelectedRows)
                    {
                        dgvsetuppackingdis.Rows.RemoveAt(item.Index);
                    }
                    Save();
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
            }
            else
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete, Color.Red);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadData();
            BindData();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
            this.Close();
        }

        #endregion

        private void dgvsetuppackingdis_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvsetuppackingdis.CurrentRow.Cells["ProductID"].Value.ToString().Equals("") || dgvsetuppackingdis.CurrentRow.Cells["ProductID"].Value.ToString().Equals("-1"))
            {
                return;
            }
            if (e.ColumnIndex == dgvsetuppackingdis.Columns["AmtPerPack"].Index)
            {
                decimal newInteger;
                if (dgvsetuppackingdis.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    //e.Cancel = true;
                    ToastMessageBox.Show("Amount must be fill", Color.Red);
                    //dgvsetuppackingdis.CurrentRow.Cells[e.ColumnIndex].ErrorText = "Amount must be fill";
                }
                else
                    if (!decimal.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger <= 0)
                    {
                        //e.Cancel = true;
                        ToastMessageBox.Show("Amount must be integer", Color.Red);
                        //dgvsetuppackingdis.CurrentRow.Cells[e.ColumnIndex].ErrorText = "Amount must be integer";
                    }
                    else
                    {
                        dgvsetuppackingdis.CurrentCell.ErrorText = string.Empty;
                    }
            }
            if (e.ColumnIndex == dgvsetuppackingdis.Columns["PackQty"].Index)
            {
                int newInteger;
                if (dgvsetuppackingdis.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    //e.Cancel = true;
                    ToastMessageBox.Show("Packing quantity must be fill", Color.Red);
                    //dgvsetuppackingdis.CurrentRow.Cells[e.ColumnIndex].ErrorText = "Packing quantity must be fill";
                }
                else if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger <= 0)
                {
                    //e.Cancel = true;
                    ToastMessageBox.Show("Packing quantity must be integer", Color.Red);
                    //dgvsetuppackingdis.CurrentRow.Cells[e.ColumnIndex].ErrorText = "Packing quantity must be integer";
                }
                else
                {
                    dgvsetuppackingdis.CurrentCell.ErrorText = string.Empty;
                }
            }
        }

        private void dgvsetuppackingdis_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //TODO handle
            e.Cancel = true;
           // dgvsetuppackingdis.CurrentRow.Cells[e.ColumnIndex].ErrorText = "error : must be integer";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvsetuppackingdis.CurrentCell.ColumnIndex;
                int iRow = dgvsetuppackingdis.CurrentCell.RowIndex;
                if (iColumn == dgvsetuppackingdis.Columns.Count - 1)
                {
                    if (iRow + 1 >= dgvsetuppackingdis.Rows.Count)
                    {
                        DataRow newRow = packingdiscountTbl.NewRow();
                        packingdiscountTbl.Rows.Add(newRow);
                        this.dgvsetuppackingdis.DataSource = packingdiscountTbl;
                        dgvsetuppackingdis[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        try
                        {
                            dgvsetuppackingdis.CurrentCell = dgvsetuppackingdis[0, iRow + 1];
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
                        dgvsetuppackingdis.CurrentCell = dgvsetuppackingdis[iColumn + 1, iRow];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvsetuppackingdis.DataSource as DataTable);
            dgvsetuppackingdis.CurrentCell = dgvsetuppackingdis.Rows[dgvsetuppackingdis.RowCount - 1].Cells["ProductID"];
        }

        private void dgvsetuppackingdis_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            var gv = sender as DataGridView;
            DataTable productTable = gv.DataSource as DataTable;
            string curColumName = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
            DataGridViewRow curRow = gv.Rows[e.RowIndex];
            //if (dgvsetuppackingdis.Columns["ProductID"].Index == e.ColumnIndex)
            ////if (curColumName.Equals("ProductID"))
            //{
            //    for (int i = 0; i <= packingdiscountTbl.Rows.Count - 2; i++)
            //    {
            //        if (Convert.ToInt32(packingdiscountTbl.Rows[i]["ProductID"]) == Convert.ToInt32(curRow.Cells["ProductID"].Value))
            //        {
            //            ToastMessageBox.Show("ယခုထုတ္ကုန္ကို သတ္မွတ္ျပီးသား ရွိပါသည္။", Color.Red);
            //            curRow.Cells["ProductID"].Value = -1;
            //        }
            //    }
            //}
        }

        private void dgvsetuppackingdis_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvsetuppackingdis.CurrentRow != null && dgvsetuppackingdis.CurrentCell.ColumnIndex == _indexProductColumn)
            {
                _cmBProduct = e.Control as ComboBox;
                if (_cmBProduct != null)
                {
                    _cmBProduct.DropDown += new EventHandler(_cmBProduct_DropDown);
                }
            }
        }

        //#region DataGridView ComboBox Events
        private void _cmBProduct_DropDown(object sender, EventArgs e)
        {
            int BrandID = (int)DataTypeParser.Parse(dgvsetuppackingdis.CurrentRow.Cells[_indexBrandColumn].Value, typeof(int), 0);
            if (BrandID < 1)
                return;
            DataTable dtResultProducts = DataUtil.GetDataTableBy(this._dtProduct, "BrandID", BrandID);
            _cmBProduct.DataSource = dtResultProducts;
        }

        private void dgvsetuppackingdis_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (_cmBProduct != null)
            {
                _cmBProduct.DropDown -= new EventHandler(_cmBProduct_DropDown);
            }
        }
        //#endregion  
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Sale.BL;
using PTIC.VC.Util;
using PTIC.Marketing.BL;
using PTIC.Util;
using PTIC.VC;
using PTIC.VC.Validation;
using PTIC.Marketing.Entities;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace PTIC.Marketing.Complaint
{
    public partial class frmProductsPicker : Form
    {
        private ValidatorFactory _validatorFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();

        //  DataTable for RelationCombo
        DataTable dtBrand, dtProduct;

        BindingSource bdBrand, bdfilteredProduct, bdunfilteredProduct;

        ComboBox cmb;

        // RowEdit Flag
        bool RowEditFalg = false;

        public delegate void ProductSelectionHandler(object sender, ProductSelectionEventArgs args);
        public event ProductSelectionHandler ProductSelectedHandler;

        public frmProductsPicker()
        {
            InitializeComponent();
            LoadNBind();
            DataUtil.AddInitialNewRow(dgvProductSelection);
            dgvProductSelection.CurrentCell = dgvProductSelection.Rows[dgvProductSelection.Rows.Count - 1].Cells[0];
        }

        #region Private Methods
        private void LoadNBind()
        {
            try
            {
                dtBrand = new BrandBL().GetAll();
                dtProduct = new ProductBL().GetAll();

                bdBrand = new BindingSource();
                bdBrand.DataSource = dtBrand;

                colBrand.DataSource = bdBrand;
                colBrand.DisplayMember = "BrandName";
                colBrand.ValueMember = "BrandID";


                bdunfilteredProduct = new BindingSource();
                DataView undv = new DataView(dtProduct);

                bdunfilteredProduct.DataSource = undv;
                colProduct.DataSource = bdunfilteredProduct;
                colProduct.DisplayMember = "ProductName";
                colProduct.ValueMember = "ProductID";


                bdfilteredProduct = new BindingSource();
                DataView fdv = new DataView(dtProduct);
                bdfilteredProduct.DataSource = fdv;

                //  Complaint Case
                DataTable dtComplaintCase = new ComplaintCaseBL().GetComplaintCase();
                colCause.DataSource = dtComplaintCase;
                colCause.DisplayMember = "CaseDespt";
                colCause.ValueMember = "ComplaintCaseID";


                DataTable dtProudctInComplaintReceive = new ProductInComplaintReceiveBL().GetProductInComplaintReceiveByComplaintReceiveID(-1);
                // Bind Data into GridView
                dgvProductSelection.AutoGenerateColumns = false;
                dgvProductSelection.DataSource = dtProudctInComplaintReceive;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvProductSelection.CurrentCell.ColumnIndex;
                int iRow = dgvProductSelection.CurrentCell.RowIndex;
                if (iColumn == dgvProductSelection.Columns[colCause.Index].Index)
                {
                    if (iRow + 1 >= dgvProductSelection.Rows.Count)
                    {
                        DataTable dtProductInComplaintReceive = dgvProductSelection.DataSource as DataTable;
                        DataRow newRow = dtProductInComplaintReceive.NewRow();
                        dtProductInComplaintReceive.Rows.Add(newRow);
                        this.dgvProductSelection.DataSource = dtProductInComplaintReceive;
                        dgvProductSelection[0, iRow + 1].Selected = true;
                        // dgvProductSelection.Rows[dgvProductSelection.Rows.Count - 1].Cells[dgvProductSelection.Index].Value = DateTime.Now;
                    }
                    else
                    {
                        dgvProductSelection.CurrentCell = dgvProductSelection[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvProductSelection.CurrentCell = dgvProductSelection[dgvProductSelection.CurrentCell.ColumnIndex + 1, dgvProductSelection.CurrentCell.RowIndex];

                    }
                    catch (Exception ie)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void dgvProductSelection_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colProduct.Index)
                {
                    int Brand = (int)DataTypeParser.Parse(this.dgvProductSelection[e.ColumnIndex - 1, e.RowIndex].Value, typeof(int), 0);
                    if (Brand == 0) return;
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvProductSelection[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdfilteredProduct;

                    this.bdfilteredProduct.Filter = "BrandID = " + this.dgvProductSelection[e.ColumnIndex - 1, e.RowIndex].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvProductSelection_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == this.colProduct.Index)
                {
                    DataGridViewComboBoxCell dgcb = (DataGridViewComboBoxCell)dgvProductSelection[e.ColumnIndex, e.RowIndex];

                    dgcb.DataSource = bdunfilteredProduct;
                }

                if (dgvProductSelection.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colProductAmt.Index)
                {
                    dgvProductSelection.Rows[e.RowIndex].ErrorText = String.Empty;
                    dgvProductSelection.CurrentRow.Cells[colProductAmt.Index].Value = 0;
                }
                else if (dgvProductSelection.Rows[e.RowIndex].ErrorText != String.Empty && e.ColumnIndex == colProduct.Index)
                {
                    dgvProductSelection.Rows[e.RowIndex].ErrorText = String.Empty;
                    dgvProductSelection.CurrentRow.Cells[colProduct.Index].Value = -1;
                }
            }
            catch { }
        }

        private void dgvProductSelection_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }

            if (this.dgvProductSelection.CurrentCell.ColumnIndex == 0 && (e.Control is ComboBox))
            {
                cmb = e.Control as ComboBox;
                cmb.SelectionChangeCommitted += new EventHandler(cmb_SelectionChangeCommitted);
            }

            e.Control.KeyPress -= new KeyPressEventHandler(Control_KeyPress);
            if (dgvProductSelection.CurrentCell.ColumnIndex == colProductAmt.Index)
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
            }
        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressfunction.CheckInt(sender, e);
        }

        private void cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvProductSelection.CurrentCell.ColumnIndex == 0)
            {
                //  this.dgvAPEnquiry[1, this.dgvAPEnquiry.CurrentCell.RowIndex].Value = 0;
            }
        }

        private void dgvProductSelection_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvProductSelection_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvProductSelection.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvProductSelection_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int newInteger = 0;
            //   decimal newDecimal = 0;
            var dgv = sender as DataGridView;
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (e.ColumnIndex == colProduct.Index)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Index != e.RowIndex & !row.IsNewRow)
                    {
                        if (row.Cells["colProduct"].FormattedValue.ToString() == "" && e.FormattedValue.ToString() == "") return;
                        if (row.Cells["colProduct"].FormattedValue.ToString() == e.FormattedValue.ToString())
                        {
                            dgv.Rows[e.RowIndex].ErrorText = "Duplicate not allowed!";
                            MessageBox.Show("Duplicate not allowed!", "တားမြစ်ချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
            }
            else if (e.ColumnIndex == colProductAmt.Index)
            {
                if (!int.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger < 0)
                {
                    dgv.Rows[e.RowIndex].ErrorText = "အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။";
                    ToastMessageBox.Show("အ‌ရေအတွက် မှားယွင်း‌နေပါသည်။", Color.Red);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvProductSelection.DataSource as DataTable);
            dgvProductSelection.CurrentCell = dgvProductSelection.Rows[dgvProductSelection.Rows.Count - 1].Cells[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProductSelection.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure want to delete Selected Row?", "အတည်ပြုချက်", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int Index = dgvProductSelection.CurrentRow.Index;
                    dgvProductSelection.Rows.RemoveAt(Index);
                }
            }
            else
            {
                MessageBox.Show(Resource.errSelectRowToDelete, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvProductSelection_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    if ((int)DataTypeParser.Parse(gridView.Rows[r.Index].Cells[colProductInComplaintReceiveID.Index].Value, typeof(int), 0) != 0)
                    {
                        gridView.Rows[r.Index].ReadOnly = true;
                        gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                    }
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void dgvProductSelection_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dgv = dgvProductSelection as DataGridView;
            if (RowEditFalg == false)
            {
                dgv.CurrentRow.ReadOnly = false;
            }
        }

        #region Inner Class
        public class ProductSelectionEventArgs : System.EventArgs
        {
            private List<ProductInComplaintReceive> _ProductsInComplaintReceive;

            public ProductSelectionEventArgs(List<ProductInComplaintReceive> _productsInComplaintReceive)
            {
                this._ProductsInComplaintReceive = _productsInComplaintReceive;
            }

            public List<ProductInComplaintReceive> ProductsInComplaintReceive
            {
                get { return this._ProductsInComplaintReceive; }
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProductsInComplaintReceive();            
        }

        private void SaveProductsInComplaintReceive()
        {
            DataTable dtProducts = dgvProductSelection.DataSource as DataTable;

            // Get selected ProductInComplaintReceive in state of  DataViewRowState.CurrentRows
            DataView dvSelectedProductsInComplaintReceive = new DataView(dtProducts, string.Empty, string.Empty, DataViewRowState.CurrentRows);

            List<ProductInComplaintReceive> insertProducts = new List<ProductInComplaintReceive>();
            DataView dvAdded = new DataView(dtProducts, "", "", DataViewRowState.Added);

            foreach (DataRow row in dvAdded.ToTable().Rows)
            {
                ProductInComplaintReceive Products = new ProductInComplaintReceive()
                {
                    //ID = (int)DataTypeParser.Parse(row["ProductInComplaintReceiveID"], typeof(int), -1),
                    ComplaintReceiveID = (int)DataTypeParser.Parse(row["ComplaintReceiveID"], typeof(int), -1),
                    ProductID = (int)DataTypeParser.Parse(row["ProductID"], typeof(int), -1),
                    ComplaintCaseID = (int)DataTypeParser.Parse(row["ComplaintCaseID"], typeof(int), -1),                    
                    ProductionDate = (string)DataTypeParser.Parse(row["ProductionDate"], typeof(string), null),
                    Qty = (int)DataTypeParser.Parse(row["Qty"], typeof(int), -1)
                };                
                insertProducts.Add(Products);
            }

            // Validate fields
            Validator<ProductInComplaintReceive> productValidator = _validatorFactory.CreateValidator<ProductInComplaintReceive>();
            foreach (ProductInComplaintReceive product in insertProducts)
            {
                ValidationResults pResults = productValidator.Validate(product);
                if (!pResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(pResults) as ValidationResult;
                    MessageBox.Show(
                            err.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    return;
                }              
            }

            // Set selected products and handler for caller
            ProductSelectionEventArgs args = new ProductSelectionEventArgs(insertProducts);
            ProductSelectedHandler(this, args);
            this.Close();
        }

    }
}

/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: (yyyy/mm/dd)
 * Description:
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.VC;
using PTIC.VC.Util;
using PTIC.Sale.BL;

namespace PTIC.Sale.Setup
{
    public partial class frmProducts : Form
    {
        /// <summary>
        /// Logger for frmProducts
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmProducts));

        #region Event Handlers
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProduct productForm = new frmProduct();
            productForm.ProductSavedHandler += new frmProduct.ProductSaveHandler(ProductSave_CallBack);
            UIManager.OpenForm(productForm);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProduct.CurrentRow.IsNewRow || dgvProduct.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectModifyRecord);
                return;
            }

            DataGridViewRow selectedRow = dgvProduct.CurrentRow;
            Product selectedProduct = new Product()
            {
                ID = (int)DataTypeParser.Parse(selectedRow.Cells["colProductID"].Value, typeof(int), -1),
                SubCategoryID = (int)DataTypeParser.Parse(selectedRow.Cells["colSubCategoryID"].Value, typeof(int), -1),
                FormulaID = (int)DataTypeParser.Parse(selectedRow.Cells["colFormulaID"].Value, typeof(int), -1),
                ProductName = (string)DataTypeParser.Parse(selectedRow.Cells["colProductName"].Value, typeof(string), string.Empty),
                ProductCode = (string)DataTypeParser.Parse(selectedRow.Cells["colProductCode"].Value, typeof(string), string.Empty),
                UsedPlace = (string)DataTypeParser.Parse(selectedRow.Cells["colUsedPlace"].Value, typeof(string), string.Empty),
                NoPerPack = (int)DataTypeParser.Parse(selectedRow.Cells["colNoPerPack"].Value, typeof(int), 0),
                ConLength = (int)DataTypeParser.Parse(selectedRow.Cells["colConLength"].Value, typeof(int), 0),
                ConBase = (int)DataTypeParser.Parse(selectedRow.Cells["colConBase"].Value, typeof(int), 0),
                ConHeight = (int)DataTypeParser.Parse(selectedRow.Cells["colConHeight"].Value, typeof(int), 0),
                ConThick = (int)DataTypeParser.Parse(selectedRow.Cells["colConThick"].Value, typeof(int), 0),
                MinOrderQty = (int)DataTypeParser.Parse(selectedRow.Cells["colMinOrderQty"].Value, typeof(int), 0),
                Volt = (float)DataTypeParser.Parse(selectedRow.Cells["colVolt"].Value, typeof(float), 0),
                Plate = (int)DataTypeParser.Parse(selectedRow.Cells["colPlate"].Value, typeof(int), 0),
                Amps = (int)DataTypeParser.Parse(selectedRow.Cells["colAmps"].Value, typeof(int), 0),
                Acid = (float)DataTypeParser.Parse(selectedRow.Cells["colAcid"].Value, typeof(float), 0),
                FreeConWeight = (float)DataTypeParser.Parse(selectedRow.Cells["colFreeConWeight"].Value, typeof(float), 0),
                LeadWeight = (float)DataTypeParser.Parse(selectedRow.Cells["colLeadWeight"].Value, typeof(float), 0),
                Remark = (string)DataTypeParser.Parse(selectedRow.Cells["colRemark"].Value, typeof(string), string.Empty),
                HasDiscount = (bool)DataTypeParser.Parse(selectedRow.Cells["colHasDiscount"].Value, typeof(bool), false)
                
            };

            string brandID = selectedRow.Cells["colBrandID"].Value.ToString();
            string categoryID = selectedRow.Cells["colCategoryID"].Value.ToString();

            frmProduct productForm = new frmProduct(selectedProduct, brandID, categoryID);
            productForm.ProductSavedHandler += new frmProduct.ProductSaveHandler(ProductSave_CallBack);
            // show frmProduct to modify a selected product
            UIManager.OpenForm(productForm);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ( dgvProduct.CurrentRow.IsNewRow || dgvProduct.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.No)
                return;

            DataGridViewRow selectedRow = dgvProduct.CurrentRow;
            int productID = (int)DataTypeParser.Parse(selectedRow.Cells["colProductID"].Value, typeof(int), -1);
            if (productID == -1)
            {
                MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // delete a selected product
                DeleteProduct(productID);
            }
        }

        private void dgvProduct_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvProduct.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
            this.Close();
        }

        private void ProductSave_CallBack(object sender, frmProduct.ProductSaveEventArgs e)
        {
            if (e.NeedToReloadProducts)
                LoadNBindData(); // load and bind products
        }
        #endregion

        #region Private Methods
        private void DeleteProduct(int productID)
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // delete a selected product
                int affectedRows = new ProductBL().DeleteByID(productID, conn);
                if (affectedRows > 0)
                {
                    dgvProduct.Rows.RemoveAt(dgvProduct.CurrentRow.Index);
                    // reload products
                    LoadNBindData();
                    // show successful msg and close this
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
                else
                    MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException sql)
            {
                _logger.Error(sql);
                MessageBox.Show(Resource.errFailedToSave, Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        #endregion
        // TODO: Remove Save() function
        /*
        private void Save()
        {
            DataTable dtProduct = dgvProduct.DataSource as DataTable;
            if (dtProduct == null || dtProduct.Rows.Count < 1)
                return;

            SqlConnection conn = null;
            try
            {
                int affectedRows = 0;
                conn = DBManager.GetInstance().GetDbConnection();
                ProductBL productSaver = new ProductBL();

                // insert
                DataView dvInsert = new DataView(dtProduct, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    affectedRows = affectedRows + 
                        productSaver.Add(new Product() 
                        {
                            // TODO: if BrandID is null, no need to proess. Continue loop
                            SubCategoryID = (int)DataTypeParser.Parse(row["SubCategoryID"].ToString(), typeof(int), -1),
                            ProductName = row["ProductName"].ToString(),
                            ProductCode = row["ProductCode"].ToString(),
                            UsedPlace = row["UsedPlace"].ToString(),
                            NoPerPack = (int)DataTypeParser.Parse(row["NoPerPack"].ToString(), typeof(int), 0),
                            ConLength = (int)DataTypeParser.Parse(row["ConLength"].ToString(), typeof(int), 0),
                            ConBase = (int)DataTypeParser.Parse(row["ConBase"].ToString(), typeof(int), 0),
                            ConHeight = (int)DataTypeParser.Parse(row["ConHeight"].ToString(), typeof(int), 0),
                            ConThick = (int)DataTypeParser.Parse(row["ConThick"].ToString(), typeof(int), 0),
                            MinOrderQty = (int)DataTypeParser.Parse(row["MinOrder"].ToString(), typeof(int), 0),
                            Volt = (float)DataTypeParser.Parse(row["Volt"].ToString(), typeof(float), 0),
                            Plate = (int)DataTypeParser.Parse(row["Plate"].ToString(), typeof(int), 0),
                            Amps = (int)DataTypeParser.Parse(row["Amps"].ToString(), typeof(int), 0),
                            Acid = (float)DataTypeParser.Parse(row["Acid"].ToString(), typeof(float), 0),
                            FreeConWeight = (float)DataTypeParser.Parse(row["FreeConWeight"].ToString(), typeof(float), 0),
                            LeadWeight = (float)DataTypeParser.Parse(row["LeadWeight"].ToString(), typeof(float), 0),
                            Remark = row["Remark"].ToString()
                        }, conn);
                }
                // update
                DataView dvUpdate = new DataView(dtProduct, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    affectedRows = affectedRows + 
                        productSaver.UpdateByID(new Product()
                        {
                            // TODO: if ID is null, no need to proess. Continue loop
                            ID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1),
                            SubCategoryID = (int)DataTypeParser.Parse(row["SubCategoryID"].ToString(), typeof(int), -1),
                            ProductName = row["ProductName"].ToString(),
                            ProductCode = row["ProductCode"].ToString(),
                            UsedPlace = row["UsedPlace"].ToString(),
                            NoPerPack = (int)DataTypeParser.Parse(row["NoPerPack"].ToString(), typeof(int), 0),
                            ConLength = (int)DataTypeParser.Parse(row["ConLength"].ToString(), typeof(int), 0),
                            ConBase = (int)DataTypeParser.Parse(row["ConBase"].ToString(), typeof(int), 0),
                            ConHeight = (int)DataTypeParser.Parse(row["ConHeight"].ToString(), typeof(int), 0),
                            ConThick = (int)DataTypeParser.Parse(row["ConThick"].ToString(), typeof(int), 0),
                            MinOrderQty = (int)DataTypeParser.Parse(row["MinOrder"].ToString(), typeof(int), 0),
                            Volt = (float)DataTypeParser.Parse(row["Volt"].ToString(), typeof(float), 0),
                            Plate = (int)DataTypeParser.Parse(row["Plate"].ToString(), typeof(int), 0),
                            Amps = (int)DataTypeParser.Parse(row["Amps"].ToString(), typeof(int), 0),
                            Acid = (float)DataTypeParser.Parse(row["Acid"].ToString(), typeof(float), 0),
                            FreeConWeight = (float)DataTypeParser.Parse(row["FreeConWeight"].ToString(), typeof(float), 0),
                            LeadWeight = (float)DataTypeParser.Parse(row["LeadWeight"].ToString(), typeof(float), 0),
                            Remark = row["Remark"].ToString()
                        }, conn);
                }
                // delete
                DataView dvDelete = new DataView(dtProduct, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    affectedRows = affectedRows + productSaver.DeleteByID(row["ProductID"].ToString(), conn);
                }
                //MessageBox.Show("Successfully Saved.");
                ToastMessageBox.Show(string.Format(Resource.msgSuccessfullySaved, affectedRows));
            }
            catch (Exception sqle)
            {
                MessageBox.Show(Resource.errFailedToSave, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }
        */

        #region Constructors
        public frmProducts()
        {
            InitializeComponent();
            // configure logger 
            XmlConfigurator.Configure();
            // load and bind data
            LoadNBindData();
        }
        #endregion

        #region Public Methods
        public void LoadNBindData()
        {            
            try
            {                
                dgvProduct.AutoGenerateColumns = false;
                dgvProduct.DataSource = new ProductBL().GetAll();
                
                // Code Added by YNK
                btnEdit.Enabled =  btnDelete.Enabled = (dgvProduct.Rows.Count > 0);
                //Code Add End


            }
            catch (Exception e)
            {
                // TODO: handle error
                _logger.Error(e);
                throw e;
            }          
        }
        #endregion

    }
}

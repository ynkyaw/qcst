/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: (yyyy/mm/dd)
 * Description: Form control to show products
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
    public partial class frmProduct : Form
    {
        /// <summary>
        /// Logger for frmProduct
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmProduct));


        DataTable productTbl = null;
        /// <summary>
        /// True or false indicating whether form is for new product or for updating existing product
        /// </summary>
        //private bool _isNewProduct = false;

        /// <summary>
        /// Product to be modified
        /// </summary>
        private Product _mdProduct = null;
        /// <summary>
        /// Brand ID of product that is to be modified
        /// </summary>
        private string _brandID;
        /// <summary>
        /// Category ID of product that is to be modified
        /// </summary>
        private string _categoryID;

        Product product = new Product();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void ProductSaveHandler(object sender, ProductSaveEventArgs e);
        /// <summary>
        /// 
        /// </summary>
        public event ProductSaveHandler ProductSavedHandler;

        #region Event Handlers
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool name_duplicate = false;

            if ("" == txtProductName.Text || txtProductName.Text == null)
            {
                ToastMessageBox.Show("ထုတ်ကုန်အမည်ကို ဖြည့်ပါ။");
            }
            //else if (txtProductCode.Text == "" || null == txtProductCode.Text)
            //{
            //    ToastMessageBox.Show("Product code ကိုျဖည့္ပါ");
            //}
            else if (cmbSubCategory.SelectedValue == null)
            {
                ToastMessageBox.Show("ထုတ်ကုန်အမျိုးအစားခွဲကို ဖြည့်ပါ။");
            }
            else if (cmbFormula.SelectedValue == null)
            {
                ToastMessageBox.Show("Formula ရွေ:ပါ။");
            }
            else
            {
                product.SubCategoryID = (int)DataTypeParser.Parse(cmbSubCategory.SelectedValue, typeof(int), -1);
                product.ProductName = txtProductName.Text.Trim();

                foreach (DataRow dr in productTbl.Rows)
                {
                    if (product.ProductName.Equals(dr[9]) && product.SubCategoryID == (int)DataTypeParser.Parse(dr[3], typeof(int), 0))
                    {
                        //show error
                        name_duplicate = true;
                    }
                }

                if (name_duplicate && _mdProduct == null)
                {
                    ToastMessageBox.Show("ထုတ်ကုန်အမျိုးအစားခွဲ ရှိပြီးသား ဖြစ်ပါသည်။");
                }
                else
                {
                    Save();
                }
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Load and bind data for Brand, Category and SubCategory
        /// </summary>
        private void LoadNBindData()
        {
            DataSet ds = new DataSet();
            BindingSource bdBrand = new BindingSource();
            BindingSource bdCategory = new BindingSource();
            BindingSource bdSubCategory = new BindingSource();
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                productTbl = new ProductBL().GetAll(); // For Validation

                DataTable dtBrand = new BrandBL().GetOwnBrands().Copy(); // make copy to be added into a single dataset
                DataTable dtCategory = new CategoryBL().GetAll().Copy(); // make copy to be added into a single dataset
                DataTable dtSubCategory = new SubCategoryBL().GetAll().Copy(); // make copy to be added into a single dataset

                // add three datatables into a single dataset
                ds.Tables.Add(dtBrand);
                ds.Tables.Add(dtCategory);
                ds.Tables.Add(dtSubCategory);

                // create data relations among three tables
                DataRelation relBrand_Category = new DataRelation("Brand_Category",
                    dtBrand.Columns["BrandID"], dtCategory.Columns["BrandID"],false);
                DataRelation relCategory_SubCategory = new DataRelation("Category_SubCategory",
                    dtCategory.Columns["CategoryID"], dtSubCategory.Columns["CategoryID"],false);
                ds.Relations.Add(relBrand_Category);
                ds.Relations.Add(relCategory_SubCategory);

                /** relation between Brand and Category **/
                bdBrand.DataSource = ds;
                bdBrand.DataMember = dtBrand.TableName;

                bdCategory.DataSource = bdBrand;
                bdCategory.DataMember = "Brand_Category";

                /** relation between Category and SubCategory **/
                bdSubCategory.DataSource = bdCategory;
                bdSubCategory.DataMember = "Category_SubCategory";

                // bind binding list to each combo datasource
                cmbBrand.DataSource = bdBrand;
                cmbCategory.DataSource = bdCategory;
                cmbSubCategory.DataSource = bdSubCategory;

                // Load Formula
                DataTable FormulaTbl = new FormulaBL().GetAll(conn);
                // generate the data to insert
                DataRow FormulaInsert = FormulaTbl.NewRow();
                FormulaInsert["FormulaID"] = -1;
                FormulaInsert["Formula"] = "-";
                // insert in the Index 0 place
                FormulaTbl.Rows.InsertAt(FormulaInsert, 0);

                cmbFormula.DataSource = FormulaTbl;
                cmbFormula.DisplayMember = "Formula";
                cmbFormula.ValueMember = "FormulaID";
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        /// <summary>
        /// Bind data to be ready for modification
        /// </summary>
        private void BindModifyData()
        {
            cmbBrand.SelectedValue = _brandID;
            cmbCategory.SelectedValue = _categoryID;
            cmbSubCategory.SelectedValue = _mdProduct.SubCategoryID;
            cmbFormula.SelectedValue = _mdProduct.FormulaID;
            txtProductCode.Text = _mdProduct.ProductCode;
            txtProductName.Text = _mdProduct.ProductName;
            txtUsedPlace.Text = _mdProduct.UsedPlace;
            txtNoPerPack.Text = DataTypeParser.Parse(_mdProduct.NoPerPack, typeof(string), string.Empty) as string;
            txtConLength.Text = DataTypeParser.Parse(_mdProduct.ConLength, typeof(string), string.Empty) as string;
            txtConBase.Text = DataTypeParser.Parse(_mdProduct.ConBase, typeof(string), string.Empty) as string;
            txtConHeight.Text = DataTypeParser.Parse(_mdProduct.ConHeight, typeof(string), string.Empty) as string;
            txtConThick.Text = DataTypeParser.Parse(_mdProduct.ConThick, typeof(string), string.Empty) as string;
            txtMinOrderQty.Text = DataTypeParser.Parse(_mdProduct.MinOrderQty, typeof(string), string.Empty) as string;
            txtVolt.Text = DataTypeParser.Parse(_mdProduct.Volt, typeof(string), string.Empty) as string;
            txtPlate.Text = DataTypeParser.Parse(_mdProduct.Plate, typeof(string), string.Empty) as string;
            txtAcid.Text = DataTypeParser.Parse(_mdProduct.Acid, typeof(string), string.Empty) as string;
            txtAmps.Text = DataTypeParser.Parse(_mdProduct.Amps, typeof(string), string.Empty) as string;
            txtFreeConWeight.Text = DataTypeParser.Parse(_mdProduct.FreeConWeight, typeof(string), string.Empty) as string;
            txtLeadWeight.Text = DataTypeParser.Parse(_mdProduct.LeadWeight, typeof(string), string.Empty) as string;
            txtRemark.Text = _mdProduct.Remark;
            chkDiscount.Checked = _mdProduct.HasDiscount;
        }

        /// <summary>
        /// Save a new or existing product
        /// </summary>
        private void Save()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                ProductBL productSaver = new ProductBL();
                Product saveProduct = new Product()
                {
                    SubCategoryID = (int)DataTypeParser.Parse(cmbSubCategory.SelectedValue, typeof(int), -1),
                    FormulaID = (int?)DataTypeParser.Parse(cmbFormula.SelectedValue, typeof(int), null),
                    ProductName = txtProductName.Text,
                   // ProductCode = txtProductCode.Text,
                    UsedPlace = txtUsedPlace.Text,
                    NoPerPack = (int)DataTypeParser.Parse(txtNoPerPack.Text, typeof(int), 0),
                    ConLength = (int)DataTypeParser.Parse(txtConLength.Text, typeof(int), 0),
                    ConBase = (int)DataTypeParser.Parse(txtConBase.Text, typeof(int), 0),
                    ConHeight = (int)DataTypeParser.Parse(txtConHeight.Text, typeof(int), 0),
                    ConThick = (int)DataTypeParser.Parse(txtConThick.Text, typeof(int), 0),
                    MinOrderQty = (int)DataTypeParser.Parse(txtMinOrderQty.Text, typeof(int), 0),
                    Volt = (int)DataTypeParser.Parse(txtVolt.Text, typeof(int), 0),
                    Plate = (int)DataTypeParser.Parse(txtPlate.Text, typeof(int), 0),
                    Amps = (float)DataTypeParser.Parse(txtAmps.Text, typeof(float), 0),
                    Acid = (float)DataTypeParser.Parse(txtAcid.Text, typeof(float), 0),
                    FreeConWeight = (float)DataTypeParser.Parse(txtFreeConWeight.Text, typeof(float), -1),
                    LeadWeight = (float)DataTypeParser.Parse(txtLeadWeight.Text, typeof(float), -1),
                    Remark = txtRemark.Text,
                    HasDiscount=chkDiscount.Checked
                };
                if (saveProduct.SubCategoryID == -1 || string.IsNullOrEmpty(saveProduct.ProductName))
                {
                    // show error msg
                    MessageBox.Show(string.Format(Resource.errRequiredFields + "\n - {0}\n - {1}", Resource.SubCategory, Resource.ProductName),
                        Resource.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int affectedRows = 0;
                if (_mdProduct == null) // add a new product
                {
                    affectedRows = productSaver.Add(saveProduct, conn);
                }
                else // update an existing product
                {
                    // set product id for update condition
                    saveProduct.ID = _mdProduct.ID;
                    affectedRows = productSaver.UpdateByID(saveProduct, conn);
                }
                // if succeeded, handle to reload products onto DataGridView from parent caller 
                if (affectedRows > 0)
                {
                    ProductSaveEventArgs productSaveEventArgs = new ProductSaveEventArgs(true);
                    ProductSavedHandler(this, productSaveEventArgs);

                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    this.Close();
                }
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor for a new product to be added
        /// </summary>
        public frmProduct()
        {
            InitializeComponent();
            // configure logger 
            XmlConfigurator.Configure();
            // load and bind data
            LoadNBindData();
        }

        /// <summary>
        /// Constructor for an existing product to be modified
        /// </summary>
        /// <param name="mdProduct">Product to be modified</param>
        /// <param name="brandID">Brand ID of mdProduct</param>
        /// <param name="categoryID">Category ID of mdProduct</param>
        public frmProduct(Product mdProduct, string brandID, string categoryID)
            : this()
        {
            txtProductCode.Enabled = false;
            this._mdProduct = mdProduct;
            this._brandID = brandID;
            this._categoryID = categoryID;
            // bind data to be modified
            BindModifyData();
        }
        #endregion

        #region Inner Class
        public class ProductSaveEventArgs : EventArgs
        {
            private bool _needToReloadProducts;
            public ProductSaveEventArgs(bool needToReloadProducts)
            {
                this._needToReloadProducts = needToReloadProducts;
            }
            public bool NeedToReloadProducts
            {
                get { return this._needToReloadProducts; }
            }
        }
        #endregion

        #region Validate Numberic

        private void txtNoPerPack_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtMinOrderQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtConLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtConBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtConHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtVolt_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtConThick_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtPlate_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void txtAmps_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            if (e.KeyChar == Delete)
                e.Handled = false;
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

        }

        private void txtFreeConWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            if (e.KeyChar == Delete)
                e.Handled = false;
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void txtAcid_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            if (e.KeyChar == Delete)
                e.Handled = false;
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        private void txtLeadWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            if (e.KeyChar == Delete)
                e.Handled = false;
            else if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }

        #endregion


        private void txtProductCode_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            foreach (DataRow row in productTbl.Rows)
            {
                if (row["ProductCode"].ToString() == txtBox.Text)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtBox, "Product Code already exist");
                }
            }

        }

        private void txtProductCode_Validated(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            errorProvider1.SetError(txtBox, string.Empty);
        }

        private void txtAcid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

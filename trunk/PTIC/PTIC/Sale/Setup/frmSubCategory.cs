using System;
using System.Data;using PTIC.Common;
using System.Windows.Forms;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using PTIC.VC;
using log4net;
using log4net.Config;
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.Common;

namespace PTIC.Sale.Setup
{
    public partial class frmSubCategory : Form
    {
        SubCategory subcategory = new SubCategory();
        DataTable categoryTbl = new DataTable();
        DataTable subcategoryTbl = new DataTable();
        SubCategoryBL subcategoryBL = new SubCategoryBL();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmSubCategory));
        int BrandID=0;

    public frmSubCategory()
        {
            InitializeComponent();
            // configure logger 
            XmlConfigurator.Configure();
            // load and bind data
            LoadNBindData();
        }

        public frmSubCategory(SubCategory subcategroy, int brandid)
        {
            InitializeComponent();
            this.subcategory = subcategroy;
            BrandID = brandid;
            LoadNBindData();
        }

        #region Private Methods              
        private void LoadNBindData()
        {
            DataSet ds = new DataSet();
            BindingSource bdBrand = new BindingSource();
            BindingSource bdCategory = new BindingSource();
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                DataTable dtBrand = new BrandBL().GetOwnBrands().Copy(); // make copy to be added into a single dataset
                DataTable dtCategory = new CategoryBL().GetAll().Copy(); // make copy to be added into a single dataset
                subcategoryTbl = subcategoryBL.GetAll();
                // add three datatables into a single dataset
                ds.Tables.Add(dtBrand);
                ds.Tables.Add(dtCategory);
                
                // create data relations among three tables
                DataRelation relBrand_Category = new DataRelation("Brand_Category",
                    dtBrand.Columns["BrandID"], dtCategory.Columns["BrandID"],false);
                ds.Relations.Add(relBrand_Category);
                
                /** relation between Brand and Category **/
                bdBrand.DataSource = ds;
                bdBrand.DataMember = dtBrand.TableName;

                bdCategory.DataSource = bdBrand;
                bdCategory.DataMember = "Brand_Category";
                
               // bind binding list to each combo datasource
                cboBrand.DataSource = bdBrand;
                cboCategory.DataSource = bdCategory;
                              
              
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

        private void BindData()
        { //Bind into Component
            cboBrand.SelectedValue = BrandID;
            DataRowView rowCat =cboCategory.SelectedValue as DataRowView;
            rowCat["BrandID"] = subcategory.CategoryID;
            txtSubCat.Text = subcategory.SubCategoryName;
            txtRemark.Text = subcategory.Remark;
        }
        #endregion

        #region Event Handler        
        private void frmSubCategory_Load(object sender, EventArgs e)
        {
            // BindData into frmSubCategory
            if (subcategory.ID != 0)
            {
                BindData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = null;
            bool name_duplicate = false;
            int affectedrow = 0;
            if (cboCategory.SelectedValue == null)
            {
                ToastMessageBox.Show("ထုတ္ကုန္အမ်ိဳးအစား ေရြးပါ");
            }
            else if (txtSubCat.Text == "" || txtSubCat.Text == null)
            {
                ToastMessageBox.Show("ထုတ္ကုန္အမ်ိဳးအစားခဲြ ကိုျဖည့္ပါ");
            }
            else
            {
                DataRowView row = (DataRowView)cboCategory.SelectedValue;
                int brandID = (int)DataTypeParser.Parse(cboBrand.SelectedValue,typeof(int),0);

                subcategory.CategoryID = (int)DataTypeParser.Parse(row.Row.ItemArray[0].ToString(), typeof(int), -1);
                subcategory.SubCategoryName = txtSubCat.Text.Trim();
                subcategory.Remark = txtRemark.Text.Trim();
                foreach(DataRow dr in subcategoryTbl.Rows)
                {
                    int categoryIdDb = 0;
                    int.TryParse(row["CategoryID"] + "", out categoryIdDb);
                    int brandIdDb = 0;  
                    int.TryParse(dr["BrandID"]+"",out brandIdDb);
                    if (subcategory.CategoryID == categoryIdDb && brandIdDb == brandID)
                    {
                        //show error
                        name_duplicate = true;
                    }

                    //if (subcategory.SubCategoryName.Equals(dr["SubCategoryName"]) && subcategory.CategoryID == (int)DataTypeParser.Parse(row["CategoryID"], typeof(int), 0) && (int)DataTypeParser.Parse(dr["BrandID"], typeof(int), 0) == brandID)
                    //{
                    //    //show error
                    //    name_duplicate = true;
                    //}


                }

                if (name_duplicate && subcategory.ID ==0)
                {
                    ToastMessageBox.Show("ထုတ္ကုန္အမ်ိဳးအစားခဲြ ရွိၿပီးသား ျဖစ္ပါသည္။");
                }
                else
                {
                    try
                    {
                        conn = DBManager.GetInstance().GetDbConnection();

                        if (subcategory.ID != 0)
                        {
                            affectedrow = subcategoryBL.Update(subcategory, conn);
                        }
                        else
                        {
                            affectedrow = subcategoryBL.Insert(subcategory, conn);
                        }
                        if (affectedrow > 0)
                        {
                            ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                        }

                    }
                    catch (SqlException sqle)
                    {
                        _logger.Error(sqle);
                    }
                    finally
                    {
                        txtSubCat.Text = "";
                        txtRemark.Text = "";
                        DBManager.GetInstance().CloseDbConnection();
                        this.Close();
                    }
                }
            }
        }
        #endregion

        private void lblSetup_Click(object sender, EventArgs e)
        {

        }
    }
}

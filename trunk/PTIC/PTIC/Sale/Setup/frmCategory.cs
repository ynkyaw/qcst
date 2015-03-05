using System;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Windows.Forms;
using PTIC.Sale.Entities;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.VC.Util;
using log4net;
using log4net.Config;
using PTIC.Sale.BL;

namespace PTIC.Sale.Setup
{
    public partial class frmCategory : Form
    {        
        Category category = new Category();
        CategoryBL categoryBL = new CategoryBL();
        DataTable categoryTbl = null;
        DataTable brandTbl = new DataTable();
        BrandBL brandBL = new BrandBL();
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmCategory));

        public frmCategory()
        {
            InitializeComponent();
            // configure logger 
            XmlConfigurator.Configure();
            // load and bind data
            LoadData();
            LoadCombo();
        }

        ////public frmCategory(frmCategorys frmCategorys)
        ////{
        ////    InitializeComponent();
        ////    this.frmCategorys = frmCategorys;
            
        ////}

        public frmCategory(Category category)
        {
            InitializeComponent();
            this.category = category;
            LoadData();
            LoadCombo();
        }

        private void LoadData()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                brandTbl= brandBL.GetOwnBrands();
                categoryTbl = categoryBL.GetAll();
            }
            catch (SqlException sqle)
            {
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void LoadCombo()
        {  //BindData from datagridview into each feild container
            cboBrand.DataSource = brandTbl;
        }

        private void BindData()
        { //Bind into Component
            cboBrand.SelectedValue = category.BrandID;
            txtProductCat.Text = category.CategoryName;
            txtRemark.Text = category.Remark;
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
            if(cboBrand.SelectedValue==null){
                ToastMessageBox.Show("ကုန္အမွတ္တံဆိပ္ ေရြးပါ");
            }
            else if (txtProductCat.Text == "" || txtProductCat.Text==null)
            {
                ToastMessageBox.Show("ထုတ္ကုန္အမ်ိဳးအစား ကိုျဖည့္ပါ");
            }
            else{
                category.BrandID = (int)DataTypeParser.Parse(cboBrand.SelectedValue.ToString(), typeof(int), null);
                category.CategoryName = txtProductCat.Text.Trim();
                category.Remark = txtRemark.Text.Trim();

                foreach(DataRow row in categoryTbl.Rows)
                {
                    if (category.CategoryName.Equals(row["CategoryName"]) && category.BrandID == (int)DataTypeParser.Parse(row["BrandID"], typeof(int), 0))
                    {
                        //show error
                        name_duplicate = true;
                    }
                }

                if (name_duplicate && category.ID ==0)
                {
                    ToastMessageBox.Show("ထုတ္ကုန္အမ်ိဳးအစား ရွိၿပီးသား ျဖစ္ပါသည္။");
                }
                else
                {
                    try
                    {
                        conn = DBManager.GetInstance().GetDbConnection();
                        
                        if (category.ID != 0)
                        {
                            affectedrow = categoryBL.Update(category, conn);
                        }
                        else
                        {
                            affectedrow = categoryBL.Insert(category, conn);
                        }
                        if (affectedrow > 0)
                        {
                            txtProductCat.Text = "";
                            txtRemark.Text = "";
                            ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                        }

                    }
                    catch (SqlException sqle)
                    {
                        _logger.Error(sqle);
                    }
                    finally
                    {
                        DBManager.GetInstance().CloseDbConnection();
                        this.Close();
                    }
                }
            }
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            if (category.ID != 0)
            {
                BindData();
            }
        }
    }
}

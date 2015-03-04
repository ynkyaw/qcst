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
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using PTIC.VC;
using System.Collections;
using PTIC.Sale.BL;
using PTIC.Sale.DA;

namespace PTIC.Sale.Setup
{
    public partial class frmBrand : Form
    {
        Brand brand = new Brand();
        BrandBL brandBL = new BrandBL();
        private DataTable brandTbl;

        public frmBrand()
        {
            InitializeComponent();
            dtpConfirmDate.Format = DateTimePickerFormat.Custom;
            dtpConfirmDate.CustomFormat = "dd-MMM-yyyy";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "dd-MMM-yyyy";
            LoadData();
        }

        public frmBrand(Brand brand)
        {
            InitializeComponent();
            this.brand = brand;
            LoadData();
        }

        public void LoadData()
        {            
            try
            {                                
                brandTbl = BrandDA.SelectAllByIsOwnBrand(true);
            }
            catch (SqlException sqle)
            {

            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void BindData()
        {
            //BindData from datagridview into each feild container

            txtBrandName.Text = brand.BrandName;
            txtRemark.Text = brand.Remark;
            dtpConfirmDate.Value = (DateTime)DataTypeParser.Parse(brand.ConfirmDate.ToString(), typeof(DateTime), DateTime.Now);
            dtpStartDate.Text = brand.StartDate.ToString();
            chkIsOwnBrand.Checked = brand.IsOwnBrand;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {   // Saving Data for Insert and Update
            bool name_duplicate = false;
            if (String.IsNullOrEmpty(txtBrandName.Text))
            {
                ToastMessageBox.Show("အမွတ္တံဆိပ္အမည္ ကိုျဖည့္ပါ");
            }
            else
            {
                int effectrow = 0;

                brand.BrandName = String.IsNullOrEmpty(txtBrandName.Text) ? "" : txtBrandName.Text.Trim();
                brand.Remark = String.IsNullOrEmpty(txtRemark.Text) ? "" : txtRemark.Text;
                brand.ConfirmDate = (DateTime)DataTypeParser.Parse(dtpConfirmDate.Text, typeof(DateTime), null);
                brand.StartDate = (DateTime)DataTypeParser.Parse(dtpStartDate.Text, typeof(DateTime), null);
                brand.IsOwnBrand = true;

                foreach (DataRow row in brandTbl.Rows)
                {
                    if (brand.BrandName.Equals(row["BrandName"]))
                    {
                        //show error
                        name_duplicate = true;
                    }
                }
                if (name_duplicate && brand.ID == 0)
                {
                    ToastMessageBox.Show("အမွတ္တံဆိပ္ ရွိၿပီးသား ျဖစ္ပါသည္။");
                }
                else
                {
                    SqlConnection conn = null;
                    try
                    {
                        conn = DBManager.GetInstance().GetDbConnection();

                        if (brand.ID != 0)
                        {
                            effectrow = brandBL.UpdateByID(brand, conn);
                        }
                        else
                        {
                            effectrow = brandBL.Insert(brand, conn);
                        }
                        if (effectrow > 0)
                        {
                            ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                        }

                    }
                    catch (SqlException sqle)
                    {
                        // To do
                    }
                    finally
                    {
                        txtBrandName.Text = "";
                        txtRemark.Text = "";
                        chkIsOwnBrand.Checked = false;
                        DBManager.GetInstance().CloseDbConnection();
                        this.Close();
                    }
                }
            }
        }

        private void frmBrand_Load(object sender, EventArgs e)
        { // BindData into frmBrand
            dtpConfirmDate.MaxDate = DateTime.Now;
            dtpStartDate.MaxDate = DateTime.Now;
            if (brand.ID != 0)
            {
                BindData();
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            //UIManager.MdiChildOpenForm(typeof(frmSetupPage));
            //this.Close();
        }
    }

}


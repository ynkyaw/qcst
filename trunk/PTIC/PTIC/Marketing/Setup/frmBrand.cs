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
using PTIC.Sale.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using PTIC.Util;

namespace PTIC.VC.Marketing.Setup
{
    public partial class frmBrand : Form
    {
        Brand brand = new Brand();
        BrandBL brandBL = new BrandBL();

        public frmBrand()
        {
            InitializeComponent();            
        }

        //public frmBrand(frmBrands frmBrands)
        //{
        //    InitializeComponent();
        //    this.frmBrands = frmBrands;
        //}

        public frmBrand(Brand brand,string CompanyName)
        {
            InitializeComponent();
            txtCompany.Text = CompanyName;
            this.brand = brand;
            txtBrandName.Enabled = false;
        }

        //private void LoadData()
        //{
        //    SqlConnection conn = null;
        //    try
        //    {
        //        conn = DBManager.GetInstance().GetDbConnection();
        //        // brandTbl= brandBL.GetAllByBrandID(id,conn);
        //    }
        //    catch (SqlException sqle)
        //    {
        //    }
        //    finally
        //    {
        //        DBManager.GetInstance().CloseDbConnection();
        //    }
        //}

        private void BindData()
        {  
            //BindData from datagridview into each feild container
            txtBrandName.Text = brand.BrandName;
            txtCptProduct.Text = (string)DataTypeParser.Parse(brand.CompetitorProduct.ToString(), typeof(string), String.Empty);
            txtRemark.Text = brand.Remark;
            chkIsOwnBrand.Checked = brand.IsOwnBrand;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {   // Saving Data for Insert and Update
            if (String.IsNullOrEmpty(txtBrandName.Text))
            {
                ToastMessageBox.Show("အမှတ်တံဆိပ် ဖြည့်ပါ။");
            }
            else
            {
                int effectrow = 0;
                SqlConnection conn = null;
                BrandBL saver = null;
                try
                {
                    saver = new BrandBL();
                    conn = DBManager.GetInstance().GetDbConnection();
                    brand.BrandName = String.IsNullOrEmpty(txtBrandName.Text) ? "" : txtBrandName.Text;
                    brand.CompetitorProduct = String.IsNullOrEmpty(txtCptProduct.Text) ? "" : txtCptProduct.Text;
                    brand.Company = (string)DataTypeParser.Parse(txtCompany.Text, typeof(string), String.Empty);
                    brand.Phone1 = (string)DataTypeParser.Parse(txtPhone1.Text, typeof(string), String.Empty);
                    brand.Phone2 = (string)DataTypeParser.Parse(txtPhone2.Text, typeof(string), String.Empty);
                    brand.Remark = String.IsNullOrEmpty(txtRemark.Text) ? "" : txtRemark.Text;
                    brand.IsOwnBrand = chkIsOwnBrand.Checked;
                    if (brand.ID != 0)
                    {
                        effectrow = saver.UpdateCompetitorProductByBrandID(brand, conn);
                        if (!saver.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(saver.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                "CompetitorBrand",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }  
                    }
                    else
                    {
                        effectrow = saver.InsertCompetitor(brand, conn);
                        if (!saver.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(saver.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                "CompetitorBrand",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);                           
                        }  
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
                    if (effectrow > 0)
                    {
                        txtBrandName.Text = "";
                        txtCptProduct.Text = "";
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


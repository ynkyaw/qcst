using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Common;
using PTIC.VC;
using PTIC;
using PTIC.VC.Marketing;
using PTIC.VC.Util;
using System.Data.SqlClient;


namespace PITC.VC.Marketing
{
    public partial class Frm_APProductRegister : Form
    {
        int id = 0;
        APMaterialVO newvo = new APMaterialVO();
        public Frm_APProductRegister()
        {
            InitializeComponent();          
        }
        public Frm_APProductRegister(APMaterialVO vo)       
        {
            InitializeComponent();
            this.id = vo.Id;
            this.newvo = vo;
            loadCombo();
            cboSubCategory.SelectedValue = newvo.APSubCategoryID;
            txtAPMaterialName.Text = vo.APMaterialName;
            txtSize.Text = vo.Size;
            rtxtDescription.Text = vo.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            APMaterialBUS apMaterialBUS = new APMaterialBUS();
            APMaterialVO apMaterialVO = new APMaterialVO();

            if (this.id != 0)
            {
                apMaterialVO.Id = this.id;
            }
            apMaterialVO.APSubCategoryID = int.Parse(cboSubCategory.SelectedValue.ToString());
            apMaterialVO.APMaterialName = (string)DataTypeParser.Parse(txtAPMaterialName.Text, typeof(string), String.Empty);
            if (apMaterialVO.APMaterialName == String.Empty)
            {
                ToastMessageBox.Show("Please fill A && P SubCategory", Color.Red);
                return;
            }
            apMaterialVO.Description = rtxtDescription.Text;
            apMaterialVO.DateAdded = DateTime.Now.Date;
            apMaterialVO.LastModified = DateTime.Now.Date;
            apMaterialVO.IsDeleted = false;
            apMaterialVO.Size = txtSize.Text;
            apMaterialBUS.Create(apMaterialVO);
            ToastMessageBox.Show(Resource.msgSuccessfullySaved);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_APProductRegister_Load(object sender, EventArgs e)
        {
            loadCombo();
        }
        private void loadCombo()
        {
            DataSet ds = new DataSet();
          
            BindingSource bdAPCategory = new BindingSource();
            BindingSource bdAPSubCategory = new BindingSource();

             SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                DataTable dtAPSubCategory = new APSubCategoryDAO().SelectAll().Copy(); // make copy to be added into a single dataset
                DataTable dtAPCategory = new APCategoryDAO().SelectAll().Copy(); // make copy to be added into a single dataset

                // add two datatables into a single dataset
                ds.Tables.Add(dtAPCategory);
                ds.Tables.Add(dtAPSubCategory);

                // create data relations among three tables
                DataRelation relAPCategory_APSubCategory = new DataRelation("APCategory_APSubCategory",
                    dtAPCategory.Columns["ID"], dtAPSubCategory.Columns["APCategoryID"], false);
                ds.Relations.Add(relAPCategory_APSubCategory);

                /** relation between APCategory and APSubCategory **/
                bdAPCategory.DataSource = ds;
                bdAPCategory.DataMember = dtAPCategory.TableName;

                bdAPSubCategory.DataSource = bdAPCategory;
                bdAPSubCategory.DataMember = "APCategory_APSubCategory";
                           
                // bind binding list to each combo datasource
                cmbAPCategory.DataSource = bdAPCategory;
                cmbAPCategory.DisplayMember = "CategoryName";
                cmbAPCategory.ValueMember = "ID";

                cboSubCategory.DataSource = bdAPSubCategory;
                cboSubCategory.DisplayMember = "APSubCategoryName";
                cboSubCategory.ValueMember = "ID";
                cboSubCategory.SelectedValue = newvo.APSubCategoryID;
            }
            catch (SqlException sqle)
            {
               // _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }          
           
        }

        private void lblSetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
            this.Close();
        }
    }
}

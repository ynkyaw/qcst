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
using PTIC.Sale.BL;
using PTIC.Common;

namespace PTIC.Sale.Setup
{
    public partial class frmCategories : Form
    {
        DataTable brandTbl = null;  // Brand Data Table
      //  DataTable brandCatTbl = null; 
        DataTable categoryTbl = null;  // Cateory DataTable
        BrandBL brandBL = new BrandBL();
        CategoryBL categroyBL = new CategoryBL();
        Category category = new Category();
        SqlConnection conn=null;

        public frmCategories()
        {
            InitializeComponent();
            LoadData();
            BindData();
        }

        public void LoadData()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                brandTbl = brandBL.GetOwnBrands();
                categoryTbl = categroyBL.GetAll();
            }
            catch (SqlException sqle)
            {

            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        public void BindData()
        {
            #region Bind DatagridView
            //Set AutoGenerateColumns False
            dgvsetupcategory.AutoGenerateColumns = false;
            
            dgvsetupcategory.DataSource = categoryTbl;
            #endregion                       
        }
             
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvsetupcategory.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {               
                category.ID = (int)DataTypeParser.Parse(dgvsetupcategory.SelectedCells[0].Value.ToString(), typeof(int), null);
                int Index = dgvsetupcategory.CurrentRow.Index;
                dgvsetupcategory.Rows.RemoveAt(Index);
                try
                {
                    conn = DBManager.GetInstance().GetDbConnection();
                    categroyBL.Delete(category, conn);
                }
                catch (SqlException sqle)
                {

                }
                finally
                {
                    DBManager.GetInstance().CloseDbConnection();
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);                   
                }                
            }              
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //UIManager.OpenForm(typeof(frmCategory));
            frmCategory frmCategory = new frmCategory();
            UIManager.OpenForm(frmCategory);
            LoadData();
            BindData();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
            this.Close();
        }

        private void dgvsetupcategory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvsetupcategory.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvsetupcategory.SelectedRows.Count == 1)
            {
                //int id = (int)DataTypeParser.Parse(dgvsetupbrand.SelectedCells[0].Value.ToString(), typeof(int), null);
                category.ID = (int)DataTypeParser.Parse(dgvsetupcategory.SelectedCells[0].Value.ToString(), typeof(int), null);
                category.CategoryName = dgvsetupcategory.SelectedCells[3].Value.ToString();
                category.Remark = dgvsetupcategory.SelectedCells[4].Value.ToString();
                category.BrandID = (int)DataTypeParser.Parse(dgvsetupcategory.SelectedCells[5].Value.ToString(), typeof(int), null);
                
                frmCategory frmCategory = new frmCategory(category);
                UIManager.OpenForm(frmCategory);
                LoadData();
                BindData();
            }
            else
            {
                ToastMessageBox.Show(Resource.errSelectModifyRecord);
            }
        }

        private void dgvsetupcategory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SendKeys.Send("{down}");
            SendKeys.Send("{right}");
        }

    }
}

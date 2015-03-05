/* Author   :   Aung Ko Ko
    Date      :   14 Feb 2014
    Description :   Setup Product Sub Category
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using WeifenLuo.WinFormsUI.Docking;
using PTIC.VC;
using PTIC.Sale.BL;
using PTIC.Common;

namespace PTIC.Sale.Setup
{
    public partial class frmSubCategories : Form
    {
        DataTable subcatTbl = null;
        DataTable categoryTbl = null;
        SubCategoryBL subcategoryBL = new SubCategoryBL();
        CategoryBL categoryBL = new CategoryBL();
        SubCategory subcategory = new SubCategory();
        SqlConnection conn = null;
        
        public frmSubCategories()
        {
            InitializeComponent();
            LoadData();
            BindData();
                //      UIManager.setRowNumber(dgvsetupsubcategory);
          
        }
        
        public void LoadData()  //Load SubCategory Data for Grid and Category Data for Combo
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                subcatTbl = subcategoryBL.GetAll();
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

        public void BindData()   // Bind Data in datagridview and combo
        {
            #region Bind DatagridView
            //Set AutoGenerateColumns False
            dgvsetupsubcategory.AutoGenerateColumns = false;
            
            dgvsetupsubcategory.DataSource = subcatTbl;
            #endregion                      
        }

        #region Event Handler       
       
        private void btnDelete_Click(object sender, EventArgs e)
        { // Delete Row
            if (dgvsetupsubcategory.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            if (MessageBox.Show("Are you sure want to delete Selected Row?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                subcategory.ID = (int)DataTypeParser.Parse(dgvsetupsubcategory.SelectedCells[SubCatID.Index].Value.ToString(), typeof(int), null);
                int Index = dgvsetupsubcategory.CurrentRow.Index;
                dgvsetupsubcategory.Rows.RemoveAt(Index);
                try
                {
                    conn = DBManager.GetInstance().GetDbConnection();
                    subcategoryBL.Delete(subcategory, conn);
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
        { // Insert
            //UIManager.OpenForm(typeof(frmSubCategory));
            frmSubCategory frmSubCategory = new frmSubCategory();
            UIManager.OpenForm(frmSubCategory);
            LoadData();
            BindData();
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        { // Update
            if (dgvsetupsubcategory.SelectedRows.Count == 1)
            {
                //int id = (int)DataTypeParser.Parse(dgvsetupbrand.SelectedCells[0].Value.ToString(), typeof(int), null);
               // subcategory.ID = (int)DataTypeParser.Parse(dgvsetupsubcategory.SelectedCells[1].Value.ToString(), typeof(int), null);
                subcategory.ID = (int)DataTypeParser.Parse(dgvsetupsubcategory.SelectedCells[SubCatID.Index].Value, typeof(int), 0);
                subcategory.SubCategoryName = dgvsetupsubcategory.SelectedCells[ProductSubCat.Index].Value.ToString();
                subcategory.Remark = dgvsetupsubcategory.SelectedCells[Remark.Index].Value.ToString();
                subcategory.CategoryID = (int)DataTypeParser.Parse(dgvsetupsubcategory.SelectedCells[ProductCat.Index].Value, typeof(int), 0);
                int BrandID = (int)DataTypeParser.Parse(dgvsetupsubcategory.SelectedCells[colBrandID.Index].Value.ToString(), typeof(int), null);
                frmSubCategory frmSubCategory = new frmSubCategory(subcategory,BrandID);
                UIManager.OpenForm(frmSubCategory);
                LoadData();
                BindData();
            }
            else
            {
                ToastMessageBox.Show(Resource.errSelectModifyRecord);
            }
        }       

        private void lblSetup_Click(object sender, EventArgs e)
        { // Back
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
            this.Close();
        }

        private void dgvsetupsubcategory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        { // Numbering
            this.dgvsetupsubcategory.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        #endregion

    }
}

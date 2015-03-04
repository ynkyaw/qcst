using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC;
using System.Data.SqlClient;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using PTIC.VC;
using PTIC.Sale.BL;
using PTIC.Common;

namespace PTIC.Sale.Setup
{
    public partial class frmBrandList : Form
    {
        DataTable brandTbl = null;
        Brand brand = new Brand();
        public frmBrandList()
        {
            InitializeComponent();
            LoadData();
            BindData();
        }

        #region Private Method
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

        public void BindData()
        {
            //Set AutoGenerateColumns False
            dgvsetupbrand.AutoGenerateColumns = false;

            dgvsetupbrand.DataSource = brandTbl;
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBrand frmBrand = new frmBrand();
            UIManager.OpenForm(frmBrand);
            LoadData();
            BindData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvsetupbrand.SelectedRows.Count == 1)
            {
                //int id = (int)DataTypeParser.Parse(dgvsetupbrand.SelectedCells[0].Value.ToString(), typeof(int), null);
                brand.ID = (int)DataTypeParser.Parse(dgvsetupbrand.SelectedCells[0].Value.ToString(), typeof(int), -1);
                brand.BrandName = (string)DataTypeParser.Parse(dgvsetupbrand.SelectedCells[2].Value.ToString(), typeof(string), null);
                brand.ConfirmDate = (DateTime)DataTypeParser.Parse(dgvsetupbrand.SelectedCells[3].Value.ToString(), typeof(DateTime), null);
                brand.StartDate = (DateTime)DataTypeParser.Parse(dgvsetupbrand.SelectedCells[4].Value.ToString(), typeof(DateTime), null);
                brand.Remark = (string)DataTypeParser.Parse(dgvsetupbrand.SelectedCells[5].Value.ToString(), typeof(string), null);

                if (brand.ConfirmDate >= DateTime.Now)
                {
                    ToastMessageBox.Show("System DateTime is Wrong", Color.Red);
                    return;
                }
                else
                {
                    frmBrand frmBrand = new frmBrand(brand);
                    UIManager.OpenForm(frmBrand);
                    LoadData();
                    BindData();
                }
            }
            else
            {
                ToastMessageBox.Show(Resource.errSelectModifyRecord);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvsetupbrand.SelectedRows.Count < 1)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete);
                return;
            }
            if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                brand.ID = (int)DataTypeParser.Parse(dgvsetupbrand.SelectedCells[0].Value.ToString(), typeof(int), null);
                int Index = dgvsetupbrand.CurrentRow.Index;
                dgvsetupbrand.Rows.RemoveAt(Index);
                SqlConnection conn = null;
                try
                {
                    conn = DBManager.GetInstance().GetDbConnection();
                    new BrandBL().DeleteByID(brand, conn);
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

        private void dgvsetupbrand_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvsetupbrand.Rows[e.RowIndex].Cells[1].Value = (e.RowIndex + 1).ToString();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
            this.Close();
        }

        private void frmBrandList_Load(object sender, EventArgs e)
        {
            LoadData();
            BindData();
        }
    }
}

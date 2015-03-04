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


namespace PITC.VC.Marketing
{
    public partial class Frm_APSubCategory : Form
    {
        int id=0;
        public Frm_APSubCategory()
        {
            InitializeComponent();
            loadCombo();
            LoadGridData();
        }
        private void loadCombo()
        {
            cboAPCategory.DataSource = new APCategoryDAO().SelectAll();
            cboAPCategory.DisplayMember = "CategoryName";
            cboAPCategory.ValueMember = "ID";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.id = 0;
            SaveData();
            txtSubCategory.Text = "";
            LoadGridData();
            btnEdit.Enabled = false;
        }
        private void SaveData()
        {
            APSubCategoryBUS apSubCategoryBUS = new APSubCategoryBUS();
            APSubCategoryVO apSubCategoryVO = new APSubCategoryVO();
            if (this.id != 0)
            {
                apSubCategoryVO.Id = this.id;
            }
            apSubCategoryVO.APCategoryID = int.Parse(cboAPCategory.SelectedValue.ToString());
            apSubCategoryVO.ApSubCategoryName = (string)DataTypeParser.Parse(txtSubCategory.Text.ToString(), typeof(string), String.Empty);
            if (apSubCategoryVO.ApSubCategoryName == String.Empty)
            {
                ToastMessageBox.Show("Please fill A && P SubCategory", Color.Red);
                return;
            }
            apSubCategoryVO.DateAdded = DateTime.Now.Date;
            apSubCategoryVO.LastModified = DateTime.Now.Date;
            apSubCategoryVO.IsDeleted = false;
            apSubCategoryBUS.Create(apSubCategoryVO);
            ToastMessageBox.Show(Resource.msgSuccessfullySaved);
        }
        private DataGridViewRow initilizeRow()
        {
            DataGridViewRow row = new DataGridViewRow();
            for (int i = 0; i < dgvAPSubCategory.ColumnCount; i++)
            {
                if (i == 4)
                {
                    row.Cells.Add(new DataGridViewCheckBoxCell());
                }
                else
                {
                    row.Cells.Add(new DataGridViewTextBoxCell());
                }
            }
            return row;
        }
        private void LoadGridData()
        {
            dgvAPSubCategory.Rows.Clear();
            int i = 1;
            DataTable dt = new APSubCategoryDAO().SelectAll();
            foreach (DataRow dr in dt.Rows)
            {
                DataGridViewRow row = initilizeRow();
                row.Cells[0].Value = dr["ID"].ToString();
                row.Cells[1].Value = i++;
                APCategoryVO vo = new APCategoryDAO().GetByID(int.Parse(dr["APCategoryID"].ToString()));
                row.Cells[2].Value = vo.CategoryName;
                row.Cells[3].Value = dr["APSubCategoryName"].ToString();
                if (dr["IsDeleted"].ToString() == "True")
                {
                    row.Cells[4].Value = true;
                }
                else
                    row.Cells[4].Value = false;
                dgvAPSubCategory.Rows.Add(row);
            }
        }

        private void Frm_APSubCategory_Load(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SaveData();
            txtSubCategory.Text = "";
            LoadGridData();
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }
        private bool checkValidate()
        {
            if (txtSubCategory.Text == "")
            {
                MessageBox.Show("A-P အမ်ိဳးအစား ထည့္ပါ။");
                return false;
            }
            return true;
        }
        private void dgvAPSubCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            this.id = int.Parse(dgvAPSubCategory.SelectedRows[0].Cells["SubCatID"].Value.ToString());
             APSubCategoryVO vo = new APSubCategoryDAO().GetByID(id);
            txtSubCategory.Text = vo.ApSubCategoryName;
            cboAPCategory.SelectedValue = vo.APCategoryID;
            //btnSave.Enabled = false;
        }

        private void lblSetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
            this.Close();
        }

        private void dgvAPSubCategory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           
        }

        private void dgvAPSubCategory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvAPSubCategory.Rows[e.RowIndex].Cells[No.Index].Value = (e.RowIndex + 1).ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            APSubCategoryBUS APSubCategoryBus = new APSubCategoryBUS();
            APSubCategoryVO vo = new APSubCategoryVO();
            if (dgvAPSubCategory.SelectedRows.Count < 0)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete); return;
            }
            else
            {
                if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    vo.Id = int.Parse(dgvAPSubCategory.SelectedRows[0].Cells["SubCatID"].Value.ToString());
                int affectedrow = APSubCategoryBus.Delete(vo);
                if (affectedrow > 0)
                {
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                    LoadGridData();
                }
                else
                {
                    MessageBox.Show(Resource.errCantDelete, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }      
        }

      
    }
}

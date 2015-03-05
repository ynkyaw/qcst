using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Common;
using PTIC.VC.Util;


namespace PTIC.VC.Marketing
{
    public partial class Frm_A_PCategory : Form
    {
        int id = 0;
        DateTime createdDate;
        public Frm_A_PCategory()
        {
            InitializeComponent();
            LoadGridData();   
        }

        public Frm_A_PCategory(int editId)
        {
            InitializeComponent();
            this.id = editId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.id = 0;
            saveData();
            txtCategory.Text = "";
            chkNonAP.Checked = false;
            LoadGridData();
            btnEdit.Enabled = false;
        }
        private void LoadGridData()
        {
            dgvAPCategory.Rows.Clear();
            int i = 1;
            DataTable dt = new APCategoryDAO().SelectAll();
            foreach (DataRow dr in dt.Rows)
            {
                DataGridViewRow row = initilizeRow();
                row.Cells[0].Value = dr["ID"].ToString();
                row.Cells[1].Value = i++;
                row.Cells[2].Value = dr["CategoryName"].ToString();
              //  row.Cells[3].Value = dr["IsNonAP"].ToString();
                row.Cells[3].Value = dr["IsDeleted"].ToString();
                dgvAPCategory.Rows.Add(row);
            }
        }

        private DataGridViewRow initilizeRow()
        {
            DataGridViewRow row = new DataGridViewRow();
            for (int i = 0; i < dgvAPCategory.ColumnCount; i++)
            {
                row.Cells.Add(new DataGridViewTextBoxCell());
            }
            return row;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            saveData();
            txtCategory.Text = String.Empty;
            chkNonAP.Checked = false;
            LoadGridData();
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }
        private void saveData()
        {
            APCategoryBUS categoryBUS = new APCategoryBUS();
            APCategoryVO categoryVO = new APCategoryVO();
            if (this.id != 0)
            {
                categoryVO.Id = this.id;
                categoryVO.LastModified = DateTime.Now.Date;
            }
            else 
            { 
                categoryVO.LastModified = DateTime.Now.Date; 
            }
            categoryVO.CategoryName = (string)DataTypeParser.Parse(txtCategory.Text.ToString(), typeof(string), String.Empty);
            categoryVO.IsNonAP = (bool)DataTypeParser.Parse(chkNonAP.Checked, typeof(bool), 0);
            if (categoryVO.CategoryName == String.Empty)
            {
                ToastMessageBox.Show("Please fill A && P Category", Color.Red);
                return;
            }
            categoryVO.DateAdded = DateTime.Parse(DateTime.Now.Date.ToShortDateString());
            categoryBUS.Create(categoryVO);
            ToastMessageBox.Show(Resource.msgSuccessfullySaved);
            txtCategory.Text = "";
            LoadGridData();
        }

        private void dgvLeave_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            if (dgvAPCategory.SelectedRows.Count == 1)
            {
                int categoryID = int.Parse(dgvAPCategory.SelectedRows[0].Cells["APCatID"].Value.ToString());
                APCategoryVO vo = new APCategoryDAO().GetByID(categoryID);
                txtCategory.Text = vo.CategoryName;
                chkNonAP.Checked = vo.IsNonAP;
                this.id = categoryID;
                btnSave.Enabled = false;
            }
        }

        private void lblSetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
            this.Close();
        }

        private void dgvAPCategory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void dgvAPCategory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvAPCategory.Rows[e.RowIndex].Cells[No.Index].Value = (e.RowIndex + 1).ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            APCategoryBUS APcategoryBus = new APCategoryBUS();
            APCategoryVO vo = new APCategoryVO();
            if (dgvAPCategory.SelectedRows.Count < 0)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete); return;
            }
            else
            {
                if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                vo.Id = int.Parse(dgvAPCategory.SelectedRows[0].Cells["APCatID"].Value.ToString());
                int affectedrow = APcategoryBus.Delete(vo);
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

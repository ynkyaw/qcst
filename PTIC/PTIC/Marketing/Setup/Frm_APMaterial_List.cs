using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Common;
using PTIC;
using PTIC.VC.Marketing;
using PTIC.VC.Util;
using PTIC.Util;
using System.Collections;
using PTIC.VC;


namespace PITC.VC.Marketing
{
    public partial class Frm_APMaterial_List : Form
    {
        /// <summary>
        /// DataTable for Searching
        /// </summary>
        DataTable dtAPMaterial = null;

        public Frm_APMaterial_List()
        {
            InitializeComponent();
            loadCombo();
        }

        private void Frm_APMaterial_List_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
           // DataTable dt = new APMaterialDAO().SelectAll();
            DataTable dt = new APMaterialDAO().SelectAllWithAPSubCat();
            this.dtAPMaterial = dt.Copy();
            dgvAPMaterial.AutoGenerateColumns = false;
            dgvAPMaterial.DataSource = dtAPMaterial;
            colSubCatID.DataPropertyName = "AP_SubCategoryID";
        //    dgvAPMaterial.Rows.Clear();
           // int i = 1;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    DataGridViewRow row = initilizeRow();
            //    row.Cells[0].Value = dr["AP_MaterialID"].ToString();
            //    //row.Cells[1].Value = i++;
            //    APSubCategoryVO vo = new APSubCategoryDAO().GetByID(int.Parse(dr["AP_SubCategoryID"].ToString()));
            //    row.Cells[2].Value = vo.ApSubCategoryName;
            //    row.Cells[3].Value = dr["APMaterialName"].ToString();
            //    row.Cells[4].Value = dr["Size"].ToString();
            //    row.Cells[5].Value = dr["Description"].ToString();
            //    row.Cells[6].Value = dr["AP_SubCategoryID"].ToString();
            ////    dgvAPMaterial.Rows.Add(row);
            //}
        }
        private DataGridViewRow initilizeRow()
        {
            DataGridViewRow row = new DataGridViewRow();
            for (int i = 0; i < dgvAPMaterial.ColumnCount; i++)
            {
                row.Cells.Add(new DataGridViewTextBoxCell());
            }
            return row;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Frm_APProductRegister form = new Frm_APProductRegister();
            form.ShowDialog();
            LoadData();
            loadCombo();
        }
        private void loadCombo()
        {
         //   cboMaterialName.DataSource = new APMaterialDAO().SelectAll();
            cboMaterialName.DataSource = new APMaterialDAO().SelectAllWithAPSubCat();
            cboMaterialName.DisplayMember = "APMaterialName";
            cboMaterialName.ValueMember = "AP_MaterialID";

            cmbAPSubCat.DataSource = new APSubCategoryDAO().SelectAll();
            cmbAPSubCat.DisplayMember = "APSubCategoryName";
            cmbAPSubCat.ValueMember = "ID";
        }

        private void lblFilter_Click(object sender, EventArgs e)
        {
            if (pnlFilter.Visible)
            {
                pnlFilter.Visible = false;
                lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
            }
            else
            {
                pnlFilter.Visible = true;

                lblFilter.Text = "▲ Hide Advance Search"; //Hide filter information";
            }
        }

        private void lblSetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
          {
              APMaterialVO apMaterial = new APMaterialVO();              
              apMaterial.APMaterialName =(string)DataTypeParser.Parse(dgvAPMaterial.CurrentRow.Cells[APMaterialName.Index].Value,typeof(string),String.Empty);
              apMaterial.APSubCategoryID =(int)DataTypeParser.Parse(dgvAPMaterial.CurrentRow.Cells["colSubCatID"].Value,typeof(int),string.Empty);
              apMaterial.Size =(string)DataTypeParser.Parse(dgvAPMaterial.CurrentRow.Cells[Size.Index].Value,typeof(string),String.Empty);
              apMaterial.Id =(int)DataTypeParser.Parse(dgvAPMaterial.CurrentRow.Cells["ID"].Value, typeof(int), 0);
              apMaterial.Description = (string)DataTypeParser.Parse(dgvAPMaterial.CurrentRow.Cells[Description.Index].Value, typeof(string), String.Empty);
              
              Frm_APProductRegister form = new Frm_APProductRegister(apMaterial);
              form.ShowDialog();
              LoadData();
              loadCombo();
          }

        private void dgvAPMaterial_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void dgvAPMaterial_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvAPMaterial.Rows[e.RowIndex].Cells[colNo.Index].Value = (e.RowIndex + 1).ToString();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            //  Auto-Generate Columns false
            dgvAPMaterial.AutoGenerateColumns = false;
            dgvAPMaterial.DataSource = this.dtAPMaterial;   // Bind Data
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Hashtable hashTmp = new Hashtable();
            int APMaterialID = (int)DataTypeParser.Parse(cboMaterialName.SelectedValue, typeof(int), -1);
            int APSubCatID = (int)DataTypeParser.Parse(cmbAPSubCat.SelectedValue, typeof(int), -1);
            dgvAPMaterial.AutoGenerateColumns = false;

            if (chkMaterial.Checked)
            {
                hashTmp.Add("AP_MaterialID", APMaterialID);
            }
            if (chkSubCat.Checked)
            {
                hashTmp.Add("AP_SubCategoryID", APSubCatID);
            }
            DataTable dtTmp = DataUtil.GetDataTableByExactFields(this.dtAPMaterial, hashTmp);
            //if (dtTmp == null)
            //{
            //    dgvAPMaterial.DataSource = dtTmp;
            //    return;
            //}          
            dgvAPMaterial.DataSource = dtTmp;
            colSubCatID.DataPropertyName = "AP_SubCategoryID";
            ID.DataPropertyName = "AP_MaterialID";
            //if (chkMaterial.Checked)
            //{
            //    DataTable dtTmp = DataUtil.GetDataTableBy(this.dtAPMaterial, "ID", APMaterialID);
            //    if (dtTmp == null) return;

            //    if (dtTmp.Rows.Count > 0)
            //    {
            //        dgvAPMaterial.AutoGenerateColumns = false;
            //        dgvAPMaterial.DataSource = dtTmp;
            //    }
            //}
            //else
            //{
            //    DataTable dtTmp = DataUtil.GetDataTableBy(this.dtAPMaterial, "APSubCategoryID", APSubCatID);
            //    if (dtTmp == null) return;

            //    if (dtTmp.Rows.Count > 0)
            //    {
            //        dgvAPMaterial.AutoGenerateColumns = false;
            //        dgvAPMaterial.DataSource = dtTmp;
            //    }
            //}

        }

        private void dgvAPMaterial_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvAPMaterial.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            APMaterialBUS APMaterialBus = new APMaterialBUS();
            APMaterialVO vo = new APMaterialVO();
            if (dgvAPMaterial.SelectedRows.Count < 0)
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete); return;
            }
            else
            {
                if (MessageBox.Show(Resource.qstSureToDeleteRow, Resource.deleteConfirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    vo.Id = int.Parse(dgvAPMaterial.SelectedRows[0].Cells["ID"].Value.ToString());
                int affectedrow = APMaterialBus.Delete(vo);
                if (affectedrow > 0)
                {
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                    LoadData();
                    loadCombo();
                }
                else
                {
                    MessageBox.Show(Resource.errCantDelete, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }           
        }



    }
}

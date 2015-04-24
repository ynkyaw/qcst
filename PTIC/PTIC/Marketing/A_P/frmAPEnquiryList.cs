using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Marketing.A_P;
using System.Data.SqlClient;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.Common;

namespace PTIC.VC.Marketing.A_P
{
    public partial class frmAPEnquiryList : Form
    {
        public frmAPEnquiryList()
        {
            InitializeComponent();
            dgvAPEnquiry.AutoGenerateColumns = false;
            LoadNBind();
            loadCombo();
        }

        #region Private Methods
        private void loadCombo()
        {
            //   cboMaterialName.DataSource = new APMaterialDAO().SelectAll();
            cmbPOSM.DataSource = new APMaterialDAO().SelectAllWithAPSubCat();
            cmbPOSM.DisplayMember = "APMaterialName";
            cmbPOSM.ValueMember = "AP_MaterialID";

            cmbAPSubCat.DataSource = new APSubCategoryDAO().SelectAll();
            cmbAPSubCat.DisplayMember = "APSubCategoryName";
            cmbAPSubCat.ValueMember = "ID";
        }

        private void LoadNBind()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();                
                dgvAPEnquiry.DataSource = new AP_EnquiryBL().GetAllEnquiry();
            }
            catch (SqlException Sqle)
            {                
                throw Sqle;
            }
        }
        #endregion

        private void btnNewEnquiry_Click(object sender, EventArgs e)
        {
            UIManager.OpenForm(typeof(frmAPEnquiry));
            LoadNBind();
        }

        private void btnEnquiry_Click(object sender, EventArgs e)
        {
            if (dgvAPEnquiry.Rows.Count < 1)
            {
                MessageBox.Show("There is no Enquiry.");
                return;
            }
            int APEnquiryID = (int)DataTypeParser.Parse(dgvAPEnquiry.CurrentRow.Cells[colAPEnquiryID.Index].Value,typeof(int),-1);
            DateTime EnquiryDate = (DateTime)DataTypeParser.Parse(dgvAPEnquiry.CurrentRow.Cells[colEnquiryDate.Index].Value,typeof(DateTime),DateTime.MinValue);            
            DateTime PlanDate = (DateTime)DataTypeParser.Parse(dgvAPEnquiry.CurrentRow.Cells[colPlanMonth.Index].Value.ToString(),typeof(DateTime),DateTime.MinValue);
            DateTime CloseDate = (DateTime)DataTypeParser.Parse(dgvAPEnquiry.CurrentRow.Cells[colEndDate.Index].Value.ToString(),typeof(DateTime),DateTime.MinValue);
            
            String COORemark = (String)DataTypeParser.Parse(dgvAPEnquiry.CurrentRow.Cells[colCOORemark.Index].Value, typeof(String), null);
            frmAPEnquiry APEnquiry = new frmAPEnquiry(EnquiryDate,CloseDate,COORemark,APEnquiryID,PlanDate);
            UIManager.OpenForm(APEnquiry);
            LoadNBind();
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

        private void dgvAPEnquiry_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmA_PMain));
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                DateTime StartDate = (DateTime)DataTypeParser.Parse(dtpEnquiryStart.Value, typeof(DateTime), DateTime.Now);
                DateTime EndDate = (DateTime)DataTypeParser.Parse(dtpEnquiryEnd.Value, typeof(DateTime), DateTime.Now);

                dgvAPEnquiry.DataSource = new AP_EnquiryBL().GetByStartDateEndDate(StartDate, EndDate);

            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadNBind();
        }
    }
}

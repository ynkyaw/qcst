using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.Common;

namespace PTIC.VC.Marketing.A_P
{
    public partial class frmPosmTransferList : Form
    {
        #region Constructors

        public frmPosmTransferList()
        {
            InitializeComponent();
            pnlFilter.Visible = false;
            lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
            LoadNBind();
        }

        #endregion

        #region Private Methods

        private void LoadNBind()
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                // Bind Data Into DataGridView
                dgvPosmTransferList.AutoGenerateColumns = false;
                dgvPosmTransferList.DataSource = new AP_TransferListBL().GetAll();

            }
            catch (SqlException Sqle)
            {
                throw Sqle;
            }
        }

        #endregion

        #region Events

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmA_PMain));
            this.Close();
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            frmPosmRequest _frmPosmRequest = new frmPosmRequest();
            UIManager.OpenForm(_frmPosmRequest);
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

        #endregion

        private void dgvPosmTransferList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();

                    //if ((int)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colAPEnquiryID.Index].Value, typeof(int), 0) != 0)
                    //{
                    //    dgv.Rows[r.Index].ReadOnly = true;
                    //    dgv.Rows[r.Index].Cells[colAccepted.Index].ReadOnly = false;
                    //}

                }
            }
        }

        private void btnGive_Click(object sender, EventArgs e)
        {
            if (dgvPosmTransferList.Rows.Count > 0)
            {
                //int? ToEmpID = (int?)DataTypeParser.Parse(dgvPosmTransferList.CurrentRow.Cells[colToEmpID.Index].Value, typeof(int), null);
                //if (ToEmpID != null)
                //{
                //    MessageBox.Show("ထုတ်ပေးပြီးဖြစ်သည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}
                int AP_RequestID = (int)DataTypeParser.Parse(dgvPosmTransferList.CurrentRow.Cells[colAP_RequestID.Index].Value, typeof(int), -1);
                int AP_IssueDeptID = (int)DataTypeParser.Parse(dgvPosmTransferList.CurrentRow.Cells[colIssueDeptID.Index].Value, typeof(int), -1);
                int AP_IssueEmployeeID = (int)DataTypeParser.Parse(dgvPosmTransferList.CurrentRow.Cells[colIssueEmployee.Index].Value, typeof(int), -1);
                frmPosmRecieve _frmPosmRecieve = new frmPosmRecieve(AP_RequestID,AP_IssueDeptID,AP_IssueEmployeeID);
                UIManager.OpenForm(_frmPosmRecieve);
                LoadNBind();
            }
        }

        private void dgvPosmTransferList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colbtnRequest.Index)
            {
                if (dgvPosmTransferList.Rows.Count > 0)
                {
                    int? ToEmpID = (int?)DataTypeParser.Parse(dgvPosmTransferList.CurrentRow.Cells[colToEmpID.Index].Value, typeof(int), null);
                    if (ToEmpID != null)
                    {
                        MessageBox.Show("ထုတ်ပေးပြီးဖြစ်သည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    int AP_RequestID = (int)DataTypeParser.Parse(dgvPosmTransferList.CurrentRow.Cells[colAP_RequestID.Index].Value, typeof(int), -1);
                    frmPosmRequest _frmPosmRequest = new frmPosmRequest(AP_RequestID);
                    UIManager.OpenForm(_frmPosmRequest);
                    this.Close();
                    LoadNBind();
                }
            }
        }

        private void btnRequestView_Click(object sender, EventArgs e)
        {
          
                if (dgvPosmTransferList.Rows.Count > 0)
                {
                    int? ToEmpID = (int?)DataTypeParser.Parse(dgvPosmTransferList.CurrentRow.Cells[colToEmpID.Index].Value, typeof(int), null);
                    if (ToEmpID != null)
                    {
                        //MessageBox.Show("ထုတ်ပေးပြီးဖြစ်သည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //return;
                    }
                    int AP_RequestID = (int)DataTypeParser.Parse(dgvPosmTransferList.CurrentRow.Cells[colAP_RequestID.Index].Value, typeof(int), -1);
                    frmPosmRequest _frmPosmRequest = new frmPosmRequest(AP_RequestID);
                    UIManager.OpenForm(_frmPosmRequest);
                    this.Close();
                    LoadNBind();
                }
            
        }

        private void frmPosmTransferList_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedValue = 8;
            comboBox2.Enabled = false;
        }

    }
}

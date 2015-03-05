using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.Marketing.Entities;
using PTIC.VC.Marketing.A_P;
using PTIC.VC;
using System.Data.SqlClient;
using PTIC.Common;

namespace PTIC.Marketing.A_P
{
    public partial class frmEnquiryAcceptedList : Form
    {
        public frmEnquiryAcceptedList()
        {
            InitializeComponent();
            pnlFilter.Hide();
            dgvAPEnquiryApprovedList.AutoGenerateColumns = false;
            LoadNBind();
        }

        #region Private Methods
        private void LoadNBind()
        {
            dgvAPEnquiryApprovedList.DataSource = new AP_EnquiryBL().GetAPEnquiryByIsAccepted();
        }

        private void Save()
        {
            SqlConnection conn = null;
            try
            {
                DataTable dt = dgvAPEnquiryApprovedList.DataSource as DataTable;
                if (dt == null) return;
                int affectedRows = 0;
                conn = DBManager.GetInstance().GetDbConnection();

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    AP_EnquiryDetail _AP_EnquiryDetail = new AP_EnquiryDetail()
                    {
                        ID = (int)DataTypeParser.Parse(row["AP_EnquiryDetailID"].ToString(), typeof(int), -1),
                        AP_EnquiryID = (int)DataTypeParser.Parse(row["AP_EnquiryID"].ToString(), typeof(int), -1),
                        EnquiryDate = (DateTime)DataTypeParser.Parse(row["EnquiryDate"].ToString(), typeof(DateTime), DateTime.Now),
                        SupplierID = (int)DataTypeParser.Parse(row["SupplierID"].ToString(), typeof(int), -1),
                        AP_MaterialID = (int)DataTypeParser.Parse(row["AP_MaterialID"].ToString(), typeof(int), -1),
                        ApprovedQty = (int)DataTypeParser.Parse(row["ApprovedQty"].ToString(), typeof(int), 0),
                        RevisedQty = (int)DataTypeParser.Parse(row["RevisedQty"].ToString(), typeof(int), 0),
                        UnitCost = (decimal)DataTypeParser.Parse(row["UnitCost"].ToString(), typeof(decimal), 0),
                        IsAccepted = (bool)DataTypeParser.Parse(row["IsAccepted"].ToString(), typeof(bool), 0),
                        Remark = (String)DataTypeParser.Parse(row["Remark"].ToString(), typeof(String), String.Empty)
                    };
                    affectedRows = new AP_EnquiryBL().UpdateByID(_AP_EnquiryDetail, conn);
                }

                if (affectedRows > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    LoadNBind();
                }
                else
                {
                    ToastMessageBox.Show(Resource.errFailedToSave);
                }
            }
            catch (SqlException Sqle)
            {
                throw Sqle;
            }
        }
        #endregion

        private void lblHeaderPCat_Click(object sender, EventArgs e)
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

        private void dgvAPEnquiryApprovedList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (null != dgv)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();
                    int ApprovedQty = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colQty.Index].Value, typeof(int), 0);
                    int PurchasedQty = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colPurchasedQty.Index].Value, typeof(int), 0);
                    int RevisedQty = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colRevisedQty.Index].Value, typeof(int), 0);

                    dgv.Rows[row.Index].Cells[colTotalQty.Index].Value = ApprovedQty - PurchasedQty - RevisedQty;
                }
            }
        }

        private void btnPurchased_Click(object sender, EventArgs e)
        {
            if (dgvAPEnquiryApprovedList.SelectedRows.Count < 1)
            {
                MessageBox.Show(Resource.errSelectRow, "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                AP_EnquiryDetail _apEnquiryDetail = new AP_EnquiryDetail();
                _apEnquiryDetail.ID = (int)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colAPEnquiryDetailID.Index].Value, typeof(int), -1);
                _apEnquiryDetail.AP_MaterialID = (int)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colPosmID.Index].Value, typeof(int), -1);
                _apEnquiryDetail.UnitCost = (decimal)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colUnitCost.Index].Value, typeof(decimal), 0);
                int APSubCategoryID = (int)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colAPSubCatID.Index].Value, typeof(int), -1);
                string APMaterialName = (string)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colPosm.Index].Value, typeof(string), String.Empty);
                int BalanceQty = (int)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colTotalQty.Index].Value, typeof(int), -1);
                string APSubCategoryName = (string)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colAPSubCat.Index].Value, typeof(string), String.Empty);
                frmPosmPurchasedIn _posmPurchasedIn = new frmPosmPurchasedIn(_apEnquiryDetail, APSubCategoryID, APMaterialName, APSubCategoryName, BalanceQty);
                UIManager.OpenForm(_posmPurchasedIn);
                LoadNBind();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to save?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != System.Windows.Forms.DialogResult.Yes)
                return;
            Save();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmA_PMain));
            this.Close();
        }

        private void dgvAPEnquiryApprovedList_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvAPEnquiryApprovedList.DataSource !=null )
            {
                if (dgvAPEnquiryApprovedList.SelectedRows.Count < 1) return;

                txtCOORemark.Text = (string)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colCOORemark.Index].Value, typeof(string), String.Empty);
                txtEnquirerRemark.Text = (string)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colRemark.Index].Value, typeof(string), String.Empty);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dgvAPEnquiryApprovedList.SelectedRows.Count > 0)
            {
                DateTime AcceptDate = (DateTime)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colEnquiryDate.Index].Value,typeof(DateTime),DateTime.Now);
                string POSM = (string)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colPosm.Index].Value, typeof(string), string.Empty);
                decimal UnitCost = (decimal)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colUnitCost.Index].Value, typeof(decimal), 0);
                int qty = (int)DataTypeParser.Parse(dgvAPEnquiryApprovedList.CurrentRow.Cells[colQty.Index].Value, typeof(int), 0);
                decimal total = UnitCost * qty;
                string Requester = (string)DataTypeParser.Parse(txtRequester.Text, typeof(string), string.Empty);
                string Accepter = (string)DataTypeParser.Parse(txtAccepter.Text, typeof(string), string.Empty);

                frmPOSM_RequestViewer _frmPOSM_RequestViewer = new frmPOSM_RequestViewer(AcceptDate.ToShortDateString(), POSM.ToString(), UnitCost.ToString(), qty.ToString(), total.ToString(), Requester.ToString(), Accepter.ToString());
                UIManager.OpenForm(_frmPOSM_RequestViewer);
            }
        }
    }
}

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
using System.Collections;
using PTIC.Util;
using PTIC.Common;

namespace PTIC.VC.Marketing.A_P
{
    public partial class frmPosmPurchasedInList : Form
    {
        DataTable _dtPurchasedInDetail = null;

   //     private DataTable _dtStockInDetail = null; // All AP_StockInDetail

        private Hashtable fieldhashtable = new Hashtable();

        public frmPosmPurchasedInList()
        {
            InitializeComponent();
            dgvPosmList.AutoGenerateColumns = false;
            pnlFilter.Visible = false;
            lblFilter.Text = "▼ Show Advance Search"; //Show filter information";
            LoadNBind();
            loadCombo();
        }

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
            try
            {
                this._dtPurchasedInDetail = new AP_PurchasedDetailBL().GetAll();
                dgvPosmList.AutoGenerateColumns = false;
                dgvPosmList.DataSource = this._dtPurchasedInDetail;

            }
            catch (SqlException Sqle)
            {
                
                throw Sqle;
            }
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

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmA_PMain));
            this.Close();
        }

        private void dgvPosmList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                    if (dgv.Rows.Count > 0)
                    {
                        int Quantity = (int)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colQty.Index].Value, typeof(int), 1);
                        decimal UnitCost = (decimal)DataTypeParser.Parse(dgv.Rows[r.Index].Cells[colUnitCost.Index].Value, typeof(decimal), 1);
                        
                        dgv.Rows[r.Index].Cells[colAmount.Index].Value = Quantity * UnitCost;
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            fieldhashtable.Clear();
            // fieldhashtable.Add("", (DateTime)DataTypeParser.Parse(cmbPOSM.SelectedValue, typeof(DateTime),DateTime.Now));
            if (chkDate.Checked)
            {
                dgvPosmList.DataSource = new AP_PurchasedDetailBL().SelectAllPurchasedInDetailByDate((DateTime)DataTypeParser.Parse(dtpStockInDate.Value, typeof(DateTime), DateTime.Now));
            }
            else
            {
                if (chkPosm.Checked)
                {
                    fieldhashtable.Add("AP_MaterialID", (int)DataTypeParser.Parse(cmbPOSM.SelectedValue, typeof(int), -1));
                }
                if (chkAPSubCat.Checked)
                {
                    fieldhashtable.Add("AP_SubCategoryID", (int)DataTypeParser.Parse(cmbAPSubCat.SelectedValue, typeof(int), -1));
                }
                dgvPosmList.AutoGenerateColumns = false;
                dgvPosmList.DataSource = DataUtil.GetDataTableByExactFields(this._dtPurchasedInDetail, fieldhashtable);           
            }
           
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            dgvPosmList.DataSource = this._dtPurchasedInDetail;
        }
    }
}

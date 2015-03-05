using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC;
using PTIC.VC;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.Util;
using System.Collections;
using PTIC.Common;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.VC.Marketing.Setup
{
    public partial class frmSupplier : Form
    {
        DataTable supplierTypeTbl = null;
        DataTable supplierTbl = null;
        SupplierType supplierType = new SupplierType();
        Supplier supplier = new Supplier();

        bool IsUpdate = false;
        int RowIndex = -1;

        public frmSupplier()
        {
            InitializeComponent();
            LoadData();
            BindData();
            DataUtil.AddInitialNewRow(dgvsetupSupplier);
            dgvsetupSupplier.CurrentCell = dgvsetupSupplier.Rows[dgvsetupSupplier.Rows.Count - 1].Cells[0];
            
        }

        #region Private Method
        private void LoadData()  //Load SupplierType Data for Grid
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                supplierTypeTbl = new SupplierTypeBL().GetAll();
                supplierTbl = new SupplierBL().GetAll();
            }
            catch (SqlException sqle)
            {

            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void BindData()  // Bind Data into DataGridView
        {
            // Auto Generate Columns
            dgvsetupSupplier.AutoGenerateColumns = false;
            clnSupplierTypeID.DataSource = supplierTypeTbl;
            clnSupplierTypeID.ValueMember = "SupplierTypeID";
            clnSupplierTypeID.DisplayMember = "SupplierType";

            cmbSupplierCat.DataSource = supplierTypeTbl;
            cmbSupplier.DataSource = supplierTbl;

            dgvsetupSupplier.DataSource = supplierTbl;
        }

        private void Save()
        {
            DataTable dt = dgvsetupSupplier.DataSource as DataTable;
            if (dt == null)
                return;
            int? sup = 0;
            SupplierBL supplierSaver = null;
            try
            {
                supplierSaver = new SupplierBL();

                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    supplier.SupTypeID = (int)DataTypeParser.Parse(row["SupTypeID"].ToString(), typeof(int), -1);
                    supplier.Address = (string)DataTypeParser.Parse(row["Address"].ToString(), typeof(string), -1);
                    supplier.SupplierName = String.IsNullOrEmpty(row["SupplierName"].ToString()) ? "" : row["SupplierName"].ToString();
                    supplier.ContactPerson = String.IsNullOrEmpty(row["ContactPerson"].ToString()) ? "" : row["ContactPerson"].ToString();
                    supplier.ContactPhone = String.IsNullOrEmpty(row["ContactPhone"].ToString()) ? "" : row["ContactPhone"].ToString();
                    supplier.Phone1 = String.IsNullOrEmpty(row["Phone1"].ToString()) ? "" : row["Phone1"].ToString();
                    supplier.Phone2 = String.IsNullOrEmpty(row["Phone2"].ToString()) ? "" : row["Phone2"].ToString();
                    sup = supplierSaver.Insert(supplier);

                    // Validation on INSERT
                    if (!supplierSaver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(supplierSaver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            "Supplier",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                
                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    supplier.SupplierID = (int)DataTypeParser.Parse(row["SupplierID"].ToString(), typeof(int), -1);
                    sup = supplierSaver.Delete(supplier);

                    // Validation on DELETE
                    if (!supplierSaver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(supplierSaver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            "Supplier",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    supplier.SupplierID = (int)DataTypeParser.Parse(row["SupplierID"].ToString(), typeof(int), -1);
                    supplier.SupTypeID = (int)DataTypeParser.Parse(row["SupTypeID"].ToString(), typeof(int), -1);
                    supplier.Address = (string)DataTypeParser.Parse(row["Address"].ToString(), typeof(string), -1);
                    supplier.SupplierName = String.IsNullOrEmpty(row["SupplierName"].ToString()) ? "" : row["SupplierName"].ToString();
                    supplier.ContactPerson = String.IsNullOrEmpty(row["ContactPerson"].ToString()) ? "" : row["ContactPerson"].ToString();
                    supplier.ContactPhone = String.IsNullOrEmpty(row["ContactPhone"].ToString()) ? "" : row["ContactPhone"].ToString();
                    supplier.Phone1 = String.IsNullOrEmpty(row["Phone1"].ToString()) ? "" : row["Phone1"].ToString();
                    supplier.Phone2 = String.IsNullOrEmpty(row["Phone2"].ToString()) ? "" : row["Phone2"].ToString();
                    sup = supplierSaver.Update(supplier);
                    // Validation on UPDATE
                    if (!supplierSaver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(supplierSaver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            "Supplier",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        dgvsetupSupplier.Rows[RowIndex].ReadOnly = false;
                        dgvsetupSupplier.CurrentCell = dgvsetupSupplier.Rows[RowIndex].Cells[clnSupplierTypeID.Index];
                        return;
                    }
                }
                
                // If no change occured
                if(dvInsert.Count < 1 && dvUpdate.Count < 1 && dvDelete.Count < 1)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    return;
                }

                // Success in db also
                if (sup.HasValue && sup.Value > 0)
                {
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    LoadData();
                    BindData();
                    ClearButton();
                }
                else
                    ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
            }
            catch (Exception e)
            {
                MessageBox.Show(
                        e.Message,
                        "Supplier",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dgvsetupSupplier.SelectedRows)
                {
                    dgvsetupSupplier.Rows.RemoveAt(item.Index);
                    ClearButton();
                }
                Save();
                DataUtil.AddInitialNewRow(dgvsetupSupplier);
                ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
            }
        }

        private void dgvsetupSupplier_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
          //  dgvsetupSupplier.Rows[e.RowIndex].Cells["clnNo"].Value = (e.RowIndex + 1).ToString();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            this.Close();
            UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
        }

        private void dgvsetupSupplier_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvsetupSupplier.Columns["clnSupplierName"].Index)
            {
                if (dgvsetupSupplier.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    //e.Cancel = true;
                    dgvsetupSupplier.Rows[e.RowIndex].ErrorText = "Supplier Name must be fill";
                }
                else
                {
                    dgvsetupSupplier.CurrentCell.ErrorText = string.Empty;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvsetupSupplier.CurrentCell.ColumnIndex;
                int iRow = dgvsetupSupplier.CurrentCell.RowIndex;
                if (iColumn == dgvsetupSupplier.Columns["clnAddress"].Index)
                {
                    if ((int)DataTypeParser.Parse(dgvsetupSupplier.CurrentRow.Cells[clnID.Index].Value, typeof(int), -1) == -1)
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }

                    if (iRow + 1 >= dgvsetupSupplier.Rows.Count)
                    {
                        if (dgvsetupSupplier.CurrentRow.ErrorText == String.Empty)
                        {
                            btnAdd.Enabled = false;
                            DataUtil.AddNewRow(dgvsetupSupplier.DataSource as DataTable);
                            dgvsetupSupplier[0, iRow + 1].Selected = true;
                        }
                    }
                    else
                    {
                        dgvsetupSupplier.CurrentCell = dgvsetupSupplier[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvsetupSupplier.CurrentCell = dgvsetupSupplier[dgvsetupSupplier.CurrentCell.ColumnIndex + 1, dgvsetupSupplier.CurrentCell.RowIndex];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void dgvsetupSupplier_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();                    
                    gridView.RowHeadersWidth = 50;

                    if ((int)DataTypeParser.Parse(r.Cells[clnID.Index].Value, typeof(int), -1) != -1)
                    {
                        gridView.Rows[r.Index].ReadOnly = true;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            DataUtil.AddNewRow(dgvsetupSupplier.DataSource as DataTable);
            dgvsetupSupplier.CurrentCell = dgvsetupSupplier.Rows[dgvsetupSupplier.Rows.Count - 1].Cells[0];
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            dgvsetupSupplier.AutoGenerateColumns = false;
            dgvsetupSupplier.DataSource = supplierTbl;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Hashtable hashTmp = new Hashtable();
            int SupplierCatID = (int)DataTypeParser.Parse(cmbSupplierCat.SelectedValue, typeof(int), -1);
            int SupplierID = (int)DataTypeParser.Parse(cmbSupplier.SelectedValue, typeof(int), -1);

            if (chkSupplier.Checked)
            {
                hashTmp.Add("SupplierID", SupplierID);
            }
            if (chkSupplierCat.Checked)
            {
                hashTmp.Add("SupTypeID", SupplierCatID);
            }
            DataTable dtTmp = DataUtil.GetDataTableByExactFields(supplierTbl, hashTmp);
            if (dtTmp == null)
            {
                dgvsetupSupplier.DataSource = null;
                return;
            }

            if (dtTmp.Rows.Count > 0)
            {
                dgvsetupSupplier.AutoGenerateColumns = false;
                dgvsetupSupplier.DataSource = dtTmp;
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

        private void dgvsetupSupplier_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvsetupSupplier_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (IsUpdate == false && (int)DataTypeParser.Parse(dgvsetupSupplier.Rows[dgvsetupSupplier.Rows.Count - 1].Cells[clnID.Index].Value, typeof(int), -1) != -1)
            {
                IsUpdate = true;
                RowIndex = (int)DataTypeParser.Parse(dgvsetupSupplier.CurrentRow.Index, typeof(int), -1);
                dgvsetupSupplier.CurrentRow.ReadOnly = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (RowIndex == (int)DataTypeParser.Parse(dgvsetupSupplier.CurrentRow.Index, typeof(int), -1))
            {
                dgvsetupSupplier.CurrentRow.ReadOnly = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (RowIndex != -1)
            {
                dgvsetupSupplier.Rows[RowIndex].ReadOnly = false;
                dgvsetupSupplier.CurrentCell = dgvsetupSupplier.Rows[RowIndex].Cells[clnSupplierTypeID.Index];
            }
        }

        private void ClearButton()
        {
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
        }
    }
}

using System;
using System.Data;
using PTIC.Common;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.Marketing.Entities;
using PTIC.Marketing.BL;
using PTIC.VC.Util;
using PTIC.Util;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.VC.Marketing.Setup
{
    public partial class frmSupplierType : Form
    {

        DataTable supplierTypeTbl = null;

        bool IsUpdate = false;
        int RowIndex = -1;

        public frmSupplierType()
        {
            InitializeComponent();
            LoadData();
            BindData();
            DataUtil.AddInitialNewRow(dgvsetupSupplierType);
        }

        #region Private Method

        private void LoadData()  //Load Town Data for Grid
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                supplierTypeTbl = new SupplierTypeBL().GetAll();
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
            dgvsetupSupplierType.AutoGenerateColumns = false;
            dgvsetupSupplierType.DataSource = supplierTypeTbl;
        }

        private SupplierType GetSupplierType()
        {
            DataTable dt = dgvsetupSupplierType.DataSource as DataTable;
            SupplierType supplierType = new SupplierType()
            {
                SupplierTypeID = (int)DataTypeParser.Parse(dt.Rows[dt.Rows.Count -1]["SupplierTypeID"],typeof(int),-1),
                SupplierTypeName = (string)DataTypeParser.Parse(dt.Rows[dt.Rows.Count - 1]["SupplierType"], typeof(string), null)
            };           
            return supplierType;
        }

        private void Save()
        {
            DataTable dt = dgvsetupSupplierType.DataSource as DataTable;
            SupplierTypeBL supplierTypeSaver = null;
            int? sup = null;
            if (dt == null)
                return;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                supplierTypeSaver = new SupplierTypeBL();

                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    SupplierType supplierType = new SupplierType();
                    supplierType.SupplierTypeID = (int)DataTypeParser.Parse(row["SupplierTypeID"], typeof(int), -1);
                    supplierType.SupplierTypeName = (string)DataTypeParser.Parse(row["SupplierType"], typeof(string), null);
                    sup = supplierTypeSaver.Insert(supplierType);

                    if (!supplierTypeSaver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(supplierTypeSaver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            "Supplier Type",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    SupplierType supplierType = new SupplierType();
                    supplierType.SupplierTypeID = (int)DataTypeParser.Parse(row["SupplierTypeID"].ToString(), typeof(int), -1);
                    sup = new SupplierTypeBL().Delete(supplierType, conn);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    SupplierType supplierType = new SupplierType();
                    supplierType.SupplierTypeID = (int)DataTypeParser.Parse(row["SupplierTypeID"].ToString(), typeof(int), -1);
                    supplierType.SupplierTypeName = (string)DataTypeParser.Parse(row["SupplierType"], typeof(string), null);

                    sup = supplierTypeSaver.Update(supplierType);
                    
                    if (!supplierTypeSaver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(supplierTypeSaver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            "Supplier Type",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        dgvsetupSupplierType.Rows[RowIndex].ReadOnly = false;
                        dgvsetupSupplierType.CurrentCell = dgvsetupSupplierType.Rows[RowIndex].Cells[clnSupplierType.Index];                       
                        return;
                    }
                    else
                    {
                        IsUpdate = false;
                    }

                }

                if (sup.HasValue && sup.Value > 0)
                {
                    LoadData();
                    BindData();
                    ClearButton();
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }

            }
            catch (Exception sqle)
            {
                // show error message
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvsetupSupplierType.CurrentCell.ColumnIndex;
                int iRow = dgvsetupSupplierType.CurrentCell.RowIndex;
                if (iColumn == dgvsetupSupplierType.Columns["clnSupplierType"].Index)
                {
                    if ((int)DataTypeParser.Parse(dgvsetupSupplierType.CurrentRow.Cells[clnID.Index].Value, typeof(int), -1) == -1)
                    {
                        return base.ProcessCmdKey(ref msg, keyData);
                    }

                    if (iRow + 1 >= dgvsetupSupplierType.Rows.Count)
                    {
                        btnAdd.Enabled = false;
                        DataUtil.AddNewRow(dgvsetupSupplierType.DataSource as DataTable);
                        dgvsetupSupplierType[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        try
                        {
                            dgvsetupSupplierType.CurrentCell = dgvsetupSupplierType[0, iRow + 1];
                        }
                        catch (Exception)
                        {
                        }

                    }
                }
                else
                {
                    try
                    {
                        dgvsetupSupplierType.CurrentCell = dgvsetupSupplierType[dgvsetupSupplierType.CurrentCell.ColumnIndex + 1, dgvsetupSupplierType.CurrentCell.RowIndex];
                    }
                    catch (Exception ie)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dgvsetupSupplierType.SelectedRows)
                {
                    dgvsetupSupplierType.Rows.RemoveAt(item.Index);
                    ClearButton();
                }
                Save();
                DataUtil.AddInitialNewRow(dgvsetupSupplierType);
                ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvsetupSupplierType.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
            this.Close();
        }

        private void dgvsetupSupplierType_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvsetupSupplierType.Columns["clnSupplierType"].Index)
            {
                if (dgvsetupSupplierType.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    dgvsetupSupplierType.Rows[e.RowIndex].ErrorText = "Supplier Type must be fill";
                }
                else
                {
                    dgvsetupSupplierType.CurrentCell.ErrorText = string.Empty;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                btnAdd.Enabled = false;
                SupplierType supplierType = GetSupplierType();

                SupplierTypeBL supplierTypeValidator = new SupplierTypeBL();
                supplierTypeValidator.Validate(supplierType);

                if (!supplierTypeValidator.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(supplierTypeValidator.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                DataUtil.AddNewRow(dgvsetupSupplierType.DataSource as DataTable);
                dgvsetupSupplierType.CurrentCell = dgvsetupSupplierType.Rows[dgvsetupSupplierType.Rows.Count - 1].Cells[clnSupplierType.Index];

            }
            catch (Exception)
            {
            }

        }

        private void dgvsetupSupplierType_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if ((int)DataTypeParser.Parse(row.Cells[clnID.Index].Value, typeof(int), -1) != -1)
                {
                    dgv.Rows[row.Index].ReadOnly = true;
                }
            }
        }

        private void dgvsetupSupplierType_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (IsUpdate == false && (int)DataTypeParser.Parse(dgvsetupSupplierType.Rows[dgvsetupSupplierType.Rows.Count-1].Cells[clnID.Index].Value, typeof(int), -1) != -1)
            {
                IsUpdate = true;
                RowIndex = (int)DataTypeParser.Parse(dgvsetupSupplierType.CurrentRow.Index,typeof(int),-1);
                dgvsetupSupplierType.CurrentRow.Cells[clnSupplierType.Index].ReadOnly = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if(RowIndex == (int)DataTypeParser.Parse(dgvsetupSupplierType.CurrentRow.Index,typeof(int),-1))
            {
                dgvsetupSupplierType.CurrentRow.Cells[clnSupplierType.Index].ReadOnly = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (RowIndex != -1)
            {
                dgvsetupSupplierType.Rows[RowIndex].Cells[clnSupplierType.Index].ReadOnly = false;
                dgvsetupSupplierType.CurrentCell = dgvsetupSupplierType.Rows[RowIndex].Cells[clnSupplierType.Index];
            }
        }

        private void ClearButton()
        {
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
        }
      
    }
}

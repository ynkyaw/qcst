using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using PTIC.Common;
using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.Entities;
using PTIC.Sale.DA;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Sale.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;


namespace PTIC.Sale.Setup
{
    public partial class frmBank : Form
    {
        DataTable bankTbl = null;
        DataTable townTbl = null;
        Bank bank = new Bank();
        bool IsRowEdit = false;

        public frmBank()
        {
            InitializeComponent();
            LoadData();
            BindData();
            DataUtil.AddInitialNewRow(dgvsetupBank);
        }

        #region Private Method
        private bool HasNewRow(DataGridView dgv)
        {
            int? BankID = (int?)DataTypeParser.Parse(dgv.Rows[dgv.Rows.Count - 1].Cells[clnBankID.Index].Value, typeof(int), null);

            if (BankID != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void LoadData()  //Load Town Data for Grid
        {
            try
            {
                bankTbl = new BankBL().GetAll();
                townTbl = new TownBL().GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void BindData()  // Bind Data into DataGridView
        {
            clnTown.DataSource = townTbl;
            clnTown.DisplayMember = "Town";
            clnTown.ValueMember = "TownID";

            // Auto Generate Columns
            dgvsetupBank.AutoGenerateColumns = false;

            dgvsetupBank.DataSource = bankTbl;
        }

        private void Save()
        {
            DataTable dt = dgvsetupBank.DataSource as DataTable;
            int sup = 0;
            if (dt == null)
                return;
            BankBL saver = null;
            try
            {
                saver = new BankBL(); ;
                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {

                    bank.BankName = (string)DataTypeParser.Parse(row["Bank"], typeof(string), null);
                    bank.TownID = (int)DataTypeParser.Parse(row["TownID"].ToString(), typeof(int), -1);
                    bank.BankAddress = (string)DataTypeParser.Parse(row["BankAddress"], typeof(string), null);
                    bank.Phone = (string)DataTypeParser.Parse(row["Phone"], typeof(string), null);
                   
                    sup = saver.Insert(bank);
                    if (!saver.ValidationResults.IsValid)
                    {
                        ValidationResult err = DataUtil.GetFirst(saver.ValidationResults) as ValidationResult;
                        MessageBox.Show(
                            err.Message,
                            "Bank",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }                   
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    bank.BankID = (int)DataTypeParser.Parse(row["BankID"].ToString(), typeof(int), -1);
                    sup = new BankBL().Delete(bank);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    bank.BankID = (int)DataTypeParser.Parse(row["BankID"].ToString(), typeof(int), -1);
                    bank.TownID = (int)DataTypeParser.Parse(row["TownID"].ToString(), typeof(int), -1);
                    bank.BankName = String.IsNullOrEmpty(row["Bank"].ToString()) ? "" : row["Bank"].ToString();
                    bank.BankAddress = String.IsNullOrEmpty(row["BankAddress"].ToString()) ? "" : row["BankAddress"].ToString();
                    bank.Phone = String.IsNullOrEmpty(row["Phone"].ToString()) ? "" : row["Phone"].ToString();
                    //bank.Remark = String.IsNullOrEmpty(row["Remark"].ToString()) ? "" : row["Remark"].ToString();
                    if (bank.TownID != -1 && bank.BankName != "" && bank.BankAddress != "")
                    {
                        sup = saver.Update(bank);
                        if (!saver.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(saver.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                "Bank",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }
                    }
                    
                }

                if (sup > 0)
                {                    
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    IsRowEdit = false;
                }
                else
                {
                    ToastMessageBox.Show(Resource.errFailedToSave);
                    IsRowEdit = false;
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

        #region EventHandler
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvsetupBank.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dgvsetupBank.SelectedRows)
                    {
                        dgvsetupBank.Rows.RemoveAt(item.Index);
                    }
                    Save();
                    DataUtil.AddInitialNewRow(dgvsetupBank);
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
            }
            else
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete, Color.Red);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadData();
            BindData();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
            this.Close();
        }

        #endregion

        private void dgvsetupBank_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
              
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvsetupBank.CurrentCell.ColumnIndex;
                int iRow = dgvsetupBank.CurrentCell.RowIndex;
                if (iColumn == dgvsetupBank.Columns["Phone"].Index)
                {
                    if (iRow + 1 >= dgvsetupBank.Rows.Count)
                    {
                        if(HasNewRow(dgvsetupBank) || IsRowEdit == true) return base.ProcessCmdKey(ref msg, keyData);
                        DataTable dt = dgvsetupBank.DataSource as DataTable;
                        DataRow newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                        this.dgvsetupBank.DataSource = dt;
                        dgvsetupBank[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvsetupBank.CurrentCell = dgvsetupBank[0, iRow + 1];

                    }
                }
                else
                {
                    try
                    {
                        dgvsetupBank.CurrentCell = dgvsetupBank[dgvsetupBank.CurrentCell.ColumnIndex + 1, dgvsetupBank.CurrentCell.RowIndex];
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvsetupBank_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    if ((int?)DataTypeParser.Parse(gridView.Rows[r.Index].Cells[clnBankID.Index].Value, typeof(int), null) != null)
                    {
                        gridView.Rows[r.Index].ReadOnly = true;
                        //gridView.Rows[r.Index].Cells[clnSPDetailID.Index].ReadOnly = false;
                    }

                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString(); // Row Header
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {           
            if (!HasNewRow(dgvsetupBank) && IsRowEdit == false)
            {
                DataUtil.AddNewRow(dgvsetupBank.DataSource as DataTable);
                dgvsetupBank.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dgvsetupBank.CurrentCell = dgvsetupBank.Rows[dgvsetupBank.RowCount - 1].Cells["BankName"];
            }
        }

        private void dgvsetupBank_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;
            if (dgv.CurrentRow == null) return;

            if (e.ColumnIndex == dgv.CurrentRow.Cells[clnTown.Index].ColumnIndex && dgv.Rows[e.RowIndex].ErrorText != String.Empty)
            {
                dgv.Rows[e.RowIndex].ErrorText = string.Empty;
                dgv.Rows[e.RowIndex].Cells[clnTown.Index].Value = -1;
            }
            else if (e.ColumnIndex == dgv.CurrentRow.Cells[BankName.Index].ColumnIndex && dgv.Rows[e.RowIndex].ErrorText != String.Empty)
            {
                dgv.Rows[e.RowIndex].ErrorText = string.Empty;
                dgv.Rows[e.RowIndex].Cells[BankName.Index].Value = string.Empty;
            }
        }

        private void dgvsetupBank_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }
        }

        private void dgvsetupBank_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvsetupBank.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvsetupBank_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (HasNewRow(dgvsetupBank)) return;
           
            if (IsRowEdit == false)
            {
                dgvsetupBank.CurrentRow.ReadOnly = false;
                IsRowEdit = true;
            }
            else
            {
                MessageBox.Show("သိမ်းမည် ကိုနှိပ်ပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

      
    }
}

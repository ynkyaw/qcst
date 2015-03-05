using System;
using System.Data;
using System.Windows.Forms;
using PTIC.VC;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.Util;
using PTIC.VC.Marketing;

namespace PTIC.Sale.Setup
{
    public partial class frmTowns : Form
    {
        DataTable sdivisionTbl = new DataTable();
        DataTable townTbl = new DataTable();
        Town town = new Town();
        bool IsMarketing = false;
        bool IsRowEdit = false;

        public frmTowns()
        {
            InitializeComponent();
            LoadData();
            BindData();
            if (dgvsetuptown.Rows.Count == 0)
            {
                DataRow newRow = townTbl.NewRow();
                townTbl.Rows.Add(newRow);
                this.dgvsetuptown.DataSource = townTbl;
            }
        }

        public frmTowns(bool IsTrue)
            : this()
        {
            IsMarketing = IsTrue;
        }

        #region Private Method
        private bool HasNewRow(DataGridView dgv)
        {
            int? TownID = (int?)DataTypeParser.Parse(dgv.Rows[dgv.Rows.Count - 1].Cells[clnTownID.Index].Value, typeof(int), null);

            if (TownID != null)
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
                sdivisionTbl = new SDivisionBL().GetAll();
                townTbl = new TownBL().GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void BindData()  // Bind Data into DataGridView
        {
            // Auto Generate Columns
            dgvsetuptown.AutoGenerateColumns = false;

            StateDivision.DataSource = sdivisionTbl;
            StateDivision.DisplayMember = "StateDivisionName";
            StateDivision.ValueMember = "SDivisionID";

            dgvsetuptown.DataSource = townTbl;
        }

        private bool Save()
        {
            DataTable dt = dgvsetuptown.DataSource as DataTable;
            int sup = 0;
            if (dt == null)
                return false;
            try
            {
                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    if (String.IsNullOrEmpty(row["StateDivisionID"].ToString()))
                    {
                        ToastMessageBox.Show(Resource.errStateDivisionMustFill);
                        return false;
                    }
                    else
                    {
                        town.StateDivisionID = (int)DataTypeParser.Parse(row["StateDivisionID"].ToString(), typeof(int), -1);
                        town.TownName = String.IsNullOrEmpty(row["Town"].ToString()) ? string.Empty : row["Town"].ToString();

                        if (town.TownName.Trim()==string.Empty) 
                        {
                            ToastMessageBox.Show(Resource.errTownEmpty);
                            return false;
                        }
                        sup = new TownBL().Insert(town);
                    }
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    town.TownID = (int)DataTypeParser.Parse(row["TownID"].ToString(), typeof(int), -1);

                    TownshipBL townShipBz = new TownshipBL();
                    int townshipCount = townShipBz.GetTownShipCountByTownID(town.TownID);
                    if (townshipCount < 1)
                        sup = new TownBL().Delete(town);
                    else {
                        ToastMessageBox.Show("Township ရှိနေပါသဖြင့်ဖျက်၍မရပါ။");
                        LoadData();
                        BindData();
                        return false;
                    }
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    if (String.IsNullOrEmpty(row["TownID"].ToString()))
                    {
                        ToastMessageBox.Show(Resource.errTownMustFill);
                        return false;
                    }
                    else if (String.IsNullOrEmpty(row["StateDivisionID"].ToString()))
                    {
                        ToastMessageBox.Show(Resource.errStateDivisionMustFill);
                        return false;
                    }
                    else
                    {
                        town.TownID = (int)DataTypeParser.Parse(row["TownID"].ToString(), typeof(int), -1);
                        town.StateDivisionID = (int)DataTypeParser.Parse(row["StateDivisionID"].ToString(), typeof(int), -1);
                        town.TownName = String.IsNullOrEmpty(row["Town"].ToString()) ? "" : row["Town"].ToString();
                        sup = new TownBL().Update(town);
                    }
                }

                if (sup > 0)
                {
                    LoadData();
                    BindData();
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                    IsRowEdit = false;
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        #endregion
        
        #region Event Handler

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.btnNew.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnEdit.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Added By YNK
            if (this.dgvsetuptown.SelectedRows.Count != 1) 
            {
                MessageBox.Show("Please Select Only one row to Delete?", "Remove confirmation", MessageBoxButtons.OK);
                return;
            }
            //Added End

            if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dgvsetuptown.SelectedRows)
                {
                    dgvsetuptown.Rows.RemoveAt(item.Index);
                }
                //Edited By YNK
                
                bool isSuccess = Save();
                
                if(isSuccess)
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                else
                    ResetReadOnlyGridViewTown(dgvsetuptown);
                //Edit End
                //Old Code
                //Save();
                //ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                //Old Code End
                
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            if (IsMarketing == true)
            {
                UIManager.MdiChildOpenForm(typeof(frmMarketingSetupPage));
                this.Close();
            }
            else
            {
                UIManager.MdiChildOpenForm(typeof(frmSetupPage));
                this.Close();
            }
        }

        #endregion

        private void dgvsetuptown_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvsetuptown.Columns["TownName"].Index)
            {
                if (dgvsetuptown.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    //e.Cancel = true;
                    dgvsetuptown.CurrentCell.ErrorText = "Town Name must be fill";
                }
                else
                {
                    dgvsetuptown.CurrentCell.ErrorText = string.Empty;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvsetuptown.CurrentCell.ColumnIndex;
                int iRow = dgvsetuptown.CurrentCell.RowIndex;
               
                if (iColumn == dgvsetuptown.Columns["TownName"].Index)
                {
                    if (iRow + 1 >= dgvsetuptown.Rows.Count)
                    {
                        if (dgvsetuptown.CurrentRow.ErrorText == String.Empty)
                        {
                            if (HasNewRow(dgvsetuptown) && IsRowEdit == true) return base.ProcessCmdKey(ref msg, keyData);
                            DataTable dt = dgvsetuptown.DataSource as DataTable;
                            DataRow newRow = dt.NewRow();
                            dt.Rows.Add(newRow);
                            this.dgvsetuptown.DataSource = dt;
                            dgvsetuptown[0, iRow + 1].Selected = true;
                        }
                    }
                    else
                    {
                        try
                        {
                            dgvsetuptown.CurrentCell = dgvsetuptown[0, iRow + 1];
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else
                {
                    try
                    {
                        dgvsetuptown.CurrentCell = dgvsetuptown[iColumn + 1, iRow];
                    }
                    catch (Exception ex)
                    {
                    }                    
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgvsetuptown_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            //Edited To Method Call Cause Want to use from another function
            // By YNK
            ResetReadOnlyGridViewTown(gridView);
            //Edit End
        }
        //Edited To Method Call Cause Want to use from another function
        // By YNK
        private void ResetReadOnlyGridViewTown(DataGridView gridView) 
        {
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    if ((int?)DataTypeParser.Parse(gridView.Rows[r.Index].Cells[clnTownID.Index].Value, typeof(int), null) != null)
                    {
                        gridView.Rows[r.Index].ReadOnly = true;
                        //gridView.Rows[r.Index].Cells[clnSPDetailID.Index].ReadOnly = false;
                    }

                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        
        }
        //Edit End

        private void dgvsetuptown_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            dgvsetuptown.Rows[e.RowIndex].ErrorText = "the value must be a Positive integer";
        }       

        private void btnNew_Click(object sender, EventArgs e)
        {
            //ResetReadOnlyGridViewTown(dgvsetuptown);
            if (!HasNewRow(dgvsetuptown) && IsRowEdit == false)
            {
                DataUtil.AddNewRow(dgvsetuptown.DataSource as DataTable);
                dgvsetuptown.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dgvsetuptown.CurrentCell = dgvsetuptown.Rows[dgvsetuptown.RowCount - 1].Cells["StateDivision"];
            }
            else
            {
                ToastMessageBox.Show("Data ကိုအရင္သိမ္းပါ။");
            }

        }

        private void dgvsetuptown_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvsetuptown_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (HasNewRow(dgvsetuptown)) return;
           
            if (IsRowEdit == false)
            {
                dgvsetuptown.CurrentRow.ReadOnly = false;
                IsRowEdit = true;
            }
            else
            {
                MessageBox.Show("သိမ်းမည် ကိုနှိပ်ပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvsetuptown.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select Only one row to Delete?", "Remove confirmation", MessageBoxButtons.OK);
                return;
            }
            this.dgvsetuptown.SelectedRows[0].ReadOnly = false;
            this.btnNew.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnEdit.Enabled = false;
           
            
        }

        
        
    }
}

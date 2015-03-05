using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.Util;
using PTIC.VC.Marketing;


namespace PTIC.Sale.Setup
{
    public partial class frmTownship : Form
    {
        DataTable townTbl = null;
        DataTable townshipTbl = null;
        Township township = new Township();
        bool IsMarketing = false;
        bool IsRowEdit = false;

        public frmTownship()
        {
            InitializeComponent();
            LoadData();
            BindData();
            if (dgvsetuptownship.Rows.Count == 0)
            {
                DataRow newRow = townshipTbl.NewRow();
                townshipTbl.Rows.Add(newRow);
                this.dgvsetuptownship.DataSource = townshipTbl;
            }
        }

        public frmTownship(bool IsTrue)
            : this()
        {
            IsMarketing = IsTrue;
        }

        #region Private Method
        private void LoadData()  //Load Town Data for Grid
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                townTbl = new TownBL().GetAll();
                townshipTbl = new TownshipBL().GetAll();
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
            dgvsetuptownship.AutoGenerateColumns = false;

            TownName.DataSource = townTbl;
            TownName.DisplayMember = "Town";
            TownName.ValueMember = "TownID";

            dgvsetuptownship.DataSource = townshipTbl;
            //   dgvsetuptownship.CurrentCell = dgvsetuptownship[2, dgvsetuptownship.RowCount-1];
            ResetReadOnlyGrid(dgvsetuptownship);
        }

        private void Save()
        {
            DataTable dt = dgvsetuptownship.DataSource as DataTable;
            int sup = 0;
            if (dt == null)
                return;
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    township.TownID = (int)DataTypeParser.Parse(row["TownID"].ToString(), typeof(int), -1);
                    township.TownshipName = String.IsNullOrEmpty(row["Township"].ToString()) ? "" : row["Township"].ToString();
                    if (String.IsNullOrEmpty(row["TownID"].ToString()))
                    {
                        ToastMessageBox.Show(Resource.errTownMustFill);
                        return;
                    }
                    else if (String.IsNullOrEmpty(township.TownshipName.Trim()))
                    {
                        ToastMessageBox.Show(Resource.errTownshipMustFill);
                        return;
                    }





                    sup = new TownshipBL().Insert(township, conn);
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    township.TownshipID = (int)DataTypeParser.Parse(row["TownshipID"].ToString(), typeof(int), -1);
                    sup = new TownshipBL().Delete(township, conn);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    township.TownshipID = (int)DataTypeParser.Parse(row["TownshipID"].ToString(), typeof(int), -1);
                    township.TownID = (int)DataTypeParser.Parse(row["TownID"].ToString(), typeof(int), -1);
                    township.TownshipName = String.IsNullOrEmpty(row["Township"].ToString()) ? "" : row["Township"].ToString();
                    if (String.IsNullOrEmpty(row["TownID"].ToString()))
                    {
                        ToastMessageBox.Show(Resource.errTownMustFill);
                        return;
                    }
                    else if (String.IsNullOrEmpty(row["TownshipID"].ToString()))
                    {
                        ToastMessageBox.Show(Resource.errTownshipMustFill);
                        return;
                    }
                    sup = new TownshipBL().Update(township, conn);
                }

                if (sup > 0)
                {
                    LoadData();
                    BindData();
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
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

        #region Event Handler

        private void dgvsetuptownship_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvsetuptownship.Rows[e.RowIndex].Cells["No"].Value = (e.RowIndex + 1).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvsetuptownship == null) return;
            int TownID = (int)DataTypeParser.Parse(dgvsetuptownship.CurrentRow.Cells[TownName.Index].Value, typeof(int), -1);
            string Township = (string)DataTypeParser.Parse(dgvsetuptownship.CurrentRow.Cells[dgvTownshipName.Index].Value, typeof(string), string.Empty);
            if (TownID == -1 || string.IsNullOrEmpty(Township))
            {
                MessageBox.Show("Data များကို ပြည့်စုံစွာဖြည့်ပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Save();
            //LoadData();
            //BindData();
            //IsRowEdit = false;
            btnDelete.Enabled = true;
            btnNew.Enabled = true;
            btnEdit.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvsetuptownship.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dgvsetuptownship.SelectedRows)
                    {
                        dgvsetuptownship.Rows.RemoveAt(item.Index);
                    }
                    Save();
                    ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
                }
            }
            else
            {
                ToastMessageBox.Show(Resource.errSelectRowToDelete, Color.Red);
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

        private void dgvsetuptownship_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvsetuptownship.Columns["TownName"].Index)
            {
                if (dgvsetuptownship.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    dgvsetuptownship.Rows[e.RowIndex].ErrorText = "Township must be fill";
                }
                else
                {
                    dgvsetuptownship.CurrentCell.ErrorText = string.Empty;
                }
            }
        }

        private void dgvsetuptownship_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    //    dgvMarketingPlan.BeginEdit(true);
            //    e.SuppressKeyPress = true;
            //    int iColumn = dgvsetuptownship.CurrentCell.ColumnIndex;
            //    int iRow = dgvsetuptownship.CurrentCell.RowIndex;
            //    if (iColumn <=dgvsetuptownship.Columns.Count - 1)
            //    {
            //        if (iRow + 1 >= dgvsetuptownship.Rows.Count)
            //        {
            //            DataRow newRow = townshipTbl.NewRow();
            //            townshipTbl.Rows.Add(newRow);
            //            this.dgvsetuptownship.DataSource = townshipTbl;
            //            dgvsetuptownship[0, iRow + 1].Selected = true;
            //        }
            //        else
            //        {
            //            dgvsetuptownship.CurrentCell = dgvsetuptownship[0, iRow + 1];
            //        }
            //    }
            //    else
            //    {
            //        //   dgvMarketingPlan.CurrentCell = dgvMarketingPlan[iColumn + 1, iRow];
            //        dgvsetuptownship.CurrentCell = dgvsetuptownship[dgvsetuptownship.CurrentCell.ColumnIndex + 1, dgvsetuptownship.CurrentCell.RowIndex];
            //    }

            // }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvsetuptownship.CurrentCell.ColumnIndex;
                int iRow = dgvsetuptownship.CurrentCell.RowIndex;
                if (iColumn == dgvsetuptownship.Columns["dgvTownshipName"].Index)
                {
                    if (iRow + 1 >= dgvsetuptownship.Rows.Count)
                    {
                        DataRow newRow = townshipTbl.NewRow();
                        townshipTbl.Rows.Add(newRow);
                        this.dgvsetuptownship.DataSource = townshipTbl;
                        dgvsetuptownship[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        dgvsetuptownship.CurrentCell = dgvsetuptownship[0, iRow + 1];
                    }
                }
                else
                {
                    try
                    {
                        dgvsetuptownship.CurrentCell = dgvsetuptownship[iColumn + 1, iRow];
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!HasNewRow(dgvsetuptownship))
            {
                DataUtil.AddNewRow(dgvsetuptownship.DataSource as DataTable);
                dgvsetuptownship.CurrentCell = dgvsetuptownship.Rows[dgvsetuptownship.RowCount - 1].Cells["TownName"];
            }
            else
            {
                ToastMessageBox.Show("Data ကိုအရင္သိမ္းပါ။");
            }
        }


        private bool HasNewRow(DataGridView dgv)
        {
            int? TownID = (int?)DataTypeParser.Parse(dgv.Rows[dgv.Rows.Count - 1].Cells[clnTownShipID.Index].Value, typeof(int), null);

            if (TownID != null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        private void dgvsetuptownship_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgv=(sender as DataGridView);
            ResetReadOnlyGrid(dgv);
            int lastRow=dgv.Rows.Count-1;
            if ((int)DataTypeParser.Parse(dgv.Rows[lastRow].Cells[clnTownShipID.Index].Value, typeof(int), 0) == 0) 
            {
                dgv.Rows[lastRow].ReadOnly = false;
           
            }
        }
        private void ResetReadOnlyGrid(DataGridView gridView) 
        {
            
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    if ((int)DataTypeParser.Parse(gridView.Rows[r.Index].Cells[TownName.Index].Value, typeof(int), 0) != 0)
                    {
                        gridView.Rows[r.Index].ReadOnly = true;
                    }
                }
            }
        }

        private void dgvsetuptownship_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //var dgv = dgvsetuptownship as DataGridView;

            //if (IsRowEdit == false)
            //{
            //    dgv.CurrentRow.ReadOnly = false;
            //    IsRowEdit = true;
            //    btnDelete.Enabled = false;
            //    btnNew.Enabled = false;
            //}
        }

        private void dgvsetuptownship_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvsetuptownship.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void frmTownship_Load(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvsetuptownship.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please Select Only one row to Delete?", "Remove confirmation", MessageBoxButtons.OK);
                return;
            }
            this.dgvsetuptownship.SelectedRows[0].ReadOnly = false;
            this.btnNew.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnEdit.Enabled = false;
        }
    }
}

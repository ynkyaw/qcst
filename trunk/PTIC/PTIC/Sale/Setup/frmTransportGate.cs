using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using PTIC.VC;
using PTIC.Sale.BL;
using PTIC.Util;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Sale.Setup
{
    public partial class frmTransportGate : Form
    {
        DataTable transporttypeTbl = null;
        DataTable transportgateTbl = null;
        TransportGate transportgate = new TransportGate();
        bool IsRowEdit = false;

        public frmTransportGate()
        {
            InitializeComponent();
            LoadData();
            BindData();
            if (dgvsetuptransportgate.Rows.Count == 0)
            {
                DataRow newRow = transportgateTbl.NewRow();
                transportgateTbl.Rows.Add(newRow);
                this.dgvsetuptransportgate.DataSource = transportgateTbl;
            }    
        }

        #region Private Method
        private void LoadData()  //Load Town Data for Grid
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transporttypeTbl = new TransportTypeBL().GetAll();
                transportgateTbl= new TransportGateBL().GetAll();
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
            dgvsetuptransportgate.AutoGenerateColumns = false;

            TransportType.DataSource = transporttypeTbl;
            TransportType.DisplayMember = "TransportTypeName";
            TransportType.ValueMember = "TransportTypeID";

            dgvsetuptransportgate.DataSource = transportgateTbl;
        }

        private void Save()
        {
            DataTable dt = dgvsetuptransportgate.DataSource as DataTable;
            int sup = 0;
            if (dt == null)
                return;
            TransportGateBL saver = null;
            try
            {
                saver = new TransportGateBL();
                // insert
                DataView dvInsert = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Added);
                foreach (DataRow row in dvInsert.ToTable().Rows)
                {
                    transportgate.TransportTypeID = (int)DataTypeParser.Parse(row["TransportTypeID"].ToString(), typeof(int), -1);
                    transportgate.GateName = String.IsNullOrEmpty(row["GateName"].ToString()) ? "" : row["GateName"].ToString();
                    transportgate.Remark = String.IsNullOrEmpty(row["Remark"].ToString()) ? "" : row["Remark"].ToString();
                    if (transportgate.TransportTypeID != -1 && transportgate.GateName != "")
                    {                        
                        sup = saver.Insert(transportgate);
                        if (!saver.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(saver.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                "Transport Gate",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            this.IsRowEdit = false;
                            return;
                        }
                    }
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    transportgate.TransportGateID = (int)DataTypeParser.Parse(row["TransportGateID"].ToString(), typeof(int), -1);
                    sup = saver.Delete(transportgate);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    transportgate.TransportGateID = (int)DataTypeParser.Parse(row["TransportGateID"].ToString(), typeof(int), -1);
                    transportgate.TransportTypeID = (int)DataTypeParser.Parse(row["TransportTypeID"].ToString(), typeof(int), -1);
                    transportgate.GateName = String.IsNullOrEmpty(row["GateName"].ToString()) ? "" : row["GateName"].ToString();
                    transportgate.Remark = String.IsNullOrEmpty(row["Remark"].ToString()) ? "" : row["Remark"].ToString();
                    if (transportgate.TransportTypeID != -1 && transportgate.GateName != "")
                    {                        
                        sup = saver.Update(transportgate);
                        if (!saver.ValidationResults.IsValid)
                        {
                            ValidationResult err = DataUtil.GetFirst(saver.ValidationResults) as ValidationResult;
                            MessageBox.Show(
                                err.Message,
                                "Transport Gate",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            this.IsRowEdit = false;
                            return;
                        }
                    }
                }

                if (sup > 0)
                {
                    IsRowEdit = false;
                    LoadData();
                    BindData();
                    ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                }

            }
            catch (Exception sqle)
            {
                // show error message
            }
        }

        #endregion

        #region EventHandler
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dgvsetuptransportgate.SelectedRows)
                {
                    dgvsetuptransportgate.Rows.RemoveAt(item.Index);
                }
                Save();
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
            this.Close();
        }

        private void dgvsetuptransportgate_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvsetuptransportgate.Rows[e.RowIndex].Cells["No"].Value = (e.RowIndex + 1).ToString();
        }
        #endregion

        private void dgvsetuptransportgate_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvsetuptransportgate.Columns["GateName"].Index)
            {
                if (dgvsetuptransportgate.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    dgvsetuptransportgate.Rows[e.RowIndex].ErrorText = "GateName must be fill";
                    MessageBox.Show("ဂိတ်အမည်ထည့်ရမည်။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    dgvsetuptransportgate.CurrentCell.ErrorText = string.Empty;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvsetuptransportgate.CurrentCell.ColumnIndex;
                int iRow = dgvsetuptransportgate.CurrentCell.RowIndex;
                if (iColumn == dgvsetuptransportgate.Columns.Count - 1)
                {
                    if (iRow + 1 >= dgvsetuptransportgate.Rows.Count)
                    {
                        DataRow newRow = transportgateTbl.NewRow();
                        transportgateTbl.Rows.Add(newRow);
                        this.dgvsetuptransportgate.DataSource = transportgateTbl;
                        dgvsetuptransportgate[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        try
                        {
                            dgvsetuptransportgate.CurrentCell = dgvsetuptransportgate[0, iRow + 1];
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
                        dgvsetuptransportgate.CurrentCell = dgvsetuptransportgate[iColumn + 1, iRow];
                    }
                    catch (Exception ex)
                    {
                    }
                    //dgvsetupbsetting.CurrentCell = dgvsetupbsetting[dgvsetupbsetting.CurrentCell.ColumnIndex + 1, dgvsetupbsetting.CurrentCell.RowIndex];
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvsetuptransportgate.DataSource as DataTable);
            dgvsetuptransportgate.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dgvsetuptransportgate.CurrentCell = dgvsetuptransportgate.Rows[dgvsetuptransportgate.RowCount - 1].Cells["TransportType"];
        }

        private void dgvsetuptransportgate_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvsetuptransportgate.Rows[e.RowIndex].ErrorText != string.Empty)
            {
                dgvsetuptransportgate.CurrentRow.Cells[TransportType.Index].Value = -1;
                dgvsetuptransportgate.Rows[e.RowIndex].ErrorText = string.Empty;
            }
        }

        private void dgvsetuptransportgate_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvsetuptransportgate_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    if ((int)DataTypeParser.Parse(gridView.Rows[r.Index].Cells[TransportType.Index].Value, typeof(int), 0) != 0)
                    {
                        gridView.Rows[r.Index].ReadOnly = true;
                        //gridView.Rows[r.Index].Cells[clnSPDetailID.Index].ReadOnly = false;
                    }                   
                }
            }
        }

        private void dgvsetuptransportgate_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dgv = dgvsetuptransportgate as DataGridView;

            if (IsRowEdit == false)
            {
                dgv.CurrentRow.ReadOnly = false;
                IsRowEdit = true;
            }
            else
            {
                MessageBox.Show("သိမ်းမည် ကိုနှိပ်ပါ။", "သတိပေးချက်", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
      
    }
}

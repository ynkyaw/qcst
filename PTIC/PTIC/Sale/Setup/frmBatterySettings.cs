/* Author   :   Aung Ko Ko
    Date      :   13 Feb 2014
    Description :   
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AGL.UI.Controls;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.DA;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using PTIC.Util;
using PTIC.Sale.BL;
using PTIC.Common;

namespace PTIC.Sale.Setup
{
    public partial class frmBatterySettings : Form
    {
        DataTable productTbl = null;
        DataTable bsettingTbl = null;
        BatterySetting bsetting = new BatterySetting();

        public frmBatterySettings()
        {
            InitializeComponent();
            this.dgvsetupbsetting.Columns["TranDate"].DefaultCellStyle.Format = "dd-MMM-yyyy";
            LoadData();
            BindData();
            DataUtil.AddInitialNewRow(dgvsetupbsetting);
        }

        #region Private Method

        private void LoadData()  //Load Town Data for Grid
        {
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                productTbl = new ProductBL().GetAll();
                bsettingTbl = new BatterySettingBL().GetAll(conn);
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
            dgvsetupbsetting.AutoGenerateColumns = false;

            ProductName.DataSource = productTbl;
            ProductName.DisplayMember = "ProductName";
            ProductName.ValueMember = "ProductID";

            dgvsetupbsetting.DataSource = bsettingTbl;
        }

        private void Save()
        {
            DataTable dt = dgvsetupbsetting.DataSource as DataTable;

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
                    if (row.IsNull("TranDate") && row.IsNull("Weight") && row.IsNull("Qty")) continue;
                    bsetting.TranDate = (DateTime)DataTypeParser.Parse(row["TranDate"].ToString(), typeof(DateTime), null);
                    bsetting.Weight = (float)DataTypeParser.Parse(row["Weight"].ToString(), typeof(float), -1);
                    bsetting.Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), -1);

                    bsetting.ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1);
                    if (bsetting.ProductID == 0)
                    {
                        ToastMessageBox.Show("ပစၥည္းအမည္ ေရြးပါ");
                    }
                    else if (bsetting.TranDate < (DateTime)DataTypeParser.Parse("1/1/1900", typeof(DateTime), null))
                    {
                        ToastMessageBox.Show("သတ္မွတ္သည့္ေန႕ ေရြးပါ");
                    }
                    else if (bsetting.Weight < 1)
                    {
                        ToastMessageBox.Show("အိုးခြံအေလးခ်ိန္ ျဖည့္ပါ");
                    }
                    else if (bsetting.Qty < 1)
                    {
                        ToastMessageBox.Show("အိုးခြံအေရအတြက္ ျဖည့္ပါ");
                    }
                    else
                    {
                        sup = BatterySettingDA.Insert(bsetting, conn);
                    }
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    bsetting.BatterySettingID = (int)DataTypeParser.Parse(row["BatterySettingID"].ToString(), typeof(int), -1);
                    sup = BatterySettingDA.DeleteByID(bsetting, conn);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    bsetting.BatterySettingID = (int)DataTypeParser.Parse(row["BatterySettingID"].ToString(), typeof(int), -1);
                    bsetting.ProductID = (int)DataTypeParser.Parse(row["ProductID"].ToString(), typeof(int), -1);
                    bsetting.TranDate = (DateTime)DataTypeParser.Parse(row["TranDate"].ToString(), typeof(DateTime), null);
                    if (bsetting.ProductID == 0)
                    {
                        ToastMessageBox.Show("ပစၥည္းအမည္ ေရြးပါ");
                    }
                    else if (bsetting.TranDate < (DateTime)DataTypeParser.Parse("1/1/1900", typeof(DateTime), null))
                    {
                        ToastMessageBox.Show("သတ္မွတ္သည့္ေန႕ ေရြးပါ");
                    }
                    else
                    {
                        bsetting.Weight = (float)DataTypeParser.Parse(row["Weight"].ToString(), typeof(float), -1);
                        bsetting.Qty = (int)DataTypeParser.Parse(row["Qty"].ToString(), typeof(int), -1);
                        sup = BatterySettingDA.UpdateByID(bsetting, conn);
                    }
                }

                if (sup > 0)
                {
                    LoadData();
                    BindData();
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

        #region Event Handler

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Save();
            LoadData();
            BindData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvsetupbsetting.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dgvsetupbsetting.SelectedRows)
                    {
                        dgvsetupbsetting.Rows.RemoveAt(item.Index);
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
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
        }

        #endregion

        private void dgvsetupbsetting_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgvsetupbsetting_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvsetupbsetting.Columns["BWeight"].Index || e.ColumnIndex == dgvsetupbsetting.Columns["BQty"].Index)
            {
                dgvsetupbsetting.Rows[e.RowIndex].ErrorText = "";
                decimal newInteger;

                // Don't try to validate the 'new row' until finished  
                // editing since there 
                // is not any point in validating its initial value. 
                if (dgvsetupbsetting.Rows[e.RowIndex].IsNewRow) { return; }
                if (!decimal.TryParse(e.FormattedValue.ToString(),
                    out newInteger) || newInteger < 0)
                {
                    //e.Cancel = true;
                    dgvsetupbsetting.Rows[e.RowIndex].ErrorText = "the value must be a Positive integer";
                }
                else
                {
                    dgvsetupbsetting.CurrentCell.ErrorText = string.Empty;
                }
            }
            //else if (e.ColumnIndex == dgvsetupbsetting.Columns["TranDate"].Index || e.ColumnIndex == dgvsetupbsetting.Columns["ProductName"].Index)
            //{
            //    if (dgvsetupbsetting.Rows[e.RowIndex].IsNewRow) { return; }
            //    if (e.FormattedValue.ToString()==null)
            //    {
            //        e.Cancel = true;
            //        dgvsetupbsetting.Rows[e.RowIndex].ErrorText = "Choose desired value";
            //    }
            //}
        }

        private void dgvsetupbsetting_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            dgvsetupbsetting.Rows[e.RowIndex].ErrorText = "the value must be a Positive integer";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvsetupbsetting.CurrentCell.ColumnIndex;
                int iRow = dgvsetupbsetting.CurrentCell.RowIndex;
                if (iColumn == dgvsetupbsetting.Columns["BQty"].Index)
                {
                    if (iRow + 1 >= dgvsetupbsetting.Rows.Count)
                    {
                        if (dgvsetupbsetting.CurrentRow.ErrorText == String.Empty)
                        {
                            DataRow newRow = bsettingTbl.NewRow();
                            bsettingTbl.Rows.Add(newRow);
                            this.dgvsetupbsetting.DataSource = bsettingTbl;
                            dgvsetupbsetting[0, iRow + 1].Selected = true;
                        }
                    }
                    else
                    {
                        try
                        {
                            dgvsetupbsetting.CurrentCell = dgvsetupbsetting[0, iRow + 1];
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
                        dgvsetupbsetting.CurrentCell = dgvsetupbsetting[iColumn + 1, iRow];
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

        private void dgvsetupbsetting_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            var gv = sender as DataGridView;

            string curColumName = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name;
            DataGridViewRow curRow = gv.Rows[e.RowIndex];
            if (dgvsetupbsetting.Columns["ProductName"].Index == e.ColumnIndex)
            //if (curColumName.Equals("ProductID"))
            {
                for (int i = 0; i <= bsettingTbl.Rows.Count - 2; i++)
                {
                    if (Convert.ToInt32(bsettingTbl.Rows[i]["ProductID"]) == Convert.ToInt32(curRow.Cells["ProductName"].Value))
                    {
                        ToastMessageBox.Show("ယခုထုတ္ကုန္ကို သတ္မွတ္ျပီးသား ရွိပါသည္။", Color.Red);
                    }
                }
            }
        }

        private void dgvsetupbsetting_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataUtil.AddNewRow(dgvsetupbsetting.DataSource as DataTable);
            dgvsetupbsetting.CurrentCell = dgvsetupbsetting.Rows[dgvsetupbsetting.RowCount - 1].Cells["TranDate"];
        }

    }
}

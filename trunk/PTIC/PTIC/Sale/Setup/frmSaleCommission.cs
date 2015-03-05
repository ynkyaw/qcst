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
using PTIC.Sale.Entities;
using PTIC.Sale.DA;
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.Util;
using PTIC.Common;

namespace PTIC.Sale.Setup
{
    public partial class frmSaleCommission : Form
    {
        SaleCommission salecommission = new SaleCommission();
        DataTable salecommissionTbl =null;
        //int counter = 0;

        public frmSaleCommission()
        {
            InitializeComponent();
            LoadData();
            BindData();
            if (dgvsetupsalecommission.Rows.Count == 0)
            {
                DataRow newRow = salecommissionTbl.NewRow();
                salecommissionTbl.Rows.Add(newRow);
                this.dgvsetupsalecommission.DataSource = salecommissionTbl;
            }    
        }

        #region Private Method
        private void LoadData()  //Load Town Data for Grid
        {            
            try
            {                
                salecommissionTbl = new SaleCommissionBL().GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        private void BindData()  // Bind Data into DataGridView
        {
            // Auto Generate Columns
            dgvsetupsalecommission.AutoGenerateColumns = false;

            dgvsetupsalecommission.DataSource = salecommissionTbl;
        }

        private void Save()
        {
            DataTable dt = dgvsetupsalecommission.DataSource as DataTable;
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
                    salecommission.SaleCommPercent = (float)DataTypeParser.Parse(row["SaleCommPercent"].ToString(), typeof(float), -1);
                    salecommission.CommAmt1 = (decimal)DataTypeParser.Parse(row["CommAmt1"].ToString(), typeof(decimal), 0);
                    salecommission.CommAmt2 = (decimal)DataTypeParser.Parse(row["CommAmt2"].ToString(), typeof(decimal), 0);
                    if (salecommission.SaleCommPercent < 1)
                    {
                        ToastMessageBox.Show("ခံစားခြင့္ ျဖည့္ပါ");
                    }
                    else if (salecommission.CommAmt1 < 1 || salecommission.CommAmt2 < 2)
                    {
                        ToastMessageBox.Show("က်သင့္ေငြ ျဖည့္ပါ");
                    }
                    else if (salecommission.CommAmt1 > salecommission.CommAmt2)
                    {
                        ToastMessageBox.Show("က်သင့္ေငြ ကို ျပန္စိစစ္ပါ");
                    }
                    else if (salecommission.SaleCommPercent > 50)
                    {
                        ToastMessageBox.Show("ခံစားခြင့္ ကို ျပန္စိစစ္ပါ");
                    }
                    else
                    {
                        sup = new SaleCommissionBL().Insert(salecommission, conn);
                    }
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    salecommission.SaleCommissionID = (int)DataTypeParser.Parse(row["SaleCommissionID"].ToString(), typeof(int), -1);
                    sup = new SaleCommissionBL().Delete(salecommission, conn);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    salecommission.SaleCommissionID = (int)DataTypeParser.Parse(row["SaleCommissionID"].ToString(), typeof(int), -1);
                    salecommission.SaleCommPercent = (float)DataTypeParser.Parse(row["SaleCommPercent"].ToString(), typeof(float), -1);
                    salecommission.CommAmt1 = (decimal)DataTypeParser.Parse(row["CommAmt1"].ToString(), typeof(decimal), 0);
                    salecommission.CommAmt2 = (decimal)DataTypeParser.Parse(row["CommAmt2"].ToString(), typeof(decimal), 0);
                    sup = new SaleCommissionBL().Update(salecommission, conn);
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
        private void dgvsetupsalecommission_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvsetupsalecommission.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
            //counter++;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvsetupsalecommission.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dgvsetupsalecommission.SelectedRows)
                    {
                        dgvsetupsalecommission.Rows.RemoveAt(item.Index);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            //LoadData();
            //BindData();
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
            this.Close();
        }
        #endregion

        private void dgvsetupsalecommission_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            //ToastMessageBox.Show("character not allowed!", Color.Red);
            //dgvsetupsalecommission.Rows[e.RowIndex].ErrorText = "character not allowed!";
        }

        private void dgvsetupsalecommission_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvsetupsalecommission.Columns["SaleCommPercent"].Index)
            {
                float newInteger;
                if (dgvsetupsalecommission.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    e.Cancel = true;
                    ToastMessageBox.Show("Sale Commission Percent must be fill", Color.Red);
                    //dgvsetupsalecommission.Rows[e.RowIndex].ErrorText = "Sale Commission Percent must be fill";
                }
                else
                    if (!float.TryParse(e.FormattedValue.ToString(),
                        out newInteger) || newInteger < 0)
                    {
                        e.Cancel = true;
                        ToastMessageBox.Show("Sale Commission Percent is Wrong", Color.Red);
                        //dgvsetupsalecommission.Rows[e.RowIndex].ErrorText = "Sale Commission Percent must be integer";
                    }
                    else
                    {
                        dgvsetupsalecommission.CurrentCell.ErrorText = string.Empty;
                    }
            }
            if (e.ColumnIndex == dgvsetupsalecommission.Columns["CommAmt1"].Index || e.ColumnIndex == dgvsetupsalecommission.Columns["CommAmt2"].Index)
            {
                decimal newDecimal;
                if (dgvsetupsalecommission.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    e.Cancel = true;
                    ToastMessageBox.Show("Commission Amount must be fill", Color.Red);
                    //dgvsetupsalecommission.Rows[e.RowIndex].ErrorText = "Commission Amount must be fill";
                }
                else
                    if (!decimal.TryParse(e.FormattedValue.ToString(),
                        out newDecimal) || newDecimal < 0)
                    {
                        ToastMessageBox.Show("Commission Amount must be Decimal Number", Color.Red);
                        //dgvsetupsalecommission.Rows[e.RowIndex].ErrorText = "Commission Amount must be Decimal Number";
                    }
                    else
                    {
                        dgvsetupsalecommission.CurrentCell.ErrorText = string.Empty;
                    }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvsetupsalecommission.CurrentCell.ColumnIndex;
                int iRow = dgvsetupsalecommission.CurrentCell.RowIndex;
                if (iColumn == dgvsetupsalecommission.Columns.Count - 1)
                {
                    if (iRow + 1 >= dgvsetupsalecommission.Rows.Count)
                    {
                        DataRow newRow = salecommissionTbl.NewRow();
                        salecommissionTbl.Rows.Add(newRow);
                        this.dgvsetupsalecommission.DataSource = salecommissionTbl;
                        dgvsetupsalecommission[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        try
                        {
                            dgvsetupsalecommission.CurrentCell = dgvsetupsalecommission[0, iRow + 1];
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
                        dgvsetupsalecommission.CurrentCell = dgvsetupsalecommission[iColumn + 1, iRow];
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
            DataUtil.AddNewRow(dgvsetupsalecommission.DataSource as DataTable);
            dgvsetupsalecommission.CurrentCell = dgvsetupsalecommission.Rows[dgvsetupsalecommission.RowCount - 1].Cells["CommAmt1"];
        }    
        
    }
}

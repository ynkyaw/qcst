using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;using PTIC.Common;
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
using PTIC.Common;

namespace PTIC.Sale.Setup
{
    public partial class frmCashDiscount : Form
    {
        DataTable cashdiscountTbl = null;
        CashDiscount cashdiscount = new CashDiscount();

        public frmCashDiscount()
        {
            InitializeComponent();
            LoadData();
            BindData();
            if (dgvsetupcashdiscount.Rows.Count == 0)
            {
                DataRow newRow = cashdiscountTbl.NewRow();
                cashdiscountTbl.Rows.Add(newRow);
                this.dgvsetupcashdiscount.DataSource = cashdiscountTbl;
            }  
        }

        #region Private Method
        private void LoadData()  //Load Town Data for Grid
        {            
            try
            {                
                cashdiscountTbl = new CashDiscountBL().GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        private void BindData()  // Bind Data into DataGridView
        {
            // Auto Generate Columns
            dgvsetupcashdiscount.AutoGenerateColumns = false;

            dgvsetupcashdiscount.DataSource = cashdiscountTbl;
        }

        private void Save()
        {
            DataTable dt = dgvsetupcashdiscount.DataSource as DataTable;
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
                    cashdiscount.Date = (DateTime)DataTypeParser.Parse(row["Date"].ToString(), typeof(DateTime), null);
                    cashdiscount.CashCommPercent = (float)DataTypeParser.Parse(row["CashCommPercent"].ToString(), typeof(float), -1);
                    if (cashdiscount.Date < (DateTime)DataTypeParser.Parse("1/1/1900", typeof(DateTime), null))
                    {
                        ToastMessageBox.Show("ေန႕စြဲ ေရြးပါ");
                    }
                    else if (cashdiscount.CashCommPercent < 1)
                    {
                        ToastMessageBox.Show("ေလ်ွာ႕ေစ်းတြင္ ျဖည့္ပါ");
                    }
                    else
                    {
                        sup = new CashDiscountBL().Insert(cashdiscount, conn);
                    }
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    cashdiscount.CashDiscountID = (int)DataTypeParser.Parse(row["CashDiscountID"].ToString(), typeof(int), -1);
                    sup = new CashDiscountBL().Delete(cashdiscount, conn);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    cashdiscount.CashDiscountID = (int)DataTypeParser.Parse(row["CashDiscountID"].ToString(), typeof(int), -1);
                    cashdiscount.Date = (DateTime)DataTypeParser.Parse(row["Date"].ToString(), typeof(DateTime), null);
                    cashdiscount.CashCommPercent = (float)DataTypeParser.Parse(row["CashCommPercent"].ToString(), typeof(float), -1);

                    sup = new CashDiscountBL().Update(cashdiscount, conn);
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
        private void dgvsetupcashdiscount_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvsetupcashdiscount.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadData();
            BindData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow item in this.dgvsetupcashdiscount.SelectedRows)
                {
                    dgvsetupcashdiscount.Rows.RemoveAt(item.Index);
                }
                Save();
                DataUtil.AddInitialNewRow(dgvsetupcashdiscount);
                ToastMessageBox.Show(Resource.errSuccessfullyDeleted);
            }
        }

        private void lblSetup_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmSetupPage));
            this.Close();
        }
        #endregion

        private void dgvsetupcashdiscount_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvsetupcashdiscount.Columns["CashCommPercent"].Index)
            {
                //int newInteger;
                decimal newDecimal;
                if (dgvsetupcashdiscount.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    e.Cancel = true;
                    dgvsetupcashdiscount.Rows[e.RowIndex].ErrorText = "Cash Commission must be fill";
                }
                else
                    if (!decimal.TryParse(e.FormattedValue.ToString(),
                        out newDecimal) || newDecimal <= 0)
                    {
                        e.Cancel = true;
                        dgvsetupcashdiscount.Rows[e.RowIndex].ErrorText = "Cash Commission must be integer";
                    }
                    else
                    {
                        dgvsetupcashdiscount.CurrentCell.ErrorText = string.Empty;
                    }
            }
        }

        private void dgvsetupcashdiscount_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            dgvsetupcashdiscount.Rows[e.RowIndex].ErrorText = "Cash Commission must be integer";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvsetupcashdiscount.CurrentCell.ColumnIndex;
                int iRow = dgvsetupcashdiscount.CurrentCell.RowIndex;
                if (iColumn <= dgvsetupcashdiscount.Columns.Count - 1)
                {
                    if (iRow + 1 >= dgvsetupcashdiscount.Rows.Count)
                    {
                        DataRow newRow = cashdiscountTbl.NewRow();
                        cashdiscountTbl.Rows.Add(newRow);
                        this.dgvsetupcashdiscount.DataSource = cashdiscountTbl;
                        dgvsetupcashdiscount[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        try
                        {

                            dgvsetupcashdiscount.CurrentCell = dgvsetupcashdiscount[0, iRow + 1];
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

using System;
using System.Data;
using PTIC.Common;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using PTIC.VC;
using PTIC.Sale.Entities;
using PTIC.VC.Util;
using PTIC.Sale.BL;
using PTIC.Util;
using PTIC.VC.Marketing;

namespace PTIC.Sale.Setup
{
    public partial class frmCustomerClass : Form
    {
        DataTable customerclassTbl = null;
        CustomerClass customerclass = new CustomerClass();
        bool IsMarketing = false;

        public frmCustomerClass()
        {
            InitializeComponent();
            LoadData();
            BindData();
            if (dgvsetupcustomerclass.Rows.Count == 0)
            {
                DataRow newRow = customerclassTbl.NewRow();
                customerclassTbl.Rows.Add(newRow);
                this.dgvsetupcustomerclass.DataSource = customerclassTbl;
            }  
        
        }

        public frmCustomerClass(bool IsTrue):this()
        {
            IsMarketing = IsTrue;
        }

        #region Private Method
        private void LoadData()  //Load Town Data for Grid
        {            
            try
            {
                customerclassTbl = new CustomerClassBL().GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void BindData()  // Bind Data into DataGridView
        {
            // Auto Generate Columns
            dgvsetupcustomerclass.AutoGenerateColumns = false;

            dgvsetupcustomerclass.DataSource = customerclassTbl;
        }

        private void Save()
        {
            DataTable dt = dgvsetupcustomerclass.DataSource as DataTable;
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
                    customerclass.CusClass = String.IsNullOrEmpty(row["CusClass"].ToString()) ? "" : row["CusClass"].ToString();
                    customerclass.Description = String.IsNullOrEmpty(row["Description"].ToString()) ? "" : row["Description"].ToString();
                    customerclass.Remark = String.IsNullOrEmpty(row["Remark"].ToString()) ? "" : row["Remark"].ToString();
                    sup = new CustomerClassBL().Insert(customerclass, conn);
                }

                // delete
                DataView dvDelete = new DataView(dt, string.Empty, string.Empty, DataViewRowState.Deleted);
                foreach (DataRow row in dvDelete.ToTable().Rows)
                {
                    customerclass.CustomerClassID =(int)DataTypeParser.Parse(row["CustomerClassID"].ToString(),typeof(int),-1);
                    sup = new CustomerClassBL().Delete(customerclass,conn);
                }

                // update
                DataView dvUpdate = new DataView(dt, string.Empty, string.Empty, DataViewRowState.ModifiedCurrent);
                foreach (DataRow row in dvUpdate.ToTable().Rows)
                {
                    customerclass.CustomerClassID =(int)DataTypeParser.Parse(row["CustomerClassID"].ToString(),typeof(int),-1);
                    customerclass.CusClass = String.IsNullOrEmpty(row["CusClass"].ToString()) ? "" : row["CusClass"].ToString();
                    customerclass.Description = String.IsNullOrEmpty(row["Description"].ToString()) ? "" : row["Description"].ToString();
                    customerclass.Remark = String.IsNullOrEmpty(row["Remark"].ToString()) ? "" : row["Remark"].ToString();
                    sup = new CustomerClassBL().Update(customerclass, conn);
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

        #region EventHandler
        private void dgvsetupcustomerclass_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgvsetupcustomerclass.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvsetupcustomerclass.SelectedRows.Count > 0)
            {

                if (MessageBox.Show("Are you sure want to delete Row(s)?", "Remove confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in this.dgvsetupcustomerclass.SelectedRows)
                    {
                        dgvsetupcustomerclass.Rows.RemoveAt(item.Index);
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
            LoadData();
            BindData();
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

        private void dgvsetupcustomerclass_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvsetupcustomerclass.Columns["CusClass"].Index)
            {
                if (dgvsetupcustomerclass.Rows[e.RowIndex].IsNewRow) { return; }
                if (e.FormattedValue.ToString() == null || e.FormattedValue.ToString() == "")
                {
                    e.Cancel = true;
                    dgvsetupcustomerclass.Rows[e.RowIndex].ErrorText = "Customer Class must be fill";
                }
                else
                {
                    dgvsetupcustomerclass.CurrentCell.ErrorText = string.Empty;
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                int iColumn = dgvsetupcustomerclass.CurrentCell.ColumnIndex;
                int iRow = dgvsetupcustomerclass.CurrentCell.RowIndex;
                if (iColumn == dgvsetupcustomerclass.Columns.Count - 1)
                {
                    if (iRow + 1 >= dgvsetupcustomerclass.Rows.Count)
                    {
                        DataRow newRow = customerclassTbl.NewRow();
                        customerclassTbl.Rows.Add(newRow);
                        this.dgvsetupcustomerclass.DataSource = customerclassTbl;
                        dgvsetupcustomerclass[0, iRow + 1].Selected = true;
                    }
                    else
                    {
                        try
                        {
                            dgvsetupcustomerclass.CurrentCell = dgvsetupcustomerclass[0, iRow + 1];
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
                        dgvsetupcustomerclass.CurrentCell = dgvsetupcustomerclass[iColumn + 1, iRow];
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
            DataUtil.AddNewRow(dgvsetupcustomerclass.DataSource as DataTable);
            dgvsetupcustomerclass.CurrentCell = dgvsetupcustomerclass.Rows[dgvsetupcustomerclass.RowCount - 1].Cells["CusClass"];
        }
    }
}

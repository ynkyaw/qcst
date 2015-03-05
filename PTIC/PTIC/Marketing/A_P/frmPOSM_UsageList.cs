using System;using PTIC.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;using PTIC.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.VC.Marketing.A_P;
using log4net;
using log4net.Config;
using PTIC.Common.BL;
using PTIC.VC;
using System.Data.SqlClient;
using PTIC.Marketing.BL;
using PTIC.VC.Util;

namespace PTIC.Marketing.A_P
{
    public partial class frmPOSM_UsageList : Form
    {
        /// <summary>
        /// Logger for frmPOSM_UsageList
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(frmPOSM_UsageList));

        #region Events
        private void lblBakToAP_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmA_PMain));
            this.Close();
        }

        private void dgvPOSM_Usage_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                // Set row number
                foreach (DataGridViewRow r in dgv.Rows)
                {
                    dgv.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
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

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            txtDate.Enabled = dtpKW_Date.Enabled = chkDate.Checked;
            CheckKeywordSelection();
        }

        private void chkDepartment_CheckedChanged(object sender, EventArgs e)
        {
            txtDepartment.Enabled = cmbKW_Department.Enabled = chkDepartment.Checked;
            CheckKeywordSelection();
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int? kwDepartmentID = null;
            DateTime kwDate = DateTime.MinValue;
            if(chkDate.Checked)
                kwDate = (DateTime)DataTypeParser.Parse(dtpKW_Date.Value, typeof(DateTime), DateTime.MinValue);
            if(chkDepartment.Checked)
                kwDepartmentID = (int?)DataTypeParser.Parse(cmbKW_Department.SelectedValue, typeof(int), null);
            Search(kwDate, kwDepartmentID);
        }

        private void dgvPOSM_Usage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.CurrentRow == null || dgv.CurrentRow.Index < 0)
                return;

            int? usageID = (int?)DataTypeParser.Parse(dgv.CurrentRow.Cells[colPOSM_UsageID.Index].Value, typeof(int), null);
            DateTime date = (DateTime)DataTypeParser.Parse(dgv.CurrentRow.Cells[colDate.Index].Value, typeof(DateTime), DateTime.MinValue);
            int? deptID = (int?)DataTypeParser.Parse(dgv.CurrentRow.Cells[colDeptID.Index].Value, typeof(int), null);
            int? inchargeID = (int?)DataTypeParser.Parse(dgv.CurrentRow.Cells[colInchargeID.Index].Value, typeof(int), null);
            if (usageID.HasValue
                && date != DateTime.MinValue
                && deptID.HasValue
                && inchargeID.HasValue
                )
                UIManager.OpenForm(new frmPOSM_Usage(usageID.Value, date, deptID.Value, inchargeID.Value));
        }

        #endregion

        #region Private Methods
        private void LoadNBindNecessaryData()
        {
            SqlConnection conn = null;
            DataTable dtDept = null;
            try
            {
                // Get db connection
                conn = DBManager.GetInstance().GetDbConnection();
                dtDept = new DepartmentBL().GetAll();
                this.cmbKW_Department.DataSource = dtDept;
                this.colDeptID.DataSource = dtDept.Copy();
                this.colInchargeID.DataSource = new EmployeeBL().GetAll();
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
            }
            finally
            {
                DBManager.GetInstance().CloseDbConnection();
            }
        }

        private void CheckKeywordSelection()
        {
            if (!chkDate.Checked && !chkDepartment.Checked)
                btnSearch.Enabled = false;
            else
                btnSearch.Enabled = true;
        }

        private void Search(DateTime kwDate, int? kwDepartmentID)
        {
            this.dgvPOSM_Usage.DataSource = new POSM_UsageBL().GetUsageList(kwDate, kwDepartmentID);
            if(this.dgvPOSM_Usage.Rows.Count < 1)
                MessageBox.Show("There is no record to display!", "No record",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Constructor
        public frmPOSM_UsageList()
        {
            InitializeComponent();
            dgvPOSM_Usage.AutoGenerateColumns = false;
            // Set value and display of GridViewComboBoxColumn
            colDeptID.ValueMember = "ID";
            colDeptID.DisplayMember = "DeptName";
            colInchargeID.ValueMember = "EmployeeID";
            colInchargeID.DisplayMember = "EmpName";
            // Configure logger
            XmlConfigurator.Configure();
            // Load necessary data
            LoadNBindNecessaryData();
        }
        #endregion
        
    }
}

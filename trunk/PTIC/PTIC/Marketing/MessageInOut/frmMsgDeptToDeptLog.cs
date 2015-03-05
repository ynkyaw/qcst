using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Common.BL;
using PTIC.VC.Util;

namespace PTIC.Marketing.MessageInOut
{
    public partial class frmMsgDeptToDeptLog : Form
    {
        #region Events
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

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMsgInOutPage));
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int? fromDeptID = chkFromDept.Checked ? (int?)DataTypeParser.Parse(cmbFromDept.SelectedValue, typeof(int), null) : null;
            int? toDeptID = chkToDept.Checked ? (int?)DataTypeParser.Parse(cmbToDept.SelectedValue, typeof(int), null) : null;
            Search(dtpStartDate.Value, dtpEndDate.Value, fromDeptID, toDeptID);
        }
        #endregion

        #region Private Methods
        private void LoadNBind()
        {
            DataTable dtDepartment = new DepartmentBL().GetAll();

            cmbFromDept.DataSource = dtDepartment;
            cmbFromDept.ValueMember = "ID";
            cmbFromDept.DisplayMember = "DeptName";

            cmbToDept.DataSource = dtDepartment.Copy();
            cmbToDept.ValueMember = "ID";
            cmbToDept.DisplayMember = "DeptName";

            colSenderAction.DataSource = GetSenderAction();
        }

        private DataTable GetSenderAction()
        {
            DataTable dt = new DataTable();            
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID", typeof(int)), new DataColumn("SenderAction", typeof(string))
            });

            DataRow row = dt.NewRow();
            row["ID"] = (int)PTIC.Common.Enum.MessageSenderAction.Send;
            row["SenderAction"] = PTIC.Common.Enum.MessageSenderAction.Send;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["ID"] = (int)PTIC.Common.Enum.MessageSenderAction.Reply;
            row["SenderAction"] = PTIC.Common.Enum.MessageSenderAction.Reply;
            dt.Rows.Add(row);

            row = dt.NewRow();
            row["ID"] = (int)PTIC.Common.Enum.MessageSenderAction.Forward;
            row["SenderAction"] = PTIC.Common.Enum.MessageSenderAction.Forward;
            dt.Rows.Add(row);
            
            return dt;
        }

        private void Search(DateTime startDate, DateTime endDate, int? fromDeptID, int? toDeptID)
        {
            DataTable msg = new UserMessageBL().GetBy(startDate, endDate, fromDeptID, toDeptID);
            dgvMessage.DataSource = msg;
            if (msg == null || msg.Rows.Count < 1)
            {
                MessageBox.Show(
                    "There is no record found!",
                    "Search",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FixTextEscape();
        }

        private void FixTextEscape()
        {
            foreach (DataGridViewRow row in dgvMessage.Rows) 
            {
                row.Cells[colToDept.Index].Value =
                    ((string)DataTypeParser.Parse(row.Cells[colToDept.Index].Value, typeof(string), string.Empty)).Replace("&amp;", "&"); 
            }
        }
        #endregion

        #region Constructors
        public frmMsgDeptToDeptLog()
        {
            InitializeComponent();
            this.dgvMessage.AutoGenerateColumns = false;
            this.colSenderAction.ValueMember = "ID";
            this.colSenderAction.DisplayMember = "SenderAction";

            LoadNBind();
        }
        #endregion

                        
    }
}

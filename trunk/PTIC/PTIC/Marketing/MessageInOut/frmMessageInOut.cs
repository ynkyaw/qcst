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
using PTIC.VC.Marketing.MessageInOut;
using PTIC.Common.Entities;

namespace PTIC.Marketing.MessageInOut
{
    public partial class frmMessageInOut : Form
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
            int deptID = (int)DataTypeParser.Parse(cmbDept.SelectedValue, typeof(int), -1);
            bool isInMsg = rdoIn.Checked ? true : false;
            if (deptID == -1)
                return;
            Search(deptID, isInMsg, dtpStartDate.Value, dtpEndDate.Value);
        }

        private void dgvMessage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!rdoIn.Checked)
                return;

            DataGridViewRow selectedRow = dgvMessage.CurrentRow;
            if (selectedRow == null)
                return;
            int messageThreadId = (int)DataTypeParser.Parse(selectedRow.Cells[colMessageThreadID.Index].Value, typeof(int), -1);
            PTIC.Common.Entities.Message msg = new PTIC.Common.Entities.Message()
            {
                Subject = (string)DataTypeParser.Parse(selectedRow.Cells[colDescription.Index].Value, typeof(string), string.Empty),
                Body = (string)DataTypeParser.Parse(selectedRow.Cells[colBody.Index].Value, typeof(string), string.Empty),
                Remark = (string)DataTypeParser.Parse(selectedRow.Cells[colRemark.Index].Value, typeof(string), string.Empty),
            };
            Employee msgSender = new Employee()
            {
                // reverse : previous receipient must be sender now
                ID = (int)DataTypeParser.Parse(selectedRow.Cells[colReceiverID.Index].Value, typeof(int), -1)
            };
            Employee recipient = new Employee()
            {
                // reverse : previous sender must be receipient now
                ID = (int)DataTypeParser.Parse(selectedRow.Cells[colSenderID.Index].Value, typeof(int), -1)
            };

            int senderAction = (int)DataTypeParser.Parse(selectedRow.Cells[colSenderAction.Index].Value, typeof(int), -1);
            frmComposeMessage frmReplyForward = new frmComposeMessage(
                messageThreadId,
                msg,
                msgSender,
                recipient
                //senderAction == (int)PTIC.Common.Enum.MessageSenderAction.Reply || msgSender.ID == -1 || recipient.ID == -1 ? false : true,
                //senderAction == (int)PTIC.Common.Enum.MessageSenderAction.Forward || msgSender.ID == -1 || recipient.ID == -1 ? false : true
                );
            UIManager.OpenForm(frmReplyForward);            
        }
        #endregion

        #region Private Methods
        private void LoadNBind()
        {
            DataTable dtDepartment = new DepartmentBL().GetAll();

            cmbDept.DataSource = dtDepartment;
            cmbDept.ValueMember = "ID";
            cmbDept.DisplayMember = "DeptName";

            colSenderAction.DataSource = GetSenderAction();
        }

        private void Search(int departmentID, bool isMessageIn, DateTime startDate, DateTime endDate)
        {
            DataTable messages = new UserMessageBL().GetMsgInOrOutBy(departmentID, isMessageIn, startDate, endDate);
            dgvMessage.DataSource = messages;
            if (messages == null || messages.Rows.Count < 1)
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
        #endregion

        #region Constructors
        public frmMessageInOut()
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

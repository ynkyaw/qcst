using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PTIC.Common.Entities;
using PTIC.Common.BL;
using PTIC.VC;
using PTIC.Util;
using PTIC.VC.Util;
using PTIC.Marketing.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace PTIC.Marketing.MessageInOut
{
    public partial class frmExternalComposeMessage : Form
    {
        DataTable dtEmployee = null;
        DataTable dtEmployeesByDept = null;
        private List<Employee> EmployeesList = null;
        int SenderMsgNoInt = -1;
        int MessageThreadID = -1;

        public frmExternalComposeMessage()
        {
            InitializeComponent();
            LoadNBind();
            if (cmbSenderEmployee.Items.Count > 0)
            {
                cmbSenderEmployee.SelectedIndex = 0;
            }
            rdoExternalSender.Checked = true;
        }

        #region Private Methods
        private void Clear()
        {
            txtReciever.Text = string.Empty;
            txtRecieverDept.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtBody.Text = string.Empty;
            txtRemark.Text = string.Empty;
            txtExternalRec.Text = string.Empty;
            txtSender.Text = string.Empty;
        }

        public void LoadNBind()
        {
            dtEmployee = new MessageUsersBL().GetAllMsgUsers();
            if (Program.module == Program.Module.Marketing)
            {
                dtEmployeesByDept = DataUtil.GetDataTableBy(dtEmployee, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Marketing);
            }
            else if (Program.module == Program.Module.Sale)
            {
                dtEmployeesByDept = DataUtil.GetDataTableBy(dtEmployee, "DeptID", (int)PTIC.Common.Enum.PredefinedDepartment.Sales);
            }
            // DataTable Formating
            if (dtEmployeesByDept == null)
            {
                dtEmployeesByDept = dtEmployee.Clone();
            }
            cmbSenderEmployee.DataSource = dtEmployeesByDept;
            cmbSenderEmployee.ValueMember = "EmployeeID";
            cmbSenderEmployee.DisplayMember = "EmpName";
            cmbSenderEmployee.SelectedIndex = -1;
            // Initialize receiver lists
            EmployeesList = new List<Employee>();
        }

        private void Save()
        {
            int? affectedrow = null;
            UserMessageBL messenger = null;
            try
            {
                messenger = new UserMessageBL();
                List<UserMessage> insertUserMessage = new List<UserMessage>();
                UserMessage _senderuserMessage = null;

                PTIC.Common.Entities.Message _message = new Common.Entities.Message()
                {
                    Subject = (string)DataTypeParser.Parse(txtSubject.Text, typeof(string), null),
                    Body = (string)DataTypeParser.Parse(txtBody.Text, typeof(string), null),
                    Remark = (string)DataTypeParser.Parse(txtRemark.Text, typeof(string), null),
                };

                MessageThread _messageThread = new MessageThread()
                {
                    Date = (DateTime)DataTypeParser.Parse(DateTime.Now, typeof(DateTime), DateTime.Now)
                };

                if (rdoExternalSender.Checked && rdoInternalRec.Checked)
                {
                    foreach (Employee employee in EmployeesList)
                    {
                        UserMessage _userMessage = new UserMessage()
                        {
                            SenderID = (int?)DataTypeParser.Parse(null, typeof(int), null),
                            ReceiverID = (int?)DataTypeParser.Parse(employee.ID, typeof(int), null),
                            SenderAction = (int)PTIC.Common.Enum.MessageSenderAction.Send,
                            MessageBox =(int)PTIC.Common.Enum.MessageBox.Inbox,
                            Sender = (string)DataTypeParser.Parse(txtSender.Text, typeof(string), string.Empty),
                            Receiver = null,
                            Status = (int)PTIC.Common.Enum.UserMessageStatus.Confirmed
                        };
                        insertUserMessage.Add(_userMessage);
                    }   //  End of foreach (Employee employee in EmployeesList)

                }
                else if (rdoInternalSender.Checked && rdoExternalRec.Checked)
                {
                    UserMessage _userMessage = new UserMessage()
                    {
                        SenderID = (int?)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), null),
                        ReceiverID = (int?)DataTypeParser.Parse(null, typeof(int), null),
                        SenderAction = (int)PTIC.Common.Enum.MessageSenderAction.Send,
                        Sender = null,
                        MessageBox =(int)PTIC.Common.Enum.MessageBox.Sentbox,
                        Receiver = (string)DataTypeParser.Parse(txtExternalRec.Text,typeof(string),string.Empty),
                        Status = (int)PTIC.Common.Enum.UserMessageStatus.Confirmed
                    };
                    insertUserMessage.Add(_userMessage);
                }
                else
                {
                    return;
                }

                if (insertUserMessage == null)
                {
                    MessageBox.Show
                        (
                        Common.ErrorMessages.UserMessage_Receiver_Require,
                        "ပြင်ပနှင့်ဆက်သွယ်စာ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
                    return;
                }

                // Save
                affectedrow = messenger.AddExternalConfirmMsg(
                        _message,
                        _messageThread,
                        insertUserMessage);
                
                // Check field validation failed or not
                if (!messenger.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(messenger.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        "ပြင်ပနှင့်ဆက်သွယ်စာ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else // Successful validation
                {
                    // Success in db also
                    if (affectedrow.HasValue && affectedrow.Value > 0)
                    {
                        ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                        Clear();
                        LoadNBind();
                    }
                    else
                        ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Data များဖြည့်သွင်းပါ။",
                    "ပြင်ပနှင့်ဆက်သွယ်စာ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        #endregion

        private void rdoExternalSender_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoExternalSender.Checked)
            {
                rdoInternalRec.Checked = true;
                cmbSenderEmployee.Visible = false;
                txtSender.Visible = true;
                txtSenderDept.Visible = false;
                txtSenderPost.Visible = false;
                lblSenderDept.Visible = false;
                lblSenderPost.Visible = false;
            }
            else
            {
                rdoExternalRec.Checked = true;
                cmbSenderEmployee.Visible = true;
                txtSenderDept.Visible = true;
                txtSenderPost.Visible = true;
                lblSenderDept.Visible = true;
                lblSenderPost.Visible = true;
                txtSender.Visible = false;
            }
        }

        private void rdoExternalRec_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoExternalRec.Checked)
            {
                rdoInternalSender.Checked = true;
                txtExternalRec.Visible = true;
                txtReciever.Visible = false;
                lblRecDept.Visible = false;
                txtRecieverDept.Visible = false;
                btnSelect.Visible = false;
            }
            else
            {
                rdoExternalSender.Checked = true;
                txtExternalRec.Visible = false;
                txtReciever.Visible = true;
                lblRecDept.Visible = true;
                txtRecieverDept.Visible = true;
                btnSelect.Visible = true;
            }
        }

        private void btnDirectlySend_Click(object sender, EventArgs e)
        {            
            Save();
        }

        private void cmbSenderEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtEmployeesByDept == null) return;

            int EmployeeID = (int)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), -1);
            DataTable SelectedCustomer = DataUtil.GetDataTableBy(dtEmployeesByDept, "EmployeeID", EmployeeID);
            if (SelectedCustomer == null) return;
            if (SelectedCustomer.Rows.Count > 0)
            {
                txtSenderDept.Text = (string)DataTypeParser.Parse(SelectedCustomer.Rows[0]["DeptName"], typeof(string), string.Empty);
                txtSenderPost.Text = (string)DataTypeParser.Parse(SelectedCustomer.Rows[0]["PostName"], typeof(string), string.Empty);
            }
            else
            {
                txtSenderPost.Text = string.Empty;
                txtSenderDept.Text = string.Empty;
            }

            DataTable dtMsgNo = new UserMessageBL().SelectMsgNo(txtSenderDept.Text);
            if (dtMsgNo.Rows.Count > 0)
            {
                SenderMsgNoInt = (int)DataTypeParser.Parse(dtMsgNo.Rows[0]["MsgNoInt"], typeof(int), 1);
                txtMsgNo.Text = txtSenderDept.Text + "-" + SenderMsgNoInt + " / " + (int)DataTypeParser.Parse(dtMsgNo.Rows[0]["Year"], typeof(int), 0);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Open invoice lookup form
            frmRecieverPicker recieverPicker = new frmRecieverPicker();
            recieverPicker.EmployeeSelectedHandler += new frmRecieverPicker.EmployeeSelectionHandler(employeeSelection_CallBack);
            // Set call back handler
            UIManager.OpenForm(recieverPicker);
        }

        private void employeeSelection_CallBack(object sender, frmRecieverPicker.EmployeeSelectionEventArgs args)
        {
            if (args.Employees == null)
                return;
            EmployeesList = new List<Employee>();
            foreach (Employee insertemployee in args.Employees)
            {
                if (insertemployee.EmployeeInTripPlanDetailID == 0)
                    EmployeesList.Add(insertemployee);
            }

            string DeptName = string.Empty;
            string Post = string.Empty;
            foreach (Employee employee in EmployeesList)
            {
                DataTable dtEmployeeByID = DataUtil.GetDataTableBy(dtEmployee, "EmployeeID", employee.ID);

                // DeptName
                DeptName += string.IsNullOrEmpty(dtEmployeeByID.Rows[0]["DeptName"].ToString()) ? string.Empty : dtEmployeeByID.Rows[0]["DeptName"].ToString() + "/ \r\n";

                //Position
                Post += string.IsNullOrEmpty(dtEmployeeByID.Rows[0]["PostName"].ToString()) ? string.Empty : dtEmployeeByID.Rows[0]["PostName"].ToString() + "/ \r\n";

            }
            DeptName = DeptName.Replace("//", "/");
            int j = DeptName.LastIndexOf('/');
            DeptName = DeptName.Remove(j);

            Post = Post.Replace("//", "/");
            int i = Post.LastIndexOf('/');
            Post = Post.Remove(i);
            txtRecieverDept.Text = DeptName;
            txtReciever.Text = Post;
        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMsgInOutPage));
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PTIC.Common.BL;
using PTIC.Util;
using PTIC.VC.Util;
using PTIC.Marketing.MessageInOut;
using PTIC.Common.Entities;
using PTIC.Marketing.BL;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.Drawing;
using PTIC.Common;

namespace PTIC.VC.Marketing.MessageInOut
{
    public partial class frmComposeMessage : Form
    {
        DataTable dtEmployee = null;
        DataTable dtEmployeesByDept = null;
        private List<Employee> ReceiverEmployeesList = null;
        int SenderMsgNoInt = -1;
        int MessageThreadID = -1;

        #region Events
        private void cmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtEmployeesByDept == null) return;

            int EmployeeID = (int)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), -1);
            //DataTable SelectedCustomer = DataUtil.GetDataTableBy(dtEmployeesByDept, "EmployeeID", EmployeeID);
            DataTable SelectedCustomer = DataUtil.GetDataTableBy(dtEmployee, "EmployeeID", EmployeeID);
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
            btnReply.Enabled = false;
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
            ReceiverEmployeesList = new List<Employee>();
            foreach (Employee insertemployee in args.Employees)
            {
                if (insertemployee.EmployeeInTripPlanDetailID == 0)
                    ReceiverEmployeesList.Add(insertemployee);
            }

            string DeptName = string.Empty;
            string Post = string.Empty;
            foreach (Employee employee in ReceiverEmployeesList)
            {
                DataTable dtEmployeeByID = DataUtil.GetDataTableBy(dtEmployee, "EmployeeID", employee.ID);

                // DeptName
                DeptName += string.IsNullOrEmpty(dtEmployeeByID.Rows[0]["DeptName"].ToString()) ? string.Empty : dtEmployeeByID.Rows[0]["DeptName"].ToString() + "/ \r\n";

                //Position
                Post += string.IsNullOrEmpty(dtEmployeeByID.Rows[0]["PostName"].ToString()) ? string.Empty : dtEmployeeByID.Rows[0]["PostName"].ToString() + "/ \r\n";

            }
            DeptName = DeptName.Replace("//", "/");
            int j = DeptName.LastIndexOf('/');
            if (j == -1) return;
            DeptName = DeptName.Remove(j);

            Post = Post.Replace("//", "/");
            int i = Post.LastIndexOf('/');
            if (i == -1) return;
            Post = Post.Remove(i);
            txtRecieverDept.Text = DeptName;
            txtReciever.Text = Post;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*
            if (this.ReceiverEmployeesList == null) return;
            if (this.ReceiverEmployeesList.Count < 1)
            {
                MessageBox.Show("လက်ခံသူ နှင့် လက်ခံသည့် ဌာန ရွေးချယ်ရမည်။", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             */             
            Save((int)PTIC.Common.Enum.UserMessageStatus.Pending);
        }

        private void btnDirectlySend_Click(object sender, EventArgs e)
        {
            /*
            if (this.ReceiverEmployeesList == null)return;
            if(this.ReceiverEmployeesList.Count < 1)
            {
                MessageBox.Show("လက်ခံသူ နှင့် လက်ခံသည့် ဌာန ရွေးချယ်ရမည်။", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             */             
            Save((int)PTIC.Common.Enum.UserMessageStatus.Confirmed);
        }

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMsgInOutPage));
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.MessageThreadID != -1)
            {
                ConfimrMessage();
            }
        }

        private void rdoExternalSender_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            Reply();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            Forward();
        }
        #endregion

        #region Private Methods
        private void Clear()
        {
            txtReciever.Text = string.Empty;
            txtRecieverDept.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtBody.Text = string.Empty;
            txtRemark.Text = string.Empty;
            if (this.ReceiverEmployeesList != null && this.ReceiverEmployeesList.Count > 0)
                this.ReceiverEmployeesList.Clear();
        }

        private void ConfimrMessage()
        {
            //DataTable dt = dgvConfirmMessage.DataSource as DataTable;
            //var dgv = dgvConfirmMessage;
            int affectedRows = -1;
            //if (dgv == null) return;

            List<UserMessage> _userMessageList = new List<UserMessage>();

            //int MessageThreadID = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colMessageThreadID.Index].Value, typeof(int), -1);
            DataTable tmpUserMessage = new UserMessageBL().SelectAllByUserMessageThreadID(this.MessageThreadID);
            if (tmpUserMessage == null) return;

            foreach (DataRow usermsgrow in tmpUserMessage.Rows)
            {
                int SenderID = (int)DataTypeParser.Parse(usermsgrow["SenderID"], typeof(int), -1);
                int ReceiverID = (int)DataTypeParser.Parse(usermsgrow["ReceiverID"], typeof(int), -1);
                int MessageBox = (int)DataTypeParser.Parse(usermsgrow["MessageBox"], typeof(int), -1);

                if (MessageBox == (int)PTIC.Common.Enum.MessageBox.Sentbox)
                {
                    UserMessage _userMessage = new UserMessage()
                    {
                        ID = (int)DataTypeParser.Parse(usermsgrow["ID"], typeof(int), -1),
                        SenderID = (int?)DataTypeParser.Parse(usermsgrow["SenderID"], typeof(int), null),
                        ReceiverID = (int?)DataTypeParser.Parse(null, typeof(int), null),
                        Status = (int)PTIC.Common.Enum.UserMessageStatus.Confirmed
                    };
                    _userMessageList.Add(_userMessage);
                }
                else
                {
                    UserMessage _userMessage = new UserMessage()
                    {
                        ID = (int)DataTypeParser.Parse(usermsgrow["ID"], typeof(int), -1),
                        SenderID = (int?)DataTypeParser.Parse(null, typeof(int), null),
                        ReceiverID = (int?)DataTypeParser.Parse(usermsgrow["ReceiverID"], typeof(int), null),
                        Status = (int)PTIC.Common.Enum.UserMessageStatus.Confirmed
                    };
                    _userMessageList.Add(_userMessage);
                }

            }

            if (_userMessageList.Count > 0)
            {
                affectedRows += new UserMessageBL().Update(_userMessageList);
            }

            if (affectedRows > 0)
            {
                ToastMessageBox.Show(Resource.msgSuccessfullySaved);
                this.Close();
            }

        }

        private void ViewData(int MessageThreadID)
        {
            DataTable dt = new UserMessageBL().SelectAllByMessageThreadID(MessageThreadID);
            if (dt == null) return;
            int RecRank = -1;
            string RecPostName = string.Empty;
            string RecDeptName = string.Empty;

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow tmprow in dt.Rows)
                {
                    RecRank = (int)DataTypeParser.Parse(tmprow["ReceiverPostRank"], typeof(int), -1);
                    RecPostName += string.IsNullOrEmpty(tmprow["ReceiverPostName"].ToString()) ? string.Empty : tmprow["ReceiverPostName"].ToString() + ", ";
                    RecDeptName += string.IsNullOrEmpty(tmprow["ReceiverDeptName"].ToString()) ? string.Empty : tmprow["ReceiverDeptName"].ToString() + ", ";
                }
                int i = RecDeptName.LastIndexOf(',');
                RecDeptName = RecDeptName.Remove(i);

                int j = RecPostName.LastIndexOf(',');
                RecPostName = RecPostName.Remove(j);

                cmbSenderEmployee.SelectedValue = (int)DataTypeParser.Parse(dt.Rows[0]["SenderID"], typeof(int), -1);
                txtSubject.Text = (string)DataTypeParser.Parse(dt.Rows[0]["Subject"], typeof(string), string.Empty);
                txtBody.Text = (string)DataTypeParser.Parse(dt.Rows[0]["Body"], typeof(string), string.Empty);
                txtRemark.Text = (string)DataTypeParser.Parse(dt.Rows[0]["Remark"], typeof(string), string.Empty);

                txtReciever.Text = RecPostName;
                txtRecieverDept.Text = RecDeptName;
            }
        }

        public void LoadNBind()
        {
            //dtEmployee = new MessageUsersBL().GetAllMsgUsers();
            dtEmployee = new EmployeeBL().GetAll();
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
            //cmbSenderEmployee.SelectedIndex = -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Status">Pending = 0, Confirmed = 1, Rejected = 2</param>
        private void Save(int Status)
        {
            int? affectedrow = null;
            UserMessageBL userMessageSaver = null;
            try
            {
                userMessageSaver = new UserMessageBL();

                List<UserMessage> insertUserMessage = new List<UserMessage>();

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

                UserMessage _senderuserMessage = new UserMessage()
                {
                    SenderID = (int?)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), null),
                    ReceiverID = (int?)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), null),
                    SenderAction = (int)PTIC.Common.Enum.MessageSenderAction.Send,
                    Sender = null,
                    Receiver = null,
                    Status = Status
                };

                if (ReceiverEmployeesList == null)
                {
                    MessageBox.Show
                        (   
                        ErrorMessages.UserMessage_Receiver_Require,
                        "ဌာနချင်းဆက်သွယ်စာ", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error
                        );  
                    return;
                }

                foreach (Employee employee in ReceiverEmployeesList)
                {
                    UserMessage _userMessage = new UserMessage()
                    {
                        SenderID = (int?)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), null),
                        ReceiverID = (int?)DataTypeParser.Parse(employee.ID, typeof(int), null),
                        SenderAction = (int)PTIC.Common.Enum.MessageSenderAction.Send,
                        Sender = null,
                        MessageBox = (int)PTIC.Common.Enum.MessageBox.Inbox,
                        Receiver = null,
                        Status = Status
                    };
                    insertUserMessage.Add(_userMessage);
                }   //  End of foreach (Employee employee in EmployeesList)

                if (Status == (int)PTIC.Common.Enum.UserMessageStatus.Pending)
                {
                    affectedrow = userMessageSaver.Add(_message, _messageThread, insertUserMessage, _senderuserMessage);
                }
                else if (Status == (int)PTIC.Common.Enum.UserMessageStatus.Confirmed)
                {
                    affectedrow = userMessageSaver.AddConfirmMsg(_message, _messageThread, insertUserMessage, _senderuserMessage);
                }

                // Check field validation failed or not
                if (!userMessageSaver.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(userMessageSaver.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        "ဌာနချင်းဆက်သွယ်စာ",
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
                    "အချက်အလက်များ မှန်ကန်စွာဖြည့်သွင်းပါရန်။", 
                    "Compose Message", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        private void Reply()
        {
            int? affectedrow;
            UserMessageBL messenger = null;
            try
            {
                messenger = new UserMessageBL();
                List<UserMessage> newReceiverUserMsgs = new List<UserMessage>();

                PTIC.Common.Entities.Message newMsg = new Common.Entities.Message()
                {
                    Subject = (string)DataTypeParser.Parse("Reply: " + txtSubject.Text, typeof(string), null),
                    //Body = (string)DataTypeParser.Parse(txtBody.Text, typeof(string), null),
                    Remark = (string)DataTypeParser.Parse(txtRemark.Text, typeof(string), null),
                };
                
                UserMessage newSenderUserMsg = new UserMessage()
                {
                    MessageThreadID = (int)DataTypeParser.Parse(this.MessageThreadID, typeof(int), -1),
                    SenderID = (int?)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), null),
                    ReceiverID = (int?)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), null)                                        
                };

                foreach (Employee employee in this.ReceiverEmployeesList)
                {
                    UserMessage _userMessage = new UserMessage()
                    {
                        SenderID = (int?)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), null),
                        ReceiverID = (int?)DataTypeParser.Parse(employee.ID, typeof(int), null),                                                
                    };
                    newReceiverUserMsgs.Add(_userMessage);
                }   //  End of foreach (Employee employee in EmployeesList)

                if (newReceiverUserMsgs.Count == 1)
                {
                    affectedrow = messenger.Reply(newMsg, newSenderUserMsg, newReceiverUserMsgs[0]);
                }
                else
                {
                    MessageBox.Show("Message recipients must not be more than one in reply!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check field validation failed or not
                if (!messenger.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(messenger.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        "ဌာနချင်းဆက်သွယ်စာ",
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
                        this.Close();
                    }
                    else
                        ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Forward()
        {
            int? affectedrow = null;
            UserMessageBL messenger = null;
            try
            {
                messenger = new UserMessageBL();
                List<UserMessage> newReceiverUserMsgs = new List<UserMessage>();

                PTIC.Common.Entities.Message newMsg = new Common.Entities.Message()
                {
                    Subject = (string)DataTypeParser.Parse("Forward: " + txtSubject.Text, typeof(string), null),                    
                    Remark = (string)DataTypeParser.Parse(txtRemark.Text, typeof(string), null),
                };

                UserMessage newSenderUserMsg = new UserMessage()
                {
                    MessageThreadID = (int)DataTypeParser.Parse(this.MessageThreadID, typeof(int), -1),
                    SenderID = (int?)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), null),
                    ReceiverID = (int?)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), null)
                };

                foreach (Employee employee in this.ReceiverEmployeesList)
                {
                    UserMessage _userMessage = new UserMessage()
                    {
                        SenderID = (int?)DataTypeParser.Parse(cmbSenderEmployee.SelectedValue, typeof(int), null),
                        ReceiverID = (int?)DataTypeParser.Parse(employee.ID, typeof(int), null),
                    };
                    newReceiverUserMsgs.Add(_userMessage);
                }   //  End of foreach (Employee employee in EmployeesList)

                // Forward message
                affectedrow = messenger.Forward(newMsg, newSenderUserMsg, newReceiverUserMsgs);

                // Check field validation failed or not
                if (!messenger.ValidationResults.IsValid)
                {
                    ValidationResult err = DataUtil.GetFirst(messenger.ValidationResults) as ValidationResult;
                    MessageBox.Show(
                        err.Message,
                        "ဌာနချင်းဆက်သွယ်စာ",
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
                        this.Close();
                    }
                    else
                        ToastMessageBox.Show(Resource.errFailedToSave, Color.Red);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShowRecipientInfo(List<Employee> recipients)
        {
            if (recipients == null || recipients.Count < 1)
                return;
            string DeptName = string.Empty;
            string Post = string.Empty;
            foreach (Employee employee in recipients)
            {
                if (employee.ID <= 0)
                    continue;
                DataTable dtEmployeeByID = DataUtil.GetDataTableBy(dtEmployee, "EmployeeID", employee.ID);
                // DeptName
                DeptName += string.IsNullOrEmpty(dtEmployeeByID.Rows[0]["DeptName"].ToString()) ? string.Empty : dtEmployeeByID.Rows[0]["DeptName"].ToString() + "/ \r\n";
                //Position
                Post += string.IsNullOrEmpty(dtEmployeeByID.Rows[0]["PostName"].ToString()) ? string.Empty : dtEmployeeByID.Rows[0]["PostName"].ToString() + "/ \r\n";
            }
            DeptName = DeptName.Replace("//", "/");
            int j = DeptName.LastIndexOf('/');
            if(j > 0)
                DeptName = DeptName.Remove(j);

            Post = Post.Replace("//", "/");
            int i = Post.LastIndexOf('/');
            if(i > 0)
                Post = Post.Remove(i);
            txtRecieverDept.Text = DeptName;
            txtReciever.Text = Post;
        }
        #endregion

        #region Constructors
        public frmComposeMessage()
        {
            InitializeComponent();
            LoadNBind();
            //cmbSenderEmployee.SelectedIndex = 0;
        }

        public frmComposeMessage(int MessageThreadID)
            : this()
        {
            this.MessageThreadID = MessageThreadID;
            ViewData(MessageThreadID);
            cmbSenderEmployee.Enabled = false;
            txtSubject.Enabled = false;
            txtBody.Enabled = false;
            txtRemark.Enabled = false;
            btnConfirm.Visible = true;
            btnConfirm.Enabled = true;
            btnDirectlySend.Enabled = false;
            btnSave.Enabled = false;
            btnSelect.Enabled = false;
        }

        /// <summary>
        /// Open message reply form
        /// </summary>
        /// <param name="messagedThreadID">Existing thread id</param>
        /// <param name="message">Incoming message</param>
        /// <param name="sender">Message sender</param>
        /// <param name="recipient">Message recipient</param>
        ///// <param name="allowReply">Allow reply</param>
        ///// <param name="allowForward">Allow forward</param>
        public frmComposeMessage(
            int messagedThreadID, 
            PTIC.Common.Entities.Message message, 
            Employee sender, 
            Employee recipient
           // bool allowReply,
           // bool allowForward
            )
            : this()
        {            
            this.MessageThreadID = messagedThreadID;
            
            if (this.ReceiverEmployeesList == null)
                this.ReceiverEmployeesList = new List<Employee>();
            this.ReceiverEmployeesList.Add(recipient);

            DataTable dtReceivers = new DataTable();
            dtReceivers.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("EmployeeID", typeof(int)),
                new DataColumn("EmpName", typeof(string))
            });            
            DataTable dtSenderReceivers = new UserMessageBL().GetReceiversByMessageThreadID(messagedThreadID);
            foreach (DataRow row in dtSenderReceivers.Rows)
            {
                DataRow newRow = dtReceivers.NewRow();
                newRow["EmployeeID"] = (int)DataTypeParser.Parse(row["ReceiverID"], typeof(int), -1);
                newRow["EmpName"] = (string)DataTypeParser.Parse(row["EmpName"], typeof(string), string.Empty);
                dtReceivers.Rows.Add(newRow);
            }
            cmbSenderEmployee.DataSource = dtReceivers;
            cmbSenderEmployee.SelectedValue = sender.ID;

            ShowRecipientInfo(new List<Employee>() 
            {
                recipient
            });

            if (message != null)
            {
                txtSubject.Text = message.Subject;
                txtBody.Text = message.Body;
                txtRemark.Text = message.Remark;
            }

            txtSubject.Enabled =
            txtBody.Enabled =
            //btnSelect.Enabled =
            btnSave.Enabled =
            btnDirectlySend.Enabled =
            btnConfirm.Enabled =
            cmbSenderEmployee.Enabled = false;

            btnReply.Enabled =
            btnForward.Enabled = true;
        }

        #endregion
                                        
    }
}

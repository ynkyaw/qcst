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
using PTIC.Common.Entities;
using PTIC.VC;
using PTIC.VC.Marketing.MessageInOut;

namespace PTIC.Marketing.MessageInOut
{
    public partial class frmMessageConfirm : Form
    {
        public frmMessageConfirm()
        {
            InitializeComponent();
            LoadNBind();
        }

        #region Private Methods
        private void LoadNBind()
        {
            dgvConfirmMessage.AutoGenerateColumns = false;
            dgvConfirmMessage.DataSource = new UserMessageBL().SelectMessageToConfirm(GlobalCache.LoginEmployee.ID);
        }

        //private void Save()
        //{
        //    //DataTable dt = dgvConfirmMessage.DataSource as DataTable;
        //    var dgv = dgvConfirmMessage;
        //    int affectedRows = -1;
        //    if (dgv == null) return;

        //    List<UserMessage> _userMessageList = new List<UserMessage>();
         
        //    foreach (DataGridViewRow row in dgv.Rows)
        //    {
        //        int MessageThreadID = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colMessageThreadID.Index].Value, typeof(int), -1);
        //        DataTable tmpUserMessage = new UserMessageBL().SelectAllByUserMessageThreadID(MessageThreadID);
        //        if (tmpUserMessage == null) return;
        //        bool Check = (bool)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colConfirm.Index].Value, typeof(bool), false);
        //        if (Check)
        //        {
        //            foreach (DataRow usermsgrow in tmpUserMessage.Rows)
        //            {
        //                int SenderID = (int)DataTypeParser.Parse(usermsgrow["SenderID"], typeof(int), -1);
        //                int ReceiverID = (int)DataTypeParser.Parse(usermsgrow["ReceiverID"], typeof(int), -1);

        //                if (SenderID == ReceiverID)
        //                {
        //                    UserMessage _userMessage = new UserMessage()
        //                    {
        //                        ID = (int)DataTypeParser.Parse(usermsgrow["ID"], typeof(int), -1),
        //                        SenderID = (int?)DataTypeParser.Parse(usermsgrow["SenderID"], typeof(int), null),
        //                        ReceiverID = (int?)DataTypeParser.Parse(null, typeof(int), null),
        //                        Status = (int)PTIC.Common.Enum.UserMessageStatus.Confirmed
        //                    };
        //                    _userMessageList.Add(_userMessage);
        //                }
        //                else
        //                {
        //                    UserMessage _userMessage = new UserMessage()
        //                    {
        //                        ID = (int)DataTypeParser.Parse(usermsgrow["ID"], typeof(int), -1),
        //                        SenderID = (int?)DataTypeParser.Parse(null, typeof(int), null),
        //                        ReceiverID = (int?)DataTypeParser.Parse(usermsgrow["ReceiverID"], typeof(int), null),
        //                        Status = (int)PTIC.Common.Enum.UserMessageStatus.Confirmed
        //                    };
        //                    _userMessageList.Add(_userMessage);
        //                }
                        
        //            }

        //        }
             

        //        //UserMessage _userMessage = new UserMessage()
        //        //{
        //        //    ID = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colUserMessageID.Index].Value, typeof(int), -1),
        //        //    SenderID = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colSenderID.Index].Value, typeof(int), -1),
        //        //    ReceiverID = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colReceiverID.Index].Value,typeof(int),-1),
        //        //    MsgNoInt = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colMsgNo.Index].Value,typeof(int),-1),
        //        //    Status = (int)PTIC.Common.Enum.UserMessageStatus.Confirmed,
        //        //    MessageID = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colMessageID.Index].Value, typeof(int), -1),
        //        //    MessageThreadID = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colMessageThreadID.Index].Value, typeof(int), -1),
        //        //};
        //        if (_userMessageList.Count > 0)
        //        {
        //            affectedRows += new UserMessageBL().Update(_userMessageList);
        //        }
        //    }

        //    if (affectedRows > 0)
        //    {
        //        ToastMessageBox.Show(Resource.msgSuccessfullySaved);
        //        LoadNBind();
        //    }

        //}
        #endregion

        private void lblMarketing_Click(object sender, EventArgs e)
        {
            UIManager.MdiChildOpenForm(typeof(frmMsgInOutPage));
            this.Close();
        }

        private void dgvConfirmMessage_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null) return;

            // Set Row Number
            foreach (DataGridViewRow row in dgv.Rows)
            {
                dgv.Rows[row.Index].HeaderCell.Value = (row.Index + 1).ToString();

                int SenderRank =(int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colRank.Index].Value, typeof(int), -1);
                string SenderPostName = (string)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colPostName.Index].Value, typeof(string), string.Empty);
                string SenderDeptName = (string)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colDeptName.Index].Value, typeof(string), string.Empty);

                //int RecRank = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colRecRank.Index].Value, typeof(int), -1);
                //string RecPostName = (string)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colRecPostName.Index].Value, typeof(string), string.Empty);
               // string RecDeptName = (string)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colRecDeptName.Index].Value, typeof(string), string.Empty);

                if (SenderRank == 7)
                {
                    dgv.Rows[row.Index].Cells[colFromDept.Index].Value = SenderPostName;
                }
                else
                {
                    dgv.Rows[row.Index].Cells[colFromDept.Index].Value = SenderDeptName;
                }

                int MessageThreadID = (int)DataTypeParser.Parse(dgv.Rows[row.Index].Cells[colMessageThreadID.Index].Value, typeof(int), -1);
                DataTable tmpUserMessage = new UserMessageBL().SelectAllForConcact(MessageThreadID);
                if(tmpUserMessage == null)return;
                if(tmpUserMessage.Rows.Count >0)
                {
                    int RecRank = -1;
                    string RecPostName = string.Empty;
                    string RecDeptName = string.Empty;
                    foreach(DataRow tmprow in tmpUserMessage.Rows)
                    {
                        RecRank = (int)DataTypeParser.Parse(tmprow["ReceiverPostRank"],typeof(int),-1);
                        RecPostName = (string)DataTypeParser.Parse(tmprow["ReceiverPostName"], typeof(string), string.Empty);                                 
                        RecDeptName += string.IsNullOrEmpty(tmprow["ReceiverDeptName"].ToString()) ? string.Empty : tmprow["ReceiverDeptName"].ToString() + ", ";
                                          
                    }
                    int i = RecDeptName.LastIndexOf(',');
                    RecDeptName = RecDeptName.Remove(i);
                    dgv.Rows[row.Index].Cells[colToDept.Index].Value = RecDeptName;
                   
                }            

             
               DataTable dtsender = new UserMessageBL().SelectMsgNo(SenderDeptName);
              //  DataTable dtreceiver = new UserMessageBL().SelectMsgNo(RecDeptName);

               if (dtsender.Rows.Count > 0)
                {
                    int SenderMsgNoInt = (int)DataTypeParser.Parse(dtsender.Rows[0]["MsgNoInt"], typeof(int), 1);
                    dgv.Rows[row.Index].Cells[colMsgInNo.Index].Value = SenderDeptName + "-" + SenderMsgNoInt + " / " + (int)DataTypeParser.Parse(dtsender.Rows[0]["Year"], typeof(int), 0);
                    dgv.Rows[row.Index].Cells[colMsgNo.Index].Value = SenderMsgNoInt;
                }

            }

            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
           //Save();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvConfirmMessage.SelectedRows.Count > 0)
            {
                int MessageThreadID = (int)DataTypeParser.Parse(dgvConfirmMessage.CurrentRow.Cells[colMessageThreadID.Index].Value, typeof(int), -1);

                frmComposeMessage _frmComposeMessage = new frmComposeMessage(MessageThreadID);
                UIManager.OpenForm(_frmComposeMessage);
                LoadNBind();
            }
        }
    }
}

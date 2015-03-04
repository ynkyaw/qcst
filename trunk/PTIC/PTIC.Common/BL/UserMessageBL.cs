using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using PTIC.Common.Entities;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace PTIC.Common.BL
{
    public class UserMessageBL : BaseBusinessLogic
    {
        /// <summary>
        /// Field validation factory
        /// </summary>
        private ValidatorFactory _validatorFactory = EnterpriseLibraryContainer.Current.GetInstance<ValidatorFactory>();

        #region SELECT
        public DataTable SelectAllByMessageThreadID(int MessageThreadID)
        {
            return UserMessageDA.SelectAllByMessageThreadID(MessageThreadID);
        }

        public DataTable SelectAllForConcact(int UserMessageThreadID)
        {
            return UserMessageDA.SelectAllForConcact(UserMessageThreadID);
        }

        public DataTable SelectAllByUserMessageThreadID(int UserMessageThreadID)
        {
            return UserMessageDA.SelectAllByUserMessageThreadID(UserMessageThreadID);
        }

        public DataTable SelectMsgNo(string DeptName)
        {
            return UserMessageDA.SelectMaxMsgNo(DeptName);
        }

        public DataTable SelectMessageToConfirm(int UserID)
        {
            return UserMessageDA.SelectMessageToConfirm(UserID);
        }

        public DataTable GetMsgInOrOutBy(
            int departmentID, bool messageIn, DateTime startDate, DateTime endDate)
        {
            return UserMessageDA.SelectMsgInOrOutBy(departmentID, messageIn, startDate, endDate);
        }

        public DataTable GetBy(
            DateTime startDate, DateTime endDate, int? fromDepartmentID, int? toDepartmentID)
        {
            return UserMessageDA.SelectBy(startDate, endDate, fromDepartmentID, toDepartmentID);
        }

        public DataTable GetReceiversByMessageThreadID(int messageThreadID)
        {
            return UserMessageDA.SelectUsersByMessageThreadID(messageThreadID, Enum.MessageBox.Inbox);
        }
        #endregion

        #region INSERT
        public int? Add(
            PTIC.Common.Entities.Message newMessage,
            MessageThread newMessageThread, // TODO: remove MessageThread to be passed by caller
            List<UserMessage> newReceiverMessage, 
            UserMessage newSenderUserMessage
            )
        {
            if (newMessage == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.Message_Subject_Require,
                        null, "newMessage", null, null));
                return null;
            }
            else if (newReceiverMessage == null || newReceiverMessage.Count < 1)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.UserMessage_Receiver_Require,
                        null, "newReceiverMessage", null, null));
                return null;
            }
            else if (newSenderUserMessage == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.UserMessage_Sender_Require,
                        null, "newSenderUserMessage", null, null));
                return null;
            }

            try
            {
                // Message
                Validator<Message> messageValidator = _validatorFactory.CreateValidator<Message>();
                ValidationResults vMessageResults = messageValidator.Validate(newMessage);
                base.ValidationResults = vMessageResults;
                if (!vMessageResults.IsValid)
                    return null;

                // User Message for sender
                Validator<UserMessage> userMessageValidator = _validatorFactory.CreateValidator<UserMessage>();
                ValidationResults vUserMessageResults = userMessageValidator.Validate(newSenderUserMessage);
                base.ValidationResults = vUserMessageResults;
                if (!vUserMessageResults.IsValid)
                    return null;

                // User Message for receiver
                foreach (UserMessage receiverMsg in newReceiverMessage)
                {
                    ValidationResults vResults = userMessageValidator.Validate(receiverMsg);
                    base.ValidationResults = vResults;
                    if (!vResults.IsValid)
                        return null;
                }

                //  Save UserMessage
                return UserMessageDA.Insert(newMessage, newMessageThread, newReceiverMessage, newSenderUserMessage);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "UserMessageBL", null, null));
                return null;
            }            
        }

        public int? AddConfirmMsg(
            PTIC.Common.Entities.Message newMessage, 
            MessageThread newMessageThread, 
            List<UserMessage> newReceiverUserMessage, 
            UserMessage newSenderUserMessage
            )
        {

            if (newMessage == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.Message_Subject_Require,
                        null, "newMessage", null, null));
                return null;
            }
            else if (newReceiverUserMessage == null || newReceiverUserMessage.Count < 1)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.UserMessage_Receiver_Require,
                        null, "newReceiverUserMessage", null, null));
                return null;
            }
            else if (newSenderUserMessage == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.UserMessage_Sender_Require,
                        null, "newSenderUserMessage", null, null));
                return null;
            }

            try
            {
                // Message
                Validator<Message> MessageValidator = _validatorFactory.CreateValidator<Message>();
                ValidationResults vMessageResults = MessageValidator.Validate(newMessage);
                base.ValidationResults = vMessageResults;
                if (!vMessageResults.IsValid)
                    return null;

                // User Message sender
                Validator<UserMessage> userMessageValidator = _validatorFactory.CreateValidator<UserMessage>();
                ValidationResults vUserMessageResults = userMessageValidator.Validate(newSenderUserMessage);
                base.ValidationResults = vUserMessageResults;
                if (!vUserMessageResults.IsValid)
                    return null;

                // User Message for receiver
                foreach (UserMessage receiverMsg in newReceiverUserMessage)
                {
                    ValidationResults vResults = userMessageValidator.Validate(receiverMsg);
                    base.ValidationResults = vResults;
                    if (!vResults.IsValid)
                        return null;
                }

                //  Save UserMessage
                return UserMessageDA.InsertConfirmMsg
                    (
                        newMessage, 
                        newMessageThread, 
                        newReceiverUserMessage, 
                        newSenderUserMessage
                    );
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "UserMessageBL", null, null));
                return null;
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newMessage"></param>
        /// <param name="newMessageThread"></param>
        /// <param name="newSenderReceiverUserMessage"></param>        
        /// <returns></returns>
        public int? AddExternalConfirmMsg(
            PTIC.Common.Entities.Message newMessage,
            MessageThread newMessageThread,
            List<UserMessage> newSenderReceiverUserMessage)
        {

            if (newMessage == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.Message_Subject_Require,
                        null, "newMessage", null, null));
                return null;
            }
            else if (newSenderReceiverUserMessage == null || newSenderReceiverUserMessage.Count < 1)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.UserMessage_Receiver_Require,
                        null, "newReceiverUserMessage", null, null));
                return null;
            }
                        
            try
            {
                // User Message for receiver
                Validator<UserMessage> userMessageValidator = _validatorFactory.CreateValidator<UserMessage>();
                foreach (UserMessage receiverMsg in newSenderReceiverUserMessage)
                {
                    ValidationResults vResults = userMessageValidator.Validate(receiverMsg);
                    base.ValidationResults = vResults;
                    if (!vResults.IsValid)
                        return null;
                }

                // Message
                Validator<Message> MessageValidator = _validatorFactory.CreateValidator<Message>();
                ValidationResults vMessageResults = MessageValidator.Validate(newMessage);
                base.ValidationResults = vMessageResults;
                if (!vMessageResults.IsValid)
                    return null;
                
                //  Save UserMessage
                return UserMessageDA.InsertConfirmMsg
                    (
                        newMessage,
                        newMessageThread,
                        newSenderReceiverUserMessage,
                        null
                    );
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "UserMessageBL", null, null));
                return null;
            }
        }



        /// <summary>
        /// Forward message from a sender to a receiver
        /// </summary>
        /// <param name="newMessage"></param>
        /// <param name="newSenderUserMessage"></param>
        /// <param name="newReceiverUserMessages"></param>
        /// <returns></returns>
        public int? Forward(
            Message newMessage,
            UserMessage newSenderUserMessage,
            List<UserMessage> newReceiverUserMessages)
        {
            if (newMessage == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.Message_Remark_Require,
                        null, "newMessage", null, null));
                return null;
            }
            else if (newSenderUserMessage == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.UserMessage_Sender_Require,
                        null, "newSenderUserMessage", null, null));
                return null;
            }
            else if (newReceiverUserMessages == null || newReceiverUserMessages.Count < 1)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.UserMessage_Receiver_Require,
                        null, "newReceiverUserMessage", null, null));
                return null;
            }

            try
            {
                // Message
                if (string.IsNullOrEmpty(newMessage.Remark) || newMessage.Remark.Length < 1)
                {
                    base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.Message_Remark_Require,
                        null, "newMessage", null, null));
                    return null;
                }

                // Sender user messages
                newSenderUserMessage.MessageBox = (int)PTIC.Common.Enum.MessageBox.Sentbox;
                newSenderUserMessage.IsRead = true;
                newSenderUserMessage.Status = (int)PTIC.Common.Enum.UserMessageStatus.Confirmed;
                newSenderUserMessage.SenderAction = (int)PTIC.Common.Enum.MessageSenderAction.Forward;

                // Receiver user messages
                foreach (UserMessage newReceiverUserMessage in newReceiverUserMessages)
                {
                    newReceiverUserMessage.MessageThreadID = newSenderUserMessage.MessageThreadID;
                    newReceiverUserMessage.MessageBox = (int)PTIC.Common.Enum.MessageBox.Inbox;
                    newReceiverUserMessage.IsRead = false;
                    newReceiverUserMessage.Status = (int)PTIC.Common.Enum.UserMessageStatus.Confirmed;
                    newReceiverUserMessage.SenderAction = (int)PTIC.Common.Enum.MessageSenderAction.Forward;
                }
                // Save
                return UserMessageDA.Insert(
                    newMessage,
                    newSenderUserMessage,
                    newReceiverUserMessages,
                    true);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "UserMessageBL", null, null));
                return null;
            }            
        }

        public int? Reply(
            Message newMessage,
            UserMessage newSenderUserMessage,
            UserMessage newReceiverUserMessage)
        {
            if (newMessage == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.Message_Remark_Require,
                        null, "newMessage", null, null));
                return null;
            }
            else if (newSenderUserMessage == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.UserMessage_Sender_Require,
                        null, "newSenderUserMessage", null, null));
                return null;
            }
            else if (newReceiverUserMessage == null)
            {
                base.ValidationResults = new ValidationResults();
                base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.UserMessage_Receiver_Require,
                        null, "newReceiverUserMessage", null, null));
                return null;
            }

            try 
            {
                // Message
                if (string.IsNullOrEmpty(newMessage.Remark) || newMessage.Remark.Length < 1)
                {
                    base.ValidationResults.AddResult(
                    new ValidationResult(ErrorMessages.Message_Remark_Require,
                        null, "newMessage", null, null));
                    return null;
                }

                // Sender user messages
                newSenderUserMessage.MessageBox = (int)PTIC.Common.Enum.MessageBox.Sentbox;
                newSenderUserMessage.IsRead = true;
                newSenderUserMessage.Status = (int)PTIC.Common.Enum.UserMessageStatus.Confirmed;
                newSenderUserMessage.SenderAction = (int)PTIC.Common.Enum.MessageSenderAction.Reply;

                // Receiver user messages
                newReceiverUserMessage.MessageThreadID = newSenderUserMessage.MessageThreadID;
                newReceiverUserMessage.MessageBox = (int)PTIC.Common.Enum.MessageBox.Inbox;
                newReceiverUserMessage.IsRead = false;
                newReceiverUserMessage.Status = (int)PTIC.Common.Enum.UserMessageStatus.Confirmed;
                newReceiverUserMessage.SenderAction = (int)PTIC.Common.Enum.MessageSenderAction.Reply;
                
                // Save
                return UserMessageDA.Insert(
                    newMessage,
                    newSenderUserMessage,
                    new List<UserMessage>() 
                    {
                        newReceiverUserMessage
                    },
                    false);
            }
            catch (Exception e)
            {
                base.ValidationResults.AddResult(
                    new ValidationResult(e.Message,
                        null, "UserMessageBL", null, null));
                return null;
            }
        }
        #endregion

        #region UPDATE
        public int Update(List<UserMessage> newUserMessage)
        {
            return UserMessageDA.Update(newUserMessage);
        }
        #endregion
    }
}

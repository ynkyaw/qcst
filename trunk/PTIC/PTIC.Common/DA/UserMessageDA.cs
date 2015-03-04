using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.Entities;
using System.Data.SqlClient;
using System.Data;

namespace PTIC.Common.DA
{
    public class UserMessageDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECT
        public static DataTable SelectAllByMessageThreadID(int MessageThreadID)
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM uv_UserMessage "
                                    + "WHERE Status =0 AND MessageThreadID ='{0}' AND MessageBox ='1' AND SenderAction = '0'";
                dt = b.SelectByQuery(String.Format(query, MessageThreadID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectAllForConcact(int UserMessageThreadID)
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM uv_UserMessage "
                                    + "WHERE Status =0 AND MessageThreadID ='{0}' AND MessageBox ='1' AND SenderAction = '0'";
                dt = b.SelectByQuery(String.Format(query, UserMessageThreadID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectAllByUserMessageThreadID(int UserMessageThreadID)
        {
            DataTable dt;
            try
            {
                dt = b.SelectByQuery(String.Format("SELECT * FROM UserMessage WHERE MessageThreadID ='{0}'", UserMessageThreadID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectMaxMsgNo(string DeptName)
        {
            DataTable dt;
            try
            {
                string query = "SELECT MAX(MsgNoInt+1) As MsgNoInt,YEAR(GETDATE()) As Year FROM UserMessage WHERE MsgNoPrefix = '{0}' AND YEAR(DateAdded)= YEAR((SELECT GETDATE()))";
                dt = b.SelectByQuery(String.Format(query, DeptName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectMessageToConfirm(int UserID)
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM uv_UserMessage "
                    + "WHERE Status =0 AND SenderID ='{0}' AND MessageBox ='2' AND SenderAction = '0'";

                dt = b.SelectByQuery(String.Format(query, UserID));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable SelectMsgInOrOutBy(
            int departmentID, bool messageIn, DateTime startDate, DateTime endDate)
        {
            DataTable table = null;
            string tableName = "UserMessageTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_UserMessageInOrOutSelectBy";

                command.Parameters.AddWithValue("@p_departmentID", departmentID);
                command.Parameters["@p_departmentID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_isIn", messageIn);
                command.Parameters["@p_isIn"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_startDate", startDate);
                command.Parameters["@p_startDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_endDate", endDate);
                command.Parameters["@p_endDate"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable SelectBy(
            DateTime startDate, DateTime endDate, int? fromDepartmentID, int? toDepartmentID)
        {
            DataTable table = null;
            string tableName = "UserMessageTable";
            try
            {
                table = new DataTable(tableName);
                SqlCommand command = new SqlCommand();
                command.Connection = DBManager.GetInstance().GetDbConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "usp_UserMessageSelectBy";

                command.Parameters.AddWithValue("@p_startDate", startDate);
                command.Parameters["@p_startDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_endDate", endDate);
                command.Parameters["@p_endDate"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_fromDepartmentID", fromDepartmentID);
                command.Parameters["@p_fromDepartmentID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@p_toDepartmentID", toDepartmentID);
                command.Parameters["@p_toDepartmentID"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }

        public static DataTable SelectUsersByMessageThreadID(int messageThreadID, PTIC.Common.Enum.MessageBox msgBox)
        {
            DataTable table = null;
            string tableName = "UserInMsgThread";
            SqlConnection conn = null;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                table = new DataTable(tableName);

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;

                command.CommandText = "SELECT ReceiverID, EmpName FROM UserMessage"
                                                        + " INNER JOIN Employee ON Employee.ID = ReceiverID"
                                                        + " WHERE MessageThreadID = @MessageThreadID AND MessageBox = @MessageBox ";

                command.Parameters.AddWithValue("@MessageThreadID", messageThreadID);
                command.Parameters["@MessageThreadID"].Direction = ParameterDirection.Input;

                command.Parameters.AddWithValue("@MessageBox", (int)msgBox);
                command.Parameters["@MessageBox"].Direction = ParameterDirection.Input;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (SqlException sqle)
            {
                return null;
            }
            return table;
        }
        #endregion

        #region INSERT
        public static int Insert(PTIC.Common.Entities.Message newMessage, MessageThread newMessageThread, List<UserMessage> newUserMessage, UserMessage newSenderUserMessage)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            SqlConnection conn = null;
            int? insertedMessageID = null;
            int? insertedMessageThreadID = null;
            // int? insertedMsgSenderReceiverID = null;
            int affectedRow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new Message
                cmd.CommandText = "usp_MessageInsert";

                cmd.Parameters.AddWithValue("@p_Subject", newMessage.Subject);
                cmd.Parameters["@p_Subject"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Body", newMessage.Body);
                cmd.Parameters["@p_Body"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", newMessage.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedMessageID = (int)insertedIDObj;
                // clear parameters of usp_MessageInsert
                cmd.Parameters.Clear();

                // insert a new MessageThread
                cmd.CommandText = "usp_MessageThreadInsert";

                cmd.Parameters.AddWithValue("@p_Date", newMessageThread.Date);
                cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                object insertedThreadIDObj = cmd.ExecuteScalar();
                if (insertedThreadIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedMessageThreadID = (int)insertedThreadIDObj;
                // clear parameters of usp_MessageThreadInsert
                cmd.Parameters.Clear();

                // insert new usp_UserMessageInsert
                cmd.CommandText = "usp_UserMessageInsert";

                cmd.Parameters.AddWithValue("@p_MessageID", insertedMessageID);
                cmd.Parameters["@p_MessageID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MessageThreadID", insertedMessageThreadID);
                cmd.Parameters["@p_MessageThreadID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SenderID", newSenderUserMessage.SenderID);
                cmd.Parameters["@p_SenderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReceiverID", newSenderUserMessage.ReceiverID);
                cmd.Parameters["@p_ReceiverID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Sender", newSenderUserMessage.Sender);
                cmd.Parameters["@p_Sender"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Receiver", newSenderUserMessage.Receiver);
                cmd.Parameters["@p_Receiver"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MessageBox", (int)PTIC.Common.Enum.MessageBox.Sentbox);
                cmd.Parameters["@p_MessageBox"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsRead", 1);
                cmd.Parameters["@p_IsRead"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", newSenderUserMessage.Status);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SenderAction", (int)PTIC.Common.Enum.MessageSenderAction.Send);
                cmd.Parameters["@p_SenderAction"].Direction = ParameterDirection.Input;

                affectedRow += cmd.ExecuteNonQuery();
                // clear parameters of each usp_UserMessageInsert
                cmd.Parameters.Clear();

                // insert new usp_UserMessageInsert
                cmd.CommandText = "usp_UserMessageInsert";
                foreach (UserMessage userMessage in newUserMessage)
                {
                    cmd.Parameters.AddWithValue("@p_MessageID", insertedMessageID);
                    cmd.Parameters["@p_MessageID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_MessageThreadID", insertedMessageThreadID);
                    cmd.Parameters["@p_MessageThreadID"].Direction = ParameterDirection.Input;


                    cmd.Parameters.AddWithValue("@p_SenderID", userMessage.SenderID);
                    cmd.Parameters["@p_SenderID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ReceiverID", userMessage.ReceiverID);
                    cmd.Parameters["@p_ReceiverID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Sender", userMessage.Sender);
                    cmd.Parameters["@p_Sender"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Receiver", userMessage.Receiver);
                    cmd.Parameters["@p_Receiver"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_MessageBox", (int)PTIC.Common.Enum.MessageBox.Inbox);
                    cmd.Parameters["@p_MessageBox"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IsRead", 0);
                    cmd.Parameters["@p_IsRead"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Status", userMessage.Status);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SenderAction", (int)PTIC.Common.Enum.MessageSenderAction.Send);
                    cmd.Parameters["@p_SenderAction"].Direction = ParameterDirection.Input;

                    affectedRow += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_MsgSenderReceiverInsert
                    cmd.Parameters.Clear();
                }

                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedRow;
        }

        public static int InsertConfirmMsg(
            PTIC.Common.Entities.Message newMessage,
            MessageThread newMessageThread,
            List<UserMessage> newUserMessage,
            UserMessage newSenderUserMessage)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            SqlConnection conn = null;
            int? insertedMessageID = null;
            int? insertedMessageThreadID = null;
            // int? insertedMsgSenderReceiverID = null;
            int affectedRow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new Message
                cmd.CommandText = "usp_MessageInsert";

                cmd.Parameters.AddWithValue("@p_Subject", newMessage.Subject);
                cmd.Parameters["@p_Subject"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Body", newMessage.Body);
                cmd.Parameters["@p_Body"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", newMessage.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedMessageID = (int)insertedIDObj;
                // clear parameters of usp_MessageInsert
                cmd.Parameters.Clear();

                // insert a new MessageThread
                cmd.CommandText = "usp_MessageThreadInsert";

                cmd.Parameters.AddWithValue("@p_Date", newMessageThread.Date);
                cmd.Parameters["@p_Date"].Direction = ParameterDirection.Input;

                object insertedThreadIDObj = cmd.ExecuteScalar();
                if (insertedThreadIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedMessageThreadID = (int)insertedThreadIDObj;
                // clear parameters of usp_MessageThreadInsert
                cmd.Parameters.Clear();

                if (newSenderUserMessage != null)
                {
                    // insert new usp_UserMessageInsertConfirm
                    cmd.CommandText = "usp_UserMessageInsertConfirm";

                    cmd.Parameters.AddWithValue("@p_MessageID", insertedMessageID);
                    cmd.Parameters["@p_MessageID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_MessageThreadID", insertedMessageThreadID);
                    cmd.Parameters["@p_MessageThreadID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SenderID", newSenderUserMessage.SenderID);
                    cmd.Parameters["@p_SenderID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ReceiverID", newSenderUserMessage.ReceiverID);
                    cmd.Parameters["@p_ReceiverID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Sender", newSenderUserMessage.Sender);
                    cmd.Parameters["@p_Sender"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Receiver", newSenderUserMessage.Receiver);
                    cmd.Parameters["@p_Receiver"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_MessageBox", (int)PTIC.Common.Enum.MessageBox.Sentbox);
                    cmd.Parameters["@p_MessageBox"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IsRead", 1);
                    cmd.Parameters["@p_IsRead"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Status", newSenderUserMessage.Status);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SenderAction", (int)PTIC.Common.Enum.MessageSenderAction.Send);
                    cmd.Parameters["@p_SenderAction"].Direction = ParameterDirection.Input;

                    affectedRow += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_UserMessageInsert
                    cmd.Parameters.Clear();
                }

                // insert new usp_UserMessageInsertConfirm
                cmd.CommandText = "usp_UserMessageInsertConfirm";
                foreach (UserMessage userMessage in newUserMessage)
                {
                    cmd.Parameters.AddWithValue("@p_MessageID", insertedMessageID);
                    cmd.Parameters["@p_MessageID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_MessageThreadID", insertedMessageThreadID);
                    cmd.Parameters["@p_MessageThreadID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SenderID", userMessage.SenderID);
                    cmd.Parameters["@p_SenderID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ReceiverID", userMessage.ReceiverID);
                    cmd.Parameters["@p_ReceiverID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Sender", userMessage.Sender);
                    cmd.Parameters["@p_Sender"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Receiver", userMessage.Receiver);
                    cmd.Parameters["@p_Receiver"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_MessageBox", userMessage.MessageBox);
                    cmd.Parameters["@p_MessageBox"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_IsRead", 0);
                    cmd.Parameters["@p_IsRead"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Status", userMessage.Status);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SenderAction", (int)PTIC.Common.Enum.MessageSenderAction.Send);
                    cmd.Parameters["@p_SenderAction"].Direction = ParameterDirection.Input;

                    affectedRow += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_MsgSenderReceiverInsert
                    cmd.Parameters.Clear();
                }


                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedRow;
        }

         


        /// <summary>
        /// Insert new message, sender and receiver messages without message number for sender
        /// </summary>
        /// <param name="newMessage"></param>
        /// <param name="newSenderUserMessage"></param>
        /// <param name="newReceiverUserMessages"></param>
        /// <param name="needMessageNoForReceiver"></param>
        /// <returns></returns>
        public static int Insert(
            Message newMessage,
            UserMessage newSenderUserMessage,
            List<UserMessage> newReceiverUserMessages,
            bool needMessageNoForReceiver)
        {
            SqlTransaction transaction = null;
            SqlCommand cmd = null;
            SqlConnection conn = null;
            int? insertedMessageID = null;
            int affectedRow = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();
                transaction = conn.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                // insert a new Message
                cmd.CommandText = "usp_MessageInsert";

                cmd.Parameters.AddWithValue("@p_Subject", newMessage.Subject);
                cmd.Parameters["@p_Subject"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Body", newMessage.Body);
                cmd.Parameters["@p_Body"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Remark", newMessage.Remark);
                cmd.Parameters["@p_Remark"].Direction = ParameterDirection.Input;

                object insertedIDObj = cmd.ExecuteScalar();
                if (insertedIDObj.GetType() == typeof(DBNull))
                    return 0;

                insertedMessageID = (int)insertedIDObj;
                // clear parameters of usp_MessageInsert
                cmd.Parameters.Clear();

                // insert new usp_UserMessageInsert for sender without MsgNo ( message number )
                cmd.CommandText = "usp_UserMessageInsert";
                cmd.Parameters.AddWithValue("@p_MessageID", insertedMessageID);
                cmd.Parameters["@p_MessageID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MessageThreadID", newSenderUserMessage.MessageThreadID);
                cmd.Parameters["@p_MessageThreadID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SenderID", newSenderUserMessage.SenderID);
                cmd.Parameters["@p_SenderID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_ReceiverID", newSenderUserMessage.ReceiverID);
                cmd.Parameters["@p_ReceiverID"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Sender", newSenderUserMessage.Sender);
                cmd.Parameters["@p_Sender"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Receiver", newSenderUserMessage.Receiver);
                cmd.Parameters["@p_Receiver"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_MessageBox", newSenderUserMessage.MessageBox);
                cmd.Parameters["@p_MessageBox"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_IsRead", newSenderUserMessage.IsRead);
                cmd.Parameters["@p_IsRead"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_Status", newSenderUserMessage.Status);
                cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                cmd.Parameters.AddWithValue("@p_SenderAction", newSenderUserMessage.SenderAction);
                cmd.Parameters["@p_SenderAction"].Direction = ParameterDirection.Input;

                affectedRow += cmd.ExecuteNonQuery();
                // clear parameters of each usp_UserMessageInsert
                cmd.Parameters.Clear();

                // if message number are needed for receiver in case of Message Forward
                if (needMessageNoForReceiver)
                {
                    // Insert new user message for receiver                    
                    cmd.CommandText = "usp_UserMessageForwardInsert";
                }
                //else // add new user messages for receiver without message no in case of Message Reply
                //{                    
                //}

                foreach (UserMessage userMessage in newReceiverUserMessages)
                {
                    cmd.Parameters.AddWithValue("@p_MessageID", insertedMessageID);
                    cmd.Parameters["@p_MessageID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_MessageThreadID", userMessage.MessageThreadID);
                    cmd.Parameters["@p_MessageThreadID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SenderID", userMessage.SenderID);
                    cmd.Parameters["@p_SenderID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ReceiverID", userMessage.ReceiverID);
                    cmd.Parameters["@p_ReceiverID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Sender", userMessage.Sender);
                    cmd.Parameters["@p_Sender"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Receiver", userMessage.Receiver);
                    cmd.Parameters["@p_Receiver"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_MessageBox", (int)PTIC.Common.Enum.MessageBox.Inbox);
                    cmd.Parameters.AddWithValue("@p_MessageBox", userMessage.MessageBox);
                    cmd.Parameters["@p_MessageBox"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_IsRead", 0);
                    cmd.Parameters.AddWithValue("@p_IsRead", userMessage.IsRead);
                    cmd.Parameters["@p_IsRead"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Status", userMessage.Status);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    //cmd.Parameters.AddWithValue("@p_SenderAction", (int)PTIC.Common.Enum.MessageSenderAction.Send);
                    cmd.Parameters.AddWithValue("@p_SenderAction", userMessage.SenderAction);
                    cmd.Parameters["@p_SenderAction"].Direction = ParameterDirection.Input;

                    affectedRow += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_UserMessageInsert
                    cmd.Parameters.Clear();
                }

                // commit transaction
                transaction.Commit();
            }
            catch (SqlException sqle)
            {
                if (conn.State == ConnectionState.Open)
                {
                    transaction.Rollback();
                    return 0;
                }
            }
            finally
            {
                transaction.Dispose();
                cmd.Dispose();
            }
            return affectedRow;
        }

        #endregion

        #region UPDATE
        public static int Update(List<UserMessage> newUserMessage)
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            int affectedRows = 0;
            try
            {
                conn = DBManager.GetInstance().GetDbConnection();

                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                // insert new usp_UserMessageInsert
                cmd.CommandText = "usp_UserMessageUpdate";
                foreach (UserMessage userMessage in newUserMessage)
                {
                    cmd.Parameters.AddWithValue("@p_UserMessageID", userMessage.ID);
                    cmd.Parameters["@p_UserMessageID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_SenderID", userMessage.SenderID);
                    cmd.Parameters["@p_SenderID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_ReceiverID", userMessage.ReceiverID);
                    cmd.Parameters["@p_ReceiverID"].Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@p_Status", userMessage.Status);
                    cmd.Parameters["@p_Status"].Direction = ParameterDirection.Input;

                    affectedRows += cmd.ExecuteNonQuery();
                    // clear parameters of each usp_UserMessageInsert
                    cmd.Parameters.Clear();

                }

            }
            catch (SqlException Sqle)
            {
                return 0;
            }
            return affectedRows;
        }
        #endregion
    }
}

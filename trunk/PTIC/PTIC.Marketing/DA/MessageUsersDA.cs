using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.DA
{
    public class MessageUsersDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECT
        public static DataTable SelectAllMsgUsers()
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM [dbo].[MessageUsers] "
                            + "INNER JOIN Employee ON Employee.ID = MessageUsers.EmployeeID "
                            + "INNER JOIN Department ON Department.ID = Employee.DeptID "
                             + "INNER JOIN Job_Position ON Job_Position.ID = Employee.PostID WHERE [IsActive] = 1";
                             

                dt = b.SelectByQuery(string.Format(query));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable SelectAll()
        {
            DataTable dt;
            try
            {
                string query = "SELECT * FROM MessageUsers "
                                        +"INNER JOIN Employee ON Employee.ID = MessageUsers.EmployeeID ORDER BY EmpName";
                dt = b.SelectByQuery(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public bool isExist(string key)
        {
            return b.CheckRec("[MessageUsers]", key);
        }
        #endregion

        #region INSERT
        public int Insert(MessageUsers messageUsers)
        {
            int lastInsertId = 0;
            try
            {
                lastInsertId = b.InsertInto("[MessageUsers]", b.ConvertColName(messageUsers), b.ConvertValueList(messageUsers));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lastInsertId;
        }
        #endregion

        #region UPDATE
        public int Update(MessageUsers messageUsers)
        {
            int GroupID = 0;
            try
            {
                b.Update("[MessageUsers]", messageUsers.ID.ToString(), b.ConvertColName(messageUsers), b.ConvertValueList(messageUsers));
                GroupID = messageUsers.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return GroupID;
        }
        #endregion

        #region DELETE
        public int Delete(MessageUsers messageUsers)
        {
            int MessageUsersID = 0;
            try
            {
                b.Delete("[MessageUsers]", messageUsers.ID);
                MessageUsersID = messageUsers.ID;
            }
            catch (Exception ex)
            {
                return MessageUsersID = 0;
            }
            return MessageUsersID;
        }
        #endregion
    }
}

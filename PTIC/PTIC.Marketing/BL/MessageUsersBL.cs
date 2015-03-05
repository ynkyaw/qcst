using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using PTIC.Common.Entities;
using PTIC.Marketing.Entities;
using PTIC.Marketing.DA;
using System.Data;

namespace PTIC.Marketing.BL
{
    public class MessageUsersBL
    {
        BaseDAO b = new BaseDAO();
        MessageUsersDA userMessageDA = new MessageUsersDA();

        #region SELECT
        public DataTable GetAllMsgUsers()
        {
            return MessageUsersDA.SelectAllMsgUsers();
        }
        #endregion


        public int Create(MessageUsers messageUsers)
        {
            int id;
            if (!userMessageDA.isExist(messageUsers.ID.ToString()))
            {
                id = userMessageDA.Insert(messageUsers);
            }
            else
            {
                id = userMessageDA.Update(messageUsers);
            }
            return id;
        }

        public int Delete(MessageUsers messageUsers)
        {
            return userMessageDA.Delete(messageUsers);
        }
    }
}

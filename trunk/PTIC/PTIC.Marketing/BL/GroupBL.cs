using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;

namespace PTIC.Marketing.BL
{
    public class GroupBL
    {
        BaseDAO b = new BaseDAO();
        GroupDA groupDA = new GroupDA();

        public int Create(Group group)
        {
            int id;
            if (!groupDA.isExist(group.ID.ToString()))
            {
                id = groupDA.Insert(group);
            }
            else
            {
                id = groupDA.Update(group);
            }
            return id;
        }

        public int Delete(Group group)
        {
            return groupDA.Delete(group);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;

namespace PTIC.Common
{
    public class APCategoryBUS
    {
        BaseDAO b = new BaseDAO();
        APCategoryDAO dao = new APCategoryDAO();
        public int Create(APCategoryVO vo)
        {
            int id;
            if (!dao.isExist(vo.Id.ToString()))
            {
                id = dao.Insert(vo);
            }
            else
            {
                id = dao.Update(vo);
            }
            return id;
        }

        public int Delete(APCategoryVO vo)
        {
            return dao.Delete(vo);
        }

    }
}

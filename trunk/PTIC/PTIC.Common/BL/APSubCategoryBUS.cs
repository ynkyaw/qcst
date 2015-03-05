using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;

namespace PTIC.Common
{
    public class APSubCategoryBUS
    {
        BaseDAO b = new BaseDAO();
        APSubCategoryDAO dao = new APSubCategoryDAO();
        public int Create(APSubCategoryVO vo)
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

        public int Delete(APSubCategoryVO vo)
        {
            return dao.Delete(vo);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;

namespace PTIC.Common
{
    public class APMaterialBUS
    {
        BaseDAO b = new BaseDAO();
        APMaterialDAO dao = new APMaterialDAO();

        public int Create(APMaterialVO vo)
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

        public int Delete(APMaterialVO vo)
        {
            return dao.Delete(vo);
        }

        public DataTable GetAll()
        {
            return b.SelectByQuery("SELECT * FROM AP_Material WHERE IsDeleted = 0 ");
        }
    }
}

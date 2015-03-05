using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using PTIC.Common.DA;

namespace PTIC.Marketing.BL
{
    public class CustomersInGroupBL
    {
        static BaseDAO b = new BaseDAO();
        CustomersInGroupDA customersInGroupDA = new CustomersInGroupDA();

        #region SELECT
        public DataTable GetAll()
        {
            return CustomersInGroupDA.SelectAll();
        }

        public int Add(Group group, List<CustomersInGroup> customersInGroup)
        {
            return CustomersInGroupDA.Insert(group, customersInGroup);
        }
        #endregion

        #region DELETE
        public int Delete(CustomersInGroup vo)
        {
            return customersInGroupDA.Delete(vo);
        }
        #endregion
    }
}

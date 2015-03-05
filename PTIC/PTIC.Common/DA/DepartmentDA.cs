using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PTIC.Common.DA
{
    public class DepartmentDA
    {
        private static BaseDAO _dataAccess = new BaseDAO();

        #region SELECT
        public static DataTable SelectAll()
        {
            string queryString = "SELECT * FROM Department";
            return _dataAccess.SelectByQuery(queryString);
        }
        #endregion
    }
}

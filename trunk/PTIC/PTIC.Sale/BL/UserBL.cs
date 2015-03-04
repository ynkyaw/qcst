using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.DA;

namespace PTIC.Sale.BL
{
    public class UserBL
    {
        #region SELECT
        public DataTable GetAll(SqlConnection conn)
        {
            return UserDA.GetAll(conn);
        }
        #endregion
    }
}

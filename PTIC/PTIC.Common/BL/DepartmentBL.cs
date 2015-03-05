using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Common.DA;

namespace PTIC.Common.BL
{
    public class DepartmentBL
    {
        #region SELECT
        public DataTable GetAll()
        {
            return DepartmentDA.SelectAll();
        }
        #endregion
    }
}

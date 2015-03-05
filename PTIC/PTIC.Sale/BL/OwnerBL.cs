using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.DA;

namespace PTIC.Sale.BL
{
    public class OwnerBL
    {
        #region SELECT
        /// <summary>
        /// Get all Owner from system
        /// </summary>        
        /// <returns>Return datatable containing all customers</returns>
        public DataTable GetAll(int CusID)
        {
            return OwnerDA.SelectAll(CusID);
        }
        #endregion
    }
}

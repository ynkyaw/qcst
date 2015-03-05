using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.DA;

namespace PTIC.Sale.BL
{
    public class FormulaBL
    {
        #region SELECT
        /// <summary>
        /// Get all Formula from system
        /// </summary>
        /// <param name="conn">Database connection</param>
        /// <returns>Return datatable containing all orders</returns>
        public DataTable GetAll(SqlConnection conn)
        {
            return FormulaDA.SelectAll(conn);
        }
        #endregion
    }
}

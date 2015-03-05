/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   CustomerClassBL ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using PTIC.Sale.DA;
using System.Data.SqlClient;
using System.Data;

namespace PTIC.Sale.BL
{
    public class CustomerClassBL
    {
        #region SELECTALL
        public DataTable GetAll()
        {
            return CustomerClassDA.SelectAll();
        }
        #endregion

        #region SELECTWithTownship
        public DataTable GetWithTownship(SqlConnection conn)
        {
            return CustomerClassDA.SelectWithTownship(conn);
        }
        #endregion

        #region INSERT
        public int Insert(CustomerClass customerclass, SqlConnection conn)
        {
            return CustomerClassDA.Insert(customerclass, conn);
        }
        #endregion

        #region UPDATE
        public int Update(CustomerClass customerclass, SqlConnection conn)
        {
            return CustomerClassDA.UpdateByID(customerclass, conn);
        }
        #endregion

        #region DELETE
        public int Delete(CustomerClass customerclass, SqlConnection conn)
        {
            return CustomerClassDA.DeleteByID(customerclass, conn);
        }
        #endregion
    }
}

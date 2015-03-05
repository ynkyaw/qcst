/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   TransportTypeBL ( Insert , Update , Delete , Select}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PTIC.Sale.DA;

namespace PTIC.Sale.BL
{
    public class TransportTypeBL
    {
        #region SELECTALL
        public DataTable GetAll()
        {
            return TransportTypeDA.SelectAll();
        }
        #endregion
    }
}

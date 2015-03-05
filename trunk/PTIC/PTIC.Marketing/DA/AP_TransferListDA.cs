using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Common.DA;
using System.Data;

namespace PTIC.Marketing.DA
{
    public class AP_TransferListDA
    {
        static BaseDAO b = new BaseDAO();

        #region SELECT
        public static DataTable SelectAll()
        {
            DataTable dtPosmTransferList = null;
            try
            {
                dtPosmTransferList = b.SelectByQuery("SELECT * FROM uv_AP_TransferList");
            }
            catch (Exception ex)
            {                
                throw ex; 
            }
            return dtPosmTransferList;
        }
        #endregion
    }
}

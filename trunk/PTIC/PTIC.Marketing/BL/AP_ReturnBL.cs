/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/13 (yyyy/MM/dd)
 * Description: 
 */

using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Marketing.DA;
using System.Collections.Generic;
namespace PTIC.Marketing.BL
{
    public class AP_ReturnBL
    {
        #region SELECT
        #endregion

        #region INSERT
        public int? Add(AP_Return newAP_Return, List<AP_ReturnDetail> newAP_ReturnDetails, SqlConnection conn)
        {
            return AP_ReturnDA.Insert(newAP_Return, newAP_ReturnDetails, conn);
        }
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion
    }
}

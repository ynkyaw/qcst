/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/07/13 (yyyy/MM/dd)
 * Description: 
 */

using PTIC.Marketing.Entities;
using System.Data.SqlClient;
using PTIC.Marketing.DA;
using System.Collections.Generic;
using System.Data;
namespace PTIC.Marketing.BL
{
    public class AP_ReturnBL
    {
        #region SELECT
        public DataTable GetAP_StockInDepartmentByAPID(int AP_MaterialID,int DeptID)
        {
            return AP_ReturnDA.SelectAPStockInDepartmentBYAPID(AP_MaterialID,DeptID);
        }

        public DataTable GetAP_StockInVehicleByAPID(int AP_MaterialID, int VenID)
        {
            return AP_ReturnDA.SelectAP_StockInVehicleByAPID(AP_MaterialID, VenID);
        }
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

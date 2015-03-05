/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: 2014/02/23 (yyyy/mm/dd)
 * Description: Vehicle business logic class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Sale.DA;
using System.Data.SqlClient;
using PTIC.Common.TableType;

namespace PTIC.Sale.BL
{
    /// <summary>
    /// Vehicle business logic
    /// </summary>
    public class VehicleBL
    {
        #region SELECT
        public DataTable GetAll()
        {
            return VehicleDA.SelectAll();
        }

        public DataTable GetVenReturn()
        {
            return VehicleDA.SelectVenReturn();
        }

        public DataTable GetVenReturnByDate(DateTime Date)
        {
            return VehicleDA.SelectVenReturnByDate(Date);
        }
        #endregion

        #region INSERT
        public int VenReturn(List<StockTableType> newStocks, int vehicleID, SqlConnection conn)
        {
            return VehicleDA.InsertVenReturn(newStocks, vehicleID, conn);
        }
        #endregion
    }
}

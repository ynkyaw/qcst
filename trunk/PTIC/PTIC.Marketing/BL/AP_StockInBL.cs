using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Marketing.DA;
using PTIC.Marketing.Entities;
using System.Data.SqlClient;

namespace PTIC.Marketing.BL
{
    public class AP_StockInBL
    {
        #region Select "AP_StockIn By Date"
        public DataTable GetAP_StockInByDate(DateTime StockInDate)
        {
            return AP_StockInDA.SelectAP_StockInByDate(StockInDate);
        }
        #endregion

        #region Select "AP_StockInDetail By AP_StockInID"
        public DataTable GetAP_StockInDetailByAP_StockInID(int AP_StockInID)
        {
            return AP_StockInDA.SelectAP_StockInDetailByAP_StockInID(AP_StockInID);
        }
        #endregion

        #region Insert "AP_StockIn and AP_StockInDetail"
        public int Add(AP_StockIn newAPStockIn, List<AP_StockInDetail> newAPStockInDetail, SqlConnection conn)
        {
            return AP_StockInDA.Insert(newAPStockIn, newAPStockInDetail, conn);
        }
        #endregion

        #region Delete
        public int DeleteByAPStockInDetailID(int APStockInDetailID, SqlConnection conn)
        {
            return AP_StockInDA.DeleteByapPosmPurchasedDetailID(APStockInDetailID, conn);
        }
        #endregion

        #region UPDATE
        public int Update(AP_StockIn _APStockIn, List<AP_StockInDetail> _APStockInDetail, SqlConnection conn)
        {
            return AP_StockInDA.Update(_APStockIn, _APStockInDetail, conn);
        }

        public int UpdateByStockInID(AP_StockIn _APStockIn, List<AP_StockInDetail> _APStockInDetail, SqlConnection conn)
        {
            return AP_StockInDA.UpdateByAPStockInID(_APStockIn, _APStockInDetail, conn);
        }
        #endregion

        public DataTable GetAllStockInDetail()
        {
            return AP_StockInDA.SelectAllStockInDetail();
        }

        public DataTable GetAllStockInDetailByDate(DateTime EntryDate)
        {
            return AP_StockInDA.SelectAllStockInDetailByDate(EntryDate);
        }

    }
}

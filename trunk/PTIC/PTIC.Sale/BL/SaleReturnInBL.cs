using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using PTIC.Sale.Entities;
using PTIC.Sale.DA;
using System.Data;

namespace PTIC.Sale.BL
{
    public class SaleReturnInBL
    {
        #region INSERT
        public int Insert(SaleReturnIn saleReturnIn,SaleDetail saleDetail, int? VenID, int? WarehouseID)
        {
            return SaleReturnInDA.Insert(saleReturnIn,saleDetail,VenID, WarehouseID);
        }
        #endregion

        #region UPDATE
        public int UpdateBySalesReturnInID(SaleReturnIn saleReturnIn, int? VenID, int? WarehouseID, SqlConnection conn)
        {
            return SaleReturnInDA.Update(saleReturnIn, VenID, WarehouseID, conn);
        }
        #endregion

        #region SELECT
        public DataTable GetSaleReturnInByDate(DateTime SaleReturnInDate,int CustomerID)
        {
            return SaleReturnInDA.SelectSaleReturnInByDate(SaleReturnInDate,CustomerID);
        }

        public DataTable GetSaleQtyToReturn(int SalesDetailID,int ProductID)
        {
            return SaleReturnInDA.SelectQtyToReturn(SalesDetailID,ProductID);
        }

        public DataTable GetBalanceAmountToReturn(int InvoiceID)
        {
            return SaleReturnInDA.SelectBalanceAmountToReturn(InvoiceID);
        }
        #endregion
    }
}

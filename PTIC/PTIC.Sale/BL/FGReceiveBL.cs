using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PTIC.Sale.Entities;
using PTIC.Sale.DA;
using System.Data.SqlClient;

namespace PTIC.Sale.BL
{
    public class FGReceiveBL
    {
        #region INSERT
        public int Add(FGReceive newfgReceive, List<FGReceiveDetail> newfgReceiveDetail, int WarehouseID, int FactoryID,SqlConnection conn)
        {
            return FGReceiveDA.Insert(newfgReceive, newfgReceiveDetail,WarehouseID,FactoryID ,conn);
        }
        #endregion
    }
}

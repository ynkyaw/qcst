using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using PTIC.Sale.DA;

namespace PTIC.Sale.BL
{
    public class FG_ReceiveBL
    {
        public DataTable GetStockInWarehouse()
        {
            return FG_ReceiveDA.GetStockInMainStore();
        }
    }
}

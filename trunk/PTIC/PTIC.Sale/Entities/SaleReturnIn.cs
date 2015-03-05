using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class SaleReturnIn
    {
        #region Properties
        public int SalesReturnInID { get; set; }
        public int SaleDetailID { get; set; }
        public int ProuductID { get; set; }
        public DateTime Date { get; set; }
        public int SalePersonID { get; set; }
        public int Qty { get; set; }
        public string Remark { get; set; }
        #endregion
    }
}

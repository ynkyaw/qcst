using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class FinishedGood
    {
        #region Properties
        public int ID { get; set; }
        public DateTime ProductionDate { get; set; }
        public string ProductionCode { get; set; }
        public int ProductID { get; set; }
        public int Qty { get; set; }
        public string Remark { get; set; }
        #endregion
    }
}

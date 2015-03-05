using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class AP_StockInDetail
    {
        public int ID { get; set; }
        public int APStockInID { get; set; }
        public int APMaterialID { get; set; }
        public int Qty { get; set; }
        public int BrandID { get; set; }
        public string Remark { get; set; }
        public decimal UnitCost { get; set; }
    }
}

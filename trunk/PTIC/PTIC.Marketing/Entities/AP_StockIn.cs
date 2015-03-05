using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class AP_StockIn
    {
        #region Properties
        public int ID { get; set; }
        public DateTime EntryDate { get; set; }
        public int EntryPersonID { get; set; }
        public int DeptID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        #endregion
    }
}

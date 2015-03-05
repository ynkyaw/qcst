using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class SvcFactoryFunction
    {
        #region Properties
        public int ID { get; set; }
        public int SalesServiceID { get; set; }
        public string FactoryFunction { get; set; }
        public char FaultBy { get; set; }
        public string Remark { get; set; }
        public string SvcCheck { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
    }
}

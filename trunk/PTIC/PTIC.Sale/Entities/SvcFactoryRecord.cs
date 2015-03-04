using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class SvcFactoryRecord
    {
        #region Properties
        public int ID { get; set; }
        public int SalesServiceID { get; set; }
        public string FaultRemark { get; set; }
        public string AGM_Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

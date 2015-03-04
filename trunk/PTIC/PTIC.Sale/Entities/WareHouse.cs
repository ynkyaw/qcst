using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class WareHouse
    {
        #region Properties
        public int ID { get; set; }
        public string WareHouseName{ get; set; }
        public bool IsMain { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

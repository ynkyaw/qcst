using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class DeliveryNote
    {
        #region Properties
        public int ID { get; set; }
        public int? VenID { get; set; }
        public int EmpID { get; set; }
        public int WareHouseID { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

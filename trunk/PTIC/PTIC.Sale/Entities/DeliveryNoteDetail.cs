using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class DeliveryNoteDetail
    {
        public int ID { get; set; }
        public int DeliveryNoteID { get; set; }
        public int ProductID { get; set; }
        public int DeliveryQty { get; set; }
        public int WareHouseQty { get; set; }
        public int ExtraQty { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}

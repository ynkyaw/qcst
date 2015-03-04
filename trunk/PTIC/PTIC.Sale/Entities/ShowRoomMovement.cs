using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class ShowRoomMovement
    {       
        #region Properties
        public int ID { get; set; }
        public int SalePersonID { get; set; }
        public int MoveFrom { get; set; }
        public int MoveTo { get; set; }
        public int VenID { get; set; }
        public DateTime DeliverDate { get; set; }
        public int ProductID { get; set; }
        public int RequestQty { get; set; }
        public int DeliverQty { get; set; }
        public int? ReceivedQty { get; set; }
        public bool Status { get; set; }
        #endregion
        
    }
}

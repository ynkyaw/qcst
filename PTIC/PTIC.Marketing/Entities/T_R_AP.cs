using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class T_R_AP
    {
        #region Properties
        public int ID { get; set; }
        public int TripReqID { get; set; }
        public int A_PID { get; set; }
        public int Qty { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   TransportGate Entiites
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class TransportGate
    {
        #region Entities
        public int TransportGateID { get; set; }
        public int TransportTypeID { get; set; }
        public String GateName { get; set; }
        public String Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }


        #endregion
    }
}

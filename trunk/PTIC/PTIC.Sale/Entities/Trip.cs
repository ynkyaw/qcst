/* Author   :   Aung Ko Ko
    Date      :   20 Feb 2014
    Description :   Trip Entity
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class Trip
    {
        #region Entities
        public int TripID { get; set; }
        public String TripName { get; set; }
        public int TripPeriod { get; set; }
        public String Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

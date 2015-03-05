/* Author   :   Aung Ko Ko
    Date      :   11 Feb 2014
    Description :   Town Entities
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class Town
    {
        #region Town Entities
        public int TownID { get; set; }
        public int StateDivisionID { get; set; }
        public String TownName { get; set; }
        public String Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

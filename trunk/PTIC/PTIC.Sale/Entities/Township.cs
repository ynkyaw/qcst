/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   Township Entiites
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class Township
    {
        #region Entities

        public int TownshipID { get; set; }
        public int TownID { get; set; }
        public String TownshipName { get; set; }
        public String Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   A_P_Usage
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class A_P_Usage
    {
        #region Entities
        public int A_P_UsageID { get; set; }
        public int CusID { get; set; }
        public int DeptID { get; set; }
        public int VenID { get; set; }
        public int SalesPersonID { get; set; }
        public DateTime Date { get; set; }
        public String Advertisement { get; set; }
        public bool IsPTIC { get; set; }        
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
    }
}

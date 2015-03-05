/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   A_P
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class A_P
    {
        #region Entities

        public int A_PID { get; set; }
        public int A_PTypeID { get; set; }
        public String A_PName { get; set; }
        public String Remark { get; set; }
        //
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
    }
}

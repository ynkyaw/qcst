/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   A_P_Type
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class A_P_Type
    {
        #region Entities

        public int A_P_TypeID { get; set; }        
        public String A_P_TypeName { get; set; }
        //
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
    }
}

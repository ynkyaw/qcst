/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   CustomerClass Entiites
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class CustomerClass
    {
        public int CustomerClassID { get; set; }
        public String CusClass { get; set; }
        public String Description { get; set; }
        public String Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}

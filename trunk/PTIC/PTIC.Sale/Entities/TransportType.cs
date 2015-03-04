/* Author   :   Aung Ko Ko
    Date      :   19 Feb 2014
    Description :   TransportType Entiites
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class TransportType
    {
        public int TransportTypeID { get; set; }
        public String TransportTypeName { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}

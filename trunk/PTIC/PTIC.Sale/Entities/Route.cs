/* Author   :   Aung Ko Ko
    Date      :   22 Feb 2014
    Description :  Route Entity
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class Route
    {
        public int RouteID { get; set; }
        public String RouteName { get; set; }
        public String Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}

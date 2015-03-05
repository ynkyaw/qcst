/* Author   :   Aung Ko Ko
    Date      :   22 Feb 2014
    Description :   TownshipInTrip
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class TownshipInRoute
    {
        public int TownshipInRouteID { get; set; }
        public int RouteID { get; set; }
        public int TownshipID { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class RoutePlan
    {
        public int ID {get; set;}
      public int RouteID {get; set;}
      public int SalesPersonID {get; set;}
      public int VenID {get; set;}
      public string RoutePlanNo {get; set;}
      public DateTime PlanDate {get; set;}
      public DateTime TranDate {get; set;}
      public DateTime DateAdded {get; set;}
      public DateTime LastModified {get; set;}
      public bool IsDeleted {get; set;}

    }
}

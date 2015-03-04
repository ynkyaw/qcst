/* Author   :   Aung Ko Ko
    Date      :   20 Feb 2014
    Description :   TownInTrip Entity
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PTIC.Sale.Entities
{
    public class TownInTrip
    {
        public int TownInTripID { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "TownInTrip_TripID_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int TripID { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 0, RangeBoundaryType.Ignore,
                    MessageTemplateResourceName = "TownInTrip_TownID_Invalid",
                    MessageTemplateResourceType = typeof(PTIC.Sale.ErrorMessages))]
        public int TownID { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}

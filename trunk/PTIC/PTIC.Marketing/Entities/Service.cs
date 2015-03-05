/* Author   :   Aung Ko Ko
    Date      :   21 Feb 2014
    Description :   Service
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class Service
    {
        #region Entities

        public int? ServiceID { get; set; }
        public int CusID { get; set; }
        public int VenID { get; set; }
        public int ShowroomID { get; set; }
        public int SalesPersonID { get; set; }
        public int ServiceVia { get; set; }
        public int ServiceNo { get; set; }
        public DateTime ServiceRecDate { get; set; }
        public bool InVen { get; set; }
        public bool InShowroom { get; set; }
        public bool FromOrder { get; set; }
        public bool InMarketing { get; set; }
        public bool InFactory { get; set; }
        public bool ToFactory { get; set; }
        public bool FromFactory { get; set; }
        public bool IsMain { get; set; }
        public bool IsDevice { get; set; }
        public bool InDevice { get; set; }
        //
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
    }
}

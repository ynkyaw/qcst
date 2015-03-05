using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Marketing.Entities
{
    public class MessageUsers
    {
        #region Properties
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}

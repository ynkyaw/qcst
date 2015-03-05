using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class Owner
    {
        public int OwnerID { get; set; }
        public int CusID { get; set; }
        public int AddrID { get; set; }
        public String OwnerName { get; set; }
        public DateTime DOB { get; set; }
        public String NRC { get; set; }
        public String Fax { get; set; }
        public String MobilePhone { get; set; }
        public String HomePhone { get; set; }
        public String Membership { get; set; }
        public String Education { get; set; }
        public String OtherBussiness { get; set; }
        public String SpouseName { get; set; }
        public String Race { get; set; }
        public int Religion { get; set; }
        public String Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}

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

        override public string ToString()
        {
            string str = String.Empty;
            str = String.Concat(str, "OwnerID = ", OwnerID, "\r\n");
            str = String.Concat(str, "CusID = ", CusID, "\r\n");
            str = String.Concat(str, "AddrID = ", AddrID, "\r\n");
            str = String.Concat(str, "OwnerName = ", OwnerName, "\r\n");
            str = String.Concat(str, "DOB = ", DOB, "\r\n");
            str = String.Concat(str, "NRC = ", NRC, "\r\n");
            str = String.Concat(str, "Fax = ", Fax, "\r\n");
            str = String.Concat(str, "MobilePhone = ", MobilePhone, "\r\n");
            str = String.Concat(str, "HomePhone = ", HomePhone, "\r\n");
            str = String.Concat(str, "Membership = ", Membership, "\r\n");
            str = String.Concat(str, "Education = ", Education, "\r\n");
            str = String.Concat(str, "OtherBussiness = ", OtherBussiness, "\r\n");
            str = String.Concat(str, "SpouseName = ", SpouseName, "\r\n");
            str = String.Concat(str, "Race = ", Race, "\r\n");
            str = String.Concat(str, "Religion = ", Religion, "\r\n");
            str = String.Concat(str, "Remark = ", Remark, "\r\n");
            str = String.Concat(str, "DateAdded = ", DateAdded, "\r\n");
            str = String.Concat(str, "LastModified = ", LastModified, "\r\n");
            str = String.Concat(str, "IsDeleted = ", IsDeleted, "\r\n");
            return str;
        }
    }
}

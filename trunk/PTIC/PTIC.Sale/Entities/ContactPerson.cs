/* Author   :   Aung Ko Ko
    Date      :   02 Mar 2014
    Description :  
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class ContactPerson
    {
        #region Properties
        public int ID { get; set; }
        public int? AddrID { get; set; }
        public int CusID { get; set; }
        public string ContactPersonName { get; set; }
        public DateTime DOB { get; set; }
        public string NRC { get; set; }
        public string Post { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Membership { get; set; }
        public string Education { get; set; }
        public string SpouseName { get; set; }
        public string Race { get; set; }
        public int Religion { get; set; }
        public string Remark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion

        override public string ToString()
        {
            string str = String.Empty;
            str = String.Concat(str, "ID = ", ID, "\r\n");
            str = String.Concat(str, "AddrID = ", AddrID, "\r\n");
            str = String.Concat(str, "CusID = ", CusID, "\r\n");
            str = String.Concat(str, "ContactPersonName = ", ContactPersonName, "\r\n");
            str = String.Concat(str, "DOB = ", DOB, "\r\n");
            str = String.Concat(str, "NRC = ", NRC, "\r\n");
            str = String.Concat(str, "Post = ", Post, "\r\n");
            str = String.Concat(str, "Email = ", Email, "\r\n");
            str = String.Concat(str, "MobilePhone = ", MobilePhone, "\r\n");
            str = String.Concat(str, "HomePhone = ", HomePhone, "\r\n");
            str = String.Concat(str, "Membership = ", Membership, "\r\n");
            str = String.Concat(str, "Education = ", Education, "\r\n");
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

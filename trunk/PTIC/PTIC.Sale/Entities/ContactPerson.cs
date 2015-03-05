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
    }
}

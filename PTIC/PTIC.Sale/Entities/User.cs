using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class User
    {
        #region
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public int AccessLvlID { get; set; }
         public bool IsAssign{get;set;}
        #endregion
    }
}

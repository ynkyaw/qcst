using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTIC.Sale.Entities
{
    public class SvcTest
    {
        #region Properties
        public int? ID { get; set; }
        public int SalesServiceID { get; set; }
        public int TestVolt { get; set; }
        public int TestService { get; set; }
        public string TestFault { get; set; }
        public string TestRecPlus1 { get; set; }
        public string TestRecPlus2 { get; set; }
        public string TestRecPlus3 { get; set; }
        public string TestRecPlus4 { get; set; }
        public string TestRecPlus5 { get; set; }
        public string TestRecPlus6 { get; set; }
        public string TestRecMinus1 { get; set; }
        public string TestRecMinus2 { get; set; }
        public string TestRecMinus3 { get; set; }
        public string TestRecMinus4 { get; set; }
        public string TestRecMinus5 { get; set; }
        public string TestRecMinus6 { get; set; }
        public string TestRemark { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}


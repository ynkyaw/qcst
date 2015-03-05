using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class Employee
    {
        #region Properties
        [DataMember]
        public int ID { get; set; }
        [DataMember]
         public string EmpName { get; set; }
        [DataMember]
        public string PostName { get; set; }
        [DataMember]
        public string DeptName { get; set; }
        #endregion
    }
}
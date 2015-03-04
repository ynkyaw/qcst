using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class Customer
    {
        #region Properties
        [DataMember]
        public int CustomerID { get; set; }
        [DataMember]
        public int AddrID { get; set; }
        [DataMember]
        public int? TownID { get; set; }
        [DataMember]
        public string Town { get; set; }
        [DataMember]
        public int? TownshipID { get; set; }
        [DataMember]
        public string Township { get; set; }
        [DataMember]
        public int? RouteID { get; set; }
        //public int? BankID { get; set; }
        [DataMember]
        public int? TripID { get; set; }
        [DataMember]
        public int CusType { get; set; }
        //public int CusClassID { get; set; }
        //public String CusCode { get; set; }
        [DataMember]
        public String CustomerName { get; set; }
        [DataMember]
        public String ContactPersonName { get; set; }
        [DataMember]
        public String Phone1 { get; set; }
        [DataMember]
        public String Phone2 { get; set; }
        //public String Fax { get; set; }
        //public String Email { get; set; }
        //public String Website { get; set; }
        [DataMember]
        public String BankAccNo { get; set; }
        [DataMember]
        public decimal CreditAmount { get; set; }
        [DataMember]
        public int CreditLimit { get; set; }
        [DataMember]
        public decimal CreditBalance { get; set; }
        //public DateTime CusDate { get; set; }
        //public byte[] Photo1 { get; set; }
        //public byte[] Photo2 { get; set; }
        //public byte[] Photo3 { get; set; }
        //public byte[] Photo4 { get; set; }
        //public byte[] Photo5 { get; set; }
        //public bool IsPotential { get; set; }
        //public bool IsMain { get; set; }
        //public bool IsDevice { get; set; }
        //public String Remark { get; set; }
        //public DateTime DateAdded { get; set; }
        //public DateTime LastModified { get; set; }
        //public bool IsDeleted { get; set; }
        #endregion
    }
}
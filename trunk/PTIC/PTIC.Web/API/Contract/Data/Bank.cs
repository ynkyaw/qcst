
using System.Runtime.Serialization;
namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class Bank
    {
        #region Properties
        [DataMember]
        public int BankID { get; set; }
        [DataMember]
        public string BankName { get; set; }
        [DataMember]
        public int? TownID { get; set; }
        [DataMember]
        public string BankAddress { get; set; }
        [DataMember]
        public string Phone { get; set; }        
        #endregion
    }
}
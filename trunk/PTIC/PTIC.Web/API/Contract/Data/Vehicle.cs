
using System.Runtime.Serialization;
namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class Vehicle
    {
        #region Properties
        [DataMember]
        public int VehicleID { get; set; }
        [DataMember]
        public string VenNo { get; set; }
        #endregion
    }
}
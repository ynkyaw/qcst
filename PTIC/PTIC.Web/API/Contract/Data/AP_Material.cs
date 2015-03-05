
using System.Runtime.Serialization;
namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class AP_Material
    {
        #region Properties
        [DataMember]
        public int AP_MaterialID { get; set; }
        [DataMember]
        public int APSubCategoryID { get; set; }
        [DataMember]
        public string APMaterialName { get; set; }
        [DataMember]
        public string Size { get; set; }
        #endregion
    }
}
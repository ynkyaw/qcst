
using System.Runtime.Serialization;
namespace PTIC.Web.API.Contract.Data
{
    [DataContract]
    public class AP_SubCategory
    {
        [DataMember]
        public int AP_SubCategoryID { get; set; }
        [DataMember]
        public string APSubCategoryName { get; set; }
    }
}
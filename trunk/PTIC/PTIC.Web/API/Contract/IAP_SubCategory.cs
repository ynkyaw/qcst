using System.ServiceModel;
using System.ServiceModel.Web;
using PTIC.Web.API.Contract.Data;
using System.Collections.Generic;

namespace PTIC.Web.API.Contract
{
    [ServiceContract]
    public interface IAP_SubCategory
    {
        #region Get all ap sub categories
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "ap-subcategories")]
        List<AP_SubCategory> GetAP_SubCategories();
        #endregion
    }
}

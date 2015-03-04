using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using PTIC.Web.API.Contract.Data;
using System.ServiceModel.Web;

namespace PTIC.Web.API.Contract
{
    [ServiceContract]
    public interface IAP_MaterialService
    {
        #region Get all materials
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "ap-materials")]
        List<AP_Material> GetAP_Materials();
        #endregion
    }
}

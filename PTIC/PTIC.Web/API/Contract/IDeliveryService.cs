using System.ServiceModel;
using System.ServiceModel.Web;
using PTIC.Web.API.Contract.Data;
using System.Collections.Generic;

namespace PTIC.Web.API.Contract
{
    [ServiceContract]
    public interface IDeliveryService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "deliveries")]
        List<Delivery> GetDeliveries();
    }
}

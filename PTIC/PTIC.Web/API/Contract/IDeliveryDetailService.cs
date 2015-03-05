using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using PTIC.Web.API.Contract.Data;

namespace PTIC.Web.API.Contract
{
    [ServiceContract]
    public interface IDeliveryDetailService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "delivery-details/{delivery_id}")]
        List<DeliveryDetail> GetDeliveryDetailsByDeliveryID(string delivery_id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Data;
using PTIC.Web.API.Contract.Data;

namespace PTIC.Web.API.Contract
{
     [ServiceContract]
    public interface IRouteService
    {
         [OperationContract]
         [WebInvoke(Method = "GET",
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Wrapped,
             UriTemplate = "routes")]
         List<Route> GetRoutes();
    }
}
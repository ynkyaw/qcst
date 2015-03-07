/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: (yyyy/MM/dd)
 * Description: PTIC order service interface file
 */

using System.ServiceModel;
using PTIC.Web.API.Contract.Data;
using System.ServiceModel.Web;
using System.Collections;
using System.Collections.Generic;
namespace PTIC.Web.API.Contract
{
    [ServiceContract]
    public interface IOrderService
    {
        /*
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "order/add")]
        void AddOrder(List<Order> newOrders);
         */ 

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "order/add")]
        void AddOrder(Order newOrder, Customer newCustomer);
    }
}

/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: (yyyy/MM/dd)
 * Description: PTIC customer service interface file
 */
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.Generic;
using PTIC.Web.API.Contract.Data;

namespace PTIC.Web.API.Contract
{
    [ServiceContract]
    public interface ICustomerService
    {
        #region Get all customers
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "customers")]
        List<Customer> GetCustomers();
        #endregion

        #region Get customers by route id
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            //UriTemplate = "Customers?RouteID={routeID}")]
            UriTemplate = "customers/routes/{route_id}")]
        List<Customer> GetCustomerByRouteID(string route_id);
        #endregion

        #region Get customers by trip id
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,            
            UriTemplate = "customers/trips/{trip_id}")]
        List<Customer> GetCustomerByTripID(string trip_id);
        #endregion

        #region Add new customer
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,            
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "customer/add")]
        string AddCustomer(Customer newCustomer);
        #endregion

    }
}

/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: (yyyy/MM/dd)
 * Description: PTIC product service interface file
 */
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using PTIC.Web.API.Contract.Data;

namespace PTIC.Web.API.Contract
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "products")]
        List<Product> GetProducts();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            //UriTemplate = "PriceList")]
            UriTemplate = "products/price-list")]
        List<ProductPrice> GetPriceList();
        
    }
}

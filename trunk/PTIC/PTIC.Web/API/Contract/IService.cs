/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: (yyyy/MM/dd)
 * Description: PTIC service interface file
 */
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PTIC.Web.API.Contract
{
    /// <summary>
    /// PTIC Service contract interface
    /// </summary>
    [ServiceContract]
    public interface IService :
        ICustomerService, 
        IProductService, 
        IRouteService, 
        ITripService, 
        IDeliveryService, 
        IDeliveryDetailService, 
        IBankService,
        IBrandService,
        IProductCategoryService,
        IProductSubCategoryService,
        ISalesInvoiceDetailService,
        ISalesInvoiceService,
        IPayment,
        ITransportTypeService,
        ITransportGateService,
        IEmployeeService,
        IOrderService,
        IOrderDetailService,
        IDailyMarketingPlanService,
        IMobileServicePlanService,
        ICompetitorBrandService,
        ISalesReturnService,
        IBatteryStatusService,
        IVehicle,
        IAP_MaterialService, IAP_SubCategory
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "info")]
        Info GetInfo();
    }
}

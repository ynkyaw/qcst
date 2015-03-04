/*
 * Author:  Wai Phyoe Thu <waiphyoethu@asiagreenleaf.com>, <wpt.osp@gmail.com> 
 * Create date: (yyyy/MM/dd)
 * Description: PTIC vehicle service interface file
 */

using System.ServiceModel;
using System.ServiceModel.Web;
using PTIC.Web.API.Contract.Data;
using System.Collections.Generic;
namespace PTIC.Web.API.Contract
{
    [ServiceContract]
    public interface IVehicle
    {
        #region Get all Banks
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "vehicles")]
        List<Vehicle> GetVehicles();
        #endregion
    }
}

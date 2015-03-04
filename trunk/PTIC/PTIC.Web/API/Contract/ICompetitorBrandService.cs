using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using PTIC.Web.API.Contract.Data;

namespace PTIC.Web.API.Contract
{
    [ServiceContract]
    public interface ICompetitorBrandService
    {
        #region Get all Brands
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "competitorbrands")]
        List<CompetitorBrand> GetCompetitorBrands();
        #endregion
    }
}
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
    public interface IDailyMarketingPlanService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            //UriTemplate = "dailymarketingplan/?startdate={startdate}&enddate={enddate}")]
            UriTemplate = "dailymarketingplan/{startdate}/{enddate}")]
        List<MarketingPlan> GetDailyMarketingPlan(string startdate,string enddate);
    }
}
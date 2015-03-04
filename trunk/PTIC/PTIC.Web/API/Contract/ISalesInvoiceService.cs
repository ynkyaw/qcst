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
    public interface ISalesInvoiceService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "invoices/debit/route/{route_id}")]
        List<Invoice> GetInvoicesByRouteID(string route_id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "invoices/debit/trip/{trip_id}")]
        List<Invoice> GetInvoicesByTripID(string trip_id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "invoice/credit/add")]
        void AddCreditInvoice(Invoice newCreditInvoice);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "invoice/cash/add")]
        void AddCashInvoice(Invoice newCashInvoice, CommDiscount newCommDiscount, Tax newTax, int vehicleID);

    }
}
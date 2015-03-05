using System.Collections.Generic;
using System.ServiceModel;
using PTIC.Web.API.Contract.Data;
using System.ServiceModel.Web;

namespace PTIC.Web.API.Contract
{
    [ServiceContract]
    public interface IPayment
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "payment-details/{invoice_id}")]
        List<Payment> GetPaymentDetailsByInvoiceID(string invoice_id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
        UriTemplate = "payment/single-inv/add")]
        void AddPayment(Payment newPayment);
    }
}


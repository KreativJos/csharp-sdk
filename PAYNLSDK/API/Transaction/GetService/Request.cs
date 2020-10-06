using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Transaction.GetService
{
    public class Request : RequestBase
    {
        public override bool RequiresServiceId
        {
            get { return true; }
        }

        [JsonProperty("paymentMethodId")]
        public Enums.PaymentMethodId? PaymentMethodId { get; set; }

        public override int Version
        {
            get { return 16; }
        }

        public override string Controller
        {
            get { return "Transaction"; }
        }

        public override string Method
        {
            get { return "getService"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters(string apiToken, string serviceId)
        {
            var parameters = base.GetParameters(apiToken, serviceId);

            if (!ParameterValidator.IsNull(PaymentMethodId))
                parameters.Add("paymentMethodId", ((int)PaymentMethodId).ToString());

            return parameters;
        }
        public Response Response { get { return (Response)response; } }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
                throw new ErrorException("rawResponse is empty!");

            response = JsonConvert.DeserializeObject<Response>(RawResponse);
        }
    }
}

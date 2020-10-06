using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.PaymentMethod.Get
{
    public class Request : RequestBase
    {
        [JsonProperty("paymentMethodId")]
        public int PaymentMethodId { get; set; }

        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "PaymentMethod"; }
        }

        public override string Method
        {
            get { return "get"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters(string apiToken, string serviceId)
        {
            var parameters = base.GetParameters(apiToken, serviceId);

            ParameterValidator.IsNotNull(PaymentMethodId, "PaymentMethodId");
            parameters.Add("paymentMethodId", PaymentMethodId.ToString());

            return parameters;
        }

        public Response Response { get { return (Response)response; } }


        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
                throw new ErrorException("rawResponse is empty!");

            response = new Response
            {
                PaymentMethod = JsonConvert.DeserializeObject<Objects.PaymentMethod>(RawResponse)
            };
        }
    }
}

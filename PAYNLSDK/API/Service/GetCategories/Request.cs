using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;


namespace PAYNLSDK.API.Service.GetCategories
{
    public class Request : RequestBase
    {
        [JsonProperty("paymentOptionId")]
        public int? PaymentOptionId { get; set; }

        public override int Version
        {
            get { return 3; }
        }

        public override string Controller
        {
            get { return "Service"; }
        }

        public override string Method
        {
            get { return "getCategories"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters(string apiToken, string serviceId)
        {
            var parameters = base.GetParameters(apiToken, serviceId);

            if (!ParameterValidator.IsNonEmptyInt(PaymentOptionId))
                parameters.Add("paymentOptionId", PaymentOptionId.ToString());

            return parameters;
        }

        public Response Response { get { return (Response)response; } }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
                throw new ErrorException("rawResponse is empty!");

            response = new Response
            {
                ServiceCategories = JsonConvert.DeserializeObject<Objects.ServiceCategory[]>(RawResponse)
            };
        }
    }
}

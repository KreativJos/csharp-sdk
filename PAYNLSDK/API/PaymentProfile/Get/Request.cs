using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.PaymentProfile.Get
{
    public class Request : RequestBase
    {
        [JsonProperty("paymentProfileId")]
        public int PaymentProfileId { get; set; }

        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "PaymentProfile"; }
        }

        public override string Method
        {
            get { return "get"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters(string serviceId)
        {
            var parameters = base.GetParameters(serviceId);

            ParameterValidator.IsNotNull(PaymentProfileId, "PaymentProfileId");
            parameters.Add("paymentProfileId", PaymentProfileId.ToString());

            return parameters;
        }

        public Response Response { get { return (Response)response; } }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
                throw new ErrorException("rawResponse is empty!");

            response = new Response
            {
                PaymentProfile = JsonConvert.DeserializeObject<Objects.PaymentProfile>(RawResponse)
            };
        }
    }
}

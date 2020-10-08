using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Converters;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.PaymentProfile.GetAvailable
{
    public class Request : RequestBase
    {
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("programId")]
        public int? ProgramId { get; set; }

        [JsonProperty("paymentMethodId")]
        public int? PaymentMethodId { get; set; }

        [JsonProperty("showNotAllowedOnRegistration"), JsonConverter(typeof(BooleanConverter))]
        public bool? ShowNotAllowedOnRegistration { get; set; }

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
            get { return "getAvailable"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters(string serviceId)
        {
            var parameters = base.GetParameters(serviceId);

            ParameterValidator.IsNotNull(CategoryId, "CategoryId");
            parameters.Add("categoryId", CategoryId.ToString());

            if (!ParameterValidator.IsNonEmptyInt(ProgramId))
                parameters.Add("programId", ProgramId.ToString());

            if (!ParameterValidator.IsNonEmptyInt(PaymentMethodId))
                parameters.Add("paymentMethodId", PaymentMethodId.ToString());

            if (!ParameterValidator.IsNull(ShowNotAllowedOnRegistration))
                parameters.Add("ShowNotAllowedOnRegistration", ((bool)ShowNotAllowedOnRegistration) ? "1" : "0");

            return parameters;
        }

        public Response Response { get { return (Response)response; } }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
                throw new ErrorException("rawResponse is empty!");

            response = new Response
            {
                PaymentProfiles = JsonConvert.DeserializeObject<Objects.PaymentProfile[]>(RawResponse)
            };
        }
    }
}

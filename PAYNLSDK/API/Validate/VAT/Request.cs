using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Validate.VAT
{
    public class Request : RequestBase
    {
        [JsonProperty("vat")]
        public string VAT { get; set; }

        public override bool RequiresApiToken
        {
            get { return false; }
        }

        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "Validate"; }
        }

        public override string Method
        {
            get { return "VAT"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters(string apiToken, string serviceId)
        {
            var parameters = base.GetParameters(apiToken, serviceId);

            ParameterValidator.IsNotEmpty(VAT, "vat");
            parameters.Add("vat", VAT);

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

using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Validate.SOFI
{
    public class Request : RequestBase
    {
        [JsonProperty("sofi")]
        public string SOFI { get; set; }

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
            get { return "SOFI"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters(string serviceId)
        {
            var parameters = base.GetParameters(serviceId);

            ParameterValidator.IsNotEmpty(SOFI, "sofi");
            parameters.Add("sofi", SOFI);

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

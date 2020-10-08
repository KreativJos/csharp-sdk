using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.SMS.PremiumMessage
{
    public class Request : RequestBase
    {

        [JsonProperty("sms_id")]
        public string SmsId { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "SMS"; }
        }

        public override string Method
        {
            get { return "sendPremiumMessage"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters(string serviceId)
        {
            var parameters = base.GetParameters(serviceId);

            ParameterValidator.IsNotEmpty(SmsId, "SmsId");
            parameters.Add("sms_id", SmsId);

            ParameterValidator.IsNotEmpty(Secret, "secret");
            parameters.Add("secret", Secret);

            ParameterValidator.IsNotEmpty(Message, "message");
            parameters.Add("message", Message);

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

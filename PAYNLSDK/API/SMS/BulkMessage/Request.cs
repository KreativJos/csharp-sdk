using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.SMS.BulkMessage
{
    public class Request : RequestBase
    {
        [JsonProperty("org")]
        public string Sender { get; set; }

        [JsonProperty("dest")]
        public string Recipient { get; set; }

        [JsonProperty("body")]
        public string Message { get; set; }

        //[JsonProperty("starttime")]
        //public int SendTime { get; set; }

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
            get { return "sendBulkMessage"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters(string serviceId)
        {
            var parameters = base.GetParameters(serviceId);

            ParameterValidator.IsNotEmpty(Sender, "Sender");
            parameters.Add("org", Sender);

            ParameterValidator.IsNotEmpty(Recipient, "Recipient");
            parameters.Add("dest", Recipient);

            ParameterValidator.IsNotEmpty(Message, "Message");
            parameters.Add("body", Message);

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

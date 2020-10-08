using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Transaction.GetLastTransactions
{
    public class Request : RequestBase
    {
        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        [JsonProperty("paid")]
        public bool? Paid { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        public override bool RequiresServiceId
        {
            get { return true; }
        }

        public override int Version
        {
            get { return 5; }
        }

        public override string Controller
        {
            get { return "Transaction"; }
        }

        public override string Method
        {
            get { return "getLastTransactions"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters(string serviceId)
        {
            var parameters = base.GetParameters(serviceId);

            if (!ParameterValidator.IsNull(MerchantId))
                parameters.Add("merchantId", MerchantId);

            if (!ParameterValidator.IsNull(Paid))
                parameters.Add("paid", ((bool)Paid) ? "1" : "0");

            if (!ParameterValidator.IsNull(Limit))
                parameters.Add("limit", Limit.ToString());

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

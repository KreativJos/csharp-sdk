using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Transaction.Info
{
    public class Request : RequestBase
    {
        public string TransactionId { get; set; }

        public string EntranceCode { get; set; }

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
            get { return "info"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters(string apiToken, string serviceId)
        {
            var parameters = base.GetParameters(apiToken, serviceId);

            ParameterValidator.IsNotEmpty(TransactionId, "TransactionId");
            parameters.Add("transactionId", TransactionId);

            if (!ParameterValidator.IsEmpty(EntranceCode))
                parameters.Add("entranceCode", EntranceCode);

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

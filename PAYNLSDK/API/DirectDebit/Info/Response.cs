using Newtonsoft.Json;
using PAYNLSDK.Objects;

namespace PAYNLSDK.API.DirectDebit.Info
{
    public class Response : ResponseBase
    {
        [JsonProperty("result")]
        public DirectDebitInfoResult Result { get; set; }
    }
}
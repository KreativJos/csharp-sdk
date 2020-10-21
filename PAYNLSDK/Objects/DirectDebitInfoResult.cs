using Newtonsoft.Json;

namespace PAYNLSDK.Objects
{
    public class DirectDebitInfoResult
    {
        [JsonProperty("mandate")]
        public Mandate Mandate { get; set; }

        [JsonProperty("directDebit")]
        public DirectDebit DirectDebit { get; set; }
    }
}
using Newtonsoft.Json;

using PAYNLSDK.Enums;

namespace PAYNLSDK.API.DirectDebit.MandateAdd
{
    public class Response : ResponseBase
    {
        public DirectDebitErrorCode? ErrorCode { get { return Request?.Code?.ToEnum<DirectDebitErrorCode>(); } }

        [JsonProperty("result")]
        public string MandateId { get; set; }
    }
}
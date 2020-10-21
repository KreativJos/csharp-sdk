using Newtonsoft.Json;

using PAYNLSDK.Enums;

namespace PAYNLSDK.API.DirectDebit.RecurringAdd
{
    public class Response : ResponseBase
    {
        public DirectDebitErrorCode? ErrorCode { get { return Request?.Code?.ToEnum<DirectDebitErrorCode>(); } }

        [JsonProperty("result")]
        public string MandateId { get; set; }
    }
}
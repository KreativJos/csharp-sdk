using Newtonsoft.Json;
using PAYNLSDK.Converters;
using PAYNLSDK.Enums;

namespace PAYNLSDK.Objects
{
    public class Mandate
    {
        [JsonProperty("result")]
        public string MandateId { get; set; }
        [JsonProperty("result")]
        public string BankaccountNumber { get; set; }
        [JsonProperty("result")]
        public string BankaccountOwner { get; set; }
        [JsonProperty("result")]
        public string BankaccountBic { get; set; }

        [JsonProperty("result")]
        public int? Amount { get; set; }
        [JsonProperty("result")]
        public string Description { get; set; }
        [JsonProperty("result")]
        public int? InternalValue { get; set; }
        [JsonProperty("intervalPeriod"), JsonConverter(typeof(MandateIntervalConverter))]
        public MandateInterval? IntervalPeriod { get; set; }
        [JsonProperty("result")]
        public int? IntervalQuantity { get; set; }
        /// <summary>
        /// First, active, last, single
        /// </summary>
        /// <value></value>
        [JsonProperty("result")]
        public string State { get; set; }
        [JsonProperty("result")]
        public string IpAddress { get; set; }
        [JsonProperty("result")]
        public string Email { get; set; }
        [JsonProperty("result")]
        public string PromotorId { get; set; }
        [JsonProperty("result")]
        public string Tool { get; set; }
        [JsonProperty("info")]
        public string Info { get; set; }
        [JsonProperty("object")]
        public string Object { get; set; }
        [JsonProperty("extra1")]
        public string Extra1 { get; set; }
        [JsonProperty("extra2")]
        public string Extra2 { get; set; }
        [JsonProperty("extra3")]
        public string Extra3 { get; set; }
    }
}
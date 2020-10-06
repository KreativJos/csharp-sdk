using Newtonsoft.Json;

using PAYNLSDK.Converters;

namespace PAYNLSDK.API.Validate.SWIFT
{
    public class Response : ResponseBase
    {
        [JsonProperty("result"), JsonConverter(typeof(BooleanConverter))]
        public bool Result { get; protected set; }
    }
}

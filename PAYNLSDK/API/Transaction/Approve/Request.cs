﻿using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Transaction.Approve
{
    /// <summary>
    /// function to approve a suspicious transaction
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// not implemented
        /// </summary>
        //  [JsonProperty("entranceCode")]
        //   public string EntranceCode { get; set; }

        /* overrides */
        /// <summary>
        /// 
        /// </summary>
        public override int Version
        {
            get { return 7; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Controller
        {
            get { return "Transaction"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Method
        {
            get { return "approve"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Querystring
        {
            get { return ""; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override NameValueCollection GetParameters(string serviceId)
        {
            var parameters = base.GetParameters(serviceId);

            ParameterValidator.IsNotEmpty(TransactionId, "TransactionId");
            parameters.Add("orderId", TransactionId);

            return parameters;
        }

        /// <summary>
        /// 
        /// </summary>
        public Response Response { get { return (Response)response; } }

        /// <summary>
        /// 
        /// </summary>
        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
                throw new ErrorException("rawResponse is empty!");

            response = JsonConvert.DeserializeObject<Response>(RawResponse);
        }
    }
}

using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Refund.Info
{
    /// <summary>
    /// 
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// create new instance
        /// </summary>
        /// <param name="refundId">Refund ID</param>
        public Request(string refundId)
        {
            this.RefundId = refundId;
        }

        /// <summary>
        /// The refund ID.
        /// </summary>
        public string RefundId { get; set; }

        /* overrides */
        /// <summary>
        /// 
        /// </summary>
        public override int Version
        {
            get { return 3; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Controller
        {
            get { return "Refund"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Method
        {
            get { return "info"; }
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
        public override bool RequiresApiToken
        {
            get { return true; }
        }
        /// <summary>
        /// 
        /// </summary>
        public override bool RequiresServiceId
        {
            get { return true; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override NameValueCollection GetParameters(string serviceId)
        {
            var parameters = base.GetParameters(serviceId);

            ParameterValidator.IsNotNull(RefundId, "RefundId");
            parameters.Add("refundId", RefundId);

            return parameters;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
                throw new ErrorException("rawResponse is empty!");

            response = JsonConvert.DeserializeObject<Response>(RawResponse);

            if (!Response.Request.Result)
                throw new ErrorException(Response.Request.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        public Response Response { get { return (Response)response; } }
    }
}

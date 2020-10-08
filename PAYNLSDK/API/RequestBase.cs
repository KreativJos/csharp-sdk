using Newtonsoft.Json;
using PAYNLSDK.Net;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Specialized;
using System.Text;

namespace PAYNLSDK.API
{
    public abstract class RequestBase
    {
        /// <summary>
        /// Indicator stating whether or not a API Token is required for a specific request
        /// </summary>
        public virtual bool RequiresApiToken { get { return true; } }

        /// <summary>
        /// Indicator stating whether or not a Service ID is required for a specific request
        /// </summary>
        public virtual bool RequiresServiceId { get { return false; } }

        /// <summary>
        /// Return as JSON
        /// </summary>
        /// <returns>JSON string</returns>
        public override string ToString()
        {
            //return base.ToString();
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// URL used to perform this specific request
        /// </summary>
        public string Url
        {
            get { return string.Format("v{0}/{1}/{2}/json", Version, Controller, Method); }
        }

        /// <summary>
        /// Api Version for this request
        /// </summary>
        public abstract int Version { get; }

        /// <summary>
        /// Controller used for this request
        /// </summary>
        public abstract string Controller { get; }

        /// <summary>
        /// COntroller method for this request
        /// </summary>
        public abstract string Method { get; }

        /// <summary>
        /// Extra querystring parameters used for this request
        /// </summary>
        public abstract string Querystring { get; }

        /// <summary>
        /// Returns a NameValueCollection of all paramaters used for this call.
        /// </summary>
        /// <returns>Name Value collection of parameters</returns>
        public virtual NameValueCollection GetParameters(string serviceId)
        {
            var parameters = new NameValueCollection();

            if (RequiresServiceId)
            {
                ParameterValidator.IsNotEmpty(serviceId, "ServiceId");
                parameters.Add("serviceId", serviceId);
            }

            return parameters;
        }
        
        /// <summary>
        /// Transform NameValueCollection to a querystring
        /// </summary>
        /// <returns>appendable querystring</returns>
        public string ToQueryString(string serviceId = null)
        {
            var parameters = GetParameters(serviceId);

            if (parameters.Count == 0)
                return "";

            var sb = new StringBuilder();
            // TODO: add "?" if GET?

            var first = true;

            foreach (string key in parameters.AllKeys)
            {
                foreach (string value in parameters.GetValues(key))
                {
                    if (!first)
                        sb.Append("&");

                    sb.AppendFormat("{0}={1}", Uri.EscapeDataString(key), Uri.EscapeDataString(value));

                    first = false;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Response belonging to this request
        /// </summary>
        protected ResponseBase response;

        /// <summary>
        /// The raw response stroing
        /// </summary>
        protected string rawResponse;

        /// <summary>
        /// Raw response data
        /// </summary>
        public string RawResponse
        {
            get
            {
                return rawResponse;
            }
            set
            {
                rawResponse = value;
                SetResponse();
            }
        }

        /// <summary>
        /// Load the raw response and perform any actions along with it.
        /// </summary>
        public abstract void SetResponse();
    }
}

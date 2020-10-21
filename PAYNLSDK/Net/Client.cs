using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

using PAYNLSDK.API;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Net.ProxyConfigurationInjector;

using Newtonsoft.Json;
using PAYNLSDK.Utilities;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace PAYNLSDK.Net
{
    public class Client : IClient
    {
        const string ApplicationJsonContentType = "application/json"; // http://tools.ietf.org/html/rfc4627
        const string WWWUrlContentType = "application/x-www-form-urlencoded"; // http://tools.ietf.org/html/rfc4627

        private static HttpClient _staticHttpClient;
        private readonly HttpClient _httpClient;
        protected HttpClient InternalHttpClient
        {
            get
            {
                if (_httpClient != null) return _httpClient;
                if (_staticHttpClient == null) _staticHttpClient = new HttpClient();

                return _staticHttpClient;
            }
        }

        private ClientSettings Settings { get; }

        /// <summary>
        /// API VERSION
        /// </summary>
        public string ApiVersion
        {
            get;
            private set;
        }

        /// <summary>
        /// Client version
        /// </summary>
        public string ClientVersion
        {
            get { return "1.0.1.1"; }
        }

        /// <summary>
        /// User agent
        /// </summary>
        public string UserAgent
        {
            get { return string.Format("PAYNL/SDK/{0} DotNet/{1}", ClientVersion, ""); }
        }

        public Client(HttpClient httpClient, ClientSettings settings)
        {
            Settings = settings;
            _httpClient = httpClient;
        }

        /// <summary>
        /// Create a new Service client
        /// </summary>
        /// <param name="apiToken">PAYNL Api Token</param>
        /// <param name="serviceID">PAYNL Service ID</param>
        /// <param name="proxyConfigurationInjector">Proxy Injector</param>
        public Client(string apiToken, string serviceID, IProxyConfigurationInjector proxyConfigurationInjector)
        {
            Settings = new ClientSettings()
            {
                ApiToken = apiToken,
                ServiceID = serviceID,
                ProxyConfigurationInjector = proxyConfigurationInjector,
            };
        }

        /// <summary>
        /// Create a new Service client
        /// </summary>
        /// <param name="apiToken">PAYNL Api Token</param>
        /// <param name="serviceID">PAYNL Service ID</param>
        public Client(string apiToken, string serviceID)
            : this(apiToken, serviceID, null)
        {
        }

        /// <summary>
        /// Create a new Service client
        /// </summary>
        /// <param name="apiToken">PAYNL Api Token</param>
        public Client(string apiToken)
            : this(apiToken, null, null)
        {
        }

        private string GetAuthorizationHeader()
        {
            var bytes = Encoding.ASCII.GetBytes($"token: {Settings.ApiToken}");

            return $"Basic {Convert.ToBase64String(bytes)}";
        }

        /// <summary>
        /// Performs an actual request
        /// </summary>
        /// <param name="request">Specific request implementation to perform</param>
        /// <returns>raw response string</returns>
        public string PerformRequest(RequestBase request)
        {
            var httpRequest = PrepareRequest(request.Url, "POST");

            if (request.RequiresApiToken)
            {
                ParameterValidator.IsNotEmpty(Settings.ApiToken, "ApiToken");
                httpRequest.Headers["authorization"] = GetAuthorizationHeader();
            }

            var rawResponse = PerformRoundTrip2(httpRequest, HttpStatusCode.OK, () =>
            {
                using var requestWriter = new StreamWriter(httpRequest.GetRequestStream());

                //string serializedResource = resource.Serialize();
                var serializedResource = request.ToQueryString(Settings.ServiceID);

                requestWriter.Write(serializedResource);
            });

            request.RawResponse = rawResponse;

            return rawResponse;
        }

        public async Task<string> PerformRequestAsync(RequestBaseBase request, CancellationToken cancellationToken = default)
        {
            if (Settings.ProxyConfigurationInjector != null)
                throw new NotImplementedException($"PerformRequestAsync not implemented yet with {nameof(Settings.ProxyConfigurationInjector)}");

            var httpRequestContent = new FormUrlEncodedContent(request.GetParametersDictionary(Settings.ServiceID));

            httpRequestContent.Headers.ContentType.MediaType = WWWUrlContentType;

            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{Settings.Endpoint}/{request.Url}")
            {
                Content = httpRequestContent,
            };

            httpRequest.Headers.Accept.Clear();
            httpRequest.Headers.Accept.ParseAdd(ApplicationJsonContentType);
            httpRequest.Headers.UserAgent.Add(new ProductInfoHeaderValue("PAYNL_SDK_DOTNET_CORE", ClientVersion));

            if (request.RequiresApiToken)
            {
                ParameterValidator.IsNotEmpty(Settings.ApiToken, "ApiToken");

                var apiTokenBytes = Encoding.ASCII.GetBytes($"token: {Settings.ApiToken}");

                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(apiTokenBytes));
            }

            var response = await InternalHttpClient.SendAsync(httpRequest, cancellationToken)
                .ConfigureAwait(false);

            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            request.RawResponse = responseContent;

            return responseContent;
        }

        /// <summary>
        /// Prepares a request
        /// </summary>
        /// <param name="requestUriString">URL to call</param>
        /// <param name="method">Request Method (get, post, delete, put)</param>
        /// <returns></returns>
        private HttpWebRequest PrepareRequest(string requestUriString, string method)
        {
            var uriString = string.Format("{0}/{1}", Settings.Endpoint, requestUriString);
            var uri = new Uri(uriString);
            var request = WebRequest.Create(uri) as HttpWebRequest;

            request.UserAgent = UserAgent;

            const string ApplicationJsonContentType = "application/json"; // http://tools.ietf.org/html/rfc4627
            const string WWWUrlContentType = "application/x-www-form-urlencoded"; // http://tools.ietf.org/html/rfc4627

            request.Accept = ApplicationJsonContentType;
            //request.ContentType = ApplicationJsonContentType;
            request.ContentType = WWWUrlContentType;
            // request.Credentials =
            request.Method = method;

            if (Settings.ProxyConfigurationInjector != null)
                request.Proxy = Settings.ProxyConfigurationInjector.InjectProxyConfiguration(request.Proxy, uri);

            return request;
        }

        /// <summary>
        /// Performs the actual HTTP Request
        /// </summary>
        /// <param name="request">the http request</param>
        /// <param name="expectedHttpStatusCode">expected http status code</param>
        /// <param name="requestAction">Any action that can be executed before actually performing the http request</param>
        /// <returns>raw response</returns>
        private string PerformRoundTrip2(HttpWebRequest request, HttpStatusCode expectedHttpStatusCode, Action requestAction)
        {
            try
            {
                requestAction();

                using var response = request.GetResponse() as HttpWebResponse;

                var statusCode = (HttpStatusCode)response.StatusCode;

                if (statusCode == expectedHttpStatusCode)
                {
                    Stream responseStream = response.GetResponseStream();
                    Encoding encoding = GetEncoding(response);

                    using var responseReader = new StreamReader(responseStream, encoding);

                    return responseReader.ReadToEnd();
                }

                throw new ErrorException(string.Format("Unexpected status code {0}", statusCode));
            }
            catch (WebException e)
            {
                throw ErrorExceptionFromWebException(e);
            }
            catch (Exception e)
            {
                throw new ErrorException(string.Format("Unhandled exception {0}", e), e);
            }
        }

        /// <summary>
        /// Get the Encoding
        /// </summary>
        /// <param name="response">http response</param>
        /// <returns>Encoding</returns>
        private static Encoding GetEncoding(HttpWebResponse response)
        {
            // TODO: Make this conditional on the encoding of the response.
            Encoding encode = Encoding.UTF8; // GetEncoding("utf-8"); // Encoding.GetEncoding(response.CharacterSet);
            return encode;
        }

        /// <summary>
        /// Build an error exception from a Web Exception
        /// </summary>
        /// <param name="e">web exception</param>
        /// <returns>ErrorException</returns>
        private ErrorException ErrorExceptionFromWebException(WebException e)
        {
            // some kind of network error: didn't even make a connection
            if (!(e.Response is HttpWebResponse httpWebResponse))
                return new ErrorException(e.Message, e);

            var statusCode = (HttpStatusCode)httpWebResponse.StatusCode;

            switch (statusCode)
            {
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.MethodNotAllowed:
                case HttpStatusCode.UnprocessableEntity:
                case HttpStatusCode.BadRequest:
                    {
                        // Try JSON parsing.
                        using var responseReader = new StreamReader(httpWebResponse.GetResponseStream());

                        string rawResponse = responseReader.ReadToEnd();

                        try
                        {
                            var errors = JsonConvert.DeserializeObject<Dictionary<string, string>>(rawResponse);
                            var errMessage = "";

                            if (errors.ContainsKey("error"))
                                errMessage = errors["error"];
                            else if (errors.ContainsKey("message"))
                                errMessage = errors["message"];

                            var errorException = new ErrorException(errMessage, e);

                            if (errorException != null)
                                return errorException;
                        }
                        catch (Exception)
                        {
                            return new ErrorException(string.Format("Unknown error for {0}", statusCode), e);
                        }

                        return new ErrorException(string.Format("Unknown error for {0}", statusCode), e);
                    }
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.NotImplemented:
                case HttpStatusCode.BadGateway:
                case HttpStatusCode.ServiceUnavailable:
                case HttpStatusCode.GatewayTimeout:
                case HttpStatusCode.HttpVersionNotSupported:
                case HttpStatusCode.VariantAlsoNegotiates:
                case HttpStatusCode.InsufficientStorage:
                case HttpStatusCode.LoopDetected:
                case HttpStatusCode.BandwidthLimitExceeded:
                case HttpStatusCode.NotExtended:
                case HttpStatusCode.NetworkAuthenticationRequired:
                case HttpStatusCode.NetworkReadTimeoutError:
                case HttpStatusCode.NetworkConnectTimeoutError:
                    return new ErrorException("Something went wrong on our end, please try again", e);
                default:
                    return new ErrorException(string.Format("Unhandled status code {0}", statusCode), e);
            }
        }
    }
}

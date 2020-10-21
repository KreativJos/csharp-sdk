using System;

using PAYNLSDK.Net.ProxyConfigurationInjector;

namespace PAYNLSDK.Net
{
    public class ClientSettings
    {
        public string ApiToken { get; set; }
        public string ServiceID { get; set; }
        public string Endpoint { get; set; } = "https://rest-api.pay.nl";
        public Uri EndpointUri { get { return new Uri(Endpoint); } }
        public IProxyConfigurationInjector ProxyConfigurationInjector { get; set; }
    }
}

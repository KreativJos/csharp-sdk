using Newtonsoft.Json;

using PAYNLSDK.Net;

namespace PAYNLSDK.API.Validate
{
    public class Util
    {
        public IClient Client { get; set; }

        private JsonSerializerSettings serializerSettings;
        public JsonSerializerSettings SerializerSettings
        {
            get
            {
                if (serializerSettings == null)
                {
                    serializerSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    };
                }

                return serializerSettings;
            }
            set
            {
                serializerSettings = value;
            }
        }

        public Util(IClient client) : this(client, null)
        {
        }

        public Util(IClient client, JsonSerializerSettings serializerSettings)
        {
            Client = client;
            SerializerSettings = serializerSettings;
        }

        public bool ValidatePayIP(string ipAddress)
        {
            var request = new IsPayServerIp.Request
            {
                IpAddress = ipAddress
            };

            Client.PerformRequest(request);

            return request.Response.Result;
        }

        public bool ValidateBankAccountNumber(string bankAccountNumber, bool international)
        {
            if (international)
            {
                var request = new BankAccountNumberInternational.Request
                {
                    BankAccountNumber = bankAccountNumber
                };

                Client.PerformRequest(request);

                return request.Response.Result;
            }
            else
            {
                var request = new BankAccountNumber.Request
                {
                    BankAccountNumber = bankAccountNumber
                };

                Client.PerformRequest(request);

                return request.Response.Result;
            }
        }

        public bool ValidateIBAN(string iban)
        {
            var request = new IBAN.Request
            {
                IBAN = iban
            };

            Client.PerformRequest(request);

            return request.Response.Result;
        }

        public bool ValidateSWIFT(string swift)
        {
            var request = new SWIFT.Request
            {
                SWIFT = swift
            };

            Client.PerformRequest(request);

            return request.Response.Result;
        }

        public bool ValidateKVK(string kvk)
        {
            var request = new KVK.Request
            {
                KVK = kvk
            };

            Client.PerformRequest(request);

            return request.Response.Result;
        }

        public bool ValidateVAT(string vat)
        {
            var request = new VAT.Request
            {
                VAT = vat
            };

            Client.PerformRequest(request);

            return request.Response.Result;
        }

        public bool ValidateSOFI(string sofi)
        {
            var request = new SOFI.Request
            {
                SOFI = sofi
            };

            Client.PerformRequest(request);

            return request.Response.Result;
        }
    }
}

using PAYNLSDK.Net;

namespace PAYNLSDK
{
    public class Banktransfer
    {
        static public API.Banktransfer.Add.Response Add(IClient client, API.Banktransfer.Add.Request request)
        {
            client.PerformRequest(request);

            return request.Response;
        }

        static public API.Banktransfer.Add.Response Add(IClient client, int amount, string bankAccountHolder, string bankAccountNumber, string bankAccountBic)
        {
            var request = new API.Banktransfer.Add.Request(amount, bankAccountHolder, bankAccountNumber, bankAccountBic);

            client.PerformRequest(request);

            return request.Response;
        }
    }
}

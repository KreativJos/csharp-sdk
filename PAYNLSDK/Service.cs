using PAYNLSDK.Net;
using ServiceGetCategories = PAYNLSDK.API.Service.GetCategories.Request;

namespace PAYNLSDK
{
    /// <summary>
    /// Generic Service service helper class.
    /// Makes calling PAYNL Services easier and illiminates the need to fully initiate all Request objects.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Get Service Categories for a given payment option ID
        /// </summary>
        /// <param name="paymentOptionId">Payment Option ID</param>
        /// <returns>Response object containing service categories</returns>
        static public API.Service.GetCategories.Response GetCategories(IClient client, int? paymentOptionId = null)
        {
            var request = new ServiceGetCategories()
            {
                PaymentOptionId = paymentOptionId
            };

            client.PerformRequest(request);

            return request.Response;
        }
    }
}

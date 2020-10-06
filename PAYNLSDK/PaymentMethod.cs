using PAYNLSDK.Net;
using PaymentMethodGet = PAYNLSDK.API.PaymentMethod.Get.Request;
using PaymentMethodGetAll = PAYNLSDK.API.PaymentMethod.GetAll.Request;

namespace PAYNLSDK
{
    /// <summary>
    /// Generic Payment Method service helper class.
    /// Makes calling PAYNL Services easier and illiminates the need to fully initiate all Request objects.
    /// </summary>
    public class PaymentMethod
    {
        /// <summary>
        /// Get information for the requested payment method.
        /// </summary>
        /// <param name="paymentMethodId">Payment Method ID</param>
        /// <returns>Response containing the payment method data</returns>
        static public API.PaymentMethod.Get.Response Get(IClient client, int paymentMethodId)
        {
            var request = new PaymentMethodGet()
            {
                PaymentMethodId = paymentMethodId
            };

            client.PerformRequest(request);

            return request.Response;
        }

        /// <summary>
        /// Get information for all payment methods.
        /// </summary>
        /// <returns>Response containing a list of information for all payment methods</returns>
        static public API.PaymentMethod.GetAll.Response GetAll(IClient client)
        {
            var request = new PaymentMethodGetAll();
            
            client.PerformRequest(request);

            return request.Response;
        }
    }
}

using PAYNLSDK.Enums;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Net;
using System;
using TransactionGetService = PAYNLSDK.API.Transaction.GetService.Request;
using TransactionInfo = PAYNLSDK.API.Transaction.Info.Request;
using TransactionRefund = PAYNLSDK.API.Transaction.Refund.Request;
using TransactionApprove = PAYNLSDK.API.Transaction.Approve.Request;
using TransactionDecline = PAYNLSDK.API.Transaction.Decline.Request;
using Newtonsoft.Json;

namespace PAYNLSDK
{
    /// <summary>
    /// Generic Transaction service helper class.
    /// Makes calling PAYNL Services easier and illiminates the need to fully initiate all Request objects.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Checks whether a transaction has a status of PAID
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>True if PAID, false otherwise</returns>
        static public bool IsPaid(IClient client, string transactionId)
        {
            try
            {
                var request = new TransactionInfo()
                {
                    TransactionId = transactionId
                };

                client.PerformRequest(request);

                return IsPaid(request?.Response?.PaymentDetails?.State);
            }
            catch (ErrorException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a status is a PAID status
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if PAID, false otherwise</returns>
        static public bool IsPaid(PaymentStatus? status)
        {
            try
            {
                return status == PaymentStatus.PAID;
            }
            catch (ErrorException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a transaction has a status of CANCELLED
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>True if CANCELLED, false otherwise</returns>
        static public bool IsCancelled(IClient client, string transactionId)
        {
            try
            {
                var request = new TransactionInfo()
                {
                    TransactionId = transactionId
                };

                client.PerformRequest(request);

                return IsCancelled(request?.Response?.PaymentDetails?.State);
            }
            catch (ErrorException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a status is a CANCELLED status
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if CANCELLED, false otherwise</returns>
        static public bool IsCancelled(PaymentStatus? status)
        {
            try
            {
                return status == PaymentStatus.CANCEL;
            }
            catch (ErrorException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a transaction has a status of PENDING
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>True if PENDING, false otherwise</returns>
        static public bool IsPending(IClient client, string transactionId)
        {
            try
            {
                var request = new TransactionInfo()
                {
                    TransactionId = transactionId
                };

                client.PerformRequest(request);

                return IsPending(request?.Response?.PaymentDetails?.State)
                    || request?.Response?.PaymentDetails?.StateName == "PENDING";
            }
            catch (ErrorException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a status is a PENDING status
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if PENDING, false otherwise</returns>
        static public bool IsPending(PaymentStatus? status)
        {
            try
            {
                return status == PaymentStatus.PENDING_1
                    || status == PaymentStatus.PENDING_2
                    || status == PaymentStatus.PENDING_3
                    || status == PaymentStatus.VERIFY;
            }
            catch (ErrorException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a transaction has a status of VERIFY
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>True if VERIFY, false otherwise</returns>
        static public bool IsVerify(IClient client, string transactionId)
        {
            try
            {
                var request = new TransactionInfo()
                {
                    TransactionId = transactionId
                };

                client.PerformRequest(request);

                return IsVerify(request?.Response?.PaymentDetails?.State)
                    || request.Response.PaymentDetails.StateName == "VERIFY";
            }
            catch (ErrorException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a status is a VERIFY status
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if VERIFY, false otherwise</returns>
        static public bool IsVerify(PaymentStatus? status)
        {
            try
            {
                return status == PaymentStatus.VERIFY;
            }
            catch (ErrorException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a status is a REFUND or REFUNDING status
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if REFUND or REFUNDING, false otherwise</returns>
        static public bool IsRefund(PaymentStatus? status)
        {
            try
            {
                return status == PaymentStatus.REFUND
                    || IsRefunding(status);
            }
            catch (ErrorException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether a status is a REFUNDING status, meaning a refund is currently being processed.
        /// </summary>
        /// <param name="status">Transaction status</param>
        /// <returns>True if REFUNDING, false otherwise</returns>
        static public bool IsRefunding(PaymentStatus? status)
        {
            try
            {
                return status == PaymentStatus.REFUNDING;
            }
            catch (ErrorException)
            {
                return false;
            }
        }

        /// <summary>
        /// Query the service for all (current status) information on a transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <returns>Full response object with all information available</returns>
        static public API.Transaction.Info.Response Info(IClient client, string transactionId)
        {
            var request = new TransactionInfo()
            {
                TransactionId = transactionId
            };

            client.PerformRequest(request);

            return request.Response;
        }

        /// <summary>
        /// Return service information.
        /// This API returns merchant info and all the available payment options per country for a given service.
        /// This is an important API if you want to build your own payment screens.
        /// </summary>
        /// <param name="paymentMethodId">Paymentmethod ID</param>
        /// <returns>FUll response with all service information</returns>
        static public API.Transaction.GetService.Response GetService(IClient client, PaymentMethodId? paymentMethodId)
        {
            var request = new TransactionGetService()
            {
                PaymentMethodId = paymentMethodId
            };

            client.PerformRequest(request);

            return request.Response;
        }

        /// <summary>
        /// Return service information.
        /// This API returns merchant info and all the available payment options per country for a given service.
        /// This is an important API if you want to build your own payment screens.
        /// </summary>
        /// <returns>FUll response with all service information</returns>
        static public API.Transaction.GetService.Response GetService(IClient client)
            => GetService(client, null);

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <param name="description">Reason for the refund. May be null.</param>
        /// <param name="amount">Amount of the refund. If null is given, it will be the full amount of the transaction.</param>
        /// <param name="processDate">Date to process the refund. May be null.</param>
        /// <returns>Full response including the Refund ID</returns>
        static public API.Transaction.Refund.Response Refund(IClient client, string transactionId, string description, int? amount, DateTime? processDate)
        {
            var request = new TransactionRefund()
            {
                TransactionId = transactionId,
                Description = description,
                Amount = amount,
                ProcessDate = processDate
            };

            client.PerformRequest(request);

            return request.Response;
        }

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <param name="description">Reason for the refund. May be null.</param>
        /// <param name="amount">Amount of the refund. If null is given, it will be the full amount of the transaction.</param>
        /// <returns>Full response including the Refund ID</returns>
        static public API.Transaction.Refund.Response Refund(IClient client, string transactionId, string description, int? amount)
            => Refund(client, transactionId, description, amount, null);

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <param name="description">Reason for the refund. May be null.</param>
        /// <returns>Full response including the Refund ID</returns>
        static public API.Transaction.Refund.Response Refund(IClient client, string transactionId, string description)
            => Refund(client, transactionId, description, null);

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction.
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <returns>Full response including the Refund ID</returns>
        static public API.Transaction.Refund.Response Refund(IClient client, string transactionId)
            => Refund(client, transactionId, null);

        /// <summary>
        /// Performs a (partial) refund call on an existing transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <param name="description">Reason for the refund. May be null.</param>
        /// <param name="amount">Amount of the refund. If null is given, it will be the full amount of the transaction.</param>
        /// <param name="processDate">Date to process the refund. May be null.</param>
        /// <param name="exchangeUrl">The url to send notifications to on changes in this refund.</param>
        /// <returns>Full response including the Refund ID</returns>
        static public API.Transaction.Refund.Response Refund(IClient client, string transactionId, string description, int? amount, DateTime? processDate, string exchangeUrl)
        {
            // Unable to reuse existing method for refunding,  since this specific case needs to be done with different Request 
            // API.Transaction.Refund.Request vs. API.Refund.Transaction.Request (already existing in code, we simply use this here)
            var request = new API.Refund.Transaction.Request(transactionId)
            {
                TransactionId = transactionId,
                Description = description,
                Amount = amount,
                ProcessDate = processDate,
                ExchangeUrl = exchangeUrl
            };

            client.PerformRequest(request);

            // We will convert the response to a PAYNLSDK.API.Transaction.Refund.Response so we stay in the same, original, namespace.
            // We manage to get away with this because the API responses have the same definition.
            return JsonConvert.DeserializeObject<API.Transaction.Refund.Response>(request.RawResponse);
        }

        /// <summary>
        /// function to approve a suspicious transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <returns>Full response including the message about the approvement</returns>
        static public API.Transaction.Approve.Response Approve(IClient client, string transactionId)
        {
            var request = new TransactionApprove()
            {
                TransactionId = transactionId
            };

            client.PerformRequest(request);

            return request.Response;
        }

        /// <summary>
        /// function to decline a suspicious transaction
        /// </summary>
        /// <param name="transactionId">Transaction ID</param>
        /// <returns>Full response including the message about the decline</returns>
        static public API.Transaction.Decline.Response Decline(IClient client, string transactionId)
        {
            var request = new TransactionDecline()
            {
                TransactionId = transactionId
            };

            client.PerformRequest(request);

            return request.Response;
        }


        /// <summary>
        /// Creates a transaction start request.
        /// </summary>
        /// <param name="ipAddress">The IP address of the customer</param>
        /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
        /// <param name="paymentOptionId">	The ID of the payment option (for iDEAL use 10).</param>
        /// <param name="paymentSubOptionId">	In case of an iDEAL payment this is the ID of the bank (see the paymentOptionSubList in the getService function).</param>
        /// <param name="testMode">	Whether or not we perform this call in test mode.</param>
        /// <param name="transferType">TransferType for this transaction (merchant/transaction)</param>
        /// <param name="transferValue">TransferValue eg MerchantId (M-xxxx-xxxx) or orderId</param>
        /// <returns>Transaction Start Request</returns>
        static public API.Transaction.Start.Request CreateTransactionRequest(string ipAddress, string returnUrl, int? paymentOptionId, string paymentSubOptionId, bool? testMode, string transferType, string transferValue)
            => new API.Transaction.Start.Request()
            {
                Amount = 0,
                IPAddress = ipAddress,
                ReturnUrl = returnUrl,
                PaymentOptionId = paymentOptionId,
                PaymentOptionSubId = paymentSubOptionId,
                TestMode = testMode,
                TransferType = transferType,
                TransferValue = transferValue
            };

        /// <summary>
        /// Creates a transaction start request.
        /// </summary>
        /// <param name="ipAddress">The IP address of the customer</param>
        /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
        /// <param name="paymentOptionId">	The ID of the payment option (for iDEAL use 10).</param>
        /// <param name="paymentSubOptionId">	In case of an iDEAL payment this is the ID of the bank (see the paymentOptionSubList in the getService function).</param>
        /// <param name="testMode">	Whether or not we perform this call in test mode.</param>
        /// <param name="transferType">TransferType for this transaction (merchant/transaction)</param>
        /// <param name="transferValue">TransferValue eg MerchantId (M-xxxx-xxxx) or orderId</param>
        /// <returns>Transaction Start Request</returns>
        static public API.Transaction.Start.Request CreateTransactionRequest(string ipAddress, string returnUrl, int? paymentOptionId, int? paymentSubOptionId, bool? testMode, string transferType, string transferValue)
            => new API.Transaction.Start.Request()
            {
                Amount = 0,
                IPAddress = ipAddress,
                ReturnUrl = returnUrl,
                PaymentOptionId = paymentOptionId,
                PaymentOptionSubId = paymentSubOptionId.ToString(),
                TestMode = testMode,
                TransferType = transferType,
                TransferValue = transferValue
            };

        /// <summary>
        /// Creates a transaction start request.
        /// </summary>
        /// <param name="ipAddress">The IP address of the customer</param>
        /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
        /// <param name="paymentOptionId">	The ID of the payment option (for iDEAL use 10).</param>
        /// <param name="paymentSubOptionId">	In case of an iDEAL payment this is the ID of the bank (see the paymentOptionSubList in the getService function).</param>
        /// <param name="testMode">	Whether or not we perform this call in test mode.</param>
        /// <returns>Transaction Start Request</returns>
        static public API.Transaction.Start.Request CreateTransactionRequest(string ipAddress, string returnUrl, int? paymentOptionId, string paymentSubOptionId, bool? testMode)
            => new API.Transaction.Start.Request()
            {
                Amount = 0,
                IPAddress = ipAddress,
                ReturnUrl = returnUrl,
                PaymentOptionId = paymentOptionId,
                PaymentOptionSubId = paymentSubOptionId,
                TestMode = testMode
            };

        /// <summary>
        /// Creates a transaction start request.
        /// </summary>
        /// <param name="ipAddress">The IP address of the customer</param>
        /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
        /// <param name="paymentOptionId">	The ID of the payment option (for iDEAL use 10).</param>
        /// <param name="paymentSubOptionId">	In case of an iDEAL payment this is the ID of the bank (see the paymentOptionSubList in the getService function).</param>
        /// <param name="testMode">	Whether or not we perform this call in test mode.</param>
        /// <returns>Transaction Start Request</returns>
        static public API.Transaction.Start.Request CreateTransactionRequest(string ipAddress, string returnUrl, int? paymentOptionId, int? paymentSubOptionId, bool? testMode = false)
            => new API.Transaction.Start.Request()
            {
                Amount = 0,
                IPAddress = ipAddress,
                ReturnUrl = returnUrl,
                PaymentOptionId = paymentOptionId,
                PaymentOptionSubId = paymentSubOptionId.ToString(),
                TestMode = testMode
            };

        /// <summary>
        /// Creates a transaction start request.
        /// 
        /// Test Mode will be defaulted to FALSE.
        /// </summary>
        /// <param name="ipAddress">The IP address of the customer</param>
        /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
        /// <param name="paymentOptionId">	The ID of the payment option (for iDEAL use 10).</param>
        /// <returns>Transaction Start Request</returns>
        static public API.Transaction.Start.Request CreateTransactionRequest(string ipAddress, string returnUrl, int paymentOptionId, bool? testMode = false)
            => CreateTransactionRequest(ipAddress, returnUrl, paymentOptionId, "", testMode);

        /// <summary>
        /// Creates a transaction start request.
        /// 
        /// Test Mode will be defaulted to FALSE.
        /// </summary>
        /// <param name="ipAddress">The IP address of the customer</param>
        /// <param name="returnUrl">The URL where the customer has to be send to after the payment.</param>
        /// <returns>Transaction Start Request</returns>
        static public API.Transaction.Start.Request CreateTransactionRequest(string ipAddress, string returnUrl, bool? testMode = false)
            => CreateTransactionRequest(ipAddress, returnUrl, null, "", testMode);

        /// <summary>
        /// Performs a request to start a transaction.
        /// </summary>
        /// <returns>Full response object including Transaction ID</returns>
        static public API.Transaction.Start.Response Start(IClient client, API.Transaction.Start.Request request)
        {
            client.PerformRequest(request);

            return request.Response;
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

using PAYNLSDK.Enums;
using PAYNLSDK.Net;

using DirectDebitInfo = PAYNLSDK.API.DirectDebit.Info.Request;
using MandateAdd = PAYNLSDK.API.DirectDebit.MandateAdd.Request;
using MandateDebit = PAYNLSDK.API.DirectDebit.MandateDebit.Request;
using RecurringAdd = PAYNLSDK.API.DirectDebit.RecurringAdd.Request;

namespace PAYNLSDK
{
    public class DirectDebit
    {
        static public async Task<API.DirectDebit.Info.Response> InfoAsync(IClient client, string mandateId,
            string referenceId = null, CancellationToken cancellationToken = default)
        {
            var request = new DirectDebitInfo(mandateId)
            {
                ReferenceId = referenceId
            };

            await client.PerformRequestAsync(request, cancellationToken).ConfigureAwait(false);

            return request.Response;
        }

        static public async Task<API.DirectDebit.MandateDebit.Response> MandateDebitAsync(IClient client, string mandateId,
            int? amount, string description = null, DateTime? processDate = null, bool? last = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MandateDebit(mandateId)
            {
                Amount = amount,
                Description = description,
                ProcessDate = processDate,
                Last = last,
            };

            await client.PerformRequestAsync(request, cancellationToken).ConfigureAwait(false);

            return request.Response;
        }

        static public async Task<API.DirectDebit.MandateAdd.Response> MandateAddAsync(
            IClient client,
            int amount,
            string bankaccountHolder,
            string bankaccountNumber,
            string bankaccountBic = null,
            DateTime? processDate = null,
            string description = null,
            string currency = null,
            string exchangeUrl = null,
            string ipAddress = null,
            string email = null,
            int? promotorId = null,
            string tool = null,
            string info = null,
            string objectData = null,
            string extra1 = null,
            string extra2 = null,
            string extra3 = null,
            CancellationToken cancellationToken = default)
        {
            var request = new MandateAdd(amount, bankaccountHolder, bankaccountNumber)
            {
                BankaccountBic = bankaccountBic,
                ProcessDate = processDate,
                Description = description,
                Currency = currency,
                ExchangeUrl = exchangeUrl,
                IpAddress = ipAddress,
                Email = email,
                PromotorId = promotorId,
                Tool = tool,
                Info = info,
                Object = objectData,
                Extra1 = extra1,
                Extra2 = extra2,
                Extra3 = extra3
            };

            await client.PerformRequestAsync(request, cancellationToken).ConfigureAwait(false);

            return request.Response;
        }

        static public async Task<API.DirectDebit.RecurringAdd.Response> RecurringAddAsync(
            IClient client,
            int amount,
            string bankaccountHolder,
            string bankaccountNumber,
            int intervalValue,
            MandateInterval intervalPeriod,
            string bankaccountBic = null,
            DateTime? processDate = null,
            string description = null,
            string currency = null,
            string exchangeUrl = null,
            string ipAddress = null,
            string email = null,
            int? promotorId = null,
            string tool = null,
            string info = null,
            string objectData = null,
            string extra1 = null,
            string extra2 = null,
            string extra3 = null,
            CancellationToken cancellationToken = default)
        {
            var request = new RecurringAdd(amount, bankaccountHolder, bankaccountNumber, intervalValue, intervalPeriod)
            {
                BankaccountBic = bankaccountBic,
                ProcessDate = processDate,
                Description = description,
                Currency = currency,
                ExchangeUrl = exchangeUrl,
                IpAddress = ipAddress,
                Email = email,
                PromotorId = promotorId,
                Tool = tool,
                Info = info,
                Object = objectData,
                Extra1 = extra1,
                Extra2 = extra2,
                Extra3 = extra3
            };

            await client.PerformRequestAsync(request, cancellationToken).ConfigureAwait(false);

            return request.Response;
        }
    }
}
using System;
using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Converters;
using PAYNLSDK.Enums;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.DirectDebit.RecurringAdd
{
    public class Request : RequestBase<Response>
    {
        public override int Version { get { return 3; } }

        public override string Controller { get { return "DirectDebit"; } }

        public override string Method { get { return "recurringAdd"; } }

        public override bool RequiresApiToken
        {
            get { return true; }
        }
        public override bool RequiresServiceId
        {
            get { return true; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public int Amount { get; set; }
        public string BankaccountHolder { get; set; } // Client name
        public string BankaccountNumber { get; set; } // IBAN
        /// <summary>
        /// Every 'IntervalValue' 'IntervalPeriod's (e.g. every 2 weeks)
        /// </summary>
        /// <value></value>
        public int IntervalValue { get; set; }
        [JsonProperty("intervalPeriod"), JsonConverter(typeof(MandateIntervalConverter))]
        public MandateInterval IntervalPeriod { get; set; }

        public int? IntervalQuantity { get; set; }
        public string BankaccountBic { get; set; }
        // [JsonProperty("processDate"), JsonConverter(typeof(DMYConverter))]
        public DateTime? ProcessDate { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; } //TODO: .NET currency?
        public string ExchangeUrl { get; set; }
        public string IpAddress { get; set; }
        public string Email { get; set; }
        public int? PromotorId { get; set; }
        public string Tool { get; set; }
        public string Info { get; set; }
        public string Object { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }

        public Request(int amount, string bankaccountHolder, string bankaccountNumber,
            int intervalValue, MandateInterval intervalPeriod)
        {
            this.Amount = amount;
            this.BankaccountHolder = bankaccountHolder;
            this.BankaccountNumber = bankaccountNumber;
            this.IntervalValue = intervalValue;
            this.IntervalPeriod = intervalPeriod;
        }

        public override NameValueCollection GetParameters(string serviceId)
        {
            var parameters = base.GetParameters(serviceId);

            ParameterValidator.IsNotNull(Amount, "Amount");
            parameters.Add("amount", Amount.ToString());

            ParameterValidator.IsNotNull(BankaccountHolder, "BankaccountHolder");
            parameters.Add("bankaccountHolder", BankaccountHolder);

            ParameterValidator.IsNotNull(BankaccountNumber, "BankaccountNumber");
            parameters.Add("bankaccountNumber", BankaccountNumber);

            ParameterValidator.IsNotNull(IntervalValue, "IntervalValue");
            parameters.Add("intervalValue", IntervalValue.ToString());

            ParameterValidator.IsNotNull(IntervalPeriod, "IntervalPeriod");
            parameters.Add("intervalPeriod", IntervalPeriod.ToEnumString());

            if (!ParameterValidator.IsEmpty(BankaccountBic))
                parameters.Add("bankaccountBic", BankaccountBic);

            if (!ParameterValidator.IsNull(ProcessDate))
                parameters.Add("processDate", ProcessDate.Value.ToString("dd-MM-yyyy"));

            if (!ParameterValidator.IsEmpty(Description))
                parameters.Add("description", Description);

            if (!ParameterValidator.IsEmpty(Currency))
                parameters.Add("currency", Currency);

            if (!ParameterValidator.IsEmpty(ExchangeUrl))
                parameters.Add("exchangeUrl", ExchangeUrl);

            if (!ParameterValidator.IsEmpty(IpAddress))
                parameters.Add("ipAddress", IpAddress);

            if (!ParameterValidator.IsEmpty(Email))
                parameters.Add("email", Email);

            if (ParameterValidator.IsNonEmptyInt(PromotorId))
                parameters.Add("promotorId", PromotorId.ToString());

            if (!ParameterValidator.IsEmpty(Tool))
                parameters.Add("tool", Tool);

            if (!ParameterValidator.IsEmpty(Info))
                parameters.Add("info", Info);

            if (!ParameterValidator.IsEmpty(Object))
                parameters.Add("object", Object);

            if (!ParameterValidator.IsEmpty(Extra1))
                parameters.Add("extra1", Extra1);

            if (!ParameterValidator.IsEmpty(Extra2))
                parameters.Add("extra2", Extra2);

            if (!ParameterValidator.IsEmpty(Extra3))
                parameters.Add("extra3", Extra3);

            return parameters;
        }
    }
}
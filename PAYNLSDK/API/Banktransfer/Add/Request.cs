﻿using System;
using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Banktransfer.Add
{
    public class Request : RequestBase
    {
        public Request(int amount, string bankAccountHolder, string bankAccountNumber, string bankAccountBic)
        {
            this.Amount = amount;
            this.BankAccountHolder = bankAccountHolder;
            this.BankAccountNumber = bankAccountNumber;
            this.BankAccountBic = bankAccountBic;
        }

        /// <summary>
        /// The amount to be paid should be given in cents. For example € 3.50 becomes 350.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// The name of the customer.
        /// </summary>
        public string BankAccountHolder { get; set; }

        /// <summary>
        /// The bankaccount number of the customer.
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// The BIC of the bank.
        /// </summary>
        public string BankAccountBic { get; set; }

        /// <summary>
        /// The description to include with the payment.
        /// </summary>
        public string Description { get; set; }

        ///<summary>
        /// The id of a promotor / affiliate.
        /// In general, you won't use this unless you know the ID's of your affiliate's
        /// </summary>
        public int? PromotorId { get; set; }

        /// <summary>
        /// The used tool code.
        /// </summary>
        public string Tool { get; set; }

        /// <summary>
        /// The used info code which can be tracked in the stats
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// The used object.
        /// </summary>
        public string Object { get; set; }

        /// <summary>
        /// The first free value which can be tracked in the stats
        /// </summary>
        public string Extra1 { get; set; }

        /// <summary>
        /// The second free value which can be tracked in the stats
        /// </summary>
        public string Extra2 { get; set; }

        /// <summary>
        /// The third free value which can be tracked in the stats
        /// </summary>
        public string Extra3 { get; set; }

        /// <summary>
        /// The currency of the amount, default is EUR.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// The currency of the amount, default is EUR.
        /// </summary>
        public DateTime? ProcessDate { get; set; }

        public override int Version
        {
            get { return 1; }
        }

        public override string Controller
        {
            get { return "Banktransfer"; }
        }

        public override string Method
        {
            get { return "add"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override bool RequiresApiToken
        {
            get { return true; }
        }
        public override bool RequiresServiceId
        {
            get { return true; }
        }

        public override NameValueCollection GetParameters(string serviceId)
        {
            var parameters = base.GetParameters(serviceId);

            ParameterValidator.IsNotNull(Amount, "Amount");
            parameters.Add("amount", Amount.ToString());

            ParameterValidator.IsNotNull(BankAccountHolder, "BankAccountHolder");
            parameters.Add("bankAccountHolder", BankAccountHolder);

            ParameterValidator.IsNotNull(BankAccountNumber, "BankAccountNumber");
            parameters.Add("bankAccountNumber", BankAccountNumber);

            ParameterValidator.IsNotNull(BankAccountBic, "BankAccountBic");
            parameters.Add("bankAccountBic", BankAccountBic);

            if (!ParameterValidator.IsEmpty(Description))
                parameters.Add("description", Description);

            if (!ParameterValidator.IsNonEmptyInt(PromotorId))
                parameters.Add("promotorId", PromotorId.Value.ToString());

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

            if (!ParameterValidator.IsEmpty(Currency))
                parameters.Add("currency", Currency);

            if (ProcessDate.HasValue)
                parameters.Add("processDate", this.ProcessDate.Value.ToString("yyyy-MM-dd"));

            return parameters;
        }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new ErrorException("rawResponse is empty!");
            }
            response = JsonConvert.DeserializeObject<Response>(RawResponse);
            if (!Response.Request.Result)
            {
                // toss
                throw new ErrorException(Response.Request.Message);
            }
        }

        public Response Response { get { return (Response)response; } }
    }
}

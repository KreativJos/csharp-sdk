using System;
using System.Collections.Specialized;

using Newtonsoft.Json;

using PAYNLSDK.Enums;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Objects;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.Transaction.Start
{
    public class Request : RequestBase
    {
        public override bool RequiresApiToken
        {
            get { return true; }
        }
        public override bool RequiresServiceId
        {
            get { return true; }
        }

        public int Amount { get; set; }
        public string IPAddress { get; set; }
        public string ReturnUrl { get; set; }
        public int? PaymentOptionId { get; set; }
        public string PaymentOptionSubId { get; set; }
        public bool? TestMode { get; set; }
        public string TransferType { get; set; }
        public string TransferValue { get; set; }

        public TransactionData Transaction { get; set; }
        public StatsDetails StatsData { get; set; }
        public EndUser Enduser { get; set; }
        public SalesData SalesData { get; set; }

        public override int Version
        {
            get { return 5; }
        }

        public override string Controller
        {
            get { return "Transaction"; }
        }

        public override string Method
        {
            get { return "start"; }
        }

        public override string Querystring
        {
            get { return ""; }
        }

        public override NameValueCollection GetParameters(string apiToken, string serviceId)
        {
            var parameters = base.GetParameters(apiToken, serviceId);

            // Basic params
            ParameterValidator.IsNotNull(Amount, "Amount");
            parameters.Add("amount", Amount.ToString());

            ParameterValidator.IsNotNull(IPAddress, "IPAddress");
            parameters.Add("ipAddress", IPAddress);

            ParameterValidator.IsNotNull(ReturnUrl, "ReturnUrl");
            parameters.Add("finishUrl", ReturnUrl);

            if (ParameterValidator.IsNonEmptyInt(PaymentOptionId))
                parameters.Add("paymentOptionId", PaymentOptionId.ToString());


            if (!ParameterValidator.IsEmpty(PaymentOptionSubId))
                parameters.Add("paymentOptionSubId", PaymentOptionSubId.ToString());

            if (!ParameterValidator.IsEmpty(TransferValue))
            {
                if (TransferType == "transaction" || TransferType == "merchant")
                {
                    parameters.Add("transferType", TransferType);
                    parameters.Add("transferValue", TransferValue);
                }
                else
                {
                    throw new Exception("TransferValue cannot be set, without valid TransferType, please fix this.");
                }
            }

            // Transaction
            if (Transaction != null)
            {
                if (!ParameterValidator.IsNull(Transaction.Currency))
                    parameters.Add("transaction[currency]", Transaction.Currency);

                if (ParameterValidator.IsNonEmptyInt(Transaction.CostsVat))
                    parameters.Add("transaction[costsVat]", Transaction.CostsVat.ToString());

                // TODO: exclude cost?
                if (!ParameterValidator.IsEmpty(Transaction.OrderExchangeUrl))
                    parameters.Add("transaction[orderExchangeUrl]", Transaction.OrderExchangeUrl);

                if (!ParameterValidator.IsEmpty(Transaction.Description))
                    parameters.Add("transaction[description]", Transaction.Description);

                // if (!ParameterValidator.IsNonEmptyInt(Transaction.EnduserId))
                //     parameters.Add("transaction[enduserId]", Transaction.EnduserId.ToString());

                if (!ParameterValidator.IsNull(Transaction.ExpireDate))
                    parameters.Add("transaction[expireDate]", ((DateTime)Transaction.ExpireDate).ToString("dd-MM-yyyy hh:mm:ss"));

                // TODO: Are these right? SHouldn't this be BOOL / INT?
                // if (!ParameterValidator.IsEmpty(Transaction.SendReminderEmail))
                //     parameters.Add("transaction[sendReminderEmail]", Transaction.SendReminderEmail);

                // if (!ParameterValidator.IsEmpty(Transaction.ReminderMailTemplateId))
                //     parameters.Add("transaction[reminderMailTemplateId]", Transaction.ReminderMailTemplateId);

                if (!ParameterValidator.IsNull(Transaction.OrderNumber))
                    parameters.Add("transaction[orderNumber]", Transaction.OrderNumber);
            }

            // StatsData
            if (StatsData != null)
            {
                if (ParameterValidator.IsNonEmptyInt(StatsData.PromotorId))
                    parameters.Add("statsData[promotorId]", StatsData.PromotorId.ToString());

                if (!ParameterValidator.IsEmpty(StatsData.Info))
                    parameters.Add("statsData[info]", StatsData.Info);

                if (!ParameterValidator.IsEmpty(StatsData.Tool))
                    parameters.Add("statsData[tool]", StatsData.Tool);

                if (!ParameterValidator.IsEmpty(StatsData.Extra1))
                    parameters.Add("statsData[extra1]", StatsData.Extra1);

                if (!ParameterValidator.IsEmpty(StatsData.Extra2))
                    parameters.Add("statsData[extra2]", StatsData.Extra2);

                if (!ParameterValidator.IsEmpty(StatsData.Extra3))
                    parameters.Add("statsData[extra3]", StatsData.Extra3);

                //if (!ParameterValidator.IsEmpty(StatsData.TransferData))
                //    parameters.Add("statsData[transferData]", StatsData.TransferData);
            }

            // End user
            if (Enduser != null)
            {
                // if (!ParameterValidator.IsEmpty(Enduser.AccessCode))
                //     parameters.Add("enduser[accessCode]", Enduser.AccessCode);

                if (!ParameterValidator.IsEmpty(Enduser.Language))
                    parameters.Add("enduser[language]", Enduser.Language);

                if (!ParameterValidator.IsEmpty(Enduser.Initials))
                    parameters.Add("enduser[initials]", Enduser.Initials);

                if (!ParameterValidator.IsEmpty(Enduser.Lastname))
                    parameters.Add("enduser[lastName]", Enduser.Lastname);

                if (!ParameterValidator.IsNull(Enduser.Gender))
                    parameters.Add("enduser[gender]", EnumUtil.ToEnumString((Gender)Enduser.Gender));

                if (!ParameterValidator.IsNull(Enduser.BirthDate))
                    parameters.Add("enduser[dob]", ((DateTime)Enduser.BirthDate).ToString("dd-MM-yyyy"));

                if (!ParameterValidator.IsEmpty(Enduser.PhoneNumber))
                    parameters.Add("enduser[phoneNumber]", Enduser.PhoneNumber);

                if (!ParameterValidator.IsEmpty(Enduser.EmailAddress))
                    parameters.Add("enduser[emailAddress]", Enduser.EmailAddress);

                if (!ParameterValidator.IsEmpty(Enduser.BankAccount))
                    parameters.Add("enduser[bankAccount]", Enduser.BankAccount);

                if (!ParameterValidator.IsEmpty(Enduser.IBAN))
                    parameters.Add("enduser[iban]", Enduser.IBAN);

                // if (!ParameterValidator.IsNull(Enduser.SendConfirmMail))
                //     parameters.Add("enduser[sendConfirmMail]", ((bool)Enduser.SendConfirmMail) ? "1" : "0");

                // if (!ParameterValidator.IsEmpty(Enduser.ConfirmMailTemplate))
                //     parameters.Add("enduser[confirmMailTemplate]", Enduser.ConfirmMailTemplate);

                if (!ParameterValidator.IsEmpty(Enduser.CustomerReference))
                    parameters.Add("enduser[customerReference]", Enduser.CustomerReference);

                // Address
                if (Enduser.Address != null)
                {
                    if (!ParameterValidator.IsEmpty(Enduser.Address.StreetName))
                        parameters.Add("enduser[address][streetName]", Enduser.Address.StreetName);

                    if (!ParameterValidator.IsEmpty(Enduser.Address.StreetNumber))
                        parameters.Add("enduser[address][streetNumber]", Enduser.Address.StreetNumber);

                    if (!ParameterValidator.IsEmpty(Enduser.Address.ZipCode))
                        parameters.Add("enduser[address][zipCode]", Enduser.Address.ZipCode);

                    if (!ParameterValidator.IsEmpty(Enduser.Address.City))
                        parameters.Add("enduser[address][city]", Enduser.Address.City);

                    if (!ParameterValidator.IsEmpty(Enduser.Address.CountryCode))
                        parameters.Add("enduser[address][countryCode]", Enduser.Address.CountryCode);
                }

                // InvoiceAddress
                if (Enduser.InvoiceAddress != null)
                {
                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.Initials))
                        parameters.Add("enduser[invoiceAddress][initials]", Enduser.InvoiceAddress.Initials);

                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.LastName))
                        parameters.Add("enduser[invoiceAddress][lastName]", Enduser.InvoiceAddress.LastName);

                    if (!ParameterValidator.IsNull(Enduser.InvoiceAddress.Gender))
                    {
                        string gender = EnumUtil.ToEnumString((Gender)Enduser.InvoiceAddress.Gender);

                        parameters.Add("enduser[invoiceAddress][gender]", gender);
                    }

                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.StreetName))
                        parameters.Add("enduser[invoiceAddress][streetName]", Enduser.InvoiceAddress.StreetName);

                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.StreetNumber))
                        parameters.Add("enduser[invoiceAddress][streetNumber]", Enduser.InvoiceAddress.StreetNumber);

                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.ZipCode))
                        parameters.Add("enduser[invoiceAddress][zipCode]", Enduser.InvoiceAddress.ZipCode);

                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.City))
                        parameters.Add("enduser[invoiceAddress][city]", Enduser.InvoiceAddress.City);

                    if (!ParameterValidator.IsEmpty(Enduser.InvoiceAddress.CountryCode))
                        parameters.Add("enduser[invoiceAddress][countryCode]", Enduser.InvoiceAddress.CountryCode);
                }

                //Company info
                if (Enduser.Company != null)
                {
                    if (!ParameterValidator.IsEmpty(Enduser.Company.CocNumber))
                        parameters.Add("enduser[company][cocNumber]", Enduser.Company.CocNumber);

                    if (!ParameterValidator.IsEmpty(Enduser.Company.CountryCode))
                        parameters.Add("enduser[company][countryCode]", Enduser.Company.CountryCode);

                    if (!ParameterValidator.IsEmpty(Enduser.Company.Name))
                        parameters.Add("enduser[company][name]", Enduser.Company.Name);

                    if (!ParameterValidator.IsEmpty(Enduser.Company.VatNumber))
                        parameters.Add("enduser[company][vatNumber]", Enduser.Company.VatNumber);
                }
            }

            // SaleData
            if (SalesData != null)
            {
                if (!ParameterValidator.IsNull(SalesData.DeliveryDate))
                    parameters.Add("saleData[deliveryDate]", SalesData.DeliveryDate.ToString("dd-MM-yyyy"));

                if (!ParameterValidator.IsNull(SalesData.InvoiceDate))
                    parameters.Add("saleData[invoiceDate]", SalesData.InvoiceDate.ToString("dd-MM-yyyy"));

                if (!ParameterValidator.IsNull(SalesData.OrderData))
                {
                    int i = 0;

                    foreach (OrderData data in SalesData.OrderData)
                    {
                        ParameterValidator.IsNotNull(data.ProductId, "SalesData.OrderData.ProductId");
                        parameters.Add(string.Format("saleData[orderData][{0}][productId]", i), data.ProductId);

                        if (!ParameterValidator.IsNull(data.Description))
                            parameters.Add(string.Format("saleData[orderData][{0}][description]", i), data.Description);

                        ParameterValidator.IsNotNull(data.Price, "SalesData.OrderData.Price");
                        parameters.Add(string.Format("saleData[orderData][{0}][price]", i), data.Price.ToString());

                        ParameterValidator.IsNotNull(data.Quantity, "SalesData.OrderData.Quantity");
                        parameters.Add(string.Format("saleData[orderData][{0}][quantity]", i), data.Quantity.ToString());

                        if (!ParameterValidator.IsNull(data.VatCode))
                            parameters.Add(string.Format("saleData[orderData][{0}][vatCode]", i), EnumUtil.ToEnumString(data.VatCode));

                        if (!ParameterValidator.IsNull(data.ProductType))
                            parameters.Add(string.Format("saleData[orderData][{0}][productType]", i), EnumUtil.ToEnumString(data.ProductType));

                        i++;
                    }
                }
            }

            // TestMode
            if (!ParameterValidator.IsNull(TestMode))
                parameters.Add("testMode", ((bool)TestMode) ? "1" : "0");

            return parameters;
        }

        public Response Response { get { return (Response)response; } }

        public override void SetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
                throw new ErrorException("rawResponse is empty!");

            response = JsonConvert.DeserializeObject<Response>(RawResponse);

            if (!Response.Request.Result)
                throw new ErrorException(Response.Request.Message);
        }
    }
}

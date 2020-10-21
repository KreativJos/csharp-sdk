using Newtonsoft.Json;
using PAYNLFormsApp.Fixtures;
using PAYNLSDK;
using PAYNLSDK.API;
using PAYNLSDK.Enums;
using PAYNLSDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace PAYNLFormsApp
{
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {

        }

        public void dumpPaymentmethods()
        {
            ClearDebug();
            PAYNLSDK.API.PaymentMethod.GetAll.Request request = new PAYNLSDK.API.PaymentMethod.GetAll.Request();
            InitRequestDebug(request);
            APISettings.Client.PerformRequest(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
        }

        public async void dumpTransactionGetService()
        {
            ClearDebug();
            PAYNLSDK.API.Transaction.GetService.Request request = new PAYNLSDK.API.Transaction.GetService.Request();
            InitRequestDebug(request);
            await APISettings.Client.PerformRequestAsync(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();

        }

        public void dumpTransactionGetLast()
        {
            ClearDebug();
            PAYNLSDK.API.Transaction.GetLastTransactions.Request request = new PAYNLSDK.API.Transaction.GetLastTransactions.Request();
            InitRequestDebug(request);
            APISettings.Client.PerformRequest(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
        }


        public void Approve(string transactionID)
        {

            try
            {

                ClearDebug();

                if (transactionID == "")
                {
                    AddDebug("foutieve invoer");
                    AddDebug("transactionID mag niet leeg zijn");
                }
                else
                {
                    PAYNLSDK.API.Transaction.Approve.Request request = new PAYNLSDK.API.Transaction.Approve.Request();
                    request.TransactionId = transactionID;

                    InitRequestDebug(request);

                    APISettings.Client.PerformRequest(request);
                    DebugRawResponse(request);
                    tbMain.Text = request.Response.Message.ToString();
                }

            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }

        }

        public void Decline(string transactionID)
        {
            try
            {

                ClearDebug();

                if (transactionID == "")
                {
                    AddDebug("foutieve invoer");
                    AddDebug("transactionID mag niet leeg zijn");
                }
                else
                {
                    PAYNLSDK.API.Transaction.Decline.Request request = new PAYNLSDK.API.Transaction.Decline.Request();
                    request.TransactionId = transactionID;

                    InitRequestDebug(request);

                    APISettings.Client.PerformRequest(request);
                    DebugRawResponse(request);


                    tbMain.Text = request.Response.Message.ToString();

                }

            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }

        }

        public void TransactionRefund(string transactionID, string amount, string exchangeUrl)
        {
            try
            {

                ClearDebug();

                int numValue;
                bool parsed = int.TryParse(amount, out numValue);
                if (!parsed || transactionID == "")
                {
                    if (!parsed)
                    {

                        AddDebug("foutieve invoer");
                        AddDebug("amount: only numbers. 3,40 must be filled in as 350");


                    }
                    AddDebug("foutieve invoer");
                    AddDebug("transactionID mag niet leeg zijn");

                }

                else if (exchangeUrl != "")
                {
                    AddDebug("-----");
                    AddDebug("Working with modified version of call");

                    PAYNLSDK.API.Transaction.Refund.Response response = Transaction.Refund(APISettings.Client, transactionID, null, numValue, null, exchangeUrl);

                    tbMain.Text = response.RefundId;
                }

                else
                {

                    PAYNLSDK.API.Transaction.Refund.Request request = new PAYNLSDK.API.Transaction.Refund.Request();
                    request.Amount = numValue;
                    request.TransactionId = transactionID;

                    InitRequestDebug(request);

                    APISettings.Client.PerformRequest(request);
                    DebugRawResponse(request);

                    tbMain.Text = request.Response.RefundId;
                }


            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }

        }

        public void RefundAdd(string bankAccountName, string bankAccountNumber, string amount)
        {

            try
            {
                ClearDebug();

                int numValue;
                bool parsed = int.TryParse(amount, out numValue);
                if (!parsed)
                {

                    AddDebug("foutieve invoer");
                    AddDebug("amount: numbers. 3,40 must be filled in as 350");

                }
                else
                {

                    PAYNLSDK.API.Refund.Add.Request request = new PAYNLSDK.API.Refund.Add.Request(numValue, bankAccountName, bankAccountNumber, "");
                    InitRequestDebug(request);

                    APISettings.Client.PerformRequest(request);
                    DebugRawResponse(request);


                    tbMain.Text = request.Response.RefundId;
                }


            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        public void TransactionRefundInfo(string refundID)
        {

            try
            {
                ClearDebug();

                PAYNLSDK.API.Refund.Info.Request request = new PAYNLSDK.API.Refund.Info.Request(refundID);
                InitRequestDebug(request);

                APISettings.Client.PerformRequest(request);
                DebugRawResponse(request);


                tbMain.Text = request.Response.ToString();


            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        public async void DirectDebit_MandateInfo(string mandateId, string referenceId = null)
        {
            try
            {
                ClearDebug();

                PAYNLSDK.API.DirectDebit.Info.Request request = new PAYNLSDK.API.DirectDebit.Info.Request(mandateId)
                {
                    ReferenceId = referenceId
                };

                InitRequestDebug(request);

                await APISettings.Client.PerformRequestAsync(request);
                DebugRawResponse(request);

                tbMain.Text = request.Response.ToString();
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        public async void DirectDebit_MandateDebit(string mandateId, int? amount, string description = null, DateTime? processDate = null, bool? last = null)
        {
            try
            {
                ClearDebug();

                PAYNLSDK.API.DirectDebit.MandateDebit.Request request = new PAYNLSDK.API.DirectDebit.MandateDebit.Request(mandateId)
                {
                    Amount = amount,
                    Description = description,
                    ProcessDate = processDate,
                    Last = last,
                };

                InitRequestDebug(request);

                await APISettings.Client.PerformRequestAsync(request);
                DebugRawResponse(request);

                tbMain.Text = request.Response.ToString();
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        public async void DirectDebit_MandateRecurringAdd(int amount,
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
            string extra3 = null)
        {
            try
            {
                ClearDebug();

                PAYNLSDK.API.DirectDebit.RecurringAdd.Request request =
                    new PAYNLSDK.API.DirectDebit.RecurringAdd.Request(amount, bankaccountHolder, bankaccountNumber, intervalValue, intervalPeriod)
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

                InitRequestDebug(request);

                await APISettings.Client.PerformRequestAsync(request);
                DebugRawResponse(request);

                tbMain.Text = request.Response.ToString();
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        public async void DirectDebit_MandateAdd(int amount,
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
            string extra3 = null)
        {
            try
            {
                ClearDebug();

                PAYNLSDK.API.DirectDebit.MandateAdd.Request request =
                    new PAYNLSDK.API.DirectDebit.MandateAdd.Request(amount, bankaccountHolder, bankaccountNumber)
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

                InitRequestDebug(request);

                await APISettings.Client.PerformRequestAsync(request);
                DebugRawResponse(request);

                tbMain.Text = request.Response.ToString();
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        // help function
        private void ClearDebug()
        {
            tbDebug.Text = "";
        }

        private void AddDebug(string value)
        {
            if (tbDebug.Text.Length == 0)
                tbDebug.Text = value;
            else
                tbDebug.AppendText(System.Environment.NewLine + value);
        }
        private void InitRequestDebug(RequestBaseBase request)
        {
            AddDebug(string.Format("Calling API {0} / {1}", request.Controller, request.Method));
            AddDebug(string.Format("Requires TOKEN? {0}", request.RequiresApiToken));
            AddDebug(string.Format("Requires SERVICEID? {0}", request.RequiresServiceId));
            AddDebug("-----");
            AddDebug("Initializing...");
            AddDebug(string.Format("URL    : {0}", request.Url));
            AddDebug(string.Format("PARAMS : {0}", request.ToQueryString(APISettings.ServiceID)));
            AddDebug("-----");
        }
        private void DebugRawResponse(RequestBaseBase request)
        {
            AddDebug("RAW Result from PAYNL");
            AddDebug(request.RawResponse);
        }
    }
}

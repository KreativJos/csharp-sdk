﻿using Newtonsoft.Json;
using PAYNLFormsApp.Fixtures;
using PAYNLSDK;
using PAYNLSDK.API;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void payNLAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void validationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new ValidationForm()).ShowDialog();
        }

        private void dumpPaymentmethodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugForm form = new DebugForm();
            form.dumpPaymentmethods();
            form.ShowDialog();

        }

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
        private void InitRequestDebug(RequestBase request)
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
        private void DebugRawResponse(RequestBase request)
        {
            AddDebug("RAW Result from PAYNL");
            AddDebug(request.RawResponse);
        }

        private void dumpTransactionGetServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DebugForm form = new DebugForm();
            form.dumpTransactionGetService();
            form.ShowDialog();


        }

        private void dumpTransactionGetLastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebugForm form = new DebugForm();
            form.dumpTransactionGetLast();
            form.ShowDialog();
        }

        private async void txinfo(string id)
        {
            //619204633Xc4027e
            ClearDebug();
            PAYNLSDK.API.Transaction.Info.Request request = new PAYNLSDK.API.Transaction.Info.Request();
            request.TransactionId = id;
            InitRequestDebug(request);
            await APISettings.Client.PerformRequestAsync(request);//.PerformRequest(request);
            DebugRawResponse(request);
            tbMain.Text = request.Response.ToString();
        }

        private void xc4027ePAIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txinfo("619204633Xc4027e");
        }

        private void xc5b75dPAIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txinfo("611642851Xc5b75d");
        }

        private void xd83303CANCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txinfo("618847570Xd83303");
        }

        private void transActionStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDebug();
            PAYNLSDK.API.Transaction.Start.Request fixture = TransactionStart.GetFixture();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            AddDebug("PARAMS:");
            AddDebug(fixture.ToQueryString(APISettings.ServiceID));
            AddDebug("-----");
            AddDebug("DONE");
        }

        private void transactionStartproductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDebug();
            PAYNLSDK.API.Transaction.Start.Request fixture = TransactionStart.GetFixtureNoProductLines();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            AddDebug("PARAMS:");
            string qs = fixture.ToQueryString(APISettings.ServiceID);
            AddDebug(qs);
            var parameters = HttpUtility.ParseQueryString(qs);
            // string json = JsonConvert.SerializeObject(parametersToDictionary(parameters, true));
            AddDebug("-----");
            //AddDebug("PARAMS AS JSON");
            //AddDebug(json);
            Dumpparameters(parameters);
            AddDebug("-----");
            AddDebug("DONE");
        }

        void Dumpparameters(NameValueCollection parameters)
        {
            foreach (string key in parameters.Keys)
            {
                string[] values = parameters.GetValues(key);
                foreach (string value in parameters.GetValues(key))
                {
                    AddDebug(string.Format("'{0}' : '{1}'", key, value));
                }
            }
        }

        private Dictionary<string, object> parametersToDictionary(NameValueCollection parameters, bool handleMultipleValuesPerKey)
        {
            var result = new Dictionary<string, object>();
            foreach (string key in parameters.Keys)
            {
                if (handleMultipleValuesPerKey)
                {
                    string[] values = parameters.GetValues(key);
                    if (values.Length == 1)
                    {
                        result.Add(key, values[0]);
                    }
                    else
                    {
                        result.Add(key, values);
                    }
                }
                else
                {
                    result.Add(key, parameters[key]);
                }
            }

            return result;
        }

        private async void startuseFixtureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDebug();
                PAYNLSDK.API.Transaction.Start.Request fixture = TransactionStart.GetFixtureNoProductLines();
                InitRequestDebug(fixture);
                Dumpparameters(fixture.GetParameters(APISettings.ServiceID));

                await APISettings.Client.PerformRequestAsync(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();

                string url = fixture.Response.Transaction.PaymentURL;
                OpenUrl(url);
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }

        }

        private static void OpenUrl(string url)
        {
            var process = new System.Diagnostics.Process();

            process.StartInfo.UseShellExecute = true;

            var browser = System.Environment.GetEnvironmentVariable("URL_BROWSER");

            if (browser is not null)
            {
                process.StartInfo.FileName = browser;
                process.StartInfo.ArgumentList.Add(url);
            }
            else
            {
                process.StartInfo.FileName = url;
            }

            try
            {
                process.Start();
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Linux))
                {
                    System.Diagnostics.Process.Start("xdg-open", url);
                }
                else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
                {
                    System.Diagnostics.Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void startuseFixtureEditableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTransaction frm = new StartTransaction();
            frm.FormClosed += frm_FormClosed;
            frm.ShowDialog();
        }



        private async void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (!StartTransaction.OK)
                {
                    ClearDebug();
                    AddDebug("CANCELLED!");
                    return;
                }

                ClearDebug();
                PAYNLSDK.API.Transaction.Start.Request fixture = LastRequests.LastTransactionStart;
                InitRequestDebug(fixture);
                Dumpparameters(fixture.GetParameters(APISettings.ServiceID));

                await APISettings.Client.PerformRequestAsync(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();

                string url = fixture.Response.Transaction.PaymentURL;
                OpenUrl(url);
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            AddDebug(PAYNLSDK.Enums.Util.ToEnumString<PAYNLSDK.Enums.TaxClass>(PAYNLSDK.Enums.TaxClass.High));
            AddDebug(PAYNLSDK.Enums.Util.ToEnumString(PAYNLSDK.Enums.TaxClass.High, typeof(PAYNLSDK.Enums.TaxClass)));

            string ser = @"{'gender':'m'}";
            X x = JsonConvert.DeserializeObject<X>(ser);
            AddDebug(JsonConvert.SerializeObject(x));
            */
        }

        private async void paymentProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDebug();
                PAYNLSDK.API.PaymentProfile.GetAll.Request fixture = new PAYNLSDK.API.PaymentProfile.GetAll.Request();
                InitRequestDebug(fixture);
                Dumpparameters(fixture.GetParameters(APISettings.ServiceID));

                await APISettings.Client.PerformRequestAsync(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        private async void serviceCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ClearDebug();
                PAYNLSDK.API.Service.GetCategories.Request fixture = new PAYNLSDK.API.Service.GetCategories.Request();
                InitRequestDebug(fixture);
                Dumpparameters(fixture.GetParameters(APISettings.ServiceID));

                await APISettings.Client.PerformRequestAsync(fixture);
                DebugRawResponse(fixture);
                tbMain.Text = fixture.Response.ToString();
            }
            catch (ErrorException ee)
            {
                AddDebug("~~EXCEPTION~~");
                AddDebug(ee.Message);
            }
        }

        private void approveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ApproveDecline form = new ApproveDecline();
            form.ShowDialog();

        }

        private void declineToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ApproveDecline form = new ApproveDecline();
            form.ShowDialog();


        }

        private void refundAddToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RefundAdd form = new RefundAdd();
            form.ShowDialog();

        }

        private void refundToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TransactionRefund form = new TransactionRefund();
            form.ShowDialog();

        }

        private void testDateTimeConversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] ymdtests = {
                                 // YMD
                                 @"{dt: '2018-1-1'}",
                                 @"{dt: '2018-5-10'}",
                                 @"{dt: '2018-12-11'}",
                                 @"{dt: '2018-12-1'}",
                                 @"{dt: '2018/1/1'}",
                                 @"{dt: '2018/5/10'}",
                                 @"{dt: '2018/12/11'}",
                                 @"{dt: '2018/12/1'}"
                                };
            string[] dmytests = {
                                 // DMY
                                 @"{dt: '1-1-2-2018'}",
                                 @"{dt: '10-5-2018'}",
                                 @"{dt: '11-23-2018'}",
                                 @"{dt: '1-12-2018'}",
                                 @"{dt: '1/1/2/2018'}",
                                 @"{dt: '10/5/2018'}",
                                 @"{dt: '11/23/2018'}",
                                 @"{dt: '1/12/2018'}"
                                };
            string[] ymdhistests = {
                                 // YMDHIS
                                 @"{dt: '2018-1-1 12:11'}",
                                 @"{dt: '2018-1-1 9:11'}",
                                 @"{dt: '2018-1-1 11:9'}",
                                 @"{dt: '2018-5-10 12:11:01'}",
                                 @"{dt: '2018-12-11 9:9:1'}",
                                 @"{dt: '2018-12-1 9:9:10'}",
                                 @"{dt: '2018-12-1 09:9:10'}",
                                 @"{dt: '2018-12-1 9:09:10'}",
                                 @"{dt: '2018/1/1 12:11'}",
                                 @"{dt: '2018/1/1 9:11'}",
                                 @"{dt: '2018/1/1 11:9'}",
                                 @"{dt: '2018/5/10 12:11:01'}",
                                 @"{dt: '2018/12/11 9:9:1'}",
                                 @"{dt: '2018/12/1 9:9:10'}",
                                 @"{dt: '2018/12/1 09:9:10'}",
                                 @"{dt: '2018/12/1 9:09:10'}"
                            };


            foreach (string dateString in ymdtests)
            {
                try
                {
                    TestYMD testObj = JsonConvert.DeserializeObject<TestYMD>(dateString);
                    AddDebug(string.Format("Converted '{0}' to {1}.", dateString, testObj.DT.ToString()));
                }
                catch (Exception e0)
                {
                    AddDebug(string.Format("Error converting '{0}' using YMD.", dateString));
                    AddDebug(e0.Message);
                }
            }
            foreach (string dateString in dmytests)
            {
                try
                {
                    TestDMY testObj = JsonConvert.DeserializeObject<TestDMY>(dateString);
                    AddDebug(string.Format("Converted '{0}' to {1}.", dateString, testObj.DT.ToString()));
                }
                catch (Exception e1)
                {
                    AddDebug(string.Format("Error converting '{0}' using YMD.", dateString));
                    AddDebug(e1.Message);
                }
            }
            foreach (string dateString in ymdhistests)
            {
                try
                {
                    TestYMDHIS testObj = JsonConvert.DeserializeObject<TestYMDHIS>(dateString);
                    AddDebug(string.Format("Converted '{0}' to {1}.", dateString, testObj.DT.ToString()));
                }
                catch (Exception e2)
                {
                    AddDebug(string.Format("Error converting '{0}' using YMD.", dateString));
                    AddDebug(e2.Message);
                }
            }

        }

        private void refundtransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDebug();
            PAYNLSDK.API.Refund.Transaction.Request fixture = RefundTransaction.GetFixtureNoProductLines();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            AddDebug("PARAMS:");
            string qs = fixture.ToQueryString(APISettings.ServiceID);
            AddDebug(qs);
            var parameters = HttpUtility.ParseQueryString(qs);
            // string json = JsonConvert.SerializeObject(parametersToDictionary(parameters, true));
            AddDebug("-----");
            //AddDebug("PARAMS AS JSON");
            //AddDebug(json);
            Dumpparameters(parameters);
            AddDebug("-----");
            AddDebug("DONE");
        }

        private void refundTrasactionProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDebug();
            PAYNLSDK.API.Refund.Transaction.Request fixture = RefundTransaction.GetFixture();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(fixture.ToString());
            AddDebug("PARAMS:");
            string qs = fixture.ToQueryString(APISettings.ServiceID);
            AddDebug(qs);
            var parameters = HttpUtility.ParseQueryString(qs);
            // string json = JsonConvert.SerializeObject(parametersToDictionary(parameters, true));
            AddDebug("-----");
            //AddDebug("PARAMS AS JSON");
            //AddDebug(json);
            Dumpparameters(parameters);
            AddDebug("-----");
            AddDebug("DONE");
        }

        private void transactionRefundInofromJsonFixtureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDebug();
            string json = TransactionRefundInfo.GetJsonFixture();
            PAYNLSDK.Objects.RefundInfo fixture = TransactionRefundInfo.GetRefundInfoFixture();
            AddDebug("Fixture loaded.");
            AddDebug("JSON:");
            AddDebug(json);
            AddDebug("-----");
            AddDebug(fixture.ToString());
            AddDebug("-----");
            AddDebug("DONE");
        }

        private void mandateRecurringAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new MandateRecurringAddForm();
            form.ShowDialog();
        }

        private void mandateAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new MandateAddForm();
            form.ShowDialog();
        }

        private void mandateDebitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new MandateDebitForm();
            form.ShowDialog();
        }

        private void mandateInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new MandateInfoForm();
            form.ShowDialog();
        }

        private void refundInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefundInfo form = new RefundInfo();
            form.ShowDialog();
        }
        /*
        class X
        {
            [JsonProperty("gender"), JsonConverter(typeof(PAYNLSDK.Converters.GenderConverter))]
            public PAYNLSDK.Enums.Gender Gender { get; set; }

        }
         */
    }

    public class TestYMD
    {
        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonProperty("dt"), JsonConverter(typeof(PAYNLSDK.Converters.YMDConverter))]
        public DateTime? DT { get; set; }

    }
    public class TestDMY
    {
        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonProperty("dt"), JsonConverter(typeof(PAYNLSDK.Converters.DMYConverter))]
        public DateTime? DT { get; set; }

    }
    public class TestYMDHIS
    {
        /// <summary>
        /// Merchant ID
        /// </summary>
        [JsonProperty("dt"), JsonConverter(typeof(PAYNLSDK.Converters.YMDHISConverter))]
        public DateTime? DT { get; set; }

    }
}

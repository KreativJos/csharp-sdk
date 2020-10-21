using System;
using System.Collections.Specialized;

using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.DirectDebit.MandateDebit
{
    public class Request : RequestBase<Response>
    {
        public override int Version { get { return 3; } }

        public override string Controller { get { return "DirectDebit"; } }

        public override string Method { get { return "mandateDebit"; } }

        public override string Querystring { get { return ""; } }

        public string MandateId { get; set; }
        public int? Amount { get; set; }
        public string Description { get; set; }
        public DateTime? ProcessDate { get; set; }
        public bool? Last { get; set; }

        public Request(string mandateId)
        {
            this.MandateId = mandateId;
        }

        public override NameValueCollection GetParameters(string serviceId)
        {
            var parameters = base.GetParameters(serviceId);

            ParameterValidator.IsNotNull(MandateId, "MandateId");
            parameters.Add("mandateId", MandateId);

            if (!ParameterValidator.IsNull(Amount))
                parameters.Add("amount", Amount.ToString());

            if (!ParameterValidator.IsEmpty(Description))
                parameters.Add("description", Description);

            if (!ParameterValidator.IsNull(ProcessDate))
                parameters.Add("processDate", ProcessDate.Value.ToString("dd-MM-yyyy"));

            if (!ParameterValidator.IsNull(Last))
                parameters.Add("last", Last.Value.ToString());

            return parameters;
        }
    }
}
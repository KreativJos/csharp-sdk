using System.Collections.Specialized;
using PAYNLSDK.Utilities;

namespace PAYNLSDK.API.DirectDebit.Info
{
    public class Request : RequestBase<Response>
    {
        public override int Version { get { return 3; } }

        public override string Controller { get { return "DirectDebit"; } }

        public override string Method { get { return "info"; } }

        public override string Querystring { get { return ""; } }

        public string MandateId { get; set; }
        public string ReferenceId { get; set; }

        public Request(string mandateId)
        {
            this.MandateId = mandateId;
        }

        public override NameValueCollection GetParameters(string serviceId)
        {
            var parameters = base.GetParameters(serviceId);

            ParameterValidator.IsNotNull(MandateId, "MandateId");
            parameters.Add("mandateId", MandateId);

            if (!ParameterValidator.IsEmpty(ReferenceId))
                parameters.Add("referenceId", ReferenceId);

            return parameters;
        }
    }
}
using PAYNLSDK.Enums;

namespace PAYNLSDK.API.DirectDebit.MandateDebit
{
    public class Response : ResponseBase
    {
        public DirectDebitErrorCode? ErrorCode { get { return Request?.Code?.ToEnum<DirectDebitErrorCode>(); } }
    }
}
using System;

using PAYNLSDK.Enums;

namespace PAYNLSDK.Objects
{
    public class DirectDebit
    {
        public string ReferenceId { get; set; }
        public string BankaccountNumber { get; set; }
        public string BankaccountOwner { get; set; }
        public string BankaccountBic { get; set; }
        public string PaymentSessionId { get; set; }

        public int Amount { get; set; }
        public string Description { get; set; }
        public DateTime? SendDate { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public DirectDebitStatus? StatusCode { get; set; }
        public string StatusName { get; set; }
        public DirectDebitDeclineCode? DeclineCode { get; set; }
        public string DeclineName { get; set; }
        public DateTime? DeclineDate { get; set; }
    }
}
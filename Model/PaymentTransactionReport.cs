namespace ReportingService.Model
{
    public class PaymentTransactionReportFilter
    {
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }

        public string? PaymentEnquiryId { get; set; }
        public string? PaymentId { get; set; }
        public string? PaymentTransactionId { get; set; }
        public string? PaymentStatus { get; set; }
        public string? BankingSystem { get; set; }
        public string? Currency { get; set; }
    }

    public class PaymentTransactionReport
    {
        public string? PaymentEnquiryId { get; set; }

        public string? PaymentId { get; set; }

        public string? PaymentTransactionId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? PaymentStatus { get; set; }

        public string? BankingSystem { get; set; }

        public decimal? Amount { get; set; }

        public string? Currency { get; set; }
    }
}
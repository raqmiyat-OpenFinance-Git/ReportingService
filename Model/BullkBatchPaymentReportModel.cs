namespace ReportingService.Model
{


    public class BullkBatchPaymentReportFilter
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public string? PaymentStatus { get; set; }
        public string? RequestStatus { get; set; }

        public string? ConsentId { get; set; }
        public string? TppId { get; set; }

        public string? PaymentType { get; set; }
    }

    public class BullkBatchPaymentReport
    {
        public long BulkPaymentRequestId { get; set; }
        public long BulkPaymentConsentId { get; set; }
        public string? ConsentId { get; set; }
        public Guid CorrelationId { get; set; }
        public string? O3ProviderId { get; set; }
        public string? O3AspspId { get; set; }
        public string? TppName { get; set; }
        public string? TppID { get; set; }
        public string? O3CallerSoftwareStatementId { get; set; }
        public string? O3ApiUri { get; set; }
        public string? O3ApiOperation { get; set; }
        public string? O3ConsentId { get; set; }
        public string? O3CallerInteractionId { get; set; }
       public string? O3OzoneInteractionId { get; set; }
        public string? O3PsuIdentifier { get; set; }
        public string? FileType { get; set; }
        public string? FileHash { get; set; }
        public string? FileReference { get; set; }
        public int NumberOfTransactions { get; set; }
        public decimal ControlSum { get; set; }
        public DateTime RequestedExecutionDate { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? RequestPayload { get; set; }
        public long? BulkPaymentTransactionId { get; set; }
        public int? SerialNo { get; set; }
        public long? TransactionBulkPaymentRequestId { get; set; }
        public string? TransactionReference { get; set; }
        public string? PaymentReference { get; set; }
        public string? ExternalReference { get; set; }
        public decimal? Amount { get; set; }
        public string? Currency { get; set; }
        public string? CreditorName { get; set; }
        public string? CreditorAccountNumber { get; set; }
        public string? CreditorBankCode { get; set; }
        public string? DebtorName { get; set; }
        public string? DebtorAccountNumber { get; set; }
        public string? DebtorBankCode { get; set; }
        public string? PurposeCode { get; set; }
        public string? RemittanceInfo { get; set; }
        public string? CreditorAccountType { get; set; }
        public string? PaymentChannel { get; set; }
        public DateTime? ValueDate { get; set; }
        public string? TransactionStatus { get; set; }
        public string? PostingStatus { get; set; }
        public string? TransactionCreatedBy { get; set; }
        public DateTime? TransactionCreatedOn { get; set; }
        public string? TransactionModifiedBy { get; set; }
        public DateTime? TransactionModifiedOn { get; set; }
        public string? TransactionRequestPayload { get; set; }
    }





}

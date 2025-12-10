namespace ReportingService.Model
{
    public class RefundTransactionsReportFilter
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? PaymentStatus { get; set; }
        public string? RequestStatus { get; set; }
        public string? PaymentType { get; set; }
        public string? ConsentId { get; set; }
        public string? TppId { get; set; }
    }
    public class RefundTransactionsReport
    {
        // Request Info
        public long RequestId { get; set; }
        public Guid CorrelationId { get; set; }
        public string? PaymentCategory { get; set; }
        public string? PaymentType { get; set; }
        public string? ConsentId { get; set; }

        // Open Finance / Ozone Metadata
        public string? O3ProviderId { get; set; }
        public string? O3AspspId { get; set; }
        public string? O3CallerOrgId { get; set; }
        public string? O3CallerClientId { get; set; }
        public string? O3CallerSoftwareStatementId { get; set; }
        public string? O3ApiUri { get; set; }
        public string? O3ApiOperation { get; set; }
        public string? O3ConsentId { get; set; }
        public string? O3CallerInteractionId { get; set; }
        public string? O3OzoneInteractionId { get; set; }
        public string? O3PsuIdentifier { get; set; }

        // Transaction Instruction
        public decimal? InstructionAmount { get; set; }
        public string? InstructionCurrency { get; set; }
        public string? PaymentPurposeCode { get; set; }
        public string? DebtorReference { get; set; }
        public string? CreditorReference { get; set; }
        public string? InstructionPriority { get; set; }

        // Billing / VRP
        public string? OpenFinanceBillingType { get; set; }
        public string? OpenFinanceBillingMerchantId { get; set; }

        // Request Audit
        public string? Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }

        // Response Info
        public long? ResponseId { get; set; }
        public string? ExternalId { get; set; }
        public string? PaymentTransactionId { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime? StatusUpdateDateTime { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public string? RejectReasonCode { get; set; }
        public string? RejectReasonMessage { get; set; }

        // Charges
        public string? ChargeBearer { get; set; }
        public string? ChargesType { get; set; }
        public decimal? ChargesAmount { get; set; }
        public string? ChargesCurrency { get; set; }

        // Billing / Paging
        public int? BillingNumberOfSuccessTxn { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        // Response Audit
        public DateTime? ResponseCreatedOn { get; set; }
        public DateTime? ResponseModifiedOn { get; set; }
    }
}

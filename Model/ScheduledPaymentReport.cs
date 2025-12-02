namespace ReportingService.Model
{
    public class ScheduledPaymentReportFilter
    {
        public string? O3ProviderId { get; set; }
        public string? AccountId { get; set; }
        public string? ScheduledPaymentId { get; set; }
        public string? AccountHolderName { get; set; }
        public string? ScheduledType { get; set; }
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
    }
    public class ScheduledPaymentReport
    {
        // Common
        public long? RequestId { get; set; }
        public long? ResponseId { get; set; }
        public Guid? CorrelationId { get; set; }

        // Request Fields
        public int? Page { get; set; }
        public int? PageSize { get; set; }
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
        public string? RequestAccountId { get; set; }
        public string? RequestStatus { get; set; }
        public string? RequestCreatedBy { get; set; }
        public DateTime? RequestCreatedOn { get; set; }
        public string? RequestModifiedBy { get; set; }
        public DateTime? RequestModifiedOn { get; set; }

        // Response Fields
        public string? AccountId { get; set; }
        public string? ScheduledPaymentId { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountHolderShortName { get; set; }
        public string? ScheduledType { get; set; }
        public DateTime? ScheduledPaymentDateTime { get; set; }
        public string? CreditorReference { get; set; }
        public string? DebtorReference { get; set; }
        public decimal? InstructedAmount { get; set; }
        public string? Currency { get; set; }

        public string? CreditorAgentSchemeName { get; set; }
        public string? CreditorAgentId { get; set; }
        public string? CreditorAccountSchemeName { get; set; }
        public string? CreditorAccountId { get; set; }

        public decimal? TotalPages { get; set; }
        public decimal? TotalRecords { get; set; }
        public string? ResponseStatus { get; set; }
        public string? ResponseCreatedBy { get; set; }
        public DateTime? ResponseCreatedOn { get; set; }
        public string? ResponseModifiedBy { get; set; }
        public DateTime? ResponseModifiedOn { get; set; }

    }

}

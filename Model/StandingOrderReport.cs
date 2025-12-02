namespace ReportingService.Model
{

    public class StandingOrderReportFilter
    {
        public string? O3ProviderId { get; set; }
        public string? AccountId { get; set; }
        public string? StandingOrderId { get; set; }
        public string? AccountHolderName { get; set; }
        public string? StandingOrderType { get; set; }
        public string? Frequency { get; set; }
        public string? StandingOrderStatusCode { get; set; }
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
    }


    public class StandingOrderReport
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
        public string? StandingOrderId { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountHolderShortName { get; set; }
        public string? StandingOrderType { get; set; }
        public string? Frequency { get; set; }
        public string? CreditorReference { get; set; }
        public string? Purpose { get; set; }
        public string? FirstPaymentDateTime { get; set; }
        public string? NextPaymentDateTime { get; set; }
        public string? LastPaymentDateTime { get; set; }
        public string? FinalPaymentDateTime { get; set; }
        public string? NumberOfPayments { get; set; }
        public string? StandingOrderStatusCode { get; set; }
        public string? FirstPaymentAmount { get; set; }
        public string? FirstPaymentCurrency { get; set; }
        public string? NextPaymentAmount { get; set; }
        public string? NextPaymentCurrency { get; set; }
        public string? LastPaymentAmount { get; set; }
        public string? LastPaymentCurrency { get; set; }
        public string? FinalPaymentAmount { get; set; }
        public string? FinalPaymentCurrency { get; set; }

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

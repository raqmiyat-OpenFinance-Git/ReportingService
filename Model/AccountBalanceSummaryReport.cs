namespace ReportingService.Model
{
    public class AccountBalanceSummaryReportFilter
    {
        public string? O3ProviderId { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountId { get; set; }
        public string? Currency { get; set; }
        public string? AccountStatus { get; set; }
        public DateTime? CreatedFrom { get; set; }
        public DateTime? CreatedTo { get; set; }
    }

    public class AccountBalanceSummaryReport
    {
        // Request Fields
        public int? RequestId { get; set; }
        public Guid? CorrelationId { get; set; } = Guid.Empty;
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? O3ProviderId { get; set; }
        public string? O3AspspId { get; set; }
        public string? O3CallerOrgId { get; set; }
        public string? O3CallerClientId { get; set; }
        public string? O3CallerSoftwareStatementId { get; set; }
        public string? O3ApiUri { get; set; }
        public string? O3ApiOperation { get; set; }
        public string? O3CallerInteractionId { get; set; }
        public string? O3OzoneInteractionId { get; set; }
        public string? O3PsuIdentifier { get; set; }
        public string? RequestAccountId { get; set; }
        public string? RequestType { get; set; }
        public string? RequestStatus { get; set; }
        public string? RequestCreatedBy { get; set; }
        public DateTime? RequestCreatedOn { get; set; }
        public string? RequestModifiedBy { get; set; }
        public DateTime? RequestModifiedOn { get; set; }

        // Response Fields
        public int? ResponseId { get; set; }
        public string? AccountId { get; set; }
        public string? AccountType { get; set; }
        public string? AccountSubType { get; set; }
        public string? Currency { get; set; }
        public string? AccountStatus { get; set; }
        public string? AccountHolderName { get; set; }
        public string? AccountHolderShortName { get; set; }
        public string? ProductName { get; set; }
        public string? BundleName { get; set; }
        public string? MultiAuth { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? BusinessCustomerId { get; set; }
        public string? BusinessCustomerName { get; set; }
        public DateTime? StatusUpdateDateTime { get; set; }
        public string? Description { get; set; }
        public string? NickName { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? MaturityDate { get; set; }
        public bool? IsShariahCompliant { get; set; }
        public int? TotalPages { get; set; }
        public int? TotalRecords { get; set; }
        public string? ResponseType { get; set; }
        public string? ResponseStatus { get; set; }
        public string? ResponseCreatedBy { get; set; }
        public DateTime? ResponseCreatedOn { get; set; }
        public string? ResponseModifiedBy { get; set; }
        public DateTime? ResponseModifiedOn { get; set; }
    }


}

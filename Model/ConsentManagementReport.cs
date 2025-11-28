namespace ReportingService.Model
{

    public class ConsentReportQuery
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? ConsentId { get; set; }
        public string? Status { get; set; }
        public string? ConsentType { get; set; }
        public string? TppId { get; set; }

    }

    public class ConsentManagementReport
    {
        public int? Id { get; set; }
        public string? ConsentId { get; set; }
        public string? ConsentType { get; set; }
        public string? Status { get; set; }
        public string? Permission { get; set; }
        public string? TppName { get; set; }
        public string? TppId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        public DateTime? TransactionFromDateTime { get; set; }
        public DateTime? TransactionToDateTime { get; set; }

        // New fields
        public string? Type { get; set; }
        public string? BaseConsentId { get; set; }
        public string? AccountType { get; set; }
        public string? AccountSubType { get; set; }
        public string? OnBehalfOfTradingName { get; set; }
        public string? OnBehalfOfLegalName { get; set; }
        public string? OnBehalfOfIdentifierType { get; set; }
        public string? OnBehalfOfIdentifier { get; set; }
        public string? OpenFinanceBillingUserType { get; set; }
        public string? OpenFinanceBillingPurpose { get; set; }
        public string? WebhookUrl { get; set; }
        public bool? WebhookIsActive { get; set; }
        public string? ResponseId { get; set; }
        public string? ParId { get; set; }
        public string? RarType { get; set; }
        public string? StandardVersion { get; set; }
        public string? ConsentGroupId { get; set; }
        public string? RequestUrl { get; set; }
        public string? ResponseStatus { get; set; }
        public string? InteractionId { get; set; }
        public string? TppClientId { get; set; }
        public string? SoftwareStatementId { get; set; }
        public string? DirectoryRecord { get; set; }
        public string? OrgId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }


}

namespace ReportingService.Model
{

    //public class FutureDatePaymentsReportFilter
    //{
    //    public DateTime? FromDate { get; set; }
    //    public DateTime? ToDate { get; set; }
    //    public string? PaymentStatus { get; set; }
    //    public string? RequestStatus { get; set; }
    //    public string? ConsentId { get; set; }
    //    public string? TppId { get; set; }
    //}

    //public class FutureDatePaymentsReport
    //{
    //    // Request
    //   // public long RequestId { get; set; }
    //    public Guid CorrelationId { get; set; }
    //    public string? PaymentCategory { get; set; }
    //    public string? PaymentType { get; set; }
    //    public string? ConsentId { get; set; }
    //    public string? O3ProviderId { get; set; }
    //    public string? O3AspspId { get; set; }
    //    public string? O3CallerOrgId { get; set; }
    //    public string? O3CallerClientId { get; set; }
    //    public string? O3CallerSoftwareStatementId { get; set; }
    //    public string? O3ApiUri { get; set; }
    //    public string? O3ApiOperation { get; set; }
    //    public string? O3ConsentId { get; set; }
    //    public string? O3CallerInteractionId { get; set; }
    //    public string? O3OzoneInteractionId { get; set; }
    //    public string? O3PsuIdentifier { get; set; }

    //    public decimal? InstructionAmount { get; set; }
    //    public string? InstructionCurrency { get; set; }
    //    public string? PaymentPurposeCode { get; set; }
    //    public string? DebtorReference { get; set; }
    //    public string? CreditorReference { get; set; }
    //    public string? InstructionPriority { get; set; }
    //    public string? OpenFinanceBillingType { get; set; }
    //    public string? OpenFinanceBillingMerchantId { get; set; }

    //    public string? Status { get; set; }
    //    public DateTime CreatedOn { get; set; }
    //    public DateTime? ModifiedOn { get; set; }
    //    public string? CreatedBy { get; set; }
    //    public string? ModifiedBy { get; set; }

    //    public long? ResponseId { get; set; }
    //    public string? ExternalId { get; set; }
    //    public string? PaymentTransactionId { get; set; }
    //    public string? PaymentStatus { get; set; }
    //    public DateTime? StatusUpdateDateTime { get; set; }
    //    public DateTime? CreationDateTime { get; set; }
    //    public string? RejectReasonCode { get; set; }
    //    public string? RejectReasonMessage { get; set; }
    //    public string? ChargeBearer { get; set; }
    //    public string? ChargesType { get; set; }
    //    public decimal? ChargesAmount { get; set; }
    //    public string? ChargesCurrency { get; set; }

    //    public int? BillingNumberOfSuccessTxn { get; set; }
    //    public int? Page { get; set; }
    //    public int? PageSize { get; set; }

    //    public DateTime? ResponseCreatedOn { get; set; }
    //    public DateTime? ResponseModifiedOn { get; set; }
    //}

    public class FutureDatePaymentsReportModel
    {
        public List<ReportTemplate>? ModulesList { get; set; }

        public string? ConsentType { get; set; }

        public string? ReportName { get; set; }

        public FutureDatePaymentsReportFilter? FutureDatePaymentsReportFilter { get; set; }
            = new FutureDatePaymentsReportFilter();

        public List<FutureDatePaymentsReport>? futureDatePaymentsReport { get; set; }
            = new List<FutureDatePaymentsReport>();

        public List<TemplateList>? templateLists { get; set; }

        public FutureDatePaymentsReportFilter? FutureDatePaymentsReportField { get; set; }
    }


    public class FutureDatePaymentsReportFilter
    {
        public DateTime? FromDate { get; set; } = DateTime.Today;

        public DateTime? ToDate { get; set; } = DateTime.Today;

        public string? PaymentStatus { get; set; }

        public string? RequestStatus { get; set; }

        public string? ConsentId { get; set; }

        public string? TppId { get; set; }

        // Dynamic Report fields
        public string? Columndetails { get; set; }

        public string? TemplateName { get; set; }

        public string? ReportName { get; set; }
    }


    public class FutureDatePaymentsReport
    {
        public DateTime? FromDate { get; set; }

        public DateTime? Todate { get; set; }

        public string? Columndetails { get; set; }

        public string? TemplateName { get; set; }

        public string? ReportName { get; set; }

        public string? FutureDatePaymentsBody { get; set; }

        // Request
        public Guid CorrelationId { get; set; }

        public string? PaymentCategory { get; set; }

        public string? PaymentType { get; set; }

        public string? ConsentId { get; set; }

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

        public decimal? InstructionAmount { get; set; }

        public string? InstructionCurrency { get; set; }

        public string? PaymentPurposeCode { get; set; }

        public string? DebtorReference { get; set; }

        public string? CreditorReference { get; set; }

        public string? InstructionPriority { get; set; }

        public string? OpenFinanceBillingType { get; set; }

        public string? OpenFinanceBillingMerchantId { get; set; }

        public string? Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        // Response
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

        public int? BillingNumberOfSuccessTxn { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }

        // Response Audit
        public DateTime? ResponseCreatedOn { get; set; }

        public DateTime? ResponseModifiedOn { get; set; }
    }
}

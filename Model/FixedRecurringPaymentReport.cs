namespace ReportingService.Model
{

    //public class FixedRecurringPaymentReportFilter
    //{
    //    public DateTime? FromDate { get; set; }
    //    public DateTime? ToDate { get; set; }
    //    public string? PaymentStatus { get; set; }
    //    public string? RequestStatus { get; set; }
    //    public string? ConsentId { get; set; }
    //    public string? TppId { get; set; }
    //    public string? PaymentType { get; set; }
    //}
    //public class FixedRecurringPaymentReport
    //{
    //    // Request
    // //   public long PaymentRequestId { get; set; }
    //    public string? PaymentConsentId { get; set; }
    //    public string? PaymentCategory { get; set; }
    //    public string? PaymentType { get; set; }
    //    public Guid CorrelationId { get; set; }
    //    public string? ConsentId { get; set; }

    //    // Open Finance / Ozone Metadata
    //    public string? O3ProviderId { get; set; }
    //    public string? O3AspspId { get; set; }
    //    //public string? O3CallerOrgId { get; set; }
    //    //public string? O3CallerClientId { get; set; }

    //    public string? TppName { get; set; }
    //    public string? TppID { get; set; }


    //    public string? O3CallerSoftwareStatementId { get; set; }
    //    public string? O3ApiUri { get; set; }
    //    public string? O3ApiOperation { get; set; }
    //    public string? O3ConsentId { get; set; }
    //    public string? O3CallerInteractionId { get; set; }
    //    public string? O3OzoneInteractionId { get; set; }
    //    public string? O3PsuIdentifier { get; set; }

    //    // Transaction Instruction
    //    public decimal? InstructionAmount { get; set; }
    //    public string? InstructionCurrency { get; set; }
    //    public string? PaymentPurposeCode { get; set; }
    //    public string? DebtorReference { get; set; }
    //    public string? CreditorReference { get; set; }
    //    public string? InstructionPriority { get; set; }

    //    // Billing / VRP Specific
    //    public string? OpenFinanceBillingType { get; set; }
    //    public string? OpenFinanceBillingMerchantId { get; set; }

    //    // Request Audit
    //    public string? Status { get; set; }
    //    public DateTime CreatedOn { get; set; }
    //    public DateTime? ModifiedOn { get; set; }
    //    public string? CreatedBy { get; set; }
    //    public string? ModifiedBy { get; set; }

    //    // Response
    //    public long? PaymentResponseId { get; set; }
    //    public string? ExternalId { get; set; }
    //    public string? PaymentTransactionId { get; set; }
    //    public string? PaymentStatus { get; set; }
    //    public DateTime? StatusUpdateDateTime { get; set; }
    //    public DateTime? CreationDateTime { get; set; }
    //    public string? RejectReasonCode { get; set; }
    //    public string? RejectReasonMessage { get; set; }

    //    // Charges
    //    public string? ChargesType { get; set; }
    //    public decimal? ChargesAmount { get; set; }
    //    public string? ChargesCurrency { get; set; }

    //    // Billing count / paging
    //    public int? BillingNumberOfSuccessTxn { get; set; }
    //    public int? Page { get; set; }
    //    public int? PageSize { get; set; }

    //    // Response Audit
    //    public DateTime? ResponseCreatedOn { get; set; }
    //    public DateTime? ResponseModifiedOn { get; set; }
    //}
    public class FixedRecurringPaymentReportModel
    {
        public List<ReportTemplate>? ModulesList { get; set; }

        public string? ConsentType { get; set; }

        public string? ReportName { get; set; }

        public FixedRecurringPaymentReportFilter? fixedRecurringPaymentReportFilter { get; set; }
            = new FixedRecurringPaymentReportFilter();

        public List<FixedRecurringPaymentReport>? fixedRecurringPaymentReport { get; set; }
            = new List<FixedRecurringPaymentReport>();

        public List<TemplateList>? templateLists { get; set; }

        public FixedRecurringPaymentReportFilter? FixedRecurringPaymentReportField { get; set; }
    }


    //public class TemplateList
    //{
    //    public int TemplateId { get; set; }

    //    public string? TemplateName { get; set; }
    //}


    //public class ReportTemplate
    //{
    //    public string? Value { get; set; }

    //    public string? DisplayName { get; set; }

    //    public string? FieldType { get; set; }
    //}


    //public class ColumnInfo
    //{
    //    public string? ColumnName { get; set; }

    //    public string? AliasName { get; set; }
    //}


    public class FixedRecurringPaymentReportFilter
    {
        public DateTime? FromDate { get; set; } = DateTime.Today;

        public DateTime? ToDate { get; set; } = DateTime.Today;

        public string? PaymentStatus { get; set; }

        public string? RequestStatus { get; set; }

        public string? ConsentId { get; set; }

        public string? TppId { get; set; }

        public string? PaymentType { get; set; }

        // Dynamic Report fields
        public string? Columndetails { get; set; }

        public string? TemplateName { get; set; }

        public string? ReportName { get; set; }

        // Dynamic Report
        //public string? FixedRecurringPaymentBody { get; set; }
        //public Guid CorrelationId { get; set; }
    }


    public class FixedRecurringPaymentReport
    {
        public DateTime? FromDate { get; set; }

        public DateTime? Todate { get; set; }

        public string? Columndetails { get; set; }

        public string? TemplateName { get; set; }

        public string? ReportName { get; set; }

        public string? FixedRecurringPaymentBody { get; set; }

        // Request
        public string? PaymentConsentId { get; set; }

        public string? PaymentCategory { get; set; }

        public string? PaymentType { get; set; }

        public Guid CorrelationId { get; set; }

        public string? ConsentId { get; set; }

        public string? TppName { get; set; }

        public string? TppID { get; set; }

        public string? O3ConsentId { get; set; }

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
        public long? PaymentResponseId { get; set; }

        public string? ExternalId { get; set; }

        public string? PaymentTransactionId { get; set; }

        public string? PaymentStatus { get; set; }

        public DateTime? StatusUpdateDateTime { get; set; }

        public DateTime? CreationDateTime { get; set; }

        public string? RejectReasonCode { get; set; }

        public string? RejectReasonMessage { get; set; }

        // Charges
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

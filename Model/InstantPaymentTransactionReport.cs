namespace ReportingService.Model
{
    public class InstantPaymentTransactionQuery
    {
        public long? RequestId { get; set; }
        public string? PaymentTransactionId { get; set; }
        public string? ConsentId { get; set; }
        public string? Status { get; set; }
        public string? PaymentStatus { get; set; }
        public string? TppId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class InstantPaymentTransactionReport
    {
        // -----------------------------
        // Request Table Fields
        // -----------------------------
        public long RequestId { get; set; }   
        public Guid? CorrelationId { get; set; }
        public string? RequestConsentId { get; set; }
        public string? O3ConsentId { get; set; }
        public string? PaymentCategory { get; set; }
        public string? PaymentType { get; set; }
        public string? RequestPaymentPurposeCode { get; set; }
        public string? ExtendedPurpose { get; set; }
        public string? RequestDebtorReference { get; set; }
        public string? CreditorReference { get; set; }

        public decimal InstructionAmount { get; set; } 
        public string? InstructionCurrency { get; set; }
        public string? CurrencyOfTransfer { get; set; }
        public string? InstructionPriority { get; set; }
        public string? RequestChargeBearer { get; set; }
        public string? RequestStatus { get; set; }

        public string? RequestCreatedBy { get; set; }
        public DateTime RequestCreatedOn { get; set; }   
        public string? RequestModifiedBy { get; set; }
        public DateTime? RequestModifiedOn { get; set; }

        //public string? RequestPayload { get; set; }

        // -----------------------------
        // Response Fields
        // -----------------------------
        public long? ResponseId { get; set; }
        public string? ExternalId { get; set; }
        public string? ResponseConsentId { get; set; }
        public string? PaymentTransactionId { get; set; }
        public string? PaymentStatus { get; set; }

        public DateTime? StatusUpdateDateTime { get; set; }
        public DateTime? ResponseCreationDateTime { get; set; }

        public string? ResponsePaymentPurposeCode { get; set; }
        public string? ResponseDebtorReference { get; set; }

        public string? RejectReasonCode { get; set; }
        public string? RejectReasonMessage { get; set; }

        public string? ResponseChargeBearer { get; set; }
        public string? ChargesType { get; set; }
        public decimal? ChargesAmount { get; set; }
        public string? ChargesCurrency { get; set; }

        public DateTime? ExchangeRateExpirationDateTime { get; set; }
        public int? BillingNumberOfSuccessTxn { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public string? ResponseCreatedBy { get; set; }
        public DateTime? ResponseCreatedOn { get; set; }
        public string? ResponseModifiedBy { get; set; }
        public DateTime? ResponseModifiedOn { get; set; }

       // public string? ResponsePayload { get; set; }
    }


}

namespace ReportingService.Model
{
    public class ServiceInitiationReport
    {
        public List<ReportTemplate>? ModulesList { get; set; }
        public string? Module { get; set; }
        public List<TemplateList>? templateLists { get; set; }
        public ServiceIntiationReportFields? serviceInitiationReportFields { get; set; }
    }

    public class  ServiceIntiationReportFields
    {
        public int Id { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? ColumnDetails { get; set; }
        public string? TemplateName { get; set; }
        public string? ReportName { get; set; }
        public string? CorrelationId { get; set; }
        public string? ConsentId { get; set; }
        public string? InstructionAmount { get; set; }
        public string? InstructionCurrency { get; set; }
        public string? PaymentTransactionId { get; set; }
        public string? PaymentStatus { get; set; }
        public string? PaymentType { get; set; }
        public string? PaymentCategory { get; set; }
        public string? TppName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
    }
}

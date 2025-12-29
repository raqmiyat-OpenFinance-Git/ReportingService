using Microsoft.AspNetCore.Mvc;
using ReportingService.Model;
using ReportingService.IServices;
using ReportingService.Service;
namespace ReportingService.Model
{
    public class ConsentEventReport
    {
        public List<ReportTemplate>? ModulesList { get; set; }
        public string? ConsentType { get; set; }
        public ConsentReportFields? ConsentReportField { get; set; }
        public List<TemplateList>? templateLists { get; set; }

    }
    public class TemplateList
    {
        public int TemplateId { get; set; }
        public string? TemplateName { get; set; }
    }
    public class ColumnInfo
    {
        public string? ColumnName { get; set; }
        public string? AliasName { get; set; }

    }
    public class ConsentReportFields
    {
        public DateTime? FromDate { get; set; }
        public DateTime? Todate { get; set; }
        public string? Columndetails { get; set; }
        public string? TemplateName { get; set; }
        public string? ReportName { get; set; }

        public string? CorrelationId { get; set; }
        public int Id { get; set; }
        public string? ConsentGroupId { get; set; }
        public string? RequestUrl { get; set; }
        public string? ConsentType { get; set; }
        public string? RequestType { get; set; }
        public string? ConsentId { get; set; }
        public string? BaseConsentId { get; set; }
        public string? CurrentStatus { get; set; }
        public string? Status { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        
        public string? AuthorizationChannel { get; set; }
        public string? InteractionId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
        public string? AccountType { get; set; }
        public string? AccountSubType { get; set; }
        public string? Permissions { get; set; }
        public string? TppClientId { get; set; }
        public string? TppId { get; set; }
        public string? TppName { get; set; }
        public string? SoftwareStatementId { get; set; }
        public string? DirectoryRecord { get; set; }
        public string? DecodedSsa { get; set; }
        public string? OrgId { get; set; }
        public string? ParId { get; set; }
        public string? RarType { get; set; }
        public string? StandardVersion { get; set; }
        public string? PsuIdentifiersUserId { get; set; }
        public string? AccountIds { get; set; }
        public string? ConsentBody { get; set; }
        public string? OzoneSupplementaryInformation { get; set; }
        public string? SupplementaryInformation { get; set; }
        public string? PaymentContext { get; set; }
        public string? ConnectToken { get; set; }
        public string? PaymentCategory { get; set; }
        public string? PaymentType { get; set; }
    }
}

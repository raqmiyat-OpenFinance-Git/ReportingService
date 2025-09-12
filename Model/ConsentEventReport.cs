using Microsoft.AspNetCore.Mvc;
using ReportingService.Model;
using ReportingService.IServices;
using ReportingService.Service;
namespace ReportingService.Model
{
    public class ConsentEventReport
    {
        public List<ReportTemplate>? ModulesList { get; set; }
        public string? Module { get; set; }
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
        public int Id { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? Todate { get; set; }
        public string? Columndetails { get; set; }
        public string? TemplateName { get; set; }
        public string? ReportName { get; set; }
        public string? CorrelationId { get; set; }
        public string? RequestType { get; set; }
        public string? BaseConsentId { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        public DateTime? TransactionFromDateTime { get; set; }
        public DateTime? TransactionToDateTime { get; set; }
        public string? ConsentId { get; set; }
        public string? AccountType { get; set; }
        public string? AccountSubType { get; set; }
        public string? Permissions { get; set; }
        public string? Purpose { get; set; }
        public string? StatusFromConsentBody { get; set; }
        public string? RevokedBy { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public string? OnBehalfOf_TradingName { get; set; }
        public string? OnBehalfOf_LegalName { get; set; }
        public string? OnBehalfOf_IdentifierType { get; set; }
        public string? OnBehalfOf_Identifier { get; set; }
        public string? Billing_UserType { get; set; }
        public string? Billing_Purpose { get; set; }
        public bool? Billing_IsLargeCorporate { get; set; }
        public float? TotalRequiredAuthorizations { get; set; }
        public string? AuthorizersJson { get; set; }
        public string? Tpp_ClientId { get; set; }
        public string? Tpp_TppId { get; set; }
        public string? Tpp_TppName { get; set; }
        public string? Tpp_SoftwareStatementId { get; set; }
        public string? Tpp_DirectoryRecord { get; set; }
        public string? Tpp_OrgId { get; set; }
        public string? Ssa_ClientName { get; set; }
        public string? Ssa_ClientUri { get; set; }
        public string? Ssa_LogoUri { get; set; }
        public string? Ssa_JwksUri { get; set; }
        public string? Ssa_ClientId { get; set; }
        public string? Ssa_Roles { get; set; }
        public string? Ssa_SectorIdentifierUri { get; set; }
        public string? Ssa_ApplicationType { get; set; }
        public string? Ssa_OrganisationId { get; set; }
        public string? Ssa_RedirectUris { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
    }
}

namespace ReportingService.Model
{
    public class StoredProcedureParams
    {
        public ConsentSPParams? consentSPParams { get; set; }
        public DataSharingReportParams? dataSharingReportParams { get; set; }
    }
    public class ConsentSPParams
    {
        public string? ReportTemplatesList { get; set; }
        public string? ColumnInfo { get; set; }
        public string? TemplateList { get; set; }
        public string? GET_Template_Details { get; set; }
        public string? DeleteTemplate_Consent { get; set; }
        public string? SaveTemplate_Consent { get; set; }
        public string? GET_Consent_Report { get; set; }
    }
    public class DataSharingReportParams
    {
        public string? GetDataSharingReportTemplates { get; set; }
        public string? GetDataSharingReportColumnNames { get; set; }
        public string? GetDataSharingReportTemplateList { get; set; }
        public string? GetDataSharingReportTemplateData { get; set; }
        public string? DataSharingReportDeleteTemplate { get; set; }
        public string? SaveDataSharingReportTemplate { get; set; }
        public string? GenerateDataSharingReport { get; set; }
    }
}
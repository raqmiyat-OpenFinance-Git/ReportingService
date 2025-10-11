namespace ReportingService.Model
{
    public class StoredProcedureParams
    {
        public ConsentSPParams? consentSPParams { get; set; }
        public DataSharingReportParams? dataSharingReportParams { get; set; }
        public ServiceInitiationReportParams? serviceInitiationReportParams { get; set; }
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

    public class ServiceInitiationReportParams
    {
        public string? ServiceInititaionTemplates { get; set; }
        public string? ServiceInititaionColumnNames { get; set; }
        public string? ServiceInititaionTemplateList { get; set; }
        public string? ServiceInititaionTemplateData { get; set; }
        public string? ServiceInititaiontDeleteTemplate { get; set; }
        public string? SaveServiceInititaionReportTemplate { get; set; }
        public string? GenerateServiceInititaionReport { get; set; }
    }
}
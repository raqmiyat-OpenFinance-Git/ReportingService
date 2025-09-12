using ReportingService.Model;
namespace ReportingService.IServices
{
    public interface IReportsService
    {
        Task<List<ReportTemplate>> GetReportTemplates();
        Task<List<ColumnInfo>> GetColumnNames(string Module);
        Task<List<TemplateList>> GetTemplateList(string Module);
        ConsentEventReport GetTemplateData(int templateId, string Module);
        int DeleteTemplate(int deleteId, string Module);
        string SaveReportTemplate(ConsentEventReport ConsentEventReport);
        Task<List<dynamic>> GenerateOriginatorReport(ConsentReportFields consentReportFields);

    }

}

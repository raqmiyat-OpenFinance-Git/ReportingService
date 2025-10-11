using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface IServiceInitiationReportService
    {
        Task<List<ReportTemplate>> GetReportTemplates();
        Task<List<ColumnInfo>> GetColumnNames();
        Task<List<TemplateList>> GetTemplateList();
        ServiceInitiationReport GetTemplateData(int templateId);
        int DeleteTemplate(int deleteId);
        string SaveReportTemplate(ServiceInitiationReport serviceInitiationReport);
        Task<List<dynamic>> GenerateServiceInitiationReport(ServiceIntiationReportFields serviceInitiationReport    );
    }
}

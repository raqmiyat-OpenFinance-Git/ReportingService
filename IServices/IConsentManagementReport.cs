using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface IConsentManagementReportService
    {
        Task<List<ConsentManagementReport>> GetConsentManagementReportAsync(ConsentReportQuery query);
    }

}

using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface IConfirmationPayeeReportService
    {
        Task<List<ConfirmationPayeeReport>> GetConfirmationPayeeReportAsync(ConfirmationPayeeQueryFilter query);
    }
}

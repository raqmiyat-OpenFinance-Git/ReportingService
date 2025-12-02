using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface IScheduledPaymentReportService
    {
        Task<List<ScheduledPaymentReport>> GetScheduledPaymentReportAsync(ScheduledPaymentReportFilter query);
    }
}

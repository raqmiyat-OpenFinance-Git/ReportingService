using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface IStandingOrderReportService
    {
        Task<List<StandingOrderReport>> GetStandingOrderReportAsync(StandingOrderReportFilter query);
    }
}

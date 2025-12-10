using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface IFutureDatePaymentsReportService
    {
        Task<List<FutureDatePaymentsReport>> GetFutureDatePaymentsReportAsync(FutureDatePaymentsReportFilter filter);
    }
}

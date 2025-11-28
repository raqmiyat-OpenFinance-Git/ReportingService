using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface IAccountBalanceSummaryReportService
    {
        Task<List<AccountBalanceSummaryReport>> GetAccountBalanceSummaryReportAsync(AccountBalanceSummaryReportFilter query);

    }
}

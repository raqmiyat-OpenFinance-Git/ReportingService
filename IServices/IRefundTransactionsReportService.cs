using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface IRefundTransactionsReportService
    {
        Task<List<RefundTransactionsReport>> GetRefundTransactionsReportAsync(RefundTransactionsReportFilter filter);
    }
}

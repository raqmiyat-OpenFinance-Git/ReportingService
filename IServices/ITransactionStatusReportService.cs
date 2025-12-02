using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface ITransactionStatusReportService
    {
        Task<List<TransactionStatusReport>> GetTransactionStatusReportAsync(TransactionStatusReportFilter query);
    }
}

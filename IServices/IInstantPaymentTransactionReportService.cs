using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface IInstantPaymentTransactionReportService
    {
        Task<List<InstantPaymentTransactionReport>> GetInstantPaymentTransactionReportAsync(InstantPaymentTransactionQuery query);
    }
}

using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface IPaymentTransactionReportService
    {
        Task<List<PaymentTransactionReport>> GetPaymentTransactionReportAsync(
            PaymentTransactionReportFilter query);
    }
}

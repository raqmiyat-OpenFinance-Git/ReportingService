using ReportingService.Model;

public interface IBulkBatchPaymentReportService
{
    Task<List<BullkBatchPaymentReport>> GetBulkBatchPaymentReportAsync(BullkBatchPaymentReportFilter query);
}

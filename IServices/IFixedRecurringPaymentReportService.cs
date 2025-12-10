using ReportingService.Model;

public interface IFixedRecurringPaymentReportService
{
    Task<List<FixedRecurringPaymentReport>> GetFixedRecurringPaymentReportAsync(FixedRecurringPaymentReportFilter query);
}

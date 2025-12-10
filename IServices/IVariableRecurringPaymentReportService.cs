using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface IVariableRecurringPaymentReportService
    {
        Task<List<VariableRecurringPaymentReport>> GetVariableRecurringPaymentReportAsync(VariableRecurringPaymentReportFilter query);
    }
}

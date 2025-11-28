using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface ICustomerProfileReportService
    {
        Task<List<CustomerProfileReportModel>> GetCustomerProfileReportAsync(CustomerProfileReportFilter query);
    }
}

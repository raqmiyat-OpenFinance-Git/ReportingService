using ReportingService.Model;

namespace ReportingService.IServices
{
    public interface IBeneficiaryManagementReportService
    {
        Task<List<BeneficiaryManagementReport>> GetBeneficiaryManagementReportAsync(BeneficiaryManagementReportFilter query);
    }
}

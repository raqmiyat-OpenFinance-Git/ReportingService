using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class BeneficiaryManagementReportService : IBeneficiaryManagementReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public BeneficiaryManagementReportService(
            DataSharingDBConnection idbConnection,
            NLogReportService logger,
            IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<BeneficiaryManagementReport>> GetBeneficiaryManagementReportAsync(BeneficiaryManagementReportFilter query)
        {
            var report = new List<BeneficiaryManagementReport>();

            try
            {
                var parameters = new DynamicParameters();

                // Filter parameters
                parameters.Add("@CreatedFrom", query?.CreatedFrom);
                parameters.Add("@CreatedTo", query?.CreatedTo);
                parameters.Add("@O3ProviderId", query?.O3ProviderId);
                parameters.Add("@AccountId", query?.AccountId);
                parameters.Add("@BeneficiaryId", query?.BeneficiaryId);
                parameters.Add("@BeneficiaryType", query?.BeneficiaryType);
                parameters.Add("@AccountHolderName", query?.AccountHolderName);
                parameters.Add("@Status", query?.Status);
               

                // Execute stored procedure
                report = (await _idbConnection.QueryAsync<BeneficiaryManagementReport>(
                    _storedProcedureParams.Value.beneficiaryManagementReportParams!.GetBeneficiaryManagementReport!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Beneficiary Management Report");
            }

            return report;
        }
    }
}

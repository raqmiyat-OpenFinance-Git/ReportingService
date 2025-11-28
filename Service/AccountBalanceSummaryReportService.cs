using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class AccountBalanceSummaryReportService : IAccountBalanceSummaryReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public AccountBalanceSummaryReportService(
            DataSharingDBConnection idbConnection,
            NLogReportService logger,
            IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<AccountBalanceSummaryReport>> GetAccountBalanceSummaryReportAsync(AccountBalanceSummaryReportFilter query)
        {
            var report = new List<AccountBalanceSummaryReport>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@O3ProviderId", query?.O3ProviderId);
                parameters.Add("@AccountHolderName", query?.AccountHolderName);
                parameters.Add("@AccountId", query?.AccountId);
                parameters.Add("@Currency", query?.Currency);
                parameters.Add("@AccountStatus", query?.AccountStatus);
                parameters.Add("@CreatedFrom", query?.CreatedFrom);
                parameters.Add("@CreatedTo", query?.CreatedTo);


                report = (await _idbConnection.QueryAsync<AccountBalanceSummaryReport>(
                    _storedProcedureParams.Value.accountBalanceSummaryReportParams!.GetAccountBalanceSummaryReport!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Account Balance Summary Report");
            }

            return report;
        }
    }
}

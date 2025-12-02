using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class StandingOrderReportService : IStandingOrderReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public StandingOrderReportService(
            DataSharingDBConnection idbConnection,
            NLogReportService logger,
            IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<StandingOrderReport>> GetStandingOrderReportAsync(StandingOrderReportFilter query)
        {
            var report = new List<StandingOrderReport>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@O3ProviderId", query?.O3ProviderId);
                parameters.Add("@AccountId", query?.AccountId);
                parameters.Add("@StandingOrderId", query?.StandingOrderId);
                parameters.Add("@AccountHolderName", query?.AccountHolderName);
                parameters.Add("@StandingOrderType", query?.StandingOrderType);
                parameters.Add("@Frequency", query?.Frequency);
                parameters.Add("@StandingOrderStatusCode", query?.StandingOrderStatusCode);
                parameters.Add("@CreatedFrom", query?.CreatedFrom);
                parameters.Add("@CreatedTo", query?.CreatedTo);

                report = (await _idbConnection.QueryAsync<StandingOrderReport>(
                    _storedProcedureParams.Value.standingOrderReportParams!.GetStandingOrderReport!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Standing Order Report");
            }

            return report;
        }
    }
}

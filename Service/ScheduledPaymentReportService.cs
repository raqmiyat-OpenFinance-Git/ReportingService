using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class ScheduledPaymentReportService : IScheduledPaymentReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public ScheduledPaymentReportService(DataSharingDBConnection idbConnection,NLogReportService logger,
            IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<ScheduledPaymentReport>> GetScheduledPaymentReportAsync(ScheduledPaymentReportFilter query)
        {
            var report = new List<ScheduledPaymentReport>();

            try
            {
                var parameters = new DynamicParameters();

                // Filter parameters
                parameters.Add("@O3ProviderId", query?.O3ProviderId);
                parameters.Add("@AccountId", query?.AccountId);
                parameters.Add("@ScheduledPaymentId", query?.ScheduledPaymentId);
                parameters.Add("@AccountHolderName", query?.AccountHolderName);
                parameters.Add("@ScheduledType", query?.ScheduledType);
                parameters.Add("@CreatedFrom", query?.CreatedFrom);
                parameters.Add("@CreatedTo", query?.CreatedTo);

                // Execute stored procedure
                report = (await _idbConnection.QueryAsync<ScheduledPaymentReport>(
                    _storedProcedureParams.Value.scheduledPaymentReportParams!.GetScheduledPaymentReport!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Scheduled Payment Report");
            }

            return report;
        }
    }
}

using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class ConfirmationPayeeReportService : IConfirmationPayeeReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public ConfirmationPayeeReportService
            (DataSharingDBConnection idbConnection, NLogReportService logger,
            IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }
        public async Task<List<ConfirmationPayeeReport>> GetConfirmationPayeeReportAsync(ConfirmationPayeeQueryFilter query)
        {
            var report = new List<ConfirmationPayeeReport>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@O3ProviderId", query?.O3ProviderId);
                parameters.Add("@FullName", query?.FullName);
                parameters.Add("@ClaimEmiratesId", query?.ClaimEmiratesId);
                parameters.Add("@Status", query?.Status);
                parameters.Add("@CopQueryStatus", query?.CopQueryStatus);
                parameters.Add("@CreatedFrom", query?.CreatedFrom);
                parameters.Add("@CreatedTo", query?.CreatedTo);

                report = (await _idbConnection.QueryAsync<ConfirmationPayeeReport>(
                    _storedProcedureParams.Value.confirmationPayeeReportParams!.GetConfirmationPayeeReport!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Confirmation Payee Report");
            }


            return report;
        }
    }


}

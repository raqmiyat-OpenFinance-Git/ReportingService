using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class ConsentManagementReportService : IConsentManagementReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;


        public ConsentManagementReportService(ConsentDbConnection idbConnection, NLogReportService logger, IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<ConsentManagementReport>> GetConsentManagementReportAsync(ConsentReportQuery query)
        {
            List<ConsentManagementReport> report = new List<ConsentManagementReport>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ConsentId", query.ConsentId);
                parameters.Add("@Status", query.Status);
                parameters.Add("@ConsentType", query.ConsentType);
                parameters.Add("@TppId", query.TppId);
                parameters.Add("@FromDate", query.FromDate);
                parameters.Add("@ToDate", query.ToDate);

                report = (await _idbConnection.QueryAsync<ConsentManagementReport>(
                    _storedProcedureParams.Value.consentManagementReportParams!.GetConsentManagementReport!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Consent Management Report");
            }

            return report;
        }

    }
}

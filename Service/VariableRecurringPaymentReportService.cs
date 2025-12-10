using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class VariableRecurringPaymentReportService : IVariableRecurringPaymentReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public VariableRecurringPaymentReportService(ServiceIntiationDbConnection idbConnection,NLogReportService logger,
            IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<VariableRecurringPaymentReport>> GetVariableRecurringPaymentReportAsync(
            VariableRecurringPaymentReportFilter query)
        {
            var report = new List<VariableRecurringPaymentReport>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@FromDate", query?.FromDate);
                parameters.Add("@ToDate", query?.ToDate);
                parameters.Add("@PaymentStatus", query?.PaymentStatus);
                parameters.Add("@RequestStatus", query?.RequestStatus);
                parameters.Add("@PaymentCategory", query?.PaymentCategory);
                parameters.Add("@ConsentId", query?.ConsentId);
                parameters.Add("@TppId", query?.TppId);

                report = (await _idbConnection.QueryAsync<VariableRecurringPaymentReport>(
                    _storedProcedureParams.Value.variableRecurringPaymentReportParams!
                        .GetVariableRecurringPaymentReport!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Variable Recurring Payment Report");
            }

            return report;
        }
    }
}

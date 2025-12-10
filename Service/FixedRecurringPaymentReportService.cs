using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class FixedRecurringPaymentReportService : IFixedRecurringPaymentReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public FixedRecurringPaymentReportService(ServiceIntiationDbConnection idbConnection, NLogReportService logger,
            IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<FixedRecurringPaymentReport>> GetFixedRecurringPaymentReportAsync(
            FixedRecurringPaymentReportFilter query)
        {
            var report = new List<FixedRecurringPaymentReport>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FromDate", query?.FromDate);
                parameters.Add("@ToDate", query?.ToDate);
                parameters.Add("@PaymentStatus", query?.PaymentStatus);
                parameters.Add("@RequestStatus", query?.RequestStatus);
                parameters.Add("@ConsentId", query?.ConsentId);
                parameters.Add("@TppId", query?.TppId);
                parameters.Add("@PaymentType", query?.PaymentType);

                report = (await _idbConnection.QueryAsync<FixedRecurringPaymentReport>(
                    _storedProcedureParams.Value.fixedRecurringPaymentReportParams!
                        .GetFixedRecurringPaymentReport!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Fixed Recurring Payment Report");
            }

            return report;
        }
    }
}

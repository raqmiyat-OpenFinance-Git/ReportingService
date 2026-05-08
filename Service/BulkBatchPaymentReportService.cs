using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class BulkBatchPaymentReportService : IBulkBatchPaymentReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public BulkBatchPaymentReportService(ServiceIntiationDbConnection idbConnection, NLogReportService logger,
            IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<BullkBatchPaymentReport>> GetBulkBatchPaymentReportAsync(
            BullkBatchPaymentReportFilter query)
        {
            var report = new List<BullkBatchPaymentReport>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FromDate", query?.FromDate);
                parameters.Add("@ToDate", query?.ToDate);
                parameters.Add("@PaymentStatus", query?.PaymentStatus);
                parameters.Add("@ConsentId", query?.ConsentId);
                parameters.Add("@TppId", query?.TppId);
                parameters.Add("@FileType", query?.PaymentType);

                report = (await _idbConnection.QueryAsync<BullkBatchPaymentReport>(
                    _storedProcedureParams.Value.bulkbatchPaymentReportParams!
                        .GetBulkBatchPaymentReport!,
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

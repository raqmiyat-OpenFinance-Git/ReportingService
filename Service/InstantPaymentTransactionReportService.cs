using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class InstantPaymentTransactionReportService : IInstantPaymentTransactionReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public InstantPaymentTransactionReportService(ServiceIntiationDbConnection idbConnection,
            NLogReportService logger, IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<InstantPaymentTransactionReport>> GetInstantPaymentTransactionReportAsync(InstantPaymentTransactionQuery query)
        {
            List<InstantPaymentTransactionReport> report = new List<InstantPaymentTransactionReport>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RequestId", query.RequestId);
                parameters.Add("@PaymentTransactionId", query.PaymentTransactionId);
                parameters.Add("@ConsentId", query.ConsentId);
                parameters.Add("@Status", query.Status);
                parameters.Add("@PaymentStatus", query.PaymentStatus);
                parameters.Add("@TppId", query.TppId);
                parameters.Add("@FromDate", query.FromDate);
                parameters.Add("@ToDate", query.ToDate);

                report = (await _idbConnection.QueryAsync<InstantPaymentTransactionReport>(
                    _storedProcedureParams.Value.instantPaymentTransactionReportParams!.GetInstantPaymentTransactionReport!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Instant Payment Transaction Report");
            }

            return report;
        }

    }
}

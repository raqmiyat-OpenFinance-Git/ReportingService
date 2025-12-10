using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class RefundTransactionsReportService : IRefundTransactionsReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public RefundTransactionsReportService(ServiceIntiationDbConnection idbConnection,NLogReportService logger,
            IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<RefundTransactionsReport>> GetRefundTransactionsReportAsync(RefundTransactionsReportFilter filter)
        {
            var report = new List<RefundTransactionsReport>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FromDate", filter?.FromDate);
                parameters.Add("@ToDate", filter?.ToDate);
                parameters.Add("@PaymentStatus", filter?.PaymentStatus);
                parameters.Add("@RequestStatus", filter?.RequestStatus);
                parameters.Add("@ConsentId", filter?.ConsentId);
                parameters.Add("@TppId", filter?.TppId);

                report = (await _idbConnection.QueryAsync<RefundTransactionsReport>(
                    _storedProcedureParams.Value.refundTransactionsReportParams!
                        .GetRefundTransactionsReport!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Refund Transactions Report");
            }

            return report;
        }
    }
}

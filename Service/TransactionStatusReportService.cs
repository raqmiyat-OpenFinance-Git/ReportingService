using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class TransactionStatusReportService : ITransactionStatusReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public TransactionStatusReportService(
            DataSharingDBConnection idbConnection,
            NLogReportService logger,
            IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<TransactionStatusReport>> GetTransactionStatusReportAsync(TransactionStatusReportFilter query)
        {
            var report = new List<TransactionStatusReport>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@CreatedFrom", query?.CreatedFrom);
                parameters.Add("@CreatedTo", query?.CreatedTo);
                parameters.Add("@O3ProviderId", query?.O3ProviderId);
                parameters.Add("@AccountId", query?.AccountId);
                parameters.Add("@TransactionCode", query?.TransactionCode);
                parameters.Add("@TransactionType", query?.TransactionType);
                parameters.Add("@SubTransactionType", query?.SubTransactionType);
                parameters.Add("@Status", query?.Status);


                // Execute stored procedure
                report = (await _idbConnection.QueryAsync<TransactionStatusReport>(
                    _storedProcedureParams.Value.transactionStatusReportParams!.GetTransactionStatusReport!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Transaction Status Report");
            }

            return report;
        }
    }
}

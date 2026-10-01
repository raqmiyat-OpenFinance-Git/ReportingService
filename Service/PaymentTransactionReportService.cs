using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class PaymentTransactionReportService : IPaymentTransactionReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public PaymentTransactionReportService(
            ServiceIntiationDbConnection idbConnection,
            NLogReportService logger,
            IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<PaymentTransactionReport>> GetPaymentTransactionReportAsync(
            PaymentTransactionReportFilter query)
        {
            var report = new List<PaymentTransactionReport>();

            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@CreatedFrom", query?.CreatedFrom);
                parameters.Add("@CreatedTo", query?.CreatedTo);
                parameters.Add("@PaymentEnquiryId", query?.PaymentEnquiryId);
                parameters.Add("@PaymentId", query?.PaymentId);
                parameters.Add("@PaymentTransactionId", query?.PaymentTransactionId);
                parameters.Add("@PaymentStatus", query?.PaymentStatus);
                parameters.Add("@BankingSystem", query?.BankingSystem);
                parameters.Add("@Currency", query?.Currency);
                report = (await _idbConnection.QueryAsync<PaymentTransactionReport>(
    _storedProcedureParams.Value
        .paymentTransactionReportParams!
        .GetPaymentTransactionReport!,
    parameters,
    commandType: CommandType.StoredProcedure
)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Error while fetching Payment Transaction Report"
                );
            }

            return report;
        }
    }
}
using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Service;
using System.Data;

namespace ReportingService.Services
{
    public class FutureDatePaymentsReportService : IFutureDatePaymentsReportService
    {
        private readonly IDbConnection _dbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public FutureDatePaymentsReportService(ServiceIntiationDbConnection dbConnection,NLogReportService logger,
            IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _dbConnection = dbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<FutureDatePaymentsReport>> GetFutureDatePaymentsReportAsync(FutureDatePaymentsReportFilter filter)
        {
            var result = new List<FutureDatePaymentsReport>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FromDate", filter?.FromDate);
                parameters.Add("@ToDate", filter?.ToDate);
                parameters.Add("@PaymentStatus", filter?.PaymentStatus);
                parameters.Add("@RequestStatus", filter?.RequestStatus);
                parameters.Add("@ConsentId", filter?.ConsentId);
                parameters.Add("@TppId", filter?.TppId);

                result = (await _dbConnection.QueryAsync<FutureDatePaymentsReport>(
                    _storedProcedureParams.Value.futureDatePaymentsReportParams!.GetFutureDatePaymentsReport!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Future Date Payments Report");
            }

            return result;
        }
    }
}

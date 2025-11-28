using Dapper;
using Microsoft.Extensions.Options;
using ReportingService.IServices;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Service
{
    public class CustomerProfileReportService : ICustomerProfileReportService
    {
        private readonly IDbConnection _idbConnection;
        private readonly NLogReportService _logger;
        private readonly IOptions<StoredProcedureParams> _storedProcedureParams;

        public CustomerProfileReportService(DataSharingDBConnection idbConnection, NLogReportService logger,
           IOptions<StoredProcedureParams> storedProcedureParams)
        {
            _idbConnection = idbConnection.GetConnection();
            _logger = logger;
            _storedProcedureParams = storedProcedureParams;
        }

        public async Task<List<CustomerProfileReportModel>> GetCustomerProfileReportAsync(CustomerProfileReportFilter query)
        {
            var report = new List<CustomerProfileReportModel>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@O3ProviderId", query?.O3ProviderId);
                parameters.Add("@CustomerNumber", query?.CustomerNumber);
                parameters.Add("@AccountId", query?.AccountId);
                parameters.Add("@CustomerCategory", query?.CustomerCategory);
                parameters.Add("@Status", query?.Status);
                parameters.Add("@CreatedFrom", query?.CreatedFrom);
                parameters.Add("@CreatedTo", query?.CreatedTo);

                report = (await _idbConnection.QueryAsync<CustomerProfileReportModel>(
                    _storedProcedureParams.Value.customerProfileReportParams!.GetCustomerProfileReport!,
                    parameters,
                    commandType: CommandType.StoredProcedure
                )).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching Customer Profile Report");
            }

            return report;
        }
    }

}


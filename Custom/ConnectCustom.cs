using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using ReportingService.Model;
using ReportingService.Services;
using System.Data;

namespace ReportingService.Custom
{
    public class ConnectCustom
    {
        private readonly IOptions<DataBaseConnectionParams> _dataBaseConnectionParams;
        private readonly NLogManagerService _logger;
        public ConnectCustom(IOptions<DataBaseConnectionParams> dataBaseConnectionParams, NLogManagerService logger)
        {
            _dataBaseConnectionParams = dataBaseConnectionParams;
            _logger = logger;
        }

        public IDbConnection GetSingletonIDbConnection()
        {
            
            SqlConnection dbConnection = new SqlConnection(SqlConManager.GetConnectionString(_dataBaseConnectionParams.Value!.DBConnection!, _dataBaseConnectionParams.Value.IsEncrypted));
            if (dbConnection.State != ConnectionState.Closed)
            {
                _logger.LogInfo("DBConnection is already opened.");
                return dbConnection;
            }
            dbConnection.Open();
            return dbConnection;

        }
        
    }

}

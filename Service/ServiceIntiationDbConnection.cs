using Microsoft.Data.SqlClient;
using System.Data;

namespace ReportingService.Service
{
    public class ServiceIntiationDbConnection
    {
        private readonly IDbConnection _connection;

        public ServiceIntiationDbConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public IDbConnection GetConnection() => _connection;
    }
}

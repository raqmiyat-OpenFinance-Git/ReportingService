using Microsoft.Data.SqlClient;
using ReportingService.Model;
using System.Data;

namespace ReportingService.Service
{
    public class DataSharingDBConnection
    {
        private readonly IDbConnection _connection;

        public DataSharingDBConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public IDbConnection GetConnection() => _connection;
    }
}

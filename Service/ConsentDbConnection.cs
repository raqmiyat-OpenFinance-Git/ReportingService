using Microsoft.Data.SqlClient;
using ReportingService.Model;
using System.Data;

namespace ReportingService.Service
{
    public class ConsentDbConnection
    {
        private readonly IDbConnection _connection;

        public ConsentDbConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public IDbConnection GetConnection() => _connection;
    }
}

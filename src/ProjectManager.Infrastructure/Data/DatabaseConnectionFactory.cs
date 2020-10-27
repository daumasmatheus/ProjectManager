using ProjectManager.Infrastructure.Data.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProjectManager.Infrastructure.Data
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string connectionString;

        public DatabaseConnectionFactory(string ConnectionString)
        {
            connectionString = ConnectionString;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();            
            return sqlConnection;
        }            
    }
}

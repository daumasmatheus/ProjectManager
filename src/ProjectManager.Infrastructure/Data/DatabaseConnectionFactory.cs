using Dapper;
using Humanizer;
using ProjectManager.Infrastructure.Data.Interfaces;
using SqlKata.Compilers;
using SqlKata.Execution;
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

        private async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();            
            return sqlConnection;
        }    
        
        public async Task<QueryFactory> CreateQueryFactory()
        {
            var conn = await CreateConnectionAsync();
            return new QueryFactory(conn, new SqlServerCompiler());
        }
    }
}

using SqlKata.Execution;
using System.Data;
using System.Threading.Tasks;

namespace ProjectManager.Infrastructure.Data.Interfaces
{
    public interface IDatabaseConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}

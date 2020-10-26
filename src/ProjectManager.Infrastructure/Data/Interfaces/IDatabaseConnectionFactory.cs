using SqlKata.Execution;
using System.Threading.Tasks;

namespace ProjectManager.Infrastructure.Data.Interfaces
{
    public interface IDatabaseConnectionFactory
    {
        Task<QueryFactory> CreateQueryFactory();
    }
}

using ProjectManager.Infrastructure.Data.Interfaces;

namespace ProjectManager.Team.Services
{
    public class TeamServices
    {
        public readonly IDatabaseConnectionFactory connectionFactory;

        public TeamServices(IDatabaseConnectionFactory ConnectionFactory)
        {
            connectionFactory = ConnectionFactory;
        }
    }
}

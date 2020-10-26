using ProjectManager.Infrastructure.Data.Interfaces;
using ProjectManager.Person.Dtos;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManager.Person.Services
{
    public class PersonServices
    {
        public readonly IDatabaseConnectionFactory connectionFactory;

        public PersonServices(IDatabaseConnectionFactory ConnectionFactory)
        {
            connectionFactory = ConnectionFactory;
        }

        public async Task<IEnumerable<PersonDto>> GetPersons()
        {
            using var conn = await connectionFactory.CreateQueryFactory();

            var result = await conn.Query("Person").GetAsync<PersonDto>();

            return result;
        }
    }
}

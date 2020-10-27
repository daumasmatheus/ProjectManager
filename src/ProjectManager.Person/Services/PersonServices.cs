using Dapper;
using ProjectManager.Infrastructure.Data.Interfaces;
using ProjectManager.Person.Dtos;
using ProjectManager.Person.Services.DbCommands;
using System.Collections.Generic;
using System.Linq;
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
        
        public async Task<IEnumerable<dynamic>> GetAllPerson()
        {
            using var conn = await connectionFactory.CreateConnectionAsync();
            IEnumerable<PersonDto> result = conn.Query<PersonDto>(PersonDbCommands.SELECT_ALL_PERSON);

            return result;
        }

        public async Task<PersonDto> GetPersonById(int personId)
        {
            using var conn = await connectionFactory.CreateConnectionAsync();

            var parameters = new DynamicParameters();
            parameters.Add("PersonId", personId);

            PersonDto result = conn.Query<PersonDto>(PersonDbCommands.SELECT_PERSON_BY_ID, parameters).FirstOrDefault();

            return result;
        }

        public async Task<bool> SaveNewPerson(PersonDto person)
        {
            using var conn = await connectionFactory.CreateConnectionAsync();

            var result = conn.Execute(PersonDbCommands.INSERT_NEW_PERSON_DATA, person);

            return result > 0;
        }
    }
}

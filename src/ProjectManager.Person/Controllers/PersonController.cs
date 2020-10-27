using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Person.Dtos;
using ProjectManager.Person.Services;
using System;
using System.Threading.Tasks;

namespace ProjectManager.Person.Controllers
{
    [Route("api/person")]
    [Authorize]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public readonly PersonServices personServices;

        public PersonController(PersonServices PersonServices)
        {
            personServices = PersonServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await personServices.GetAllPerson();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetPersonById(int personId)
        {
            try
            {
                var result = await personServices.GetPersonById(personId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("SaveNewPerson")]
        public async Task<IActionResult> SaveNewPersonData(PersonDto person)
        {
            try
            {
                var result = await personServices.SaveNewPerson(person);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

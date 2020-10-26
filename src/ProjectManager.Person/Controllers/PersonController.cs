using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Person.Services;
using System.Threading.Tasks;

namespace ProjectManager.Person.Controllers
{
    [Authorize]
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public readonly PersonServices personServices;

        public PersonController(PersonServices PersonServices)
        {
            personServices = PersonServices;
        }

        [Authorize(Policy = "AllowRead")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await personServices.GetPersons();
            return Ok(result);
        }
    }
}

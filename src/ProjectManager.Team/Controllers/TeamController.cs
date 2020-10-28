using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Team.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Team.Controllers
{
    [Route("api/team")]
    [Authorize]
    [ApiController]
    public class TeamController : ControllerBase
    {
        public readonly TeamServices teamServices;

        public TeamController(TeamServices TeamServices)
        {
            teamServices = TeamServices;
        }
    }
}

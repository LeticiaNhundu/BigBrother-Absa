using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherAPI.Entities;
using BigBrotherAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBrotherAPI.Controllers
{
    [Route("bigbrother/")]
    [ApiController]
    public class TeamPersonController : ControllerBase
    {
        private readonly ITeamPersonService _service;

        public TeamPersonController(ITeamPersonService service)
        {
            _service = service;
        }

        [HttpGet("getAllTeamPerson")]
        public ActionResult<List<TeamPerson>> GetAllTeamPerson()
        {
           return _service.GetAllTeamPerson();
        }

        [HttpGet("getTeamPersonByTeam")]
        public ActionResult<List<TeamPerson>> GetByTeam([FromQuery]int teamId)
        {
            return _service.GetByTeam(teamId);
        }

        [HttpGet("getTeamPersonByPerson")]
        public ActionResult<List<TeamPerson>> GetByPerson([FromQuery]int personId)
        {
            return _service.GetByPerson(personId);
        }

        [HttpPost("saveTeamPerson")]
        public ActionResult<List<TeamPerson>> Insert([FromBody] TeamPerson teamPerson)
        {
            return _service.Insert(teamPerson);
        }

        [HttpPut("updateTeamPerson")]
        public ActionResult<List<TeamPerson>> Update(TeamPerson teamPerson)
        {
            return _service.Update(teamPerson);
        }

        [HttpDelete("deleteTeamPerson")]
        public ActionResult<List<TeamPerson>> Delete([FromQuery] int teamId, [FromQuery] int personId)
        {
            return _service.Delete(teamId, personId);
        }
    }
}
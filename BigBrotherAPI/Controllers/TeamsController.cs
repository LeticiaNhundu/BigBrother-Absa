using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherAPI.Entities;
using BigBrotherAPI.Models;
using BigBrotherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BigBrotherAPI.Controllers
{
    [Route("bigbrother/")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _service;

        public TeamsController(ITeamService service)
        {
            _service = service;
        }

        // GET api/values
        [HttpGet("teams")]
        public ActionResult<List<Teams>> GetAllTeams()
        {
            return _service.GetAllTeams();
        }

        [HttpGet("teamsByName")]
        public ActionResult<Teams> GetTeamByName([FromQuery]string teamName)
        {
            return _service.GetTeamByName(teamName);
        }

        [HttpGet("teamsById")]
        public ActionResult<Teams> GetTeamById([FromQuery]int id)
        {
            return _service.GetTeamById(id);
        }

        // POST api/values
        [HttpPost("teams")]
        public ActionResult<List<Teams>> SaveTeam([FromBody] Teams team)
        {
            return _service.SaveTeam(team);
        }

        // PUT api/values/5
        [HttpPut("teams")]
        public ActionResult<List<Teams>> updateTeam([FromBody] Teams team)
        {
            return _service.UpdateTeam(team);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<List<Teams>> DeleteTeam(int id)
        {
            return _service.DeleteTeam(id);
        }
    }
}

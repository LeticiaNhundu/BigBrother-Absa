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
    public class PersonController : Controller
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        [HttpGet("getPerson")]
        public ActionResult<List<Person>> GetAllPeople()
        {
            return _service.GetAllPerson();
        }

        [HttpGet("getPersonByAbNumber/{abNumber}")]
        public ActionResult<Person> GetPerson(string abNumber)
        {

            return _service.GetPerson(abNumber);
        }

        [HttpGet("getPersonById/{id}")]
        public ActionResult<Person> GetPersonBy(int id)
        {
            return _service.GetPersonById(id);
        }

        [HttpPost("savePerson")]
        public ActionResult<List<Person>> SavePerson([FromBodyAttribute] Person person)
        {
            return _service.SavePerson(person);
        }

        [HttpPut("updatePerson")]
        public ActionResult<List<Person>> UpdatePerson([FromBodyAttribute] Person person)
        {
            return _service.UpdatePerson(person);
        }

        [HttpDelete("deletePerson/{abNumber}")]
        public ActionResult<List<Person>> DeletePerson(string abNumber)
        {
            return _service.DeletePerson(abNumber);
        }
    }
}
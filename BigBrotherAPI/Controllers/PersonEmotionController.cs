using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherAPI.Entities;
using BigBrotherAPI.Models;
using BigBrotherAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBrotherAPI.Controllers
{
    [Route("bigbrother/")]
    [ApiController]
    public class PersonEmotionController : ControllerBase
    {
        private readonly IPersonEmotionsService _service;

        public PersonEmotionController(IPersonEmotionsService service)
        {
            _service = service;
        }

        [HttpGet("getPersonEmotion")]
        public ActionResult<List<PersonEmotions>> GetAllPersonEmotions()
        {
            return _service.GetAllPersonEmotions();
        }

        [HttpGet("getByPersonEmotions")]
        public ActionResult<PersonEmotions> GetByPersonEmotion([FromQuery] int personId, [FromQuery] int emotionId)
        {
            return _service.GetByPersonEmotion(personId, emotionId);
        }

        [HttpGet("getPersonEmotionByDate")]
        public ActionResult<List<PersonEmotions>> GetAllPersonEmotionByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            return _service.GetAllPersonEmotionByDate(startDate, endDate);
        }

      //  [HttpPost("savePersonEmotions")]
       // public ActionResult<List<PersonEmotions>> SavePersonEmotion([FromBodyAttribute] PersonEmotions personEmotion)
       // {
      //      return _service.Insert(personEmotion);
      //  }

       // [HttpPut("updatePersonEmotion")]
       // public ActionResult<List<PersonEmotions>> UpdatePersonEmotion([FromBodyAttribute] PersonEmotions personEmotion)
       // {
       //     return _service.Update(personEmotion);
       // }

      //  [HttpDelete("deletePersonEmotion/{id}")]
       // public ActionResult<List<PersonEmotions>> DeletePersonEmotion(int id)
      //  {
      //      return _service.Delete(id);
      //  }
    }
}
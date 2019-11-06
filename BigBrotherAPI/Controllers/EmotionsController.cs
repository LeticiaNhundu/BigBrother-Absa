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
    public class EmotionsController : Controller
    {
        private readonly IEmotionService _service;

        public EmotionsController(IEmotionService service)
        {
            _service = service;
        }

        [HttpGet("getEmotions")]
        public ActionResult<List<Emotions>> GetAllEmotions()
        {
           return _service.GetAllEmotions();
        }

        [HttpGet("getEmotions/{emotionId}")]
        public ActionResult<Emotions> GetEmotion(int emotionId)
        {
            return _service.GetEmotion(emotionId);
        }

        [HttpPost("saveEmotions")]
        public ActionResult<List<Emotions>> SaveEmotion([FromBodyAttribute] Emotions emotion)
        {
            return _service.SaveEmotion(emotion);
        }

        [HttpPut("updateEmotion")]
        public ActionResult<List<Emotions>> UpdateEmotion([FromBodyAttribute] Emotions emotion)
        {
            return _service.UpdateEmotion(emotion);
        }

        [HttpDelete("deleteEmotion/{emotionId}")]
        public ActionResult<List<Emotions>> DeleteEmotion(int emotionId)
        {
            return _service.DeleteEmotion(emotionId);
        }
    }
}
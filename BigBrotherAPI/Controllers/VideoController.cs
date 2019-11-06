using BigBrotherAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BigBrotherAPI.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BigBrotherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : Controller
    {
        private IVideoService _videoservice;
        public VideoController(IVideoService videoService)
        {
            _videoservice = videoService;
        }

        //example of method for sending stuff through MQ, through the browser, simply returns an integer just to test
        [HttpPost("Recognition")]
        public async Task<IActionResult> PostRecognition(IFormFile files)
        {
            return await _videoservice.PostRecognition(files);

        }

        //example of method for sending stuff through MQ, through the browser, simply returns an integer just to test
        [HttpPost("Training")]
        public async Task<IActionResult> PostTraining(IFormFile file ,string abNumber)
        {
            return await _videoservice.PostTraining(file,abNumber);
        }
    }
}


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BigBrotherAPI.Models;

namespace BigBrotherAPI.Services
{
    public interface IVideoService
    {
        Task<IActionResult> PostRecognition(IFormFile files);
        Task<IActionResult> PostTraining(IFormFile file, string abNumber);
    }
}

using Microsoft.AspNetCore.Http;

namespace BigBrotherAPI.Models
{
    public class TrainingModels
    {
        public string id { get; set; }
        public int personName { get; set; }
        public IFormFile files { get; set; }
        public TeamsModel team { get; set; }
    }
     
}

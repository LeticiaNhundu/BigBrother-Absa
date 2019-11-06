using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Models
{
    public class PersonEmotionsModel
    {
        public int emotionFk { get; set; }
        public int personFk { get; set; }
        public double percentage { get; set; }
        public DateTime emotionDate { get; set; }
    }
}

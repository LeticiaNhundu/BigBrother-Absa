using BigBrotherAPI.Entities;
using BigBrotherAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Services
{
    public interface IEmotionService
    {
        List<Emotions> GetAllEmotions();
        Emotions GetEmotion(int id);
        List<Emotions> SaveEmotion(Emotions emotion);
        List<Emotions> UpdateEmotion(Emotions emotion);
        List<Emotions> DeleteEmotion(int id);
    }
}

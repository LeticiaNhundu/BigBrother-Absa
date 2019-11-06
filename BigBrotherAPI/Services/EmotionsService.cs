using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherAPI.Entities;
using BigBrotherAPI.Models;
using BigBrotherAPI.Repositories;

namespace BigBrotherAPI.Services
{
    public class EmotionsService : IEmotionService
    {
        private readonly IEmotionsRepo _repo;
        public EmotionsService(IEmotionsRepo repo)
        {
            _repo = repo;
        }

        public List<Emotions> DeleteEmotion(int id)
        {
            Emotions emotion = GetEmotion(id);
            _repo.Delete(emotion);
            return _repo.GetAllEmotions();

        }

        public List<Emotions> GetAllEmotions()
        {
            return _repo.GetAllEmotions();
        }

        public Emotions GetEmotion(int id)
        {
            return _repo.GetById(id);
        }

        public List<Emotions> SaveEmotion(Emotions emotion)
        {
            _repo.Insert(emotion);
            _repo.Save();
            return _repo.GetAllEmotions();
        }

        public List<Emotions> UpdateEmotion(Emotions emotion)
        {
            _repo.Update(emotion);
            _repo.Save();
            return _repo.GetAllEmotions();
        }
    }
}

using BigBrotherAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Repositories
{
    public interface IPersonEmotionsRepo
    {
        List<PersonEmotions> GetAllPersonEmotions();
        PersonEmotions GetByPersonEmotion(int personId, int emotionId);
        List<PersonEmotions> GetAllPersonEmotionByDate(DateTime startDate, DateTime endDate);
        //void Insert(PersonEmotions personEmotion);
        //void Update(PersonEmotions personEmotion);
       // void Delete(PersonEmotions personEmotion);
        PersonEmotions GetById(int id);
        void Save();
    }
}

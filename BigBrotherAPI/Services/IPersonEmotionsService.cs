using BigBrotherAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Services
{
    public interface IPersonEmotionsService
    {
        List<PersonEmotions> GetAllPersonEmotions();
        PersonEmotions GetByPersonEmotion(int personId, int emotionId);
        List<PersonEmotions> GetAllPersonEmotionByDate(DateTime startDate, DateTime endDate);
       // List<PersonEmotions> Insert(PersonEmotions personEmotion);
       // List<PersonEmotions> Update(PersonEmotions personEmotion);
       // List<PersonEmotions> Delete(int id);
    }
}

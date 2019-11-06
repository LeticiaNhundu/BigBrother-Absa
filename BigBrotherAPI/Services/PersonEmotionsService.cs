using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherAPI.DataContext;
using BigBrotherAPI.Entities;
using BigBrotherAPI.Models;
using BigBrotherAPI.Repositories;
using Microsoft.Extensions.Logging;

namespace BigBrotherAPI.Services
{
    public class PersonEmotionsService : IPersonEmotionsService
    {
        // Logger _log = new 
        private readonly IPersonEmotionsRepo _repo;
        private readonly IPersonRepo _personRepo;

        public PersonEmotionsService(IPersonEmotionsRepo repo, IPersonRepo personRepo)
        {
            _repo = repo;
            _personRepo = personRepo;
        }

     //   public List<PersonEmotions> Delete(int id)
     //   {
     //       PersonEmotions personEmotion = _repo.GetById(id);
     //       _repo.Delete(personEmotion);
     //       _repo.Save();
     //       return _repo.GetAllPersonEmotions();
     //   }

        public List<PersonEmotions> GetAllPersonEmotions()
        {
            return _repo.GetAllPersonEmotions();
        }

        public PersonEmotions GetByPersonEmotion(int personId, int emotionId)
        {
            return _repo.GetByPersonEmotion(personId, emotionId);
        }

        public List<PersonEmotions> GetAllPersonEmotionByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                DateTime _startDate = DateTime.ParseExact(startDate.ToString("yyyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);
                DateTime _endDate = DateTime.ParseExact(endDate.ToString("yyyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);


                List<PersonEmotions> allPersonEmotions = _repo.GetAllPersonEmotions();
                List<PersonEmotions> dateRangePersonEmotion = new List<PersonEmotions>();

                for (int i = 0; i < allPersonEmotions.Count; i++)
                {
                    if (allPersonEmotions[i].emotion_date.Date >= startDate.Date && allPersonEmotions[i].emotion_date.Date <= endDate.Date)
                    {
                        dateRangePersonEmotion.Add(allPersonEmotions[i]);
                    }
                }

                return dateRangePersonEmotion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     //   public List<PersonEmotions> Insert(PersonEmotions personEmotion)
     //   {
      //      _repo.Insert(personEmotion);
     //       _repo.Save();
     //       return _repo.GetAllPersonEmotions();
     //   }

     //   public List<PersonEmotions> Update(PersonEmotions personEmotion)
     //   {
     //       _repo.Update(personEmotion);
     //       _repo.Save();
     //       return _repo.GetAllPersonEmotions();
    //    }
    }
}

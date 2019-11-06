using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherAPI.DataContext;
using BigBrotherAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BigBrotherAPI.Repositories
{
    public class PersonEmotionsRepo : IPersonEmotionsRepo
    {
        private readonly BbAppContext _context;

        public PersonEmotionsRepo(BbAppContext context)
        {
            _context = context;
        }

      //  public void Delete(PersonEmotions personEmotion)
      //  {
      //      _context.PersonEmotions.Remove(personEmotion);
      //  }

        public List<PersonEmotions> GetAllPersonEmotions()
        {
            return _context.PersonEmotions.ToList();
        }

        public PersonEmotions GetById(int id)
        {
            return _context.PersonEmotions.Where(x => x.id == id).FirstOrDefault();
        }

        public PersonEmotions GetByPersonEmotion(int personId, int emotionId)
        {
            return _context.PersonEmotions.Where(x => x.person_fk == personId && x.emotion_fk == emotionId).FirstOrDefault();
        }

        public List<PersonEmotions> GetAllPersonEmotionByDate(DateTime startDate, DateTime endDate)
        {
            return _context.PersonEmotions.Where(x => startDate >= x.emotion_date.Date && x.emotion_date <= endDate).ToList();
       }

      //  public void Insert(PersonEmotions personEmotion)
      //  {
      //      _context.PersonEmotions.Add(personEmotion);
     //   }

        public void Save()
        {
            _context.SaveChanges();
        }

     //   public void Update(PersonEmotions personEmotion)
     //   {
     //       _context.Entry(personEmotion).State = EntityState.Modified;
     //   }


    }
}

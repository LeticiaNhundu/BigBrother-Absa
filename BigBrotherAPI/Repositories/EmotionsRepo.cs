using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BigBrotherAPI.Repositories
{
    public class EmotionsRepo : IEmotionsRepo
    {

        private readonly DataContext.BbAppContext _context;

        public EmotionsRepo(DataContext.BbAppContext context)
        {
            _context = context;
        }
        public void Delete(Emotions emotion)
        {
            _context.Emotion.Remove(emotion);
        }

        public List<Emotions> GetAllEmotions()
        {
            return _context.Emotion.ToList();
        }

        public Emotions GetById(int id)
        {
            return _context.Emotion.Where(x => x.emotion_id == id).FirstOrDefault();
        }

        public void Insert(Emotions emotion)
        {
            _context.Emotion.Add(emotion);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Emotions emotion)
        {
            _context.Entry(emotion).State = EntityState.Modified;
        }
    }
}

using BigBrotherAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Repositories
{
    public interface IEmotionsRepo
    {
        List<Emotions> GetAllEmotions();
        Emotions GetById(int id);
        void Insert(Emotions emotion);
        void Update(Emotions emotion);
        void Delete(Emotions emotion);

        void Save();
    }
}

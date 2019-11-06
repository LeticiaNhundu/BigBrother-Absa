using BigBrotherAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Repositories
{
    public interface IPersonRepo
    {
        List<Person> GetAllPerson();
        Person GetByAbnumber(string abnumber);
        Person GetById(int id);
        void Insert(Person person);
        void Update(Person person);
        void Delete(Person person);

        void Save();
    }
}

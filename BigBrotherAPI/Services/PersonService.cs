using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherAPI.Entities;
using BigBrotherAPI.Models;
using BigBrotherAPI.Repositories;

namespace BigBrotherAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepo repo;
        public PersonService(IPersonRepo personRepo)
        {
            repo = personRepo;
        }

        public List<Person> DeletePerson(string abNumber)
        {
            Person person = this.GetPerson(abNumber);
            repo.Delete(person);
            repo.Save();
            return this.GetAllPerson();
        }

        public List<Person> GetAllPerson()
        {
            return repo.GetAllPerson();
        }

        public Person GetPerson(string abNumber)
        {
            return repo.GetByAbnumber(abNumber);
        }

        public Person GetPersonById(int id)
        {
            return repo.GetById(id);
        }

        public List<Person> SavePerson(Person person)
        {
            repo.Insert(person);
            repo.Save();
            return this.GetAllPerson();
        }

        public List<Person> UpdatePerson(Person person)
        {
            repo.Update(person);
            repo.Save();
            return this.GetAllPerson();
        }
    }
}

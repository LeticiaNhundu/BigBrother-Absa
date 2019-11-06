using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherAPI.DataContext;
using BigBrotherAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BigBrotherAPI.Repositories
{
    public class PersonRepo : IPersonRepo
    {
        private DataContext.BbAppContext _context;

        public PersonRepo(DataContext.BbAppContext context)
        {
            _context = context;
        }

        public void Delete(Person person)
        {
            _context.Person.Remove(person);
        }

        public List<Person> GetAllPerson()
        {
            return _context.Person.ToList();
        }

        public Person GetByAbnumber(string abnumber)
        {

            return _context.Person.Where(x => x.abnumber == abnumber).FirstOrDefault();

        }

        public Person GetById(int id)
        {
            return _context.Person.Where(x => x.person_id == id).FirstOrDefault();
        }

        public void Insert(Person person)
        {
            _context.Person.Add(person);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
        }
    }
}

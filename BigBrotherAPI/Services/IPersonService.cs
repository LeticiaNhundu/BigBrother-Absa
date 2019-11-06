using BigBrotherAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Services
{
    public interface IPersonService
    {
        List<Person> GetAllPerson();
        Person GetPerson(string abNumber);
        Person GetPersonById(int id);
        List<Person> SavePerson(Person person);
        List<Person> UpdatePerson(Person person);
        List<Person> DeletePerson(string abNumber);

    }
}

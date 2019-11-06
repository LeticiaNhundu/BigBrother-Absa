using BigBrotherAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Repositories
{
    public interface ITeamRepo
    {
        List<Teams> GetAllTeams();
        Teams GetByName(string teamName);
        Teams GetById(int id);
        void Insert(Teams team);
        void Update(Teams team);
        void Delete(Teams team);

        void Save();
    }
}

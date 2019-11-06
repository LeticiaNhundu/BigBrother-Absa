using BigBrotherAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Repositories
{
    public interface ITeamPersonRepo
    {
        List<TeamPerson> GetAll();
        List<TeamPerson> GetByTeam(int teamId);
        TeamPerson GetByTeamPerson(int teamId, int personId);
        List<TeamPerson> GetByPerson(int personId);
        void Insert(TeamPerson teamPerson);
        void Update(TeamPerson teamPerson);
        void Delete(TeamPerson teamPerson);
        void Save();
    }
}

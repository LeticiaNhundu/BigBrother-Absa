using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherAPI.Entities;
using BigBrotherAPI.Repositories;

namespace BigBrotherAPI.Services
{
    public class TeamPersonService : ITeamPersonService
    {
        private readonly ITeamPersonRepo _repo;

        public TeamPersonService(ITeamPersonRepo repo)
        {
            _repo = repo;
        }

        public List<TeamPerson> Delete(int teamId, int personId)
        {
            TeamPerson teamPerson = _repo.GetByTeamPerson(teamId, personId);
            _repo.Delete(teamPerson);
            _repo.Save();
            return _repo.GetAll();
        }

        public List<TeamPerson> GetAllTeamPerson()
        {
            return _repo.GetAll();
        }

        public List<TeamPerson> GetByPerson(int personId)
        {
            return _repo.GetByPerson(personId);
        }

        public List<TeamPerson> GetByTeam(int teamId)
        {
            return _repo.GetByTeam(teamId);
        }

        public List<TeamPerson> Insert(TeamPerson teamPerson)
        {
            _repo.Insert(teamPerson);
            _repo.Save();
            return _repo.GetAll();
        }

        public List<TeamPerson> Update(TeamPerson teamPerson)
        {
            _repo.Update(teamPerson);
            _repo.Save();
            return _repo.GetAll();
        }
    }
}

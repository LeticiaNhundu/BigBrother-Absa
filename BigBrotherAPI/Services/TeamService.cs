using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherAPI.Entities;
using BigBrotherAPI.Repositories;

namespace BigBrotherAPI.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepo _repo;

        public TeamService(ITeamRepo repo)
        {
            _repo = repo;
        }

        public List<Teams> DeleteTeam(int teamId)
        {
            Teams team = GetTeamById(teamId);
            _repo.Delete(team);
            _repo.Save();

            return _repo.GetAllTeams();

        }

        public List<Teams> GetAllTeams()
        {
            return _repo.GetAllTeams();
        }

        public Teams GetTeamByName(string teamName)
        {
            return _repo.GetByName(teamName);
        }

        public Teams GetTeamById(int teamId)
        {
            return _repo.GetById(teamId);
        }

        public List<Teams> SaveTeam(Teams team)
        {
             _repo.Insert(team);
            _repo.Save();
            return _repo.GetAllTeams();
        }

        public List<Teams> UpdateTeam(Teams team)
        {
            _repo.Update(team);
            _repo.Save();
            return _repo.GetAllTeams();
        }
    }
}

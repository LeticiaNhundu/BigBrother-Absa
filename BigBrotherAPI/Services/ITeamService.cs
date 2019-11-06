using BigBrotherAPI.Entities;
using BigBrotherAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Services
{
    public interface ITeamService
    {
        List<Teams> GetAllTeams();
        Teams GetTeamByName(string teamName);
        Teams GetTeamById(int teamId);
        List<Teams> SaveTeam(Teams team);
        List<Teams> UpdateTeam(Teams team);
        List<Teams> DeleteTeam(int teamId);
    }
}

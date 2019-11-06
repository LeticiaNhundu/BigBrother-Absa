using BigBrotherAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Services
{
    public interface ITeamPersonService
    {
        List<TeamPerson> GetAllTeamPerson();
        List<TeamPerson> GetByTeam(int teamId);
        List<TeamPerson> GetByPerson(int personId);
        List<TeamPerson> Insert(TeamPerson teamPerson);
        List<TeamPerson> Update(TeamPerson teamPerson);
        List<TeamPerson> Delete(int teamId, int personId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherAPI.DataContext;
using BigBrotherAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BigBrotherAPI.Repositories
{
    public class TeamPersonRepo : ITeamPersonRepo
    {
        private readonly BbAppContext _context;

        public TeamPersonRepo(BbAppContext context)
        {
            _context = context;
        }

        public void Delete(TeamPerson teamPerson)
        {
            _context.TeamPerson.Remove(teamPerson);
        }

        public List<TeamPerson> GetAll()
        {
            return _context.TeamPerson.ToList();
        }

        public List<TeamPerson> GetByPerson(int personId)
        {
            return _context.TeamPerson.Where(x => x.person_fk == personId).ToList();
        }

        public List<TeamPerson> GetByTeam(int teamId)
        {
            return _context.TeamPerson.Where(x => x.team_fk == teamId).ToList();
        }

        public TeamPerson GetByTeamPerson(int teamId, int personId)
        {
            return _context.TeamPerson.Where(x => x.team_fk == teamId && x.person_fk == personId).FirstOrDefault();
        }

        public void Insert(TeamPerson teamPerson)
        {
            _context.TeamPerson.Add(teamPerson);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TeamPerson teamPerson)
        {
            _context.Entry(teamPerson).State = EntityState.Modified;

        }
    }
}

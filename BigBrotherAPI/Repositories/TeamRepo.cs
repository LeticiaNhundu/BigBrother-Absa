using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BigBrotherAPI.DataContext;
using BigBrotherAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BigBrotherAPI.Repositories
{
    public class TeamRepo : ITeamRepo
    {
        private readonly BbAppContext _context;

        public TeamRepo(BbAppContext context)
        {
            _context = context;
        }
        public void Delete(Teams team)
        {
            _context.Teams.Remove(team);
        }

        public List<Teams> GetAllTeams()
        {
            return _context.Teams.ToList();
        }

        public Teams GetById(int id)
        {
            return _context.Teams.Where(x => x.team_id == id).FirstOrDefault();
        }

        public Teams GetByName(string teamName)
        {
            return _context.Teams.Where(x => x.team_name == teamName).FirstOrDefault();
        }

        public void Insert(Teams team)
        {
            _context.Teams.Add(team);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Teams team)
        {
            _context.Entry(team).State = EntityState.Modified;
        }
    }
}
